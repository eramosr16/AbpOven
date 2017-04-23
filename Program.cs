using System;
using System.Collections.Generic;

namespace AbpOven
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 1)
            {
                PrintHelp();
            }
            else
            {
                switch (args[0].ToLower())
                {
                    case "-c":
                        CreateCommand(args);
                        break;

                    default:
                        PrintHelp();
                        break;
                }
            }

           
        }

        static void PrintHelp()
        {
            Console.WriteLine("USAGE: <command> <element> <ProjectName.[folderName.]itemName>");
            Console.WriteLine("<command>: " +
                              "c : Create \r\n" +
                              "<element>:\r\n" +
                              "  e: Entity \r\n" +
                              "  s: Service \r\n" +
                              "  v: View \r\n" +
                              "  t: Test \r\n" +
                              "  full: Create an entity, service, test, view" +
                              "note: Every element will be created in the respective project folder");
        }

        static void CreateCommand(string[] args)
        {

            switch (args[1].ToLower())
            {
                //syntax: abpOven -c e BaseWebsite.Domain
                case "e":
                    var projectPath = Helper.GetCoreProjectPath(args[2]); 
                    CommandFunction cmFunction =new CommandFunction(args[2]);
                    var file = cmFunction.CreateEntity();
                    var fileList = new List<string>() {file};
                    Helper.AddFileToProject(fileList,projectPath);
                    break;
                case "s":
                    throw new NotImplementedException("Coming soon!!");
                    break;
                case "v":
                    throw new NotImplementedException("Coming soon!!");
                    break;
                case "t":
                    throw new NotImplementedException("Coming soon!!");
                    break;
                case "full":
                    throw new NotImplementedException("Coming soon!!");
                    break;
                default: PrintHelp();
                    break;
            }
        }

    }
}
