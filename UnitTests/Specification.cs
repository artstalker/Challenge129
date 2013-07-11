using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NBehave.Spec.NUnit;

using NUnit.Framework;

namespace UnitTests
{
	[TestFixture]
	public class Specification : SpecBase
	{
		protected static Random _randomGenerator = new Random();
	}
}
