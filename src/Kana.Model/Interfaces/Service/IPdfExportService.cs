using System.Collections.Generic;

namespace Kana.Model.Interfaces.Service
{
    public interface IPdfExportService
    {
        byte[] ConvertHtmlToPdf(string template, Dictionary<string, object> propertyBag);
    }
}
