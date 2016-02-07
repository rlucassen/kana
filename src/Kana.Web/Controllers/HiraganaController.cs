using Kana.Model.Factories;
using Kana.Model.Helpers;
using Kana.Model.Interfaces.Service;

namespace Kana.Web.Controllers
{
    public class HiraganaController : KanaController<HirganaFactory>
    {
        public HiraganaController(IPdfExportService pdfExportService, ICounterService counterService) : base(pdfExportService, counterService, "hiragana")
        {
        }
    }
}