using NSubstitute;
using UnityEngine;

public class UnitUIFactoryBuilder
{
    private IUnitUIFactory _factory;

    public UnitUIFactoryBuilder()
    {
        _factory = Substitute.For<IUnitUIFactory>();
    }

    public UnitUIFactoryBuilder With(UnitUIManager instanceManager)
    {
        _factory.instanceManager.Returns(instanceManager);
        return this;
    }

    public UnitUIFactoryBuilder With(UnitUIManager instanceManager, Transform instanceParent)
    {
        _factory.instanceManager.Returns(instanceManager);
        _factory.parentTransform.Returns(instanceParent);
        return this;
    }

    public IUnitUIFactory Build()
    {
        return _factory;
    }
}
