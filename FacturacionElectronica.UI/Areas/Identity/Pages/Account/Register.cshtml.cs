
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using FacturacionElectronica.UI.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using FacturacionElectronica.Modelos;

namespace FacturacionElectronica.UI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Data.Usuario> _signInManager;
        private readonly UserManager<Data.Usuario> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<Data.Usuario> userManager,
            SignInManager<Data.Usuario> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {

            [Required(ErrorMessage = "Ingrese un nombre")]
            [RegularExpression(@"^\w+$", ErrorMessage = "No se permiten espacios en blanco o signos")]
            [Display(Name = "Nombre")]
            [DataType(DataType.Text)]
            public string Nombre { get; set; }

            [Required(ErrorMessage = "Ingrese un nombre")]
            [RegularExpression(@"^\w+$", ErrorMessage = "No se permiten espacios en blanco o signos")]
            [Display(Name = "Primer apellido")]
            [DataType(DataType.Text)]
            public string PrimerApellido { get; set; }

            [Required(ErrorMessage = "Ingrese un nombre")]
            [RegularExpression(@"^\w+$", ErrorMessage = "No se permiten espacios en blanco o signos")]
            [Display(Name = "Segundo apellido")]
            [DataType(DataType.Text)]
            public string SegundoApellido { get; set; }

            [Required(ErrorMessage = "Ingrese un correo electrónico")]
            [Display(Name = "Correo Electrónico")]
            [EmailAddress(ErrorMessage = "Ingrese un Correo Electrónico válido")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Ingrese una Clave")]
            [Display(Name = "Clave")]
            [RegularExpression(@"^((?=.*[a-z])(?=.*\d)(?=.*\w)).+$", ErrorMessage = "La Contraseña debe tener al menos una letra y un número")]
            [StringLength(100, ErrorMessage = "La Clave debe ser de mínimo 6 dígitos", MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required(ErrorMessage = "Ingrese la clave para confirmar")]
            [DataType(DataType.Password)]
            [Display(Name = "Confirmar la Clave")]
            [Compare("Password", ErrorMessage = "Las Contraseñas no coinciden")]
            public string ConfirmPassword { get; set; }
            public int Identificacion { get; set; }
            public TipoDeIdentificacion TipoDeIdentificacion { get; set; }
            public string Provincia { get; set; }
            public string Canton { get; set; }
            public string Distrito { get; set; }
            public string OtrasSenas { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new Data.Usuario
                {
                    UserName = Input.Identificacion.ToString(),
                    Nombre = Input.Nombre,
                    PrimerApellido = Input.PrimerApellido,
                    SegundoApellido = Input.SegundoApellido,
                    Email = Input.Email,
                    TipoDeIdentificacion = Input.TipoDeIdentificacion,
                    Identificacion = Input.Identificacion,
                    Provincia = Input.Provincia,
                    Canton = Input.Canton,
                    Distrito = Input.Distrito,
                    OtrasSenas = Input.OtrasSenas
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Crear una nueva cuenta con contraseña.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirme su correo",
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


