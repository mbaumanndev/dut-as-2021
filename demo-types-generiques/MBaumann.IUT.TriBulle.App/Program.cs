using MBaumann.IUT.TriBulle.Algos;

int[] tableau = new int[20];
Random rand = new Random();
for(int i = 0; i < tableau.Length; i++)
    tableau[i] = rand.Next(0, int.MaxValue);

IEnumerable<int> result = TriBulle.Run(tableau);

Console.WriteLine("Avant");
foreach (int value in tableau)
    Console.WriteLine(value);

Console.WriteLine();
Console.WriteLine("Après");
foreach (int value in result)
    Console.WriteLine(value);

Console.WriteLine();
Console.ReadLine();
