using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebSiteTestAdmissao.Model;

namespace WebSiteTestAdmissao
{
    public class UserRepository : AbstractRepository<Usuario, int>
    {
        public override void Delete(Usuario entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE USERS Where Codigo=@Codigo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Codigo", entity.Codigo);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        ///<summary>Exclui uma Usuario pelo ID
        ///<param name="id">Id do registro que será excluído.</param>
        ///</summary>
        public override void DeleteById(int codigo)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE USERS Where Codigo=@Codigo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        ///<summary>Obtém todas as Users
        ///<returns>Retorna as Users cadastradas.</returns>
        ///</summary>
        public override List<Usuario> GetAll()
        {
            string sql = "Select Codigo, Nome, Senha FROM USERS ORDER BY Nome";
            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Usuario> list = new List<Usuario>();
                Usuario p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            p = new Usuario();
                            p.Codigo = (int)reader["Codigo"];
                            p.Nome = reader["Nome"].ToString();
                            p.Senha = reader["Senha"].ToString();
                            list.Add(p);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return list;
            }
        }

        ///<summary>Obtém uma Usuario pelo ID
        ///<param name="codigo">Id do registro que obtido.</param>
        ///<returns>Retorna uma referência de Usuario do registro encontrado ou null se ele não for encontrado.</returns>
        ///</summary>
        public override Usuario GetById(int codigo)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "Select Codigo, Nome, Senha FROM USERS WHERE Codigo=@Codigo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                Usuario p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                p = new Usuario();
                                p.Codigo = (int)reader["Codigo"];
                                p.Nome = reader["Nome"].ToString();
                                p.Senha = reader["Senha"].ToString();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return p;
            }
        }
        public  Usuario LoginUser(string nome, string senha)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "Select Codigo, Nome, Senha FROM USERS WHERE Nome=@Nome and Senha=@Senha";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Senha", senha);
                Usuario p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                p = new Usuario();
                                p.Codigo = (int)reader["Codigo"];
                                p.Nome = reader["Nome"].ToString();
                                p.Senha = reader["Senha"].ToString();

                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return p;
            }
        }

        ///<summary>Salva a Usuario no banco
        ///<param name="entity">Referência de Usuario que será salva.</param>
        ///</summary>
        public override void Save(Usuario entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "INSERT INTO USERS (Nome, Senha) VALUES (@Nome, @Senha)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@Senha", entity.Senha);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        ///<summary>Atualiza a Usuario no banco
        ///<param name="entity">Referência de Usuario que será atualizada.</param>
        ///</summary>
        public override void Update(Usuario entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "UPDATE USERS SET Nome=@Nome, Senha=@Senha Where Codigo=@Codigo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Codigo", entity.Codigo);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@Senha", entity.Senha);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}