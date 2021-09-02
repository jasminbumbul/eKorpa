using eKorpa.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using eKorpa.SignalR;


namespace eKorpa.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize(Roles = "Admin,KorisnickaSluzba")]
    public class AdministracijaController : Controller
    {
        ApplicationDbContext _database = new ApplicationDbContext();
        IHubContext<MyHub> _hubContext;

        private readonly IWebHostEnvironment _hostEnvironment;

        public AdministracijaController(IWebHostEnvironment hostEnvironment, IHubContext<MyHub> hubContext)
        {
            this._hostEnvironment = hostEnvironment;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }



    }
}
