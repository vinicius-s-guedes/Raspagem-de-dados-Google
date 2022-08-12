using GoogleSearch.Interfaces;
using GoogleSearch.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleSearch.Application
{
    public class WebScrapingGoogleService: IWebScrapingGoogleService
    {
        /// <summary>
        /// Usa a técnica webScraping para retornar a paginação do Google
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public List<PaginationGoogle> ParseHtmlInPagination(string html)
        {
            List<PaginationGoogle> pages = new();
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            //Obtem a tag onde está a paginação
            var programmerLinksNext = htmlDoc.DocumentNode.Descendants("tr").First(node => node.GetAttributeValue("jsname", "").Contains("TeSSVd"));
            //pegue as páginas
            var pagination = programmerLinksNext.Descendants("td").ToList();

            foreach (var page in pagination)
            {
                string numberPage = page.InnerText;
                //se você não for possível oobter o link dessa página significa que você está localizado nela
                var link = "#";
                if (!string.IsNullOrEmpty(numberPage))
                {
                    if (page.FirstChild.Attributes.Count > 2)
                        link = page.FirstChild.Attributes[2].Value;

                    pages.Add(new() { page = numberPage, link = link });
                }
            }
            return pages;
        }

        /// <summary>
        /// Usa a técnica webScraping para retornar as respostas do Google
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public List<ResultGoogle> ParseHtmlInItemsResults(string html)
        {
            List<ResultGoogle> results = new();
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            //obtem a tag onde os itens da resposta do Google estão localizados
            var items = htmlDoc.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Contains("yuRUbf"))
                .ToList();

            foreach (var item in items)
            {
                var link = item.FirstChild.Attributes[0].Value;
 
                var title = item.Descendants("h3").First().FirstChild.InnerHtml;
                results.Add(new() { Link = link, Title = title });
            }
            return results;
        }
    }
}
