using CondomiNextCore.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondomiNextCore.Controller
{
    public class MoradorController
    {

        private bool _morador_existe = false;
        public Morador Login(string id_morador, string senha)
        {
            using (var contexto = new CondomiNextContext())
            {
                IList<Morador> moradores = contexto.Moradores.ToList();

                foreach (var morador in moradores)
                {
                    if (morador.IdMorador == id_morador && morador.Senha == senha)
                    {
                        return morador;
                    }
                }
            }
            return null;
        }

        public string CadastrarMorador(string IdMorador, string senha, string nome, string email)
        {
            Morador m = new Morador();
            m.IdMorador = IdMorador;
            m.Senha = senha;
            m.Nome = nome;
            m.Email = email;
            using (var contexto = new CondomiNextContext())
            {
                string msgConfirmacao = VerificarSeExisteMorador(m);
                if (!_morador_existe)
                {
                    contexto.Moradores.Add(m);
                    contexto.SaveChanges();
                }
                return msgConfirmacao;
            }
        }

        public IList<Servico> VerServicos()
        {
            using (var contexto = new CondomiNextContext())
            {
                IList<Servico> servicos = contexto.Servicos.ToList();
                return servicos;
            }

        }

        public IList<Servico> FiltrarServicos(string filtro)
        {
            using (var contexto = new CondomiNextContext())
            {
                IList<Servico> servicos = contexto.Servicos.Where(item => item.Nome.Contains(filtro)).ToList();
                return servicos;
            }
        }

        private string VerificarSeExisteMorador(Morador morador)
        {
            using (var contexto = new CondomiNextContext())
            {
                IList<Morador> moradores = contexto.Moradores.ToList();

                foreach (var m in moradores)
                {
                    if (m.IdMorador == morador.IdMorador)
                    {
                        _morador_existe = true;
                        return "Já existe um morador com esse Id, por favor verifico com o ADM do sistema de seu condominio";
                    }
                }
            }

            _morador_existe = false;
            return "Parabéns cadastro feito com sucesso !";
        }

        public void SolicitarServico(Servico servico, string IdMorador)
        {
            Pedido p = new Pedido();
            p.IdServico = servico.Id;
            p.IdMorador = IdMorador;
            using (var contexto = new CondomiNextContext())
            {
                contexto.Pedidos.Add(p);
                contexto.SaveChanges();
            }


        }

        public void FazerAvaliacao(Servico servico, string IdMorador, string comentario = "", double nota = 5)
        {
            Avaliacao a = new Avaliacao();
            a.Descricao = comentario;
            a.IdServico = servico.Id;
            a.IdMorador = IdMorador;
            a.Nota = nota;
            
            using (var contexto = new CondomiNextContext())
            {
                contexto.Avaliacoes.Add(a);
                contexto.SaveChanges();
            }

            ServicoController s = new ServicoController();
            s.MediaAvaliacaoServico(servico);
           




        }
    }
}
