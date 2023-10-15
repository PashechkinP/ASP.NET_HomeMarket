using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MainHomeApplication.Pages
{
    //[Authorize]
    public class CreateHomeModel : PageModel
    {
        IHomeDataProvider _homeDataProvider;

        [BindProperty]
        public Home NewHome { get; set; } = new();

        [BindProperty]
        public IFormFile? file { get; set; }
        public CreateHomeModel(IHomeDataProvider provider)
        {
            this._homeDataProvider = provider;
        }
        public void OnGet()
        {
        }
        async public Task<IActionResult> OnPost([FromServices] IGetHomeImagePath imagePath) {
            Home createdHome = this._homeDataProvider.createHome(NewHome);
            FileStream stream = new FileStream("wwwroot/"+imagePath.GetImagePath(NewHome), FileMode.Create);
            await file.CopyToAsync(stream);
            return RedirectToPage("Index");
        }
    }
}
