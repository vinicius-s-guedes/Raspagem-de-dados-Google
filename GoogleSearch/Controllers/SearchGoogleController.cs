using GoogleSearch.Interfaces;
using GoogleSearch.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleSearch.Controllers
{
    [ApiController]
    [Route("api/Search/Google")]
    public class SearchGoogleController : ControllerBase
    {

        private readonly ISearchGoogleApplication _searchGoogleApplication;

        private readonly ILogger<SearchGoogleController> _logger;

        public SearchGoogleController(ILogger<SearchGoogleController> logger, ISearchGoogleApplication searchGoogleApplication)
        {
            _logger = logger;
            _searchGoogleApplication = searchGoogleApplication;
        }

        /// <summary>
        /// Pesquise o texto no google e retorna a resposta e paginação
        /// </summary>
        /// <param name="searchValue"></param>
        /// <param name="nextPage"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<SearchGoogleDTO>> GetResultItemsInGoogle(string searchValue, [FromQuery] string nextPage)
        {
            try
            {
                return Ok(await _searchGoogleApplication.GetResultItemsInGoogle(searchValue, nextPage));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(new { status = 400, message = ex.Message});
            }
        }
    }
}
