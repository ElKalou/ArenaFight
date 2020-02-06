using System;

public class CompetenceButtonFactoryController
{
    ICompetenceButtonFactory _factory;

    public CompetenceButtonFactoryController(ICompetenceButtonFactory factory)
    {
        _factory = factory;
    }

    public void InitNewButton(CompetenceButton newButton, Competence competence)
    {
        newButton.Init(competence);
        _factory.instanceManager.RegisterNewElement(newButton);
    }
}