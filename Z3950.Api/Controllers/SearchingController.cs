using Microsoft.AspNetCore.Mvc;
using Z3950.Api.Models;
using Z3950.Api.Services;

namespace Z3950.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchingController : ControllerBase
    {
        private readonly ILogger<SearchingController> _logger;
        private readonly IZ3950Service _z3950Service;

        public SearchingController(ILogger<SearchingController> logger, IZ3950Service z3950Service)
        {
            _logger = logger;
            _z3950Service = z3950Service;
        }

        //[HttpGet("isbn/${isbn}")]
        //public IActionResult GetByISBN(string isbn)
        //{
        //    return Ok();
        //}

        [HttpGet("{queryText}")]
        public IActionResult GetByQueryText(string queryText)
        {
            var searchParam = new SearchParam();
            var props = typeof(SearchParam).GetProperties();
            foreach (var prop in props)
            {
                prop.SetValue(searchParam, queryText);
            }
            var result = _z3950Service.Search(searchParam);
            return Ok(result);
        }

        [HttpPost("")]
        public IActionResult GetBySearchParam([FromBody] SearchParam searchParam)
        {
            var result = _z3950Service.Search(searchParam);
            return Ok(result);
        }
    }
}