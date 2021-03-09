using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Defult.Models;
using Defult.viewmodel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Remotion.Linq.Clauses;

namespace Defult.Controllers
{

    public class ExcercisesController : Controller
    {
        private Data _context;

        public ExcercisesController(Data c)
        {
            _context = c;
        }

        //This code is responsible of showing the workout page
        public IActionResult WorkoutPage(int wId, int wnum, bool Completed)
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
            HttpContext.Session.SetInt32("Program", Program.Id);
            var Workout = _context.Workout.Where(w => w.Wid == wId).FirstOrDefault() as Workout;
            var WorkoutExces = _context.Workout_Excercise.Join(
                _context.Excercises,
                we => we.WE_ExId,
                e => e.ExId,
                (we, e) => new ExcerciseItem
                {
                    ExId = e.ExId,
                    ExName = e.ExName,
                    ExType = e.ExType,
                    ExBodyPart = e.ExBodyPart,
                    ExEquip = e.ExEquip,
                    ExSkill = e.ExSkill,
                    ExDuration = e.ExDuration,
                    ExDesc = e.ExDesc,
                    ExStepOne = e.ExStepOne,
                    ExStepTwo = e.ExStepTwo,
                    ExVideo = e.ExVideo,
                    WId = we.WE_WId
                }).Where(it => it.WId == Workout.Wid).ToArray();

            var Exc = WorkoutExces[wnum - 1];
            var TotalExc = WorkoutExces.Length;


            var ExcModelView = new ExcWorkModel
            {
                Excercises = WorkoutExces,
                Exc = Exc,
                wnum = wnum,
                TotalExc = TotalExc,
                wId = wId,


            };

            return View("WorkoutPage", ExcModelView);
        }

        //This code is responsible of showing the weeks boxes
        public IActionResult Excercisers()
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

            var ProgramWorkouts1 = _context.Program_Workout.Join(
                _context.Workout,
                pw => pw.PW_Id,
                w => w.Wid,
                (pw, w) => new ProgramWorkoutsItem
                {
                    wId = w.Wid,
                    wName = w.WName,
                    wType = w.WType,
                    wArea = w.WArea,
                    pId = pw.PW_PId
                }
            ).Where(PW => PW.pId == 1).ToArray();

            var ProgramWorkouts2 = _context.Program_Workout.Join(
         _context.Workout,
         pw => pw.PW_Id,
         w => w.Wid,
         (pw, w) => new ProgramWorkoutsItem
         {
             wId = w.Wid,
             wName = w.WName,
             wType = w.WType,
             wArea = w.WArea,
             pId = pw.PW_PId
         }
     ).Where(PW => PW.pId == 2).ToArray();
            var arr = ProgramWorkouts1.Concat(ProgramWorkouts2).ToArray();
            var user = HttpContext.Session.GetInt32("UserID");
            var compW = _context.Completed_Workouts.Where(cw => cw.UserId == user.Value);
            var t = compW.ToArray();

