using CVMSCore.BAL.Models;
using CVMSCore.BAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVMSCore.BAL.Service
{
    public class AdLoginSer
    {
        AdLoginRepo _repo = new AdLoginRepo();

        //----------------------------------admin login-----------------------------------
        public int AdminloginSer(AdLoginModel obj)
        {
            return _repo.AdminLoginRepository(obj);
        }

        //---------------------------------admin signup-----------------------------------
        public int AdminSignupSer(AdSigupModel obj)
        {
            return _repo.AdminSignupRepository(obj);
        }

        //--------------------------------applicant signup-------------------------------
        public int ApplicantSignupSer(AppSigupModel obj)
        {
            return _repo.ApplicantSignupRepository(obj);
        }

        //----------------------------------applicant login-----------------------------------
        public int ApplicantloginSer(AppLoginModel obj)
        {
            return _repo.ApplicantLoginRepository(obj);
        }

        //--------------------------------employee signup-------------------------------
        public int EmployeeSignupSer(EmpSignupModel obj)
        {
            return _repo.EmployeeSignupRepository(obj);
        }

        //----------------------------------employee login-----------------------------------
        public int EmployeeloginSer(EmpLoginModel obj)
        {
            return _repo.EmployeeLoginRepository(obj);
        }


        //---------------------------------add job opening-----------------------------------
        public int AddJobSer(JobOpeningModel Obj)
        {
            return _repo.SaveJobOpening(Obj);
        }

        //---------------------------------get job opening------------------------------------
        public List<JobOpeningModel> JobOpening()
        {
            List<JobOpeningModel> ls = new List<JobOpeningModel>();
            ls = _repo.getdata();
            return ls;
        }

        //-------------------------------------get job dtl in applicant dtl form------------------------------

        public JobOpeningModel AppJobService(int jobId)
        {
            try
            {
                return _repo.AppJobRepo(jobId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-----------------------------------------------------------------------------------------------------

        public List<JobOpeningModel> ApplicantJobServiceList(int jobId)
        {
            List<JobOpeningModel> appli = new List<JobOpeningModel>();

            appli = _repo.ApplicantJobRepoList(jobId);
            return appli;

        }


        //--------------------------------post applicant dtl------------------

        public int PostAppDetails(ApplicantPostModel Obj, string filepath)
        {
            return _repo.SaveAppDetailsRepo(Obj, filepath);
        }

        //--------------------------------get applicant dtl-----------------------

        public List<ApplicantPostModel> GetAppSer()
        {
            List<ApplicantPostModel> ls = new List<ApplicantPostModel>();
            ls = _repo.getapp();
            return ls;
        }

        //---------------------------------post emp dtl-----------------------------------
        public int EmpDtlPostSer(EmpDtlPostModel Obj)
        {
            return _repo.EmpDtlPostRepo(Obj);
        }

        //--------------------------------get emp dtl-------------------------------------
        public List<EmpDtlPostModel> EmployeeDetails()
        {
            List<EmpDtlPostModel> ls = new List<EmpDtlPostModel>();
            ls = _repo.getempdtl();
            return ls;
        }

        //-------------------------------------new login--------------------------------------
        public UserLogin AdminLogSer(string UserName, string Password)
        {
            return _repo.AdminLoginRepo(UserName, Password);
        }
    }


}
