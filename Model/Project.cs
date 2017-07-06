using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOven.Model
{
    public class Project
    {
        public Project(string projectPath)
        {
            if (!File.Exists(projectPath))
            {
                throw new FileNotFoundException(projectPath);
            }
            Name = Path.GetFileNameWithoutExtension(projectPath);
            FullPath = Path.GetDirectoryName(projectPath);

            SetProjectType(FullPath);

        }

        private void SetProjectType(string projectPath)
        {
            if (projectPath.EndsWith(".Application", StringComparison.InvariantCultureIgnoreCase))
                Type = ProjectType.Application;

            if (projectPath.EndsWith(".Core", StringComparison.InvariantCultureIgnoreCase))
                Type = ProjectType.Core;

            if (projectPath.EndsWith(".EntityFrameworkCore", StringComparison.InvariantCultureIgnoreCase))
                Type = ProjectType.EntityFrameWorkCore;

            if (projectPath.EndsWith(".Migrator", StringComparison.InvariantCultureIgnoreCase))
                Type = ProjectType.Migrator;

            if (projectPath.EndsWith(".Web.Core", StringComparison.InvariantCultureIgnoreCase))
                Type = ProjectType.WebCore;

            if (projectPath.EndsWith(".Web.Host", StringComparison.InvariantCultureIgnoreCase))
                Type = ProjectType.WebHost;
        }

        public ProjectType Type { get; set; }

        public string Name { get; set; }

        public string FullPath { get; set; }

    }
}
