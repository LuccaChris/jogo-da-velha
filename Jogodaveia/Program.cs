using System;

namespace Jogodaveia
{
    public class Program
    {
        static char[] tabuleiro = new char[] { '1','2','3','4','5','6','7','8','9' };
        static int Jogador = 1;

        static void Main()
        {
            int escolha;
            int status = 0;
            int jogadorAtual = 1;  // variável para armazenar o jogador da vez

            do
            {
               // Console.Clear();
                Console.WriteLine("Tabuleiro:");
                ExibicaoTabuleiro();

                jogadorAtual = Jogador;

                Console.WriteLine($"\nJogador {(jogadorAtual % 2 == 0 ? 2 : 1)}, escolha uma posição de 1 a 9:");
                while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 9 || tabuleiro[escolha - 1] == 'X' || tabuleiro[escolha - 1] == 'O')
                {
                    Console.WriteLine("Escolha inválida, tente novamente.");
                }

                tabuleiro[escolha - 1] = jogadorAtual % 2 == 0 ? 'O' : 'X';

                status = VerificaVitoria();
                Jogador++;

            } while (status == 0);

            Console.Clear();
            ExibicaoTabuleiro();
            if (status == 1)
                Console.WriteLine($"\n>> Jogador {(jogadorAtual % 2 == 0 ? 2 : 1)} venceu!");
            else
                Console.WriteLine("\n>> Empate!");

            Console.WriteLine("Pressione qualquer tecla para sair.");
            Console.ReadKey();
        }

        static void ExibicaoTabuleiro()
        {
            Console.WriteLine($" {tabuleiro[0]} | {tabuleiro[1]} | {tabuleiro[2]}");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {tabuleiro[3]} | {tabuleiro[4]} | {tabuleiro[5]}");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {tabuleiro[6]} | {tabuleiro[7]} | {tabuleiro[8]}");
        }

        private static int VerificaVitoria()
        {
            int[,] posicoesVitoria = new int[,]
            {
                { 0, 1, 2 },
                { 3, 4, 5 },
                { 6, 7, 8 },
                { 0, 3, 6 },
                { 1, 4, 7 },
                { 2, 5, 8 },
                { 0, 4, 8 },
                { 2, 4, 6 }
            };

            for (int i = 0; i < posicoesVitoria.GetLength(0); i++)
            {
                int a = posicoesVitoria[i, 0];
                int b = posicoesVitoria[i, 1];
                int c = posicoesVitoria[i, 2];

                if (tabuleiro[a] == tabuleiro[b] && tabuleiro[b] == tabuleiro[c])
                    return 1;
            }

            foreach (char c in tabuleiro)
                if (char.IsDigit(c))
                    return 0;

            return -1;
        }
    }
}