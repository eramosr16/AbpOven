using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Data.Entity;
using System.Data.Entity.Design.PluralizationServices;

namespace AbpOven
{
    public static class Helper
    {
        /// <summary>
        /// Return the Project folder given the Project name
        /// </summary>
        /// <param name="projectName"></param>
        /// <returns>Path to project name</returns>
        public static string GetProjectDirectory(string projectName)
        {
            string path = Directory.GetCurrentDirectory();
            var idx = path.IndexOf(@"AbpOven", StringComparison.InvariantCultureIgnoreCase);
            path = path.Substring(0, idx);
            var projPath = Path.Combine(path, projectName);        
            return projPath;
        }

        /// <summary>
        /// Get the project file name given the project name
        /// </summary>
        /// <param name="projectName"></param>
        /// <returns>Return the path to the project.csproj file</returns>
        public static string GetProjectFileName(string projectName)
        {
            var projPath = GetProjectDirectory(projectName);
            var projFile = Path.Combine(projPath , projectName + @".csproj");
            return projFile;
        }

        /// <summary>
        /// Pluralize the name of an element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string PluralizeElement(string element)
        {
            var service = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en-us"));
            return service.Pluralize(element);
        }

        public static string GetTemplatesDirectory()
        {
            return GetProjectDirectory(@"AbpOven\\Templates");
        }

        public static void AddFileToProject(List<string> fileList, string projectName)
        {            
            var p = new Microsoft.Build.Evaluation.Project(projectName);
            foreach (var fileN in fileList)
            {
                p.AddItem("Compile", fileN);
                p.Save();
            }
            
        }

        public static string GetCoreProjectPath(string arg)
        {
            var result = arg.Split('.');
            if (result.Length < 2)
            {
                throw new Exception("Project Name and element cannot contain . symbol");
            }
            var projectName = result[0] + @".Core";
            return GetProjectFileName(projectName);
        }
    }
}
