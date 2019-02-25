using SsoService.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SsoService.DAL
{
    public class clsRepo
    {
        private string connStr;

        public clsRepo(string connStr)
        {
            this.connStr = connStr;
        }

        private DataSet ExecuteSqlCmd(string sqlText)
        {
            SqlCommand cmdSql;
            SqlDataAdapter daSql;

            var ds = new System.Data.DataSet();
            string cmdText = sqlText;

            using (SqlConnection objConnection = new SqlConnection(connStr))
            {
                try
                {
                    objConnection.Open();

                    cmdSql = new SqlCommand();
                    cmdSql.CommandText = cmdText;
                    cmdSql.CommandType = CommandType.Text;
                    cmdSql.Connection = objConnection;

                    daSql = new SqlDataAdapter(cmdSql);
                    daSql.Fill(ds);
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    objConnection.Close();
                }

                return ds;
            }
        }

        public AppUser SelectUserByUserNamePwd(string userName, string password)
        {
            SqlCommand cmdSql;
            SqlDataAdapter daSql;
            var ds = new System.Data.DataSet();
            string cmdText = "";
            var result = new AppUser();

            using (SqlConnection objConnection = new SqlConnection(connStr))
            {
                cmdText = "SELECT * FROM AppUser";
                cmdText += " where userName=@userName and password=@password";

                try
                {
                    objConnection.Open();

                    cmdSql = new SqlCommand();
                    cmdSql.CommandText = cmdText;
                    cmdSql.CommandType = CommandType.Text;
                    cmdSql.Connection = objConnection;

                    cmdSql.Parameters.Add("@userName", SqlDbType.Char).Value = userName;
                    cmdSql.Parameters.Add("@password", SqlDbType.Char).Value = password;

                    daSql = new SqlDataAdapter(cmdSql);
                    daSql.Fill(ds);

                    if (ds != null && ds.Tables.Count > 0)
                    {
                        var query = (from b in ds.Tables[0].AsEnumerable()
                                     select new AppUser
                                     {
                                         UserId = b.Field<int>("UserId"),
                                         UserName = b.Field<string>("UserName"),
                                         Password = b.Field<string>("Password"),
                                     });

                        result = query.FirstOrDefault();
                    }
                    else
                        result = null;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    objConnection.Close();
                }

                return result;
            }
        }

        public AppUser SelectUserByUserName(string userName)
        {
            SqlCommand cmdSql;
            SqlDataAdapter daSql;

            var result = new AppUser();

            var ds = new System.Data.DataSet();
            string cmdText = "";

            cmdText = "SELECT * FROM AppUser";
            cmdText += " where userName=@userName";

            using (SqlConnection objConnection = new SqlConnection(connStr))
            {
                try
                {
                    objConnection.Open();

                    cmdSql = new SqlCommand();
                    cmdSql.CommandText = cmdText;  // 26/01
                    cmdSql.CommandType = CommandType.Text;
                    cmdSql.Connection = objConnection;

                    cmdSql.Parameters.Add("@userName", SqlDbType.Char).Value = userName;

                    daSql = new SqlDataAdapter(cmdSql);
                    daSql.Fill(ds);

                    if (ds != null && ds.Tables.Count > 0)
                    {
                        var query = (from b in ds.Tables[0].AsEnumerable()
                                     select new AppUser
                                     {
                                         UserId = b.Field<int>("UserId"),
                                         UserName = b.Field<string>("UserName"),
                                         Password = b.Field<string>("Password"),
                                     });

                        result = query.FirstOrDefault();
                    }
                    else
                        result = null;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    objConnection.Close();
                }

                return result;
            }
        }

        public bool AddUser(string userName, string password)
        {
            SqlCommand cmdSql;
            string cmdText = "";
            using (SqlConnection objConnection = new SqlConnection(connStr))
            {
                cmdText = "Insert into AppUser";
                cmdText += " VALUES(@userName, @password)";

                try
                {
                    objConnection.Open();

                    cmdSql = new SqlCommand();
                    cmdSql.CommandText = cmdText;
                    cmdSql.CommandType = CommandType.Text;
                    cmdSql.Connection = objConnection;

                    cmdSql.Parameters.Add(new SqlParameter("UserName", userName));
                    cmdSql.Parameters.Add(new SqlParameter("Password", password));

                    cmdSql.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    objConnection.Close();
                }

                return true;
            }
        }
    }
}