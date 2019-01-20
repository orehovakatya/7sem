using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public class myDAL
    {
        //connection string of the server database
        private static readonly string connString =
            System.Configuration.ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;






        //-----------------------------------------------------------------------------------//
        //																					 //
        //									SIGNUP											 //
        //																					 //
        //-----------------------------------------------------------------------------------//



        /*CHECKS WHETHER IT IS A VALID USER AND RETURN ITS TYPE*/
        public int validateLogin(string Email, string Password, ref int id)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            try
            {

                SqlCommand cmd1 = new SqlCommand("Login", con);
                cmd1.CommandType = CommandType.StoredProcedure;

                /*
                 procedure Login
                 @email varchar(30),
                 @password varchar(20),
                 @status int output,
                 @ID int output,
                 @type int output
                 */


                cmd1.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = Email;
                cmd1.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = Password;

                cmd1.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
               // cmd1.Parameters.Add("@type", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd1.ExecuteNonQuery();

                int status = (int)cmd1.Parameters["@status"].Value;
                //type = (int)cmd1.Parameters["@type"].Value;
                id = (int)cmd1.Parameters["@ID"].Value;

                return status;
            }

            catch (SqlException ex)
            {
                return -1;
            }

            finally
            {
                con.Close();
            }
        }
    }
}