using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class UnitUITest
    {
        [Test]
        public void Init_UnitUI_When_Instanciated_By_Factory()
        {
            //Arrange
            UnitUI prefab = A.UnitUIPrefab();
            IUnitUIFactory factoryView = A.MockUIFactory().With(A.UnitUIManager(), A.RandomTransform(), prefab).Build();
            UnitUIFactoryController factoryController = new UnitUIFactoryController(factoryView);

            UnitInfo unitInfo = ScriptableObject.CreateInstance<UnitInfo>();

            //Act
            UnitUI instance = factoryController.SpawnUnitUI(unitInfo);

            //Test
            Assert.NotNull(instance.boundData);
            Assert.AreEqual(unitInfo, instance.boundData);
        }

        [Test]
        public void Instanciate_Competence_Button_From_Prefab()
        {
            //Arrange
            IUnitUI unitUI = Substitute.For<IUnitUI>();
            unitUI.buttonPrefab.Returns(A.CompetenceButtonPrefab());
            unitUI.parentTransform.Returns(A.RectTransform());

            CompetenceButtonFactory controller = new CompetenceButtonFactory(unitUI);
            IUnitInfo unitInfo = A.MockUnitInfo().WithCompetences(5).Build();

            //Act
            List<CompetenceButton> instanceCompetenceButtons = controller.SpawnCompetenceButtons(unitInfo.competences);

            //Assert
            foreach (CompetenceButton instance in instanceCompetenceButtons)
            {
                CompetenceButton prefabOfInstance = PrefabUtility.GetCorrespondingObjectFromSource(instance);
                Assert.AreEqual(unitUI.buttonPrefab, prefabOfInstance);
            }
        }

        [Test]
        public void Init_Competence_Button_After_Instanciation()
        {
            //Arrange
            IUnitUI unitUI = Substitute.For<IUnitUI>();
            unitUI.buttonPrefab.Returns(A.CompetenceButtonPrefab());
            unitUI.parentTransform.Returns(A.RectTransform());

            CompetenceButtonFactory controller = new CompetenceButtonFactory(unitUI);
            IUnitInfo unitInfo = A.MockUnitInfo().WithCompetences(5).Build();

            //Act
            List<CompetenceButton> instanceCompetenceButtons = controller.SpawnCompetenceButtons(unitInfo.competences);

            //Assert
            for (int i = 0; i < instanceCompetenceButtons.Count; i++)
            {
                Assert.AreEqual(unitInfo.competences[i], instanceCompetenceButtons[i].boundCompetence);
            }
        }
    }
}
