using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Z3950.Api.Models;
using Z3950.Api.Services;

namespace Z3950.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScanController : ControllerBase
    {
        private readonly ILogger<ScanController> _logger;
        private readonly IZ3950Service _z3950Service;
        private readonly IMARCXmlReader _mARCXmlReader;

        public ScanController(
            ILogger<ScanController> logger, 
            IZ3950Service z3950Service, 
            IMARCXmlReader mARCXmlReader)
        {
            _logger = logger;
            _z3950Service = z3950Service;
            _mARCXmlReader = mARCXmlReader;
        }

        [HttpGet("paging/{queryText}/{skip}/{limit}")]
        public IActionResult Paging(string queryText, int skip, int limit)
        {
            try
            {
                var searchParam = new SearchParam()
                {
                    Title = queryText
                };
                var (marcxmls, total) = _z3950Service.Paging(searchParam, skip, limit);
                var result = _mARCXmlReader.ReadMARCXmlStrings<BookEntity>(marcxmls);
                return Ok(new
                {
                    total,
                    marcxmls,
                    docs = result,
                });
            } catch (Exception ex)
            {
                return Ok(new {
                    Message = ex.Message,
                    Data = JsonConvert.SerializeObject(ex),
                });
            }
        }
    }
}