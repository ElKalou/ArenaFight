using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CompetenceButtonFactoryTest
    {
        [Test]
        public void Set_Up_Unit_UI_From_Template_And_Pass_It_To_Manager()
        {

            ICompetenceButtonFactory factory = A.CompetenceButtonFactory();
            CompetenceButton newButton = new GameObject().AddComponent<CompetenceButton>();
            Competence newCompetence = A.Competence();
            CompetenceButtonFactoryController controller = new CompetenceButtonFactoryController(factory);

            //Act
            controller.InitNewButton(newButton, newCompetence);

            //Assert
            Assert.AreEqual(newButton.dataToSend, newCompetence);
            Assert.IsTrue(factory.instanceManager.workers.Contains(newButton));
        }
    }
}
