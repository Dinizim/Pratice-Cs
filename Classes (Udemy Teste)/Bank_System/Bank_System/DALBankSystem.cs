using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Security.Principal;

namespace Bank_System
{
    internal class DALBankSystem
    {
        public static string path = Directory.GetCurrentDirectory() + "\\banco.sqlite";
        private static SQLiteConnection sqliteconnection;


        //metodo  para fazer a conexão
        private static SQLiteConnection DbConnection()
        {
            sqliteconnection = new SQLiteConnection("Data Source=" + path);
            sqliteconnection.Open();
            return sqliteconnection;
            //caso nao exista o bd o metodo abaixo vai resolver isso
        }
        public static void CriarBancoSQLite()
        {
            try
            {
                //caso o bd nao existe ira criar um
                if(File.Exists(path) == false)
                {
                    SQLiteConnection.CreateFile(path);

                }
            }
            catch
            {
                throw;
            }
        }
        public static void CriarTabelaSQLite()
        {
            try
            {
                //criar tabela caso ela n exista
                using(var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Account(name Varchar(50),cpf Varchar(11), saldo int, AcessKEY Varchar(5), dd_mm_aa int)";
                    cmd.ExecuteNonQuery();
                }

            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetAccount(string cpf)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                //pega apenas todos os dados do banco de dados
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Account Where cpf=" + cpf;
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetAccounts()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                //pega apenas um dado do banco de dados
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Account";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static void Add(Client account)
        {
            try
            {
                //add um dado ao banco de dados
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Account(name, cpf, saldo, AcessKEY, dd_mm_aa) values (@name, @cpf, @saldo, @AcessKEY, @dd_mm_aa )";
                    cmd.Parameters.AddWithValue("@name", account.name);
                    cmd.Parameters.AddWithValue("@cpf", account.cpf);
                    cmd.Parameters.AddWithValue("@saldo", account.saldo);
                    cmd.Parameters.AddWithValue("@AcessKEY", account.aceess_key);
                    cmd.Parameters.AddWithValue("@dd_mm_aa", account.dd_mm_aa);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Update(Client account)
        {
            try
            {
                //atualiza um dado ao banco de dados
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "UPDATE Account SET name=@name, saldo=@saldo, AcessKEY=@AcessKEY, dd_mm_aa=@dd_mm_aa WHERE cpf=@cpf";
                    cmd.Parameters.AddWithValue("@name", account.name);
                    cmd.Parameters.AddWithValue("@cpf", account.cpf);
                    cmd.Parameters.AddWithValue("@saldo", account.saldo);
                    cmd.Parameters.AddWithValue("@AcessKEY", account.aceess_key);
                    cmd.Parameters.AddWithValue("@dd_mm_aa", account.dd_mm_aa);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Delete(string cpf)
        {
            try
            {
                //deleta um dado ao banco de dados
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Account WHERE cpf=@cpf";
                    cmd.Parameters.AddWithValue("@cpf", cpf);                   
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
