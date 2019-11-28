using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projTransporte
{
    class Garagem
    {
        #region atributos
        int id;
        static int temp = 1;
        static int Incrementar()
        {
            return temp++;
        }

        string local;
        Stack<Veiculo> pilhaDeVeiculos;
        #endregion

        #region propriedades
        public int Id { get { return id; } }
        public string Local { get { return local; } set { local = value; } }
        public Stack<Veiculo> PilhaVeiculos { get { return pilhaDeVeiculos; } set { pilhaDeVeiculos = value; } }

        #endregion

        #region construtores
        public Garagem(int id) : this("")
        {

        }

        public Garagem(string local)
        {
            pilhaDeVeiculos = new Stack<Veiculo>();
            this.Local = local;
            this.id = Incrementar();
        }

        #endregion

        #region métodos funcionais

        /// <summary>
        /// Método para contar veiculos na pilha de veiculos
        /// </summary>
        /// <returns>retorna um inteiro com o somátório de veículos na garagem</returns>
        public int qtdeVeiculos()
        {
            return pilhaDeVeiculos.Count();
        }

        /// <summary>
        /// Método para somar o potencial de transporte corrente na garagem
        /// </summary>
        /// <returns>retorna um inteiro com o somatorio de vagas em todos os veiculos na garagem</returns>
        public int potencialDeTransporte()
        {
            int potencial = 0;
            foreach (Veiculo v in pilhaDeVeiculos)
            {
                potencial += v.Lotacao;
            }
            return potencial;
        }

        #endregion

        #region sobreescritas

        public override bool Equals(object obj)
        {
            Garagem g = (Garagem)obj;
            return this.Local.Equals(g.Local);
        }
        #endregion
    }
}
