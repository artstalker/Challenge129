using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Challange_129.Intermidiate;

using NUnit.Framework;
using NBehave.Spec.NUnit;

namespace UnitTests
{
	public class when_parse_input : Specification
	{
		protected Parser _testObject;

		protected string _input = string.Empty;

		protected List<List<double>> _vectors;

		protected List<Tuple<string, List<int>>> _operations;

		protected override void Establish_context()
		{
			_testObject = new Parser();
		}

		protected override void Because_of()
		{
			base.Because_of();
			_vectors = _testObject.ParseVectors(_input);
			_operations = _testObject.ParseOperations(_input);
		}
	}

	public class and_nothing_in_input : when_parse_input
	{
		protected override void Establish_context()
		{
			base.Establish_context();
			_input = string.Empty;
		}

		[Test]
		public void then_parser_should_return_empty_vector_collection()
		{
			_vectors.ShouldNotBeNull();
			_vectors.Count().ShouldEqual(0);
		}

	}

	public class and_correct_data_in_input : when_parse_input
	{
		protected override void Establish_context()
		{
			base.Establish_context();
			_input =
@"5
2 1 1
2 1.2 3.4
3 6.78269 6.72 6.76312
4 0 1 0 1
7 84.82 121.00 467.05 142.14 592.55 971.79 795.33
7
l 0
l 3
l 4
n 1
n 2
n 3
d 0 1
";
		}

		[Test]
		public void then_parser_should_return_identical_vector_collection()
		{
			_vectors.ShouldNotBeNull();
			_vectors.Count().ShouldEqual(5);

			_vectors[0].Count().ShouldEqual(2);
			_vectors[0][0].ShouldEqual(1);
			_vectors[0][1].ShouldEqual(1);

			_vectors[1].Count().ShouldEqual(2);
			_vectors[1][0].ShouldEqual(1.2);
			_vectors[1][1].ShouldEqual(3.4);

			_vectors[2].Count().ShouldEqual(3);
			_vectors[2][0].ShouldEqual(6.78269);
			_vectors[2][1].ShouldEqual(6.72);
			_vectors[2][2].ShouldEqual(6.76312);

			_vectors[3].Count().ShouldEqual(4);
			_vectors[3][0].ShouldEqual(0);
			_vectors[3][1].ShouldEqual(1);
			_vectors[3][2].ShouldEqual(0);
			_vectors[3][3].ShouldEqual(1);

			_vectors[4].Count().ShouldEqual(7);
			_vectors[4][0].ShouldEqual(84.82);
			_vectors[4][1].ShouldEqual(121.00);
			_vectors[4][2].ShouldEqual(467.05);
			_vectors[4][3].ShouldEqual(142.14);
			_vectors[4][4].ShouldEqual(592.55);
			_vectors[4][5].ShouldEqual(971.79);
			_vectors[4][6].ShouldEqual(795.33);
			
		}

		[Test]
		public void then_parser_should_return_identical_operations_collection()
		{
			_operations.ShouldNotBeNull();
			_operations.Count().ShouldEqual(7);

			_operations[0].Item1.ShouldEqual("l");
			_operations[0].Item2.Count().ShouldEqual(1);
			_operations[0].Item2[0].ShouldEqual(0);

			_operations[1].Item1.ShouldEqual("l");
			_operations[1].Item2.Count().ShouldEqual(1);
			_operations[1].Item2[0].ShouldEqual(3);

			_operations[2].Item1.ShouldEqual("l");
			_operations[2].Item2.Count().ShouldEqual(1);
			_operations[2].Item2[0].ShouldEqual(4);

			_operations[3].Item1.ShouldEqual("n");
			_operations[3].Item2.Count().ShouldEqual(1);
			_operations[3].Item2[0].ShouldEqual(1);

			_operations[4].Item1.ShouldEqual("n");
			_operations[4].Item2.Count().ShouldEqual(1);
			_operations[4].Item2[0].ShouldEqual(2);

			_operations[5].Item1.ShouldEqual("n");
			_operations[5].Item2.Count().ShouldEqual(1);
			_operations[5].Item2[0].ShouldEqual(3);

			_operations[6].Item1.ShouldEqual("d");
			_operations[6].Item2.Count().ShouldEqual(2);
			_operations[6].Item2[0].ShouldEqual(0);
			_operations[6].Item2[1].ShouldEqual(1);

		}




	}

	public class and_no_operations_in_input : when_parse_input
	{
		protected override void Establish_context()
		{
			base.Establish_context();
			_input = string.Empty;
		}

		[Test]
		public void then_parser_should_return_empty_vector_collection()
		{
			_operations.ShouldNotBeNull();
			_operations.Count().ShouldEqual(0);
		}

	}
}
