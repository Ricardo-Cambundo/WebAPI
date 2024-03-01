using Npgsql;
namespace APIC.Model
{
    public class Produto
    {
        public int Id {get; set;} = 0;
        public string? Nome { get; set; }
        public string? Categoria { get; set; } 
        public decimal Preco { get; set; } 
        public DateTime DataExpiracao { get; set; } 
        public string? Localizacao { get; set; } 
        public string? Descricao { get; set; } 
        public string? Contato { get; set; } 
        public bool DisponivelOnline { get; set; } 
        public int Avaliacao { get; set; } 

        

        public object AdProduto(Produto pessoa)
        {
            var operacao = string.Empty;
            var conexao = ConexaoDB.Conectar();
            var cmd = new NpgsqlCommand
            {
                Connection = conexao,
                CommandText = "INSERT INTO tbl_produto (nome, categoria, preco, dataExpiracao, localizacao, descricao, contato, disponivelOnline, avaliacao) VALUES (@Nome, @Categoria, @Preco, @DataExpiracao, @Localizacao, @Descricao, @Contato, @DisponivelOnline, @Avaliacao);"
            };
            cmd.Parameters.AddWithValue("@Nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = pessoa.Nome;
            cmd.Parameters.AddWithValue("@Categoria", NpgsqlTypes.NpgsqlDbType.Varchar).Value = pessoa.Categoria;
            cmd.Parameters.AddWithValue("@Preco", NpgsqlTypes.NpgsqlDbType.Numeric).Value = pessoa.Preco;
            cmd.Parameters.AddWithValue("@DataExpiracao", NpgsqlTypes.NpgsqlDbType.Date).Value = pessoa.DataExpiracao;
            cmd.Parameters.AddWithValue("@Localizacao", NpgsqlTypes.NpgsqlDbType.Varchar).Value = pessoa.Localizacao;
            cmd.Parameters.AddWithValue("@Descricao", NpgsqlTypes.NpgsqlDbType.Varchar).Value = pessoa.Descricao;
            cmd.Parameters.AddWithValue("@Contato", NpgsqlTypes.NpgsqlDbType.Varchar).Value = pessoa.Contato;
            cmd.Parameters.AddWithValue("@DisponivelOnline", NpgsqlTypes.NpgsqlDbType.Boolean).Value = pessoa.DisponivelOnline;
            cmd.Parameters.AddWithValue("@Avaliacao", NpgsqlTypes.NpgsqlDbType.Integer).Value = pessoa.Avaliacao;

            try
            {
                if (conexao.State == System.Data.ConnectionState.Open){
                    cmd.ExecuteNonQuery();
                    conexao.Close();
                    operacao = "Produto cadastrado com sucesso.";
                }
            }
            catch (System.Exception)
            {
                operacao = "Erro durante o cadastramento.";
            }
            return operacao;
        }
        public List<Produto> CarregarProdutos()
        {
            var ListaProdutos = new List<Produto>();
            var conexao = ConexaoDB.Conectar();
            // CommandText = "INSERT INTO tbl_produto (nome, categoria, preco, dataExpiracao, localizacao, descricao, contato, disponivelOnline, avaliacao) VALUES (@Nome, @Categoria, @Preco, @DataExpiracao, @Localizacao, @Descricao, @Contato, @DisponivelOnline, @Avaliacao);"
            // };
            var cmd = new NpgsqlCommand
            {
                Connection = conexao,
                CommandText = "SELECT tbl_produto.nome, tbl_produto.categoria, tbl_produto.preco, tbl_produto.dataExpiracao, tbl_produto.localizacao, tbl_produto.descricao, tbl_produto.contato, tbl_produto.disponivelOnline, tbl_produto.avaliacao, tbl_produto.id FROM tbl_produto;"
            };
            try
            {
                if (conexao.State == System.Data.ConnectionState.Open){
                    var consulta = cmd.ExecuteReader();
                    while (consulta.Read())
                    {
                        
                            var produto = new Produto
                            {
                                
                                Nome = consulta.GetString(0),
                                Categoria = consulta.GetString(1),
                                Preco = consulta.GetDecimal(2),
                                DataExpiracao = consulta.GetDateTime(3),
                                Localizacao = consulta.GetString(4),
                                Descricao = consulta.GetString(5),
                                Contato = consulta.GetString(6),
                                DisponivelOnline = consulta.GetBoolean(7),
                                Avaliacao = consulta.GetInt32(8),
                                Id = consulta.GetInt32(9)
                            };
                            ListaProdutos.Add(produto);
                        
                    }
                    conexao.Close();
                }
            }
            catch (System.Exception)
            {
                ListaProdutos.Clear();
                
            }
            return ListaProdutos;
        }

