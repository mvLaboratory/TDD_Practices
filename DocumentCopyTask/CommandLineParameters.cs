using System;
using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;

namespace DocumentCopyTask
{
  public class CommandLineParameters
  {
    [Option('p', "Project Type", HelpText = "0: All project types; 1: Public Projects; 2: Private Projects; Default: 0; -p 1")]
    public int ProjectType { get; set; } = 0;

    [HelpOption]
    public string GetUsage()
    {
      return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
    }

    public int WriteUsage()
    {
      Console.Error.WriteLine(GetUsage());
      return 2;
    }
  }
}
