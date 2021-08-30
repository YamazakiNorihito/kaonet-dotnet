using kao_net_app.Model.Auth.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Firebase.Auth;


namespace kao_net_app.Controllers.Auth
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : AbsAuthController
    {

        [HttpPost]
        public JsonResult Regist([FromBody] RegistModel requestdata)
        {
            var task = _FirebaseAuthProvider.CreateUserWithEmailAndPasswordAsync(
                                                    requestdata.Email,
                                                    requestdata.Password,
                                                    requestdata.Email, 
                                                    true);

            task.Wait();

            FirebaseAuthLink createUserResult = task.Result;


            object response = new
            {
                createUserResult
            };

            return new JsonResult(response);
        }

    }
}
