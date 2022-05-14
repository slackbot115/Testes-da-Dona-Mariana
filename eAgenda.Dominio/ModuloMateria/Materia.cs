using eAgenda.Dominio.Compartilhado;
using eAgenda.Dominio.ModuloDisciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public string Nome { get; set; }
        public Disciplina Disciplina { get; set; }
        public TipoSerieEnum Serie { get; set; }

        public override void Atualizar(Materia registro)
        {
            Nome = registro.Nome;
            Disciplina = registro.Disciplina;
            Serie = registro.Serie;
        }

        public override string ToString()
        {
            return $"{Nome}";
        }
    }
}
