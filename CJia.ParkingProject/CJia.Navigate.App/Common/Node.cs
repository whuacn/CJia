using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CJia.Navigate.App.Common
{
          
    public class Node
    {
        private string iD ;
        private List<Edge> edgeList ;//Edge的集合－－出边表
        private Point point; //位置

        public Node(string id,Point location )
        {
            this.iD = id ;
            this.edgeList = new  List<Edge>() ;
            this.point = location;
        }


       #region property
        
        public string ID
        {
            get
          {
                return this.iD ;
            }
        }

        public List<Edge>  EdgeList
        {
            get
            {
                return this.edgeList ;
            }
        }

        public Point Point
        {
            get 
            {
                return point;
            }
        }
        #endregion
    }
}
