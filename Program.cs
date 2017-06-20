using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine("USAGE: <command> <type> <SolutionName.[<folder>].ElementName>");
            Console.WriteLine("<command>: " +
                              "-c : Create \r\n" +
                              "<type>:\r\n" +
                              "  e: Core Entity \r\n" +
                              "  s: Application Service \r\n" +                              
                              "  t: Test \r\n" +
                              "  full: Create an entity, service, test, view" +
                              "note: Every element will be created in the respective project folder. " +
                              "This tool only works for AspNetCore + AngularJS ");
        }

        static void CreateCommand(string[] args)
        {
            var prms = args[2].Split('.').ToList();
            string solutionName = prms[0];
            string element = string.Join(".", prms.Skip(1));
            CommandFunction cmFunction = new CommandFunction(args[2]);

            switch (args[1].ToLower())
            {
                //syntax: abpOven -c e BaseWebsite.Domain
                case "e":
                    //Entity -> Core Project
                    var projectFileName = Helper.GetProjectFileName($"{solutionName}.Core");                     
                    var file = cmFunction.CreateEntity();
                    var fileList = new List<string>() {file};
                    Helper.AddFileToProject(fileList,projectFileName);
                    break;
                case "s":
                    throw new NotImplementedException("Coming soon!!");
                    //break;
                case "v":
                    throw new NotImplementedException("Coming soon!!");
                    //break;
                case "t":
                    throw new NotImplementedException("Coming soon!!");
                    //break;
                case "full":
                    throw new NotImplementedException("Coming soon!!");
                    //break;
                default: PrintHelp();
                    break;
            }
        }

    }
}
