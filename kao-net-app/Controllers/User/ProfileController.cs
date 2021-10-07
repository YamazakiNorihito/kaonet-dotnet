﻿using Google.Cloud.Firestore;
using kao_net_app.Model.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace kao_net_app.Controllers.User
{
    [Route("user")]
    [ApiController]
    public class ProfileController : AbsUserController
    {
        [HttpGet]
        [Route("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public AbsBaseResponse Get(string localId)
        {
            AbsBaseResponse response = null;

            return new SuccessResponse<string[]>(new[] { "OK" , localId });

            try
            {
                string token = localId;
                var signInTask = _FirebaseAuthProvider.SignInWithGoogleIdTokenAsync(token);

                signInTask.Wait();


                DocumentReference docref = _FirestoreDb.Collection("Add_Document_Custom").Document(localId);
                Dictionary<string, object> data1 = new Dictionary<string, object>()
                {
                    {"firstname", "aaaaa" },
                    { "lastname","bbbbb"},
                    {"phone nuber", 000011112222},
                    {"postdata", localId}
                };

                /*
                DocumentSnapshot snap = docref.GetSnapshotAsync().Result;

                if (snap.Exists)
                {
                    var a = docref.SetAsync(data1).Result;
                }*/

                var result = docref.SetAsync(data1).Result;

                //var c = ControllerContext.MyDisplayRouteInfo(id);

                response = new SuccessResponse<WriteResult>(result);

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
