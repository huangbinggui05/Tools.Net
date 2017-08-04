using HBG.Utils.Log;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBG.Utils.Tree
{
    /// <summary>
    /// 多叉树
    /// </summary>
    public class MTree : ITreeUnRecursionTravel<MTreeNode>, ITreeRecursionTravel<MTreeNode>
    {
        /// <summary>
        /// 多叉树广度优先遍历（非递归实现）
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<MTreeNode> BreadthFirstTravel(MTreeNode root)
        {
            List<MTreeNode> travelNodes = new List<MTreeNode>();
            MTreeNode node = root;
            if (node == null) return travelNodes;

            Queue<MTreeNode> queue = new Queue<MTreeNode>();
            queue.Enqueue(node);
            while (queue.Any<MTreeNode>())
            {
                node = queue.Dequeue();
                travelNodes.Add(node);
                if (node.Childrens != null)
                {
                    foreach (MTreeNode item in node.Childrens)
                    {
                        queue.Enqueue(item);
                        node = item;
                    }
                }
            }
            
            return travelNodes;
        }
        /// <summary>
        /// 多叉树深度优先遍历（非递归实现）
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<MTreeNode> DepthFirstTravel(MTreeNode root)
        {
            //待实现 
            return null;
        }
        /// <summary>
        /// 多叉树广度优先遍历（递归实现）
        /// </summary>
        /// <param name="travelNodes"></param>
        /// <param name="root"></param>
        public void BreadthFirstTravel(ref List<MTreeNode> travelNodes, MTreeNode root)
        {
            //待实现 
        }

        /// <summary>
        /// 多叉树深度优先（前序）遍历（递归实现）
        /// </summary>
        /// <param name="travelNodes"></param>
        /// <param name="root"></param>
        public void DepthFirstTravel(ref List<MTreeNode> travelNodes, MTreeNode root)
        {
            MTreeNode node = root;
            if (node == null) return;

            travelNodes.Add(node);
            if (node.Childrens != null)
            {
                for (int i = 0; i < node.Childrens.Count; i++)
                {
                    DepthFirstTravel(ref travelNodes, node.Childrens[i]);
                }
            }
        }
    }
}
