using System.Collections.Generic;

namespace _12._1.Models
{
    /// <summary>
    /// Completed tests' info
    /// </summary>
    public class CompletedTestsInfo
    {
        public List<AssemblyInfo> Assemblies { get; set; } = new List<AssemblyInfo>();
        public List<TestInfo> Tests { get; set; } = new List<TestInfo>();
    }
}
