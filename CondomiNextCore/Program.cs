using CondomiNextCore.Controller;
using CondomiNextCore.Table;
using System.Linq;

AdicionarAvaliacao(2.5);
AdicionarAvaliacao(3.7);
AdicionarAvaliacao(5);
AdicionarAvaliacao(1);


void RecuperarMoradores()
{
    using ( var contexto = new CondomiNextContext())
    {
        IList<Morador> moradores = contexto.Moradores.ToList();
        foreach(var morador in moradores)
        {
            Console.WriteLine(morador.Nome);
        }
    }
}
void RecuperarServicos()
{
    MoradorController m = new MoradorController();
    IList<Servico> servicos = m.VerServicos();
    foreach(Servico servico in servicos)
    {
        Console.WriteLine($"{servico.Nome}");   
    }
}

string GravarUsandoEntity()
{
    MoradorController morador = new MoradorController();
    return morador.CadastrarMorador("bl1apt503", "bernardo2", "Bernardo Madeira", "bernardoMadeira@gmail.com");

}

string CriarServico()
{
    ServicoController servico = new ServicoController();


    return servico.CriarServico("bl3apt503", "descricao", "Salva Vidas");

}

void RemoverUmServico(string titulo)
{
    ServicoController servico = new ServicoController();
    servico.RemoverServico(titulo);
}

void AdicionarAvaliacao(double nota)
{
    MoradorController m = new MoradorController();
    using (var contexto = new CondomiNextContext())
    {
        IList<Servico> servico = contexto.Servicos.ToList();
        m.FazerAvaliacao(servico[0], "bl3apt506", "Uma beleza de servico", nota);


    }
    
}

void VerPedidos()
{
    ServicoController s = new ServicoController();
    using (var contexto = new CondomiNextContext())
    {
        IList<Servico> servico = contexto.Servicos.ToList();
        s.VerPedidosDesteServico(servico[0]);


    }
}