using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Challange_129.Intermidiate;

using NUnit.Framework;
using NBehave.Spec.NUnit;

namespace UnitTests
{
	class when_length_of_vector_is_called : Specification
	{
		protected  List<double> _testVector = new List<double>();

		protected double _result;

		
		
	}

	class and_2point_vector_is_used : Specification
	{
		protected List<double> _testVector = new List<double>();

		protected double _result;

		protected double _expected = 1.4142;

		protected override void Establish_context()
		{
			base.Establish_context();
			_testVector.AddRange(new double[]{1,1});
		}

		protected override void Because_of()
		{
			_result = Program.LengthOf(_testVector);
		}

		[Test]
		public void then_correct_length_expected()
		{
			_result.ShouldApproximatelyEqual(_expected, 0.0001);
		}


	}

	class and_4point_vector_is_used : Specification
	{
		protected List<double> _testVector = new List<double>();

		protected double _result;

		protected double _expected = 1.4142;

		protected override void Establish_context()
		{
			base.Establish_context();
			_testVector.AddRange(new double[] { 0, 1, 0, 1 });
		}

		protected override void Because_of()
		{
			_result = Program.LengthOf(_testVector);
		}

		[Test]
		public void then_correct_length_expected()
		{
			_result.ShouldApproximatelyEqual(_expected, 0.0001);
		}


	}

	class and_7point_vector_is_used : Specification
	{
		protected List<double> _testVector = new List<double>();

		protected double _result;

		protected double _expected = 1479.26;

		protected override void Establish_context()
		{
			base.Establish_context();
			_testVector.AddRange(new double[] { 84.82, 121.00, 467.05, 142.14, 592.55, 971.79, 795.33 });
		}

		protected override void Because_of()
		{
			_result = Program.LengthOf(_testVector);
		}

		[Test]
		public void then_correct_length_expected()
		{
			_result.ShouldApproximatelyEqual(_expected, 0.01);
		}


	}

	class when_normalization_of_vector_is_called : Specification
	{
		protected List<double> _testVector = new List<double>();

		protected double _result;



	}

	class and_2point_vector_is_used_for_normalization : Specification
	{
		protected List<double> _testVector = new List<double>();

		protected List<double> _result = new List<double>();

		protected List<double> _expected = new List<double>();

		protected override void Establish_context()
		{
			base.Establish_context();
			_testVector.AddRange(new double[] { 1.2, 3.4 });
			_expected.AddRange(new double[] { 0.33282, 0.94299 });
		}

		protected override void Because_of()
		{
			_result = Program.Normalize(_testVector);
		}

		[Test]
		public void then_correct_normal_expected()
		{
			for (int i = 0; i < _result.Count;i++ )
			{
				_result[i].ShouldApproximatelyEqual(_expected[i], 0.0001);
			}
			
		}


	}

	class and_dot_product_of_2_2point_vectors_is_used : Specification
	{
		protected List<double> _testVector1 = new List<double>();
		protected List<double> _testVector2 = new List<double>();

		protected double _result;
		protected double _expected;
		

		protected override void Establish_context()
		{
			base.Establish_context();
			_testVector1.AddRange(new double[] { 1, 1 });
			_testVector2.AddRange(new double[] { 1.2, 3.4 });
			_expected = 4.6;
		}

		protected override void Because_of()
		{
			_result = Program.DotProduct(_testVector1, _testVector2);
		}

		[Test]
		public void then_correct_dot_expected()
		{
			_result.ShouldApproximatelyEqual(_expected, 0.0001);

		}


	}

}
