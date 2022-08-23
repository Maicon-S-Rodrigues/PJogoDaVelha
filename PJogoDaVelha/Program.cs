using System;

namespace PJogoDaVelha
{
    internal class Program
    {
        /// Funções
        static void TelaInicial()
            {
            //quando a tela inicial for chamada, o tabuleiro recebera os valores de 1 a 9, zerando-o para um novo jogo
            string[,] tabuleiro = new string[3, 3];
            int jogadorNum = 1;
            int turno = 0;
            //matriz [linha , coluna]
            tabuleiro[0, 0] = "1";
            tabuleiro[0, 1] = "2";
            tabuleiro[0, 2] = "3";
            tabuleiro[1, 0] = "4";
            tabuleiro[1, 1] = "5";
            tabuleiro[1, 2] = "6";
            tabuleiro[2, 0] = "7";
            tabuleiro[2, 1] = "8";
            tabuleiro[2, 2] = "9";
            ///Saudação de inicio de jogo
            Console.WriteLine("\t\t\t\tBem vindo ao Jogo da Véinha!");
            Console.WriteLine("\n\t\t\t\t\tINSTRUÇÕES:");
            Console.WriteLine("\t\t- O Player 1 será o X e o Player 2 será o O!\n" +
                              "\t\t- Quando for sua vez de jogar, digite um número de 1 a 9 para escolher onde por sua marcação!\n" +
                              "\t\t- Os números (1-9) representam onde ficará a sua marcação, não será possível escolher\n" +
                              "\t\tuma que outro player já tenha escolhido!\n" +
                              "\t\t- O primeiro a alinha 3 marcações na HORIZONTAL, VERTICAL ou DIAGONAL vence!\n" +
                              "\t\t- Se ninguém alinhar 3 marcações, o resultado será um EMPATE!\n\n" +
                              "\t\t\t\t\tBOM JOGO!");
            Console.WriteLine("\n\n\t\t\tAperte qualquer tecla para iniciar...");
            Console.ReadKey();
            Console.Clear();
            TurnoDeJogada(tabuleiro, jogadorNum, turno);
            //////////////////////////////////////////////////////////////////////////////////////////////
        }
        static void MostrarTabuleiro(string[,] tabuleiro, int jogadorNum)
        {
            ///Mostrar o tabuleiro na tela e pedir a seleçãoo do jogador:
            Console.WriteLine("\n\n\tSua vez, Player " + jogadorNum + "! Escolha um número do tabuleiro!");
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\t\t\t\t\t  {0}  |   {1}   |  {2} ", tabuleiro[0, 0], tabuleiro[0, 1], tabuleiro[0, 2]);
            Console.WriteLine("\t\t\t\t\t-----+-------+-----");
            Console.WriteLine("\t\t\t\t\t  {0}  |   {1}   |  {2} ", tabuleiro[1, 0], tabuleiro[1, 1], tabuleiro[1, 2]);
            Console.WriteLine("\t\t\t\t\t-----+-------+-----");
            Console.WriteLine("\t\t\t\t\t  {0}  |   {1}   |  {2} ", tabuleiro[2, 0], tabuleiro[2, 1], tabuleiro[2, 2]);
            ///     1   |   2   |   3
            ///    -----+-------+-----
            ///     4   |   5   |   6
            ///    -----+-------+-----
            ///     7   |   8   |   9
        }

        static void MostrarTabuleiroFinal(string[,] tabuleiro)
        {
            ///Mostrar o tabuleiro na tela e pedir a seleçãoo do jogador:
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\t\t\t\t  {0}  |   {1}   |   {2}", tabuleiro[0, 0], tabuleiro[0, 1], tabuleiro[0, 2]);
            Console.WriteLine("\t\t\t\t-----+-------+-----");
            Console.WriteLine("\t\t\t\t  {0}  |   {1}   |   {2}", tabuleiro[1, 0], tabuleiro[1, 1], tabuleiro[1, 2]);
            Console.WriteLine("\t\t\t\t-----+-------+-----");
            Console.WriteLine("\t\t\t\t  {0}  |   {1}   |   {2}", tabuleiro[2, 0], tabuleiro[2, 1], tabuleiro[2, 2]);
            ///     1   |   2   |   3
            ///    -----+-------+-----
            ///     4   |   5   |   6
            ///    -----+-------+-----
            ///     7   |   8   |   9
        }
        static void TurnoDeJogada(string[,] tabuleiro, int jogadorNum, int turno)

