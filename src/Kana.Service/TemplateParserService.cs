using Castle.MonoRail.Framework;
using Castle.MonoRail.Views.Brail;
using Kana.Model.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kana.Service
{
    public class TemplateParserService : ITemplateParserService
    {
        private readonly FileAssemblyViewSourceLoader viewSourceLoader;
        private readonly StandaloneBooViewEngine standaloneBooViewEngine;

        public TemplateParserService(string templateDirectory)
        {
            viewSourceLoader = new FileAssemblyViewSourceLoader(templateDirectory);
            standaloneBooViewEngine = new StandaloneBooViewEngine(viewSourceLoader, null);
        }

        public string Parse(string templateName, Dictionary<string, object> propertyBag)
        {
            try
            {
                using (var writer = new StringWriter())
                {
                    standaloneBooViewEngine.Process(templateName, writer, propertyBag);
                    return writer.GetStringBuilder().ToString();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
