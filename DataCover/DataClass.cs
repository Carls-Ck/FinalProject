using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using UsersCover;
using System.Configuration;

namespace DataCover
{
    public class DataClass
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        public DataTable Dlogin(UsersClass obje)
        {
            SqlCommand cmd = new SqlCommand("sp_login", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", obje.user);
            cmd.Parameters.AddWithValue("@code", obje.code);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable D_UsersSearch( UsersClass )
        {
            SqlCommand cmd = new SqlCommand("sp_search_users", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", obje.user);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_UsersList(UsersClass )
        {
            SqlCommand cmd = new SqlCommand("sp_search_users", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public string D_UsersProc (UsersClass obje)
            {
            string action = "";
            SqlCommand cmd = new SqlCommand('dealing_user', con);
            //se tu ver o angola escrever 'cn' pra tu é 'con'^^
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_user", obje.id_user);
            cmd.Parameters.AddWithValue("@name", obje.name);
            cmd.Parameters.AddWithValue("@name_user", obje.user);
            cmd.Parameters.AddWithValue("@id_type", obje.type);
            cmd.Parameters.Add("@action", sqlDbType.VarChar, 50).value=obje.action;
            cmd.Parameters["action"].Direction = ParameterDirection.InputOutput;
            if (con.State == ConnectionState.Open) con.Close();
            con.Open();
            cmd.ExecuteNonQuery();
            action = cmd.Parameters["action"].Value.ToString();
            return action;
        }

    }
}