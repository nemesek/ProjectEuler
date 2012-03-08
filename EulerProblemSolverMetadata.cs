using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ProjectEuler
{
    class EulerProblemSolverMetadata
    {
        public Type Class
        {
            get;
            set;
        }

        public MethodInfo Method
        {
            get;
            set;
        }

        public int Number
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public static IEnumerable<EulerProblemSolverMetadata> GetProblemSolvers()
        {
            var problemSolvers = from type in Assembly.GetExecutingAssembly().GetTypes()
                                 // filter out types that are not decorated with the EulerProblemAttribute
                                 where Attribute.IsDefined(type, typeof(EulerProblemAttribute))
                                 // ensure that the type has a parameterless public Solve method 
                                 let method = type.GetMethod("Solve", new Type[] { })
                                 let returnType = method.ReturnType
                                 where method != null && returnType == typeof(long)
                                 // get hold of the attribute, so that we can get the metadata from it
                                 let attribute = Attribute.GetCustomAttribute(type, typeof(EulerProblemAttribute)) as EulerProblemAttribute
                                 // sort the problems into ascending order
                                 orderby attribute.ProblemNumber ascending
                                 select new EulerProblemSolverMetadata
                                     {
                                         Class = type,
                                         Number = attribute.ProblemNumber,
                                         Title = attribute.Title,
                                         Method = method
                                     };
                                  

            return problemSolvers;
        }
    }
}
