using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBG.Utils.Tree
{
    /// <summary>
    /// 树遍历（非递归算法）
    /// </summary>
    public interface ITreeUnRecursionTravel<T> where T : TreeNode
    {
        /// <summary>
        /// 广度优先遍历
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <returns></returns>
        List<T> BreadthFirstTravel(T root);

        /// <summary>
        /// 深度优先遍历
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <returns></returns>
        List<T> DepthFirstTravel(T root);
    }
}
