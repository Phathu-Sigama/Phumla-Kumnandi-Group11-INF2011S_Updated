using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumla_Kumnandi_Group11_INF2011S.Data
{
    public class DB
    {
        #region Data Members
        private string strConn = Properties.Settings.Default.PhumlaKamnandiHotelsConnectionString;
        protected SqlConnection cnMain;
        protected DataSet dsMain;
        protected SqlDataAdapter daMain;
        #endregion

        #region Constructor
        public DB()
        {
            try
            {
                // Use |DataDirectory| for portability
                strConn = @"Data Source=(LocalDB)\MSSQLLocalDB;
                    AttachDbFilename=|DataDirectory|\PhumlaKamnandiHotels.mdf;
                    Integrated Security=True;
                    Connect Timeout=30";

                cnMain = new SqlConnection(strConn);
                dsMain = new DataSet();

                // Test connection
                cnMain.Open();
                cnMain.Close();
            }
            catch (Exception errObj)
            {
                MessageBox.Show("Database connection error: " + errObj.Message + " " + errObj.StackTrace);
            }
        }

        #endregion

        // Fill dataset from database
        #region Utility Methods
        public void FillDataSet(string aSQLstring, string aTable)
        {
            try
            {
                daMain = new SqlDataAdapter(aSQLstring, cnMain);

                cnMain.Open();
                dsMain.Clear();

                // Fill the data adapter
                daMain.Fill(dsMain, aTable);

                cnMain.Close();
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + " " + errObj.StackTrace);
            }
        }
        #endregion

        #region Update the data source
        protected bool UpdateDataSource(string sqlLocal, string table)
        {
            bool success = false;

            try
            {
                cnMain.Open();

                // Update database table using data adapter
                daMain.Update(dsMain, table);

                cnMain.Close();

                // Fill dataset with SQL statement
                FillDataSet(sqlLocal, table);

                success = true;
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + " " + errObj.StackTrace);
                success = false;
            }
            finally
            {
                // Ensure connection is closed if still open
                if (cnMain.State == ConnectionState.Open)
                {
                    cnMain.Close();
                }
            }

            return success;
        }
        #endregion
    }
}