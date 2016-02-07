using System.Collections.Generic;

namespace Kana.Model.Interfaces.Service
{
    public interface ITemplateParserService
    {
        string Parse(string templateName, Dictionary<string, object> propertyBag);
    }
}
