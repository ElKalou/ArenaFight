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
        public IEnumerator True_If_Clicked_On_Selectable()
        {
            //Arrange
            Camera mainCam = Camera.main;

            UnitFactory factory = new GameObject().AddComponent<UnitFactory>();
            factory.Init();
            InteractorController interactor = new InteractorController(mainCam);

            //Act
            Unit spawnedUnit = factory.SpawnUnit(A.UnitPrefab(), A.RandomTransform());
            yield return null; //for the navmesh agent to find a mesh
            mainCam.transform.position = spawnedUnit.transform.position + new Vector3(10.0f, 10.0f, 10.0f);
            mainCam.transform.LookAt(spawnedUnit.transform.position);

            bool clikedOnUnit = interactor.ClickOnSelectable(mainCam.WorldToScreenPoint(spawnedUnit.transform.position));

            //Assert
            Assert.IsTrue(clikedOnUnit);
        }

        [UnityTest]
        public IEnumerator False_Otherwise()
        {
            //Arrange
            Camera mainCam = Camera.main;

            UnitFactory factory = new GameObject().AddComponent<UnitFactory>();
            factory.Init();
            InteractorController interactor = new InteractorController(mainCam);

            //Act
            Unit spawnedUnit = factory.SpawnUnit(A.UnitPrefab(), A.RandomTransform());
            yield return null; //for the navmesh agent to find a mesh (but pos of the spawned unit does not change..)
            mainCam.transform.position = spawnedUnit.transform.position + new Vector3(10.0f, 10.0f, 10.0f);
            mainCam.transform.LookAt(spawnedUnit.transform.position);

            bool clikedOnUnit = interactor.ClickOnSelectable(
                mainCam.WorldToScreenPoint(spawnedUnit.transform.position) + new Vector3(100,100,100));

            //Assert
            Assert.IsFalse(clikedOnUnit);
        }
    }
}
