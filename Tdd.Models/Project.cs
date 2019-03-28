using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tdd.Models
{
  [Table("Projects")]
  public class Project : Entity
  {
    public string Name { get; set; }
    public int Sum { get; set; }
    public HashSet<Document> Documents { get; set; } = new HashSet<Document>();
  }
}