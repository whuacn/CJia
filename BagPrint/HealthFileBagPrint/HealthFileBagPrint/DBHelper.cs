namespace HealthFileBagPrint
{
    using System;
    using System.Data;
    using System.Data.OleDb;

    public class DBHelper : IDisposable
    {
        private OleDbConnection cnn = new OleDbConnection(strcnn);
        private static string strcnn = ConfigurationSettings.AppSettings["DBConnectionString"];

        public DBHelper()
        {
            this.cnn.Open();
        }

        public void Dispose()
        {
            if ((this.cnn != null) && (this.cnn.State == ConnectionState.Open))
            {
                this.cnn.Close();
                this.cnn.Dispose();
            }
        }

        public int Execute(string sql)
        {
            using (OleDbCommand command = new OleDbCommand())
            {
                command.Connection = this.cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = sql;
                return command.ExecuteNonQuery();
            }
        }

        public int Execute(string sql, OleDbParameter[] opm)
        {
            using (OleDbCommand command = new OleDbCommand())
            {
                command.Connection = this.cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = sql;
                if ((opm != null) && (opm.Length > 0))
                {
                    command.Parameters.AddRange(opm);
                }
                return command.ExecuteNonQuery();
            }
        }

        public DataTable Query(string sql)
        {
            DataTable table;
            using (OleDbCommand command = new OleDbCommand())
            {
                command.Connection = this.cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = sql;
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    table = dataSet.Tables[0];
                }
            }
            return table;
        }

        public DataTable Query(string sql, OleDbParameter[] opm)
        {
            DataTable table;
            using (OleDbCommand command = new OleDbCommand())
            {
                command.Connection = this.cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = sql;
                if ((opm != null) && (opm.Length > 0))
                {
                    command.Parameters.AddRange(opm);
                }
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    table = dataSet.Tables[0];
                }
            }
            return table;
        }

        public object QueryScalar(string sql)
        {
            using (OleDbCommand command = new OleDbCommand())
            {
                command.Connection = this.cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = sql;
                return command.ExecuteScalar();
            }
        }

        public object QueryScalar(string sql, OleDbParameter[] opm)
        {
            using (OleDbCommand command = new OleDbCommand())
            {
                command.Connection = this.cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = sql;
                if ((opm != null) && (opm.Length > 0))
                {
                    command.Parameters.AddRange(opm);
                }
                return command.ExecuteScalar();
            }
        }
    }
}

