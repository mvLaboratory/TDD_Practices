using System.ComponentModel.DataAnnotations;

namespace TDD_Practices.Data
{
  public abstract class Entity
  {
    [Key]
    public int Id { get; set; }
  }
}