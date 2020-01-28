using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class UnitTest
    {
        UnitFactory factory;

        [SetUp]
        public void BeforeEveryTest()
        {
            factory = new GameObject().AddComponent<UnitFactory>();
            factory.Init();
        }

        [Test]
        public void Always_Initialize_When_Instanciated_By_Factory()
        {
            //Arrange 
            Unit prefabUnit = A.UnitPrefab();
            //Act
            Unit spawnedUnit = factory.SpawnUnit(prefabUnit, A.RandomTransform());
            //Assert
            Assert.NotNull(spawnedUnit.boundData);
        }

        [Test]
        public void Intitialize_With_Proper_Unit_Template()
        {
            //Arrange
            Unit prefabUnit = A.UnitPrefab();
            UnitInfo originalUnitInfoTemplate = prefabUnit.UnitInfoTemplate;
            //Act
            Unit spawnedUnit = factory.SpawnUnit(prefabUnit, A.RandomTransform());
            UnitInfo spawnedUnitInfoTemplate = spawnedUnit.UnitInfoTemplate;
            //Assert
            Assert.AreEqual(originalUnitInfoTemplate, spawnedUnitInfoTemplate);
        }

        [Test]
        public void Send_Unit_Event_Containing_Unit_Info_When_Instanciated()
        {
            //Arrange           
            UnitInfo receivedUnitInfo = null;
            Unit originalPrefab = A.UnitPrefab();
            UnitEvent eventToReact = originalPrefab.eventToSend;

            UnitEventListener.AddComponentAtTestTime(
                new GameObject().AddComponent<UnitEventListener>(),
                eventToReact,
                (UnitInfo receivedData) => { receivedUnitInfo = receivedData; }
                );

            //Act                
            Unit spawnedUnit = factory.SpawnUnit(A.UnitPrefab(), A.RandomTransform());
            UnitInfo originalUnitInfo = spawnedUnit.boundData;

            //Assert
            Assert.AreEqual(originalUnitInfo, receivedUnitInfo);

            eventToReact.ResetEvent();
        }

        [TearDown]
        public void AfterEveryTest()
        {
            UnitEventListener[] _listeners = Object.FindObjectsOfType<UnitEventListener>();
            for (int i = 0; i < _listeners.Length; i++)
                Object.DestroyImmediate(_listeners[i]);

            UnitFactory[] _factories = Object.FindObjectsOfType<UnitFactory>();
            for (int i = 0; i < _factories.Length; i++)
                Object.DestroyImmediate(_factories[i]);

        }

    }
}
