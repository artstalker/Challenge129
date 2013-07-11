using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace Challange_129.Intermidiate
{
	public class Parser
	{
		public List<List<double>> ParseVectors(string input)
		{
			List<List<double>> vectors = new List<List<double>>();
			var lines = input.Split(new string[]{Environment.NewLine}, StringSplitOptions.None);
			int vectorsCount;
			int.TryParse(lines[0], out vectorsCount);
			for (int i = 1; i <= vectorsCount; i++)
			{
				List<double> vector = new List<double>();
				string currentLine = lines[i];
				var symbolsInLine = currentLine.Split(new string[] { " "}, StringSplitOptions.RemoveEmptyEntries);
				int numbersInVector;
				int.TryParse(symbolsInLine[0], out numbersInVector);

				
				for (int j = 1; j <= numbersInVector; j++ )
				{
					double number;
					double.TryParse(symbolsInLine[j], NumberStyles.Any,CultureInfo.InvariantCulture , out number);
					vector.Add(number);
				}
				vectors.Add(vector);
			}

			return vectors;
		}

		public List<List<double>> ParseVectors(StreamReader reader)
		{
			List<List<double>> vectors = new List<List<double>>();

		
			int vectorsCount = int.Parse(reader.ReadLine());

			
			for (int i = 1; i <= vectorsCount; i++)
			{
				List<double> vector = new List<double>();
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

		public List<Tuple<string, List<int>>> ParseOperations(StreamReader reader)
		{

			List<Tuple<string, List<int>>> operations = new List<Tuple<string, List<int>>>();

			int operationsCount =int.Parse(reader.ReadLine());
			
			for (int i = 1; i <= operationsCount; i++)
			{
				List<int> operationArguments = new List<int>();
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

		public List<Tuple<string, List<int>>> ParseOperations(string input)
		{

			List<Tuple<string, List<int>>> operations = new List<Tuple<string, List<int>>>();

			var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
			int vectorsCount;
			int.TryParse(lines[0], out vectorsCount);
			int operationsCount;

			if (lines.Count() <= vectorsCount + 1)
			{
				return operations;
			}
			int.TryParse(lines[vectorsCount + 1], out operationsCount);
			for (int i = vectorsCount + 2; i < vectorsCount + 2 + operationsCount; i++)
			{
				string currentLine = lines[i];
				var symbolsInLine = currentLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

				List<int> operationArguments = new List<int>();
				for (int j = 1; j < symbolsInLine.Count(); j++)
				{
					int number;
					int.TryParse(symbolsInLine[j], NumberStyles.Any, CultureInfo.InvariantCulture, out number);
					operationArguments.Add(number);
				}
				operations.Add(new Tuple<string, List<int>>(symbolsInLine[0], operationArguments));
			}

			return operations;
		}
	}
}