        public object AtualizarProduto(Produto produto)
        {
            var operacao = string.Empty;
            var conexao = ConexaoDB.Conectar();
            var cmd = new NpgsqlCommand
            {
                Connection = conexao,
                CommandText = "UPDATE tbl_produto SET nome = @Nome, categoria = @Categoria, preco = @Preco, dataExpiracao = @DataExpiracao, localizacao = @Localizacao, descricao = @Descricao, contato = @Contato, disponivelOnline = @DisponivelOnline, avaliacao = @Avaliacao WHERE id = @Id;"
            };
            cmd.Parameters.AddWithValue("@Nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = produto.Nome;
            cmd.Parameters.AddWithValue("@Categoria", NpgsqlTypes.NpgsqlDbType.Varchar).Value = produto.Categoria;
            cmd.Parameters.AddWithValue("@Preco", NpgsqlTypes.NpgsqlDbType.Numeric).Value = produto.Preco;
            cmd.Parameters.AddWithValue("@DataExpiracao", NpgsqlTypes.NpgsqlDbType.Date).Value = produto.DataExpiracao;
            cmd.Parameters.AddWithValue("@Localizacao", NpgsqlTypes.NpgsqlDbType.Varchar).Value = produto.Localizacao;
            cmd.Parameters.AddWithValue("@Descricao", NpgsqlTypes.NpgsqlDbType.Varchar).Value = produto.Descricao;
            cmd.Parameters.AddWithValue("@Contato", NpgsqlTypes.NpgsqlDbType.Varchar).Value = produto.Contato;
            cmd.Parameters.AddWithValue("@DisponivelOnline", NpgsqlTypes.NpgsqlDbType.Boolean).Value = produto.DisponivelOnline;
            cmd.Parameters.AddWithValue("@Avaliacao", NpgsqlTypes.NpgsqlDbType.Integer).Value = produto.Avaliacao;
            cmd.Parameters.AddWithValue("@Id", NpgsqlTypes.NpgsqlDbType.Integer).Value = produto.Id;

            try
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                {
                    cmd.ExecuteNonQuery();
                    conexao.Close();
                    operacao = "Produto atualizado com sucesso.";
                }
            }
            catch (System.Exception)
            {
                operacao = "Erro durante a atualização do produto.";
            }
            return operacao;
            }


            public List<Produto> CarregarProdutosPorCategoria(string categoriaDesejada)
            {
                var ListaProdutos = new List<Produto>();
                var conexao = ConexaoDB.Conectar();
                
                var cmd = new NpgsqlCommand
                {
                    Connection = conexao,
                    CommandText = "SELECT nome, categoria, preco, dataExpiracao, localizacao, descricao, contato, disponivelOnline, avaliacao FROM tbl_produto WHERE categoria = @Categoria;"
                };
                cmd.Parameters.AddWithValue("@Categoria", NpgsqlTypes.NpgsqlDbType.Varchar).Value = categoriaDesejada;

                try
                {
                    if (conexao.State == System.Data.ConnectionState.Open)
                    {
                        var consulta = cmd.ExecuteReader();
                        while (consulta.Read())
                        {
                            ListaProdutos.Add
                            (
                                new Produto
                                {
                                    Nome = consulta.GetString(0),
                                    Categoria = consulta.GetString(1),
                                    Preco = consulta.GetDecimal(2),
                                    DataExpiracao = consulta.GetDateTime(3),
                                    Localizacao = consulta.GetString(4),
                                    Descricao = consulta.GetString(5),
                                    Contato = consulta.GetString(6),
                                    DisponivelOnline = consulta.GetBoolean(7),
                                    Avaliacao = consulta.GetInt32(8)
                                }
                            );
                        }
                        conexao.Close();
                    }
                }
                catch (System.Exception)
                {
                    ListaProdutos.Clear();
                }
                return ListaProdutos;
            }

