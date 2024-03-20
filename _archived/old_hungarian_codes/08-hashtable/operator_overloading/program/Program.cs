using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{

	class Cell
	{
		public int Size { get; set; }
		public int PosX { get; set; }
		public int PosY { get; set; }

		// operator overloadingg
		public static Cell operator + (Cell a, Cell b)
		{
			Cell newCell = new Cell();
			newCell.Size = a.Size + b.Size;
			return newCell;
		}
	}

    class Program
    {

		static void DrawUser(Cell user)
		{
			int startYPosition = 10;

			for (int i = 0; i < user.Size; i++)
			{
				Console.SetCursorPosition(user.PosX, startYPosition--);
				Console.Write("X");
			}
		}

		static void DrawPickups(List<Cell> pickups)
		{
			foreach (Cell actualCell in pickups)
			{
				Console.SetCursorPosition(actualCell.PosX, actualCell.PosY);
    			Console.Write("O"); 
			}
		}

		static void CheckPickup(ref Cell felh, List<Cell> pickups, ref bool endofgame)
		{
			int toBeDeletedIndex = -1;

			for (int i = 0; i < pickups.Count(); i++)
			{
				if (pickups[i].PosX == felh.PosX)
				{
					Cell newUser = felh + pickups[i]; // » operandus túlterhelés itt jelenik meg!!!
					newUser.PosX = felh.PosX;
					newUser.PosY = felh.PosY;
					felh = newUser; // ? problem?
					toBeDeletedIndex = i; 
				}

			}

			if(toBeDeletedIndex > -1)
				pickups.RemoveAt(toBeDeletedIndex);



			if (pickups.Count() == 0)
			{
				endofgame = true;
			}


		}


		static void Main(string[] args)
		{
			Cell user = new Cell() { Size = 1, PosX = 10, PosY = 30 };

			List<Cell> pickUps = new List<Cell>();
			pickUps.Add(new Cell() { Size = 1, PosX = 3, PosY = 10 });
			pickUps.Add(new Cell() { Size = 1, PosX = 15, PosY = 10 });
			pickUps.Add(new Cell() { Size = 1, PosX = 23, PosY = 10 });
			pickUps.Add(new Cell() { Size = 1, PosX = 30, PosY = 10 });

			bool endofgame = false;
			while (!endofgame)
			{

				// rajzolás
				Console.Clear();
				DrawUser(user);
				DrawPickups(pickUps);


				// mozgás
				ConsoleKeyInfo move = Console.ReadKey();

				if (move.Key == ConsoleKey.LeftArrow)
				{
					user.PosX--;
				}
				else if (move.Key == ConsoleKey.RightArrow)
				{
					user.PosX++;
				}

				CheckPickup(ref user, pickUps, ref endofgame);
			}
		}
    }




}
