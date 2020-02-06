using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class UnitTest
    {
        [Test]
        public void Instantiate_Competence_From_Template_Data()
        {
            //Arrange
            IUnit unit = A.MockUnit().Build();
            UnitController unitController = new UnitController(unit);
            List<ICompetenceTemplate> templates = new List<ICompetenceTemplate>()
            {
                A.MockCompetenceTemplate(), A.MockCompetenceTemplate(), A.MockCompetenceTemplate()
            };

            //Act
            List<Competence> instances = unitController.InitCompetences();

            //Assert          
            for (int i = 0; i < instances.Count; i++)
            {
                Assert.AreEqual(instances[i].template, templates[i]);
            }
        }      
    }
}
