using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using myfinance_web_netcore.Infra;

namespace myfinance_web_netcore.Models
{
    public class PagamentoModel
    {
         public int? Id {get; set;}

        public string? Pagamento {get; set;}


            public List<PagamentoModel> ListaPagamento()
        {
            List<PagamentoModel> lista = new List<PagamentoModel>();
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();
            var sql = "select id, pagamento from pagamento";
            var dataTable = objDAL.RetornarDataTable(sql);

            for (int i=0; i< dataTable.Rows.Count; i++)
            {
                
				var pagamento = new PagamentoModel(){
                    Id = int.Parse (dataTable.Rows[i]["id"].ToString()),
                    Pagamento = dataTable.Rows[i]["pagamento"].ToString(),       
                                      
                };
                lista.Add(pagamento);
            }

            return lista;
        }


    }
}