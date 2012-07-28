using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ryan.ProjectEuler.Core.Problems
{
    public class Problem01 : IProblem
    {
        public int Number 
        {
            get
            {
                return 1;
            }
        }

        public string Description
        {
            get
            {
                return "Find the sum of all the multiples of 3 or 5 below 1000.";
            }
        }

        public long Solve()
        {
            return Enumerable.Range(1, 999)
                              .Where(x => x % 3 == 0 || x % 5 == 0)
                              .Sum();
        }
    }
}
