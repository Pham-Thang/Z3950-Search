﻿using Microsoft.AspNetCore.Http;
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
        private readonly IPrintService _printService;

        public TestController(
            IZ3950Service z3950Service,
            IMARCXmlReader mARCXmlReader,
            IPrintService printService)
        {
            _z3950Service = z3950Service;
            _mARCXmlReader = mARCXmlReader;
            _printService = printService;
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

        [HttpGet("local/print/{skip}/{limit}")]
        public async Task<IActionResult> LocalPrint(int skip, int limit)
        {
            var take = skip + limit;
            if (skip >= MARCXmlString.List.Count)
                skip = MARCXmlString.List.Count - 1;
            if (take >= MARCXmlString.List.Count)
                take = MARCXmlString.List.Count - 1;

            var marcxmls = MARCXmlString.List.Skip(skip).Take(take).ToList();

            var docs = _mARCXmlReader.ReadMARCXmlStrings<DocumentEntity>(marcxmls);

            var isSuccess = _printService.Print(data: docs, filePath: @"D:\docs.csv");

            return Ok(isSuccess);
        }

        [HttpGet("print/{queryText}")]
        public async Task<IActionResult> SearchAndPrint(string queryText)
        {
            var searchParam = new SearchParam()
            {
                Title = queryText
            };
            var marcxmls = _z3950Service.Search(searchParam);

            var docs = _mARCXmlReader.ReadMARCXmlStrings<DocumentEntity>(marcxmls);

            var isSuccess = _printService.Print(data: docs, filePath: @"D:\docs.csv");

            return Ok(docs.Count);
        }

        [HttpGet("print/large/{queryText}")]
        public async Task<IActionResult> SearchAndPrintLargeData(string queryText)
        {
            var searchParam = new SearchParam()
            {
                Title = queryText
            };
            var num = _z3950Service.SearchAndPrint(searchParam);

            return Ok(num);
        }
    }
}
