using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Infra;

namespace myfinance_web_netcore.Models
{
    public class PlanoContaModel
    {

         public void Inserir ()
        {
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();
            var sql = $"INSERT INTO PLANO_CONTAS (DESCRICAO, TIPO) VALUES ('{Descricao}','{Tipo}')";
            objDAL.ExecutarComandoSQL(sql);
            objDAL.Desconectar();
        }

       public int Id{get; set; }
       public string? Descricao{get; set; } 
       public string? Tipo {get; set; }

       public List<PlanoContaModel> ListaPlanoContas() 
       {
        List<PlanoContaModel> lista = new List<PlanoContaModel>();
        var objDAL = DAL.GetInstancia;
        objDAL.Conectar();

        var sql = "SELECT ID, DESCRICAO, TIPO FROM PLANO_CONTAS";
        var dataTable = objDAL.RetornarDataTable(sql);

        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            var planoConta = new PlanoContaModel() {
                Id = int.Parse(dataTable.Rows[i]["ID"].ToString()),
                Descricao = dataTable.Rows[i]["DESCRICAO"].ToString(),
                Tipo = dataTable.Rows[i]["TIPO"].ToString()
            };

            lista.Add(planoConta);
        }

        objDAL.Desconectar();
        return lista;
       }
    }
}