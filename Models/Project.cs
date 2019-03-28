using System.Collections.Generic;
using TDD_Practices.Models;

namespace Models
{
  [Table("Projects")]
  public class Project : Entity
  {
    public string Name { get; set; }
    public int Sum { get; set; }
    public HashSet<Document> Documents { get; set; } = new HashSet<Document>();
  }
}