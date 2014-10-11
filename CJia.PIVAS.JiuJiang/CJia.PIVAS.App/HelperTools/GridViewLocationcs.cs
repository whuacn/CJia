using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.App.HelperTools
{
    public class GridViewLocationcs
    {
        DevExpress.XtraGrid.Views.Grid.GridView gridView = null;
        int oldTopRow = 0;
        int rowHandle = 0;

        /// <summary>
        /// 初始化gridview位置类
        /// </summary>
        /// <param name="gridView"></param>
        public GridViewLocationcs(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            this.gridView = gridView;
        }

        /// <summary>
        /// 保存当前位置
        /// </summary>
        public void GetLocation()
        {
            try
            {
                this.oldTopRow = this.gridView.TopRowIndex;
                this.rowHandle = this.gridView.FocusedRowHandle;
            }
            catch
            {
            }
        }

        /// <summary>
        /// 设置回上次保存的位置
        /// </summary>
        public void SetLocation()
        {
            try
            {
                this.gridView.FocusedRowHandle = rowHandle;
                this.gridView.TopRowIndex = oldTopRow;
            }
            catch
            {
            }
        }

        public void gridViewMove(int count)
        {
            try
            {
                if(count > 0)
                {
                    for(int i = 0; i < count; i++)
                    {
                        this.gridView.MoveNext();
                    }
                }
                else if(count < 0)
                {
                    for(int i = 0; i > count; i--)
                    {
                        this.gridView.MovePrev();
                    }
                }
                else
                {

                }
            }
            catch
            {
            }
        }
    }
}
