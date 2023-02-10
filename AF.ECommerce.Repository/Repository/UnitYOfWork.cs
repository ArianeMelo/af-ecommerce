using AF.ECommerce.Domain.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AF.ECommerce.Repository.Repository
{
    public class UnitYOfWork : IUnityOfWork
    {
        public string ConnectionString { get; private set; }
        public SqlConnection Connection { get; private set; }
        public SqlTransaction Transaction { get; set; }

        public UnitYOfWork(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultString");            
            GetConnection();
        }
        public SqlConnection GetConnection()
        {
            Connection = new SqlConnection(ConnectionString);
            return Connection;           
        }

        public void IniciarTransacao()
        {
            if (Connection == null) Connection = new SqlConnection(ConnectionString);

            Connection.Open();
            Transaction.Connection.BeginTransaction();
        }

        public void CommittarTransacao()
        {
            if (Connection?.State == System.Data.ConnectionState.Open)
            {
                Transaction.Commit();
                Connection.Close();
            }
        }

        public void RollbackTransacao()
        {
            if (Connection?.State == System.Data.ConnectionState.Open)
            {
                Transaction.Rollback();
                Connection.Close();
            }
        }

        public void FinalizarConnexao()
        {
            if (Connection == null) return;

            if (Connection?.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }
}
