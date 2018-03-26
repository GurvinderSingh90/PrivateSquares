using System;
using Microsoft.AspNetCore.Mvc;
using PrivateSquares.Web.Models;
using PrivateSquares.Web.Services;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace PrivateSquares.Web.Controllers
{
    public class AccountController : Controller
    {
        public static string sApiUrl = clsCommon.GetApiUrl();

        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost("register")]
        public IActionResult Register(Register register)
        {
            using (var client = new HttpClient())
            {
                if (ModelState.IsValid)
                {
                    client.BaseAddress = new Uri(sApiUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PostAsJsonAsync<Register>("api/Account/register", register).Result;
                    using (HttpContent content = response.Content)
                    {
                        Task<string> result = null;
                        if (response.IsSuccessStatusCode)
                        {
                            result = content.ReadAsStringAsync();
                            TempData["msg"] = result.Result;
                            return RedirectToAction("Register");
                        }
                        else
                        {
                            result = content.ReadAsStringAsync();
                            TempData["msg"] = result.Result;
                        }
                    }
                }
                return View(register);
            }
        }

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost("login")]
        public IActionResult Login(Login user)
        {
            using (var client = new HttpClient())
            {
                if (ModelState.IsValid)
                {
                    client.BaseAddress = new Uri(sApiUrl);
                    var response = client.PostAsJsonAsync("api/Account", user).Result;
                    using (HttpContent content = response.Content)
                    {
                        Task<string> result = null;
                        if (response.IsSuccessStatusCode)
                        {
                            result = content.ReadAsStringAsync();
                            TempData["msg"] = result.Result;
                            return RedirectToAction("login");
                        }
                        else
                        {
                            result = content.ReadAsStringAsync();
                            TempData["msg"] = result.Result;
                        }
                    }
                }
                return View(user);
            }
        }

        [HttpGet("verify-email")]
        public IActionResult VerifyEmail()
        {
            return RedirectToAction("Login");
        }

        [HttpGet("thank-you")]
        public IActionResult CompleteRegistration()
        {
            return RedirectToAction("Login");
        }


    }
}