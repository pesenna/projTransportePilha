using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projTransporte
{
    class Veiculos
    {
        #region atributos
        List<Veiculo> listDeVeiculos;
        #endregion

        #region propriedades
        public List<Veiculo> ListDeVeiculos { get { return listDeVeiculos; } }
        #endregion

        #region construtores
        public Veiculos()
        {
            listDeVeiculos = new List<Veiculo>();
        }
        #endregion

        #region métodos funcionais

        public void cadastrarVeiculo(Veiculo veiculo)
        {
            listDeVeiculos.Add(veiculo);
        }
        #endregion
    }
}
