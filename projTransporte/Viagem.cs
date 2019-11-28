using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projTransporte
{
    class Viagem
    {
        #region atributos

        static int temp = 1;
        static int Incrementar() { return temp++; }
        int id = 0;
        Garagem origem, destino;
        Veiculo veiculo;
        #endregion

        #region propriedades

        public int Id { get { return id; } set { id = value; } }
        public Garagem Origem { get { return origem; } set { origem = value; } }
        public Garagem Destino { get { return destino; } set { destino = value; } }
        public Veiculo Veiculo { get { return veiculo; } set { veiculo = value; } }
        #endregion

        #region construtores
        public Viagem()
        {

        }

        public Viagem(Veiculo veiculo, Garagem origem, Garagem destino)
        {
            this.id = Incrementar();
            this.Origem = origem;
            this.Destino = destino;
            this.veiculo = veiculo;
        }

        #endregion

        #region sobreescritas

        public override bool Equals(object obj)
        {
            Viagem v = (Viagem)obj;
            return this.id.Equals(v.Id);
        }

        #endregion
    }
}
