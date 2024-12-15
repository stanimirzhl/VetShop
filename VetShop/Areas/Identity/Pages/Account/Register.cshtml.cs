// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using VetShop.Infrastructure.Data.Models;
using static VetShop.Infrastructure.Constants.DataConstants.UserConstants;
using static VetShop.Infrastructure.Constants.DataConstants.ExceptionMessagesConstants;

namespace VetShop.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = UsersUserNameMessage)]
            [DataType(DataType.Text)]
            [Display(Name = "User name")]
            [StringLength(MaxUsersName, MinimumLength = MinUsersName, ErrorMessage = UsersUserNameLegnthMessage)]
            public string UserName { get; set; }

            [Required(ErrorMessage = UserFirstNameMessage)]
            [DataType(DataType.Text)]
            [Display(Name = "First name")]
            [StringLength(MaxUserFirstName,MinimumLength = MinUserFirstName, ErrorMessage = UserFirstNameLegnthMessage)]
            public string FirstName { get; set; }

            [Required(ErrorMessage = UserLastNameMessage)]
            [DataType(DataType.Text)]
            [Display(Name = "Last name")]
            [StringLength(MaxUserLastName,MinimumLength = MinUserLastName, ErrorMessage = UserLastNameLegnthMessage)]
            public string LastName { get; set; }

        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                var userNameExists = await _userManager.FindByNameAsync(Input.UserName) != null;
                var emailExists = await _userManager.FindByEmailAsync(Input.Email) != null;

                if (userNameExists)
                {
                    ModelState.AddModelError(string.Empty, "The user name is already taken, please try with another one.");
                    return Page();
                }

                if (emailExists)
                {
                    ModelState.AddModelError(string.Empty, "There is an existing user with that email.");
                    return Page();
                }

                var user = (ApplicationUser)Activator.CreateInstance(typeof(ApplicationUser));
                user.UserName = Input.UserName;
                user.Email = Input.Email;
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                user.Id = Guid.NewGuid().ToString();

                var result = await _userManager.CreateAsync(user, Input.Password);


                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}
