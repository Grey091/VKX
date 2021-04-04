using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FASTECH;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Diagnostics;
using LowLevelMouseHook;


namespace VKX_XYStage
{
    public partial class Form_xystage : Form, IMessageFilter
    {
        public Form_xystage()
        {
            InitializeComponent();
            MouseHook.InstallHook();
            MouseHook.LeftDown += MouseHook_LeftDown;
            MouseHook.LeftUp += MouseHook_LeftUp;
            //RegistryKey regkey = Registry.CurrentUser.CreateSubKey("Software\\VKX_XYStage");
            //RegistryKey regstart = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            //string keyvalue = "1";
            //try
            //{
            //    regkey.SetValue("Index", keyvalue);
            //    regstart.SetValue("VKX_XYStage", Application.StartupPath + "\\VKX_XYStage.exe");
            //}
            //catch (System.Exception)
            //{

            //}           
        }

        private void MouseHook_LeftUp(object sender, MouseEventArgs e)
        {
            if ((mouse_posx < this.Location.X || mouse_posx > (this.Location.X + 662) || e.Location.Y < this.Location.Y || e.Location.Y > (this.Location.Y + 410)) && status == 2)
            {
                stop_motor(5);
                SetStart = true;
                isDown = false;
            }
        }
        private void MouseHook_LeftDown(object sender, MouseEventArgs e)
        {           
            if ((mouse_posx < this.Location.X || mouse_posx > (this.Location.X + 662) || e.Location.Y < this.Location.Y || e.Location.Y > (this.Location.Y + 410)) && status == 2)
            {                   
                StartPoint.X = e.Location.X;
                StartPoint.Y = e.Location.Y;                   
                isDown = true;
            }           
        }

        #region Field
        int status = 0;
        
        uint velocity_x = 50000;
        //uint velocity_y = 50000;
        //uint velocity_z = 20000;

        int position_x;
        //int position_y, position_z;
        int mouse_posx, mouse_posy;
        
        //uint dwAxisStatus;

        float xdistance = 0;
        //float ydistance = 0;

        System.Net.IPAddress ipaddr_x = System.Net.IPAddress.Parse("192.168.0.5");
        //System.Net.IPAddress ipaddr_y = System.Net.IPAddress.Parse("192.168.0.3");
        //System.Net.IPAddress ipaddr_z = System.Net.IPAddress.Parse("192.168.0.4");

        MouseHelper mh = new MouseHelper();
        KeyHelper KH = new KeyHelper();
        Point StartPoint, FinishPoint;
        #endregion
        private void form_xystage_Load(object sender, EventArgs e)
        {
            //Process p = new Process();
            //p.StartInfo.FileName = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
            //p.Start();

            if (EziMOTIONPlusELib.FAS_ConnectTCP(ipaddr_x, 5) != true)
            {
                MessageBox.Show("Connect Fail, Axis X is not exist");
            }

            //if (EziMOTIONPlusELib.FAS_ConnectTCP(ipaddr_y, 3) != true)
            //{
            //    MessageBox.Show("Connect Fail, Axis Y is not exist");
            //}

            //if (EziMOTIONPlusELib.FAS_ConnectTCP(ipaddr_z, 4) != true)
            //{
            //    MessageBox.Show("Connect Fail, Axis Z is not exist");
            //}

            //int ntRn;
            //ntRn = EziMOTIONPlusELib.FAS_ServoEnable(4, 1);
            //if (ntRn != EziMOTIONPlusELib.FMM_OK)
            //{
            //    MessageBox.Show("Vui long kiem tra ket noi truc Z-1");
            //}

            //EziMOTIONPlusELib.FAS_SetParameter(4, 14, 20000);
            //EziMOTIONPlusELib.FAS_SetParameter(4, 15, 200);
            //EziMOTIONPlusELib.FAS_SetParameter(4, 17, 3);
            //EziMOTIONPlusELib.FAS_SetParameter(4, 18, 0);
            //EziMOTIONPlusELib.FAS_SetParameter(4, 19, 20000);

            timer_xy_stage.Enabled = true;           

            

            EziMOTIONPlusELib.FAS_SetParameter(5, 14, 50000);
            EziMOTIONPlusELib.FAS_SetParameter(5, 15, 500);
            EziMOTIONPlusELib.FAS_SetParameter(5, 17, 3);
            EziMOTIONPlusELib.FAS_SetParameter(5, 18, 0);
            EziMOTIONPlusELib.FAS_SetParameter(5, 19, -487865);

            //EziMOTIONPlusELib.FAS_SetParameter(3, 14, 50000);
            //EziMOTIONPlusELib.FAS_SetParameter(3, 15, 500);
            //EziMOTIONPlusELib.FAS_SetParameter(3, 17, 3);
            //EziMOTIONPlusELib.FAS_SetParameter(3, 18, 0);
            //EziMOTIONPlusELib.FAS_SetParameter(3, 19, -488850);

            txtBox_xdistance.Text = "0";
            //txtBox_ydistance.Text = "0";           

            mh.SetHook();
            mh.MouseMoveEvent += Mh_MouseMoveEvent;           
            this.TopMost = true;
        }
        bool SetStart = true;
       
