using System.Collections.Generic;
using UnityEngine;

public class A 
{
    
    public static UnitBuilder UnitPrefab()
    {
        return new UnitBuilder();
    }

    public static UnitBuilder UnitPrefab(string path)
    {
        return new UnitBuilder(path);
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

    public static UnitUIFactoryBuilder MockUIFactory()
    {
        return new UnitUIFactoryBuilder();
    }

    public static MockUnitInfoBuilder MockUnitInfo()
    {
        return new MockUnitInfoBuilder();
    }
}
