using UnityEngine;

public class An
{
    public static ArmyDataBuilder Army()
    {
        return new ArmyDataBuilder();
    }

    public static ArmyDataBuilder Army(string path)
    {
        return new ArmyDataBuilder(path);
    }
}