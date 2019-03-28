using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tdd.Models
{
  [Table("Documents")]
  public class Document : Entity
  {
    public string Name { get; set; }
    public string Path { get; set; }
    public string Extension { get; set; }
    public DateTime UpdateDate { get; set; }
    
    public int ProjectId { get; set; }
    public Project Project { get; set; }
  }
}