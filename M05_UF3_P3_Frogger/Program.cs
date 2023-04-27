using System;
using System.Collections.Generic;
using System.Linq;

using M05_UF3_P3_Frogger;

namespace M05_UF3_P3_Frogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mapWidth = 40; // Cambia esto al valor deseado, por ejemplo, 40
            int mapHeight = Utils.MAP_HEIGHT;

            Console.SetWindowSize(mapWidth, mapHeight + 1);

            Lane[] lanes = new Lane[5];
            lanes[0] = new Lane(2, false, ConsoleColor.Blue, true, false, 0.03f, Utils.charCars, Utils.colorsLogs.ToList());
            lanes[1] = new Lane(3, true, ConsoleColor.Green, false, true, 0.1f, Utils.charLogs, Utils.colorsLogs.ToList());
            lanes[2] = new Lane(4, false, ConsoleColor.Blue, true, false, 0.03f, Utils.charCars, Utils.colorsLogs.ToList());
            lanes[3] = new Lane(5, true, ConsoleColor.Green, false, true, 0.1f, Utils.charLogs, Utils.colorsLogs.ToList());
            lanes[4] = new Lane(6, false, ConsoleColor.Blue, true, false, 0.03f, Utils.charCars, Utils.colorsLogs.ToList());

            Player player = new Player();

            Utils.GAME_STATE gameState = Utils.GAME_STATE.RUNNING;

            while (gameState == Utils.GAME_STATE.RUNNING)
            {
                foreach (var lane in lanes)
                {
                    lane.Update();
                }

                Vector2Int tecla = Utils.Input();
                gameState = player.Update(tecla, lanes.ToList());

                Console.Clear();
                foreach (Lane lane in lanes)
                {
                    lane.Draw();
                }
                player.Draw();
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(0, mapHeight);
                Console.Write("Tiempo: {0:0.00}", TimeManager.time);

                TimeManager.NextFrame();
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(gameState == Utils.GAME_STATE.WIN ? "Has ganado!" : "Perdiste...");
            Console.WriteLine("Pulsa cualquier tecla para salir");
            Console.ReadKey(true);
        }

    }
}
