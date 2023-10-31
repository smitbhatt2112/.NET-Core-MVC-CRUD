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
                    CombineModel modelProducts = new CombineModel();
                    modelProducts.Product = new ProductsModel();  // Initialize Product
                    modelProducts.ProductDetail = new Product_DetailsModel();  // Initialize ProductDetail
                    foreach (DataRow dr in dt.Rows)
                    {
                        modelProducts.Product.ProductId = Convert.ToInt32(dr["ProductId"]);
                        modelProducts.Product.ProductName = dr["ProductName"].ToString();
                        modelProducts.Product.ProductBrand = dr["ProductBrand"].ToString();
                        modelProducts.Product.ProductManufacturer = dr["ProductManufacturer"].ToString();
                        modelProducts.ProductDetail.ProductVarient= dr["ProductVariant"].ToString();
                        modelProducts.ProductDetail.ProductColor = dr["ProductColor"].ToString();
                        modelProducts.ProductDetail.ProductDes = dr["ProductDes"].ToString();
                        modelProducts.ProductDetail.ProductCost = Convert.ToDecimal(dr["ProductCost"]);
                        modelProducts.ProductDetail.ProductSalePrice = Convert.ToDecimal(dr["ProductSalePrice"]);
                        modelProducts.ProductDetail.PhotoPath = dr["ProductImage"].ToString();

                    }
                    return View("AddProducts", modelProducts);
                }

            }

            return View("AddProducts");
        }
        #endregion

        #region Save
        public IActionResult Save(CombineModel modelProducts)
        {
            if (modelProducts.ProductDetail.File != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);
                /*Here, you're combining the current working directory of your application with the FilePath. This creates an absolute path to the directory where you want to save uploaded files.*/
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileNamewithPath = Path.Combine(path, modelProducts.ProductDetail.File.FileName);
                /*This line creates the full path (including the filename) where the uploaded file will be stored. It combines the path (the directory) with the name of the uploaded file, which is obtained from */
                modelProducts.ProductDetail.PhotoPath = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + modelProducts.ProductDetail.File.FileName;
                using (var stream = new FileStream(fileNamewithPath, FileMode.Create))
                {
                    /*This line creates a new FileStream object. 
                   fileNamewithPath is the path to the file where you want to copy the uploaded file.
                   FileMode.Create specifies that if the file already exists, it should be overwritten; otherwise, a new file will be created. This prepares a stream for writing to the file.*/
                    modelProducts.ProductDetail.File.CopyTo(stream);
                }
            }
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Products_DAL dalLOC = new Products_DAL();
            if (modelProducts.Product.ProductId == null)
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
