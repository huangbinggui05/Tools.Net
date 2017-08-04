using HBG.Utils.Log;
using HBG.Utils.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeConstruction
{
    public static class MockMTree
    {
        /// <summary>
        /// 构建多叉树
        /// </summary>
        /// <returns></returns>
        public static MTreeNode CreateFakeMTree()
        {
            MTreeNode tree = new MTreeNode();
            tree.NChildren = 3;
            tree.Id = "1";
            tree.Name = "A";
            tree.Childrens = new List<MTreeNode> {
                new MTreeNode
                {
                    NChildren =2,
                    Id ="11",
                    Name ="B",
                    Childrens= new List<MTreeNode>
                                {   new MTreeNode
                                    {
                                        NChildren =1,
                                        Id ="111",
                                        Name ="E",
                                        Childrens= new List<MTreeNode> { new MTreeNode { NChildren = 0, Id = "1111", Name = "G",Childrens=null} }
                                    },
                                    new MTreeNode{NChildren =0,Id ="112", Name ="F",Childrens=null }
                                }
                },
                new MTreeNode { NChildren =0,Id ="12", Name ="C",Childrens=null },
                new MTreeNode { NChildren =0,Id ="13", Name ="D",Childrens=null} };

            return tree;
        }

        /// <summary>
        /// 根据层次数据构建多叉树
        /// </summary>
        /// <returns></returns>
        public static MTreeNode CreateFakeMTreeByLevelData()
        {
            return new OrgMTree().CreateFakeMTree();
        }
        
        /// <summary>
        /// 打印遍历节点名称
        /// </summary>
        /// <param name="travelNodes"></param>
        /// <param name="travelType"></param>
        /// <param name="travelOrder"></param>
        /// <param name="arithmeticType"></param>
        public static void PrintTravelNodeNames(List<MTreeNode> travelNodes, 
            EnumTravelType travelType,EnumTravelOrder travelOrder, EnumArithmeticType arithmeticType)
        {
            string names = string.Empty;
            string travelTypeName = string.Empty;
            string travelOrderName = string.Empty;
            string arithmeticTypeName = string.Empty;
            for (int i = 0; i < travelNodes.Count; i++)
            {
                if (i == 0)
                {
                    names += string.Format("{0}", travelNodes[i].Name);
                }
                else
                {
                    names += string.Format(",{0}", travelNodes[i].Name);
                }
            }

            LogHelper.GetInstance().WriteLog(string.Format("多叉树{0}优先{1}遍历（{2}）：{3}", 
                EnumParser.ParseEnumTravelType(travelType),
                EnumParser.ParseEnumTravelOrder(travelOrder),
                EnumParser.ParseEnumArithmeticType(arithmeticType),
                names));
        }
    }
}
