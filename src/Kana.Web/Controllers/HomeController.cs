using Kana.Model.Interfaces.Service;

namespace Kana.Web.Controllers
{
    public class HomeController : BaseController
    {
        protected ICounterService counterService;

        public HomeController(ICounterService counterService)
        {
            this.counterService = counterService;
        }

        public void Index()
        {
            PropertyBag.Add("hiraganaCounter", counterService.GetCounter("hiragana"));
            PropertyBag.Add("katakanaCounter", counterService.GetCounter("katakana"));
        }
    }
}