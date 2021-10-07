using Firebase.Auth;
using kao_net_app.Model.Response;
using kao_net_app.Model.Response.Auth;
using Microsoft.AspNetCore.Mvc;
using System;


namespace kao_net_app.Controllers.Auth
{
    [Route("auth/pwdreset")]
    [ApiController]
    public class PwdResetController : AbsAuthController
    {
        [HttpGet]
        public AbsBaseResponse Get(string email)
        {
            AbsBaseResponse response = null;

            try
            {
                var resetTask = _FirebaseAuthProvider.SendPasswordResetEmailAsync(email);

                resetTask.Wait();
                response = new SuccessResponse<string>(string.Empty);
            }
            catch (Exception ex)
            {
                // todo  log 出力
                this.HttpContext.Response.StatusCode = 400;
                response = new ValidResponse(ex);
            }

            return response;
        }

        [HttpPut]
        public AbsBaseResponse Put([FromBody] string idToken, string password)
        {
            AbsBaseResponse response = null;

            try
            {
                var resetTask = _FirebaseAuthProvider.ChangeUserPassword(idToken, password);

                resetTask.Wait();

                FirebaseAuthLink signInResult = resetTask.Result;

                if (string.IsNullOrEmpty(signInResult.FirebaseToken))
                {// error

                    throw new Exception("ChangePasswordに失敗しました。");
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
