using kao_net_app.Model.Auth.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kao_net_app.Controllers.Auth
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : AbsBaseController
    {
        [HttpPost]
        public JsonResult Regist([FromBody] RegistModel data)
        {
            object response = new
            {
                data
            };

            return new JsonResult(response);
        }

    }
}
