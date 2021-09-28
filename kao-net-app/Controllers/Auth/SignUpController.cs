using Firebase.Auth;
using kao_net_app.Model.Request.Auth;
using kao_net_app.Model.Response;
using Microsoft.AspNetCore.Mvc;
using System;

namespace kao_net_app.Controllers.Auth
{
    [Route("auth/signup")]
    [ApiController]
    public class SignUpController : AbsAuthController
    {
        [HttpPost]
        public AbsBaseResponse Post([FromBody] SignupModel requestdata)
        {
            AbsBaseResponse response = null;

            try
            {
                var task = _FirebaseAuthProvider.CreateUserWithEmailAndPasswordAsync(
                                                        requestdata.Email,
                                                        requestdata.Password,
                                                        requestdata.Email,
                                                        true);

                task.Wait();

                FirebaseAuthLink createUserResult = task.Result;
                response = new SuccessResponse<FirebaseAuthLink>(createUserResult);

            }
            catch (Exception ex)
            {
                // todo
                // log 出力
                // todo  log 出力
                this.HttpContext.Response.StatusCode = 400;
                response = new ValidResponse(ex);
            }

            return response;
        }

    }
}
