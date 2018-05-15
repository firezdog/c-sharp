using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Bank.Models;
using System;
using System.Linq;

namespace Bank.Controllers{
    [Route("")]
    public class LoginController:Controller{
        private readonly BankContext _context;
        public LoginController(BankContext context){
            _context = context;
        }

        [HttpPost]
        [Route("users/new")]
        public IActionResult CreateUser(UserViewModel user){
            if (ModelState.IsValid){
                if (_context.Users.SingleOrDefault(qUser => qUser.EmailAddress == user.EmailAddress) != null){
                    ViewBag.duplicate = true;
                    return View("Register");
                } else {
                    User newUser = new User{
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        EmailAddress = user.EmailAddress,
                        Password = user.Password
                    };
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    newUser.Password = Hasher.HashPassword(newUser,newUser.Password);
                    _context.Users.Add(newUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetString("user",newUser.EmailAddress);
                    return RedirectToAction("BankPage", "Bank");
                }
            }
            ViewBag.duplicate = false;
            return View("Register");
        }
        [HttpGet]
        [Route("")]
        public IActionResult Register(){
            ViewBag.duplicate = false;
            return View();
        }
        [HttpPost]
        [Route("users/login")]
        public IActionResult CheckUser(string user, string password){
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            User foundUser = _context.Users.SingleOrDefault(qUser => qUser.EmailAddress == user);
            if (foundUser != null && password != null){
                if (0 != Hasher.VerifyHashedPassword(foundUser, foundUser.Password, password)){
                    HttpContext.Session.SetString("user",user);
                    return RedirectToAction("BankPage", "Bank");
                }
            }
            ViewBag.fail = true;
            return View("Login");
        }
        [HttpGet]
        [Route("login")]
        public IActionResult Login(){
            ViewBag.fail = false;
            return View();
        }
    }
}
