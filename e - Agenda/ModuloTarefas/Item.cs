using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e___Agenda.ModuloTarefas
{
    public class Item : EntidadeBase
    {
        public string descricao;
        public bool concluido;

        public Item(string descricao)
        {
            this.descricao = descricao;
            this.concluido = false;
        }

        public override string ToString()
        {
            string status = concluido ? "concluido" : "pendente";

            return "ID :" + id + "\n" +
                "Descrição" + descricao + "\n" +
                "Conclusão" + status + "\n";
                
        }
    }

    
}
