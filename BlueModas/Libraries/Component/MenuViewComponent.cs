using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlueModas.Libraries.Component
{
    public class MenuViewComponent : ViewComponent
    {
        public MenuViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
