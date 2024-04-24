using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondomiNext
{
    public abstract class Usuario
    {
        private int id;
        private string nome;
        private string email;
        private string senha;
        private List<Servico> servicos;

        public int Id { 
            get {
                return id;
            } 
            set {
                id = value;
            } 
        }
        public string Nome {
            get { 
                return nome;
            } 
            set {
                nome = value;
            } 
        }
        public string Email {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string Senha {
            get
            {
                return senha;
            }
            set
            {
                senha = value;
            }
        }
        public List<Servico> Servicos {
            get
            {
                return servicos;
            }
            set
            {
                servicos = value;
            }
        }

        public abstract Servico AdicionarServico();

        public abstract int RemoverServico(Servico servico);

        public abstract int AlterarServico(Servico servico);

        public abstract Servico VerServico(string nomeServico);
    }
}
