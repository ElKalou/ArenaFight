using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EventTest
    {
        [Test]
        public void Receive_Input_Event()
        {
            bool inputEventReceived = false;
            InputEvent eventObserved = A.SO<InputEvent>();
            ScriptableObject sentData = A.SO<ScriptableObject>();

            IEventListener<InputEvent, ScriptableObject> listener = 
                Substitute.For<IEventListener<InputEvent, ScriptableObject>>();
            listener.eventToListen.Returns(eventObserved);
            listener.When(x => x.OnReceiveEvent(A.SO<ScriptableObject>())).Do(x => inputEventReceived = true);
           
            IEventEmitter<InputEvent, ScriptableObject> emitter = 
                Substitute.For<IEventEmitter<InputEvent, ScriptableObject>>();
            emitter.eventToSend.Returns(eventObserved);
            emitter.boundData.Returns(sentData);

            A.EventListenerController<InputEvent, InputEventListener, ScriptableObject>(
                    listener, new GameObject(), new InputEventListener.BindEvent()).AddListenerComponent();

            new EventEmitterController<InputEvent, ScriptableObject>(emitter).RaiseEvent(emitter);

            Assert.IsTrue(inputEventReceived);
        }
    }
}
