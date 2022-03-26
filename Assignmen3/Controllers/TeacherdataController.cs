using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assignmen3.Models;
using MySql.Data.MySqlClient;

namespace Assignmen3.Controllers
{
    public class TeacherdataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext teacher = new SchoolDbContext();
        
        //This Controller Will access the authors table of our blog database.
        /// <summary>
        /// Returns a list of Authors in the system
        /// </summary>
        /// <example>GET api/AuthorData/ListAuthors</example>
        /// <returns>
        /// A list of authors (first names and last names)
        /// </returns>
        [HttpGet]
        public IEnumerable<Teacher> ListTeacher()
        {
            //Create an instance of a connection
            MySqlConnection Conn = teacher.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from teachers";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Authors
            List<Teacher> Teacher = new List<Teacher>{};

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string EmployeeNo = ResultSet["employeenumber"].ToString();
                DateTime Hiredate = (DateTime)ResultSet["hiredate"];
                Decimal Salary = (Decimal)ResultSet["salary"];

                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname= TeacherLname;
                NewTeacher.EmployeeNo = EmployeeNo;
                NewTeacher.salary = Salary;

                //Add the Author Name to the List
                Teacher.Add(NewTeacher);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of author names
            return Teacher;
        }


        /// <summary>
        /// Finds an author in the system given an ID
        /// </summary>
        /// <param name="id">The author primary key</param>
        /// <returns>An author object</returns>
        [HttpGet]
        public Teacher FindTeacher(int id)
        {
            Teacher NewTeacher = new Teacher();

            //Create an instance of a connection
            MySqlConnection Conn = teacher.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Teachers where teacherid = "+id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string EmployeeNo = ResultSet["employeenumber"].ToString();
                DateTime Hiredate = (DateTime)ResultSet["hiredate"];
                Decimal Salary = (Decimal)ResultSet["salary"];

                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNo = EmployeeNo;
                NewTeacher.salary = Salary;

            }

            return NewTeacher;
        }
    }
}
