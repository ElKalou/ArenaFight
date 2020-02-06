using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class InteractorTest
    {
        [UnityTest]
        public IEnumerator True_If_Clicked_On_Selectable_With_Collider()
        {
            //Arrange
            Camera mainCam = Camera.main;
            InteractorController interactor = new InteractorController(mainCam);
            Selectable selectable = new GameObject().AddComponent<Selectable>();
            CapsuleCollider collider = selectable.gameObject.AddComponent<CapsuleCollider>();
            collider.radius = 1.5f;
            collider.height = 1.5f;
            collider.isTrigger = false;          
            selectable.transform.position = A.RandomTransform().position;
            yield return null;

            //Act
            mainCam.transform.position = selectable.transform.position + new Vector3(5.0f, 5.0f, 5.0f);
            mainCam.transform.LookAt(selectable.transform.position);

            bool clikedOnUnit = interactor.ClickOnSelectable(mainCam.WorldToScreenPoint(selectable.transform.position));

            //Assert
            Assert.IsTrue(clikedOnUnit);
        }

        [UnityTest]
        public IEnumerator False_Otherwise()
        {
            //Arrange
            Camera mainCam = Camera.main;
            InteractorController interactor = new InteractorController(mainCam);
            Selectable selectable = new GameObject().AddComponent<Selectable>();
            CapsuleCollider collider = selectable.gameObject.AddComponent<CapsuleCollider>();
            collider.radius = 1.5f;
            collider.height = 1.5f;
            collider.isTrigger = false;
            selectable.transform.position = A.RandomTransform().position;
            yield return null;

            //Act
            mainCam.transform.position = selectable.transform.position + new Vector3(5.0f, 5.0f, 5.0f);
            mainCam.transform.LookAt(selectable.transform.position);

            bool clikedOnUnit = interactor.ClickOnSelectable(mainCam.WorldToScreenPoint(-selectable.transform.position));

            //Assert
            Assert.IsFalse(clikedOnUnit);
        }
    }
}
