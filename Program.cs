using AbpOven.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
                //Main Commands (Create, Delete)
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
            //TODO Change the Solution.Name to search the .csproj from the directory
            Console.WriteLine("USAGE: <command> <type> [<additional params>] <[<folder>].ElementName>");
            Console.WriteLine("COMMANDS:\r\n " +
                              "<-c> : Create \r\n" +
                              "TYPE:\r\n" +
                              "  <e>: Core Entity \r\n" +
                              "     - Additional Params \r\n" +
                              "       - <m> : Add Multitenancy\r\n" +
                              "       - <s> : Add Soft Delete\r\n" +
                              "       - <ms>: Add Both\r\n" +
                              "  <s>: Application Service \r\n" +                              
                              "  <t>: Test \r\n" +
                              "  <full>: Create an entity, service, test, view\r\n" +
                              "EXAMPLES: \r\n " +
                              "AbpOven -c e ms Domain  : Create Entity with Multienancy and Soft Delete" +
                              "note: Every element will be created in the respective project folder. " +
                              "This tool only works for AspNetCore + AngularJS ");
        }

        static void CreateCommand(string[] args)
        {
            var projects = Helper.GetProjectsList(Directory.GetCurrentDirectory());
            var cmdType = args.Count() == 4 ?  args[2] : string.Empty;
            var element = args[args.Count() - 1];
          
           
            //Types: (Entities, Services, etc)
            switch (args[1].ToLower())
            {
                //syntax: abpOven -c e BaseWebsite.Domain
                case "e":
                    //Entity -> Core Project             
                    var core = projects[ProjectType.Core];
                    var file = Command.CreateEntity(core,new EntityViewModel(cmdType,element));

                    //var fileList = new List<string>() {file};
                    //Helper.AddFileToProject(fileList,core.FullPath);
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
