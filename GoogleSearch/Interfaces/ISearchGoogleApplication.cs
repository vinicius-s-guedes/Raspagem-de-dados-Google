using GoogleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleSearch.Interfaces
{
    public interface ISearchGoogleApplication
    {
        // Monta o conteúdo de retorno obtido pelo webScraping no google
        Task<SearchGoogleDTO> GetResultItemsInGoogle(string searchValue, string nextPage);

    }
}
