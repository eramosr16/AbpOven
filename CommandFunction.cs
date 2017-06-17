using System;
using System.IO;
using System.Linq;

namespace AbpOven
{
    public class CommandFunction
    {
        private readonly string _projectName;
        private readonly string _element;
        private readonly string _folder;
        private readonly string _baseNameSpace;

        public CommandFunction(string cmdElementParam)
        {
            var result = cmdElementParam.Split('.');
            if (result.Length < 2)
            {
                throw new Exception("Wrong Parameter: <SolutionName.[folderName.]itemName>");
            }
            _projectName = result[0] + @".Core";
            _baseNameSpace = result[0];
            _folder = result.Count() > 2 ? result[1] : string.Empty;
            _element = result.Last();
        }

        /// <summary>
        /// Template is on: Template\EntityTemplate.cs
        /// </summary>
        /// <returns>The file path to add in the project</returns>
        public string CreateEntity()
        {
            var elementDir = Helper.PluralizeElement(_element);
            var entityName = _element;

            var projectDir = Helper.GetProjectDirectory(_projectName);

            var newEntityPath = Path.Combine(projectDir, elementDir);
            var newEntityFile = Path.Combine(newEntityPath, entityName + @".cs");
            var templateFile = Path.Combine(Helper.GetTemplatesDirectory(), @"EntityTemplate.cs");

            if (!File.Exists(templateFile))
                    throw new FileNotFoundException(@"The following template file does not exist: " + templateFile);

            if (!Directory.Exists(newEntityPath))
            {
                //Create dir               
                Directory.CreateDirectory(newEntityPath);
            }

            //1- Copy to the folder                    
            if (File.Exists(templateFile) && !File.Exists(newEntityFile))
                File.Copy(templateFile, newEntityFile);


            //2- Process the new entity copied to project folder
            //Making replacements EntityName
            string text = File.ReadAllText(newEntityFile);
            text = text.Replace(@"EntityTemplate", _element);

            //Setting NameSpace
            text = text.Replace(@"AbpOven.Templates", $"{_baseNameSpace}.{elementDir}");
            File.WriteAllText(newEntityFile, text);

            //3- Add the new entity to the project file .scsproj
            return $"{elementDir}\\{_element}.cs";

        }
    }
    
}
