using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;

namespace CJia.Parking.App.UI
{
    public partial class AreaManageView : CJia.Parking.Tools.View,CJia.Parking.Views.IAreaManageView
    {
        public AreaManageView()
        {
            InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.AreaManagePresenter(this);
        }

        Views.AreaManageArgs areaArgs = new Views.AreaManageArgs();

        #region 【界面事件】
        private void AreaManageView_SizeChanged(object sender, EventArgs e)
        {
            int width = this.Width;
            int height = this.Height;
            int bottom = 7; // 控件距离底部高度
            int spaceFloorArea = 10;  // 楼层和区域之间距离
            int spaceAreaPark = 17;  // 区域和车位之间距离

            pnlFloor.Width = width / 6 + 70;
            pnlFloor.Height = height - bottom;

            pnlArea.Location = new System.Drawing.Point(pnlFloor.Width + spaceFloorArea, 3);
            pnlArea.Width = width / 3 - 25;
            pnlArea.Height = height - bottom;

            pnlPark.Location = new System.Drawing.Point(pnlFloor.Width + pnlArea.Width + spaceAreaPark, 3);
            pnlPark.Width = width - pnlFloor.Width - pnlArea.Width - 25; // 最后一块 = 整长-前面块数-间距
            pnlPark.Height = height - bottom;
        }

        private void AreaManageView_Load(object sender, EventArgs e)
        {
            OnInit(null, null);
        }

        private void gvwFloor_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
           Tools.Help.GridViewDrawEmptyForeground(gvwFloor, sender, e);
        }

