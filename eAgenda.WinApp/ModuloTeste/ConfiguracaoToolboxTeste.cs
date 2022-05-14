﻿using eAgenda.WinApp.Compartilhado;

namespace eAgenda.WinApp.ModuloTeste
{
    public class ConfiguracaoToolboxTeste : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Testes";

        public override string TooltipInserir { get { return "Inserir um nova teste"; } }

        public override string TooltipEditar { get { return "Editar um teste existente"; } }

        public override string TooltipExcluir { get { return "Excluir um teste existente"; } }
    }
}