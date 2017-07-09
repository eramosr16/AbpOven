using AbpOven.Model;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.IO;
using System.Linq;

namespace AbpOven
{
    public static class Command
    {        
        /// <summary>
        /// Template is on: Template\EntityTemplate.cs
        /// </summary>
        /// <returns>The file path to add in the project</returns>
        public static string CreateEntity(Project project,EntityViewModel entity)
        {
            var templateFile = Path.Combine(Helper.GetTemplatesDirectory(), @"EntityTemplate.cs");
            //var result = Engine.Razor.RunCompile(new LoadedTemplateSource("Entity", templateFile),typeof(EntityViewModel),entity);

            //TODO: Add Razor engine to generate the Entity
            throw new NotImplementedException();
            //var elementDir =  string.IsNullOrEmpty(dir) ? Helper.PluralizeElement(element) : dir;
            //var entityName = element;

            //var projectDir = _project.FullPath;

            //var newEntityPath = Path.Combine(projectDir, elementDir);
            //var newEntityFile = Path.Combine(newEntityPath, entityName + @".cs");
            //var templateFile = Path.Combine(Helper.GetTemplatesDirectory(), @"EntityTemplate.cs");

            //if (!File.Exists(templateFile))
            //        throw new FileNotFoundException(@"The following template file does not exist: " + templateFile);

            //if (!Directory.Exists(newEntityPath))
            //{
            //    //Create dir               
            //    Directory.CreateDirectory(newEntityPath);
            //}



            ////TODO: Change this to use the RAZOR engine
            ////SEE:  https://github.com/Antaris/RazorEngine
            ////1- Copy to the folder                    
            //if (File.Exists(templateFile) && !File.Exists(newEntityFile))
            //    File.Copy(templateFile, newEntityFile);


            ////2- Process the new entity copied to project folder
            ////Making replacements EntityName
            //string text = File.ReadAllText(newEntityFile);
            //text = text.Replace(@"EntityTemplate", entityName);

            ////Setting NameSpace
            ////text = text.Replace(@"AbpOven.Templates", $"{_baseNameSpace}.{elementDir}");
            //File.WriteAllText(newEntityFile, text);

            ////3- Add the new entity to the project file .scsproj
            //return $"{elementDir}\\{entityName}.cs";

        }
    }
    
}