        private void Mh_MouseMoveEvent(object sender, MouseEventArgs e)
        {           
            mouse_posx = e.Location.X;
            mouse_posy = e.Location.Y;
            if ((e.Location.X < this.Location.X || e.Location.X > (this.Location.X + 662) || e.Location.Y < this.Location.Y || e.Location.Y > (this.Location.Y + 410)) && status == 2 && isDown)
            {
                FinishPoint.X = e.Location.X;
                FinishPoint.Y = e.Location.Y;
                if (SetStart)
                {
                    if (FinishPoint.X < StartPoint.X)
                    {
                        run_motor(5, velocity_x, 1);
                        SetStart = false;
                    }
                    else
                    {
                        run_motor(5, velocity_x, 0);
                        SetStart = false;
                    }
                }               
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1) //Manual mode
            {
                status = 1;
                lbl_manu.BackColor = Color.NavajoWhite;
                lbl_motor.BackColor = Color.White;
                lbl_stiching.BackColor = Color.White;
                return true;
            }
            if(keyData == Keys.F2)//Motor mode
            {
                status = 2;
                lbl_motor.BackColor = Color.NavajoWhite;
                lbl_manu.BackColor = Color.White;
                lbl_stiching.BackColor = Color.White;
                return true;
            }
            if (keyData == Keys.F3) //Stiching
            {
                status = 3;
                lbl_stiching.BackColor = Color.NavajoWhite;
                lbl_motor.BackColor = Color.White;
                lbl_manu.BackColor = Color.White;
                return true;
            }           
            return base.ProcessCmdKey(ref msg, keyData);
        }       
        private void form_xystage_FormClosed(object sender, FormClosedEventArgs e)
        {
            EziMOTIONPlusELib.FAS_ServoEnable(5, 0);
            //EziMOTIONPlusELib.FAS_ServoEnable(3, 0);
            //EziMOTIONPlusELib.FAS_ServoEnable(4, 0);
           
            timer_xy_stage.Enabled = false;           
            mh.UnHook();
            MouseHook.RemoveHook();
        }
        private void timer_xy_stage_Tick(object sender, EventArgs e)
        {
            if (mouse_posx > this.Location.X && mouse_posx < (this.Location.X + 500))
            {
                if (mouse_posy > this.Location.Y && mouse_posy < (this.Location.Y + 335))
                {
                    this.Opacity = 1;
                }    
            }
            else
            {
                this.Opacity = 0.3;
            }

            if (status == 2)
            {
                int ntRn_2;
                //int ntRn_3;
                ntRn_2 = EziMOTIONPlusELib.FAS_ServoEnable(5, 1);
                if (ntRn_2 != EziMOTIONPlusELib.FMM_OK)
                {
                    string strMsg;
                    strMsg = "FAS_MoveVelocity() \nReturned: " + ntRn_2.ToString();
                    MessageBox.Show(strMsg, "Function Failed");
                }
                //ntRn_3 = EziMOTIONPlusELib.FAS_ServoEnable(3, 1);
                //if (ntRn_3 != EziMOTIONPlusELib.FMM_OK)
                //{
                //    string strMsg;
                //    strMsg = "FAS_MoveVelocity() \nReturned: " + ntRn_3.ToString();
                //    MessageBox.Show(strMsg, "Function Failed");
                //}
                gr_box_move.Enabled = true;
            }
            else if (status == 1)
            {
                int ntRn_2;
                //int ntRn_3;
                ntRn_2 = EziMOTIONPlusELib.FAS_ServoEnable(5, 0);
                if (ntRn_2 != EziMOTIONPlusELib.FMM_OK)
                {
                    string strMsg;
                    strMsg = "FAS_MoveVelocity() \nReturned: " + ntRn_2.ToString();
                    MessageBox.Show(strMsg, "Function Failed");
                }
                //ntRn_3 = EziMOTIONPlusELib.FAS_ServoEnable(3, 0);
                //if (ntRn_3 != EziMOTIONPlusELib.FMM_OK)
                //{
                //    string strMsg;
                //    strMsg = "FAS_MoveVelocity() \nReturned: " + ntRn_3.ToString();
                //    MessageBox.Show(strMsg, "Function Failed");
                //}
                gr_box_move.Enabled = false;
            }
            //int ntRn_12, ntRn_13, ntRn_14;
            int ntRn_12;
            ntRn_12 = EziMOTIONPlusELib.FAS_GetActualPos(2, ref position_x);
            //ntRn_13 = EziMOTIONPlusELib.FAS_GetActualPos(3, ref position_y);
            //ntRn_14 = EziMOTIONPlusELib.FAS_GetActualPos(4, ref position_z);

            //if (ntRn_12 != EziMOTIONPlusELib.FMM_OK || ntRn_13 != EziMOTIONPlusELib.FMM_OK || ntRn_14 != EziMOTIONPlusELib.FMM_OK)
            //{
            //    string strMsg;
            //    strMsg = "FAS_GetActPos() \nReturned: ";
            //    MessageBox.Show(strMsg, "Function Failed");
            //}
            txtBox_xaxis.Text = ((float)position_x / 5).ToString();
            //txtBox_yaxis.Text = ((float)position_y / 5).ToString();
            //txtBox_zaxis.Text = ((float)position_z / 5).ToString();

            //for (int i = 2; i <= 4; i++)
            //{
            //    int ntRn_stt;

            //    ntRn_stt = EziMOTIONPlusELib.FAS_GetAxisStatus(i, ref dwAxisStatus);
            //    if (ntRn_stt != EziMOTIONPlusELib.FMM_OK)
            //    {
            //        string strMsg;
            //        strMsg = "FAS_GetAxisStatus() \nReturned: " + ntRn_stt.ToString();
            //        MessageBox.Show(strMsg, "Function Failed");
            //        return;
            //    }
            //}

            //if ((dwAxisStatus & 0x00000001) != 0)
            //{
            //    MessageBox.Show("Hệ thống đang lỗi trục di chuyển" + dwAxisStatus.ToString());
            //}
        }
        private void run_motor(int i, uint v, int j)
        {
            int ntRn_1, ntRn_2;

            if (status == 2)
            {
                ntRn_1 = EziMOTIONPlusELib.FAS_ServoEnable(i, 1);
                if (ntRn_1 != EziMOTIONPlusELib.FMM_OK)
                {
                    string strMsg;
                    strMsg = "FAS_MoveVelocity() \nReturned: " + ntRn_1.ToString();
                    MessageBox.Show(strMsg, "Function Failed");
                }

                ntRn_2 = EziMOTIONPlusELib.FAS_MoveVelocity(i, v, j);
                if (ntRn_2 != EziMOTIONPlusELib.FMM_OK)
                {
                    string strMsg;
                    strMsg = "FAS_MoveVelocity() \nReturned: " + ntRn_2.ToString();
                    MessageBox.Show(strMsg, "Function Failed");
                }
            }
        }
        private void stop_motor(int i)
        {          
            int ntRn = EziMOTIONPlusELib.FAS_MoveStop(i); ;
            if (ntRn != EziMOTIONPlusELib.FMM_OK)
            {
                string strMsg;
                strMsg = "FAS_MoveStop() \nReturned: " + ntRn.ToString();
                MessageBox.Show(strMsg, "Function Failed");
            }
        }

