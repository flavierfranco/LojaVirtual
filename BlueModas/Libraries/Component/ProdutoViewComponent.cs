using BlueModas.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlueModas.Libraries.Component
{
    public class ProdutoViewComponent:ViewComponent
    {
        private IProdutoRepository _produtoRepository;
        public ProdutoViewComponent(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int? pagina = 1;
            if (HttpContext.Request.Query.ContainsKey("pagina"))
                pagina = int.Parse(HttpContext.Request.Query["pagina"]);

            if (ViewContext.RouteData.Values.ContainsKey("slug"))
            {
                return View(_produtoRepository.GeneratePagination(pagina));
            }

            return View(_produtoRepository.GeneratePagination(pagina));
        }
    }
}
