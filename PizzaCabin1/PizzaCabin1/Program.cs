using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PizzaCabin1
{
    class Program
    {
        static void Main(string[] args)
        {
            string json;
            //Test WebServiceTest = new Test();
            //WebServiceTest.TestMe();
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("http://pizzacabininc.azurewebsites.net/PizzaCabinInc.svc/schedule/2015-12-14");
            }
            //json = WebServiceTest.TestMe();
            Rootobject rootobject = JsonConvert.DeserializeObject<Rootobject>(json);
            UpdateDB(rootobject);
            Console.ReadLine();
        }
        public static void UpdateDB(Rootobject rootobject)
        {
            string InsertShedules = "";
            string InsertProjections = "";
            string InsertActvities = "";
            System.Data.SqlClient.SqlConnection sqlConnection1 =
                new System.Data.SqlClient.SqlConnection(ConfigurationManager.AppSettings["DBConnectionString"]);

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = sqlConnection1;

            for (int i = 0; i < rootobject.ScheduleResult.Schedules.Length; i++)
            {
                int IsFullDayAbsence;
                if (rootobject.ScheduleResult.Schedules[i].IsFullDayAbsence == false)
                {
                    IsFullDayAbsence = 0;
                }
                else
                {
                    IsFullDayAbsence = 1;
                }
                InsertShedules = "INSERT INTO Schedules (Schedule, ContractTimeMinutes, ScheduleDate, IsFullDayAbscense, EmployeeName, PersonID) " +
                    " VALUES ("+ i + "," + rootobject.ScheduleResult.Schedules[i].ContractTimeMinutes + ",'" + rootobject.ScheduleResult.Schedules[i].Date + "'," + IsFullDayAbsence + ",'" + rootobject.ScheduleResult.Schedules[i].Name + "','" + rootobject.ScheduleResult.Schedules[i].PersonId + "')";
                cmd.CommandText = InsertShedules;
                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();

                InsertProjections = "INSERT INTO Projections (PersonID, ScheduleID) " +
                    " VALUES ('" + rootobject.ScheduleResult.Schedules[i].PersonId + "'," + "(SELECT ScheduleID FROM Schedules WHERE Schedule = '" + i + "' AND PersonID = '" + rootobject.ScheduleResult.Schedules[i].PersonId + "'))";
                cmd.CommandText = InsertProjections;
                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
                int k = 0;
                foreach (PizzaCabin1.Activity a in rootobject.ScheduleResult.Schedules[i].Projection)
                {
                    InsertActvities = "INSERT INTO Activities(ActivityNumber, Color, Description, StartDateTime, Minutes, ProjectionID) " +
                        " VALUES (" + k + ",'" + a.Color + "','" + a.Description + "','" + a.Start + "'," + a.minutes + ",(SELECT ProjectionID FROM Projections WHERE ScheduleId = (SELECT ScheduleID FROM Schedules WHERE Schedule = " + i + " AND PersonID = '" + rootobject.ScheduleResult.Schedules[i].PersonId + "') AND PersonID = '" + rootobject.ScheduleResult.Schedules[i].PersonId + "'))";

                    cmd.CommandText = InsertActvities;
                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection1.Close();
                    k++;
                }
            }
        }
    }
}