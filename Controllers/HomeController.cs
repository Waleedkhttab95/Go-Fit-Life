using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Defult.Models;
using Defult.viewmodel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace Defult.Controllers
{

    public class HomeController : Controller
    {


        private Data _context;
        private static User account;
        private IHostingEnvironment hostingEnv;

        public HomeController(Data c, IHostingEnvironment env)
        {
            _context = c;
            hostingEnv = env;
        }


        public IActionResult Index()
        {
            var isLogged = HttpContext.Session.GetString("isLogged") ?? "0";
            if (isLogged.Equals("1"))
            {
                return Redirect("UserIndex");
            }
            return View("Index");
        }


        public IActionResult UserIndex()
        {
            var isLogged = HttpContext.Session.GetString("isLogged") ?? "0";
            if (!isLogged.Equals("1"))
            {
                return Redirect("http://localhost:1994/Home/Loginview");
            }
            var UserId = int.Parse(HttpContext.Session.GetString("UserId"));
            var UserObj = (User)_context.Users.Where(
                u => u.Id == UserId
            ).FirstOrDefault();

            var Program = _context.Programs.Where(p => p.Id == UserObj.ProgramsId).FirstOrDefault() as Programs;

            HttpContext.Session.SetInt32("Prog", Program.Id);
            HttpContext.Session.SetInt32("UserID", UserObj.Id);
            return View("UserIndex");


        }


        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


        public IActionResult Loginview()
        {

            var isLogged = HttpContext.Session.GetString("isLogged") ?? "0";
            if (isLogged.Equals("1"))
            {
                return Redirect("UserIndex");
            }

            var prog = _context.Programs.ToList();
            var viewModel = new Traineeviewmodel
            {

                Programs = prog,

            };

            return View("Login", viewModel);
        }


        [HttpPost]
        public IActionResult Login(User user)
        {
            account = _context.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();

            if (account != null)
            {
                HttpContext.Session.SetString("isLogged", "1");
                HttpContext.Session.SetString("UserId", account.Id.ToString());
                return RedirectToAction("UserIndex");

            }
            else
            {
                ViewBag.msgl = "*Please try again!";
                return RedirectToAction("Loginview");
            }



        }


        public IActionResult Foods()
        {
            var isLogged = HttpContext.Session.GetString("isLogged") ?? "0";
            if (!isLogged.Equals("1"))
            {
                return Redirect("http://localhost:1994/Home/Loginview");
            }
            return View(account);
        }




        public IActionResult Manage()
        {
            var isLogged = HttpContext.Session.GetString("isLogged") ?? "0";
            if (!isLogged.Equals("1"))
            {
                return Redirect("http://localhost:1994/Home/Loginview");
            }
            var user = HttpContext.Session.GetInt32("UserID");
            var compW = _context.Completed_Workouts.Where(cw => cw.UserId == user.Value);
            var t = compW.ToArray();
            var x = t.Length;

            var UserId = int.Parse(HttpContext.Session.GetString("UserId"));
            var UserObj = (User)_context.Users.Where(
                u => u.Id == UserId
            ).FirstOrDefault();
            var Program = _context.Programs.Where(p => p.Id == UserObj.ProgramsId).FirstOrDefault() as Programs;

            var ModelViewItem = new CompletedPercentageViewModel
            {
                Length = x,
                user = account,
                Program = Program

            };
            return View("Mange", ModelViewItem);
        }


        public IActionResult Edit()
        {
            var isLogged = HttpContext.Session.GetString("isLogged") ?? "0";
            if (!isLogged.Equals("1"))
            {
                return Redirect("http://localhost:1994/Home/Loginview");
            }

            return View("Edit", account);
        }
        //this code is responsible of saving the edited data for the profile
        [HttpPost]
        public IActionResult Edit(User user, IList<IFormFile> files)
        {
            account.Email = user.Email;
            account.Password = user.Password;
            account.Name = user.Name;
            account.Weight = user.Weight;
            if (account.ProgramsId == 1)
            {
                double weightBound = user.Weight * 2.2;
                account.Calories = (int)(weightBound * 13);
                account.Protin = (int)((account.Calories * 0.4) / 4);
                account.Carb = (int)((account.Calories * 0.4) / 4);
                account.Fat = (int)((account.Calories * 0.2) / 9);
            }
            else if (account.ProgramsId == 2)
            {
                double weightBound = user.Weight * 2.2;
                account.Calories = (int)((weightBound * 13) + 200);
                account.Protin = (int)((account.Calories * 0.4) / 4);
                account.Carb = (int)(account.Calories * 0.4) / 4;
                account.Fat = (int)(account.Calories * 0.2) / 9;
            }

            long size = 0;
            int i = 1;

            string s = user.Email + i + ".jpg";
            i++;
            account.imgPath = s;
            foreach (var file in files)
            {
                var filename = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                filename = hostingEnv.WebRootPath + $@"\{s}";
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            var updatedUser = _context.Users.Single(u => u.Id == account.Id);
            TryUpdateModelAsync(updatedUser);
            _context.SaveChanges();

            return View("UserIndex");
        }



        public IActionResult Registerview()
        {
            var isLogged = HttpContext.Session.GetString("isLogged") ?? "0";
            if (isLogged.Equals("1"))
            {
                return Redirect("UserIndex");
            }
            return View("Login");
        }

        [HttpPost]
        public ActionResult Save(User user, IList<IFormFile> files)
        {

            if (ModelState.IsValid)
            {

                if (user.ProgramsId == 1)
                {
                    double weightBound = user.Weight * 2.2;
                    user.Calories = (int)(weightBound * 13);
                    user.Protin = (int)((user.Calories * 0.4) / 4);
                    user.Carb = (int)((user.Calories * 0.4) / 4);
                    user.Fat = (int)((user.Calories * 0.2) / 9);

                }

                if (user.ProgramsId == 2)
                {
                    double weightBound = user.Weight * 2.2;
                    user.Calories = (int)((weightBound * 13) + 200);
                    user.Protin = (int)((user.Calories * 0.4) / 4);
                    user.Carb = (int)(user.Calories * 0.4) / 4;
                    user.Fat = (int)(user.Calories * 0.2) / 9;

                }


                long size = 0;
                string s = user.Email + ".jpg";
                user.imgPath = s;
                foreach (var file in files)
                {
                    var filename = ContentDispositionHeaderValue
                                    .Parse(file.ContentDisposition)
                                    .FileName
                                    .Trim('"');
                    filename = hostingEnv.WebRootPath + $@"\{s}";
                    size += file.Length;
                    using (FileStream fs = System.IO.File.Create(filename))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                }

            }
            _context.Users.Add(user);
            _context.SaveChanges();
            ModelState.Clear();

            return RedirectToAction("Loginview");
        }

    }
}
