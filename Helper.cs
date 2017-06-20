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
                var projPath = Path.Combine(path,"src",projectName);

            if (!Directory.Exists(projPath))
                throw new DirectoryNotFoundException($"Project folder: {projPath} not found, must be in solution folder to execute command");

            return projPath;            
        }

        /// <summary>
        /// Get the project file name (.csproj) given the project name
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
            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Templates");
            Console.WriteLine(templatePath);
            return templatePath;
        }

        public static void AddFileToProject(List<string> fileList, string projectName)
        {
            try
            {
                var p = new Microsoft.Build.Evaluation.Project(projectName);
                foreach (var fileN in fileList)
                {
                    p.AddItem("Compile", fileN);
                    p.Save();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fail to add file to project {projectName}: {ex.Message}");                
            }
        }


        /// <summary>
        /// Return the Path to the Project
        /// </summary>
        /// <param name="solutionName">Solution Name</param>
        /// <param name="projectName">Project Name</param>
        /// <returns></returns>
        public static string GetProjectPath(string solutionName, string projectName)
        {            
            if (string.IsNullOrEmpty(solutionName) && string.IsNullOrEmpty(projectName))
            {
                throw new Exception("Must provide: Solution Name  and  Project Name");
            }
            return GetProjectDirectory($"{solutionName}.{projectName}");
        }
        
    }
}
