using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using Ryan.ProjectEuler.Core.Problems;

namespace Ryan.ProjectEuler.Runner
{
    public class CoreRegistry : Registry
    {
        public CoreRegistry()
        {
            Scan(x => 
            {
                x.AssemblyContainingType<IProblem>();
                x.AddAllTypesOf<IProblem>();
            });
        }
    }
}
