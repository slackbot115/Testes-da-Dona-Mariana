using eAgenda.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.WinApp.ModuloDisciplina
{
    public class ConfiguracaoToolboxDisciplina : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Disciplinas";

        public override string TooltipInserir { get { return "Inserir uma nova disciplina"; } }

        public override string TooltipEditar { get { return "Editar uma disciplina existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma disciplina existente"; } }
    }
}
