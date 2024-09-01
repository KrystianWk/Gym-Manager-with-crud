using Microsoft.AspNetCore.Mvc;
using GymManagerApplication.Services;
using GymManagerApplication;
using GymManagerApplication.GymManager;
using MediatR;
using AutoMapper;
using GymManagerApplication.GymManager.Queries.GetAllGymMenagers;
using GymManagerApplication.GymManager.Commands.CreateGymManager; 

using GymManagerApplication.GymManager.Commands.EditGymManager;
using GymManagerApplication.GymManager.Queries.GetGymManagerById;
using GymManagerApplication.GymManager.Commands.DeleteGymManager;
using Microsoft.AspNetCore.Authorization;

namespace GymManager.MVC.Controllers
{
    public class GymManagerController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GymManagerController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task <IActionResult> Index()
        {
            var gymManagers = await _mediator.Send(new GetAllGymManagerQuery());
            return View(gymManagers);
        }
        [Authorize(Roles = "Owner")]
        public IActionResult Create()
        {
            // Check if the user is authenticated = > if not, redirect to the login page == [authorize]
            /*    if(!User.Identity.IsAuthenticated || User.Identity == null )
                {
                    return RedirectToPage("/Account/Login", new { area = "Identity" });
                }   
            */
        
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteGymManagerCommand(id);
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        [Route("GymManager/{id}/Details")]
        public async Task<IActionResult> Details(int id)
        {
            var dto = await _mediator.Send(new GetGymManagerByIdQuery(id));
            if (dto == null)
            {
                // Handle the case when the gym manager is not found
                return NotFound($"GymManager with Id {id} not found.");
            }
            return View(dto);
        }

        [Route("GymManager/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _mediator.Send(new GetGymManagerByIdQuery(id)); // Use the new query

            if (!dto.isEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            EditGymManagerCommand model = _mapper.Map<EditGymManagerCommand>(dto);
            return View(model);
        }
        [HttpPost]
        [Route("GymManager/{id}/Edit")]
        public async Task<IActionResult> Edit(int id, EditGymManagerCommand commands)
        {
            if (!ModelState.IsValid)
            {
                return View(commands);

            }
            await _mediator.Send(commands);
            return RedirectToAction("Index");

        }
        
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateGymManagerCommands commands)
        {
            if (!ModelState.IsValid)
            {
                return View(commands); 

            }
           await _mediator.Send(commands);
            return RedirectToAction("Index");
            
        }

    }
}