using Npgsql;

namespace APIC.Model
{
    public class ConexaoDB
    {
        public static NpgsqlConnection Conectar()
        {
            var conexao = new NpgsqlConnection("Host = localhost; Username = postgres; Password = carlos1610 ; Database = dbstore");
            try
            {
                conexao.Open();
            }
            catch ( System.Exception)
            {

            }
            return conexao;
        }
    }
}