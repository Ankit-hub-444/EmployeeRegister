using EmployeeRegister.Core.Repositories;
using EmployeeRegister.Core.ViewModels;
using EmployeeRegister.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace EmployeeRegister.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {

        /*private readonly UserManager<IdentityUser> _userManager;

        public AdministrationController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }*/

        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AdministrationController(IUnitOfWork unitOfWork, SignInManager<IdentityUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _unitOfWork.User.GetUsers();
           return View(users);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = _unitOfWork.User.GetUser(id);
            var roles= _unitOfWork.Role.GetRoles();

            var userRoles=await _signInManager.UserManager.GetRolesAsync(user);

            var roleItems = roles.Select(role =>
            new SelectListItem(
                role.Name,
                role.Id,
                userRoles.Any(ur=>ur.Contains(role.Name))
                )
            ).ToList();

            var vm = new EditUserViewModel
            {
                User = user,
                Roles=roleItems
            };
            return View(vm);  
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(EditUserViewModel data)
        {
            var user = _unitOfWork.User.GetUser(data.User.Id);
            if(user == null) {
                return NotFound();

            }

            var userRolesInDb = await _signInManager.UserManager.GetRolesAsync(user);

            //Loop through roles in ViewModel
            //Check if the role is Assigned In DB
            //If Assigned=>Do Nothing
            //If Not Assigned->Add Role
            var rolesToAdd = new List<string>();
            var rolesToRemove = new List<string>();

            foreach(var role in data.Roles)
            {
                var assignedInDb = userRolesInDb.FirstOrDefault(ur => ur == role.Text);
                if (role.Selected)
                {
                    if(assignedInDb == null)
                    {
                        //Add Role
                        rolesToAdd.Add(role.Text);
                    }
                }
                else
                {
                    if(assignedInDb != null)
                    {
                        //Remove Role
                        rolesToRemove.Add(role.Text);

                    }
                }
            }

            if(rolesToAdd.Any())
            {
                await _signInManager.UserManager.AddToRolesAsync(user, rolesToAdd);
            }

            if(rolesToRemove.Any())
            {
                await _signInManager.UserManager.RemoveFromRolesAsync(user, rolesToRemove);
            }

            user.FirstName = data.User.FirstName;
            user.LastName = data.User.LastName;
            user.Email = data.User.Email;

            _unitOfWork.User.UpdateUser(user);
            return RedirectToAction(nameof(Index)); ;
        }
    }
}