        #region eventMouse
        private void btn_x_right_MouseUp(object sender, MouseEventArgs e)
        {
            stop_motor(5);
        }
        private void btn_x_left_MouseUp(object sender, MouseEventArgs e)
        {
            stop_motor(5);
        }
        private void btn_y_in_MouseUp(object sender, MouseEventArgs e)
        {
            //stop_motor(3);
        }
        private void btn_y_out_MouseUp(object sender, MouseEventArgs e)
        {
            //stop_motor(3);
        }
        private void btn_cross_up_right_MouseUp(object sender, MouseEventArgs e)
        {
            //stop_motor(2);
            //stop_motor(3);
        }
        private void btn_cross_up_left_MouseUp(object sender, MouseEventArgs e)
        {
            //stop_motor(2);
            //stop_motor(3);
        }
        private void btn_cross_down_right_MouseUp(object sender, MouseEventArgs e)
        {
            //stop_motor(2);
            //stop_motor(3);
        }
        private void btn_cross_down_left_MouseUp(object sender, MouseEventArgs e)
        {
            //stop_motor(2);
            //stop_motor(3);
        }
        private void btn_x_right_MouseDown(object sender, MouseEventArgs e)
        {
            run_motor(5, velocity_x, 1);
        }
        private void btn_x_left_MouseDown(object sender, MouseEventArgs e)
        {
            run_motor(5, velocity_x, 0);
        }
        #endregion

