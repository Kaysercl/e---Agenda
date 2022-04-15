using e___Agenda.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e___Agenda.ModuloTarefas
{
    public class TelaCadastroTarefa : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Tarefa> _repositorioTarefa;        

        public TelaCadastroTarefa(IRepositorio<Tarefa> repositorioTarefa)
            : base("Cadastro de tarefas")
        {
            _repositorioTarefa = repositorioTarefa;          
        }

        public void Inserir()
        {
            MostrarTitulo("Cadastro de Tarefas");

            Tarefa novoGenero = ObterTarefa();

            _repositorioTarefa.Inserir(novoGenero);

            Notificador.ApresentarMensagem("Tarefa cadastrada com sucesso!", TipoMensagem.Sucesso);
        }

        public override string MostrarOpcoes()
        {
            MostrarTitulo(Titulo);

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");
            Console.WriteLine("Digite 5 para Adicionar Itens");
            Console.WriteLine("Digite 6 para Conlcuir Itens");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void Editar()
        {
            MostrarTitulo("Editando Tarefa");

            bool temTarefasCadastradas = VisualizarRegistros("Pesquisando");

            if (temTarefasCadastradas == false)
            {
                Notificador.ApresentarMensagem("Nenhuma tarefa cadastrada para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroTarefa = ObterNumeroRegistro();

            Tarefa tarefaAtualizada = ObterTarefa();

            bool conseguiuEditar = _repositorioTarefa.Editar(numeroTarefa, tarefaAtualizada);

            if (!conseguiuEditar)
                Notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                Notificador.ApresentarMensagem("Tarefa editada com sucesso!", TipoMensagem.Sucesso);
        }

        internal void AdicionarItems()
        {
            VisualizarRegistros("abc");
            Console.WriteLine("Qual tarefa você gostaria de adicionar items?");
            int tarefaescolhida = Convert.ToInt32(Console.ReadLine());
            Tarefa tarefa = _repositorioTarefa.SelecionarRegistro(tarefaescolhida);
            Item item = ObterItem();
            tarefa.AdicionarItem(item);
        }

        private Item ObterItem()
        {
            Console.WriteLine("Descrição do item");
            string descricao = Console.ReadLine();
            return new Item(descricao);
        }

        internal void ConcluirItems()
        {
            VisualizarRegistros("abc");
            Console.WriteLine("Qual tarefa você gostaria de selecionar");
            int tarefaselecionada = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Tarefa tarefa = _repositorioTarefa.SelecionarRegistro(tarefaselecionada);
            Console.WriteLine(tarefa.ToString());
            Console.WriteLine("Qual destes itens você gostaria de concluir?");
            int itemescolhido = Convert.ToInt32(Console.ReadLine())-1;
            tarefa.ConcluirItem(itemescolhido);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Tarefa");

            bool temTarefasRegistradas = VisualizarRegistros("Pesquisando");

            if (temTarefasRegistradas == false)
            {
                Notificador.ApresentarMensagem("Nenhuma tarefa cadastrada para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroTarefa = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioTarefa.Excluir(numeroTarefa);

            if (!conseguiuExcluir)
                Notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                Notificador.ApresentarMensagem("Tarefa excluída com sucesso1", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Tarefas");

            List<Tarefa> tarefas = _repositorioTarefa.SelecionarTodos();

            if (tarefas.Count == 0)
            {
                Notificador.ApresentarMensagem("Nenhuma tarefa disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Tarefa tarefa in tarefas)
                Console.WriteLine(tarefa.ToString());

            Console.ReadLine();

            return true;
        }

        private Tarefa ObterTarefa()
        {
            Console.WriteLine("Digite a prioridade da tarefa, sendo alta, média ou baixa: ");
            string prioridade = Console.ReadLine();

            Console.WriteLine("Digite o título da tarefa: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite a data de criação da tarefa: ");
            DateTime datacriacao = DateTime.Parse(Console.ReadLine());
            Console.ReadLine();

            Console.WriteLine("Digite a data de conclusão da tarefa: ");
            DateTime dataconclusao = DateTime.Parse(Console.ReadLine());
            


            return new Tarefa(prioridade, titulo, datacriacao, dataconclusao);
        }

        public int ObterNumeroRegistro()
        {
            int numeroTarefa;
            bool numeroTarefaEncontrada;

            do
            {
                Console.Write("Digite o ID da tarefa que deseja editar: ");
                numeroTarefa = Convert.ToInt32(Console.ReadLine());

                numeroTarefaEncontrada = _repositorioTarefa.ExisteRegistro(numeroTarefa);

                if (numeroTarefaEncontrada == false)
                    Notificador.ApresentarMensagem("ID da tarefa não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroTarefaEncontrada == false);

            return numeroTarefa;
        }

    }
}
