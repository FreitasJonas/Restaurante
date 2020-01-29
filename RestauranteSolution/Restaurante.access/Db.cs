using MySql.Data.MySqlClient;
using Restaurante.modelos;
using System;
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
    }
}
