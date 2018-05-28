using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace FunBet.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : FunBetControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}