            var ModelViewItem = new UserExcerciseModel
            {
                Program = Program,
                ProgramWorkouts = arr,
                Com = t

            };
            return View("Excercise", ModelViewItem);

        }

        //This code is responsible of displaying the random excercise page

        public IActionResult RandomExcercises()
        {
            var isLogged = HttpContext.Session.GetString("isLogged") ?? "0";
            if (!isLogged.Equals("1"))
            {
                return Redirect("http://localhost:1994/Home/Loginview");
            }

            return View("RandomExcercise");
        }

        //this code is responsible of showing the excercise details in the random excercise page 
        public IActionResult ExcCategory(int BodyPartid, int ExCatId)
        {
            var isLogged = HttpContext.Session.GetString("isLogged") ?? "0";
            if (!isLogged.Equals("1"))
            {
                return Redirect("http://localhost:1994/Home/Loginview");
            }
            var BodyPartSection = _context.BodyPartSection.Where(b => b.BPartId == BodyPartid).FirstOrDefault() as BodyPartSection;

            var Excercises = _context.Excercises.Join(
                   _context.BodyPartSection,
                   e => e.BPartId,
                   b => b.BPartId,
                   (e, b) => new ExcerciseItemCategory
                   {
                       ExId = e.ExId,
                       ExName = e.ExName,
                       ExType = e.ExType,
                       ExBodyPart = e.ExBodyPart,
                       ExEquip = e.ExEquip,
                       ExSkill = e.ExSkill,
                       ExDuration = e.ExDuration,
                       ExDesc = e.ExDesc,
                       ExStepOne = e.ExStepOne,
                       ExStepTwo = e.ExStepTwo,
                       ExVideo = e.ExVideo,
                       BPartId = b.BPartId

                   }
                   ).Where(it => it.BPartId == BodyPartSection.BPartId).ToArray();
            var Exc = Excercises[ExCatId - 1];
            var TotalExc = Excercises.Length;
            var ModelViewItem = new ExcCategoryItemViewModel
            {
                ExcerciseItemCat = Excercises,
                ExcItemCat = Exc,
                TotalExc = TotalExc,
                BodyPartId = BodyPartid
            };
            return View("ExcerciseOfCategory", ModelViewItem);
        }

        //this code is responsible of showing the list of excercises for each body part
        public IActionResult ListRandomExc(int BodyPartid)
        {
            var isLogged = HttpContext.Session.GetString("isLogged") ?? "0";
            if (!isLogged.Equals("1"))
            {
                return Redirect("http://localhost:1994/Home/Loginview");
            }
            var BodyPartSection = _context.BodyPartSection.Where(b => b.BPartId == BodyPartid).FirstOrDefault() as BodyPartSection;

            var Excercises = _context.Excercises.Join(
                   _context.BodyPartSection,
                   e => e.BPartId,
                   b => b.BPartId,
                   (e, b) => new ExcerciseItemCategory
                   {
                       ExId = e.ExId,
                       ExName = e.ExName,
                       BPartId = b.BPartId

                   }
                   ).Where(it => it.BPartId == BodyPartSection.BPartId).ToArray();

            var ModelViewItem = new ExcCategoryItemViewModel
            {
                ExcerciseItemCat = Excercises,
                BodyPartId = BodyPartid
            };
            return View("ListofRandomExcercise", ModelViewItem);
        }

        //this code is responsible of showing completed boxes in the my excercise page
        public IActionResult CompletedWorkout(int wid)
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
            var ProgramWorkouts1 = _context.Program_Workout.Join(
            _context.Workout,
            pw => pw.PW_Id,
            w => w.Wid,
            (pw, w) => new ProgramWorkoutsItem
            {
                wId = w.Wid,
                wName = w.WName,
                wType = w.WType,
                wArea = w.WArea,
                pId = pw.PW_PId
            }
        ).Where(PW => PW.pId == 1).ToArray();

            var ProgramWorkouts2 = _context.Program_Workout.Join(
         _context.Workout,
         pw => pw.PW_Id,
         w => w.Wid,
         (pw, w) => new ProgramWorkoutsItem
         {
             wId = w.Wid,
             wName = w.WName,
             wType = w.WType,
             wArea = w.WArea,
             pId = pw.PW_PId
         }
     ).Where(PW => PW.pId == 2).ToArray();

            var arr = ProgramWorkouts1.Concat(ProgramWorkouts2).ToArray();
            //When Clicking Finish . this code adds the workout to completed workout table
            _context.Completed_Workouts.Add(new Completed_Workouts { UserId = UserObj.Id, PW_PId = Program.Id, PW_WId = arr[wid - 1].wId, Completed = true });
            _context.SaveChanges();
            var user = HttpContext.Session.GetInt32("UserID");
            var compW = _context.Completed_Workouts.Where(cw => cw.UserId == user.Value);
            //getting all completed workout values to list
            var t = compW.ToArray();

            var ModelViewItem = new UserExcerciseModel
            {
                Program = Program,
                ProgramWorkouts = arr,
                Com = t

            };
            return View("Excercise", ModelViewItem);
        }
    }
}