            public List<Produto> CarregarProdutosPorPreco(decimal precoDesejado)
            {
                var ListaProdutos = new List<Produto>();
                var conexao = ConexaoDB.Conectar();
                
                var cmd = new NpgsqlCommand
                {
                    Connection = conexao,
                    CommandText = "SELECT nome, categoria, preco, dataExpiracao, localizacao, descricao, contato, disponivelOnline, avaliacao FROM tbl_produto WHERE preco = @PrecoDesejado;"
                };

                cmd.Parameters.AddWithValue("@PrecoDesejado", NpgsqlTypes.NpgsqlDbType.Numeric).Value = precoDesejado;

                try
                {
                    if (conexao.State == System.Data.ConnectionState.Open)
                    {
                        var consulta = cmd.ExecuteReader();
                        while (consulta.Read())
                        {
                            ListaProdutos.Add
                            (
                                new Produto
                                {
                                    Nome = consulta.GetString(0),
                                    Categoria = consulta.GetString(1),
                                    Preco = consulta.GetDecimal(2),
                                    DataExpiracao = consulta.GetDateTime(3),
                                    Localizacao = consulta.GetString(4),
                                    Descricao = consulta.GetString(5),
                                    Contato = consulta.GetString(6),
                                    DisponivelOnline = consulta.GetBoolean(7),
                                    Avaliacao = consulta.GetInt32(8)
                                }
                            );
                        }
                        conexao.Close();
                    }
                }
                catch (System.Exception)
                {
                    ListaProdutos.Clear();
                }
                return ListaProdutos;
            }

            public List<Produto> CarregarProdutosPorDataExpiracao(DateTime dataExpiracaoDesejada)
            {
                var ListaProdutos = new List<Produto>();
                var conexao = ConexaoDB.Conectar();
                
                var cmd = new NpgsqlCommand
                {
                    Connection = conexao,
                    CommandText = "SELECT nome, categoria, preco, dataExpiracao, localizacao, descricao, contato, disponivelOnline, avaliacao FROM tbl_produto WHERE dataExpiracao = @DataExpiracaoDesejada;"
                };

                cmd.Parameters.AddWithValue("@DataExpiracaoDesejada", NpgsqlTypes.NpgsqlDbType.Date).Value = dataExpiracaoDesejada;

                try
                {
                    if (conexao.State == System.Data.ConnectionState.Open)
                    {
                        var consulta = cmd.ExecuteReader();
                        while (consulta.Read())
                        {
                            ListaProdutos.Add
                            (
                                new Produto
                                {
                                    Nome = consulta.GetString(0),
                                    Categoria = consulta.GetString(1),
                                    Preco = consulta.GetDecimal(2),
                                    DataExpiracao = consulta.GetDateTime(3),
                                    Localizacao = consulta.GetString(4),
                                    Descricao = consulta.GetString(5),
                                    Contato = consulta.GetString(6),
                                    DisponivelOnline = consulta.GetBoolean(7),
                                    Avaliacao = consulta.GetInt32(8)
                                }
                            );
                        }
                        conexao.Close();
                    }
                }
                catch (System.Exception)
                {
                    ListaProdutos.Clear();
                }
                return ListaProdutos;
            }
    }
}