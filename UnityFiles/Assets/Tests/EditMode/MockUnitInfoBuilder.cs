using System.Collections.Generic;
using NSubstitute;
using UnityEngine;

public class MockUnitInfoBuilder
{
    private IUnitInfo _unitInfo;

    public MockUnitInfoBuilder()
    {
        _unitInfo = Substitute.For<IUnitInfo>();
        _unitInfo.competences.Returns(new List<Competence>());
        _unitInfo.currentLife.Returns(Random.Range(0, 100));
        _unitInfo.displacement.Returns(Random.Range(0.0f, 100.0f));
        _unitInfo.maxLife.Returns(Random.Range(0, 100));
        string randomGenerator = "azertyuiop";
        string randomString = "";
        for (int i = 0; i < 10; i++)
        {
            randomString += randomGenerator[Random.Range(0, 10)];
        }
        _unitInfo.name.Returns(randomString);
    }

    public MockUnitInfoBuilder WithCompetences(List<Competence> competences)
    {
        _unitInfo.competences.Returns(competences);
        return this;
    }

    public MockUnitInfoBuilder WithCompetences(int numberOfCompetencesToReturn)
    {
        List<Competence> competencesToReturn = new List<Competence>();
        for (int i = 0; i < numberOfCompetencesToReturn; i++)
        {
            competencesToReturn.Add(ScriptableObject.CreateInstance<Competence>());
        }
        _unitInfo.competences.Returns(competencesToReturn);
        return this;
    }

    public IUnitInfo Build()
    {
        return _unitInfo;
    }
}
