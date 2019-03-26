using System.ComponentModel.DataAnnotations.Schema;
using TDD_Practices.Data;

namespace TDD_Practices.Models
{
  [Table("DocumentIndex")]
  public class DocumentIndex : Entity
  {
    public int DocumentId { get; set; }
    public string DocText { get; set; }
  }
}