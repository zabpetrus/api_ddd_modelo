using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Produtos.Api.Controllers._Base
{
    //[Route("api/[controller]")]
    //[ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAcessor;

        protected BaseApiController(IHttpContextAccessor contextAcessor)
        {
            _contextAcessor = contextAcessor;
        }

        protected string GetIpClient()
        {
            var ipClient = string.Empty;

            //first try to get IP address from the forwarded header
            if (_contextAcessor.HttpContext.Request.Headers != null)
            {
                //the X-Forwarded-For (XFF) HTTP header field is a de facto standard for identifying the originating IP address of a client
                //connecting to a web server through an HTTP proxy or load balancer

                var forwardedHeader = _contextAcessor.HttpContext.Request.Headers["X-Forwarded-For"];
                if (!string.IsNullOrWhiteSpace(forwardedHeader))
                    ipClient = forwardedHeader.FirstOrDefault();
            }

            //if this header not exists try get connection remote IP address
            if (string.IsNullOrEmpty(ipClient) && _contextAcessor.HttpContext.Connection.RemoteIpAddress != null)
                ipClient = _contextAcessor.HttpContext.Connection.RemoteIpAddress.ToString();

            return ipClient;
        }
    }
}
