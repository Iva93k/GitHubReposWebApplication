using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace GitHubReposWebApplication.Controllers
{
    //[Route("[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReposController : ControllerBase
    {
        private ILoggerManager _logger;
        public ReposController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetRepository()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://api.github.com");
                    client.DefaultRequestHeaders.Add("User-Agent", "C# App");
                    var response = await client.GetAsync($"/repos/Iva93k/employee-timesheet");

                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    
                    var rawRepo = JsonConvert.DeserializeObject<ReposResponse>(stringResult);

                    _logger.LogInfo($"Returned all informations.");

                    return Ok(new
                    {
                        RepositoryName          = rawRepo.Name,
                        RepositoryFullName      = rawRepo.Full_name,
                        RepositoryPrivate       = rawRepo.Private,
                        RepositoryHtmlUrl       = rawRepo.Html_url,
                        RepositoryDescription   = rawRepo.Description,
                        RepositoryLanguage      = rawRepo.Language

                    });
                }
                catch (HttpRequestException httpRequestException)
                {
                    _logger.LogError($"Something went wrong: {httpRequestException.Message}");
                    return BadRequest($"Error getting repository from GitHub: {httpRequestException.Message}");
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRepository(ReposResponse reposRespose)
        { 
            string json = JsonConvert.SerializeObject(reposRespose);

            //write string to file
            System.IO.File.WriteAllText(@"json.txt", json);

            return Ok();
        }
    }
}
