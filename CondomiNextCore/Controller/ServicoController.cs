using CondomiNextCore.Table;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CondomiNextCore.Controller
{
    public class ServicoController
    {
        private bool _servico_existe = false;

        public string CriarServico(string IdPrestador, string descricao, string nome)
        {
            
            Servico s = new Servico();
            s.IdPrestador = IdPrestador;
            s.Descricao = descricao;
            s.Nome = nome;
            using (var contexto = new CondomiNextContext())
            {
                string msgConfirmacao = VerificarSeExisteServico(s);
                if (!_servico_existe)
                {
                    contexto.Servicos.Add(s);
                    contexto.SaveChanges();
                }
               
                return msgConfirmacao;
            }
        }

        public void RemoverServico(string titulo)
        {
            using (var context = new CondomiNextContext())
            {
                IList<Servico> servicos = context.Servicos.Where(item => item.Nome.Equals(titulo)).ToList();
                foreach (var item in servicos)
                {
                    context.Servicos.Remove(item);
                }

                context.SaveChanges();
            }
        }

        private string VerificarSeExisteServico(Servico servico)
        {
            using (var contexto = new CondomiNextContext())
            {
                
                    IList<Servico> servicos = contexto.Servicos.ToList();

                    foreach (var s in servicos)
                    {
                        if (s.IdPrestador == servico.IdPrestador && s.Nome == servico.Nome)
                        {
                            _servico_existe = true;
                            return "Já existe um serviço com esse nome e que você está prestando";
                        }
                    }
            }
                
                

            _servico_existe = false;
                return "Parabéns cadastro feito com sucesso !";
           
            
        }

        public IList<Pedido> VerPedidosDesteServico (Servico servico)
        {
            using (var context = new CondomiNextContext())
            {
                IList<Pedido> pedidos = context.Pedidos.Where(item => item.IdServico.Equals(servico.Id)).ToList();
                return pedidos;
            }
        }

        public void MediaAvaliacaoServico(Servico servico)
        {
            using (var context = new CondomiNextContext())
            {
                IList<double> notas = context.Avaliacoes.Where(a => a.IdServico.Equals(servico.Id)).Select(a => a.Nota).ToList();
                servico.Media = notas.Average();
                context.Servicos.Update(servico);
                context.SaveChanges();
            }
        }

        public IList<Avaliacao> VerAvaliacoes(Servico servico)
        {
            using (var context = new CondomiNextContext())
            {
                IList<Avaliacao> avaliacoes = context.Avaliacoes.Where(a => a.IdServico.Equals(servico.Id)).ToList();
                return avaliacoes;
            }
        }
        
       

    }
}
