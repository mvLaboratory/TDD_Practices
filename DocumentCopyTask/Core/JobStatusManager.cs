using System;
using System.IO;
using DocumentCopyTask.Data.Dto;
using DocumentCopyTask.Interfaces;
using Newtonsoft.Json;

namespace DocumentCopyTask.Core
{
  class JobStatusManager : IJobStatusManager
  {
    public ProjectUpdateInfo LastProcessedType1Project { get; private set; }
    public ProjectUpdateInfo LastProcessedType2Project { get; private set; }
    public bool IsProcessingFinished { get; private set; }

    public void Init()
    {
      LastProcessedType1Project = null;
      LastProcessedType2Project = null;

      LastProcessedProjectsDto savedStatus;
      if (!File.Exists(_fileStoragePath))
      {
        return;
      }

      try
      {
        savedStatus = JsonConvert.DeserializeObject<LastProcessedProjectsDto>(File.ReadAllText(_fileStoragePath));
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error while reading job state: {ex.Message}");
        //TODO:: implement Logger
        //_logger.Error($"Error while reading job state: {ex.Message}");
        return;
      }

      if (savedStatus != null && ValidateSavedLoadingStatus(savedStatus))
      {
        LastProcessedType1Project = savedStatus.LastProcessedType1Project;
        LastProcessedType2Project = savedStatus.LastProcessedType2Project;
      }
    }

    public void Save(ProjectUpdateInfo projUpdateInfo)
    {

      var dto = new LastProcessedProjectsDto
      {
        LastProcessedType1Project = LastProcessedType1Project,
        LastProcessedType2Project = LastProcessedType2Project
      };
      try
      {
        File.WriteAllText(_fileStoragePath, JsonConvert.SerializeObject(dto));
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error while saving job state: {ex.Message}");
        //TODO:: Implement logger;
        //_logger.Error($"Error while saving job state: {ex.Message}");
      }
    }

    private bool ValidateSavedLoadingStatus(LastProcessedProjectsDto savedStatus)
    {
      //TODO:: Implement real logic
      return true;
    }

    private readonly string _fileStoragePath = AppDomain.CurrentDomain.BaseDirectory + "LoadingStatus.json";

  }
}