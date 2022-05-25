using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes_da_Mariana.Dominio.ModuloMateria;

namespace Testes_da_Mariana.Infra.BancoDados
{
    public class BackupRepositorioMateriaEmBancoDados : IRepositorioMateria
    {
        private const string enderecoBanco =
               "Data Source=(LocalDB)\\MSSqlLocalDB;" +
               "Initial Catalog=TestesDaMarianaDb;" +
               "Integrated Security=True;" +
               "Pooling=False";

        #region Sql Queries
        private const string sqlInserir =
            @"INSERT INTO [MATERIA] 
                (
                    [NOME],
                    [ID_DISCIPLINA],
                    [SERIE]
	            )
	            VALUES
                (
                    @NOME,
                    @ID_DISCIPLINA,
                    @SERIE
                );SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
            @"UPDATE [MATERIA]	
		        SET
                    [NOME] = @NOME,
			        [ID_DISCIPLINA] = @ID_DISCIPLINA,
                    [SERIE] = @SERIE
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlExcluir =
            @"DELETE FROM [MATERIA]
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlSelecionarTodos =
            @"SELECT 
		            [NUMERO],
                    [NOME],
		            [ID_DISCIPLINA],
                    [SERIE]
	            FROM 
		            [MATERIA]";

        private const string sqlSelecionarPorNumero =
            @"SELECT 
		            [NUMERO],
                    [NOME],
		            [ID_DISCIPLINA],
                    [SERIE]
	            FROM 
		            [MATERIA]
		        WHERE
                    [NUMERO] = @NUMERO";

        #endregion

        private static RepositorioDisciplinaEmBancoDados repositorioDisciplinaEmBancoDados = new RepositorioDisciplinaEmBancoDados();

        public ValidationResult Inserir(Materia novaMateria)
        {
            var validador = new ValidadorMateria();

            var resultadoValidacao = validador.Validate(novaMateria);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosMateria(novaMateria, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            novaMateria.Numero = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Editar(Materia materia)
        {
            var validador = new ValidadorMateria();

            var resultadoValidacao = validador.Validate(materia);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            ConfigurarParametrosMateria(materia, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Materia materia)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("NUMERO", materia.Numero);

            conexaoComBanco.Open();
            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            var resultadoValidacao = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public List<Materia> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorMateria = comandoSelecao.ExecuteReader();

            List<Materia> materias = new List<Materia>();

            while (leitorMateria.Read())
            {
                Materia materia = ConverterParaMateria(leitorMateria);

                materias.Add(materia);
            }

            conexaoComBanco.Close();

            return materias;
        }

        public Materia SelecionarPorNumero(int numero)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();
            SqlDataReader leitorMateria = comandoSelecao.ExecuteReader();

            Materia disciplina = null;
            if (leitorMateria.Read())
                disciplina = ConverterParaMateria(leitorMateria);

            conexaoComBanco.Close();

            return disciplina;
        }

        private static Materia ConverterParaMateria(SqlDataReader leitorMateria)
        {
            int numero = Convert.ToInt32(leitorMateria["NUMERO"]);
            string nome = Convert.ToString(leitorMateria["NOME"]);
            int id_disciplina = Convert.ToInt32(leitorMateria["ID_DISCIPLINA"]);
            TipoSerieEnum serie = (TipoSerieEnum) Enum.Parse(typeof(TipoSerieEnum), leitorMateria["SERIE"].ToString());

            var materia = new Materia
            {
                Numero = numero,
                Nome = nome,
                Disciplina = repositorioDisciplinaEmBancoDados.SelecionarPorNumero(id_disciplina),
                Serie = serie
            };

            return materia;
        }

        private static void ConfigurarParametrosMateria(Materia novaMateria, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NUMERO", novaMateria.Numero);
            comando.Parameters.AddWithValue("NOME", novaMateria.Nome);
            comando.Parameters.AddWithValue("ID_DISCIPLINA", novaMateria.Disciplina.Numero);
            comando.Parameters.AddWithValue("SERIE", novaMateria.Serie.ToString());
        }

    }
}
