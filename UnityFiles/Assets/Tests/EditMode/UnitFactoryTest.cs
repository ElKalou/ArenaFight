using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class UnitFactoryTest
    {
        UnitFactory unitFactory;
        int numberOfUnits;

        [SetUp]
        public void BeforeEveryTest()
        {
            unitFactory = new GameObject().AddComponent<UnitFactory>();
            unitFactory.Init();
            numberOfUnits = 20;
        }

        [Test]
        public void _Proper_Loading_()
        {
            Assert.NotNull(A.UnitPrefab());
            Assert.NotNull(An.Army().With(numberOfUnits));
        }

        [Test]
        public void Instantiate_Unit_From_Unit_Prefab()
        {
            Unit originalPrefab = A.UnitPrefab();
            Transform spawnTransform = A.RandomTransform();

            Unit spawnedUnit = unitFactory.SpawnUnit(originalPrefab, spawnTransform);
            Unit prefabOfTheSpawnedUnit = PrefabUtility.GetCorrespondingObjectFromSource(spawnedUnit);

            Assert.AreEqual(originalPrefab, prefabOfTheSpawnedUnit);
        }

        [Test]
        public void Spawn_Unit_With_Proper_Position_And_Rotation()
        {
            Unit originalPrefab = A.UnitPrefab();
            Transform spawnTransform = A.RandomTransform();

            Unit spawnedUnit = unitFactory.SpawnUnit(originalPrefab, spawnTransform);

            Assert.AreEqual(spawnedUnit.transform.position, spawnTransform.position);
            Assert.AreEqual(spawnedUnit.transform.rotation, spawnTransform.rotation);

        }

        [Test]
        public void Pass_Unit_Info_To_Unit_Manager()
        {
            Unit originalPrefab = A.UnitPrefab();
            Transform spawnTransform = A.RandomTransform();

            Unit spawnedUnit = unitFactory.SpawnUnit(originalPrefab, spawnTransform);
            Selectable spawnedSelectable = spawnedUnit.GetComponent<Selectable>();

            Assert.True(unitFactory.unitManager.selectables.Contains(spawnedSelectable));
        }

        [Test]
        public void Instantiate_Units_As_Children_Of_Factory()
        {
            ArmyData army = An.Army().With(numberOfUnits);
            List<Transform> spawnTransforms = A.ListOfTransform(numberOfUnits);

            unitFactory.SpawnArmy(army.units, spawnTransforms);
            Unit[] instanciatedUnits = unitFactory.GetComponentsInChildren<Unit>();

            Assert.AreEqual(instanciatedUnits.Length, army.units.Count);
        }

        [Test]
        public void Instantiate_Units_From_Army_Data()
        {
            ArmyData army = An.Army().With(numberOfUnits);
            List<Transform> spawnTransforms = A.ListOfTransform(numberOfUnits);

            List<Unit> instanciatedUnits = unitFactory.SpawnArmy(army.units, spawnTransforms);
            List<Unit> prefabsOfTheSpawnedUnits = new List<Unit>();
            foreach (Unit unit in instanciatedUnits)
                prefabsOfTheSpawnedUnits.Add(PrefabUtility.GetCorrespondingObjectFromSource(unit));

            Assert.AreEqual(army.units, prefabsOfTheSpawnedUnits);
        }

        [Test]
        public void Spawn_Units_With_Proper_Position_And_Rotation()
        {
            ArmyData army = An.Army().With(numberOfUnits);
            List<Transform> spawnTransforms = A.ListOfTransform(numberOfUnits);

            List<Unit> instanciatedUnits = unitFactory.SpawnArmy(army.units, spawnTransforms);

            List<Transform> transformsOfTheSpawnUnits = new List<Transform>();
            foreach (Unit unit in instanciatedUnits)
                transformsOfTheSpawnUnits.Add(unit.transform);

            float eps = float.Epsilon;
            for (int i = 0; i < transformsOfTheSpawnUnits.Count; i++)
            {
                 Assert.GreaterOrEqual(eps, Vector3.Magnitude(spawnTransforms[i].position - transformsOfTheSpawnUnits[i].position));
                 Assert.GreaterOrEqual(eps, Vector3.Magnitude(spawnTransforms[i].eulerAngles - transformsOfTheSpawnUnits[i].eulerAngles));
            }
        }

        [Test]
        public void Pass_Units_Info_To_Unit_Manager()
        {
            ArmyData army = An.Army().With(numberOfUnits);
            List<Transform> spawnTransforms = A.ListOfTransform(numberOfUnits);

            List<Unit> instanciatedUnits = unitFactory.SpawnArmy(army.units, spawnTransforms);

            Selectable[] instanciatedSelectables = new Selectable[instanciatedUnits.Count];

            for (int i = 0; i < instanciatedUnits.Count; i++)
            {
                instanciatedSelectables[i] = instanciatedUnits[i].GetComponent<Selectable>();
                Assert.True(unitFactory.unitManager.selectables.Contains(instanciatedSelectables[i]));
            }
        }

        

    }
}
