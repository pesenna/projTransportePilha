using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projTransporte
{
    class Transporte
    {
        #region atributos
        Veiculo veiculo;
        int qtdeTransportada;
        #endregion

        #region propriedades        
        internal Veiculo Veiculo { get { return veiculo; } set { veiculo = value; } }
        public int QtdeTransportada { get { return qtdeTransportada; } set { qtdeTransportada = value; } }
        #endregion
        #region construtor
        public Transporte(Veiculo veiculo, int quantidade)
        {
            this.veiculo = veiculo;
            this.qtdeTransportada = quantidade;
        }
        #endregion
    }
}
