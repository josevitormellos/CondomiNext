using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondomiNext
{
    public class Morador : Usuario , IComparable
    {
        public override Servico AdicionarServico()
        {
            throw new NotImplementedException();
        }

        public override int AlterarServico(Servico servico)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override int RemoverServico(Servico servico)
        {
            throw new NotImplementedException();
        }

        public override Servico VerServico(string nomeServico)
        {
            throw new NotImplementedException();
        }

        public Pedido SolicitarServico(Servico servico)
        {
            return null;
        }
        public Avaliacao AvaliarServico(Servico servico, string comentario = null, double avaliar)
        {
            return null;
        }
        
        public int AlterarAvaliacao (Servico servico, Avaliacao avaliacao)
        {
            return 1;
        }
        public int RemoverAvaliacao (Servico servico, Avaliacao avalicao)
        {
            return 1;
        }
    }
}
