using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MainHomeApplication.Pages
{
    public class RegistrationModel : PageModel
    {
        IHomeDataProvider _homeDataProvider;

        [BindProperty]
        public ServiceUser userochek1 { get; set; } = new();

        public RegistrationModel(IHomeDataProvider provider)
        {
            this._homeDataProvider = provider;
        }

        async public Task<IActionResult> OnPost()
        {  
            ServiceUser userochek = this._homeDataProvider.createUser(userochek1);
            return RedirectToPage("Index");
        }

        public void OnGet()
        {
        }
    }
}
