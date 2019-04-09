using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentCopyTask.Data.Dto;

namespace DocumentCopyTask.Interfaces
{
  public interface IJobStatusManager
  {
    ProjectUpdateInfo LastProcessedType1Project {get;}
    ProjectUpdateInfo LastProcessedType2Project {get;}

    void Init();
    void Save(ProjectUpdateInfo projUpdateInfo);
  }
}
