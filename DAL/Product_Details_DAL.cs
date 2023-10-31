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
