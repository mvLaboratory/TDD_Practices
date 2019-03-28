using System.ComponentModel.DataAnnotations;

namespace Tdd.Models 
{
  public abstract class Entity
  {
    [Key]
    public int Id { get; set; }
  }
}