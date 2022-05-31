using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes_da_Mariana.Dominio.ModuloQuestao;
using Testes_da_Mariana.Dominio.ModuloTeste;

namespace Testes_da_Mariana.Infra.BancoDados
{
    public class RepositorioTesteEmBancoDados : IRepositorioTeste
    {
        RepositorioDisciplinaEmBancoDados repositorioDisciplina = new RepositorioDisciplinaEmBancoDados();
        RepositorioMateriaEmBancoDados repositorioMateria = new RepositorioMateriaEmBancoDados();
        RepositorioQuestaoEmBancoDados repositorioQuestao = new RepositorioQuestaoEmBancoDados();

        private const string enderecoBanco =
                "Data Source=(LocalDb)\\MSSQLLocalDB;" +
                "Initial Catalog=TestesDaMarianaDb;" +
                "Integrated Security=True;" +
                "Pooling=False";

        #region Comandos SQL
        private const string sqlInserir =
            @"INSERT INTO [TESTE] 
                (
                    [TITULO],
                    [ID_DISCIPLINA],
                    [ID_MATERIA],
                    [DATA]
                )
	            VALUES
                (
                    @TITULO,
                    @ID_DISCIPLINA,
                    @ID_MATERIA,
                    @DATA
                );SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
            @"UPDATE [TESTE]	
		        SET
			        [TITULO] = @TITULO,
			        [ID_DISCIPLINA] = @ID_DISCIPLINA,
                    [ID_MATERIA] = @ID_MATERIA,
                    [DATA] = @DATA
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlExcluir =
            @"DELETE FROM [TESTE_QUESTAO]
                WHERE
                    [ID_TESTE] = @NUMERO;
              DELETE FROM [TESTE]
                WHERE
                    [NUMERO] = @NUMERO";

        private const string sqlSelecionarPorNumero =
            @"SELECT
	                NUMERO,
                    TITULO,
                    ID_DISCIPLINA,
                    ID_MATERIA,
                    [DATA]
                FROM 
	                TESTE
                WHERE
                    NUMERO = @NUMERO";

        private const string sqlSelecionarTodos =
            @"SELECT
	            NUMERO,
                TITULO,
                ID_DISCIPLINA,
                ID_MATERIA,
                [DATA]
            FROM 
	            TESTE";

        private const string sqlContarQuestoesTeste =
            @"SELECT count(*) as Quantidade
                FROM 
                    QUESTAO AS Q INNER JOIN TESTE_QUESTAO AS TQ
                    ON Q.NUMERO = TQ.ID_QUESTAO
            
                WHERE 
                    TQ.ID_TESTE = ID_TESTE";

        private const string sqlSelecionarQuestoesTeste =
            @"SELECT
                    Q.NUMERO,
                    Q.ENUNCIADO,
                    Q.ID_DISCIPLINA,
                    Q.ID_MATERIA
            FROM 
                QUESTAO AS Q INNER JOIN TESTE_QUESTAO AS TQ
                ON Q.NUMERO = TQ.ID_QUESTAO
            
            WHERE 
                TQ.ID_TESTE = @ID_TESTE";

        private const string sqlAdicionarQuestaoTeste =
            @"INSERT INTO [TESTE_QUESTAO] 
                (
                    [ID_TESTE],
                    [ID_QUESTAO]
	            )
	            VALUES
                (
                    @ID_TESTE,
                    @ID_QUESTAO
                )";

        private const string sqlRemoverQuestaoDoTeste =
            @"DELETE FROM 
                TESTE_QUESTAO
            WHERE 
	            [ID_QUESTAO] = @ID_QUESTAO";
        #endregion

