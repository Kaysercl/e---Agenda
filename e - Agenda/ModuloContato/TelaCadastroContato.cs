using e___Agenda.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e___Agenda.ModuloContato
{
    public class TelaCadastroContato : TelaBase, ITelaCadastravel
    {
        public IRepositorio<Contato> _repositorioContato;
        

        public TelaCadastroContato(IRepositorio<Contato> repositorioContato) : base("Gerenciamento de Contatos")
        {
           this._repositorioContato = repositorioContato;
        }

        public void Inserir()
        {
            MostrarTitulo("Cadastro de Contatos");

            Contato novoGenero = ObterContato();

            _repositorioContato.Inserir(novoGenero);

            Notificador.ApresentarMensagem("Contato cadastrado com sucesso!", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Contato")
                MostrarTitulo("Visualização de Contatos");

            List<Contato> contatos = _repositorioContato.SelecionarTodos();

            if (contatos.Count == 0)
            {
                Notificador.ApresentarMensagem("Nenhum contato disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Contato contato in contatos)
                Console.WriteLine(contato.ToString());

            Console.ReadLine();

            return true;
        }

        public Contato ObterContato()
        {
            Console.WriteLine("Digite o nome do contato");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o email do contato ");
            string email = Console.ReadLine();

            Console.WriteLine("Digite o telefone do contato");
            string telefone = Console.ReadLine();

            Console.WriteLine("Digite a empresa do contato");
            string empresa = Console.ReadLine();

            Console.WriteLine("Digite o cargo na empresa do contato");
            string cargo = Console.ReadLine();


            return new Contato(nome, email, telefone, empresa, cargo);
        }

        public void Editar()
        {
            throw new NotImplementedException();
        }

        public void Excluir()
        {
            throw new NotImplementedException();
        }
    }
}
