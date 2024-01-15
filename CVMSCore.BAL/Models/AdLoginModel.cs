using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVMSCore.BAL.Models
{
    public class AdLoginModel
    {
        public int AdminId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

    }

    public class AdSigupModel
    {
        public int AdminId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

    }

    public class AppSigupModel
    {
        public int ApplicantId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

    }

    public class AppLoginModel
    {
        public int ApplicantId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

    }

    public class EmpLoginModel
    {
        public int EmployeeId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

    }

    public class EmpSignupModel
    {
        public int EmployeeId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

    }

    public class JobOpeningModel
    {
        public int JobId { get; set; }
        public string? JobName { get; set; }
        public string? RequiredSkills { get; set; }
        public string? PreferredQualifications { get; set; }
        public int MinimumExperience { get; set; }
        public int SalaryPackage { get; set; }
        public DateTime ValidUpto { get; set; }

    }


    public class ApplicantPostModel
    {

        public int AppId { get; set; }
        public string? FullName { get; set; }
        public string? Qualifications { get; set; }
        public string? Experience { get; set; }
        public long AadharNumber { get; set; }
        public string? Fileattach { get; set; }
        public string? JobName { get; set; }
        public string? RequiredSkills { get; set; }
        public string? PreferredQualifications { get; set; }
        public int MinimumExperience { get; set; }
        public int SalaryPackage { get; set; }
    }


    public class EmpDtlPostModel
    {
        public int EmpId { get; set; }
        public string? EmpName { get; set; }
        public DateTime EmpDob { get; set; }
        public string? EmpGender { get; set; }
        public long EmpMob { get; set; }
        public string? EmpEmail { get; set; }
        public string? EmpAddress { get; set; }
        public string? BankName { get; set; }
        public string? AccountHolderName { get; set; }
        public string? IfscCode { get; set; }
        public string? AccountNo { get; set; }
    }

    public class UserLogin
    {
        public int Userid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string UserSubType { get; set; }
        public int IsAuthenticated { get; set; }
        public string LoggedInName { get; set; }

    }

}


