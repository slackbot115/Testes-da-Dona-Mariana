using eAgenda.Dominio.Compartilhado;
using eAgenda.Dominio.ModuloDisciplina;
using eAgenda.Dominio.ModuloMateria;
using eAgenda.Dominio.ModuloQuestao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Dominio.ModuloTeste
{
    public class Teste : EntidadeBase<Teste>
    {
        public int NumeroQuestoes { get; set; }
        public string Titulo { get; set; }
        public Disciplina Disciplina { get; set; }
        public Materia Materia { get; set; }
        public DateTime Data { get; set; }
        public List<Questao> Questoes { get; set; }

        public Teste()
        {
            Data = DateTime.Now;
        }

        public override void Atualizar(Teste registro)
        {
            Titulo = registro.Titulo;
            Disciplina = registro.Disciplina;
            Materia = registro.Materia;
            Data = registro.Data;
            Questoes = registro.Questoes;
            NumeroQuestoes = registro.NumeroQuestoes;
        }
    }
}
