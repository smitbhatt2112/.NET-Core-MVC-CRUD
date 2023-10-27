using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Project_Management.DAL;
using Project_Management.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Project_Management.Controllers
{
    public class ProductsController : Controller
    {
        private IConfiguration Configuration;
        public ProductsController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        #region Select all 
        public IActionResult Index()
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Products_DAL dalLOC = new Products_DAL();
            DataTable dt = dalLOC.pr_Products_selectall(connectionstr);

            return View("ProductsList", dt);
        }
        #endregion

        #region Insert
        public IActionResult Add(int? ProductID) 
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Products_DAL dalLOC = new Products_DAL();

            if (ProductID != null)
            {
                DataTable dt = dalLOC.pr_Products_SelectByPK(connectionstr, ProductID);

                if (dt.Rows.Count > 0)
                {
                    ProductsModel modelProducts = new ProductsModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        modelProducts.ProductId = Convert.ToInt32(dr["ProductId"]);
                        modelProducts.ProductName = dr["ProductName"].ToString();
                        modelProducts.ProductBrand = dr["ProductBrand"].ToString();
                        modelProducts.ProductManufacturer = dr["ProductManufacturer"].ToString();
                    }
                    return View("AddProducts", modelProducts);
                }

            }

            return View("AddProducts");
        }
        #endregion

        #region Save
        public IActionResult Save(ProductsModel modelProducts)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Products_DAL dalLOC = new Products_DAL();
            if (modelProducts.ProductId == null)
            {
                if (Convert.ToBoolean(dalLOC.pr_Products_Insert(connectionstr, modelProducts)))
                {
                    TempData["AlertMsg"] = "Record Inserted Successfully";
                }

            }
            else
            {
                if (Convert.ToBoolean(dalLOC.pr_Products_Update(connectionstr, modelProducts)))
                {
                    TempData["AlertMsg"] = "Record Updated Successfully";
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int ProductID)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Products_DAL dalLOC = new Products_DAL();

            if (Convert.ToBoolean(dalLOC.PR_Products_Delete(connectionstr, ProductID)))
                TempData["AlertMsg"] = "Record Delete Successfully";
            return RedirectToAction("Index");

        }
        #endregion
    }
}
