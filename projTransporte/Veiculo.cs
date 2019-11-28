using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projTransporte
{
    class Veiculo
    {
        #region atributos
        static int temp = 1;
        static int Incrementar()
        {
            return temp++;
        }
        int id;
        private string placa;
        int lotacao;
        #endregion

        #region propriedades
        public int Lotacao { get { return lotacao; } }
        public int Id { get { return id; } set { id = value; } }
        public string Placa { get { return placa; } }
        #endregion

        #region construtores

        public Veiculo(string placa, int lotacao)
        {
            this.id = Incrementar();
            this.lotacao = lotacao;
            this.placa = placa;
        }
        #endregion

        #region sobreescritas

        public override bool Equals(object obj)
        {
            Veiculo v = (Veiculo)obj;
            return this.Id.Equals(v.Id);
        }

        #endregion
    }
}
