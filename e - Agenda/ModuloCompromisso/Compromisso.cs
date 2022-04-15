using e___Agenda.ModuloContato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e___Agenda.ModuloCompromisso
{
    public class Compromisso : EntidadeBase
    {
        public string assunto;
        public string local;
        public string horainicio;
        public string horafim;
        public Contato contato;
        public Compromisso(string assunto, string local, string horainicio, string horafim, Contato contato)
        {
            this.assunto = assunto;
            this.local = local;
            this.horainicio = horainicio;
            this.horafim = horafim;
            this.contato = contato;
        }

        public override string ToString()
        {

            return "Id :" + id + "\n" +
                "Assunto" + assunto + "\n" +
                "Local" + local + "\n" +
                "Hora de Inicio" + horainicio + "\n" +
                "Hora final" + horafim + "\n" +
                "Contato" + contato.ToString() + "\n";
        }

    }
}
