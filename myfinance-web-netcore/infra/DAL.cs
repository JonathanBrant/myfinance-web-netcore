using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace myfinance_web_netcore.Infra
{
    public class DAL
    {
        private SqlConnection? conn;

        private string connectionString;

        public static IConfiguration? Configuration;

        private static DAL? Instancia;

        //DesignerPartiner singleton
        public static DAL GetInstancia
        {

            get
            {
                if (Instancia == null)
                    Instancia = new();

                return Instancia;
            }
        }

        public DAL()
        {
            //ConnectionString - o valor esta no arquivio appsetings.json

            connectionString = Configuration.GetValue<string>("ConfigurationString");
        }

        public void Conectar()
        {
            try
            {
                Console.WriteLine("Iniciando conexão com o BD");
                conn = new();
                conn.ConnectionString = connectionString;
                conn.Open();
                Console.WriteLine("Banco conectado");
            }
            catch (Exception ex)
            {
                Console.WriteLine("falha na abertura do banco de dados = " + ex.ToString());
            }
        }
    }
}