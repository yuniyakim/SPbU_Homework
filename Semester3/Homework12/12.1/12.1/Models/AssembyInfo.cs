using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _12._1.Models
{
    /// <summary>
    /// Assembly's info
    /// </summary>
    public class AssembyInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TestInfo> Tests { get; set; }
    }
}
