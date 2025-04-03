using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePedidos
{
    class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string DataPedido { get; set; }
        public List<ItemPedido> Itens { get; set; }
        public double Total { get; set; }
    }
}
