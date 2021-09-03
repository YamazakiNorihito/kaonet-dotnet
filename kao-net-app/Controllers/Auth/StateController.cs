using kao_net_app.Model.Auth.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Firebase.Auth;
using kao_net_app.Model.Auth.State;
using kao_net_app.Model.Response;

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
                    response = new SuccessResponse<FirebaseAuthLink>(signInResult);
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

    }
}
