using HBG.Utils.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBG.Utils.Tree
{
    /// <summary>
    /// 二叉树
    /// </summary>
    public class BTree: ITreeUnRecursionTravel<BTreeNode>, ITreeRecursionTravel<BTreeNode>
    {
        private EnumTravelOrder travelType = EnumTravelOrder.PreOrder;//默认前序遍历

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="travelType"></param>
        public BTree(EnumTravelOrder travelType)
        {
            this.travelType = travelType;
        }

        /// <summary>
        /// 二叉树广度优先遍历（非递归实现）
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<BTreeNode> BreadthFirstTravel(BTreeNode root)
        {
            List<BTreeNode> travelNodes = new List<BTreeNode>();
            BTreeNode node = root;
            if (node == null) return travelNodes;

            Queue<BTreeNode> q = new Queue<BTreeNode>();
            q.Enqueue(node);

            while (q.Any())
            {
                var item = q.Dequeue();
                travelNodes.Add(item);

                if (item.LChildren != null)
                {
                    q.Enqueue(item.LChildren);
                }

                if (item.RChildren != null)
                {
                    q.Enqueue(item.RChildren);
                }
            }
            return travelNodes;
        }

        /// <summary>
        /// 二叉树深度优先遍历（非递归实现）
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<BTreeNode> DepthFirstTravel(BTreeNode root)
        {
            List<BTreeNode> travelNodes = new List<BTreeNode>();
            BTreeNode node = root;
            if (node == null) return travelNodes;
            
            Stack<BTreeNode> stack = new Stack<BTreeNode>();
            switch (travelType)
            {
                case EnumTravelOrder.PreOrder:
                    #region 前序
                    while (node != null || stack.Any())
                    {
                        if (node != null)
                        {
                            stack.Push(node);
                            travelNodes.Add(node);
                            node = node.LChildren;
                        }
                        else
                        {
                            var item = stack.Pop();
                            node = item.RChildren;
                        }
                    }
                    break;
                    #endregion
                case EnumTravelOrder.InOrder:
                    #region 中序
                    while (node != null || stack.Any())
                    {
                        if (node != null)
                        {
                            stack.Push(node);
                            node = node.LChildren;
                        }
                        else
                        {
                            var item = stack.Pop();
                            travelNodes.Add(item);
                            node = item.RChildren;
                        }
                    }
                    break;
                    #endregion
                case EnumTravelOrder.PostOrder:
                    #region 后序
                    BTreeNode pre = null;
                    stack.Push(node);

                    while (stack.Any())
                    {
                        node = stack.Peek();
                        if ((node.LChildren == null && node.RChildren == null) ||
                            (pre != null && (pre == node.LChildren || pre == node.RChildren)))
                        {
                            travelNodes.Add(node);
                            pre = node;

                            stack.Pop();
                        }
                        else
                        {
                            if (node.RChildren != null)
                                stack.Push(node.RChildren);

                            if (node.LChildren != null)
                                stack.Push(node.LChildren);
                        }
                    }
                    break;
                    #endregion
                default:
                    break;
            }
            return travelNodes;
        }

        /// <summary>
        /// 二叉树广度优先遍历（递归实现）
        /// </summary>
        /// <param name="travelNodes"></param>
        /// <param name="root"></param>
        public void BreadthFirstTravel(ref List<BTreeNode> travelNodes, BTreeNode root)
        {
            //待实现 
        }

        /// <summary>
        /// 二叉树深度优先遍历（递归实现）
        /// </summary>
        /// <param name="travelNodes"></param>
        /// <param name="root"></param>
        public void DepthFirstTravel(ref List<BTreeNode> travelNodes, BTreeNode root)
        {
            BTreeNode node = root;
            if (node == null) return;

            switch (travelType)
            {
                case EnumTravelOrder.PreOrder:
                    travelNodes.Add(node);
                    DepthFirstTravel(ref travelNodes, node.LChildren);
                    DepthFirstTravel(ref travelNodes, node.RChildren);
                    break;
                case EnumTravelOrder.InOrder:
                    DepthFirstTravel(ref travelNodes, node.LChildren);
                    travelNodes.Add(node);
                    DepthFirstTravel(ref travelNodes, node.RChildren);
                    break;
                case EnumTravelOrder.PostOrder:
                    DepthFirstTravel(ref travelNodes ,node.LChildren);
                    DepthFirstTravel(ref travelNodes , node.RChildren);
                    travelNodes.Add(node);
                    break;
                default:
                    break;
            }
        }
    }
}
