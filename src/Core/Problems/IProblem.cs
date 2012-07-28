using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ryan.ProjectEuler.Core.Problems
{
    public interface IProblem
    {
        int Number { get; }
        string Description { get; }

        long Solve();
    }
}
