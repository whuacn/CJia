using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CJia.Health.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] str = { "2", "3", "4" };
            var s = from sleectStr in str
                    where sleectStr == "2"
                    select sleectStr;
            s.ToList();
            Bitmap bit = new Bitmap("");
            bit.RotateFlip(RotateFlipType.Rotate90FlipNone);
            //Image img = new System.Web.UI.WebControls.Image();
            
            
        }
    }
}