using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aegis.Game.GameOfLife
{
    public class GameOfLife
    {
        public bool[,] Grid { get; private set; }
        public int Rows { get; }
        public int Columns { get; }

        public event EventHandler GenerationCompleted;

        protected virtual void OnGenerationCompleted()
        {
            // Invoke the event, notifying all subscribers
            GenerationCompleted?.Invoke(this, EventArgs.Empty);
        }

        public GameOfLife(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Grid = new bool[rows, columns];
        }

        public void ToggleCell(int row, int column)
        {
            Grid[row, column] = !Grid[row, column];
        }

        public void NextGeneration()
        {
            bool[,] newGrid = new bool[Rows, Columns];
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    int liveNeighbors = CountLiveNeighbors(row, column);
                    bool shouldLive = liveNeighbors == 3 || (liveNeighbors == 2 && Grid[row, column]);
                    newGrid[row, column] = shouldLive;
                }
            }
            Grid = newGrid;

            OnGenerationCompleted();
        }

        private int CountLiveNeighbors(int row, int column)
        {
            int count = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;
                    int r = (row + i + Rows) % Rows;
                    int c = (column + j + Columns) % Columns;
                    if (Grid[r, c])
                        count++;
                }
            }
            return count;
        }

        public void RandomizeGrid()
        {
            Random rnd = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Grid[i, j] = rnd.NextDouble() > 0.5;
                }
            }
        }

        public void ClearGrid()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Grid[i, j] = false;
                }
            }
        }
        
        public bool IsStable()
        {
            bool[,] newGrid = new bool[Rows, Columns];
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    int liveNeighbors = CountLiveNeighbors(row, column);
                    bool shouldLive = liveNeighbors == 3 || (liveNeighbors == 2 && Grid[row, column]);
                    newGrid[row, column] = shouldLive;
                }
            }
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    if (newGrid[row, column] != Grid[row, column])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
