using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using V03.Models;
using V03.Utils;

namespace V03.Dal
{
    public class SubjectRepository : IRepository<Subject>
    {
        private static string cs = Cryptography.Decrypt(ConfigurationManager.ConnectionStrings["cs"].ConnectionString, "abc");
        //private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public void Add(Subject subject)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Subject);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Subject.Name), subject.Name);

                    SqlParameter idSubject = new SqlParameter(nameof(Subject.IDSubject), System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idSubject);
                    cmd.ExecuteNonQuery();
                    subject.IDSubject = (int)idSubject.Value;
                }
            }
        }

        public void Delete(Subject subject)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Subject);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Subject.IDSubject), subject.IDSubject);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Subject Get(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Subject);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Subject.IDSubject), id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ReadSubject(dr);
                        }
                    }


                    cmd.ExecuteNonQuery();
                }
            }
            throw new Exception("Wrong id");
        }

        private Subject ReadSubject(SqlDataReader dr)
        {
            return new Subject
            {
                IDSubject = (int)dr[nameof(Subject.IDSubject)],
                Name = dr[nameof(Subject.Name)].ToString()
            };
        }

        public IList<Subject> GetAll()
        {
            IList<Subject> list = new List<Subject>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Subject);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(ReadSubject(dr));
                        }
                    }

                    cmd.ExecuteNonQuery();
                }
                return list;
            }
        }

        public void Update(Subject subject)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Subject);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Subject.Name), subject.Name);
                    cmd.Parameters.AddWithValue(nameof(Subject.IDSubject), subject.IDSubject);

                    SqlParameter id = new SqlParameter(nameof(Person.SubjectID), System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
