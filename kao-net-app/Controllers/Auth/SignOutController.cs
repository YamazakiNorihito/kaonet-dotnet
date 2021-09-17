using kao_net_app.Model.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace kao_net_app.Controllers.Auth
{
    [Route("auth/signout")]
    [ApiController]
    public class SignOutController : AbsAuthController
    {
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public AbsBaseResponse Get()
        {
            AbsBaseResponse response = null;

            try
            {
                response = new SuccessResponse<string>("OK");
            }
            catch (Exception ex)
            {
                // todo
                // log 出力
                response = new ValidResponse("LogOutに失敗しました。");
            }

            return response;
        }
    }
}
