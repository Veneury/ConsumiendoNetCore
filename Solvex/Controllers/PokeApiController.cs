using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Solvex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokeApiController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> Data()
        {
            string apiResponse;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon/"))
                {
                     apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return apiResponse;
        }
    
    [HttpGet("{name}")]
    public async Task<ActionResult<string>> Data(string name)
    {
        string apiResponse;
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon/" + name))
            {
                apiResponse = await response.Content.ReadAsStringAsync();
            }
        }
        return apiResponse;
    }
}
}