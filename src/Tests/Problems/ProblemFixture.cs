using System;
using NUnit.Framework;
using Ryan.ProjectEuler.Core.Problems;

namespace Ryan.ProjectEuler.Tests.Problems
{
	[TestFixture]
	public class ProblemFixture
	{
		[Test]
		public void Problem001()
		{
			var problem = new Problem01();

			var answer = problem.Solve();

			Assert.That (answer, Is.EqualTo(233168));
		}
	}
}

