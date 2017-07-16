using AbpOven.Model;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using RazorEngine.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOven
{
    public class TemplateFactory
    {
        private readonly IRazorEngineService _engine;
        public TemplateFactory()
        {
            var config = new TemplateServiceConfiguration()
            {
                Language = RazorEngine.Language.CSharp,
                EncodedStringFactory = new RawStringFactory(), // Raw string encoding.
                Debug = true,                
            };
            _engine = RazorEngineService.Create(config);

        }
        public void RenderEntity(EntityViewModel entity,string destFile)
        {
            var templateFile = File.ReadAllText(Path.Combine(Helper.GetTemplatesDirectory(), @"Entity.cshtml"));
            var templateContent = new LoadedTemplateSource(templateFile);
            var output = _engine.RunCompile(templateContent, @"Entity", typeof(EntityViewModel), entity, null);
            File.WriteAllText(destFile, output);
        }
    }
}
