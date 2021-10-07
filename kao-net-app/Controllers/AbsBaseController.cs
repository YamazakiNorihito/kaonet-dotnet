using Microsoft.AspNetCore.Mvc;

namespace kao_net_app.Controllers
{
    abstract public class AbsBaseController : ControllerBase
    {
        // TODO startup.cs 移動
        protected static string GOOGLE_PROJECT_ID = "kao-net";
    }
}
