﻿using eAgenda.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Dominio.ModuloQuestao
{
    public class Alternativa
    {
        public string Descricao { get; set; }
        public bool Correta { get; set; }
        public char Letra { get; set; }

        public override string ToString()
        {
            return Descricao;
        }
    }
}
