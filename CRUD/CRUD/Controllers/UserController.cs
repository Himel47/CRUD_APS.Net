using CRUD.Data;
using CRUD.Models;
using CRUD.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly myDbContext myContext;

        public UserController(myDbContext myContext)
        {
            this.myContext = myContext;
        }

        [HttpGet]  //output all users
        public async Task<IActionResult> Index()
        {
            var allUser = await myContext.AllUsers.ToListAsync();
            return View(allUser);
        }

        //New user page
        //heading and output

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserViewModel addUserRequest)
        {
            var User = new Users()
            {
                Name = addUserRequest.Name,
                Email = addUserRequest.Email,
                Phone = addUserRequest.Phone,
                Address = addUserRequest.Address
            };

            await myContext.AllUsers.AddAsync(User);
            await myContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        //New user portion ends

        //Editing link
        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var userDetails = await myContext.AllUsers.FirstOrDefaultAsync(x => x.Id == id);

            if(userDetails != null)
            {
                var viewModel = new UpdateUserViewModel()
                {
                    Id = userDetails.Id,
                    Name = userDetails.Name,
                    Email = userDetails.Email,
                    Phone = userDetails.Phone,
                    Address = userDetails.Address
                };

                return await Task.Run(()=>View("View",viewModel));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateUserViewModel viewModel)
        {
            var userDetails= await myContext.AllUsers.FindAsync(viewModel.Id);

            if(userDetails!= null)
            {
                userDetails.Name = viewModel.Name;
                userDetails.Email = viewModel.Email;
                userDetails.Phone = viewModel.Phone;
                userDetails.Address = viewModel.Address;

                await myContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        //Editing link ends

        //Delete specific user

        [HttpPost] 
        public async Task<IActionResult> Delete(UpdateUserViewModel deleteModel)
        {
            var userInfo = await myContext.AllUsers.FindAsync(deleteModel.Id);

            if(userInfo!= null)
            {
                myContext.AllUsers.Remove(userInfo);
                await myContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}


/* async Task<IActionResult>*/