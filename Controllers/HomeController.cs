using BudgetApproved.Services;
using Microsoft.AspNetCore.Mvc;
// Asigură-te că ai acces la modelul UserModel din proiectul API (cel mai bine, printr-un proiect Shared)
using BudgetApproved.Models; 

namespace BudgetApproved.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientService _apiClient;

        // DI funcționează: IHttpClientService este injectat automat
        public HomeController(IHttpClientService apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _apiClient.GetAsync<UserModel>("api/Users");

            // Trimite utilizatorii către View
            return View(users);
        }
    }
}

