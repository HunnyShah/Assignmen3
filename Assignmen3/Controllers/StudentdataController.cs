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
    public class StudentdataController : ApiController
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
        public IEnumerable<Students> ListStudents()
        {
            //Create an instance of a connection
            MySqlConnection Conn = teacher.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from students";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Authors
            List<Students> Students = new List<Students> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int StudentId = (int)ResultSet["studentid"];
                string StudentFname = ResultSet["studentfname"].ToString();
                string StudentLname = ResultSet["studentlname"].ToString();
                string StudentNo = ResultSet["studentnumber"].ToString();
                DateTime Enroll = (DateTime)ResultSet["enroldate"];

                Students NewStudent = new Students();
                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNo = StudentNo;
                NewStudent.Enroll = Enroll;

                //Add the Author Name to the List
                Students.Add(NewStudent);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of author names
            return Students;
        }


        /// <summary>
        /// Finds an author in the system given an ID
        /// </summary>
        /// <param name="id">The author primary key</param>
        /// <returns>An author object</returns>
        [HttpGet]
        public Students FindStudents(int id)
        {
            Students NewStudent = new Students();

            //Create an instance of a connection
            MySqlConnection Conn = teacher.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Students where studentid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int StudentId = (int)ResultSet["studentid"];
                string StudentFname = ResultSet["studentfname"].ToString();
                string StudentLname = ResultSet["studentlname"].ToString();
                string StudentNo = ResultSet["studentnumber"].ToString();
                DateTime Enroll= (DateTime)ResultSet["enroldate"];

                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNo = StudentNo;
                NewStudent.Enroll = Enroll;

            }

            return NewStudent;
        }
    }
}
