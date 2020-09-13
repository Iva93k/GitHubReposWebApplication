using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Contracts;
using GitHubReposWebApplication.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GitHubReposWebApplication.Controllers
{
    [Route("api/repos")]
    [ApiController]
    public class ReposController : ControllerBase
    {
    }
}
