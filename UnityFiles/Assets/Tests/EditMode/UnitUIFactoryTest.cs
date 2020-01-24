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
        public void Instantiate_From_Prefab()
        {
            IUnitUIFactory factory = A.MockUIFactory().With(A.UnitUIManager(), A.RandomTransform(), A.UnitUIPrefab()).Build();

            UnitInfo unitInfo = ScriptableObject.CreateInstance<UnitInfo>();

            UnitUIFactoryController controller = new UnitUIFactoryController(factory);
            UnitUI spawnedUnit = controller.SpawnUnitUI(unitInfo); 
            UnitUI prefabOfTheSpawnedUnitUI = PrefabUtility.GetCorrespondingObjectFromSource(spawnedUnit);

            Assert.AreEqual(factory.prefabUnitUI, prefabOfTheSpawnedUnitUI);
        }

        [Test]
        public void Always_Init_Instantiated_Prefab()
        {
            IUnitUIFactory factory = A.MockUIFactory().With(A.UnitUIManager(), A.RandomTransform(), A.UnitUIPrefab()).Build();
            UnitInfo unitInfo = ScriptableObject.CreateInstance<UnitInfo>();

            UnitUIFactoryController controller = new UnitUIFactoryController(factory);
            UnitUI spawnedUnit = controller.SpawnUnitUI(unitInfo);

            Assert.AreEqual(unitInfo, spawnedUnit.attachedUnit);
        }

        [Test]
        public void Pass_Instance_To_Manager()
        {
            UnitUIManager instanceManager = A.UnitUIManager();
            IUnitUIFactory factory = A.MockUIFactory().With(instanceManager, A.RandomTransform(), A.UnitUIPrefab()).Build();
            UnitInfo unitInfo = ScriptableObject.CreateInstance<UnitInfo>();

            UnitUIFactoryController controller = new UnitUIFactoryController(factory);
            UnitUI spawnedUnit = controller.SpawnUnitUI(unitInfo);

            Assert.True(instanceManager.managedUnitUI.Contains(spawnedUnit));
        }
    }
}
