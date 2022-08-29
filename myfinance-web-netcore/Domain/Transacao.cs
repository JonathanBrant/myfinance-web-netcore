using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Models;

using myfinance_web_netcore.Infra;

namespace myfinance_web_netcore.Domain
{
    public class Transacao
    {

            public void Deletar(int id)
        {
            var objDAL = DAL.GetInstancia;
            objDAL.Conectar();
            string sql = $"DELETE FROM TRANSACAO WHERE ID = {id}";
            objDAL.ExecutarComandoSQL(sql);
            objDAL.Desconectar();
        }

            public void Atualizar (TransacaoModel formulario)            
        {
            var valor = decimal.Parse(formulario.Valor.ToString())/100;
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();
            var sql = $"UPDATE TRANSACAO SET DATA = '{formulario.Data.ToString("yyyyMMdd")}'," +
                $"VALOR = {valor}, TIPO = '{formulario.Tipo}', HISTORICO = '{formulario.Historico}', " +
                $"ID_PLANO_CONTA = {formulario.IdPlanoConta}, " +
                $"ID_PAGAMENTO = {formulario.IdPagamento} WHERE ID = {formulario.Id}";

                Console.WriteLine("Comando SQL: " + sql.ToString());

            objDAL.ExecutarComandoSQL(sql);
            objDAL.Desconectar();
        }
        public void Inserir(TransacaoModel formulario)
        {
            var objDAL = DAL.GetInstancia;
            objDAL.Conectar();

            var sql = "INSERT INTO TRANSACAO(data, valor, tipo, historico, id_plano_conta, id_pagamento) " +
            "VALUES(" +
            $"'{formulario.Data.ToString("yyyyMMdd")}',"+
            $"{formulario.Valor},"+
            $"'{formulario.Tipo}',"+            
            $"'{formulario.Historico}',"+
            $"{formulario.IdPlanoConta},"+
            $"{formulario.IdPagamento})";

            Console.WriteLine("Comando SQL: " + sql.ToString());

            objDAL.ExecutarComandoSQL(sql);
            objDAL.Desconectar();
        }

            public TransacaoModel CarregarTransacaoPorId(int? id)
        {
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();

            var sql = $"SELECT ID, DATA, VALOR,TIPO, HISTORICO, ID_PLANO_CONTA, ID_PAGAMENTO FROM TRANSACAO where id = {id}";
            var dataTable = objDAL.RetornarDataTable(sql);

                
    		var transacao = new TransacaoModel(){
                    Id = int.Parse (dataTable.Rows[0]["ID"].ToString()),
                    Historico = dataTable.Rows[0]["HISTORICO"].ToString(),
                    Tipo = dataTable.Rows[0]["TIPO"].ToString(),
                    Data = DateTime.Parse(dataTable.Rows[0]["DATA"].ToString()),
                    Valor = decimal.Parse(dataTable.Rows[0]["VALOR"].ToString()),  
                    IdPlanoConta = int.Parse(dataTable.Rows[0]["ID_PLANO_CONTA"].ToString()), 
                    IdPagamento = int.Parse(dataTable.Rows[0]["ID_PAGAMENTO"].ToString())                           
                };

                 Console.WriteLine("Comando SQL: " + sql.ToString() +  " " + transacao.Valor +  " " + transacao.Tipo +  " " + transacao.Historico +  " " + transacao.IdPlanoConta +  " " + transacao.IdPagamento);

            objDAL.Desconectar();
            return transacao;
        }

        public List<TransacaoModel> ListaTransacoes()
        {
            List<TransacaoModel> lista = new List<TransacaoModel>();
            var objDAL = DAL.GetInstancia;
            objDAL.Conectar();

            var sql = "SELECT ID, DATA, VALOR,TIPO, HISTORICO, ID_PLANO_CONTA, ID_PAGAMENTO FROM TRANSACAO";
            var dataTable = objDAL.RetornarDataTable(sql);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {

                var transacao = new TransacaoModel()
                {
                    Id = int.Parse(dataTable.Rows[i]["ID"].ToString()),
                    Data = DateTime.Parse(dataTable.Rows[i]["DATA"].ToString()),
                    Valor = decimal.Parse(dataTable.Rows[i]["VALOR"].ToString()),
                    Tipo = dataTable.Rows[i]["TIPO"].ToString(),
                    Historico = dataTable.Rows[i]["HISTORICO"].ToString(),
                    IdPlanoConta = int.Parse(dataTable.Rows[i]["ID_PLANO_CONTA"].ToString()),
                    IdPagamento = int.Parse(dataTable.Rows[i]["ID_PAGAMENTO"].ToString())
                };

                lista.Add(transacao);
            }
            objDAL.Desconectar();

            return lista;
        }
    }
}