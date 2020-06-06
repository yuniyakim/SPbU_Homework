using System.ComponentModel.DataAnnotations;

namespace _12._1.Models
{
    /// <summary>
    /// Test's info
    /// </summary>
    public class TestInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }
        public string IgnoreReason { get; set; }
        public long Time { get; set; }
    }
}
