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
            Unit spawnedUnit = factory.SpawnUnit(A.UnitPrefab(), A.RandomTransform());

            Assert.NotNull(spawnedUnit.unitInfo);
        }

        [Test]
        public void Intitialize_With_Proper_Unit_Template()
        {
            Unit prefabUnit = A.UnitPrefab();
            UnitInfo originalUnitInfoTemplate = prefabUnit.UnitInfoTemplate;

            Unit spawnedUnit = factory.SpawnUnit(prefabUnit, A.RandomTransform());
            UnitInfo spawnedUnitInfoTemplate = spawnedUnit.UnitInfoTemplate;

            Assert.AreEqual(originalUnitInfoTemplate, spawnedUnitInfoTemplate);
        }

        [Test]
        public void Send_Unit_Event_Containing_Unit_Info_When_Instanciated()
        {
            Unit originalPrefab = A.UnitPrefab();

            UnitInfo receivedUnitInfo = null;

            UnitEventListener.AddComponentAtRunTime(
                new GameObject(),
                originalPrefab.eventSetupUI, 
                (UnitInfo unitInfo) => { receivedUnitInfo = unitInfo; }
                );
  
            Unit spawnedUnit = factory.SpawnUnit(A.UnitPrefab(), A.RandomTransform());
            UnitInfo originalUnitInfo = spawnedUnit.unitInfo;

            Assert.AreEqual(originalUnitInfo, receivedUnitInfo);

            originalPrefab.eventSetupUI.ResetEvent();
        }

    }
}
