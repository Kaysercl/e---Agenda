using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e___Agenda.ModuloTarefas
{
    public class Tarefa : EntidadeBase
    {
        public string prioridade;
        public string titulo;
        public bool concluida;
        public DateTime datacriacao;
        public List<string> tarefas;
        public DateTime dataconclusao;
        public decimal percentualconclusao;
        public List<Item> items;

        public string Prioridade { get => prioridade; }


        public Tarefa (string prioridade, string titulo, DateTime datacriacao, DateTime dataconclusao)
        {
            this.prioridade = prioridade;
            this.titulo = titulo;
            this.datacriacao = datacriacao;
            this.dataconclusao = dataconclusao;
            this.percentualconclusao = 0;
            this.items = new List<Item>();
            this.concluida = false;
        }

        public override string ToString()
        {

            string status = concluida ? "concluido" : "pendente";

            return "ID :" + id + "\n" +
                "Prioridade" + prioridade + "\n" +
                "Titulo" + titulo + "\n" +
                "datacriacao" + datacriacao + "\n" +
                "status" + status + "\n" +
                "dataconclusao" + dataconclusao + "\n" +
                "percentualconclusao" + percentualconclusao + "\n" +
                "Items" + ToStringDeItems() + "\n";

        }

        public string ToStringDeItems()
        {
            StringBuilder d = new StringBuilder();


            foreach (Item item in items)
            {
                d.AppendLine(item.ToString());
            }

            return d.ToString();
        }

        public void AdicionarItem(Item item)
        {
            int contID = items.Count;
            contID++;
            item.id = contID;
            this.items.Add(item);
            AtualizarPercentual();
        }

        public void ConcluirItem(int id)
        {
            this.items[id].concluido = true;
            AtualizarPercentual();
        }

        private void AtualizarPercentual()
        {
            int totalItens = this.items.Count;
            int itensConcluidos = 0;
            foreach (Item item in items)
            {
                if (item.concluido == true)
                    itensConcluidos++;
            }
            if(itensConcluidos == 0)
                return;
            this.percentualconclusao = 0;
            this.percentualconclusao = ((itensConcluidos * 100) / totalItens);
            if (this.percentualconclusao == 100)
                this.concluida = true;
        }
    }
}
