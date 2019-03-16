using System;
using System.ComponentModel.DataAnnotations.Schema;
using TDD_Practices.Dal;

namespace TDD_Practices.Models
{
  [Table("Documents")]
  public class Document : Entity
  {
    public string Name { get; set; }
    public string Path { get; set; }
    public string Extention { get; set; }
    [Column(TypeName = "datetime2")]
    public DateTime UpdateDate { get; set; }
    
    public int ProjectId { get; set; }
    public Project Project { get; set; }
  }
}