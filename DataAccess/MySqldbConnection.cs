using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.dataAccess
{
    public class MySqldbConnection
    {
        private readonly string _connectionString;

        public MySqldbConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable ExecuteQuery(string query)
        {
            using (var connection = new MySqlConnection(_connectionString))
            using (var command = new MySqlCommand(query, connection))
            using (var adapter = new MySqlDataAdapter(command))
            {
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameter)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                using (var command = new MySqlCommand(query, connection))

                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameter != null && parameter.Count > 0)
                    {
                        foreach (var item in parameter)
                            command.Parameters.AddWithValue(item.Key, item.Value);
                    }
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        public DataSet ExecuteQueryReturnAsDataSet(string query)
        {
            using (var connection = new MySqlConnection(_connectionString))
            using (var command = new MySqlCommand(query, connection))
            using (var adapter = new MySqlDataAdapter(command))
            {
                var dataset = new DataSet();
                adapter.Fill(dataset);
                return dataset;
            }
        }
        public int ExecuteNonQuery(string query)
        {
            using (var connection = new MySqlConnection(_connectionString))
            using (var command = new MySqlCommand(query, connection))
            {
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(string query)
        {
            using (var connection = new MySqlConnection(_connectionString))
            using (var command = new MySqlCommand(query, connection))
            {
                connection.Open();
                return command.ExecuteScalar();
            }
        }

    }
}
