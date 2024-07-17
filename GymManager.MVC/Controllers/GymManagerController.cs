using Microsoft.AspNetCore.Mvc;
using GymManagerApplication.Services;
using GymManagerApplication;
using GymManagerApplication.GymManager; // Assuming entities are directly under this namespace


namespace GymManager.MVC.Controllers
{
    public class GymManagerController : Controller
    {
        private readonly IGymManagerServices _gymManagerServices;

        public GymManagerController(IGymManagerServices gymManagerServices)
        {
            _gymManagerServices = gymManagerServices;
        }

        public async Task <IActionResult> Index()
        {
            var gymManagers = await _gymManagerServices.GetAll();
            return View(gymManagers);
        }

        public IActionResult Create()
        {
            return View();
        }
        [Route("GymManager/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var gymManager = await _gymManagerServices.GetByEncodedName(encodedName);
            return View(gymManager);
        }


        [HttpPost]
        public async Task<IActionResult> Create(GymManagerDto gymManager)
        {
            if (ModelState.IsValid)
            {
                await _gymManagerServices.Create(gymManager);
                TempData["SuccessMessage"] = "Gym Manager created successfully."; // Feedback to user
                return RedirectToAction("Index"); // Assuming there's an Index view to list Gym Managers
            }
           
            return View(gymManager);
        }
    }
}