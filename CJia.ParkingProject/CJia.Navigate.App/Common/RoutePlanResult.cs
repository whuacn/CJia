using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CJia.Navigate.App.Common
{
    public class RoutePlanResult
    {
        public RoutePlanResult(string[] passedNodes, double value,List<Point> pointlist)
        {
            m_resultNodes = passedNodes;
            m_value = value;
            m_pointList = pointlist;
        }

        private string[] m_resultNodes;
        /// <summary>
        /// 最短路径经过的节点
        /// </summary>
        public string[] ResultNodes
        {
            get { return m_resultNodes; }
        }

        private double m_value;
        /// <summary>
        /// 最短路径的值
        /// </summary>
        private double Value
        {
            get { return m_value; }
        }

        private List<Point> m_pointList;
        public List<Point> PointList
        {
            get
            {
                return m_pointList;
            }
        }
    }
}
