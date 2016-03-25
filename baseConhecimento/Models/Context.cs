using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using baseConhecimento.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace baseConhecimento.Models
{
    public class Context
    {
        MySqlConnection conn;
        /*public Context()
        {
            //conn = new SqlConnection(
            //"Data Source=localhost;user id=spina;password=Rflsd@745;database=base");
        }*/

        List<Item> itens = new List<Item>();
        List<problema> problemas = new List<problema>();
        public List<Item> retornadados_item()
        {
            MySqlConnection conectado = conecta();
            MySqlDataReader reader = null;
            MySqlCommand comm = new MySqlCommand("SELECT * FROM `ic` order by ranking desc", conectado);
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                itens.Add(new Item()
                {
                    id_ic = Convert.ToInt32(reader["id_ic"].ToString()),
                    nome = reader["nome"].ToString(),
                    descricao = reader["descricao"].ToString(),
                    ranking = 1,
                    imagem = reader["imagem"].ToString(),

                });
            }
            reader.Close();
            conectado.Close();
            return (itens);
        }

        public List<problema> retornadados_problema()
        {
            MySqlConnection conectado = conecta();
            MySqlDataReader reader = null;
            MySqlCommand comm = new MySqlCommand("SELECT * FROM `itens` order by ranking desc", conectado);
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                problemas.Add(new problema()
                {
                    id_itens = Convert.ToInt32(reader["id_itens"].ToString()),
                    nome = reader["nome"].ToString(),
                    descricao = reader["descricao"].ToString(),
                    ranking = Convert.ToInt32(reader["ranking"].ToString()),
                    imagem = reader["imagem"].ToString(),
                    id_ic = Convert.ToInt32(reader["id_ic"].ToString()),
                });
            }
            reader.Close();
            conectado.Close();
            return (problemas);
        }


        public void inseredados(Item itens)
        {
            MySqlConnection conectado = conecta();
            //MySqlDataReader reader = null;
            MySqlCommand comm = new MySqlCommand("Insert Into `ic` (nome, descricao, imagem) values('"+ itens.nome + "','"+ itens.descricao + "','"+ itens.imagem+"')", conectado);
            comm.ExecuteNonQuery();
            conectado.Close();
        }

        public Item retornavalor(int id)
        {
            Item item = new Item();
            MySqlConnection conectado = conecta();
            MySqlCommand comm = new MySqlCommand("SELECT * FROM ic WHERE id_ic ="+id, conectado);
            //comm.ExecuteReader();
            MySqlDataReader reader = comm.ExecuteReader();
            //reader = comm.ExecuteReader();
            while(reader.Read())
            {
                item.id_ic = Convert.ToInt32(reader["id_ic"].ToString());
                item.nome = reader["nome"].ToString();
                item.descricao = reader["descricao"].ToString();
                item.imagem = reader["imagem"].ToString();
            }
            reader.Close();
            conectado.Close();
            return (item);
        }

        public void alteradados(Item item)
        {
            MySqlConnection conectado = conecta();
            //update ic SET nome = 'Rene', descricao = 'Spina', imagem = 'Teste' where id_ic = 3
            MySqlCommand comm = new MySqlCommand("UPDATE `ic` SET nome = '"+item.nome+"', descricao = '"+item.descricao+"', imagem = '"+item.imagem+"' where id_ic = '"+item.id_ic+"'", conectado);
            comm.ExecuteNonQuery();
            conectado.Close();
            //comm.ExecuteReader();
        }

        public MySqlConnection conecta()
        {
            string conexao = ConfigurationManager.ConnectionStrings["Context"].ConnectionString;
            conn = new MySqlConnection(conexao);
            conn.Open();
            return (conn);
        }

        public void deletadados(int id)
        {
            MySqlConnection conectado = conecta();
            //update ic SET nome = 'Rene', descricao = 'Spina', imagem = 'Teste' where id_ic = 3
            MySqlCommand comm = new MySqlCommand("DELETE FROM `ic` WHERE id_ic = '" + id + "'", conectado);
            comm.ExecuteNonQuery();
            conectado.Close();
        }

        public void somaranking(int id)
        {
            MySqlConnection conectado = conecta();
            //update ic SET nome = 'Rene', descricao = 'Spina', imagem = 'Teste' where id_ic = 3
            MySqlCommand retornaRanking = new MySqlCommand("SELECT * FROM ic WHERE id_ic =" + id, conectado);
            MySqlDataReader reader = retornaRanking.ExecuteReader();
            var ranking = 0;
            while (reader.Read())
            {
                if(reader["ranking"].ToString() == "")
                {
                    ranking = 1;
                }
                else
                {
                    ranking = Convert.ToInt32(reader["ranking"].ToString());
                    ranking = ++ranking;

                }
            }
            reader.Close();
            MySqlCommand comm = new MySqlCommand("UPDATE `ic` SET ranking = '" + ranking + "' where id_ic = '" + id + "'", conectado);
            comm.ExecuteNonQuery();
            conectado.Close();
            reader.Close();
        }

    }
}