using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookList.MIddlewares
{
    public class GlobalExceptionHandlingMiddelware : IMiddleware
    {
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public GlobalExceptionHandlingMiddelware(ILogger<GlobalExceptionHandlingMiddelware> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _hostingEnvironment = environment;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                    context.Response.Redirect("/Home/CustomError");
            }
        }
    }
}
