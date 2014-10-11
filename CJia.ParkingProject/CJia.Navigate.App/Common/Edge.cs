using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Navigate.App.Common
{
    public class Edge
    {
        public string StartNodeID;
        public string EndNodeID;
        public double Weight; //权值，代价    

        public Edge(string startNodeID, string endNodeID, double weight)
        {
            StartNodeID = startNodeID;
            EndNodeID = endNodeID;
            Weight = weight;
        }
    }
}
