using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CJia.Navigate.App.Common  
{
    public static class Graph 
    {
        //public static List<Node> m_nodeList = null;
        //public static Graph()
        //{
        //    m_nodeList = new List<Node>();
        //}

        /// <summary>
        /// 获取图的节点集合
        /// </summary>
        //public static List<Node> NodeList
        //{
        //    get { return m_nodeList; }
        //}

        /// <summary>
        /// 初始化拓扑图
        /// </summary>
        //public static void Init()
        //{
            //NodeA
            //Node aNode = new Node("A");
            //m_nodeList.Add(aNode);
            ////A -> B
            ////Edge aEdge1 = new Edge();
            ////aEdge1.StartNodeID = aNode.ID;
            ////aEdge1.EndNodeID = "B";
            ////aEdge1.Weight = 26;
            //aNode.EdgeList.Add(new Edge("A", "B", 26));

            ////NodeB
            //Node bNode = new Node("B");
            //m_nodeList.Add(bNode);
            ////B->C
            ////Edge bEdge1 = new Edge();
            ////bEdge1.StartNodeID = bNode.ID;
            ////bEdge1.EndNodeID = "C";
            ////bEdge1.Weight = 15;
            //bNode.EdgeList.Add(new Edge("B","C",15));

            ////---------------------------
            ////B->A
            ////Edge bEdge2 = new Edge();
            ////bEdge2.StartNodeID = bNode.ID;
            ////bEdge2.EndNodeID = "A";
            ////bEdge2.Weight = 26;
            //bNode.EdgeList.Add(new Edge("B","A",26));
            ////---------------------------

            ////NodeC
            //Node cNode = new Node("C");
            //m_nodeList.Add(cNode);
            ////C->D
            ////Edge cEdge1 = new Edge();
            ////cEdge1.StartNodeID = cNode.ID;
            ////cEdge1.EndNodeID = "D";
            ////cEdge1.Weight = 92;
            //cNode.EdgeList.Add(new Edge("C","D",92));
            ////C->H
            ////Edge cEdge2 = new Edge();
            ////cEdge2.StartNodeID = cNode.ID;
            ////cEdge2.EndNodeID = "H";
            ////cEdge2.Weight = 183;
            //cNode.EdgeList.Add(new Edge("C","H",183));

            ////------------------------------
            ////C->B
            ////Edge cEdge3 = new Edge();
            ////cEdge3.StartNodeID = cNode.ID;
            ////cEdge3.EndNodeID = "H";
            ////cEdge3.Weight = 15;
            //cNode.EdgeList.Add(new Edge("C","B",15));
            ////------------------------------

            ////Node D
            //Node dNode = new Node("D");
            //m_nodeList.Add(dNode);
            ////D->E
            ////Edge dEdge1 = new Edge();
            ////dEdge1.StartNodeID = dNode.ID;
            ////dEdge1.EndNodeID = "E";
            ////dEdge1.Weight = 148;
            //dNode.EdgeList.Add(new Edge("D","E",148));
            ////D->G
            ////Edge dEdge2 = new Edge();
            ////dEdge2.StartNodeID = dNode.ID;
            ////dEdge2.EndNodeID = "G";
            ////dEdge2.Weight = 183;
            //dNode.EdgeList.Add(new Edge("D","G",183));
            ////-----------------------------
            ////D->C
            ////Edge dEdge3 = new Edge();
            ////dEdge3.StartNodeID = dNode.ID;
            ////dEdge3.EndNodeID = "C";
            ////dEdge3.Weight = 92;
            //dNode.EdgeList.Add(new Edge("D","C",92));
            ////-----------------------------

            ////Node E
            //Node eNode = new Node("E");
            //m_nodeList.Add(eNode);
            ////E->F
            ////Edge eEdge1 = new Edge();
            ////eEdge1.StartNodeID = eNode.ID;
            ////eEdge1.EndNodeID = "F";
            ////eEdge1.Weight = 183;
            //eNode.EdgeList.Add(new Edge("E","F",183));
            ////---------------------------
            ////E->D
            ////Edge eEdge2 = new Edge();
            ////eEdge2.StartNodeID = eNode.ID;
            ////eEdge2.EndNodeID = "D";
            ////eEdge2.Weight = 148;
            //eNode.EdgeList.Add(new Edge("E","D",148));
            ////---------------------------

            ////Node F
            //Node fNode = new Node("F");
            //m_nodeList.Add(fNode);
            ////F->G
            ////Edge fEdge1 = new Edge();
            ////fEdge1.StartNodeID = fNode.ID;
            ////fEdge1.EndNodeID = "G";
            ////fEdge1.Weight = 148;
            //fNode.EdgeList.Add(new Edge("F","G",148));
            ////-----------------------------
            ////F->E
            ////Edge fEdge2 = new Edge();
            ////fEdge2.StartNodeID = fNode.ID;
            ////fEdge2.EndNodeID = "E";
            ////fEdge2.Weight = 183;
            //fNode.EdgeList.Add(new Edge("F","E",183));
            ////------------------------------

            ////Node G
            //Node gNode = new Node("G");
            //m_nodeList.Add(gNode);
            ////G->I
            ////Edge gEdge1 = new Edge();
            ////gEdge1.StartNodeID = gNode.ID;
            ////gEdge1.EndNodeID = "I";
            ////gEdge1.Weight = 50;
            //gNode.EdgeList.Add(new Edge("G","I",50));
            ////-------------------------------
            ////G->F
            ////Edge gEdge2 = new Edge();
            ////gEdge2.StartNodeID = gNode.ID;
            ////gEdge2.EndNodeID = "F";
            ////gEdge2.Weight = 148;
            //gNode.EdgeList.Add(new Edge("G","F",148));

            ////G->D
            ////Edge gEdge3 = new Edge();
            ////gEdge3.StartNodeID = gNode.ID;
            ////gEdge3.EndNodeID = "D";
            ////gEdge3.Weight = 183;
            //gNode.EdgeList.Add(new Edge("G","D",183));
            ////-------------------------------

            ////NodeI
            //Node iNode = new Node("I");
            //m_nodeList.Add(iNode);
            ////I->H
            ////Edge iEdge1 = new Edge();
            ////iEdge1.StartNodeID = iNode.ID;
            ////iEdge1.EndNodeID = "H";
            ////iEdge1.Weight = 42;
            //iNode.EdgeList.Add(new Edge("I","H",42));
            ////I->J
            ////Edge iEdge2 = new Edge();
            ////iEdge2.StartNodeID = iNode.ID;
            ////iEdge2.EndNodeID = "J";
            ////iEdge2.Weight = 57;
            //iNode.EdgeList.Add(new Edge("I","J",57));
            ////-------------------------------
            ////I->G
            ////Edge iEdge3 = new Edge();
            ////iEdge3.StartNodeID = iNode.ID;
            ////iEdge3.EndNodeID = "G";
            ////iEdge3.Weight = 50;
            //iNode.EdgeList.Add(new Edge("I","G",50));
            ////-------------------------------

            ////Node J
            //Node jNode = new Node("J");
            //m_nodeList.Add(jNode);
            ////-------------------------
            ////J->I
            ////Edge jEdge1 = new Edge();
            ////jEdge1.StartNodeID = jNode.ID;
            ////jEdge1.EndNodeID = "I";
            ////jEdge1.Weight = 57;
            //jNode.EdgeList.Add(new Edge("J","I",57));
            ////-------------------------

            ////NOde H
            //Node hNode = new Node("H");
            //m_nodeList.Add(hNode);
            ////---------------------------------------
            ////H->C
            ////Edge hEdge1 = new Edge();
            ////hEdge1.StartNodeID = hNode.ID;
            ////hEdge1.EndNodeID = "C";
            ////hEdge1.Weight = 183;
            //hNode.EdgeList.Add(new Edge("H","C",183));
            ////H->I
            ////Edge hEdge2 = new Edge();
            ////hEdge2.StartNodeID = hNode.ID;
            ////hEdge2.EndNodeID = "I";
            ////hEdge2.Weight = 42;
            //hNode.EdgeList.Add(new Edge("H","I",42));
            //-----------------------------------

        //    DataTable dtPoint = CJia.DefaultPostgre.Query(CJia.Parking.Models.SqlTools.SqlQueryPoint);
        //    for (int i = 0; i < dtPoint.Rows.Count; i++)
        //    {
        //        m_nodeList.Add(new Node(dtPoint.Rows[i]["POINT_NO"].ToString()));
        //        DataTable DtPointToPoint = CJia.DefaultPostgre.Query(CJia.Parking.Models.SqlTools.SqlQueryPointToPoint, new object[] { dtPoint.Rows[i]["POINT_ID"].ToString() });
        //        for(int j=0;j<DtPointToPoint.Rows.Count;j++)
        //        {
        //            m_nodeList[m_nodeList.Count - 1].EdgeList.Add(new Edge(DtPointToPoint.Rows[j]["POINT_NO"].ToString(), DtPointToPoint.Rows[j]["TO_POINT_NO"].ToString(), Convert.ToDouble(DtPointToPoint.Rows[j]["LEN"])));
        //        }
        //    }
        //}

        private static List<Node> nodelist;
        public static List<Node> Nodelist
        {
            set
            {
                nodelist = value;
            }
            get
            {
                return nodelist;
            }
        }
        

        //public static List<Node> Init()
        //{
        //    List<Node> NodeList = new List<Node>();
        //    DataTable dtPoint = CJia.DefaultPostgre.Query(CJia.Parking.Models.SqlTools.SqlQueryPoint);
        //    for (int i = 0; i < dtPoint.Rows.Count; i++)
        //    {
        //        NodeList.Add(new Node(dtPoint.Rows[i]["POINT_NO"].ToString(), new Point(Convert.ToInt32(dtPoint.Rows[i]["point_X"]), Convert.ToInt32(dtPoint.Rows[i]["point_Y"]))));
        //        DataTable DtPointToPoint = CJia.DefaultPostgre.Query(CJia.Parking.Models.SqlTools.SqlQueryPointToPoint, new object[] { dtPoint.Rows[i]["POINT_ID"].ToString() });
        //        for (int j = 0; j < DtPointToPoint.Rows.Count; j++)
        //        {
        //            NodeList[NodeList.Count - 1].EdgeList.Add(new Edge(DtPointToPoint.Rows[j]["POINT_NO"].ToString(), DtPointToPoint.Rows[j]["TO_POINT_NO"].ToString(), Convert.ToDouble(DtPointToPoint.Rows[j]["LEN"])));
        //        }
        //    }
        //    return NodeList;
        //}
    }
}
