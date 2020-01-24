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
            UnitUI prefab = A.UnitUIPrefab();
            IUnitUIFactory factory = A.MockUIFactory().With(A.UnitUIManager(), A.RandomTransform(), prefab).Build();
            UnitUIFactoryController controller = new UnitUIFactoryController(factory);

            UnitInfo unitInfo = ScriptableObject.CreateInstance<UnitInfo>();

            UnitUI instance = controller.SpawnUnitUI(unitInfo);

            Assert.NotNull(instance.attachedUnit);
            Assert.AreEqual(unitInfo, instance.attachedUnit);
        }

        [Test]
        public void Instanciate_Competence_Button_From_Prefab()
        {
            IUnitUI unitUI = Substitute.For<IUnitUI>();
            unitUI.buttonPrefab.Returns(A.CompetenceButtonPrefab());
            unitUI.parentTransform.Returns(A.RandomTransform());

            UnitUIController controller = new UnitUIController(unitUI);
            IUnitInfo unitInfo = A.MockUnitInfo().WithCompetences(5).Build();

            List<CompetenceButton> instanceCompetenceButtons = controller.SpawnCompetenceButtons(unitInfo.competences);

            foreach (CompetenceButton instance in instanceCompetenceButtons)
            {
                CompetenceButton prefabOfInstance = PrefabUtility.GetCorrespondingObjectFromSource(instance);
                Assert.AreEqual(unitUI.buttonPrefab, prefabOfInstance);
            }
        }

        [Test]
        public void Init_Competence_Button_After_Instanciation()
        {
            
        }

        [Test]
        public void Send_Event_Containing_Attached_Unit_On_Clik()
        {

        }
    }
}
