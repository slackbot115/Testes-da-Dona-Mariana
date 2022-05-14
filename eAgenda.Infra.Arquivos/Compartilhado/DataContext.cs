using eAgenda.Dominio.ModuloDisciplina;
using eAgenda.Dominio.ModuloMateria;
using eAgenda.Dominio.ModuloQuestao;
using eAgenda.Dominio.ModuloTarefa;
using eAgenda.Dominio.ModuloTeste;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eAgenda.Infra.Arquivos
{
    [Serializable]
    public class DataContext //Container
    {
        private readonly ISerializador serializador;

        public DataContext()
        {
            Tarefas = new List<Tarefa>();
            Questoes = new List<Questao>();
            Disciplinas = new List<Disciplina>();
            Materias = new List<Materia>();
            Testes = new List<Teste>();
        }

        public DataContext(ISerializador serializador) : this()
        {
            this.serializador = serializador;

            CarregarDados();
        }

        public List<Tarefa> Tarefas { get; set; }
        public List<Questao> Questoes { get; set; }
        public List<Disciplina> Disciplinas { get; set; }
        public List<Materia> Materias { get; set; }
        public List<Teste> Testes { get; set; }

        public void GravarDados()
        {
            serializador.GravarDadosEmArquivo(this);
        }

        private void CarregarDados()
        {
            var ctx = serializador.CarregarDadosDoArquivo();

            if (ctx.Tarefas.Any())
                this.Tarefas.AddRange(ctx.Tarefas);

            if(ctx.Disciplinas.Any())
                this.Disciplinas.AddRange(ctx.Disciplinas);

            if(ctx.Materias.Any())
                this.Materias.AddRange(ctx.Materias);

            if(ctx.Questoes.Any())
                this.Questoes.AddRange(ctx.Questoes);

            if(ctx.Testes.Any())
                this.Testes.AddRange(ctx.Testes);
        }
    }
}
