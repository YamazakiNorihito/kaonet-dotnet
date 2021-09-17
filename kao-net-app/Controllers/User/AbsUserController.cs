using Firebase.Auth;
using Google.Cloud.Firestore;
using System;
using System.IO;

namespace kao_net_app.Controllers.User
{
    abstract public class AbsUserController : AbsBaseController
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


        // TODO startup.cs 移動
        private static string GOOGLE_PROJECT_ID = "kao-net";
        private static string GOOGLE_CREDENTIALS = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                                "kao-net-firebase-secret.json");
        protected FirestoreDb _FirestoreDb;

        public AbsUserController()
        {
            this._FireBaseAuthConfig = new FirebaseConfig(_FireBaseApiKey);
            this._FirebaseAuthProvider = new FirebaseAuthProvider(this._FireBaseAuthConfig);

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", GOOGLE_CREDENTIALS);
            _FirestoreDb = FirestoreDb.Create(GOOGLE_PROJECT_ID);
        }

    }
}
