using System;
using Tdd.Models.Enums;

namespace DocumentCopyTask.Data.Dto
{
  public class ProjectUpdateInfo
  {
    public int ProjectId { get; set; }
    public DateTime UpdateDate { get; set; }
    public ProjectType ProjectType { get; set; } 
  }
}
