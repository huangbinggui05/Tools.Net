using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBG.Utils;
using HBG.Utils.Log;

namespace MultiTreeConstruction
{
    public class OrgMultiTree : MultiTree
    {
        protected Queue<MultiTreeNode> queue = new Queue<MultiTreeNode>();//一般广度（宽度/层次）优先遍历时使用
        protected Stack<MultiTreeNode> stack; //一般深度优先遍历时使用

        public List<OrgModel> Orgs
        {
            get
            {
                List<OrgModel> orgs = new List<OrgModel>();

                OrgModel org0 = new OrgModel { OrgId = 0, OrgName = "广东移动", ParentOrgId = null };
                OrgModel org1 = new OrgModel { OrgId = 1, OrgName = "广州移动", ParentOrgId = 0 };
                OrgModel org2 = new OrgModel { OrgId = 2, OrgName = "深圳移动", ParentOrgId = 0 };
                OrgModel org3 = new OrgModel { OrgId = 3, OrgName = "佛山移动", ParentOrgId = 0 };
                OrgModel org4 = new OrgModel { OrgId = 4, OrgName = "网络管理中心", ParentOrgId = 0 };
                OrgModel org5 = new OrgModel { OrgId = 5, OrgName = "网络服务中心", ParentOrgId = 1 };
                OrgModel org6 = new OrgModel { OrgId = 6, OrgName = "网络管理中心", ParentOrgId = 1 };
                OrgModel org7 = new OrgModel { OrgId = 7, OrgName = "网络监控室", ParentOrgId = 4 };
                OrgModel org8 = new OrgModel { OrgId = 8, OrgName = "传输动力维护室", ParentOrgId = 6 };
                OrgModel org9 = new OrgModel { OrgId = 9, OrgName = "核心数据维护室", ParentOrgId = 6 };
                OrgModel org10 = new OrgModel { OrgId = 10, OrgName = "综合维护组", ParentOrgId = 6 };
                OrgModel org11 = new OrgModel { OrgId = 11, OrgName = "核心数据维护室", ParentOrgId = 4 };
                orgs.Add(org0);
                orgs.Add(org1);
                orgs.Add(org2);
                orgs.Add(org3);
                orgs.Add(org4);
                orgs.Add(org5);
                orgs.Add(org6);
                orgs.Add(org7);
                orgs.Add(org8);
                orgs.Add(org9);
                orgs.Add(org10);
                orgs.Add(org11);

                return orgs;
            }
        }

        /// <summary>
        /// 根据层次数据构建多叉树
        /// </summary>
        /// <returns></returns>
        public override MultiTreeNode CreateFakeMultiTree()
        {
            //构建根节点
            MultiTreeNode root = new MultiTreeNode();
            root.Childrens = new List<MultiTreeNode>();

            #region 构建 Hashtable
            Dictionary<string, MultiTreeNode> dic = new Dictionary<string, MultiTreeNode>();
            foreach (OrgModel item in Orgs)
            {
                MultiTreeNode node = new MultiTreeNode();
                node.Childrens = new List<MultiTreeNode>();
                string id = item.OrgId.ToString();
                node.Id = id;
                node.ParentId = item.ParentOrgId.HasValue ? item.ParentOrgId.Value.ToString() : string.Empty;
                node.Name = item.OrgName;

                dic.Add(id, node);
            }
            #endregion 

            #region Childrens
            foreach (string key in dic.Keys)
            {
                MultiTreeNode node = dic[key];
                string parentId = node.ParentId;
                if (string.IsNullOrEmpty(parentId))
                {
                    //获得根节点
                    root = node;
                }
                else
                {
                    try
                    {
                        //可能异常：给定关键字不在字典中
                        MultiTreeNode pNode = dic[parentId];

                        pNode.Childrens.Add(node);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.GetInstance().WriteLog(string.Format("异常：{0}\n{1}", ex.Message, ex.StackTrace), LogType.错误);
                    }
                }
            }
            #endregion

            #region 设置 NChildren  
            foreach (string key in dic.Keys)
            {
                MultiTreeNode node = dic[key];
                node.NChildren = node.Childrens.Count;
            }
            #endregion

            return root;
        }
    }
}
