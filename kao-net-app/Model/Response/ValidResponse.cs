using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

using System.Linq;
using System.Web;

namespace kao_net_app.Model.Response
{
    public class ValidResponse : AbsBaseResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; }

        public ValidResponse(string message) : base(ResponseStatus.VALID)
        {
            this.Message = message;
        }

        public ValidResponse(Exception ex) : base(ResponseStatus.VALID)
        {
            var error = new Dictionary<string, string>
            {
                {"Type", ex.GetType().ToString()},
                {"Message", ex.Message},
                {"StackTrace", ex.StackTrace}
            };
            foreach (DictionaryEntry data in ex.Data)
            {
                error.Add(data.Key.ToString(), data.Value.ToString());
            }

            var options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            this.Message = System.Text.Json.JsonSerializer.Serialize(error, options);
        }
    }
}
