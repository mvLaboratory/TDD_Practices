using System.ComponentModel.DataAnnotations.Schema;
using TDD_Practices.Dal;

namespace TDD_Practices.Models
{
  [Table("Projects")]
  public class Project : Entity
  {
    public string Name { get; set; }
    public int Summ { get; set; }
  }
}