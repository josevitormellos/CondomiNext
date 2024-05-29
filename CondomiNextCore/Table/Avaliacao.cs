using System.Collections.Generic;

namespace CondomiNextCore.Table
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int IdServico { get; set; }
        public string IdMorador { get; set; }
        public double Nota { get; set; }
        public string Descricao { get; set; }

       
    }
}