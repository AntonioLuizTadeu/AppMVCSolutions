using DevIO.Busines.Notificacoes;
using System.Collections.Generic;

namespace DevIO.Busines.Interfaces
{
    public interface INotificador
    {
       
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();

        void Handle(Notificacao notificacao);
    }
}
