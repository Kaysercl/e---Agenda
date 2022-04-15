using e___Agenda.ModuloCompromisso;
using e___Agenda.ModuloContato;
using e___Agenda.ModuloTarefas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e___Agenda.Compartilhado
{
    public class TelaMenuPrincipal
    {
        private IRepositorio<Tarefa> repositorioTarefa;
        private TelaCadastroTarefa telaCadastroTarefa;
        private IRepositorio<Contato> repositorioContato;
        private TelaCadastroContato telaCadastroContato;
        private IRepositorio<Compromisso> repositorioCompromisso;
        private TelaCadastroCompromisso telaCadastroCompromisso;

        public TelaMenuPrincipal()
        {
            repositorioTarefa = new RepositorioTarefa();
            telaCadastroTarefa = new TelaCadastroTarefa(repositorioTarefa);
            repositorioContato = new RepositorioContato();
            telaCadastroContato = new TelaCadastroContato(repositorioContato);
            repositorioCompromisso = new RepositorioCompromisso();
            telaCadastroCompromisso = new TelaCadastroCompromisso(repositorioCompromisso, telaCadastroContato, repositorioContato);
        }

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Controle de Sessões de Cinema 1.0");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Gerenciar Tarefas");
            Console.WriteLine("Digite 2 para Gerenciar Contatos ");
            Console.WriteLine("Digite 3 para Gerenciar Compromissos ");
            Console.WriteLine("Digite 4 para Gerenciar ");
            Console.WriteLine("Digite 5 para Gerenciar ");

            Console.WriteLine("Digite s para sair");

            string opcaoSelecionada = Console.ReadLine();

            return opcaoSelecionada;
        }

        public TelaBase ObterTela()
        {
            string opcao = MostrarOpcoes();

            TelaBase tela = null;

            if (opcao == "1")
                tela = telaCadastroTarefa;

            else if (opcao == "2")
                tela = telaCadastroContato;

            else if (opcao == "3")
                tela = telaCadastroCompromisso;

            else if (opcao == "4")
                tela = null;

            else if (opcao == "5")
                tela = null;

            return tela;
        }
    }
}
