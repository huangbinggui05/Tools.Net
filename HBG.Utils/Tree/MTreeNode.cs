using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace HBG.Utils.Tree
{
    [DebuggerDisplay("MTreeNode[Id={Id},ParentId={ParentId},Name={Name},NChildren={NChildren},Childrens={Childrens}]")]
    public class MTreeNode: TreeNode
    {
        [JsonProperty("nChildren")]
        public int NChildren { get; set; }//子节点数
        [JsonProperty("childrens")]
        public List<MTreeNode> Childrens { get; set; }//子节点列表
    }
}
