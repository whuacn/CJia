using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CJia.Navigate.App.Common;

namespace CJia.Navigate.App
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //UI.Query query = new UI.Query();
            //frm.Controls.Add(query);
            //query.Dock = DockStyle.Fill;
            if (CJia.Parking.Tools.Help.SystemInitConfig())
            {
                //Graph.Init();
                Graph.Nodelist = Init();
                MainForm frm = new MainForm();
                //this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                //this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
                //frm.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                //frm.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
                Application.Run(frm);

                //Application.Run(new Form1());

                //UI.PointToPointView Point = new UI.PointToPointView();
                //ManageForm manfrm = new ManageForm();
                //manfrm.Controls.Add(Point);
                //manfrm.Dock = DockStyle.Fill;
                //Application.Run(manfrm);
            }
        }

        public static  List<Node> Init()
        {
            List<Node> NodeList = new List<Node>();
            DataTable dtPoint = CJia.DefaultPostgre.Query(CJia.Parking.Models.SqlTools.SqlQueryPoint);
            for (int i = 0; i < dtPoint.Rows.Count; i++)
            {
                NodeList.Add(new Node(dtPoint.Rows[i]["POINT_NO"].ToString(), new Point(Convert.ToInt32(dtPoint.Rows[i]["point_X"]), Convert.ToInt32(dtPoint.Rows[i]["point_Y"]))));
                DataTable DtPointToPoint = CJia.DefaultPostgre.Query(CJia.Parking.Models.SqlTools.SqlQueryPointToPoint, new object[] { dtPoint.Rows[i]["POINT_ID"].ToString() });
                for (int j = 0; j < DtPointToPoint.Rows.Count; j++)
                {
                    NodeList[NodeList.Count - 1].EdgeList.Add(new Edge(DtPointToPoint.Rows[j]["POINT_NO"].ToString(), DtPointToPoint.Rows[j]["TO_POINT_NO"].ToString(), Convert.ToDouble(DtPointToPoint.Rows[j]["LEN"])));
                }
            }
            return NodeList;
        }
    }
}
