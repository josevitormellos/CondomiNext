using System.Collections.Generic;

namespace CondomiNextCore.Table
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public string IdPrestador { get; set; }

        public double Media { get; set; }



    }
}