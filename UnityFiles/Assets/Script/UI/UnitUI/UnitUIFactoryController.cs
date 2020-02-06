using UnityEditor;

public class UnitUIFactoryController
{
    private IUnitUIFactory _factory;

    public UnitUIFactoryController(IUnitUIFactory factory)
    {
        _factory = factory;
    }

    public IUnitUI SetUpUnitUI(UnitUI toSetUp, IUnit data)
    {
        toSetUp.Init(data);
        _factory.instanceManager.RegisterNewElement(toSetUp);
        return toSetUp;
    }
}
