using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
	public class Mines
	{
		public class Points
		{
			string playerName;
			int points;

			public string PlayerName
			{
				get { return playerName; }
				set { playerName = value; }
			}

			public int PlayerPoints
			{
				get { return points; }
				set { points = value; }
			}

			public Points() { }

			public Points(string name, int playerPionts)
			{
				this.playerName = name;
				this.points = playerPionts;
			}
		}

		static void Main(string[] arguments)
		{
			string command = string.Empty;
			char[,] field = CreatePlayingField();
			char[,] bombs = PlaceBombs();
			int counterOfOpenedFreeCells = 0;
			bool hasBombBeenOpen = false;
			List<Points> champions = new List<Points>(6);
			int row = 0;
			int column = 0;
			bool newGame = true;
			const int MaxFreeCells = 35;
			bool hasWon = false;

			do
			{
				if (newGame)
				{
					Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
					" Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
					DrawField(field);
					newGame = false;
				}
				Console.Write("Daj red i kolona : ");
				command = Console.ReadLine().Trim();
				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
					int.TryParse(command[2].ToString(), out column) &&
						row <= field.GetLength(0) && column <= field.GetLength(1))
					{
						command = "turn";
					}
				}
				switch (command)
				{
					case "top":
						ListScoreBoard(champions);
						break;
					case "restart":
						field = CreatePlayingField();
						bombs = PlaceBombs();
						DrawField(field);
						hasBombBeenOpen = false;
						newGame = false;
						break;
					case "exit":
						Console.WriteLine("4a0, 4a0, 4a0!");
						break;
					case "turn":
						if (bombs[row, column] != '*')
						{
							if (bombs[row, column] == '-')
							{
								NextMove(field, bombs, row, column);
								counterOfOpenedFreeCells++;
							}
							if (MaxFreeCells == counterOfOpenedFreeCells)
							{
								hasWon = true;
							}
							else
							{
								DrawField(field);
							}
						}
						else
						{
							hasBombBeenOpen = true;
						}
						break;
					default:
						Console.WriteLine("\nGreshka! nevalidna Komanda\n");
						break;
				}
				if (hasBombBeenOpen)
				{
					DrawField(bombs);
					Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
						"Daj si niknejm: ", counterOfOpenedFreeCells);
					string nickname = Console.ReadLine();
					Points currentPlayerPoints = new Points(nickname, counterOfOpenedFreeCells);
					if (champions.Count < 5)
					{
						champions.Add(currentPlayerPoints);
					}
					else
					{
						for (int i = 0; i < champions.Count; i++)
						{
							if (champions[i].PlayerPoints < currentPlayerPoints.PlayerPoints)
							{
								champions.Insert(i, currentPlayerPoints);
								champions.RemoveAt(champions.Count - 1);
								break;
							}
						}
					}
					champions.Sort((Points playerOne, Points playerTwo) => playerTwo.PlayerName.CompareTo(playerOne.PlayerName));
                    champions.Sort((Points playerOne, Points playerTwo) => playerTwo.PlayerPoints.CompareTo(playerOne.PlayerPoints));
					ListScoreBoard(champions);

					field = CreatePlayingField();
					bombs = PlaceBombs();
					counterOfOpenedFreeCells = 0;
					hasBombBeenOpen = false;
					newGame = true;
				}
				if (hasWon)
				{
					Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
					DrawField(bombs);
					Console.WriteLine("Daj si imeto, batka: ");
					string winnerName = Console.ReadLine();
					Points winnerPoints = new Points(winnerName, counterOfOpenedFreeCells);
					champions.Add(winnerPoints);
					ListScoreBoard(champions);
					field = CreatePlayingField();
					bombs = PlaceBombs();
					counterOfOpenedFreeCells = 0;
					hasWon = false;
					newGame = true;
				}
			}
			while (command != "exit");
			Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
			Console.WriteLine("AREEEEEEeeeeeee.");
			Console.Read();
		}

		private static void ListScoreBoard(List<Points> champions)
		{
			Console.WriteLine("\nTo4KI:");
			if (champions.Count > 0)
			{
				for (int i = 0; i < champions.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} kutii",
						i + 1, champions[i].PlayerName, champions[i].PlayerPoints);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("prazna klasaciq!\n");
			}
		}

		private static void NextMove(char[,] field,
			char[,] bombsOnField, int row, int col)
		{
			char kolkoBombi = NumberOfBombsAroundCell(bombsOnField, row, col);
			bombsOnField[row, col] = kolkoBombi;
			field[row, col] = kolkoBombi;
		}

		private static void DrawField(char[,] board)
		{
			int rows = board.GetLength(0);
			int cols = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
			for (int i = 0; i < rows; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < cols; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}
				Console.Write("|");
				Console.WriteLine();
			}
			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreatePlayingField()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];
			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] PlaceBombs()
		{
			int MaxRows = 5;
			int MaxCols = 10;
			char[,] palyingField = new char[MaxRows, MaxCols];

			for (int i = 0; i < MaxRows; i++)
			{
				for (int j = 0; j < MaxCols; j++)
				{
					palyingField[i, j] = '-';
				}
			}

			List<int> randomNumbersToPopulateBombsOnField = new List<int>();
			while (randomNumbersToPopulateBombsOnField.Count < 15)
			{
				Random random = new Random();
				int randomNumberToUse = random.Next(50);
				if (!randomNumbersToPopulateBombsOnField.Contains(randomNumberToUse))
				{
					randomNumbersToPopulateBombsOnField.Add(randomNumberToUse);
				}
			}

			foreach (int randNum in randomNumbersToPopulateBombsOnField)
			{
				int col = (randNum / MaxCols);
				int row = (randNum % MaxCols);
				if (row == 0 && randNum != 0)
				{
					col--;
					row = MaxCols;
				}
				else
				{
					row++;
				}
				palyingField[col, row - 1] = '*';
			}

			return palyingField;
		}

		private static void CalculateBombsAroundFreeCells(char[,] field)
		{
			int rows = field.GetLength(0);
			int cols = field.GetLength(1);

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					if (field[i, j] != '*')
					{
						char numberOfBombs = NumberOfBombsAroundCell(field, i, j);
						field[i, j] = numberOfBombs;
					}
				}
			}
		}

		private static char NumberOfBombsAroundCell(char[,] bombsOnField, int row, int col)
		{
			int bombsCount = 0;
			int maxRows = bombsOnField.GetLength(0);
			int maxCols = bombsOnField.GetLength(1);

			if (row - 1 >= 0)
			{
				if (bombsOnField[row - 1, col] == '*')
				{ 
					bombsCount++; 
				}
			}
			if (row + 1 < maxRows)
			{
				if (bombsOnField[row + 1, col] == '*')
				{ 
					bombsCount++; 
				}
			}
			if (col - 1 >= 0)
			{
				if (bombsOnField[row, col - 1] == '*')
				{ 
					bombsCount++;
				}
			}
			if (col + 1 < maxCols)
			{
				if (bombsOnField[row, col + 1] == '*')
				{ 
					bombsCount++;
				}
			}
			if ((row - 1 >= 0) && (col - 1 >= 0))
			{
				if (bombsOnField[row - 1, col - 1] == '*')
				{ 
					bombsCount++; 
				}
			}
			if ((row - 1 >= 0) && (col + 1 < maxCols))
			{
				if (bombsOnField[row - 1, col + 1] == '*')
				{ 
					bombsCount++; 
				}
			}
			if ((row + 1 < maxRows) && (col - 1 >= 0))
			{
				if (bombsOnField[row + 1, col - 1] == '*')
				{ 
					bombsCount++; 
				}
			}
			if ((row + 1 < maxRows) && (col + 1 < maxCols))
			{
				if (bombsOnField[row + 1, col + 1] == '*')
				{ 
					bombsCount++; 
				}
			}
			return char.Parse(bombsCount.ToString());
		}
	}
}
