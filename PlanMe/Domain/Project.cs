using System;
using System.Collections.Generic;

namespace PlanMe.Domain;

public class Project : TaskContainer
{
    private readonly List<Project> _subProjects;
    
    public Project(string id)
    {
        Id = id;
        _subProjects = new List<Project>();
    }
    
    public string Id { get; }

    public string Name { get; set; }

    public IReadOnlyList<Project> SubProject => _subProjects;
    
    public DateTime ExpectedStartDate { get; set; }

    public DateTime ExpectedCompleteDate { get; set; }

    public TimeSpan ExpectedWorkingTime { get; set; }

    public DateTime ActualStartDate { get; set; }

    public DateTime ActualCompleteDate { get; set; }

    public TimeSpan ActualWorkingTime { get; set; }

    public Project ParentProject { get; private set; }

    public Project AddProject(string name)
    {
        var project = new Project(IdGenerator.New("P"))
        {
            Name = name
        };
        AddProject(project);
        return project;
    }
    
    public void AddProject(Project project)
    {
        _subProjects.Add(project);
        project.ParentProject = this;
    }

    public void AddProjects(IEnumerable<Project> projects)
    {
        foreach (var project in projects)
        {
            AddProject(project);
        }
    }

    public void Remove(Project project)
    {
        if (!_subProjects.Contains(project)) return;
        _subProjects.Remove(project);
        project.ParentProject = null;
    }

    public void MoveProject(Project project, Project target)
    {
        Remove(project);
        target.AddProject(project);
    }
    
    public void ChangeIndex(Project project, int targetIndex)
    {
        if (!_subProjects.Contains(project) || _subProjects.IndexOf(project) == targetIndex) return;
        if (_subProjects.IndexOf(project) < targetIndex)
        {
            targetIndex--;
        }
        
        _subProjects.Remove(project);
        _subProjects.Insert(targetIndex, project);
    }
}