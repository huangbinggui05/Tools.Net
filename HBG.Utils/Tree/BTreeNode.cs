using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBG.Utils.Tree
{
    public class BTreeNode:TreeNode
    {
        [JsonProperty("lChildren")]
        public BTreeNode LChildren { get; set; }//左子节点
        [JsonProperty("rChildren")]
        public BTreeNode RChildren { get; set; }//右子节点
    }
}
