using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_tier_archi.entities
{
    public class StoresDAL
    {
        private static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\pc\\source\\repos\\assignment1_archi\\assignment1_archi\\bin\\Debug\\Assignment.accdb";

        private static OleDbConnection conn = new OleDbConnection(connectionString);
        public static void InsertCommand(Stores store)
        {
            string commandText = string.Format("Insert into Stores(StoreID,StoreName,StorePhone)" +
            "values('{0}','{1}','{2}')", store.StoreID, store.StoreName, store.StorePhone);

            OleDbCommand command = new OleDbCommand(commandText, conn);

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
        public static void UpdateCommand(Stores store)
        {
            string updateCommand = string.Format("Update Stores Set StoreID = '{1}', StoreName = '{2}',StorePhone = '{3}'" +
                " where StId = {0}", store.StId, store.StoreID, store.StoreName, store.StorePhone);

            OleDbCommand command = new OleDbCommand(updateCommand, conn);

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteCommand(Stores store)
        {
            string commandText = string.Format("Delete from Stores where StId = {0}"
                , store.StId);

            OleDbCommand command = new OleDbCommand(commandText, conn);

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
        public static DataTable GetAllCommand()
        {
            string commandText = string.Format("Select * from Stores");

            OleDbCommand command = new OleDbCommand(commandText, conn);

            OleDbDataAdapter da = new OleDbDataAdapter(command);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }
    }

}

