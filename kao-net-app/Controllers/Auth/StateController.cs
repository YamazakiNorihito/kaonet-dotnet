using Firebase.Auth;
using kao_net_app.Model.Auth.State;
using kao_net_app.Model.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace kao_net_app.Controllers.Auth
{
    [Route("state")]
    [ApiController]
    public class StateController : AbsAuthController
    {
        [HttpPost]
        [Route("[action]")]
        public AbsBaseResponse SignIn([FromBody] SignInModel requestdata)
        {
            AbsBaseResponse response = null;

            try
            {
                var signInTask = _FirebaseAuthProvider.SignInWithEmailAndPasswordAsync(
                                                        requestdata.Email,
                                                        requestdata.Password);

                signInTask.Wait();

                FirebaseAuthLink signInResult = signInTask.Result;

                if (string.IsNullOrEmpty(signInResult.FirebaseToken))
                {// error
                    response = new ValidResponse("SignInに失敗しました。");
                }
                else
                {// success
                    response = new SuccessResponse<object>(new { token = signInResult.FirebaseToken });
                }
            }
            catch (Exception ex)
            {
                // todo
                // log 出力
                response = new ValidResponse("SignInに失敗しました。");
            }

            return response;
        }


        [HttpGet]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public AbsBaseResponse LogOut()
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
