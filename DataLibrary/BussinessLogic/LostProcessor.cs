using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BussinessLogic
{
    public class LostProcessor
    {
        public static void CreateLost(string name, string lastName, string age, string lastSeenPlace, string lastSeenDate)
        {
            LostModel data = new LostModel
            {
                Name = name,
                LastName = lastName,
                Age = age,
                LastSeenPlace = lastSeenPlace,
                LastSeenDate = lastSeenDate,

            };

            string sql = @"insert into dbo.Lost (Name, LastName, Age, LastSeenPlace, LastSeenDate) values (@Name, @LastName, @Age, @LastSeenPlace, @LastSeenDate);";

            //return SqlDataAccess.SaveData(sql, data);
        }

        public static List<LostModel> LoadLost()
        {
            string sql = @"select Id, Name, LastName, Age, LastSeenPlace, LastSeenDate from dbo.Lost;";

            return SqlDataAccess.LoadData<LostModel>(sql);
        }

    }
}
