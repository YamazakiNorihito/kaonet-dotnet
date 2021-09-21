using Firebase.Auth;
using kao_net_app.Model.Request.Auth;
using kao_net_app.Model.Response;
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
                    response = new ValidResponse("SignInに失敗しました。");
                }
                else
                {// success
                    response = new SuccessResponse<FirebaseAuthLink>(signInResult);
                }
            }
            catch (Exception ex)
            {
                // todo
                // log 出力
                response = new ValidResponse(ex);
            }

            return response;
        }
    }
}
