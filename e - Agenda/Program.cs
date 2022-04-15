using e___Agenda.Compartilhado;
using e___Agenda.ModuloTarefas;
using System;

namespace e___Agenda
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TelaMenuPrincipal telaMenuPrincipal = new TelaMenuPrincipal();

            while (true)
            {
                TelaBase telaSelecionada = telaMenuPrincipal.ObterTela();

                if (telaSelecionada is null)
                    break;

                string opcaoSelecionada = telaSelecionada.MostrarOpcoes();

                if (telaSelecionada is ITelaCadastravel)
                {
                    ITelaCadastravel telaCadastroBasico = (ITelaCadastravel)telaSelecionada;

                    if (opcaoSelecionada == "1")
                        telaCadastroBasico.Inserir();

                    if (opcaoSelecionada == "2")
                        telaCadastroBasico.Editar();

                    if (opcaoSelecionada == "3")
                        telaCadastroBasico.Excluir();

                    if (opcaoSelecionada == "4")
                        telaCadastroBasico.VisualizarRegistros("Tela");
                }

                if (telaSelecionada is TelaCadastroTarefa)
                {
                    TelaCadastroTarefa telaCadastroBasico = (TelaCadastroTarefa)telaSelecionada;

                    if (opcaoSelecionada == "5")
                        telaCadastroBasico.AdicionarItems();

                    if (opcaoSelecionada == "6")
                        telaCadastroBasico.ConcluirItems();

                }
            }
        }
    }
}
