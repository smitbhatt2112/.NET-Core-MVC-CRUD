using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Project_Management.DAL;
using Project_Management.Models;
using System.Data;

namespace Project_Management.Controllers
{
    public class Product_DetailsController : Controller
    {
        private IConfiguration Configuration;
        public Product_DetailsController(IConfiguration _configuration)// When you create an instance of YourService, the ASP.NET Core framework will provide an IConfiguration instance to this constructor 
        {
            Configuration = _configuration;
        }

        #region Select all
        public IActionResult Index(int? ProductID)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Product_Details_DAL dalProducts_det = new Product_Details_DAL();
            DataTable dt = dalProducts_det.pr_Products_Details_SelectByProductId(connectionstr, ProductID);
            return View("Product_Details_List", dt);
        }
        #endregion

        #region Insert and Update
        public IActionResult Add(int? ProductID)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Product_Details_DAL dalLOC = new Product_Details_DAL();

            if (ProductID != null)
            {
                DataTable dt = dalLOC.pr_Products_Details_SelectByProductId(connectionstr, ProductID);

                if (dt.Rows.Count > 0)
                {
                    Product_DetailsModel modelProducts_det = new Product_DetailsModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        modelProducts_det.Product_Details_Id = Convert.ToInt32(dr["Product_Details_Id"]);
                        modelProducts_det.ProductId = Convert.ToInt32(dr["ProductId"]);
                        modelProducts_det.ProductVarient = dr["ProductVariant"].ToString();
                        modelProducts_det.ProductColor = dr["ProductColor"].ToString();
                        modelProducts_det.ProductDes = dr["ProductDes"].ToString();
                        modelProducts_det.ProductCost = Convert.ToInt32(dr["ProductCost"]);
                        modelProducts_det.ProductSalePrice = Convert.ToInt32(dr["ProductSalePrice"]);
                        modelProducts_det.PhotoPath = dr["ProductImage"].ToString();
                    }
                    return View("AddProduct_Details", modelProducts_det);
                }

            }
            return View("AddProduct_Details");
        }
        #endregion

        #region Save
        public IActionResult Save(Product_DetailsModel modelProducts_Details)
        {
            if (modelProducts_Details.File != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);
                /*Here, you're combining the current working directory of your application with the FilePath. This creates an absolute path to the directory where you want to save uploaded files.*/
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileNamewithPath = Path.Combine(path, modelProducts_Details.File.FileName);
                /*This line creates the full path (including the filename) where the uploaded file will be stored. It combines the path (the directory) with the name of the uploaded file, which is obtained from */
                modelProducts_Details.PhotoPath = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + modelProducts_Details.File.FileName;

                using (var stream = new FileStream(fileNamewithPath, FileMode.Create))
                {
                    /*This line creates a new FileStream object. 
                   fileNamewithPath is the path to the file where you want to copy the uploaded file.
                   FileMode.Create specifies that if the file already exists, it should be overwritten; otherwise, a new file will be created. This prepares a stream for writing to the file.*/
                    modelProducts_Details.File.CopyTo(stream);
                }
            }

            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Product_Details_DAL dalProd_det = new Product_Details_DAL();
            if (modelProducts_Details.Product_Details_Id == null)
            {
                if (Convert.ToBoolean(dalProd_det.pr_Product_Details_Insert(connectionstr, modelProducts_Details)))
                {
                    TempData["AlertMsg"] = "Record Inserted Successfully";
                }

            }
            else
            {
                if (Convert.ToBoolean(dalProd_det.pr_Product_Details_Update(connectionstr, modelProducts_Details)))
                {
                    TempData["AlertMsg"] = "Record Inserted Successfully";
                }
            }

            var ProductID = modelProducts_Details.ProductId;
            return RedirectToAction("Index", new { ProductID = ProductID });
        }
        #endregion


    }
}
