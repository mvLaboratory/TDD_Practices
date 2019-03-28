using System.ComponentModel.DataAnnotations.Schema;

namespace Tdd.Models
{
  [Table("DocumentIndex")]
  public class DocumentIndex : Entity
  {
    public int DocumentId { get; set; }
    public string DocText { get; set; }
  }
}