using Microsoft.AspNetCore.Mvc;
using Z3950.Api.Models;
using Z3950.Api.Services;

namespace Z3950.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly IZ3950Service _z3950Service;
        private readonly IMARCXmlReader _mARCXmlReader;

        public SearchController(
            ILogger<SearchController> logger, 
            IZ3950Service z3950Service, 
            IMARCXmlReader mARCXmlReader)
        {
            _logger = logger;
            _z3950Service = z3950Service;
            _mARCXmlReader = mARCXmlReader;
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
            var resultSet = _z3950Service.Search(searchParam);
            var result = _mARCXmlReader.ReadMARCXmlStrings<DocumentEntity>(resultSet);
            return Ok(result);
        }

        [HttpGet("title/{queryText}")]
        public IActionResult GetByTitle(string queryText)
        {
            var searchParam = new SearchParam()
            {
                Title = queryText
            };
            var marcxmls = _z3950Service.Search(searchParam);
            var result = _mARCXmlReader.ReadMARCXmlStrings<DocumentEntity>(marcxmls);
            return Ok(result);
        }

        [HttpGet("title/{queryText}/{skip}/{limit}")]
        public IActionResult Paging(string queryText, int skip, int limit)
        {
            var searchParam = new SearchParam()
            {
                Title = queryText
            };
            var (marcxmls, total) = _z3950Service.Paging(searchParam, skip, limit);
            var result = _mARCXmlReader.ReadMARCXmlStrings<DocumentEntity>(marcxmls);
            return Ok(new
            {
                total,
                marcxmls,
                docs = result,
            });
        }

        [HttpGet("title/{queryText}/marcxmlstring")]
        public IActionResult GetMARCXmlStringByTitle(string queryText)
        {
            var searchParam = new SearchParam()
            {
                Title = queryText
            };
            var marcxmls = _z3950Service.Search(searchParam);
            return Ok(marcxmls);
        }

        [HttpPost("")]
        public IActionResult GetBySearchParam([FromBody] SearchParam searchParam)
        {
            var marcxmls = _z3950Service.Search(searchParam);
            var result = _mARCXmlReader.ReadMARCXmlStrings<DocumentEntity>(marcxmls);
            return Ok(result);
        }
    }
}