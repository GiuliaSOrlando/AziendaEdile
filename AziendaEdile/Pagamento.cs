using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AziendaEdile
{
    public class Pagamento
    {
        public int IDPagamento { get; set; }
        public int IDDipendente { get; set; }
        public DateTime PeriodoPagamento { get; set; }
        public decimal Ammontare { get; set; }
        public string Tipo { get; set; }
    }
}