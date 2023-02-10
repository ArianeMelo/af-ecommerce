using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AF.ECommerce.Domain.Interfaces.Repository
{
    public interface IUnityOfWork 
    {
        string ConnectionString { get; }
        SqlConnection Connection { get; }
        SqlTransaction Transaction { get; set; }
        SqlConnection GetConnection();
        void IniciarTransacao();
        void CommittarTransacao();
        void RollbackTransacao();
        void FinalizarConnexao();

    }
}
