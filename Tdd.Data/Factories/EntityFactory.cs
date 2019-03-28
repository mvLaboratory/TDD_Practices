using System;
using System.Collections.Generic;
using System.Text;
using Tdd.Data.Factories;
using Tdd.Models;

namespace TDD_Practices.Data.Factories
{
  public class EntityFactory : IEntityFactory
  {
    public Project GetProject()
    {
      var documentCount = _randomizer.Next(10, 50);
      var id = _randomizer.Next(2000000, 5000000);
      var project = new Project
      {
        Id = id,
        Name = $"Project {Guid.NewGuid()}",
        Sum = _randomizer.Next(1, 1000) * 10000,
        Documents = new HashSet<Document>()
      };
      for (int i = 0; i < documentCount; i++)
      {
        project.Documents.Add(GetDocument(project));
      }

      return project;
    }

    public Document GetDocument(Project project)
    {
      var id = _randomizer.Next(2000000, 5000000);
      var name = $"Document {Guid.NewGuid()}";
      var modificationDate = new DateTime(2019, _randomizer.Next(1, 12), _randomizer.Next(1, 28), _randomizer.Next(1, 24), _randomizer.Next(0, 59), _randomizer.Next(0, 59));
      var extenstion = _randomizer.Next(0, 2) == 0 ? "pdf" : "tif";
      return new Document
      {
        Project = project,
        Id = id,
        Extension = extenstion,
        Name = name,
        UpdateDate = modificationDate,
        Path = $"C://projectDocuments/{project.Id}/{name}.{extenstion}"
      };
    }

    public DocumentIndex GetDocIndex(int documentId)
    {
      var textBuilder = new StringBuilder();
      int length = _randomizer.Next(10, 25);
      for (int i = 0; i < length; i++)
      {
        textBuilder.Append((Char) _randomizer.Next(97, 122));
      }

      return new DocumentIndex {DocumentId = documentId, DocText = textBuilder.ToString()};
    } 

    private readonly Random _randomizer = new Random();
  }
}