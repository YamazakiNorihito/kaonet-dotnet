﻿using Firebase.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kao_net_app.Controllers.Auth
{
    [Route("auth")]
    [ApiController]
    abstract public class AbsAuthController : AbsBaseController
    {
        /// <summary>
        /// ウェブ API キー
        /// </summary>
        private static string _FireBaseApiKey = "AIzaSyDQS8iX_BYVg1cZNBFaRZajwlWC1384DCs";

        /// <summary>
        /// FireBaseConfig
        /// </summary>
        private FirebaseConfig _FireBaseAuthConfig;

        /// <summary>
        /// FirebaseAuthProvider
        /// </summary>
        protected FirebaseAuthProvider _FirebaseAuthProvider;

        public AbsAuthController()
        {
            this._FireBaseAuthConfig = new FirebaseConfig(_FireBaseApiKey);
            this._FirebaseAuthProvider = new FirebaseAuthProvider(this._FireBaseAuthConfig);
        }


    }
}
