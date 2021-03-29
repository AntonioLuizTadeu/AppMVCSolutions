using DevIO.Busines.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DevIO.Busines.Notificacoes
{

    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes;

        //Construtor
        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public Notificador(List<Notificacao> notificacoes)
        {
            _notificacoes = notificacoes;
        }

       

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}
