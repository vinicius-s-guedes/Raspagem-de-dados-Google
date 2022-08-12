using GoogleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleSearch.Interfaces
{
    public interface IWebScrapingGoogleService
    {
        // Usa a técnica webScraping para retornar a paginação do Google
        List<PaginationGoogle> ParseHtmlInPagination(string html);

        // Usa a técnica webScraping para retornar as respostas do Google
        List<ResultGoogle> ParseHtmlInItemsResults(string html);
    }
}
