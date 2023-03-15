using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Z3950.Api.DataFake;
using Z3950.Api.Models;
using Z3950.Api.Services;

namespace Z3950.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IZ3950Service _z3950Service;
        private readonly IMARCXmlReader _mARCXmlReader;

        public TestController(
            IZ3950Service z3950Service,
            IMARCXmlReader mARCXmlReader)
        {
            _z3950Service = z3950Service;
            _mARCXmlReader = mARCXmlReader;
        }


        [HttpGet("local/{skip}/{limit}")]
        public async Task<IActionResult> LocalPaging(int skip, int limit)
        {
            var take = skip + limit;
            if (skip >= MARCXmlString.List.Count)
                skip = MARCXmlString.List.Count - 1;
            if (take >= MARCXmlString.List.Count)
                take = MARCXmlString.List.Count - 1;

            var marcxmls = MARCXmlString.List.Skip(skip).Take(take).ToList();

            var docs = _mARCXmlReader.ReadMARCXmlStrings<DocumentEntity>(marcxmls);

            return Ok(docs);
        }
    }
}
