using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Challange_129.Intermidiate
{
	public class Program
	{
		static void Main(string[] args)
		{
			var reader = File.OpenText(args[0]);
			Parser parser = new Parser();
			string content = reader.ReadToEnd();
			var vectors = parser.ParseVectors(content);
			var operations = parser.ParseOperations(content);

			foreach (var operation in operations)
			{
				switch (operation.Item1)
				{
					case "l":
						double length = LengthOf(vectors[operation.Item2[0]]);
						Console.WriteLine(length);
						break;
					case "n":
						var normalized_vector = Normalize(vectors[operation.Item2[0]]);
						Console.WriteLine(string.Join(" ", normalized_vector));
						break;
					case "d":
						double dot_product = DotProduct(vectors[operation.Item2[0]], vectors[operation.Item2[1]]);
						Console.WriteLine(dot_product);
						break;
				}
			}

			Console.ReadLine();

		}

		public static double LengthOf(List<double> vector)
		{
			double sum = vector.Sum(d => d * d);
			return Math.Round(Math.Sqrt(sum), 6);
		}

		public static List<double> Normalize(List<double> vector)
		{
			double length = LengthOf(vector);
			List<double> normalizedVector = new List<double>();

			foreach (var d in vector)
			{
				double normal = d / length;
				normalizedVector.Add(Math.Round(normal,6));
			}

			return normalizedVector;
		}

		public static double DotProduct(List<double> vector1, List<double> vector2)
		{
			double sum = 0;
			for (int i = 0; i < Math.Min(vector1.Count, vector2.Count); i++)
			{
				sum += vector1[i] * vector2[i];
			}
			return Math.Round(sum,6);
		}
	}
}
