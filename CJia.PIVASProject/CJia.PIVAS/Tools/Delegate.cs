using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Tools
{
    public class Delegate
    {
        public delegate void NoResNoPar();  
        public delegate void NoResOnePar(object parameter1);
        public delegate void NoResTwoPar(object parameter1, object parameter2);
        public delegate void NoResThreePar(object parameter1, object parameter2, object parameter3);
        public delegate void NoResFourPar(object parameter1, object parameter2, object parameter3, object parameter4);
        public delegate void NoResFivePar(object parameter1, object parameter2, object parameter3, object parameter4, object parameter5);

        public delegate object ResNoPar();
        public delegate object ResOnePar(object parameter1);
        public delegate object ResTwoPar(object parameter1, object parameter2);
        public delegate object ResThreePar(object parameter1, object parameter2, object parameter3);
        public delegate object ResFourPar(object parameter1, object parameter2, object parameter3, object parameter4);
        public delegate object ResFivePar(object parameter1, object parameter2, object parameter3, object parameter4, object parameter5);

    }
}
