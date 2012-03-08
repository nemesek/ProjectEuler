using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Project Euler problem solver.");

            var solversMetaData = EulerProblemSolverMetadata.GetProblemSolvers().ToList();

            if (!solversMetaData.Any())
            {
                "There are no problems available to solve".DisplayAndPause();
                return;
            }

            // create a summary of all the available problems
            var problemsSummary = solversMetaData.Aggregate(new StringBuilder(), (sb, solverData) =>
                sb.AppendFormat("{0}: {1}\n", solverData.Number, solverData.Title));

            do
            {
                Console.WriteLine("Which problem would you like to solve?");
                Console.WriteLine(problemsSummary);

                var chosenSolver = GetSolverForUsersChosenProblem(solversMetaData);
                SolveProblem(chosenSolver);

                Console.WriteLine("Would you like to solve another? (y/n)");
            } while (Console.ReadKey().Key == ConsoleKey.Y);

        }

        private static void SolveProblem(EulerProblemSolverMetadata chosenSolver)
        {
            Console.WriteLine(string.Format("Solving problem {0}: {1}", chosenSolver.Number, chosenSolver.Title));
            object instance = Activator.CreateInstance(chosenSolver.Class);

            Stopwatch timer = new Stopwatch();
            long answer = 0;

            timer.Time(()=> answer= (long)chosenSolver.Method.Invoke(instance, new object[] { }));

            // if the solve method took less than 5 seconds, use the ActionTimer to get a more 
            // accurate time
            double time = (timer.TimeInFractionalSeconds() < 5) ? 
                ActionTimer.AverageTime(()=>chosenSolver.Method.Invoke(instance, new object[]{})) 
                : timer.TimeInFractionalSeconds();

            Console.WriteLine(string.Format("Answer is {0}; took {1} seconds", answer, time));
        }

        private static EulerProblemSolverMetadata GetSolverForUsersChosenProblem(IList<EulerProblemSolverMetadata> solversMetaData)
        {
            var chosenSolver =
                Console.In.ReadLines()
                .Validate(input => input.IsInteger(), "Please type in a number")
                .Select(input => int.Parse(input))
                .Validate(problemNumber => solversMetaData.Any(metaData => metaData.Number == problemNumber), "That problem number wasn't recognised")
                .Select(problemNumber => solversMetaData.First(metaData => metaData.Number == problemNumber))
                .First();

            return chosenSolver;
        }
    }
}
