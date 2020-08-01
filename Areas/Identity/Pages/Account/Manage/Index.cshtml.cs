using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SammysAuto.Data;

namespace SammysAuto.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<SammysAutoUser> _userManager;
        private readonly ApplicationDbContext _db;
        private readonly SignInManager<SammysAutoUser> _signInManager;

        public IndexModel(
            UserManager<SammysAutoUser> userManager,
            ApplicationDbContext db,
            SignInManager<SammysAutoUser> signInManager)
        {
            _userManager = userManager;
            _db = db;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Email { get; set; }


        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            public string FirstName { get; set; }


            public string LastName { get; set; }


            public string Address { get; set; }


            public string City { get; set; }


            public string PostalCode { get; set; }

            public string Password { get; set; }

            public string ConfirmPassword { get; set; }
        }

        private async Task LoadAsync(SammysAutoUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                City = user.City,
                PostalCode = user.PostalCode,
                Password = user.Password,
                ConfirmPassword = user.ConfirmPassword
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var userInDb = _db.Users.Where(u => u.Email.Equals(user.Email)).FirstOrDefault();
            userInDb.FirstName = user.FirstName;
            userInDb.LastName = user.LastName;
            userInDb.Address = user.Address;
            userInDb.City = user.   City;
            userInDb.PhoneNumber = user.PhoneNumber;
            userInDb.PostalCode = user.PostalCode;

            await _db.SaveChangesAsync();

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
