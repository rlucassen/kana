using Kana.Model.Factories;
using Kana.Model.Helpers;
using Kana.Model.Interfaces.Service;

namespace Kana.Web.Controllers
{
    public class KatakanaController : KanaController<KatakanaFactory>
    {
        public KatakanaController(IPdfExportService pdfExportService) : base(pdfExportService, "katakana")
        {
        }
    }
}