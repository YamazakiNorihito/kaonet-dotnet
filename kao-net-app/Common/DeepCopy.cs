using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace kao_net_app.Common
{
    public class DeepCopy
    {
        public static void Copy<T>(object from, T to)
        {
            var from_str = JsonSerializer.Serialize(from);

            to = JsonSerializer.Deserialize<T>(from_str);
        }

    }
}
