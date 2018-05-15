using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Bank.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Bank.Controllers{
    [Route("bank")]
    public class BankController:Controller{
        private readonly BankContext _context;
        public BankController(BankContext context){
            _context = context;
        }
        [HttpPost]
        [Route("transaction")]
        public IActionResult Transaction(TransactionViewModel transaction){
            string currentUser = HttpContext.Session.GetString("user");
            ViewBag.user = _context.Users.Where(user => user.EmailAddress == currentUser).SingleOrDefault();
            if (ModelState.IsValid){
                if (ViewBag.user.balance + transaction.amount > 0){
                    Transaction newTransaction = new Transaction{
                        amount = (decimal) transaction.amount,
                        UserId = ViewBag.user.id
                    };
                    _context.Add(newTransaction);
                    int id = ViewBag.user.id;
                    User RetrievedUser = _context.Users.SingleOrDefault(user => user.id == id);
                    RetrievedUser.balance += (decimal) transaction.amount;
                    _context.SaveChanges();
                    return RedirectToAction("BankPage");
                } else {
                    ViewBag.overdrawn = true;
                }
            }
            return View("BankPage");
        }
        [HttpGet]
        [Route("")]
        public IActionResult BankPage(){
            string currentUser = HttpContext.Session.GetString("user");
            if (currentUser == null){
                return RedirectToAction("Login","Login");
            }
            User foundUser = _context.Users.Include(user => user.Transactions).Where(user => user.EmailAddress == currentUser).SingleOrDefault();
            foundUser.Transactions.Sort((x,y) => y.created_at.CompareTo(x.created_at));
            ViewBag.user = foundUser;
            return View();
        }
    }
}