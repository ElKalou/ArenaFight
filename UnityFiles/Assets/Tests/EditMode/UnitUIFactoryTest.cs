using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class UnitUIFactoryTest
    {
        [Test]
        public void Set_Up_Unit_UI_From_Template_And_Pass_It_To_Manager()
        {
            //Arrange
            IUnit unit = A.MockUnit().Build();
            UnitUIManager manager = new GameObject().AddComponent<UnitUIManager>();
            IUnitUIFactory factory = A.MockUnitUIFactory().With(manager).Build();
            UnitUIFactoryController controller = new UnitUIFactoryController(factory);
            UnitUI toSetUp = new GameObject().AddComponent<UnitUI>();

            //Act
            controller.SetUpUnitUI(toSetUp, unit);

            //Assert
            Assert.AreEqual(toSetUp.dataToSend, unit);
            Assert.IsTrue(manager.workers.Contains(toSetUp));
        }

        /*
        [Test]
        public void Instantiate_From_Prefab()
        {
            IUnitUIFactory factory = A.MockUnitUIFactory().With(A.UnitUIManager(), A.RandomTransform(), A.UnitUIPrefab()).Build();

            UnitInfo unitInfo = ScriptableObject.CreateInstance<UnitInfo>();

            UnitUIFactoryController controller = new UnitUIFactoryController(factory);
            UnitUI spawnedUnit = controller.SpawnUnitUI(unitInfo); 
            UnitUI prefabOfTheSpawnedUnitUI = PrefabUtility.GetCorrespondingObjectFromSource(spawnedUnit);

            Assert.AreEqual(factory.prefab, prefabOfTheSpawnedUnitUI);
        }

        [Test]
        public void Always_Init_Instantiated_Prefab()
        {
            IUnitUIFactory factory = A.MockUnitUIFactory().With(A.UnitUIManager(), A.RandomTransform(), A.UnitUIPrefab()).Build();
            UnitInfo unitInfo = ScriptableObject.CreateInstance<UnitInfo>();

            UnitUIFactoryController controller = new UnitUIFactoryController(factory);
            UnitUI spawnedUnit = controller.SpawnUnitUI(unitInfo);

            Assert.AreEqual(unitInfo, spawnedUnit.boundData);
        }

        [Test]
        public void Pass_Instance_To_Manager()
        {
            UnitUIManager instanceManager = A.UnitUIManager();
            IUnitUIFactory factory = A.MockUnitUIFactory().With(instanceManager, A.RandomTransform(), A.UnitUIPrefab()).Build();
            UnitInfo unitInfo = ScriptableObject.CreateInstance<UnitInfo>();

            UnitUIFactoryController controller = new UnitUIFactoryController(factory);
            UnitUI spawnedUnit = controller.SpawnUnitUI(unitInfo);

            Assert.True(instanceManager.managedUnitUI.Contains(spawnedUnit));
        }*/
    }
}
