using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class UnitFactoryTest
    {

        [Test]
        public void Make_Dictionary()
        {
            //Arrange
            List<IUnit> prefabs = new List<IUnit>(){ A.MockUnit().Build(), A.MockUnit().Build(), A.MockUnit().Build()};
            int numberOfPrefabs = prefabs.Count;
            IUnitFactory unitFactory = A.MockUnitFactory().With(prefabs).Build();

            UnitFactoryController factoryController = new UnitFactoryController(unitFactory);

            //Act
            factoryController.MakeDictionnary();

            //Assert
            foreach (IUnit prefab in prefabs)
                Assert.IsTrue(factoryController.unitsAvailable.ContainsKey(prefab.template));
        }

        [Test]
        public void Get_Correct_Index_From_UnitInfoTemplate()
        {
            //Arrange
            List<IUnit> prefabs = new List<IUnit>() { A.MockUnit().Build(), A.MockUnit().Build(), A.MockUnit().Build() };
            int numberOfPrefabs = prefabs.Count;
            IUnitFactory unitFactory = A.MockUnitFactory().With(prefabs).Build();
            UnitFactoryController factoryController = new UnitFactoryController(unitFactory);

            //Act + Assert
            foreach (IUnit prefab in prefabs)
            {
                int returnIdx = factoryController.GetIndex(prefab.template);
                Assert.AreEqual(prefabs[returnIdx], prefab);
            }
        }

        [Test]
        public void Pass_Unit_To_Manager()
        {
            IUnitFactory unitFactory = A.MockUnitFactory().Build();
            UnitFactoryController factoryController = new UnitFactoryController(unitFactory);
            IUnit unitToPass = A.MockUnit().Build();

            factoryController.PassUnitToManager(A.MockUnit().Build());

            unitFactory.instanceManager.workers.Contains(unitToPass.selectable);
        }
        
    }
}
