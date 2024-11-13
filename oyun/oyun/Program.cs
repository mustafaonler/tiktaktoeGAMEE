using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oyun
{



    class TicTacToe
    {
        // Tahtadaki hücreleri temsil eden bir dizi
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        // Oyuncu sırası (1 = X, -1 = O)
        static int currentPlayer = 1;

        static void Main(string[] args)
        {
            int choice; // Kullanıcının seçtiği hücre
            bool gameOver = false; // Oyunun bitip bitmediğini kontrol eder

            while (!gameOver)
            {
                Console.Clear(); // Ekranı temizler
                DrawBoard(); // Tahtayı çiz

                // Şu anki oyuncuyu ekrana yazdır
                Console.WriteLine($"Oyuncu {(currentPlayer == 1 ? "X" : "O")}'in sırası.");
                Console.WriteLine("Bir hücre seçin (1-9): ");
                choice = int.Parse(Console.ReadLine()) - 1; // Kullanıcının girdiği hücreyi al

                // Seçilen hücre geçerli mi kontrol et
                if (choice < 0 || choice > 8 || board[choice] == 'X' || board[choice] == 'O')
                {
                    Console.WriteLine("Geçersiz seçim! Tekrar deneyin.");
                    Console.ReadKey(); // Geçersiz seçimde bir tuşa basarak devam eder
                    continue; // Hatalı seçimde döngü başa döner
                }

                // Seçilen hücreye X veya O işareti yerleştir
                board[choice] = currentPlayer == 1 ? 'X' : 'O';

                // Kazanan var mı kontrol et
                gameOver = CheckWin();

                // Oyuncu sırasını değiştir
                currentPlayer = currentPlayer == 1 ? -1 : 1;
            }

            // Oyun bitince sonucu yazdır
            Console.Clear();
            DrawBoard();
            Console.WriteLine($"Oyuncu {(currentPlayer == 1 ? "X" : "O")} kazandı!");
        }

        // Tahtayı ekranda çizme fonksiyonu
        static void DrawBoard()
        {
            Console.WriteLine("-----");
            Console.WriteLine($"| {board[0]} | {board[1]} | {board[2]} |");
            Console.WriteLine("-----");
            Console.WriteLine($"| {board[3]} | {board[4]} | {board[5]} |");
            Console.WriteLine("-----");
            Console.WriteLine($"| {board[6]} | {board[7]} | {board[8]} |");
            Console.WriteLine("-----");
        }

        // Kazanma durumu kontrol fonksiyonu
        static bool CheckWin()
        {
            // Kazanma durumlarını kontrol eden diziler
            int[,] winPatterns =
            {
            { 0, 1, 2 }, // Üst satır
            { 3, 4, 5 }, // Orta satır
            { 6, 7, 8 }, // Alt satır
            { 0, 3, 6 }, // Sol sütun
            { 1, 4, 7 }, // Orta sütun
            { 2, 5, 8 }, // Sağ sütun
            { 0, 4, 8 }, // Çapraz 1
            { 2, 4, 6 }  // Çapraz 2
        };

            // Her kazanan satırı kontrol et
            for (int i = 0; i < 8; i++)
            {
                if (board[winPatterns[i, 0]] == board[winPatterns[i, 1]] &&
                    board[winPatterns[i, 1]] == board[winPatterns[i, 2]])
                {
                    return true; // Kazanma durumunda oyun biter
                }
            }

            return false; // Kazanan yoksa false döner

        }
    }
    }