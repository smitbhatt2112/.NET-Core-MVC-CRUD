using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Project_Management.Models;

namespace Project_Management.DAL
{
    public class Product_Details_DAL
    {
        #region Product_Details Select all
        public DataTable? pr_Product_Details_selectall(string? conn)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Product_Details_SelectAll");

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region Products Insert
        public bool? pr_Product_Details_Insert(string conn, Product_DetailsModel model_Products_Details)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Product_Details_Insert");
                sqlDB.AddInParameter(dbCMD, "ProductId", SqlDbType.Int, model_Products_Details.ProductId);
                sqlDB.AddInParameter(dbCMD, "ProductVariant", SqlDbType.NVarChar, model_Products_Details.ProductVarient);
                sqlDB.AddInParameter(dbCMD, "ProductColor", SqlDbType.NVarChar, model_Products_Details.ProductColor);
                sqlDB.AddInParameter(dbCMD, "ProductDes", SqlDbType.NVarChar, model_Products_Details.ProductDes);
                sqlDB.AddInParameter(dbCMD, "ProductCost", SqlDbType.Decimal, model_Products_Details.ProductCost);
                sqlDB.AddInParameter(dbCMD, "ProductSalePrice", SqlDbType.Decimal, model_Products_Details.ProductSalePrice);
                sqlDB.AddInParameter(dbCMD, "ProductImage", SqlDbType.NVarChar, model_Products_Details.PhotoPath);

                DataTable dt = new DataTable();
                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

        #region Update
        public bool? pr_Product_Details_Update(string conn, Product_DetailsModel model_Products_Details)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Product_Details_Update");
                sqlDB.AddInParameter(dbCMD, "Product_Details_Id", SqlDbType.Int, model_Products_Details.Product_Details_Id);
                sqlDB.AddInParameter(dbCMD, "ProductId", SqlDbType.Int, model_Products_Details.ProductId);
                sqlDB.AddInParameter(dbCMD, "ProductVariant", SqlDbType.NVarChar, model_Products_Details.ProductVarient);
                sqlDB.AddInParameter(dbCMD, "ProductColor", SqlDbType.NVarChar, model_Products_Details.ProductColor);
                sqlDB.AddInParameter(dbCMD, "ProductDes", SqlDbType.NVarChar, model_Products_Details.ProductDes);
                sqlDB.AddInParameter(dbCMD, "ProductCost", SqlDbType.Decimal, model_Products_Details.ProductCost);
                sqlDB.AddInParameter(dbCMD, "ProductSalePrice", SqlDbType.Decimal, model_Products_Details.ProductSalePrice);
                sqlDB.AddInParameter(dbCMD, "ProductImage", SqlDbType.NVarChar, model_Products_Details.PhotoPath);


                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Select by ProductId
        public DataTable pr_Products_Details_SelectByProductId(string conn, int? ProductId)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ProductsDetails_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "ProductId", SqlDbType.Int, ProductId);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

    }
}
