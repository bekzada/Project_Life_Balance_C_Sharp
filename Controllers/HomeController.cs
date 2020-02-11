using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LifeBalance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LifeBalance.Controllers {
    public class HomeController : Controller {
        private HomeContext dbContext;
        public HomeController (HomeContext context) {
            dbContext = context;
        }

        [HttpGet ("")]
        public IActionResult Index () {
            return View ();
        }

        [HttpPost ("register")]
        public IActionResult Register (User newUser) {
            Regex rx = new Regex (@"\d");
            if (newUser.FirstName != null) {
                MatchCollection FirstNameMatches = rx.Matches (newUser.FirstName);
                if (FirstNameMatches.Count != 0) {
                    ModelState.AddModelError ("FirstName", "'Name' Fields cannot contain numeric characters");
                }
            }
            if (newUser.LastName != null) {
                MatchCollection LastNameMatches = rx.Matches (newUser.LastName);
                if (LastNameMatches.Count != 0) {
                    ModelState.AddModelError ("LastName", "'Name' Fields cannot contain numeric characters");
                }
            }
            if (newUser.Password != null) {
                MatchCollection PasswordNumberMatches = rx.Matches (newUser.Password);
                if (PasswordNumberMatches.Count == 0) {
                    ModelState.AddModelError ("Password", "Password should contain at least one number");
                }
               
            }
            if (dbContext.users.Any (c => c.Email == newUser.Email)) {
                ModelState.AddModelError ("Email", "That Email is taken");
            }
            if (ModelState.IsValid) {
                PasswordHasher<User> Hasher = new PasswordHasher<User> ();
                newUser.Password = Hasher.HashPassword (newUser, newUser.Password);
                HttpContext.Session.SetString ("UserName", newUser.FirstName + " " + newUser.LastName);
                dbContext.users.Add (newUser);
                dbContext.SaveChanges ();
                HttpContext.Session.SetInt32 ("ID", newUser.UserId);
                return Redirect ("signin");
            }
            return View ("Index");
        }
        [HttpGet("signin")]
        public IActionResult Sign ()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login (Login _logUSer) {
            User DbUser = dbContext.users.FirstOrDefault (c => c.Email == _logUSer.LoginEmail);
            if (DbUser == null) {
                ModelState.AddModelError ("LoginEmail", "Email not found. Register?");
            }
            if (ModelState.IsValid) {
                var hasher = new PasswordHasher<Login> ();
                var result = hasher.VerifyHashedPassword (_logUSer, DbUser.Password, _logUSer.LoginPassword);
                if (result == 0) {
                    ModelState.AddModelError ("LoginEmail", "Email or password not valid");
                    return View ("Index");
                }
                HttpContext.Session.SetInt32 ("ID", DbUser.UserId);
                Console.WriteLine(DbUser.UserId);
                HttpContext.Session.SetString ("UserName", DbUser.FirstName + " " + DbUser.LastName);
                return RedirectToAction("CreateValue");
            }
            return View ("Index");
        }

        [HttpGet ("logout")]
        public IActionResult LogOut () {
            HttpContext.Session.Clear ();
            return Redirect ("/");
        }
      ////////////////////////REGISTRATION&LOGIN//////////////////////////////////////////////////
     
    
    private User LoggedIn()
        {
            return dbContext.users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("ID"));
        } 
    
    [HttpGet("CreateValue")]
    public IActionResult CreateValue()
    {
        User userInDb = dbContext.users.FirstOrDefault(u => u.UserId == (int)HttpContext.Session.GetInt32("ID"));
        ViewBag.LoggedId = userInDb.UserId;
        return View();
    }

    [HttpPost ("AddValue")]
   
    public IActionResult AddValue(Values newValue)
    {
        User userInDb = dbContext.users.FirstOrDefault(u => u.UserId == (int)HttpContext.Session.GetInt32("ID"));
        Console.WriteLine(userInDb.FirstName);
        Console.WriteLine("#################");
        if (ModelState.IsValid)
        {
            Console.WriteLine("$$$$");
            dbContext.Values.Add(newValue);
            dbContext.SaveChanges();
            return RedirectToAction("dashboard");
        }
        else
        {
            ViewBag.LoggedId = userInDb.UserId;
            return View("CreateValue");

        }
        ///////////////////////////Create_Value//////////////////////////////////////////////////////
    }

    [HttpGet("dashboard")]
    public IActionResult dashboard()
    {
         if (HttpContext.Session.GetInt32 ("ID") == null) {
                return Redirect ("AddValue");
            }
            List<Values> thisValue = dbContext.Values.Where(p => p.CoordinatorID == HttpContext.Session.GetInt32("ID")).ToList();
            
            return View (thisValue);
       
    }
    //////////////Display only your values/////////////////////////////////////////
}

}