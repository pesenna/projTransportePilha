using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projTransporte
{
    class Garagens
    {
        #region atributos
        List<Garagem> listaDeGaragens;
        private bool jornadaAtiva;
        List<Transporte> listaTransporte;
        #endregion

        #region propriedades
        public List<Garagem> ListaDeGaragens { get { return listaDeGaragens; } set { listaDeGaragens = value; } }
        public bool JornadaAtiva { get { return jornadaAtiva; } }
        #endregion

        #region construtores


        public Garagens()
        {
            this.jornadaAtiva = false;
            listaDeGaragens = new List<Garagem>();
            listaTransporte = new List<Transporte>();
        }
        #endregion

        #region metodos funcionais
        public void incluirGaragem(Garagem garagem)

        {
            if (!listaDeGaragens.Contains(garagem))
                listaDeGaragens.Add(garagem);
        }

        public void inciarJornada(List<Veiculo> listVei)
        {
            int x = ListaDeGaragens.Count() - 1;
            foreach (Veiculo vei in listVei)
            {
                x = x % listaDeGaragens.Count;
                ListaDeGaragens[x].PilhaVeiculos.Push(vei);
                x++;
            }
            jornadaAtiva = true;

        }
        public List<Transporte> encerrarJornada()
        {

            this.jornadaAtiva = false;

            return listaTransporte;

        }
        #endregion
    }
}
