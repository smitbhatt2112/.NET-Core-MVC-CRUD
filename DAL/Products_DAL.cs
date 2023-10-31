using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Project_Management.Models;

namespace Project_Management.DAL
{
    public class Products_DAL
    {
        #region Products Select all
        public DataTable? pr_Products_selectall(string? conn)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Products_SelectAll");

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
        public bool? pr_Products_Insert(string conn,CombineModel model_Products)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Products_Insert");
                sqlDB.AddInParameter(dbCMD, "ProductName", SqlDbType.NVarChar, model_Products.Product.ProductName);
                sqlDB.AddInParameter(dbCMD, "ProductBrand", SqlDbType.NVarChar,model_Products.Product.ProductBrand);
                sqlDB.AddInParameter(dbCMD, "ProductManufacturer", SqlDbType.NVarChar, model_Products.Product.ProductManufacturer);
                sqlDB.AddInParameter(dbCMD, "ProductVariant", SqlDbType.NVarChar, model_Products.ProductDetail.ProductVarient);
                sqlDB.AddInParameter(dbCMD, "ProductColor", SqlDbType.NVarChar, model_Products.ProductDetail.ProductColor);
                sqlDB.AddInParameter(dbCMD, "ProductDes", SqlDbType.NVarChar, model_Products.ProductDetail.ProductDes);
                sqlDB.AddInParameter(dbCMD, "ProductCost", SqlDbType.Decimal, model_Products.ProductDetail.ProductCost);
                sqlDB.AddInParameter(dbCMD, "ProductSalePrice", SqlDbType.Decimal, model_Products.ProductDetail.ProductSalePrice);
                sqlDB.AddInParameter(dbCMD, "ProductImage", SqlDbType.NVarChar, model_Products.ProductDetail.PhotoPath);
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

        #region Products Update
        public bool? pr_Products_Update(string conn, CombineModel model_Products)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Products_Update");
                sqlDB.AddInParameter(dbCMD, "ProductID", SqlDbType.Int, model_Products.Product.ProductId);
                sqlDB.AddInParameter(dbCMD, "ProductName", SqlDbType.NVarChar, model_Products.Product.ProductName);
                sqlDB.AddInParameter(dbCMD, "ProductBrand", SqlDbType.NVarChar, model_Products.Product.ProductBrand);
                sqlDB.AddInParameter(dbCMD, "ProductManufacturer", SqlDbType.NVarChar, model_Products.Product.ProductManufacturer);
                sqlDB.AddInParameter(dbCMD, "ProductVariant", SqlDbType.NVarChar, model_Products.ProductDetail.ProductVarient);
                sqlDB.AddInParameter(dbCMD, "ProductColor", SqlDbType.NVarChar, model_Products.ProductDetail.ProductColor);
                sqlDB.AddInParameter(dbCMD, "ProductDes", SqlDbType.NVarChar, model_Products.ProductDetail.ProductDes);
                sqlDB.AddInParameter(dbCMD, "ProductCost", SqlDbType.Decimal, model_Products.ProductDetail.ProductCost);
                sqlDB.AddInParameter(dbCMD, "ProductSalePrice", SqlDbType.Decimal, model_Products.ProductDetail.ProductSalePrice);
                sqlDB.AddInParameter(dbCMD, "ProductImage", SqlDbType.NVarChar, model_Products.ProductDetail.PhotoPath);

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

        #region Select by PK
        public DataTable pr_Products_SelectByPK(string conn,int? ProductId)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Products_SelectByPK");
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

        #region Method: PR_Products_Delete
        public bool? PR_Products_Delete(string conn, int? ProductId)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Products_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "ProductId", SqlDbType.Int, ProductId);
                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion
    }
}
