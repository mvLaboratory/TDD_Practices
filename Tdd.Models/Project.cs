using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Tdd.Models.Enums;

namespace Tdd.Models
{
  [Table("Projects")]
  public class Project : Entity
  {
    public string Name { get; set; }
    public int Sum { get; set; }
    public ProjectType ProjectType { get; set; }
    public HashSet<Document> Documents { get; set; } = new HashSet<Document>();
  }
}