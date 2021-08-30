using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kao_net_app.Controllers.Auth
{
    [Route("[controller]")]
    [ApiController]
    abstract public class AbsAuthController : AbsBaseController
    {
    }
}
