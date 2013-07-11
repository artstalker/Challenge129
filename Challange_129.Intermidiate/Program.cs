using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Challange_129.Intermidiate
{
	public class Program
	{
		private static List<List<double>> vectors;
		private static List<Tuple<string, List<int>>> operations;

		static void Main(string[] args)
		{
			using (var reader = File.OpenText(args[0]))
			{
				vectors = ParseVectors(reader);
				operations = ParseOperations(reader);
			}

			foreach (var operation in operations)
			{
				switch (operation.Item1)
				{
					case "l":
						double length = LengthOf(vectors[operation.Item2[0]]);
						Console.WriteLine("{0:F5}",length);
						break;
					case "n":
						var normalized_vector = Normalize(vectors[operation.Item2[0]]);
						foreach (var d in normalized_vector)
						{
							Console.Write("{0:F6} ", d);
						}
						Console.WriteLine();
						break;
					case "d":
						double dot_product = DotProduct(vectors[operation.Item2[0]], vectors[operation.Item2[1]]);
						Console.WriteLine("{0:F5}", dot_product);
						break;
				}
			}

			Console.ReadLine();
		}

		public static double LengthOf(List<double> vector)
		{
			double sum = vector.Sum(d => d * d);
			return Math.Sqrt(sum);
		}

		public static List<double> Normalize(List<double> vector)
		{
			double length = LengthOf(vector);
			return vector.Select(d => d/length).ToList();
		}

		public static double DotProduct(List<double> vector1, List<double> vector2)
		{
			double sum = 0;
			for (int i = 0; i < Math.Min(vector1.Count, vector2.Count); i++)
			{
				sum += vector1[i] * vector2[i];
			}
			return sum;
		}

		public static List<List<double>> ParseVectors(StreamReader reader)
		{
			var vectors = new List<List<double>>();
			int vectorsCount = int.Parse(reader.ReadLine());

			for (int i = 1; i <= vectorsCount; i++)
			{
				var vector = new List<double>();
				var symbolsInLine = reader.ReadLine().Split(' ');
				int numbersInVector = int.Parse(symbolsInLine[0]);

				for (int j = 1; j <= numbersInVector; j++)
				{
					double number = double.Parse(symbolsInLine[j], CultureInfo.InvariantCulture);
					vector.Add(number);
				}
				vectors.Add(vector);
			}

			return vectors;
		}

		public static List<Tuple<string, List<int>>> ParseOperations(StreamReader reader)
		{
			var operations = new List<Tuple<string, List<int>>>();
			int operationsCount = int.Parse(reader.ReadLine());

			for (int i = 1; i <= operationsCount; i++)
			{
				var operationArguments = new List<int>();
				var symbolsInLine = reader.ReadLine().Split(' ');

				for (int j = 1; j < symbolsInLine.Count(); j++)
				{
					int number = int.Parse(symbolsInLine[j]);
					operationArguments.Add(number);
				}
				operations.Add(new Tuple<string, List<int>>(symbolsInLine[0], operationArguments));
			}

			return operations;
		}
	}
}
