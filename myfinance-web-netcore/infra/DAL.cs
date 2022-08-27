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
                Console.WriteLine("Conexão comm BD realizada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na conexão com o BD: " + ex.ToString());
            }
        }

        public void Desconectar() {
            conn.Close();
        }

        public DataTable RetornarDataTable(string sql) 
        {
            var dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dataTable);
            return dataTable;
        }

        public void ExecutarComandoSQL(string sql) 
        {
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.ExecuteNonQuery();
        }

    }
}