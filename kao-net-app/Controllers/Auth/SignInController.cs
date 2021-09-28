using Firebase.Auth;
using kao_net_app.Common;
using kao_net_app.Model.Request.Auth;
using kao_net_app.Model.Response;
using kao_net_app.Model.Response.Auth;
using Microsoft.AspNetCore.Mvc;
using System;

namespace kao_net_app.Controllers.Auth
{
    [Route("auth/signin")]
    [ApiController]
    public class SignInController : AbsAuthController
    {
        [HttpPost]
        public AbsBaseResponse Post([FromBody] SignInModel requestdata)
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

                    throw new Exception("SignInに失敗しました。");
                }
                else
                {// success
                    var authModel = new AuthLinkModel();

                    authModel.Token = signInResult.FirebaseToken;
                    authModel.RefreshToken = signInResult.RefreshToken;
                    authModel.ExpiresIn = signInResult.ExpiresIn;

                    response = new SuccessResponse<AuthLinkModel>(authModel);
                }
            }
            catch (Exception ex)
            {
                // todo  log 出力
                this.HttpContext.Response.StatusCode = 400;
                response = new ValidResponse(ex);
            }

            return response;
        }
    }
}
