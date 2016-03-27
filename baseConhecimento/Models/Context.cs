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

        public List<problema> retornadados_problemas()
        {
            MySqlConnection conectado = conecta();
            MySqlDataReader reader = null;
            MySqlCommand comm = new MySqlCommand("SELECT * FROM `problema` order by ranking desc", conectado);
            List<Item> itens = new List<Item>();
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                problemas.Add(new problema()
                {
                    id_problema = Convert.ToInt32(reader["id_problema"].ToString()),
                    nome = reader["nome"].ToString(),
                    descricao = reader["descricao"].ToString(),
                    ranking = Convert.ToInt32(reader["ranking"].ToString()),
                    imagem = reader["imagem"].ToString(),
                    id_ic = Convert.ToInt32(reader["id_ic"].ToString()),
                    item = retornadados_item(),
                });
            }

            reader.Close();
            conectado.Close();
            return (problemas);
        }


        public void inseredados_itens(Item itens)
        {
            MySqlConnection conectado = conecta();
            //MySqlDataReader reader = null;
            MySqlCommand comm = new MySqlCommand("Insert Into `ic` (nome, descricao, imagem) values('"+ itens.nome + "','"+ itens.descricao + "','"+ itens.imagem+"')", conectado);
            comm.ExecuteNonQuery();
            conectado.Close();
        }

        public void inseredados_problemas(problema problemas)
        {
            MySqlConnection conectado = conecta();
            //MySqlDataReader reader = null;
            MySqlCommand comm = new MySqlCommand("Insert Into `problema` (nome, descricao, imagem, id_ic) values('" + problemas.nome + "','" + problemas.descricao + "','" + problemas.imagem + "','" + problemas.id_ic + "')", conectado);
            comm.ExecuteNonQuery();
            conectado.Close();
        }




        public Item retornavalor_itens(int id)
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

        public problema retornavalor_problemas(int id)
        {
            problema problema = new problema();
            MySqlConnection conectado = conecta();
            MySqlCommand comm = new MySqlCommand("SELECT * FROM problema WHERE id_problema =" + id, conectado);
            //comm.ExecuteReader();
            MySqlDataReader reader = comm.ExecuteReader();
            //reader = comm.ExecuteReader();
            while (reader.Read())
            {
                problema.id_problema = Convert.ToInt32(reader["id_problema"].ToString());
                problema.nome = reader["nome"].ToString();
                problema.descricao = reader["descricao"].ToString();
                problema.imagem = reader["imagem"].ToString();
                problema.id_ic = Convert.ToInt32(reader["id_ic"].ToString());
            }
            reader.Close();
            conectado.Close();
            return (problema);
        }

        public void alteradados_itens(Item item)
        {
            MySqlConnection conectado = conecta();
            //update ic SET nome = 'Rene', descricao = 'Spina', imagem = 'Teste' where id_ic = 3
            MySqlCommand comm = new MySqlCommand("UPDATE `ic` SET nome = '"+item.nome+"', descricao = '"+item.descricao+"', imagem = '"+item.imagem+"' where id_ic = '"+item.id_ic+"'", conectado);
            comm.ExecuteNonQuery();
            conectado.Close();
            //comm.ExecuteReader();
        }

        public void alteradados_problemas(problema problema)
        {
            MySqlConnection conectado = conecta();
            //update ic SET nome = 'Rene', descricao = 'Spina', imagem = 'Teste' where id_ic = 3
            MySqlCommand comm = new MySqlCommand("UPDATE `problema` SET nome = '" + problema.nome + "', descricao = '" + problema.descricao + "', imagem = '" + problema.imagem + "', id_ic = '" + problema.id_ic + "' where id_problema = '" + problema.id_problema + "'", conectado);
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

        public void deletadados_itens(int id)
        {
            MySqlConnection conectado = conecta();
            //update ic SET nome = 'Rene', descricao = 'Spina', imagem = 'Teste' where id_ic = 3
            MySqlCommand comm = new MySqlCommand("DELETE FROM `ic` WHERE id_ic = '" + id + "'", conectado);
            comm.ExecuteNonQuery();
            conectado.Close();
        }

        public void deletadados_problemas(int id)
        {
            MySqlConnection conectado = conecta();
            //update ic SET nome = 'Rene', descricao = 'Spina', imagem = 'Teste' where id_ic = 3
            MySqlCommand comm = new MySqlCommand("DELETE FROM `problema` WHERE id_problema = '" + id + "'", conectado);
            comm.ExecuteNonQuery();
            conectado.Close();
        }

        public void somaranking_itens(int id)
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

        public void somaranking_problemas(int id)
        {
            MySqlConnection conectado = conecta();
            //update ic SET nome = 'Rene', descricao = 'Spina', imagem = 'Teste' where id_ic = 3
            MySqlCommand retornaRanking = new MySqlCommand("SELECT * FROM problema WHERE id_problema =" + id, conectado);
            MySqlDataReader reader = retornaRanking.ExecuteReader();
            var ranking = 0;
            while (reader.Read())
            {
                if (reader["ranking"].ToString() == "")
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
            MySqlCommand comm = new MySqlCommand("UPDATE `problema` SET ranking = '" + ranking + "' where id_problema = '" + id + "'", conectado);
            comm.ExecuteNonQuery();
            conectado.Close();
            reader.Close();
        }
    }
}