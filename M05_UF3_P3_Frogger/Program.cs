using System;
using System.Collections.Generic;
using System.Linq;

namespace M05_UF3_P3_Frogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // Carreteras
            Lane[] lanes = new Lane[10];
            lanes[0] = new Lane(2, false, ConsoleColor.Blue, true, false, 0.03f, Utils.charCars, Utils.colorsLogs.ToList());
            lanes[1] = new Lane(3, true, ConsoleColor.Green, false, true, 0.1f, Utils.charLogs, Utils.colorsLogs.ToList());
            lanes[2] = new Lane(4, false, ConsoleColor.Blue, true, false, 0.03f, Utils.charCars, Utils.colorsLogs.ToList());
            lanes[3] = new Lane(5, true, ConsoleColor.Green, false, true, 0.1f, Utils.charLogs, Utils.colorsLogs.ToList());
            lanes[4] = new Lane(6, false, ConsoleColor.Blue, true, false, 0.03f, Utils.charCars, Utils.colorsLogs.ToList());
            lanes[5] = new Lane(7, true, ConsoleColor.Green, false, true, 0.1f, Utils.charLogs, Utils.colorsLogs.ToList());
            lanes[6] = new Lane(8, false, ConsoleColor.Blue, true, false, 0.03f, Utils.charCars, Utils.colorsLogs.ToList());
            lanes[7] = new Lane(9, true, ConsoleColor.Green, false, true, 0.1f, Utils.charLogs, Utils.colorsLogs.ToList());
            lanes[8] = new Lane(10, false, ConsoleColor.Blue, true, false, 0.03f, Utils.charCars, Utils.colorsLogs.ToList());
            lanes[9] = new Lane(11, true, ConsoleColor.Green, false, true, 0.1f, Utils.charLogs, Utils.colorsLogs.ToList());

            Player player = new Player();

            
            Utils.GAME_STATE gameState = Utils.GAME_STATE.RUNNING;

            // Bucle del juego
            while (gameState == Utils.GAME_STATE.RUNNING)
            {
                // Se recorren las lineas
                foreach (var lane in lanes)
                {
                    lane.Update();
                }

                // Controles
                Vector2Int tecla = Utils.Input();

                
                gameState = player.Update(tecla, lanes.ToList());

                // Creamos el mapa
                Console.Clear();
                foreach (Lane lane in lanes)
                {
                    lane.Draw();
                }
                player.Draw();
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(0, Utils.MAP_HEIGHT);
                Console.Write("Tiempo: {0:0.00}", TimeManager.time);

                TimeManager.NextFrame();
            }

            // Juego terminado
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(gameState == Utils.GAME_STATE.WIN ? "Has ganado!" : "Game over!!!");
            Console.WriteLine("Pulsa una tecla para salir");
            Console.ReadKey(true);
        }
    }
}
