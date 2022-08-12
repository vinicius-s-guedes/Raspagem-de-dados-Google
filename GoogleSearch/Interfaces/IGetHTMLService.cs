using GoogleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleSearch.Interfaces
{
    public interface IGetHTMLService
    {
        // retornar o html da url fornacida
        // para a utilização da tecnica web Scraping
        Task<string> GetHtmlByUrl(string fullUrl, string dispositivo= "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 OPR/89.0.4447.64");
    }
}
