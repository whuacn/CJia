using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;

namespace CJia.iSmartMedical.Data
{
    public class iFunction
    {
        public iFunction(string functionName,int index,Type targetType,Frame parentFrame,Color fontColor,string inhosID)
        {
            Name = functionName;
            Index = index;
            TargetPage = targetType;
            ParentFrame = parentFrame;
            FontColor = fontColor;
            InhosID = inhosID;
        }
        public string Name { get; set; }
        public int Index { get; set; }
        public Type TargetPage { get; set; }
        public Frame ParentFrame { get; set; }
        public Color FontColor { get; set; }
        public string InhosID { get; set; }
        public AppBar BottomAppBar { get; set; }
    }
}
