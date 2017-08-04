using HBG.Utils.Log;
using HBG.Utils.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeConstruction
{
    public static class MockBTree
    {
        /// <summary>
        /// 构建二叉树
        /// </summary>
        /// <returns></returns>
        public static BTreeNode CreateFakeBTree()
        {
            BTreeNode tree = new BTreeNode()
            {
                Id = "0",
                Name = "A",
                LChildren = new BTreeNode()
                {
                    Id = "1",
                    Name = "B",
                    LChildren = new BTreeNode()
                    {
                        Id = "3",
                        Name = "D",
                        LChildren = new BTreeNode()
                        {
                            Id = "5",
                            Name = "F",
                            LChildren = null,
                            RChildren = null
                        },
                    },
                    RChildren = new BTreeNode()
                    {
                        Id = "4",
                        Name = "E",
                        LChildren = null,
                        RChildren = null
                    }
                },
                RChildren = new BTreeNode()
                {
                    Id = "2",
                    Name = "C",
                    LChildren = null,
                    RChildren = null
                }
            };
            return tree;
        }

        /// <summary>
        /// 打印遍历节点名称
        /// </summary>
        public static void PrintTravelNodeNames(List<BTreeNode> travelNodes,
            EnumTravelType travelType, EnumTravelOrder travelOrder, EnumArithmeticType arithmeticType)
        {
            string names = string.Empty;
            string travelTypeName = string.Empty;
            string arithmeticTypeName = string.Empty;
            for (int i = 0; i < travelNodes.Count; i++)
            {
                if (i==0)
                {
                    names += string.Format("{0}", travelNodes[i].Name);
                }
                else
                {
                    names += string.Format(",{0}", travelNodes[i].Name);
                }
            }

            LogHelper.GetInstance().WriteLog(string.Format("二叉树{0}优先{1}遍历（{2}）：{3}",
                    EnumParser.ParseEnumTravelType(travelType),
                    EnumParser.ParseEnumTravelOrder(travelOrder),
                    EnumParser.ParseEnumArithmeticType(arithmeticType),
                    names));
        }
    }
}
