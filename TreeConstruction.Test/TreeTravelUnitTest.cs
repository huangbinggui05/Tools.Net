using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HBG.Utils.Tree;
using HBG.Utils.Log;
using System.Collections.Generic;

namespace TreeConstruction.Test
{
    [TestClass]
    public class TreeTravelUnitTest
    {
        [TestMethod]
        public void TreeTravelTest()
        {
            BTreeTravelTest();
            MTreeTravelTest();
        }

        [TestMethod]
        public void BTreeTravelTest()
        {
            List<BTreeNode> travelNodes = new List<BTreeNode>();
            BTreeNode rootBTreeNode = MockBTree.CreateFakeBTree();

            #region 二叉树广度优先遍历

            //递归算法
            //travelNodes.Clear();
            //new BTree(EnumTravelOrder.PreOrder).BreadthFirstTravel(ref travelNodes, rootBTreeNode);
            //MockBTree.PrintTravelNodeNames(travelNodes, EnumTravelType.Breadth, EnumTravelOrder.None, EnumArithmeticType.Recursion);

            //非递归算法
            travelNodes.Clear();
            travelNodes = new BTree(EnumTravelOrder.PreOrder).BreadthFirstTravel(rootBTreeNode);
            MockBTree.PrintTravelNodeNames(travelNodes, EnumTravelType.Breadth, EnumTravelOrder.None, EnumArithmeticType.UnRecursion);

            #endregion

            #region 二叉树深度优先遍历

            #region 递归算法
            //前序
            travelNodes.Clear();
            new BTree(EnumTravelOrder.PreOrder).DepthFirstTravel(ref travelNodes, rootBTreeNode);
            MockBTree.PrintTravelNodeNames(travelNodes, EnumTravelType.Depth, EnumTravelOrder.PreOrder, EnumArithmeticType.Recursion);

            //中序
            travelNodes.Clear();
            new BTree(EnumTravelOrder.InOrder).DepthFirstTravel(ref travelNodes, rootBTreeNode);
            MockBTree.PrintTravelNodeNames(travelNodes, EnumTravelType.Depth, EnumTravelOrder.InOrder, EnumArithmeticType.Recursion);

            //后序
            travelNodes.Clear();
            new BTree(EnumTravelOrder.PostOrder).DepthFirstTravel(ref travelNodes, rootBTreeNode);
            MockBTree.PrintTravelNodeNames(travelNodes, EnumTravelType.Depth, EnumTravelOrder.PostOrder, EnumArithmeticType.Recursion);
            #endregion

            #region 非递归算法
            //前序
            travelNodes.Clear();
            travelNodes = new BTree(EnumTravelOrder.PreOrder).DepthFirstTravel(rootBTreeNode);
            MockBTree.PrintTravelNodeNames(travelNodes, EnumTravelType.Depth, EnumTravelOrder.PreOrder, EnumArithmeticType.UnRecursion);

            //中序
            travelNodes.Clear();
            travelNodes = new BTree(EnumTravelOrder.InOrder).DepthFirstTravel(rootBTreeNode);
            MockBTree.PrintTravelNodeNames(travelNodes, EnumTravelType.Depth, EnumTravelOrder.InOrder, EnumArithmeticType.UnRecursion);

            //后序
            travelNodes.Clear();
            travelNodes = new BTree(EnumTravelOrder.PostOrder).DepthFirstTravel(rootBTreeNode);
            MockBTree.PrintTravelNodeNames(travelNodes, EnumTravelType.Depth, EnumTravelOrder.PostOrder, EnumArithmeticType.UnRecursion);
            #endregion

            #endregion
        }

        [TestMethod]
        public void MTreeTravelTest()
        {
            List<MTreeNode> travelNodes = new List<MTreeNode>();
            MTreeNode rootMTreeNode = MockMTree.CreateFakeMTree();
            MTree mTree = new MTree();

            #region 多叉树广度优先遍历
            //递归算法
            //travelNodes.Clear();
            //mTree.DepthFirstTravel(ref travelNodes, rootMTreeNode);
            //MockMTree.PrintTravelNodeNames(travelNodes, EnumTravelType.Breadth,EnumTravelOrder.None, EnumArithmeticType.Recursion);

            //非递归算法
            travelNodes.Clear();
            travelNodes = mTree.BreadthFirstTravel(rootMTreeNode);
            MockMTree.PrintTravelNodeNames(travelNodes, EnumTravelType.Breadth, EnumTravelOrder.None, EnumArithmeticType.UnRecursion);
            #endregion

            #region 多叉树深度优先遍历
            //递归算法
            travelNodes.Clear();
            mTree.DepthFirstTravel(ref travelNodes, rootMTreeNode);
            MockMTree.PrintTravelNodeNames(travelNodes, EnumTravelType.Depth, EnumTravelOrder.None, EnumArithmeticType.Recursion);

            //非递归算法
            //travelNodes.Clear();
            //travelNodes = mTree.DepthFirstTravel(rootMTreeNode);
            //MockMTree.PrintTravelNodeNames(travelNodes, EnumTravelType.Depth,EnumTravelOrder.None, EnumArithmeticType.UnRecursion);
            #endregion
        }
    }
}
