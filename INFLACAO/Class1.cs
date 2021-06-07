using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFLACAO
{
    public class D_CLIENTE
    {
        private int _IdCliente;

        public int IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }

        private string _NomeCliente;

        public string NomeCliente
        {
            get { return _NomeCliente; }
            set { _NomeCliente = value; }
        }

        private string _Nif;

        public string Nif
        {
            get { return _Nif; }
            set { _Nif = value; }
        }

        private string _Local;

        public string Local
        {
            get { return _Local; }
            set { _Local = value; }
        }

        private string _Ntelefone;

        public string Ntelefone
        {
            get { return _Ntelefone; }
            set { _Ntelefone = value; }
        }

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _TextoBuscar;

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }


        // Construtores

        public D_CLIENTE()
        {
        }

        public D_CLIENTE(int idcliente, string nomecliente, string nif, string local, string ntelefone, string email, string textobuscar)
        {
            this.IdCliente = idcliente;
            this.NomeCliente = nomecliente;
            this.Nif = nif;
            this.Local = local;
            this.Ntelefone = ntelefone;
            this.Email = email;
            this.TextoBuscar = textobuscar;
        }

        // Metodo Inserir
        public string Inserir(D_CLIENTE CLIENTE)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Inserir_Cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_Cliente = new SqlParameter();
                ParId_Cliente.ParameterName = "@ID_CLIENTE";
                ParId_Cliente.SqlDbType = SqlDbType.Int;
                ParId_Cliente.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParId_Cliente);

                SqlParameter ParNome_Cliente = new SqlParameter();
                ParNome_Cliente.ParameterName = "@NOME_CLIENTE";
                ParNome_Cliente.SqlDbType = SqlDbType.VarChar;
                ParNome_Cliente.Size = 50;
                ParNome_Cliente.Value = CLIENTE.NomeCliente;
                SqlCmd.Parameters.Add(ParNome_Cliente);

                SqlParameter ParNif = new SqlParameter();
                ParNif.ParameterName = "@NIF";
                ParNif.SqlDbType = SqlDbType.VarChar;
                ParNif.Size = 50;
                ParNif.Value = CLIENTE.Nif;
                SqlCmd.Parameters.Add(ParNif);


                SqlParameter ParLocal = new SqlParameter();
                ParLocal.ParameterName = "@LOCAL";
                ParLocal.SqlDbType = SqlDbType.VarChar;
                ParLocal.Size = 50;
                ParLocal.Value = CLIENTE.Local;
                SqlCmd.Parameters.Add(ParLocal);

                SqlParameter ParNtelefone = new SqlParameter();
                ParNtelefone.ParameterName = "@N_TELEFONE";
                ParNtelefone.SqlDbType = SqlDbType.VarChar;
                ParNtelefone.Size = 50;
                ParNtelefone.Value = CLIENTE.Ntelefone;
                SqlCmd.Parameters.Add(ParNtelefone);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@EMAIL";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = CLIENTE.Email;
                SqlCmd.Parameters.Add(ParEmail);



                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : " Registo não Cadastrado";


            }

            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return rpta;

        }

        // Metodo Editar

        public string Editar(D_CLIENTE CLIENTE)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_Cliente = new SqlParameter();
                ParId_Cliente.ParameterName = "@ID_CLIENTE";
                ParId_Cliente.SqlDbType = SqlDbType.VarChar;
                ParId_Cliente.Size = 50;
                ParId_Cliente.Value = CLIENTE.IdCliente;
                SqlCmd.Parameters.Add(ParId_Cliente);

                SqlParameter ParNome_Cliente = new SqlParameter();
                ParNome_Cliente.ParameterName = "@NOME_CLIENTE";
                ParNome_Cliente.SqlDbType = SqlDbType.VarChar;
                ParNome_Cliente.Size = 50;
                ParNome_Cliente.Value = CLIENTE.NomeCliente;
                SqlCmd.Parameters.Add(ParNome_Cliente);

                SqlParameter ParNif = new SqlParameter();
                ParNif.ParameterName = "@NIF";
                ParNif.SqlDbType = SqlDbType.VarChar;
                ParNif.Size = 50;
                ParNif.Value = CLIENTE.Nif;
                SqlCmd.Parameters.Add(ParNif);


                SqlParameter ParLocal = new SqlParameter();
                ParLocal.ParameterName = "@LOCAL";
                ParLocal.SqlDbType = SqlDbType.VarChar;
                ParLocal.Size = 50;
                ParLocal.Value = CLIENTE.Local;
                SqlCmd.Parameters.Add(ParLocal);

                SqlParameter ParNtelefone = new SqlParameter();
                ParNtelefone.ParameterName = "@N_TELEFONE";
                ParNtelefone.SqlDbType = SqlDbType.VarChar;
                ParNtelefone.Size = 50;
                ParNtelefone.Value = CLIENTE.Ntelefone;
                SqlCmd.Parameters.Add(ParNtelefone);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@EMAIL";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = CLIENTE.Email;
                SqlCmd.Parameters.Add(ParEmail);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : " Registo não Actualizado";


            }

            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return rpta;
        }

        // Metodo Eliminar
        public string Eliminar(D_CLIENTE CLIENTE)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[speliminar_cliente]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_Pacote = new SqlParameter();
                ParId_Pacote.ParameterName = "@ID_CLIENTE";
                ParId_Pacote.SqlDbType = SqlDbType.Int;
                ParId_Pacote.Value = CLIENTE.IdCliente;
                SqlCmd.Parameters.Add(ParId_Pacote);
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : " Registo não Eliminado";

            }

            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return rpta;
        }

        // Metodo Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Cliente - Empresa");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spmostrar_cliente]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }

            catch (Exception ex)
            { DtResultado = null; }
            return DtResultado;
        }

        // Metodo Buscar
        public DataTable BuscarCliente(D_CLIENTE CLIENTE)
        {
            DataTable DtResultado = new DataTable("Cliente - Empresa");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spbuscar_nome_cliente]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = CLIENTE.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }

            catch (Exception ex)
            { DtResultado = null; }
            return DtResultado;
        }
    }
}
