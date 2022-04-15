using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e___Agenda.ModuloContato
{
    public class Contato : EntidadeBase
    {
        public string nome;
        public string telefone;
        public string email;
        public string empresa;
        public string cargo;

        public Contato(string nome, string telefone, string email, string empresa, string cargo)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.email = email;
            this.empresa = empresa;
            this.cargo = cargo;
        }

        public override string ToString()
        {

            return "Id :" + id + "\n" +
                "Nome" + nome + "\n" +
                "Telefone" + telefone + "\n" +
                "Email" + email + "\n" +
                "Empresa" + empresa + "\n" +
                "Cargo" + cargo + "\n";
        }
    }

    
}
