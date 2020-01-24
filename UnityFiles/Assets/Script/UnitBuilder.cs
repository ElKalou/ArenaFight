using UnityEngine;

public class UnitBuilder
{
    private Unit _unit;

    public UnitBuilder()
    {
        _unit = Resources.Load<Unit>(Random.Range(0.0f, 1.0f) < 0.5 ? "Test/UnitTest1" : "Test/UnitTest2");
    }

    public UnitBuilder(string path)
    {
        _unit = Resources.Load<Unit>(path);
    }

    public static implicit operator Unit(UnitBuilder unitBuilder) => unitBuilder.Build();

    public Unit Build()
    {
        return _unit;
    }
}
