using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace TreeViewArchitecture.Models
{
    public class NodeModel
    {
        [Key]
        public int NodeId { get; set; }

        [Required]
        public string NodeName { get; set; }

        public int? ParentNodeId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [ForeignKey("ParentNodeId")]
        [JsonIgnore]
        public virtual NodeModel ParentNode { get; set; }

        public virtual ICollection<NodeModel> ChildNodes { get; set; }
    }

    public class TreeViewNode
    {
        public string id { get; set; }
        public string parent { get; set; }
        public string text { get; set; }
    }
}
