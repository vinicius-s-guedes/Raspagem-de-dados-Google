using GoogleSearch.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleSearch.SystemConnector
{
    public class GetHTMLService: IGetHTMLService
    {
        /// <summary>
        /// retornar o html da url fornacida
        /// para a utilização da tecnica web Scraping
        /// </summary>
        /// <param name="fullUrl"></param>
        /// <param name="dispositivo"></param>
        /// <returns></returns>
        public async Task<string> GetHtmlByUrl(string fullUrl,string? dispositivo = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 OPR/89.0.4447.64")
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("user-agent", dispositivo);
            var response = await client.GetStringAsync(fullUrl);
            return response;
        }
    }
}