        public ValidationResult Inserir(Teste teste)
        {
            var validador = new ValidadorTeste();

            var resultadoValidacao = validador.Validate(teste);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosTeste(teste, comandoInsercao);

            conexaoComBanco.Open();

            var id = comandoInsercao.ExecuteScalar();

            teste.Numero = Convert.ToInt32(id);

            foreach (var questao in teste.Questoes)
                AdicionarQuestao(teste, questao);

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Editar(Teste teste)
        {
            var validador = new ValidadorTeste();

            var resultadoValidacao = validador.Validate(teste);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            ConfigurarParametrosTeste(teste, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Teste teste)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("NUMERO", teste.Numero);

            conexaoComBanco.Open();
            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            var resultadoValidacao = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public Teste SelecionarPorNumero(int numero)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();
            SqlDataReader leitorTeste = comandoSelecao.ExecuteReader();

            Teste teste = null;

            if (leitorTeste.Read())
                teste = ConverterParaTeste(leitorTeste);

            conexaoComBanco.Close();

            CarregarQuestoes(teste);

            return teste;
        }

        public List<Teste> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorTeste = comandoSelecao.ExecuteReader();

            List<Teste> testes = new List<Teste>();

            while (leitorTeste.Read())
            {
                Teste teste = ConverterParaTeste(leitorTeste);

                testes.Add(teste);
            }

            conexaoComBanco.Close();

            return testes;
        }

        private void CarregarQuestoes(Teste teste)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarQuestoesTeste, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("ID_TESTE", teste.Numero);

            conexaoComBanco.Open();
            SqlDataReader leitorQuestoesTeste = comandoSelecao.ExecuteReader();


            while (leitorQuestoesTeste.Read())
            {
                Questao questao = ConverterParaQuestao(leitorQuestoesTeste);

                repositorioQuestao.CarregarAlternativasQuestao(questao);

                teste.AdicionarQuestao(questao);
            }

            conexaoComBanco.Close();
        }

        #region Métodos privados

        private void ConfigurarParametrosTeste(Teste teste, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NUMERO", teste.Numero);
            comando.Parameters.AddWithValue("TITULO", teste.Titulo);
            comando.Parameters.AddWithValue("DATA", teste.Data);
            comando.Parameters.AddWithValue("ID_MATERIA", teste.Materia.Numero);
            comando.Parameters.AddWithValue("ID_DISCIPLINA", teste.Disciplina.Numero);
        }

        private Teste ConverterParaTeste(SqlDataReader leitorTeste)
        {
            var numero = Convert.ToInt32(leitorTeste["NUMERO"]);
            var titulo = Convert.ToString(leitorTeste["TITULO"]);
            var data = Convert.ToDateTime(leitorTeste["DATA"]);
            var numeroMateria = Convert.ToInt32(leitorTeste["ID_MATERIA"]);
            var numeroDisciplina = Convert.ToInt32(leitorTeste["ID_DISCIPLINA"]);

            var teste = new Teste
            {
                Numero = numero,
                Titulo = titulo,
                Data = data,
                Materia = repositorioMateria.SelecionarPorNumero(numeroMateria),
                Disciplina = repositorioDisciplina.SelecionarPorNumero(numeroDisciplina)
            };

            return teste;
        }

        private Questao ConverterParaQuestao(SqlDataReader leitorQuestao)
        {
            var numero = Convert.ToInt32(leitorQuestao["NUMERO"]);
            var enunciado = Convert.ToString(leitorQuestao["ENUNCIADO"]);
            var numeroMateria = Convert.ToInt32(leitorQuestao["ID_MATERIA"]);
            var numeroDisciplina = Convert.ToInt32(leitorQuestao["ID_DISCIPLINA"]);

            var questao = new Questao
            {
                Numero = numero,
                Enunciado = enunciado,
                Materia = repositorioMateria.SelecionarPorNumero(numeroMateria),
                Disciplina = repositorioDisciplina.SelecionarPorNumero(numeroDisciplina)
            };

            return questao;
        }

        private void AdicionarQuestao(Teste teste, Questao questao)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlAdicionarQuestaoTeste, conexaoComBanco);

            comandoInsercao.Parameters.AddWithValue("ID_TESTE", teste.Numero);
            comandoInsercao.Parameters.AddWithValue("ID_QUESTAO", questao.Numero);

            conexaoComBanco.Open();
            comandoInsercao.ExecuteNonQuery();
            conexaoComBanco.Close();
        }

        private void RemoverQuestao(Questao questao)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlRemoverQuestaoDoTeste, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("ID_QUESTAO", questao.Numero);

            conexaoComBanco.Open();
            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();
            conexaoComBanco.Close();
        }

        #endregion

    }
}
