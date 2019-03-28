// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Reflection;
using StructureMap.Pipeline;
using Tdd.Data.Repositories;
using TDD_Practices.Data.Factories;
using TDD_Practices.Utils;

namespace TDD_Practices.DependencyResolution {
  using StructureMap;
  using Tdd.Data;
  using Tdd.Data.Factories;

  public class DefaultRegistry : Registry {
    #region Constructors and Destructors

    public DefaultRegistry() {
      Scan(scan => {
        scan.TheCallingAssembly();
        scan.Assembly("Tdd.Data");
        scan.Assembly("Tdd.Models");
        scan.WithDefaultConventions();
			  scan.With(new ControllerConvention());
      });

      For<RdLabDbContext>().Use(context => CreateNewContext(context)).SetLifecycleTo(new TransientLifecycle());
      For<IEntityFactory>().Use<EntityFactory>().SetLifecycleTo(new SingletonLifecycle());
      For<IDocumentRepository>().Use<DocumentRepository>().SetLifecycleTo(new TransientLifecycle());
      For<IDocumentIndexRepository>().Use<DocumentIndexRepository>().SetLifecycleTo(new TransientLifecycle());
      For<IProjectRepository>().Use<ProjectRepository>().SetLifecycleTo(new TransientLifecycle());
    }

    public RdLabDbContext CreateNewContext(IContext context)
    {
      var myContext = new RdLabDbContext(AppSettingsManager.GetStringOrDefault("dbName", "rdLabDb"));
      myContext.Configuration.ProxyCreationEnabled = false;
      return myContext;
    }

    #endregion
  }
}