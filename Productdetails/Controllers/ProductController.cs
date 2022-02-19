using Productdetails.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Productdetails.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            SqlConnection cd = new SqlConnection();
            cd.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductData;Integrated Security=True;";
            cd.Open();
            SqlCommand cmds = new SqlCommand();
            cmds.Connection = cd;
            cmds.CommandType = System.Data.CommandType.Text;
            cmds.CommandText = "select * from Products ";
            List<Products> pd = new List<Products>();
            try
            {
                SqlDataReader dr = cmds.ExecuteReader();
                while (dr.Read())
                {
                    pd.Add(new Products { ProductId = (int)dr["ProductId"], ProductName = dr["ProductName"].ToString(), Rate = (decimal)dr["Rate"], Description = dr["Description"].ToString(), CategoryName = dr["CategoryName"].ToString() });
                }
                dr.Close();
            }
            catch
            {

            }
            cd.Close();
            return View(pd);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Products pd = null;
            SqlConnection cd = new SqlConnection();
            cd.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ProductData; Integrated Security = True";
            cd.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cd;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Products where ProductId=@ProductId";

            cmd.Parameters.AddWithValue("@ProductId", id);
            SqlDataReader sqdrd = cmd.ExecuteReader();
            if (sqdrd.Read())
            {
                pd = new Products { ProductId = (int)sqdrd["ProductId"], ProductName = sqdrd["ProductName"].ToString(), Rate = (decimal)sqdrd["Rate"], Description = sqdrd["Description"].ToString(), CategoryName = sqdrd["CategoryName"].ToString() };

            }
            else
            {
                ViewBag.ErrorMessage = "No Data Found";
            }
            sqdrd.Close();
            cd.Close();

            return View(pd);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Products obj)
        {
            SqlConnection cd = new SqlConnection();
            cd.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ProductData; Integrated Security = True";
            cd.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cd;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update Products set ProductName=@ProductName, Rate=@Rate, Description=@Description, CategoryName=@CategoryName where ProductId=@ProductId";

            cmd.Parameters.AddWithValue("@ProductId", obj.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", obj.ProductName);
            cmd.Parameters.AddWithValue("@Rate", obj.Rate);
            cmd.Parameters.AddWithValue("@Description", obj.Description);
            cmd.Parameters.AddWithValue("@CategoryName", obj.CategoryName);


            try
            {
                cmd.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
            catch (Exception excp)
            {
                ViewBag.Error = (excp.Message);
                return View();
            }
            finally
            {
                cd.Close();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
