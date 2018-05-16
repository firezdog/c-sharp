using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WeddingApp.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace WeddingApp.Controllers{
    [Route("wedding")]
    public class WeddingController:Controller{
        private readonly WeddingContext _context;
        private readonly MyGoogleOptions _google;
        public WeddingController(WeddingContext context, IOptions<MyGoogleOptions> MyGoogleOptions){
            _context = context;
            _google = MyGoogleOptions.Value;
        }
        [HttpPost]
        [Route("unrsvp")]
        public IActionResult UnRSVP (int UserId, int WeddingId){
            Attendance Cancellation = _context.Attendance.SingleOrDefault(
                a =>
                a.WeddingId == WeddingId && a.UserId == UserId
            );
            _context.Attendance.Remove(Cancellation);
            _context.SaveChanges();
            return RedirectToAction("WeddingPage");
        }
        [HttpPost]
        [Route("rsvp")]
        public IActionResult RSVP (int UserId, int WeddingId){
            Attendance attendance = new Attendance{
                UserId = UserId,
                WeddingId = WeddingId
            };
            _context.Attendance.Add(attendance);
            _context.SaveChanges();
            return RedirectToAction("WeddingPage");
        }
        [HttpPost]
        [Route("delete")]
        public IActionResult DeleteWedding(int WeddingId){
            Wedding weddingToRemove = _context.Weddings.SingleOrDefault(w => w.WeddingId == WeddingId);
            _context.Weddings.Remove(weddingToRemove);
            _context.SaveChanges();
            return RedirectToAction("WeddingPage");
        }
        [HttpGet]
        [Route("")]
        public IActionResult WeddingPage(){
            if (!LoginCheck()){
                return RedirectToAction("Login", "Login");
            }
            DenigrateWeddings();
            User user = GetUser();
            var weddings = _context.Weddings.Include(wedding => wedding.Users);
            ViewBag.weddings = weddings;
            ViewBag.user = user;
            return View();
        }
        [HttpGet]
        [Route("show")]
        public IActionResult OneWeddingPage(int WeddingId){
            if (!LoginCheck()){
                return RedirectToAction("Login", "Login");
            }
            ViewBag.key = _google.Key;
            ViewBag.wedding = _context.Weddings
                .Include(w => w.Users)
                .ThenInclude (a => a.User)
                .Where(w => w.WeddingId == WeddingId)
                .SingleOrDefault();
            return View();
        }
        [HttpPost]
        [Route("new")]
        public IActionResult NewWedding(WeddingViewModel formdata){
            User user = GetUser();
            if (ModelState.IsValid){
                Wedding wedding = new Wedding {
                    WedderOne = formdata.WedderOne,
                    WedderTwo = formdata.WedderTwo,
                    Date = (DateTime) formdata.Date,
                    Address = formdata.Address,
                    UserId = user.UserId
                };
                _context.Add(wedding);
                _context.SaveChanges();
                return RedirectToAction("OneWeddingPage", new {WeddingId = wedding.WeddingId});
            }
            return View();
        }
        [HttpGet]
        [Route("new")]
        public IActionResult NewWedding(){
            if (!LoginCheck()){
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        public bool LoginCheck() {
            string currentUser = HttpContext.Session.GetString("user");
            if (currentUser == null){
                return false;
            }
            return true;
        }
        public User GetUser() {
            return _context.Users
                .Include(u => u.Weddings)
                .Where(
                    u => 
                    u.EmailAddress == HttpContext.Session.GetString("user")
                )
                .FirstOrDefault();
        }
        public void DenigrateWeddings() {
            List<Wedding> weddings = _context.Weddings.ToList();
            foreach (Wedding wedding in weddings){
                if (wedding.Date < DateTime.Now){
                    _context.Remove(wedding);
                    _context.SaveChanges();
                }
            }
        }
    }
}