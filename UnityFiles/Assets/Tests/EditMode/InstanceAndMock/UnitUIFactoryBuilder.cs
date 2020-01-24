using NSubstitute;
using UnityEngine;

public class UnitUIFactoryBuilder
{
    private IUnitUIFactory _factory;

    public UnitUIFactoryBuilder()
    {
        _factory = Substitute.For<IUnitUIFactory>();
    }

    public UnitUIFactoryBuilder With(UnitUIManager instanceManager, Transform instanceParent, UnitUI prefab)
    {
        _factory.instanceManager.Returns(instanceManager);
        _factory.parentTransform.Returns(instanceParent);
        _factory.prefabUnitUI.Returns(prefab);
        return this;
    }

    public IUnitUIFactory Build()
    {
        return _factory;
    }
}
