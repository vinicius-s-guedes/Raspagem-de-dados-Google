using GoogleSearch.Interfaces;
using GoogleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleSearch.Application
{
    public class SearchGoogleApplication: ISearchGoogleApplication
    {
        private readonly IGetHTMLService _getHTMLService;
        private readonly IWebScrapingGoogleService _webScrapingGoogleService;

        public SearchGoogleApplication(IGetHTMLService getHTMLService, IWebScrapingGoogleService webScrapingGoogleService)
        {
            _getHTMLService = getHTMLService;
            _webScrapingGoogleService = webScrapingGoogleService;
        }

        /// <summary>
        /// Retorna a URL do Google a ser usada para realizar a técnica webScraping
        /// </summary>
        /// <param name="searchValue"></param>
        /// <param name="nextPage"></param>
        /// <returns></returns>
        private string getUrlGoogle(string searchValue, string nextPage) {
            string urlBase = "https://www.google.com";
            //codificar searchValue para ser valido na url
            searchValue = searchValue.Replace(" ", "+");
            if (string.IsNullOrEmpty(nextPage))
                nextPage = $"{urlBase}/search?client=opera-gx&q={searchValue}&sourceid=opera&ie=UTF-8&oe=UTF-8";
            else
                nextPage = urlBase + nextPage;

            return nextPage;
        }


        /// <summary>
        /// Retorna o conteúdo de retorno obtido pela técnica webScraping no google
        /// </summary>
        /// <param name="searchValue"></param>
        /// <param name="nextPage"></param>
        /// <returns></returns>
        public async Task<SearchGoogleDTO> GetResultItemsInGoogle(string searchValue, string nextPage)
        {
           string htmlresult= await _getHTMLService.GetHtmlByUrl(getUrlGoogle(searchValue, nextPage));
            List<ResultGoogle> itemsResult = _webScrapingGoogleService.ParseHtmlInItemsResults(htmlresult);
            List<PaginationGoogle> pagination = _webScrapingGoogleService.ParseHtmlInPagination(htmlresult);

            return new SearchGoogleDTO(){ items = itemsResult,paginations= pagination };

        }
    }
}
