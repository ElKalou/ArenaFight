using UnityEngine;

public static class Util
{
    public static string GetRandomString()
    {
        string randomGenerator = "azertyuiopkqjflrzkg^pzka^pf,kpojnfmùq";
        string randomString = "";
        for (int i = 0; i < 10; i++)
        {
            randomString += randomGenerator[Random.Range(0, randomGenerator.Length)];
        }
        return randomString;
    }
}
