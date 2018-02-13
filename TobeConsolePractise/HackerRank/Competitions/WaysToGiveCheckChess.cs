using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class WaysToGiveCheckChess
    {
        static int waysToGiveACheck(char[][] board)
        {
            int ways = 0;

            //check seventh row for viable pawn to promote
            int pawnPos=0;
            for (int i = 0; i < 8; i++)
            {
                if (board[1][i] == 'P')
                {
                    if ((i == 0 && board[0][1] == '#') || (i == 7 && board[0][6] == '#') || 
                        ((i != 0 || i != 7) && board[0][i + 1] == '#' && board[0][i - 1] == '#'))
                    {
                        pawnPos = i;
                        break;
                    }
                }
            }

            ways += Queen(pawnPos, board);
            ways += Rook(pawnPos, board);
            ways += Bishop(pawnPos, board);
            ways += Knight(pawnPos, board);
            
            return ways;
        }

        static int Queen(int pos, char[][] board)
        {
            int ways=0;

            if (pos == 0) //(8,0)
            {
                //horizontally
                for (int i = 1; i < 8; i++)
                {
                    if (board[0][i] != 'k') break;
                    if (board[0][i] == 'k') return ++ways;
                }
                //vertically
                for (int i = 1; i < 8; i++)
                {
                    if (board[i][0] != 'k') break;
                    if (board[i][0] == 'k') return ++ways;
                }
                //diagonally
                for (int i = 1, j = 1; i < 8 && j < 8; i++, j++)
                {
                    if (board[i][j] != 'k') break;
                    if (board[i][j] == 'k') return ++ways;
                }
            }
            else if (pos == 7)
            {
                //horizontally
                for (int i = 6; i >=0; i--)
                {
                    if (board[7][i] != 'k') break;
                    if (board[7][i] == 'k') return ++ways;
                }
                //vertically
                for (int i = 6; i >=0; i--)
                {
                    if (board[i][7] != 'k') break;
                    if (board[i][7] == 'k') return ++ways;
                }
                //diagonally
                for (int i = 1, j = 1; i < 8 && j < 8; i++, j++)
                {
                    if (board[i][j] != 'k') break;
                    if (board[i][j] == 'k') return ++ways;
                }
            }
            else
            {
                //left check
            }

            return ways;
        }

        static int Rook(int pos, char[][] board)
        {
            int ways = 0;

            if (pos == 0)
            {

            }
            else if (pos == 7)
            {

            }
            else
            {

            }

            return 1;
        }

        static int Bishop(int pos, char[][] board)
        {
            int ways = 0;

            if (pos == 0)
            {

            }
            else if (pos == 7)
            {

            }
            else
            {

            }

            return ways;
        }

        static int Knight(int pos, char[][] board)
        {
            int ways = 0;

            if (pos == 0)
            {

            }
            else if (pos == 7)
            {

            }
            else
            {

            }

            return ways;
        }

        static void Run()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                char[][] board = new char[8][];
                for (int board_i = 0; board_i < 8; board_i++)
                {
                    string[] board_temp = Console.ReadLine().Split(' ');
                    board[board_i] = Array.ConvertAll(board_temp, Char.Parse);
                }
                int result = waysToGiveACheck(board);
                Console.WriteLine(result);
            }
        }
    }
}
