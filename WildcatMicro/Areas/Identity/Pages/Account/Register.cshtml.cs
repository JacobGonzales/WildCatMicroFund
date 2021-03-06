using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using WildcatMicro.Models;
using WildcatMicro.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace WildcatMicro.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {

            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            public string PhoneNumber { get; set; }


            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            _roleManager.CreateAsync(new IdentityRole(SD.MentorRole)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.InternRole)).GetAwaiter().GetResult();

            //retrieve the role from the form
            string role = Request.Form["rdUserRole"].ToString();
            /*if (role == "")
            { role = SD.AdministratorRole; }*/ //make the first login a manager)
            returnUrl = returnUrl ?? Url.Content("~/"); //null-coalescing assignment operator ??= assigns the value of right-hand operand to its left-hand operand only if the left-hand is nulll
            if (ModelState.IsValid)
            {
                //expand identityuser with applicationuser properties
                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    PhoneNumber = Input.PhoneNumber
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                //add the roles to the ASPNET Roles table if they do not exist yet
                if (!await _roleManager.RoleExistsAsync(SD.AdministratorRole))
                {
                    _roleManager.CreateAsync(new IdentityRole(SD.AdministratorRole)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.ApplicantRole)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.JudgeRole)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.MentorRole)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.InternRole)).GetAwaiter().GetResult();
                }
                if (result.Succeeded)
                //assign role to the user (from the form radio options available after the first manager is created)
                {
                    switch (role)
                    {
                        case SD.AdministratorRole:
                            await _userManager.AddToRoleAsync(user, SD.AdministratorRole);
                            break;
                        case SD.ManagementRole:
                            await _userManager.AddToRoleAsync(user, SD.ManagementRole);
                            break;
                        case SD.MentorRole:
                            await _userManager.AddToRoleAsync(user, SD.MentorRole);
                            break;
                        case SD.JudgeRole:
                            await _userManager.AddToRoleAsync(user, SD.JudgeRole);
                            break;
                        default:
                            await _userManager.AddToRoleAsync(user, SD.ApplicantRole);
                            break;
                    }                                                                           
               
                    _logger.LogInformation("User created a new account with password.");
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);
                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                       $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