        #region YZ&auto
        private void btn_y_out_MouseDown(object sender, MouseEventArgs e)
        {
            //run_motor(3, velocity_y, 1);
        }
        private void btn_y_in_MouseDown(object sender, MouseEventArgs e)
        {
            //run_motor(3, velocity_y, 0);
        }
        private void btn_cross_up_right_MouseDown(object sender, MouseEventArgs e)
        {
            //run_motor(2, velocity_x, 1);
            //run_motor(3, velocity_y, 0);
        }
        private void btn_cross_down_right_MouseDown(object sender, MouseEventArgs e)
        {
            //run_motor(2, velocity_x, 1);
            //run_motor(3, velocity_y, 1);
        }
        private void btn_cross_up_left_MouseDown(object sender, MouseEventArgs e)
        {
            //run_motor(2, velocity_x, 0);
            //run_motor(3, velocity_y, 0);
        }
        private void btn_cross_down_left_MouseDown(object sender, MouseEventArgs e)
        {
            //run_motor(2, velocity_x, 0);
            //run_motor(3, velocity_y, 1);
        }
        private void btn_move_Zup_MouseDown(object sender, MouseEventArgs e)
        {
            //run_motor(4, velocity_z, 0);
        }
        private void btn_move_Zup_MouseUp(object sender, MouseEventArgs e)
        {
            //stop_motor(4);
        }
        private void btn_move_Zdown_MouseDown(object sender, MouseEventArgs e)
        {
            //run_motor(4, velocity_z, 1);
        }
        private void btn_move_Zdown_MouseUp(object sender, MouseEventArgs e)
        {
            //stop_motor(4);
        }
        private void btn_move_auto_MouseDown(object sender, MouseEventArgs e)
        {
            int total_checkbox = 0;

            //if (rdb_automatic.Checked == true)
            //{
            //    foreach (CheckBox c in gr_box_auto.Controls.OfType<CheckBox>())
            //    {
            //        if (c.Checked == true)
            //        {
            //            total_checkbox += 1;
            //        }
            //    }

            //    if (total_checkbox == 0)
            //    {
            //        MessageBox.Show("Bạn chưa chọn trục chuyển động");
            //    }
            //    else
            //    {
            //        if (checkBox_x.Checked == true)
            //        {
            //            if (numeric_pitch_x.Value == 0)
            //            {
            //                MessageBox.Show("Bạn cần chọn bước dịch chuyển cho trục X");
            //            }
            //            else
            //            {
            //                numeric_pitch_x.Enabled = false;
            //                checkBox_x.Enabled = false;

            //                int ntRn;

            //                ntRn = EziMOTIONPlusELib.FAS_MoveSingleAxisIncPos(5, (int)(numeric_pitch_x.Value * 5), velocity_x);
            //                if (ntRn != EziMOTIONPlusELib.FMM_OK)
            //                {
            //                    string strMsg;
            //                    strMsg = "FAS_MoveSingleAxisIncPos() \nReturned: ";
            //                    MessageBox.Show(strMsg, "Function Failed");
            //                }

            //                xdistance = xdistance + (float)numeric_pitch_x.Value;
            //                txtBox_xdistance.Text = xdistance.ToString();
            //            }
            //        }

                    //if (checkBox_y.Checked == true)
                    //{
                    //    if (numeric_pitch_y.Value == 0)
                    //    {
                    //        MessageBox.Show("Bạn cần chọn bước dịch chuyển cho trục Y");
                    //    }
                    //    else
                    //    {
                    //        numeric_pitch_y.Enabled = false;
                    //        checkBox_y.Enabled = false;

                    //        int ntRn;

                    //        ntRn = EziMOTIONPlusELib.FAS_MoveSingleAxisIncPos(3, (int)(numeric_pitch_y.Value * 5), velocity_y);
                    //        if (ntRn != EziMOTIONPlusELib.FMM_OK)
                    //        {
                    //            string strMsg;
                    //            strMsg = "FAS_MoveSingleAxisIncPos() \nReturned: ";
                    //            MessageBox.Show(strMsg, "Function Failed");
                    //        }

                    //        //ydistance = ydistance + (float)numeric_pitch_y.Value;
                    //        //txtBox_ydistance.Text = ydistance.ToString();
                    //    }
                    //}
            //    }
            //}
        }
        private void btn_move_auto_MouseUp(object sender, MouseEventArgs e)
        {
            checkBox_x.Enabled = true;
            checkBox_y.Enabled = true;

            numeric_pitch_x.Enabled = true;
            numeric_pitch_y.Enabled = true;
        }
        private void btn_0distance_Click(object sender, EventArgs e)
        {
            xdistance = 0;
            //ydistance = 0;

            txtBox_xdistance.Text = xdistance.ToString();
            //txtBox_ydistance.Text = ydistance.ToString();
        }
        private void btn_origin_Click(object sender, EventArgs e)
        {
            //int ntRn_2, ntRn_3, ntRn_4;

            //if (rdb_by_motor.Checked == true)
            //{
            //    ntRn_2 = EziMOTIONPlusELib.FAS_MoveOriginSingleAxis(2);
            //    ntRn_3 = EziMOTIONPlusELib.FAS_MoveOriginSingleAxis(3);
            //    ntRn_4 = EziMOTIONPlusELib.FAS_MoveOriginSingleAxis(4);

            //    if (ntRn_2 != EziMOTIONPlusELib.FMM_OK || ntRn_3 != EziMOTIONPlusELib.FMM_OK || ntRn_4 != EziMOTIONPlusELib.FMM_OK)
            //    {
            //        string strMsg;
            //        strMsg = "FAS_MoveOrigin() \nReturned: ";
            //        MessageBox.Show(strMsg, "Function Failed");
            //    }
            //}
            //else MessageBox.Show("Vui lòng lựa chọn đúng chế độ di chuyển");
        }
        #endregion

