using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projTransporte
{
    class Viagens
    {
        #region atributos

        List<Viagem> listaDeViagens;

        #endregion

        #region propriedades

        public List<Viagem> ListaDeViagens { get { return listaDeViagens; } set { listaDeViagens = value; } }

        #endregion

        #region construtores

        public Viagens()
        {
            listaDeViagens = new List<Viagem>();
        }

        #endregion

        #region métodos funcionais

        public bool incluirViagem(Viagem viagem)
        {
            ListaDeViagens.Add(viagem);
            return true;
        }

        #endregion
    }
}
