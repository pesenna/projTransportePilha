using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projTransporte
{
    class Program
    {
        #region atributos

        static Garagens garagens;
        static Veiculos frota;
        static Viagens viagens;
        static int opcao;
        #endregion
        static void Main(string[] args)
        {
            garagens = new Garagens();
            frota = new Veiculos();
            viagens = new Viagens();

            // Criando e instanciando as classes
            carregamentoInicial();

            // Menu
            construaOMenu();

        }


        #region funções

        static void carregamentoInicial()
        {
            Garagem congonhas = new Garagem("Congonhas");
            Garagem guarulhos = new Garagem("Guarulhos");
            garagens.incluirGaragem(congonhas);
            garagens.incluirGaragem(guarulhos);
            Veiculo van1 = new Veiculo("AAA-1234", 8);
            Veiculo van2 = new Veiculo("BBB-1234", 8);
            Veiculo van3 = new Veiculo("CCC-1242", 8);
            Veiculo van4 = new Veiculo("DDD-4324", 8);
            Veiculo van5 = new Veiculo("EEE-3211", 8);
            Veiculo van6 = new Veiculo("FFF-4321", 8);
            Veiculo van7 = new Veiculo("GGG-3214", 8);
            Veiculo van8 = new Veiculo("HHH-2432", 8);
            frota.cadastrarVeiculo(van1);
            frota.cadastrarVeiculo(van2);
            frota.cadastrarVeiculo(van3);
            frota.cadastrarVeiculo(van4);
            frota.cadastrarVeiculo(van5);
            frota.cadastrarVeiculo(van6);
            frota.cadastrarVeiculo(van7);
            frota.cadastrarVeiculo(van8);
        }

        static void construaOMenu()
        {

            do
            {
                Console.Clear();
                Console.SetCursorPosition(10, 04); println("----------------------------------------------------------------------------------------------------------");
                Console.SetCursorPosition(10, 05); println("|                                         GARAGEM                                                        |");
                Console.SetCursorPosition(10, 06); println("| 1. Cadastrar veículo                                                                                   |");
                Console.SetCursorPosition(10, 07); println("| 2. Cadastrar garagem                                                                                   |");
                Console.SetCursorPosition(10, 08); println("| 3. Iniciar jornada                                                                                     |");
                Console.SetCursorPosition(10, 09); println("| 4. Encerrar jornada                                                                                    |");
                Console.SetCursorPosition(10, 10); println("| 5. Liberar viagem de uma determinada origem para um determinado destino                                |");
                Console.SetCursorPosition(10, 11); println("| 6. Listar veículos em determinada garagem (informando a qtde de veículos e seu potencial de transporte)|");
                Console.SetCursorPosition(10, 12); println("| 7. Informar qtde de viagens efetuadas de uma determinada origem para um determinado destino            |");
                Console.SetCursorPosition(10, 13); println("| 8. Listar viagens efetuadas de uma determinada origem para um determinado destino                      |");
                Console.SetCursorPosition(10, 14); println("| 9. Informar qtde de passageiros transportados de uma determinada origem para um determinado destino    |");
                Console.SetCursorPosition(10, 15); println("| 0. Sair                                                                                                |");
                Console.SetCursorPosition(10, 16); println("----------------------------------------------------------------------------------------------------------");


                Console.SetCursorPosition(10, 20); opcao = recebeInt("Opção: ");
                println("");
                switch (opcao)
                {
                    case 1: cadastraVeiculo(); break;
                    case 2: cadastrarGaragem(); break;
                    case 3: iniciarJornada(); break;
                    case 4: encerrarJornada(); break;
                    case 5: liberarViagem(); break;
                    case 6: listarVeicPorGaragem(); break;
                    case 7: informarQuantViagens(); break;
                    case 8: listarViagens(); break;
                    case 9: informarQuantPassageiros(); break;
                }

            } while (opcao != 0);
        }

        // 1. Cadastrar veículo
        // Cadastros de novos veículos e novas garagens só podem ser realizados com a jornada diária encerrada.
        static void cadastraVeiculo()
        {
            if (!garagens.JornadaAtiva)
            {
                string placa;
                int lotacao;

                println("");
                println("");
                print("Digite a placa: ");
                placa = Console.ReadLine();
                lotacao = recebeInt("Informe a lotação: ");
                frota.cadastrarVeiculo(new Veiculo(placa, lotacao));
            }
            else
            {
                println("");
                println("Jornada já foi iniciada");
            }
            Console.ReadKey();
        }

        // 2. Cadastrar garagem
        // Cadastros de novos veículos e novas garagens só podem ser realizados com a jornada diária encerrada.
        static void cadastrarGaragem()
        {
            if (!garagens.JornadaAtiva)
            {
                println("");
                println("Informe o nome da garagem: ");
                println("");
                print("");
                string nomeGaragem = Console.ReadLine();
                println("");
                println("Você inseriu a garagem " + nomeGaragem + ", confirmar?");
                println("");
                int opcao = recebeInt("1 - Sim | 2 - Não --> ");
                switch (opcao)
                {
                    case 1:
                        try
                        {
                            Garagem garagem = new Garagem(nomeGaragem);
                            garagens.incluirGaragem(garagem);
                            println("");
                            println("Garagem adicionada com sucesso!");
                            print("");
                            Console.ReadKey();
                            construaOMenu();
                        }
                        catch
                        {

                        }
                        break;
                    case 2: print(""); break;
                }
                Console.ReadKey();
            }
            else
            {
                println("");
                println("Jornada já foi iniciada");
                print("");
            }
            Console.ReadKey();
        }
        // 3. Iniciar jornada
        // Todo início de jornada diária, os veículos são alternadamente distribuídos entre os destinos (garagens).
        static void iniciarJornada()
        {

            if (!garagens.JornadaAtiva)
            {
                garagens.inciarJornada(frota.ListDeVeiculos);
                print("Jornada iniciada com sucesso!");

            }
            else
            {
                print("Jornada já foi iniciada");
            }
            Console.ReadKey();
        }

        // 4. Encerrar jornada
        // O encerramento da jornada consiste na geração de uma lista informando, veículo a veículo, a quantidade
        // de passageiros transportados com a "limpeza" das ocorrências das viagens anteriores.
        static void encerrarJornada()
        {

            garagens.encerrarJornada();
            foreach (Veiculo veiculo in frota.ListDeVeiculos)
            {
                foreach (Viagem viagem in viagens.ListaDeViagens)
                {
                    if (viagem.Veiculo.Equals(veiculo))
                    {
                        println("Veiculo: " + veiculo.Id + ". " + " Placa: " + veiculo.Placa + " Transportados: " + veiculo.Lotacao + " Origem: " + viagem.Origem.Local + " Destino " + viagem.Destino.Local);
                    }
                }
            }
            frota = new Veiculos();

            print("Fim da Jornada!");
            Console.ReadKey();

        }

        // 5. Liberar viagem de uma determinada origem para um determinado destino
        // Uma viagem só pode ser liberada quando a jornada diária foi iniciada.
        // 
        // Sempre que a lotação de um carro está completa, este sai em direção ao destino e, lá chegando, é
        // estacionado na garagem.
        //
        //Quando um estacionamento fica vazio, uma nova viagem só pode ser iniciada desta origem quando um
        //veículo retornar à garagem.
        static void liberarViagem()
        {
            int idOrigem, idDestino;

            Veiculo veiculo;
            Garagem garOrigem = null, garDestino = null;


            if (garagens.JornadaAtiva)
            {
                mostreGaragens();
                // recolhe do teclado o id e armazena
                idOrigem = recebeInt("Digite o ID origem: ");
                // faz a mesma coisa com o destino
                idDestino = recebeInt("Digite o ID destino: ");
                // quantos passageiros: 
                foreach (Garagem garagem in garagens.ListaDeGaragens)
                {
                    if (garagem.Id == idOrigem)
                        garOrigem = garagem;
                    if (garagem.Id == idDestino)
                        garDestino = garagem;
                }
                if (garOrigem == null && garDestino == null)
                {
                    println("Origem ou Destino não existem");
                }
                else if (garOrigem.Id == garDestino.Id)
                {
                    println("Origem igual destino");
                }
                else if (garOrigem.PilhaVeiculos.Count() != 0)
                {
                    veiculo = garOrigem.PilhaVeiculos.Pop();
                    garDestino.PilhaVeiculos.Push(veiculo);
                    Viagem viagem = new Viagem(veiculo, garOrigem, garDestino);
                    Transporte tranporte = new Transporte(veiculo, veiculo.Lotacao);
                    println("\nViagem iniciada com sucesso!");
                    //incluir viagem na lista
                    viagens.incluirViagem(viagem);
                }
                else println("\nGaragem vazia");
            }
            else
            {
                println("");
                println("Jornada ainda não foi iniciada");
                print("");
            }
            Console.ReadKey();
        }

        // 6. Listar veículos em determinada garagem (informando a qtde de veículos e seu potencial de transporte)
        static void listarVeicPorGaragem()
        {
            if (garagens.JornadaAtiva)
            {
                mostreGaragens();
                int idGaragem = recebeInt("Qual o ID da Garagem: ");
                foreach (Garagem g in garagens.ListaDeGaragens)
                {
                    if (g.Id == idGaragem)
                    {
                        println("");
                        println("Garagem: " + g.Local);
                        println("Potencial de transporte: " + g.potencialDeTransporte());
                        println("");
                        foreach (Veiculo v in g.PilhaVeiculos)
                        {
                            println("Veículo id: " + v.Id + " - Lotação: " + v.Lotacao);
                        }
                        println("");
                    }
                }
            }
            else
            {
                println("");
                println("Jornada ainda não foi iniciada");
                println("");
            }
            Console.ReadKey();
        }

        // 7. Informar qtde de viagens efetuadas de uma determinada origem para um determinado destino
        static void informarQuantViagens()
        {
            int idOrigem, idDestino, contViagem = 0;
            if (garagens.JornadaAtiva)
            {
                mostreGaragens();

                // recolhe do teclado o id e armazena
                idOrigem = recebeInt("Digite o ID origem: ");
                // faz a mesma coisa com o destino
                idDestino = recebeInt("Digite o ID destino: ");
                if (viagens.ListaDeViagens.Count != 0)
                {
                    foreach (Viagem viagem in viagens.ListaDeViagens)
                    {
                        if (viagem.Origem.Id == idOrigem && viagem.Destino.Id == idDestino)
                            ++contViagem;
                    }
                    println("Esse trecho possui " + contViagem + " viagen(s) feita(s)");
                }
                if (contViagem == 0)
                {

                    println("");
                    println("Esse trecho ainda não possui viagens feitas");
                    println("");
                }
            }
            else
            {
                println("");
                println("Jornada ainda não foi iniciada");
                print("");
            }
            Console.ReadKey();

        }

        // 8. Listar viagens efetuadas de uma determinada origem para um determinado destino
        static void listarViagens()
        {
            int idOrigem, idDestino;

            if (garagens.JornadaAtiva)
            {
                mostreGaragens();
                // recolhe do teclado o id e armazena
                idOrigem = recebeInt("Digite o ID origem: ");
                // faz a mesma coisa com o destino
                idDestino = recebeInt("Digite o ID destino: ");
                if (viagens.ListaDeViagens.Count != 0 && idDestino != idOrigem)
                {
                    foreach (Viagem viagem in viagens.ListaDeViagens)
                    {
                        if (viagem.Origem.Id == idOrigem && viagem.Destino.Id == idDestino)
                            println("");
                        println("Lista de viagens:");
                        println("Viagem nº: " + viagem.Id + ". Origem: " + viagem.Origem.Local + " Destino: " + viagem.Destino.Local);
                    }
                }
                else
                {
                    println("");
                    println("Esse trecho ainda não possui viagens feitas");
                    println("");
                }
            }
            else
            {
                println("");
                println("Jornada ainda não foi iniciada");
                print("");
            }
            Console.ReadKey();
        }

        // 9. Informar qtde de passageiros transportados de uma determinada origem para um determinado destino
        static void informarQuantPassageiros()
        {
            int idOrigem, idDestino, quantidade = 0;

            if (garagens.JornadaAtiva)
            {
                mostreGaragens();
                // recolhe do teclado o id e armazena
                idOrigem = recebeInt("Digite o ID origem: ");
                // faz a mesma coisa com o destino
                idDestino = recebeInt("Digite o ID destino: ");
                if (viagens.ListaDeViagens.Count != 0)
                {
                    foreach (Viagem viagem in viagens.ListaDeViagens)
                    {
                        if (viagem.Origem.Id == idOrigem && viagem.Destino.Id == idDestino)
                            quantidade += viagem.Veiculo.Lotacao;
                    }
                    println("Esse trecho possui " + quantidade + " passageiros transportados");
                }
                else
                {
                    println("");
                    println("Esse trecho ainda não possui viagens feitas");
                    println("");
                }
            }
            else
            {
                println("");
                println("Jornada ainda não foi iniciada");
                print("");
            }
            Console.ReadKey();
        }
        #endregion

        #region métodos para entrada e saída de dados via teclado

        static public int recebeInt(String str)
        {
            try
            {
                print(str);
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                println("");
                println("Digite um número inteiro\n");
                return recebeInt(str);
            }
        }

        static public void print(string arg)
        {
            Console.Write("   " + arg);
        }

        static public void println(string arg)
        {
            Console.WriteLine("   " + arg);
        }

        static void mostreGaragens()
        {
            println("");
            println("Origens e destinos possíveis:\n");
            println("ID  |  GARAGEM");

            foreach (Garagem g in garagens.ListaDeGaragens)
            {
                println(g.Id + ". " + g.Local);
            }
            println("");
        }
        #endregion
    }
}
