using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityHealth.Infrastructure.Migrations
{
    public class MigrationSetupInitializer : Core.Application.IInitializer
    {
        private readonly Runner.Runner _runner;
        private readonly string _profile;

        public MigrationSetupInitializer() : this("DefaultConnection"){ /*...empty constructor */ }

        public MigrationSetupInitializer(string connString, string profile = "")
        {
            _runner = new Runner.Runner(connString);
            _profile = profile;
        }

        public void Initialize(Core.Application.EnvironmentProfile environment)
        {           
            _runner.MigrateUp(Runner.Runner.VersionLatest, _profile);
        }
    }
}
