using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondomiNextCore.Table
{
    public class Administrador : Morador
    {
        public string Id_ADmin { get; }
        public Administrador(string idMorador, string nome, string email, string senha)
        {
            Id_ADmin = idMorador;
            Nome = nome;
            Email = email;
            Senha = senha;

        }


        public void AdicionarMorador()
        {

        }

        public void ConfirmarFornecedorExterno()
        {

        }
    }
}