        {
            //////sempre que começa um novo jogo, o turno recebe 0 para continuar no laço até o
                          //jogador informar uma escolha valida
            int digitoDoUsuario = 0;

            MostrarTabuleiro(tabuleiro, jogadorNum);

            while (turno == 0)
            {

                try
                {
                    digitoDoUsuario = int.Parse(Console.ReadLine()); //aqui recebe o que o usuario digitar caso seja numero
                    if (digitoDoUsuario > 0 && digitoDoUsuario < 10)
                    {
                        LerJogada(jogadorNum, tabuleiro, digitoDoUsuario, turno);
                        Console.Clear();
                        turno++;                                             
                    }
                    else
                    {
                        Console.WriteLine("\t- Digite um número de 1 a 9 que estiver disponível no tabuleiro para jogar!\n" +
                        "\t- Ou Pressione 'S' para sair do Jogo.");
                    }    
                }
                catch //aqui recebe o que o jogador digitar caso não seja número
                {
                    Console.WriteLine("\t- Digite um número de 1 a 9 que estiver disponível no tabuleiro para jogar!\n" +
                            "\t- Ou Pressione 'S' para sair do Jogo.");
                    string sairDoJogo = Console.ReadLine();
                    if (sairDoJogo == "S" || sairDoJogo == "s")//se o jogador digitar 's' ou 'S' o jogo fecha
                    {
                        Console.Clear();
                        turno++;
                    }
                    else //se for qualquer outro caractere, vai voltar para o inicio do laço, permanecendo no turno
                        //ate escolher uma opção válida
                    {
                        Console.WriteLine("\t- Digite um número de 1 a 9 que estiver disponível no tabuleiro para jogar!\n" +
                            "\t- Ou Pressione 'S' para sair do Jogo.");
                    }                    
                }
            }
        }
        static void LerJogada (int jogadorNum, string[,] tabuleiro, int digitoDoUsuario, int turno)
        {
            ///////////////////////////////////////////////////////////////////////////////////////////
            if(digitoDoUsuario == 1)
            {
                if (tabuleiro[0, 0] == "X" || tabuleiro[0, 0] == "O")
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t\tEii!\n" +
                                              "\t\t\tEssa posição já foi escolhida, tente outra!");
                    TurnoDeJogada(tabuleiro, jogadorNum, turno);
                }
                else
                {
                    if (jogadorNum == 1)
                    {
                        tabuleiro[0, 0] = "X";
                        Console.Clear();
                        validarVitoria(jogadorNum, tabuleiro, turno);
                    }
                    else
                    {
                        tabuleiro[0, 0] = "O";
                        Console.Clear();
                        validarVitoria(jogadorNum, tabuleiro, turno);
                    }          
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////////////
            else if (digitoDoUsuario == 2)
            {
                if (tabuleiro[0,1] == "X" || tabuleiro[0,1] == "O")
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t\tEii!\n" +
                                              "\t\t\tEssa posição já foi escolhida, tente outra!");
                    TurnoDeJogada(tabuleiro, jogadorNum, turno);
                }
                else
                {
                    if (jogadorNum == 1)
                    {
                        tabuleiro[0,1] = "X";
                        Console.Clear();
                        validarVitoria(jogadorNum, tabuleiro, turno);
                    }
                    else
                    {
                        tabuleiro[0,1] = "O";
                        Console.Clear();
                        validarVitoria(jogadorNum, tabuleiro, turno);
                    }
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////////////
            else if(digitoDoUsuario == 3)
            {
                if (tabuleiro[0,2] == "X" || tabuleiro[0,2] == "O")
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t\tEii!\n" +
                                              "\t\t\tEssa posição já foi escolhida, tente outra!");
                    TurnoDeJogada(tabuleiro, jogadorNum, turno);
                }
                else
                {
                    if (jogadorNum == 1)
                    {
                        tabuleiro[0,2] = "X";
                        Console.Clear();
                        validarVitoria(jogadorNum, tabuleiro, turno);
                    }
                    else
                    {
                        tabuleiro[0,2] = "O";
                        Console.Clear();
                        validarVitoria(jogadorNum, tabuleiro, turno);
                    }
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////////////
            else if (digitoDoUsuario == 4)
            {
                if (tabuleiro[1,0] == "X" || tabuleiro[1,0] == "O")
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t\tEii!\n" +
                                              "\t\t\tEssa posição já foi escolhida, tente outra!");
                    TurnoDeJogada(tabuleiro, jogadorNum, turno);
                }
                else
                {
                    if (jogadorNum == 1)
                    {
                        tabuleiro[1,0] = "X";
                        Console.Clear();
                        validarVitoria(jogadorNum, tabuleiro, turno);
                    }
                    else
                    {
                        tabuleiro[1,0] = "O";
                        Console.Clear();
                        validarVitoria(jogadorNum, tabuleiro, turno);
                    }
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////////////
            else if (digitoDoUsuario == 5)
            {
                if (tabuleiro[1,1] == "X" || tabuleiro[1, 1] == "O")
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t\tEii!\n" +
                                              "\t\t\tEssa posição já foi escolhida, tente outra!");
                    TurnoDeJogada(tabuleiro, jogadorNum, turno);
                }
                else
                {
                    if (jogadorNum == 1)
                    {
                        tabuleiro[1, 1] = "X";
                        Console.Clear();
                        validarVitoria(jogadorNum, tabuleiro, turno);
                    }
                    else
                    {
                        tabuleiro[1, 1] = "O";
                        Console.Clear();
                        validarVitoria(jogadorNum, tabuleiro, turno);
                    }
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////////////
            else if (digitoDoUsuario == 6)
            {
                if (tabuleiro[1,2] == "X" || tabuleiro[1, 2] == "O")
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t\tEii!\n" +
                                              "\t\t\tEssa posição já foi escolhida, tente outra!");
                    TurnoDeJogada(tabuleiro, jogadorNum, turno);
                }
                else
                {
                    if (jogadorNum == 1)
                    {
                        tabuleiro[1, 2] = "X";
                        Console.Clear();
                        validarVitoria(jogadorNum, tabuleiro, turno);
                    }
                    else
                    {
                        tabuleiro[1, 2] = "O";
                        Console.Clear();
                        validarVitoria(jogadorNum, tabuleiro, turno);
                    }
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////////////
            else if (digitoDoUsuario == 7)
            {
                if (tabuleiro[2, 0] == "X" || tabuleiro[2, 0] == "O")
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t\tEii!\n" +
                                              "\t\t\tEssa posição já foi escolhida, tente outra!");
                    TurnoDeJogada(tabuleiro, jogadorNum, turno);
                }
                else
                {
                    if (jogadorNum == 1)
                    {
                        tabuleiro[2, 0] = "X";
                        Console.Clear();
                        validarVitoria(jogadorNum, tabuleiro, turno);
                    }
                    else
                    {
                        tabuleiro[2, 0] = "O";
                        Console.Clear();
                        validarVitoria(jogadorNum, tabuleiro, turno);
                    }
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////////////
            else if (digitoDoUsuario == 8)
            {
                if (tabuleiro[2,1] == "X" || tabuleiro[2, 1] == "O")
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t\tEii!\n" +
                                              "\t\t\tEssa posição já foi escolhida, tente outra!");
                    TurnoDeJogada(tabuleiro, jogadorNum, turno);
                }
                else
                {
                    if (jogadorNum == 1)
                    {
                        tabuleiro[2, 1] = "X";
                        Console.Clear();
                        validarVitoria(jogadorNum, tabuleiro, turno);
                    }
                    else
                    {
                        tabuleiro[2, 1] = "O";
                        Console.Clear();
                        validarVitoria(jogadorNum, tabuleiro, turno);
                    }
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////////////
            else if (digitoDoUsuario == 9)
            {
                if (tabuleiro[2, 2] == "X" || tabuleiro[2, 2] == "O")
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t\tEii!\n" +
                                              "\t\t\tEssa posição já foi escolhida, tente outra!");
                    TurnoDeJogada(tabuleiro, jogadorNum, turno);
                }
                else
                {
                    if (jogadorNum == 1)
                    {
                        tabuleiro[2, 2] = "X";
                        Console.Clear();
                        validarVitoria(jogadorNum, tabuleiro, turno);
                    }
                    else
                    {
                        tabuleiro[2, 2] = "O";
                        Console.Clear();
                        validarVitoria(jogadorNum, tabuleiro, turno);
                    }
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////////////
        }
        static void VitoriaJogador1(int jogadorNum, int turno, string[,] tabuleiro)
        {
            MostrarTabuleiroFinal(tabuleiro);
                Console.WriteLine("\n\n\t\t\t\t      PARABÉNS!\n\n" +
                                  "\t\t\t\tVitória do Jogador " + jogadorNum + "!!!!!");
                Console.WriteLine("\n\n\t\t Aperte qualquer tecla para voltar para a tela inicial...");
                Console.ReadKey();
                Console.Clear();
                TelaInicial();               
        }
        static void VitoriaJogador2(int jogadorNum, int turno, string[,] tabuleiro)
        {
            MostrarTabuleiroFinal(tabuleiro);
            Console.WriteLine("\n\n\t\t\t\t      PARABÉNS!\n\n" +
                                  "\t\t\t\tVitória do Jogador " + jogadorNum + "!!!!!");
            Console.WriteLine("\n\n\t\t Aperte qualquer tecla para voltar para a tela inicial...");
            Console.ReadKey();
            Console.Clear();
            TelaInicial();
        }
        static void validarVitoria(int jogadorNum, string[,] tabuleiro, int turno)
        {
            ///////////////////////////////////////////////////////////////////////////////////
            ///VITORIA NA HORIZONTAL (--)
            if (tabuleiro[0,0] == tabuleiro[0,1] && tabuleiro[0,0] == tabuleiro[0,2])
            {
                if (jogadorNum == 1)
                {
                    VitoriaJogador1(jogadorNum, turno, tabuleiro);
                }
                else if (jogadorNum == 2)
                {
                    VitoriaJogador2(jogadorNum, turno, tabuleiro);
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////
            ///VITORIA NA HORIZONTAL (--)
            else if (tabuleiro[1,0] == tabuleiro[1,1] && tabuleiro[1,0] == tabuleiro[1,2])
            {
                if (jogadorNum == 1)
                {
                    VitoriaJogador1(jogadorNum, turno, tabuleiro);
                }
                else if (jogadorNum == 2)
                {
                    VitoriaJogador2(jogadorNum, turno, tabuleiro);
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////
            ///VITORIA NA HORIZONTAL (--)
            else if (tabuleiro[2,0] == tabuleiro[2,1] && tabuleiro[2,0] == tabuleiro[2,2])
            {
                if (jogadorNum == 1)
                {
                    VitoriaJogador1(jogadorNum, turno, tabuleiro);
                }
                else if (jogadorNum == 2)
                {
                    VitoriaJogador2(jogadorNum, turno, tabuleiro);
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////
            ///VITORIA NA VERTICAL (|)
            else if (tabuleiro[0,0] == tabuleiro[1,0] && tabuleiro[0,0] == tabuleiro[2,0])
            {
                if (jogadorNum == 1)
                {
                    VitoriaJogador1(jogadorNum, turno, tabuleiro);
                }
                else if (jogadorNum == 2)
                {
                    VitoriaJogador2(jogadorNum, turno, tabuleiro);
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////
            ///VITORIA NA VERTICAL (|)
            else if (tabuleiro[0,1] == tabuleiro[1,1] && tabuleiro[0,1] == tabuleiro[2,1])
            {
                if (jogadorNum == 1)
                {
                    VitoriaJogador1(jogadorNum, turno, tabuleiro);
                }
                else if (jogadorNum == 2)
                {
                    VitoriaJogador2(jogadorNum, turno, tabuleiro);
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////
            ///VITORIA NA VERTICAL (|)
            else if (tabuleiro[0,2] == tabuleiro[1,2] && tabuleiro[0,2] == tabuleiro[2, 2])
            {
                if (jogadorNum == 1)
                {
                    VitoriaJogador1(jogadorNum, turno, tabuleiro);
                }
                else if (jogadorNum == 2)
                {
                    VitoriaJogador2(jogadorNum, turno, tabuleiro);
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////
            ///VITORIA NA DIAGONAL (\)
            else if (tabuleiro[0,0] == tabuleiro[1,1] && tabuleiro[0,0] == tabuleiro[2,2])
            {
                if (jogadorNum == 1)
                {
                    VitoriaJogador1(jogadorNum, turno, tabuleiro);
                }
                else if (jogadorNum == 2)
                {
                    VitoriaJogador2(jogadorNum, turno, tabuleiro);
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////
            ///VITORIA NA DIAGONAL (/)
            else if (tabuleiro[0,2] == tabuleiro[1,1] && tabuleiro[0,2] == tabuleiro[2,0])
            {
                if (jogadorNum == 1)
                {
                    VitoriaJogador1(jogadorNum, turno, tabuleiro);
                }
                else if (jogadorNum == 2)
                {
                    VitoriaJogador2(jogadorNum, turno, tabuleiro);
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////
            if (tabuleiro[0,0] == "X" || tabuleiro[0,0] == "O")     /////verificar se foi um empate     
            {
                if (tabuleiro[0, 1] == "X" || tabuleiro[0, 1] == "O")
                {
                    if (tabuleiro[0, 2] == "X" || tabuleiro[0, 2] == "O")
                    {
                        if (tabuleiro[1, 0] == "X" || tabuleiro[1, 0] == "O")
                        {
                            if (tabuleiro[1, 1] == "X" || tabuleiro[1, 1] == "O")
                            {
                                if (tabuleiro[1, 2] == "X" || tabuleiro[1, 2] == "O")
                                {
                                    if (tabuleiro[2, 0] == "X" || tabuleiro[2, 0] == "O")
                                    {
                                        if (tabuleiro[2, 1] == "X" || tabuleiro[2, 1] == "O")
                                        {
                                            if (tabuleiro[2, 2] == "X" || tabuleiro[2, 2] == "O")
                                            {
                                                MostrarTabuleiroFinal(tabuleiro);
                                                Console.WriteLine("\n\n\t\t\t\t\tOOPS!\n\n" +
                                                                  "\t\t\t\tA partida foi um EMPATE!!!");
                                                Console.WriteLine("\n\n\t\tAperte qualquer tecla para voltar para a tela inicial...");
                                                Console.ReadKey();
                                                Console.Clear();
                                                TelaInicial();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////verificar se foi um empate ^^^^^^

            ///SE NENHUMA DAS CONDIÇÕES DE VITÓRIA FOR ATENDIDA, A RODADA CONTINUA:
            if (jogadorNum == 1)
            {
                jogadorNum = 2;
                TurnoDeJogada(tabuleiro, jogadorNum, turno);

            }
            else
            {
                jogadorNum = 1;
                TurnoDeJogada(tabuleiro, jogadorNum, turno);
            }
        }
        static void Main(string[] args)
        {
            ///CHAMADA DAS FUNÇÕES//Inicialização do Jogo:
            TelaInicial();
        }
    }
}
