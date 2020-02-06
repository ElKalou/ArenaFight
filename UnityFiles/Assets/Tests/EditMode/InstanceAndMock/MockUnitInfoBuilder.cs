using System.Collections.Generic;
using NSubstitute;
using UnityEngine;

public class MockUnitInfoTemplateBuilder
{
    private IUnitTemplate _unitInfo;

    public MockUnitInfoTemplateBuilder()
    {
        _unitInfo = Substitute.For<IUnitTemplate>();
        _unitInfo.competenceTemplates.Returns(new List<ICompetenceTemplate>());
        _unitInfo.displacement.Returns(Random.Range(0.0f, 100.0f));
        _unitInfo.maxLife.Returns(Random.Range(0, 100));
        _unitInfo.name.Returns(Util.GetRandomString());
    }

    public MockUnitInfoTemplateBuilder WithCompetences(List<ICompetenceTemplate> competences)
    {
        _unitInfo.competenceTemplates.Returns(competences);
        return this;
    }

    /*public MockUnitInfoTemplateBuilder WithCompetences(int numberOfCompetencesToReturn)
    {
        List<Competence> competencesToReturn = new List<Competence>();
        for (int i = 0; i < numberOfCompetencesToReturn; i++)
        {
            competencesToReturn.Add(ScriptableObject.CreateInstance<MoveCompetence>());
        }
        _unitInfo.competenceTemplates.Returns(competencesToReturn);
        return this;
    }*/

    public IUnitTemplate Build()
    {
        return _unitInfo;
    }
}
