using NSubstitute;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class A 
{
    
    public static MockUnitBuilder MockUnit()
    {
        return new MockUnitBuilder();
    }

    public static List<Transform> ListOfTransform(int count)
    {
        List<Transform> toReturn = new List<Transform>();

        for (int i = 0; i < count; i++)            
            toReturn.Add(RandomTransform());

        return toReturn;
    }

    public static Transform RandomTransform()
    {
        Transform toReturn = new GameObject().GetComponent<Transform>();
        toReturn.position = 5 * Random.onUnitSphere;
        toReturn.eulerAngles = 360 * Random.onUnitSphere;
        return toReturn;
    }

    public static RectTransform RectTransform()
    {
        return new GameObject().AddComponent<RectTransform>();
    }

    public static UnitUI UnitUIPrefab()
    {
        return Resources.Load<UnitUI>("Test/UnitUITest");
    }

    public static CompetenceButton CompetenceButtonPrefab()
    {
        return Resources.Load<CompetenceButton>("Test/CompetenceButtonTest");
    }

    public static UnitUIManager UnitUIManager()
    {
        return new GameObject().AddComponent<UnitUIManager>();
    }

    public static UnitUIFactoryBuilder MockUnitUIFactory()
    {
        return new UnitUIFactoryBuilder();
    }

    public static MockUnitInfoTemplateBuilder MockUnitInfoTemplate()
    {
        return new MockUnitInfoTemplateBuilder();
    }

    public static InstanceType SO<InstanceType>() where InstanceType : ScriptableObject
    {
        return ScriptableObject.CreateInstance<InstanceType>();
    }

    public static UnitFactoryBuilder MockUnitFactory()
    {
        return new UnitFactoryBuilder();
    } 

    public static ICompetenceTemplate MockCompetenceTemplate()
    {
        ICompetenceTemplate template = Substitute.For<ICompetenceTemplate>();
        template.name.Returns(Util.GetRandomString());
        return template;
    }

    public static Competence Competence()
    {
        ICompetenceTemplate competanceTemplate = A.MockCompetenceTemplate();
        IUnit caster = A.MockUnit().Build();
        CompetenceFactory competenceFactory = new CompetenceFactory(caster);
        Competence newCompetence = competenceFactory.GetCompetenceInstanceFromTemplate(competanceTemplate);
        return newCompetence;
    }

    public static ICompetenceButtonFactory CompetenceButtonFactory()
    {
        ICompetenceButtonFactory toReturn = Substitute.For<ICompetenceButtonFactory>();
        CompetenceButtonManager manager = new GameObject().AddComponent<CompetenceButtonManager>();
        toReturn.instanceManager.Returns(manager);
        return toReturn;
    }
 
}
