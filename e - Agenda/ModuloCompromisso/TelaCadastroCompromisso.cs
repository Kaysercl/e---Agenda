using e___Agenda.Compartilhado;
using e___Agenda.ModuloContato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e___Agenda.ModuloCompromisso
{
    public class TelaCadastroCompromisso : TelaBase, ITelaCadastravel
    {
        public IRepositorio<Contato> _repositorioContato;
        public TelaCadastroContato telaCadastroContato;
        public IRepositorio<Compromisso> _repositorioCompromisso;
        
        public TelaCadastroCompromisso(IRepositorio<Compromisso> repositorioCompromisso, 
            TelaCadastroContato telaCadastroContato, IRepositorio<Contato> repositorioContato) 
            : base("Gerenciamento de Compromissos")
        {
            this._repositorioCompromisso = repositorioCompromisso;
            this.telaCadastroContato = telaCadastroContato;
            this._repositorioContato = repositorioContato;
        }

        public void Inserir()
        {
            MostrarTitulo("Cadastro de Compromissos");

            Compromisso novoGenero = ObterCompromisso();

            _repositorioCompromisso.Inserir(novoGenero);

            Notificador.ApresentarMensagem("Compromisso cadastrado com sucesso!", TipoMensagem.Sucesso);
        }

        private Compromisso ObterCompromisso()
        {
            Console.WriteLine("Digite o local do compromisso");
            string local = Console.ReadLine();

            Console.WriteLine("Digite o assunto do compromisso ");
            string assunto = Console.ReadLine();

            Console.WriteLine("Digite a hora inicial ");
            string horainicio = Console.ReadLine();            

            Console.WriteLine("Digite a hora de término do compromisso: ");
            string horafim = Console.ReadLine();

            telaCadastroContato.VisualizarRegistros("abc");

            Console.WriteLine("Qual contato adicionar o compromisso?");
            int contatoadicionado = Convert.ToInt32(Console.ReadLine());

            Contato contato = _repositorioContato.SelecionarRegistro(contatoadicionado);

            return new Compromisso(local, assunto, horainicio, horafim, contato);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Compromissos");

            List<Compromisso> compromissos = _repositorioCompromisso.SelecionarTodos();

            if (compromissos.Count == 0)
            {
                Notificador.ApresentarMensagem("Nenhum compromisso disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Compromisso compromisso in compromissos)
                Console.WriteLine(compromisso.ToString());

            Console.ReadLine();

            return true;
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
