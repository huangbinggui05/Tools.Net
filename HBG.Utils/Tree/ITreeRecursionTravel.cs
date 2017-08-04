using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBG.Utils.Tree
{
    /// <summary>
    /// 树遍历（递归算法）
    /// </summary>
    public interface ITreeRecursionTravel<T> where T : TreeNode
    {
        /// <summary>
        /// 广度优先遍历
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="root"></param>
        void BreadthFirstTravel(ref List<T> travelNodes, T root);

        /// <summary>
        /// 深度优先遍历
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="root"></param>
        void DepthFirstTravel(ref List<T> travelNodes, T root);
    }
}
