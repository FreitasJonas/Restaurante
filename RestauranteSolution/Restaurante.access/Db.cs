using MySql.Data.MySqlClient;
using Restaurante.modelos;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Restaurante.access
{
    public class Db : IDao
    {
        protected MySqlConnection Conn;
        protected MySqlCommand Cmd;
        protected MySqlDataReader Reader;
        protected MySqlDataAdapter Adapter;
        protected MySqlTransaction Trans;

        public Db()
        {
            var connection = ConfigurationManager.ConnectionStrings["RestauranteConnection"].ConnectionString;
            Conn = new MySqlConnection(connection);
            Cmd = new MySqlCommand();

            Cmd.Connection = Conn;
            Cmd.CommandType = System.Data.CommandType.Text;
        }


        public void AbreDb()
        {
            if (Conn.State != System.Data.ConnectionState.Open)
            {
                Conn.Open();
            }
            else
            {
                FechaDb();
                Conn.Open();
            }
        }

        public void FechaDb()
        {
            if (Conn.State == System.Data.ConnectionState.Open)
            {
                Conn.Close();
                Cmd.Parameters.Clear();
            }
        }

        public Usuario ValidaUsuario(string login, string senha)
        {
            try
            {
                Cmd.CommandText = "select id_usuario, mn_nome, nm_login, nm_senha, nr_tel, nm_email, perfil, dt_cadastro, ultimo_acesso from usuarios where nm_login = @login and nm_senha = @senha;";
                Cmd.Parameters.AddWithValue("login", login);
                Cmd.Parameters.AddWithValue("senha", senha);

                AbreDb();

                Reader = Cmd.ExecuteReader();

                if (Reader.Read())
                {
                    var usr = new Usuario();

                    usr.UsuarioId = Reader.GetInt32(0);
                    usr.UsuarioNome = Reader.GetString(1);
                    usr.UsuarioLogin = Reader.GetString(2);

                    usr.UsuarioTelefone = Reader.GetString(4);
                    usr.UsuarioEmail = Reader.GetString(5);
                    usr.UsuarioPerfil = Reader.GetInt32(6);
                    usr.UsuarioCadastro = Reader.GetDateTime(7);
                    usr.UsuarioUltimoAcesso = Reader.GetDateTime(8);

                    return usr;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("[ValidaUsuario] [" + login + "] " + e.Message);
            }
            finally
            {
                FechaDb();
            }
        }

        public List<Porcao> ListarPorcoes()
        {
            try
            {
                var porcoes = new List<Porcao>();

                Cmd.CommandText = "select id_porcao, nm_nome, nr_peso, nr_valor, nm_desc, nm_imagem, dt_cadastro from porcoes;";

                AbreDb();

                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    var porcao = new Porcao();

                    porcao.PorcaoId = Reader.GetInt32(0);
                    porcao.Nome = Reader.GetString(1);
                    porcao.Peso = Reader.GetDouble(2);
                    porcao.Valor = Reader.GetDouble(3);
                    porcao.Descricao = Reader.GetString(4);
                    porcao.Imagem = Reader.GetString(5);
                    porcao.Cadastro = Reader.GetDateTime(6);

                    porcoes.Add(porcao);
                }

                return porcoes;
            }
            catch (Exception e)
            {
                throw new Exception("[ListarPorcoes] " +  e.Message);
            }
            finally
            {
                FechaDb();
            }
        }

        public Porcao PegaPorcao(int porcaoId)
        {
            try
            {
                Porcao porcao = null;

                Cmd.CommandText = "select id_porcao, nm_nome, nr_peso, nr_valor, nm_desc, nm_imagem, dt_cadastro from porcoes where id_porcao = @id_porcao;";
                Cmd.Parameters.AddWithValue("id_porcao", porcaoId);

                AbreDb();

                Reader = Cmd.ExecuteReader();

                if (Reader.Read())
                {
                    porcao = new Porcao();

                    porcao.PorcaoId = Reader.GetInt32(0);
                    porcao.Nome = Reader.GetString(1);
                    porcao.Peso = Reader.GetDouble(2);
                    porcao.Valor = Reader.GetDouble(3);
                    porcao.Descricao = Reader.GetString(4);
                    porcao.Imagem = Reader.GetString(5);
                    porcao.Cadastro = Reader.GetDateTime(6);
                }

                return porcao;
            }
            catch (Exception e)
            {
                throw new Exception("[PegaPorcao] " + e.Message);
            }
            finally
            {
                FechaDb();
            }
        }

        public int AtualizaPorcao(Porcao porcao)
        {
            try
            {
                Cmd.CommandText = @"update porcoes set 
                                    nr_peso = @nr_peso,
                                    nr_valor = @nr_valor, 
                                    nm_desc = @nm_desc, 
                                    nm_imagem = @nm_imagem where id_porcao = @id_porcao;";

                Cmd.Parameters.AddWithValue("nr_peso", porcao.Peso);
                Cmd.Parameters.AddWithValue("nr_valor", porcao.Valor);
                Cmd.Parameters.AddWithValue("nm_desc", porcao.Descricao);
                Cmd.Parameters.AddWithValue("nm_imagem", porcao.Imagem);
                Cmd.Parameters.AddWithValue("id_porcao", porcao.PorcaoId);

                AbreDb();

                return Cmd.ExecuteNonQuery();               
            }
            catch (Exception e)
            {
                throw new Exception("[PegaPorcao] " + e.Message);
            }
            finally
            {
                FechaDb();
            }
        }
    }
}
