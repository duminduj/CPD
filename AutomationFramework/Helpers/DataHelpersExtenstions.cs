using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RACGP_AutomationFramework.Helpers
{
    public static class DataHelpersExtenstions
    {

        //open the connection DB
        public static SqlConnection DBConnect(this SqlConnection sqlConnection, string connectionString)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                return sqlConnection;
            }
            catch(Exception e)
            {
                LogHelpers.Write("Error::" + e.Message);
            }
            return null;

        }

               
        //closing the connection

        public static void DBClose(this SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception e)
            {

                LogHelpers.Write("Error::"+e.Message);
            }
        }

        //execution


        public static DataTable ExecuteQuerry(this SqlConnection sqlConnection,string querryString)
        {

            DataSet dataset;
            try
            {
                if (sqlConnection == null || ((sqlConnection != null && (sqlConnection.State == ConnectionState.Closed ||
                    sqlConnection.State == ConnectionState.Broken))))
                    sqlConnection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand(querryString, sqlConnection);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;

                dataset = new DataSet();
                dataAdapter.Fill(dataset, "table");
                sqlConnection.Close();
                return dataset.Tables["table"];
            }
            catch (Exception e)
            {
                dataset = null;
                sqlConnection.Close();
                LogHelpers.Write("Error::" + e.Message);
                return null;
            }
            finally
            {
                sqlConnection.Close();
                dataset = null;
            }

        }

    }
}
