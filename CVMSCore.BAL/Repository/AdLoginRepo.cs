using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVMSCore.BAL.Models;

namespace CVMSCore.BAL.Repository
{
    public class AdLoginRepo
    {
        private SqlConnection _conn;
        private DapperConnection dapper = new DapperConnection(ConnectionFile.Connection_ANTSDB);

        //------------------------------------admin login----------------------------------------
        public int AdminLoginRepository(AdLoginModel obj)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserName", obj.UserName);
            dynamicParameters.Add("@Password", obj.Password);
            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            var result = conn.QueryFirstOrDefault<int>("Save_AdminLogin", dynamicParameters, commandType: CommandType.StoredProcedure);
            DapperConnection.CloseConnection(this._conn);

            return result;

        }

        //----------------------------------------------Admin signup--------------------------------------------------
        public int AdminSignupRepository(AdSigupModel obj)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserName", obj.UserName);
            dynamicParameters.Add("@Password", obj.Password);
            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            var result = conn.QueryFirstOrDefault<int>("Save_AdminSignup", dynamicParameters, commandType: CommandType.StoredProcedure);
            DapperConnection.CloseConnection(this._conn);

            return result;

        }

        //--------------------------------------------Applicant signup-------------------------------------

        public int ApplicantSignupRepository(AppSigupModel obj)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserName", obj.UserName);
            dynamicParameters.Add("@Password", obj.Password);
            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            var result = conn.QueryFirstOrDefault<int>("Save_ApplicantSignup", dynamicParameters, commandType: CommandType.StoredProcedure);
            DapperConnection.CloseConnection(this._conn);

            return result;

        }

        //------------------------------------------Applicant login--------------------------------------------

        public int ApplicantLoginRepository(AppLoginModel obj)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserName", obj.UserName);
            dynamicParameters.Add("@Password", obj.Password);
            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            var result = conn.QueryFirstOrDefault<int>("Save_ApplicantLogin", dynamicParameters, commandType: CommandType.StoredProcedure);
            DapperConnection.CloseConnection(this._conn);

            return result;

        }

        //--------------------------------------------employee signup-------------------------------------

        public int EmployeeSignupRepository(EmpSignupModel obj)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserName", obj.UserName);
            dynamicParameters.Add("@Password", obj.Password);
            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            var result = conn.QueryFirstOrDefault<int>("Save_EmployeeSignup", dynamicParameters, commandType: CommandType.StoredProcedure);
            DapperConnection.CloseConnection(this._conn);

            return result;

        }

        //------------------------------------------Employee login--------------------------------------------

        public int EmployeeLoginRepository(EmpLoginModel obj)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserName", obj.UserName);
            dynamicParameters.Add("@Password", obj.Password);
            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            var result = conn.QueryFirstOrDefault<int>("Save_EmployeeLogin", dynamicParameters, commandType: CommandType.StoredProcedure);
            DapperConnection.CloseConnection(this._conn);

            return result;

        }

        //-------------------------------------Job opening post--------------------------------------------


        public int SaveJobOpening(JobOpeningModel sjb)
        {
            DynamicParameters dynamicParameters1 = new DynamicParameters();
            dynamicParameters1.Add("JobName", (object)sjb.JobName, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("RequiredSkills", (object)sjb.RequiredSkills, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("PreferredQualifications", (object)sjb.PreferredQualifications, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("MinimumExperience", (object)sjb.MinimumExperience, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("SalaryPackage", (object)sjb.SalaryPackage, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("ValidUpto", (object)sjb.ValidUpto, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());


            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            DynamicParameters dynamicParameters2 = dynamicParameters1;
            CommandType? nullable1 = new CommandType?(CommandType.StoredProcedure);
            int? nullable2 = new int?();
            CommandType? nullable3 = nullable1;
            string? str = SqlMapper.ExecuteScalar((IDbConnection)conn, "AddJobOpening", (object)dynamicParameters2, (IDbTransaction)null, nullable2, nullable3).ToString();
            DapperConnection.CloseConnection(this._conn);
            int num = Convert.ToInt32(str);

            return num;
        }

        //----------------------------------------get job opening---------------------------------------

        public List<JobOpeningModel> getdata()
        {
            List<JobOpeningModel> obj = new List<JobOpeningModel>();
            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            obj = conn.Query<JobOpeningModel>("GetJobOpening", commandType: CommandType.StoredProcedure).ToList();
            DapperConnection.CloseConnection(this._conn);

            return obj;
        }


        //--------------------------------get job dtl in applicant dtl form-------------------------------

        public JobOpeningModel AppJobRepo(int jobId)
        {
            try
            {
                using (this._conn = dapper.GetConnection())
                {
                    DapperConnection.OpenConnection(this._conn);

                    
                    var parameters = new DynamicParameters();
                    parameters.Add("@JobId", jobId);

                    var jobdtl = _conn.QueryFirstOrDefault<JobOpeningModel>("GetJobOpeningDtl", parameters, commandType: CommandType.StoredProcedure);

                    DapperConnection.CloseConnection(this._conn);
                    return jobdtl;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-------------------------------------------------------------------------------------------------------
        public List<JobOpeningModel> ApplicantJobRepoList(int jobId)
        {
            List<JobOpeningModel> data = new List<JobOpeningModel>();
            using (this._conn = dapper.GetConnection())
            {
                DapperConnection.OpenConnection(this._conn);
                var parameters = new DynamicParameters();
                parameters.Add("@JobId", jobId);
                data = (List<JobOpeningModel>)_conn.Query<JobOpeningModel>("GetJobOpeningDtl", parameters, commandType: CommandType.StoredProcedure).ToList();
                DapperConnection.CloseConnection(this._conn);
                return data;
            }

}


        //-----------------------------------post applicant dtl------------------------------

        public int SaveAppDetailsRepo(ApplicantPostModel apm, string filepath)
        {

            DynamicParameters dynamicParameters1 = new DynamicParameters();
            dynamicParameters1.Add("FullName", (object)apm.FullName, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("Qualifications", (object)apm.Qualifications, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("Experience", (object)apm.Experience, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("AadharNumber", (object)apm.AadharNumber, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("JobName", (object)apm.JobName, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("RequiredSkills", (object)apm.RequiredSkills, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("PreferredQualifications", (object)apm.PreferredQualifications, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("MinimumExperience", (object)apm.MinimumExperience, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("SalaryPackage", (object)apm.SalaryPackage, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            

            dynamicParameters1.Add("Fileattach", filepath);


            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            DynamicParameters dynamicParameters2 = dynamicParameters1;
            CommandType? nullable1 = new CommandType?(CommandType.StoredProcedure);
            int? nullable2 = new int?();
            CommandType? nullable3 = nullable1;
            string? str = SqlMapper.ExecuteScalar((IDbConnection)conn, "SaveApplicantDetails", (object)dynamicParameters2, (IDbTransaction)null, nullable2, nullable3).ToString();
            DapperConnection.CloseConnection(this._conn);
            int num = Convert.ToInt32(str);

            return num;
        }

        //------------------------------------------get applicant dtl------------------------------------------

        public List<ApplicantPostModel> getapp()
        {
            List<ApplicantPostModel> obj = new List<ApplicantPostModel>();
            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            obj = conn.Query<ApplicantPostModel>("GetAppDetails", commandType: CommandType.StoredProcedure).ToList();
            DapperConnection.CloseConnection(this._conn);

            return obj;
        }

        //-------------------------------------emp dtl post--------------------------------------------


        public int EmpDtlPostRepo(EmpDtlPostModel edm)
        {
            DynamicParameters dynamicParameters1 = new DynamicParameters();
            dynamicParameters1.Add("EmpName", (object)edm.EmpName, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("EmpDob", (object)edm.EmpDob, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("EmpGender", (object)edm.EmpGender, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("EmpMob", (object)edm.EmpMob, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("EmpEmail", (object)edm.EmpEmail, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("EmpAddress", (object)edm.EmpAddress, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("BankName", (object)edm.BankName, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("AccountHolderName", (object)edm.AccountHolderName, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("IfscCode", (object)edm.IfscCode, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("AccountNo", (object)edm.AccountNo, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());


            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            DynamicParameters dynamicParameters2 = dynamicParameters1;
            CommandType? nullable1 = new CommandType?(CommandType.StoredProcedure);
            int? nullable2 = new int?();
            CommandType? nullable3 = nullable1;
            string? str = SqlMapper.ExecuteScalar((IDbConnection)conn, "SaveEmployeeDetails", (object)dynamicParameters2, (IDbTransaction)null, nullable2, nullable3).ToString();
            DapperConnection.CloseConnection(this._conn);
            int num = Convert.ToInt32(str);

            return num;
        }

        //-------------------------------------emp get----------------------------------------

        public List<EmpDtlPostModel> getempdtl()
        {
            List<EmpDtlPostModel> obj = new List<EmpDtlPostModel>();
            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            obj = conn.Query<EmpDtlPostModel>("GetEmployeeDtl", commandType: CommandType.StoredProcedure).ToList();
            DapperConnection.CloseConnection(this._conn);

            return obj;
        }

        //------------------------------------------new login-------------------------------------

        public UserLogin AdminLoginRepo(string UserName, string Password)
        {
            UserLogin userDetail = null;

            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserName", UserName);
                dynamicParameters.Add("@Password", Password);

                using (this._conn = this.dapper.GetConnection())
                {
                    DapperConnection.OpenConnection(this._conn);

                    userDetail = _conn.Query<UserLogin>("ValidateUserLogin", dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, log, or rethrow if needed
            }
            finally
            {
                DapperConnection.CloseConnection(this._conn);
            }

            return userDetail;
        }
    }
}
