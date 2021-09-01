using kao_net_app.Model.Auth.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Firebase.Auth;
using kao_net_app.Model.Auth.State;

namespace kao_net_app.Controllers.Auth
{
    [Route("state")]
    [ApiController]
    public class StateController : AbsAuthController
    {

        [HttpPost]
        [Route("[action]")]
        public FirebaseAuth SignIn([FromBody] SignInModel requestdata)
        {
            var signInTask = _FirebaseAuthProvider.SignInWithEmailAndPasswordAsync(
                                                    requestdata.Email,
                                                    requestdata.Password);

            signInTask.Wait();

            FirebaseAuthLink signInResult = signInTask.Result;


            FirebaseAuth response = null;

            if (string.IsNullOrEmpty(signInResult.FirebaseToken))
            {// error
            }
            else
            {// success
                response = signInResult;
            }

            return response;
        }

    }
}
