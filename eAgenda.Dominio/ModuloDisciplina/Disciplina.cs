using eAgenda.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Dominio.ModuloDisciplina
{
    public class Disciplina : EntidadeBase<Disciplina>
    {
        public string Nome { get; set; }

        public override void Atualizar(Disciplina registro)
        {
            Nome = registro.Nome;
        }

        public override string ToString()
        {
            return $"{Nome}";
        }
    }
}
