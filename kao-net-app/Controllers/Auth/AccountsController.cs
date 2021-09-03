using Firebase.Auth;
using kao_net_app.Model.Auth.Account;
using kao_net_app.Model.Response;
using Microsoft.AspNetCore.Mvc;
using System;

namespace kao_net_app.Controllers.Auth
{
    [Route("accounts")]
    [ApiController]
    public class AccountsController : AbsAuthController
    {

        [HttpPost]
        public AbsBaseResponse Regist([FromBody] RegistModel requestdata)
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
                response = new ValidResponse("登録に失敗しました。");
            }

            return response;
        }

    }
}
