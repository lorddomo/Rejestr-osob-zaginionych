using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rejestr_osób_zaginionych.Data;
using Rejestr_osób_zaginionych.Models;

namespace Rejestr_osób_zaginionych.Controllers
{
    public class LostController : Controller
    {
        private readonly IConfiguration _configuration;

        public LostController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // GET: Lost
        public IActionResult Index()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("Rejestr_osób_zaginionychDbContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("LostViewAll", sqlConnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.Fill(dtbl);
            }

            return View(dtbl);
        }



        // GET: Lost/AddOrEdit/
        public IActionResult AddOrEdit(int? id)
        {
            LostViewModel lostViewModel = new LostViewModel();
            if (id > 0)
                lostViewModel = FetchLostById(id);
            return View(lostViewModel);
        }

        // POST: Lost/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, [Bind("ID,Name,LastName,Age,Sex,LastSeenPlace,LastSeenDate")] LostViewModel lostViewModel)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {

                    using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("Rejestr_osób_zaginionychDbContextConnection")))
                    {
                        sqlConnection.Open();
                        SqlCommand sqlCmd = new SqlCommand("LostAddOrEdit", sqlConnection);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("ID", lostViewModel.ID);
                        sqlCmd.Parameters.AddWithValue("Name", lostViewModel.Name);
                        sqlCmd.Parameters.AddWithValue("LastName", lostViewModel.LastName);
                        sqlCmd.Parameters.AddWithValue("Age", lostViewModel.Age);
                        sqlCmd.Parameters.AddWithValue("Sex", lostViewModel.Sex);
                        sqlCmd.Parameters.AddWithValue("LastSeenPlace", lostViewModel.LastSeenPlace);
                        sqlCmd.Parameters.AddWithValue("LastSeenDate", lostViewModel.LastSeenDate);
                        sqlCmd.ExecuteNonQuery();
                    }
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(lostViewModel);
        }

        // GET: Lost/Delete/5
        public IActionResult Delete(int? id)
        {
            LostViewModel lostViewModel = FetchLostById(id);
            return View(lostViewModel);
        }

        // POST: Lost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("Rejestr_osób_zaginionychDbContextConnection")))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("LostDeleteByID", sqlConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("ID", id);
                    sqlCmd.ExecuteNonQuery();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public LostViewModel FetchLostById(int? id)
        {
            LostViewModel lostViewModel = new LostViewModel();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("Rejestr_osób_zaginionychDbContextConnection")))
            {
                DataTable dtbl = new DataTable();
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("LostViewById", sqlConnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("ID", id);
                sqlDa.Fill(dtbl);
                if(dtbl.Rows.Count == 1)
                {
                    lostViewModel.ID = Convert.ToInt32(dtbl.Rows[0]["ID"].ToString());
                    lostViewModel.Name = dtbl.Rows[0]["Name"].ToString();
                    lostViewModel.LastName = dtbl.Rows[0]["LastName"].ToString();
                    lostViewModel.Age = dtbl.Rows[0]["Age"].ToString();
                    lostViewModel.Sex = dtbl.Rows[0]["Sex"].ToString();
                    lostViewModel.LastSeenPlace = dtbl.Rows[0]["LastSeenPlace"].ToString();
                    lostViewModel.LastSeenDate = dtbl.Rows[0]["LastSeenDate"].ToString();
                }
                return lostViewModel;
            }
        }
    }
}
