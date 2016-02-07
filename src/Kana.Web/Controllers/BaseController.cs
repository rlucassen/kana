namespace Kana.Web.Controllers
{
    using Castle.MonoRail.Framework;
    using Castle.MonoRail.Framework.Filters;

    [Layout("default")]
    [Filter(ExecuteWhen.BeforeAction, typeof(RequestValidatorFilter), ExecutionOrder = int.MinValue)]
    public abstract class BaseController : SmartDispatcherController
    {
        protected void Error(string message, bool redirectToReferrer = false)
        {
            CreateMessage("error", message, redirectToReferrer);
        }

        protected void Information(string message, bool redirectToReferrer = false)
        {
            CreateMessage("info", message, redirectToReferrer);
        }

        protected void Success(string message, bool redirectToReferrer = false)
        {
            CreateMessage("success", message, redirectToReferrer);
        }

        private void CreateMessage(string type, string message, bool redirectToReferrer)
        {
            Flash[type] = message;
            if(redirectToReferrer) 
                RedirectToReferrer();
        }

    }
}