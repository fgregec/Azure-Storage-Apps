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
    public class SqlRepository : IRepository<Person>
    {
        private const string FirstNameParam = "@firstname";
        private const string LastNameParam = "@lasstname";
        private const string AgeParam = "@age";
        private const string EmailParam = "@email";
        private const string PictureParam = "@picture";
        private const string IdPersonParam = "@idPerson";
        private const string SubjectIDParam = "@subjectid";

        private const string IdTeacherParam = "@idTeacher";
        private const string IdSubjectParam = "@idSubject";

        private static string cs = Cryptography.Decrypt(ConfigurationManager.ConnectionStrings["cs"].ConnectionString, "abc");
        //private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public void Add(Person person)
        {
            using(SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Person);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Person.FirstName), person.FirstName);
                    cmd.Parameters.AddWithValue(nameof(Person.LastName), person.LastName);
                    cmd.Parameters.AddWithValue(nameof(Person.Age), person.Age);
                    cmd.Parameters.AddWithValue(nameof(Person.Email), person.Email);
                    cmd.Parameters.AddWithValue(nameof(Person.SubjectID), person.SubjectID);

                    cmd.Parameters.Add(new SqlParameter(nameof(Person.Picture), System.Data.SqlDbType.Binary, person.Picture.Length)
                    {
                        Value = person.Picture
                    });

                    SqlParameter id = new SqlParameter(nameof(Person.IDPerson), System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(id);
                    cmd.ExecuteNonQuery();
                    person.IDPerson = (int)id.Value;
                }
            }
        }

        public void Delete(Person person)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Person);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Person.IDPerson), person.IDPerson);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Person Get(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Person);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Person.IDPerson), id);

                    using(SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ReadPerson(dr);
                        }
                    }


                    cmd.ExecuteNonQuery();
                }
            }
            throw new Exception("Wrong id");
        }

        public IList<Person> GetAll()
        {

            IList<Person> list = new List<Person>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Person);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(ReadPerson(dr));
                        }
                    }

                    cmd.ExecuteNonQuery();
                }
                return list;
            }
        }

        private Person ReadPerson(SqlDataReader dr)
        {
            return new Person
            {
                IDPerson = (int)dr[nameof(Person.IDPerson)],
                Age = (int)dr[nameof(Person.Age)],
                FirstName = dr[nameof(Person.FirstName)].ToString(),
                LastName = dr[nameof(Person.LastName)].ToString(),
                Email = dr[nameof(Person.Email)].ToString(),
                Picture = ImageUtils.ByteArrayFromSqlDataReader(dr, 5),
                SubjectID = (int)dr[nameof(Person.SubjectID)]
            };
        }

        public void Update(Person person)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Person);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Person.FirstName), person.FirstName);
                    cmd.Parameters.AddWithValue(nameof(Person.LastName), person.LastName);
                    cmd.Parameters.AddWithValue(nameof(Person.Age), person.Age);
                    cmd.Parameters.AddWithValue(nameof(Person.Email), person.Email);
                    cmd.Parameters.AddWithValue(nameof(Person.IDPerson), person.IDPerson);
                    cmd.Parameters.AddWithValue(nameof(Person.SubjectID), person.SubjectID);

                    cmd.Parameters.Add(new SqlParameter(nameof(Person.Picture), System.Data.SqlDbType.Binary, person.Picture.Length)
                    {
                        Value = person.Picture
                    });                   
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