        private void gvwArea_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            Tools.Help.GridViewDrawEmptyForeground(gvwArea, sender, e);
        }

        private void gvwPark_CustomDrawEmptyForeground(object sender, CustomDrawEventArgs e)
        {
            Tools.Help.GridViewDrawEmptyForeground(gvwPark, sender, e);
        }

        private void gvwFloor_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gvwFloor.FocusedRowHandle < 0)
            {
                txtFloorNo.Text = "";
                return;
            }
            areaArgs.FloorSaveStatus = "update";
            DataRow dr = gvwFloor.GetFocusedDataRow();
            if (dr != null)
            {
                this.txtFloorNo.Text = dr["floor_no"].ToString();

                areaArgs.FloorId = (long)dr["floor_id"];
                areaArgs.OldFloorNo = dr["floor_no"].ToString();
                OnGridFloorClick(sender, areaArgs);
                //OnGridAreaClick(sender,areaArgs);
                gvwArea_FocusedRowChanged(sender, e);
            }
           
        }
        

        private void btnFloorSave_Click(object sender, EventArgs e)
        {
            if (IsNullReturnFloor())
            {
                return;
            }
            areaArgs.FloorNo = this.txtFloorNo.Text;
            OnFloorSave(sender,areaArgs);
            this.txtFloorNo.Text = "";
        }

       
        private void btnFloorAdd_Click(object sender, EventArgs e)
        {
            areaArgs.FloorId = -1;
            areaArgs.FloorSaveStatus = "add";
            this.txtFloorNo.Text = "";
        }

        private void btnFloorDelete_Click(object sender, EventArgs e)
        {
            if (gvwFloor.FocusedRowHandle < 0)
            {
                return;
            }
            DataRow dr = gvwFloor.GetFocusedDataRow();
            if (dr != null)
            {
                areaArgs.FloorId = (long)(dr["floor_id"]);
                areaArgs.FloorNo = dr["floor_no"].ToString();
                OnFloorDelete(sender, areaArgs);
                gvwFloor_FocusedRowChanged(null,null);
            }
            
        }

        private void gvwArea_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gvwArea.FocusedRowHandle < 0)
            {
                txtAreaNo.Text = "";
                gridPark.DataSource = null;
                return;
            }

            areaArgs.AreaSaveStatus = "update";
            DataRow dr = gvwArea.GetFocusedDataRow();
            if (dr != null)
            {
                areaArgs.AreaId = (long)dr["area_id"];
                areaArgs.OldAreaNo = dr["area_no"].ToString();
                areaArgs.OldFloorNo = dr["floor_no"].ToString();
                this.txtAreaNo.Text = dr["area_no"].ToString();

                OnGridAreaClick(sender, areaArgs);
            }
           
        }
       

        private void btnAreaSave_Click(object sender, EventArgs e)
        {
            if (IsNullReturnArea())
            {
                return;
            }
            areaArgs.AreaNo = this.txtAreaNo.Text;
            OnAreaSave(null,areaArgs);
            this.txtAreaNo.Text = "";
        }

        private void btnAreaAdd_Click(object sender, EventArgs e)
        {
            areaArgs.AreaId = -1; // 保存时，如是新增有重名则提示并返回，修改则不处理
            areaArgs.AreaSaveStatus = "add";
            this.txtAreaNo.Text = "";
        }
        private void btnAreaDelete_Click(object sender, EventArgs e)
        {
            if (gvwArea.FocusedRowHandle < 0)
            {
                return;
            }
            OnAreaDelete(null, areaArgs);
            gvwArea_FocusedRowChanged(null, null);
        }


        private void gvwPark_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gvwPark.FocusedRowHandle < 0)
            {
                txtParkNo.Text = "";
                txtCameraNo.Text = "";
                return;
            }
            areaArgs.ParkSaveStatus = "update";
            DataRow dr = gvwPark.GetFocusedDataRow();
            if (dr != null)
            {
                this.txtParkNo.Text = dr["park_no"].ToString();
                this.txtCameraNo.Text = dr["camera_no"].ToString();
                areaArgs.ParkId = (long)dr["park_id"];
                areaArgs.OldParkNo = dr["park_no"].ToString();
                areaArgs.CameraNo = dr["camera_no"].ToString();
            }
        }
       
        private void btnParkSave_Click(object sender, EventArgs e)
        {
            if (IsNullReturnPark())
            {
                return;
            }
            areaArgs.ParkNo = this.txtParkNo.Text;
            areaArgs.CameraNo = this.txtCameraNo.Text;
            OnParkSave(null, areaArgs);
        }

        private void btnParkAdd_Click(object sender, EventArgs e)
        {
            areaArgs.ParkId = -1; // 保存时，如是新增有重名则提示并返回，修改则不处理
            areaArgs.ParkSaveStatus = "add";
            this.txtParkNo.Text = "";
            this.txtCameraNo.Text = "";
        }

        private void btnParkDelete_Click(object sender, EventArgs e)
        {
            if (gvwPark.FocusedRowHandle < 0)
            {
                return;
            }
            OnParkDelete(null,areaArgs);
            gvwPark_FocusedRowChanged(null,null);
        }

        #endregion

        #region 【实现接口】
        /// <summary>
        /// 绑定楼层
        /// </summary>
        /// <param name="dtFloor"></param>
        public void ExeBindGridFloor(DataTable dtFloor)
        {
            this.gridFloor.DataSource = dtFloor;
        }

        /// <summary>
        /// 绑定区域
        /// </summary>
        /// <param name="dtArea"></param>
        public void ExeBindGridArea(DataTable dtArea)
        {
            this.gridArea.DataSource = dtArea;
        }

        /// <summary>
        /// 绑定车位
        /// </summary>
        /// <param name="dtPark"></param>
        public void ExeBindGridPark(DataTable dtPark)
        {
            this.gridPark.DataSource = dtPark;
        }
        #endregion

        #region 【自定义方法】
        /// <summary>
        /// 楼层数据为空返回
        /// </summary>
        /// <returns></returns>
        public bool IsNullReturnFloor()
        {
            if (this.txtFloorNo.Text == "")
            {
                MessageBox.Show("楼层编号不能为空！");
                return true;
            }
            return false;
        }

        /// <summary>
        /// 区域数据为空返回
        /// </summary>
        /// <returns></returns>
        public bool IsNullReturnArea()
        {
            if (this.txtAreaNo.Text == "")
            {
                MessageBox.Show("区域编号不能为空！");
                return true;
            }
            if (areaArgs.FloorId == 0)
            {
                MessageBox.Show("请先选择楼层编号！");
                return true;
            }
            return false;
        }

        /// <summary>
        /// 车位数据为空返回
        /// </summary>
        /// <returns></returns>
        public bool IsNullReturnPark()
        {
            if (txtParkNo.Text == "")
            {
                MessageBox.Show("车位编号不能为空！");
                return true;
            }
            if (txtCameraNo.Text == "")
            {
                MessageBox.Show("摄像机编号不能为空！");
                return true;
            }
            return false;
        }
        #endregion

        #region 【接口层事件】
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.AreaManageArgs> OnInit;

        /// <summary>
        /// 保存楼层信息
        /// </summary>
        public event EventHandler<Views.AreaManageArgs> OnFloorSave;

        /// <summary>
        /// 删除楼层
        /// </summary>
        public event EventHandler<Views.AreaManageArgs> OnFloorDelete;

        /// <summary>
        /// 保存区域信息
        /// </summary>
        public event EventHandler<Views.AreaManageArgs> OnAreaSave;

        /// <summary>
        /// 删除区域
        /// </summary>
        public event EventHandler<Views.AreaManageArgs> OnAreaDelete;

        /// <summary>
        /// 单击Grid楼层事件
        /// </summary>
        public event EventHandler<Views.AreaManageArgs> OnGridFloorClick;

        /// <summary>
        /// 保存车位信息
        /// </summary>
        public event EventHandler<Views.AreaManageArgs> OnParkSave;

        /// <summary>
        /// 删除车位
        /// </summary>
        public event EventHandler<Views.AreaManageArgs> OnParkDelete;

        /// <summary>
        /// 单击Grid区域事件
        /// </summary>
        public event EventHandler<Views.AreaManageArgs> OnGridAreaClick;
        #endregion

        #region 【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                    btnFloorSave_Click(null, null);
                    return true;
                case Keys.F2:
                    btnParkAdd_Click(null, null);
                    return true;
                case Keys.F3:
                    btnParkDelete_Click(null, null);
                    return true;
                case Keys.F4:
                    btnAreaSave_Click(null, null);
                    return true;
                case Keys.F5:
                    btnAreaAdd_Click(null, null);
                    return true;
                case Keys.F6:
                    btnAreaDelete_Click(null, null);
                    return true;
                case Keys.F7:
                    btnParkSave_Click(null, null);
                    return true;
                case Keys.F8:
                    btnParkAdd_Click(null, null);
                    return true;
                case Keys.F9:
                    btnParkDelete_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

    }
}
