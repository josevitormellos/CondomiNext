using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondomiNextCore.Table
{
    public interface IUsuario
    {


        public abstract void AdicionarServico(string nome, string descricao);

        public abstract void RemoverServico(Servico servico);

        public abstract void AlterarServico(Servico servico);

        public abstract List<Servico> VerMeusServico();
    }
}
