using System;
using System.Net;
using System.Configuration;
using Newtonsoft.Json;
namespace PizzaCabin1
{
    class Program
    {
        //Main Method
        static void Main(string[] args)
        {
            Console.WriteLine("Entering Main Method");
            //Variables
            string json;

            //Call to web service
            //WebServiceCall WebServiceTest = new WebServiceCall();
            //json = WebServiceTest.ServiceCall();

            //Pulling JSon Data
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("http://pizzacabininc.azurewebsites.net/PizzaCabinInc.svc/schedule/2015-12-14");
            }

            //Deserializing JSon string and putting it into RootObject
            Rootobject rootobject = JsonConvert.DeserializeObject<Rootobject>(json);
            Console.WriteLine("Deserialized JSon");
            //Calling UpdateDB Method
            UpdateDB(rootobject);

            Console.ReadLine();
        }
        //Update DB Method
        //Takes JSon RootObject and puts data into SQL Database
        public static void UpdateDB(Rootobject rootobject)
        {
            Console.WriteLine("Entering UpdateDB Method");
            //Database Creation script located: ..\PizzaCabin\PizzaCabin1\Database\PizzaDBCreation.sql
            //Variables
            string InsertShedules = "";
            string InsertProjections = "";
            string InsertActvities = "";

            //Setting up SQL Connection
            System.Data.SqlClient.SqlConnection sqlConnection1 =
                new System.Data.SqlClient.SqlConnection(ConfigurationManager.AppSettings["DBConnectionString"]);

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = sqlConnection1;
            Console.WriteLine("SQL Connections Created");

            //Looping through Schedules
            for (int i = 0; i < rootobject.ScheduleResult.Schedules.Length; i++)
            {
                int IsFullDayAbsence;
                //Changing IsFullAbscense from Bool to BIT for SQL DB
                if (rootobject.ScheduleResult.Schedules[i].IsFullDayAbsence == false)
                {
                    IsFullDayAbsence = 0;
                }
                else
                {
                    IsFullDayAbsence = 1;
                }
                //Inserting Schedules into Tables
                InsertShedules = "INSERT INTO Schedules (Schedule, ContractTimeMinutes, ScheduleDate, IsFullDayAbscense, EmployeeName, PersonID) " +
                    " VALUES ("+ i + "," + rootobject.ScheduleResult.Schedules[i].ContractTimeMinutes + ",'" + rootobject.ScheduleResult.Schedules[i].Date + "'," + IsFullDayAbsence + ",'" + rootobject.ScheduleResult.Schedules[i].Name + "','" + rootobject.ScheduleResult.Schedules[i].PersonId + "')";
                cmd.CommandText = InsertShedules;
                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
                //Inserting Projections into Tables
                InsertProjections = "INSERT INTO Projections (PersonID, ScheduleID) " +
                    " VALUES ('" + rootobject.ScheduleResult.Schedules[i].PersonId + "'," + "(SELECT ScheduleID FROM Schedules WHERE Schedule = '" + i + "' AND PersonID = '" + rootobject.ScheduleResult.Schedules[i].PersonId + "'))";
                cmd.CommandText = InsertProjections;
                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
                int k = 0;
                //Looping through Activities
                foreach (PizzaCabin1.Activity a in rootobject.ScheduleResult.Schedules[i].Projection)
                {
                    //Inserting Activities into Tables
                    InsertActvities = "INSERT INTO Activities(ActivityNumber, Color, Description, StartDateTime, Minutes, ProjectionID) " +
                        " VALUES (" + k + ",'" + a.Color + "','" + a.Description + "','" + a.Start + "'," + a.minutes + ",(SELECT ProjectionID FROM Projections WHERE ScheduleId = (SELECT ScheduleID FROM Schedules WHERE Schedule = " + i + " AND PersonID = '" + rootobject.ScheduleResult.Schedules[i].PersonId + "') AND PersonID = '" + rootobject.ScheduleResult.Schedules[i].PersonId + "'))";

                    cmd.CommandText = InsertActvities;
                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection1.Close();
                    k++;
                }
            }
            Console.WriteLine("SQL Update Completed");
        }
    }
}