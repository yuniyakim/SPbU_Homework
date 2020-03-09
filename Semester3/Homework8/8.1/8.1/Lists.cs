using System;
using System.Collections.Generic;
using System.Reflection;

namespace _8._1
{
    /// <summary>
    /// Lists for tests
    /// </summary>
    public class Lists
    {
        public List<MethodInfo> Tests { get; set; } = new List<MethodInfo>();
        public List<MethodInfo> Before { get; set; } = new List<MethodInfo>();
        public List<MethodInfo> After { get; set; } = new List<MethodInfo>();
        public List<MethodInfo> BeforeClass { get; set; } = new List<MethodInfo>();
        public List<MethodInfo> AfterClass { get; set; } = new List<MethodInfo>();
    }
}
