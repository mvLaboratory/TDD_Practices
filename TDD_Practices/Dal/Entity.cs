using System.ComponentModel.DataAnnotations;

namespace TDD_Practices.Dal
{
  public abstract class Entity
  {
    [Key]
    public int Id { get; set; }
  }
}