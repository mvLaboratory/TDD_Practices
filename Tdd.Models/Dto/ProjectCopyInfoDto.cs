using System;
using Tdd.Models.Enums;

namespace Tdd.Models.Dto
{
  public class ProjectCopyInfoDto
  {
    public int ProjectId { get; set; }
    public DateTime UpDate { get; set; }
    public ProjectType ProjectType { get; set; }
  }
}
