using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBG.Utils.Tree
{
    public static class EnumParser
    {
        public static string ParseEnumTravelType(EnumTravelType travelType)
        {
            string name = string.Empty;
            switch (travelType)
            {
                case EnumTravelType.Breadth:
                    name = "广度";
                    break;
                case EnumTravelType.Depth:
                    name = "宽度";
                    break;
                default:
                    break;
            }
            return name;
        }
        public static string ParseEnumTravelOrder(EnumTravelOrder travelOrder)
        {
            string name = string.Empty;
            switch (travelOrder)
            {
                case EnumTravelOrder.None:
                    name = "";
                    break;
                case EnumTravelOrder.PreOrder:
                    name = "前序";
                    break;
                case EnumTravelOrder.InOrder:
                    name = "中序";
                    break;
                case EnumTravelOrder.PostOrder:
                    name = "后序";
                    break;
                default:
                    break;
            }
            return name;
        }
        public static string ParseEnumArithmeticType(EnumArithmeticType arithmeticType)
        {
            string name = string.Empty;
            switch (arithmeticType)
            {
                case EnumArithmeticType.Recursion:
                    name = "递归算法";
                    break;
                case EnumArithmeticType.UnRecursion:
                    name = "非递归算法";
                    break;
                default:
                    break;
            }
            return name;
        }
    }
}
