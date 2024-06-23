using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicaExtra
{
    public class slotMachine
    {
        private List<Prize> prizes;
        public slotMachine() 
        {
            prizes = new List<Prize>();
        }

        public void loadPrizes(string filepath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filepath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');

                    int prizeType = int.Parse(parts[0]);
                    string name = parts[1];
                    int symbol1 = int.Parse(parts[2]);
                    int symbol2 = int.Parse(parts[3]);
                    int symbol3 = int.Parse(parts[4]);
                    string advice1 = parts[5];
                    string advice2 = parts[6];
                    double probability = double.Parse(parts[7]);

                    if (prizeType == 1)
                    {
                        prizes.Add(new simplePrize(name, symbol1, symbol2, symbol3, advice1));
                    }
                    else if(prizeType == 2) 
                    {
                        prizes.Add(new randomPrize(name, symbol1, symbol2, symbol3, advice1, advice2));
                    }

                    Console.WriteLine("The prize was correctly stored in the file\n\n");
                }

            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("Input file not found.");
            }
        }
        public void Play()
        {
            int[,] slots = randomMatrix();
            displayMatrix(slots);
            checkWin(slots[1, 0], slots[1, 1], slots[1, 2]);
        }

        private int[,] randomMatrix()
        {
            Random random = new Random();
            int[,] slots = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    slots[i, j] = random.Next(1, 9);
                }
            }
            return slots;
        }

        private void displayMatrix(int[,] slots)
        {
            Console.WriteLine("Slots results: ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(slots[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private void checkWin(int symbol1, int symbol2, int symbol3)
        {
            foreach (var prize in prizes)
            {
                if (prize.winningComb(symbol1, symbol2, symbol3))
                {
                    Console.WriteLine($"Congrats, you won!! :) Price: {prize.GetName()}");
                    Console.WriteLine($"Advice: {prize.GetAdvice()}");
                    return;
                }
            }
            Console.WriteLine("You lost, sorry :(");
        }

        public void showPrices()
        {
            int idViewDetails;
            Console.WriteLine("These are the available prizes");
            foreach (var prize in prizes)
            {
                Console.WriteLine($"ID: {prize.GetId()}, Name: {prize.GetName()}");
            }

            Console.WriteLine("Introduce the prize id to see the details");
            idViewDetails = int.Parse(Console.ReadLine());

            try
            {
                Prize selectedPrize = null;

                // Buscar el premio con el ID proporcionado
                foreach (var prize in prizes)
                {
                    if (prize.GetId() == idViewDetails)
                    {
                        selectedPrize = prize;
                        break;
                    }
                }

                if (selectedPrize != null)
                {
                    Console.WriteLine($"Name: {selectedPrize.GetName()}, Symbols: {selectedPrize.GetSymbol1()}-{selectedPrize.GetSymbol2()}-{selectedPrize.GetSymbol3()}");
                    Console.WriteLine($"Advice: {selectedPrize.GetAdvice()}");
                }
                else
                {
                    Console.WriteLine("Prize not found.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
            }
        }
    }
}

