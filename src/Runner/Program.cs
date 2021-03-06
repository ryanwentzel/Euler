﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ryan.ProjectEuler.Core.Problems;

namespace Ryan.ProjectEuler.Runner
{
    class Program
    {
        private static void SolveProblem(IProblem problem)
        {
            Console.WriteLine("\n----------------------------");
            string message = string.Format("Problem {0}: {1}", problem.Number.ToString().PadLeft(3, '0'), problem.Description);
            Console.WriteLine(message);

            var solution = problem.Solve();
            Console.WriteLine("\nThe answer is: {0}", solution);
            Console.WriteLine("----------------------------");
        }

        static void Main(string[] args)
        {
            DependencyResolver.EnsureDependenciesAreRegistered();

            DependencyResolver
                .ResolveAll<IProblem>()
                .OrderBy(x => x.Number)
                .ToList()
                .ForEach(SolveProblem);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
