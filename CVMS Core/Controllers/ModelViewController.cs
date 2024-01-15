using CVMS_Core.Models;
using CVMSCore.BAL.Models;
using CVMSCore.BAL.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CVMS_Core.Controllers
{
    public class ModelViewController : BaseController
    {
        AdLoginSer service = new AdLoginSer();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Aboutus()
        {
            return View();
        }
        public IActionResult AdminLogin()
        {
            return View();
        }
        public IActionResult AdminSignup()
        {
            return View();
        }
        
        public IActionResult EmpDtl()
        {
            return View();
        }
        public IActionResult AppLogin()
        {
            return View();
        }
        public IActionResult AppSignup()
        {
            return View();
        }
        public IActionResult EmpLogin()
        {
            return View();
        }
        public IActionResult EmpSignup()
        {
            return View();
        }
        public IActionResult AdHome()
        {
            return View();
        }
        public IActionResult JobDesc()
        {
            return View();
        }
        public IActionResult JobApplication()
        {
            return View();
        }
        public IActionResult JobApplicant()
        {
            return View();
        }
        public IActionResult AppDtlPage()
        {
            return View();
        }
        public IActionResult EmpDtlGet()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }


        //-----------------------------------admin login--------------------------------------
        public IActionResult AdminLoginPage(AdLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = service.AdminloginSer(model);

                if (result == 1)
                {
                    ViewBag.ReturnMessage = "Congrats Login successfull!!!";
                    return RedirectToAction("AdHome", "ModelView");
                }
                else
                {
                    ViewBag.ReturnMessage = "Invalid credentials";
                    return View("AdminLogin", model);
                }
            }

            return View("AdminLogin", model);
        }

        //--------------------------------------post-admin signup------------------------------------------ 

        public IActionResult AdminSignupPage(AdSigupModel model)
        {
            if (ModelState.IsValid)
            {
                var result = service.AdminSignupSer(model);

                if (result == 101)
                {
                    ViewBag.ReturnMessage = "Congrats Signup successfull!!!";
                    return RedirectToAction("AdminLogin", "ModelView");
                }
                else
                {
                    ViewBag.ReturnMessage = "Invalid credentials";
                    return View("AdminSignup", model);
                }
            }

            return View("AdminSignup", model);
        }

        //--------------------------------------Applicant signup-----------------------------------

        public IActionResult ApplicantSignupPage(AppSigupModel model)
        {
            if (ModelState.IsValid)
            {
                var result = service.ApplicantSignupSer(model);

                if (result == 101)
                {
                    ViewBag.ReturnMessage = "Congrats Signup successfull!!!";
                    return RedirectToAction("AdminLogin", "ModelView");
                }
                else
                {
                    ViewBag.ReturnMessage = "Invalid credentials";
                    return View("AppSignup", model);
                }
            }

            return View("AppSignup", model);
        }

        //-----------------------------------------applicant login-------------------------------------

        public IActionResult ApplicantLoginPage(AppLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = service.ApplicantloginSer(model);

                if (result == 1)
                {
                    ViewBag.ReturnMessage = "Congrats Login successfull!!!";
                    return RedirectToAction("JobApplication", "ModelView");

                }
                else
                {
                    ViewBag.ReturnMessage = "Invalid credentials";
                    return View("AppLogin", model);
                }
            }

            return View("AppLogin", model);
        }

        //--------------------------------------employee signup-----------------------------------

        public IActionResult EmployeeSignupPage(EmpSignupModel model)
        {
            if (ModelState.IsValid)
            {
                var result = service.EmployeeSignupSer(model);

                if (result == 101)
                {
                    ViewBag.ReturnMessage = "Congrats Signup successfull!!!";
                    return RedirectToAction("AdminLogin", "ModelView");
                }
                else
                {
                    ViewBag.ReturnMessage = "Invalid credentials";
                    return View("EmpSignup", model);
                }
            }

            return View("EmpSignup", model);
        }

        //-----------------------------------------employee login-------------------------------------

        public IActionResult EmployeeLoginPage(EmpLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = service.EmployeeloginSer(model);

                if (result == 1)
                {
                    ViewBag.ReturnMessage = "Congrats Login successfull!!!";
                    return RedirectToAction("EmpDtl", "ModelView");

                }
                else
                {
                    ViewBag.ReturnMessage = "Invalid credentials";
                    return View("EmpLogin", model);
                }
            }

            return View("EmpLogin", model);
        }

        //----------------------------------------Post job opening---------------------------------------


        public JsonResult JobOpeningPost(IFormCollection formcollection)
        {
            var result = 0;
            if (formcollection != null)
            {
                JobOpeningModel obj = new JobOpeningModel();
                obj.JobName = Convert.ToString(formcollection["JobName"]);
                obj.RequiredSkills = Convert.ToString(formcollection["RequiredSkills"]);
                obj.PreferredQualifications = Convert.ToString(formcollection["PreferredQualifications"]);
                obj.MinimumExperience = Convert.ToInt32(formcollection["MinimumExperience"]);
                obj.SalaryPackage = Convert.ToInt32(formcollection["SalaryPackage"]);
                obj.ValidUpto = Convert.ToDateTime(formcollection["ValidUpto"]);


                
                result = service.AddJobSer(obj);
                

            }
            return Json(new { result });
        }


        //------------------------------------get job opening--------------------------------


        public JsonResult GetJob()
        {
            List<JobOpeningModel> applicant = new List<JobOpeningModel>();
            applicant = service.JobOpening();
            return Json(new { applicant = applicant });

        }

        //-----------------------------------get job dtl in applicant dtl form-----------------------------

        public JsonResult ApplicantDtlJob(int jobId)
        {



            var obj = service.AppJobService(jobId);
            var jobdtl = service.ApplicantJobServiceList(jobId);



            return Json(new { jobdtl = jobdtl, obj = obj });


        }


        //--------------------------------------post applicant dtl-----------------------------

        public JsonResult PostApplicantDtl(IFormCollection formcollection)
        {

            var result = 0;
            IFormFile file = Request.Form.Files[0];

            string filename = "";

            string filepath = "";


            if (formcollection != null && file != null && file.Length > 0)
            {
                ApplicantPostModel obj = new ApplicantPostModel();

                obj.FullName = Convert.ToString(formcollection["FullName"]);
                obj.Qualifications = Convert.ToString(formcollection["Qualifications"]);
                obj.Experience = Convert.ToString(formcollection["Experience"]);
                obj.AadharNumber = Convert.ToInt64(formcollection["AadharNumber"]);
                obj.JobName = Convert.ToString(formcollection["JobName"]);
                obj.RequiredSkills = Convert.ToString(formcollection["RequiredSkills"]);
                obj.PreferredQualifications = Convert.ToString(formcollection["PreferredQualifications"]);
                obj.MinimumExperience = Convert.ToInt32(formcollection["MinimumExperience"]);
                obj.SalaryPackage = Convert.ToInt32(formcollection["SalaryPackage"]);



                filename = file.FileName;
                filepath = Path.Combine("~/FileUpload/", filename);

        

                result = service.PostAppDetails(obj, filepath);



            }
            return Json(new { result = result });
        }

        //----------------------------------get applicant dtl-------------------------------------

        public JsonResult ApplicantGet()
        {
            List<ApplicantPostModel> applicants = new List<ApplicantPostModel>();
            applicants = service.GetAppSer();
            return Json(new { applicants = applicants });

        }

        //----------------------------------post emp dtl----------------------------------------------

        public JsonResult EmpDetailsPost(IFormCollection formcollection)
        {
            var result = 0;
            if (formcollection != null)
            {
                EmpDtlPostModel obj = new EmpDtlPostModel();
                obj.EmpName = Convert.ToString(formcollection["EmpName"]);
                obj.EmpDob = Convert.ToDateTime(formcollection["EmpDob"]);
                obj.EmpGender = Convert.ToString(formcollection["EmpGender"]);
                obj.EmpMob = Convert.ToInt64(formcollection["EmpMob"]);
                obj.EmpEmail = Convert.ToString(formcollection["EmpEmail"]);
                obj.EmpAddress = Convert.ToString(formcollection["EmpAddress"]);
                obj.BankName = Convert.ToString(formcollection["BankName"]);
                obj.AccountHolderName = Convert.ToString(formcollection["AccountHolderName"]);
                obj.IfscCode = Convert.ToString(formcollection["IfscCode"]);
                obj.AccountNo = Convert.ToString(formcollection["AccountNo"]);


                result = service.EmpDtlPostSer(obj);


            }
            return Json(new { result });
        }

        //-----------------------------------get emp dtl----------------------------------

        public JsonResult EmpDetailGet()
        {
            List<EmpDtlPostModel> empdtl = new List<EmpDtlPostModel>();
            empdtl = service.EmployeeDetails();
            return Json(new { empdtl = empdtl });

        }

        //------------------------------------new login------------------------------------

        public IActionResult login(string UserName, string Password)
        {
            UserLogin userdt = new UserLogin();
            List<UserLogin> userdtt = new List<UserLogin>();
            if (UserName != null && Password != null)
            {
                userdt = service.AdminLogSer(UserName, Password);
                if (userdt != null)
                {
                    HttpContext.Session.SetString("LoggedUserInfo", JsonConvert.SerializeObject(userdt));
                    var value = HttpContext.Session.GetString("LoggedUserInfo");
                    //string _userDetail = Security.GetEncryptString(userdt.UserName.Trim() + "|" + encryptPassword.Trim());
                    ViewBag.Userid = userdt.Userid;
                    ViewBag.UserName = userdt.UserName;
                    Debug.WriteLine($"User ID set in ViewBag: {ViewBag.Userid}");
                    Debug.WriteLine($"User Name set in ViewBag: {ViewBag.UserName}");

                    userdt = GetUserDetail();
                }

                if (userdt != null)
                {
                    if (userdt.UserSubType == "Admin")
                    {

                        return RedirectToAction("AdHome", "ModelView");
                    }
                    else if (userdt.UserSubType == "Applicant")
                    {

                        return RedirectToAction("JobApplication", "ModelView");
                    }
                    else if (userdt.UserSubType == "Employee")
                    {

                        return RedirectToAction("EmpDtl", "ModelView");
                    }
                    //else if (userdt.UserSubType == "Patient")
                    //{

                    //    return RedirectToAction("PatientDashBoardPage", "Hospital", new { Userid = userdt.Userid });
                    //}
                }
                //if(userdt != null)
                //{
                //    HttpContext.Session.SetString("LoggedUserInfo", JsonConvert.SerializeObject(userdt));
                //    var value = HttpContext.Session.GetString("LoggedUserInfo");
                //    //string _userDetail = Security.GetEncryptString(userdt.UserName.Trim() + "|" + encryptPassword.Trim());
                //    userdt = GetUserDetail();
                //}


                ViewData["ErrorMessage"] = "Invalid username or password";
                return View("AdminLogin");
            }
            else
            {

                return View();
            }
        }
    }
}
