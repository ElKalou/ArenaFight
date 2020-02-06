using NSubstitute;
using UnityEngine;

public class MockUnitBuilder
{
    private IUnit _unit;
    private IUnitTemplate _unitInfo;
    private Transform _unitTransform;
    private ISelectable _selectable;


    public MockUnitBuilder()
    {
        _unit = Substitute.For<IUnit>();

        _unitInfo = A.MockUnitInfoTemplate().Build();

        _unitTransform = A.RandomTransform();

        _selectable = Substitute.For<ISelectable>();
    }

    public MockUnitBuilder With(IUnitTemplate unitInfo)
    {
        _unitInfo = unitInfo;
        return this;
    }

    public MockUnitBuilder With(Transform unitTransform)
    {
        _unitTransform = unitTransform;
        return this;
    }

    public IUnit Build()
    {
        _unit.template.Returns(_unitInfo);
        _unit.unitTransform.Returns(_unitTransform);
        _unit.selectable.Returns(_selectable);
        return _unit;
    }
}