        bool start = true, isDown = false;
        private void Form_xystage_KeyDown(object sender, KeyEventArgs e)
        {           
            if (e.KeyCode == Keys.Right)
            {                
                if (start)
                {
                    run_motor(5, velocity_x, 1);
                    start = false;
                }               
            }
            if (e.KeyCode == Keys.Left)
            {               
                if (start)
                {
                    run_motor(5, velocity_x, 0);
                    start = false;
                }
            }
        }
        private void Form_xystage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {                
                start = true;
                stop_motor(5);               
            }
        }
        private void gr_box_option_Enter(object sender, EventArgs e)
        {

        }     
        private void btn_rst_alarm_Click(object sender, EventArgs e)
        {
            //if ((dwAxisStatus & 0x00000001) != 0)
            //{
            //    int nRtn = EziMOTIONPlusELib.FAS_ServoAlarmReset(0);
            //    if (nRtn != EziMOTIONPlusELib.FMM_OK)
            //    {
            //        string strMsg;
            //        strMsg = "FAS_ServoAlarmReset() \nReturned: " + nRtn.ToString();
            //        MessageBox.Show(strMsg, "Function Failed");
            //        return;
            //    }
            //}
        }

        //protected override bool ProcessKeyPreview(ref Message m)
        //{
        //    int msgVal = m.WParam.ToInt32();
        //    if (m.Msg == WM_KEYDOWN)
        //    {
        //        switch ((Keys)msgVal)
        //        {
        //            case Keys.Right:
        //                run_motor(5, velocity_x, 1);
        //                break;
        //            case Keys.Left:
        //                run_motor(5, velocity_x, 0);
        //                break;
        //        }
        //    }
        //    if (m.Msg == WM_KEYUP)
        //    {
        //        switch ((Keys)msgVal)
        //        {
        //            case Keys.Right:
        //                stop_motor(5);
        //                break;
        //            case Keys.Left:
        //                stop_motor(5);
        //                break;
        //        }
        //    }
        //    return base.ProcessKeyPreview(ref m);
        //}
        public bool PreFilterMessage(ref Message m)
        {
            if ((m.Msg == 0x100 || m.Msg == 0x101) && (((Keys)m.WParam.ToInt32() == Keys.Left) || ((Keys)m.WParam.ToInt32() == Keys.Right)))
            {               
                //only for this form
                Form form = null;
                var ctl = Control.FromHandle(m.HWnd);
                if (ctl != null) form = ctl.FindForm();
                if (form == this)
                {                    
                    return true;
                }
            }
            return false;
        }

        //private void Form_xystage_Deactivate(object sender, EventArgs e)
        //{
        //    var originOfCoordinates = new Point(750,430);
        //    var SecondPoint = Cursor.Position;
        //    if(SecondPoint.X < originOfCoordinates.X && SecondPoint.Y < originOfCoordinates.Y)
        //    {
        //        run_motor(5, velocity_x, 1);
        //    }
        //    else if (SecondPoint.X > originOfCoordinates.X && SecondPoint.Y < originOfCoordinates.Y)
        //    {
        //        run_motor(5, velocity_x, 0);
        //    }
        //    else if (SecondPoint.X < originOfCoordinates.X && SecondPoint.Y > originOfCoordinates.Y)
        //    {
        //        stop_motor(5);
        //    }
        //    else if (SecondPoint.X > originOfCoordinates.X && SecondPoint.Y > originOfCoordinates.Y)
        //    {
        //        stop_motor(5);
        //    }           
        //}

        //bool start;
              
    }
}
