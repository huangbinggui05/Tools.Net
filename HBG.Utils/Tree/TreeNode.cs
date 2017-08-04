using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBG.Utils.Tree
{
    public class TreeNode
    {
        [JsonProperty("id")]
        public string Id { get; set; }//节点Id  
        [JsonProperty("parentId")]
        public string ParentId { get; set; }//父节点Id
        [JsonProperty("name")]
        public string Name { get; set; }//节点名  
    }
}
