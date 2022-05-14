using eAgenda.Dominio.ModuloDisciplina;
using eAgenda.Dominio.ModuloMateria;
using eAgenda.Dominio.ModuloQuestao;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eAgenda.WinApp.ModuloQuestao
{
    public partial class TelaCadastroQuestaoForm : Form
    {
        private Questao questao;
        char[] letras = new char[] { 'A', 'B', 'C', 'D', 'E' };
        int contadorLetra = 0;
        List<Alternativa> alternativasAdicionadas = new List<Alternativa>();

        public TelaCadastroQuestaoForm(List<Disciplina> disciplinas, List<Materia> materias)
        {
            InitializeComponent();
            CarregarDisciplinas(disciplinas);
            CarregarMaterias(materias);

            foreach (Alternativa alternativa in Alternativas)
            {
                listAlternativas.Items.Add(alternativa);
            }
        }

        private void CarregarMaterias(List<Materia> materias)
        {
            comboMateria.Items.Clear();

            foreach (var item in materias)
            {
                comboMateria.Items.Add(item);
            }
        }

        private void CarregarDisciplinas(List<Disciplina> disciplinas)
        {
            comboDisciplina.Items.Clear();

            foreach (var item in disciplinas)
            {
                comboDisciplina.Items.Add(item);
            }
        }

        public Func<Questao, ValidationResult> GravarRegistro { get; set; }

        public Questao Questao
        {
            get
            {
                return questao;
            }
            set
            {
                questao = value;
                txtNumero.Text = questao.Numero.ToString();
                txtEnunciado.Text = questao.Enunciado;
                comboDisciplina.SelectedItem = questao.Disciplina;
                comboMateria.SelectedItem = questao.Materia;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            questao.Enunciado = txtEnunciado.Text;
            questao.Disciplina = (Disciplina) comboDisciplina.SelectedItem;
            questao.Materia = (Materia) comboMateria.SelectedItem;
            questao.Alternativas = alternativasAdicionadas;

            var resultadoValidacao = GravarRegistro(questao);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;
                TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                DialogResult = DialogResult.None;
            }
        }

        private void TelaCadastroQuestaoForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroQuestaoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        public List<Alternativa> Alternativas
        {
            get
            {
                return listAlternativas.Items.Cast<Alternativa>().ToList();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //List<string> alternativas = Alternativas.Select(x => x.Descricao).ToList();

            //if (alternativas.Count == 0 || alternativas.Contains(txtEnunciadoAlternativa.Text) == false)
            //{
                Alternativa alternativa = new Alternativa();
                alternativa.Descricao = txtEnunciadoAlternativa.Text;
                alternativa.Letra = letras[contadorLetra];
                contadorLetra++;
                if (isCorreta.Checked)
                {
                    alternativa.Correta = true;
                    listAlternativas.Items.Add($"{alternativa.Letra}) {alternativa.Descricao} [CORRETA]");
                }
                else
                {
                    listAlternativas.Items.Add($"{alternativa.Letra}) {alternativa.Descricao}");
                }

                alternativasAdicionadas.Add(alternativa);
                isCorreta.Checked = false;
                txtEnunciadoAlternativa.Text = String.Empty;
            //}

        }
    }
}
