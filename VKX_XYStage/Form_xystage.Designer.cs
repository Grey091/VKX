
namespace VKX_XYStage
{
    partial class Form_xystage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_xystage));
            this.btn_x_right = new System.Windows.Forms.Button();
            this.gr_box_move = new System.Windows.Forms.GroupBox();
            this.btn_Z = new System.Windows.Forms.Button();
            this.btn_move_Zdown = new System.Windows.Forms.Button();
            this.btn_move_Zup = new System.Windows.Forms.Button();
            this.btn_cross_down_right = new System.Windows.Forms.Button();
            this.btn_cross_up_left = new System.Windows.Forms.Button();
            this.btn_cross_up_right = new System.Windows.Forms.Button();
            this.btn_y_out = new System.Windows.Forms.Button();
            this.btn_origin = new System.Windows.Forms.Button();
            this.btn_y_in = new System.Windows.Forms.Button();
            this.btn_cross_down_left = new System.Windows.Forms.Button();
            this.btn_x_left = new System.Windows.Forms.Button();
            this.gr_box_option = new System.Windows.Forms.GroupBox();
            this.lbl_stiching = new System.Windows.Forms.Label();
            this.lbl_motor = new System.Windows.Forms.Label();
            this.lbl_manu = new System.Windows.Forms.Label();
            this.gr_box_coor = new System.Windows.Forms.GroupBox();
            this.txtBox_zaxis = new System.Windows.Forms.TextBox();
            this.label_z = new System.Windows.Forms.Label();
            this.txtBox_yaxis = new System.Windows.Forms.TextBox();
            this.txtBox_xaxis = new System.Windows.Forms.TextBox();
            this.label_y = new System.Windows.Forms.Label();
            this.label_x = new System.Windows.Forms.Label();
            this.gr_box_auto = new System.Windows.Forms.GroupBox();
            this.btn_0distance = new System.Windows.Forms.Button();
            this.txtBox_ydistance = new System.Windows.Forms.TextBox();
            this.label_ydistance = new System.Windows.Forms.Label();
            this.txtBox_xdistance = new System.Windows.Forms.TextBox();
            this.label_xdistance = new System.Windows.Forms.Label();
            this.checkBox_y = new System.Windows.Forms.CheckBox();
            this.checkBox_x = new System.Windows.Forms.CheckBox();
            this.btn_move_auto = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.numeric_pitch_y = new System.Windows.Forms.NumericUpDown();
            this.numeric_pitch_x = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_rst_alarm = new System.Windows.Forms.Button();
            this.timer_xy_stage = new System.Windows.Forms.Timer(this.components);
            this.gr_box_move.SuspendLayout();
            this.gr_box_option.SuspendLayout();
            this.gr_box_coor.SuspendLayout();
            this.gr_box_auto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_pitch_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_pitch_x)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_x_right
            // 
            this.btn_x_right.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.btn_x_right, "btn_x_right");
            this.btn_x_right.Name = "btn_x_right";
            this.btn_x_right.UseVisualStyleBackColor = false;
            this.btn_x_right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_x_right_MouseDown);
            this.btn_x_right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_x_right_MouseUp);
            // 
            // gr_box_move
            // 
            this.gr_box_move.Controls.Add(this.btn_Z);
            this.gr_box_move.Controls.Add(this.btn_move_Zdown);
            this.gr_box_move.Controls.Add(this.btn_move_Zup);
            this.gr_box_move.Controls.Add(this.btn_cross_down_right);
            this.gr_box_move.Controls.Add(this.btn_cross_up_left);
            this.gr_box_move.Controls.Add(this.btn_cross_up_right);
            this.gr_box_move.Controls.Add(this.btn_y_out);
            this.gr_box_move.Controls.Add(this.btn_origin);
            this.gr_box_move.Controls.Add(this.btn_y_in);
            this.gr_box_move.Controls.Add(this.btn_cross_down_left);
            this.gr_box_move.Controls.Add(this.btn_x_left);
            this.gr_box_move.Controls.Add(this.btn_x_right);
            resources.ApplyResources(this.gr_box_move, "gr_box_move");
            this.gr_box_move.Name = "gr_box_move";
            this.gr_box_move.TabStop = false;
            // 
            // btn_Z
            // 
            resources.ApplyResources(this.btn_Z, "btn_Z");
            this.btn_Z.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Z.Name = "btn_Z";
            this.btn_Z.UseVisualStyleBackColor = true;
            // 
            // btn_move_Zdown
            // 
            this.btn_move_Zdown.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.btn_move_Zdown, "btn_move_Zdown");
            this.btn_move_Zdown.Name = "btn_move_Zdown";
            this.btn_move_Zdown.UseVisualStyleBackColor = false;
            this.btn_move_Zdown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_move_Zdown_MouseDown);
            this.btn_move_Zdown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_move_Zdown_MouseUp);
            // 
            // btn_move_Zup
            // 
            this.btn_move_Zup.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.btn_move_Zup, "btn_move_Zup");
            this.btn_move_Zup.Name = "btn_move_Zup";
            this.btn_move_Zup.UseVisualStyleBackColor = false;
            this.btn_move_Zup.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_move_Zup_MouseDown);
            this.btn_move_Zup.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_move_Zup_MouseUp);
            // 
            // btn_cross_down_right
            // 
            this.btn_cross_down_right.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.btn_cross_down_right, "btn_cross_down_right");
            this.btn_cross_down_right.Name = "btn_cross_down_right";
            this.btn_cross_down_right.UseVisualStyleBackColor = false;
            this.btn_cross_down_right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_cross_down_right_MouseDown);
            this.btn_cross_down_right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_cross_down_right_MouseUp);
            // 
            // btn_cross_up_left
            // 
            this.btn_cross_up_left.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.btn_cross_up_left, "btn_cross_up_left");
            this.btn_cross_up_left.Name = "btn_cross_up_left";
            this.btn_cross_up_left.UseVisualStyleBackColor = false;
            this.btn_cross_up_left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_cross_up_left_MouseDown);
            this.btn_cross_up_left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_cross_up_left_MouseUp);
            // 
            // btn_cross_up_right
            // 
            this.btn_cross_up_right.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_cross_up_right.BackgroundImage = global::VKX_XYStage.Properties.Resources._5;
            resources.ApplyResources(this.btn_cross_up_right, "btn_cross_up_right");
            this.btn_cross_up_right.Name = "btn_cross_up_right";
            this.btn_cross_up_right.UseVisualStyleBackColor = false;
            this.btn_cross_up_right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_cross_up_right_MouseDown);
            this.btn_cross_up_right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_cross_up_right_MouseUp);
            // 
            // btn_y_out
            // 
            this.btn_y_out.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.btn_y_out, "btn_y_out");
            this.btn_y_out.Name = "btn_y_out";
            this.btn_y_out.UseVisualStyleBackColor = false;
            this.btn_y_out.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_y_out_MouseDown);
            this.btn_y_out.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_y_out_MouseUp);
            // 
            // btn_origin
            // 
            this.btn_origin.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.btn_origin, "btn_origin");
            this.btn_origin.Name = "btn_origin";
            this.btn_origin.UseVisualStyleBackColor = false;
            this.btn_origin.Click += new System.EventHandler(this.btn_origin_Click);
            // 
            // btn_y_in
            // 
            this.btn_y_in.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.btn_y_in, "btn_y_in");
            this.btn_y_in.Name = "btn_y_in";
            this.btn_y_in.UseVisualStyleBackColor = false;
            this.btn_y_in.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_y_in_MouseDown);
            this.btn_y_in.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_y_in_MouseUp);
            // 
            // btn_cross_down_left
            // 
            this.btn_cross_down_left.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.btn_cross_down_left, "btn_cross_down_left");
            this.btn_cross_down_left.Name = "btn_cross_down_left";
            this.btn_cross_down_left.UseVisualStyleBackColor = false;
            this.btn_cross_down_left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_cross_down_left_MouseDown);
            this.btn_cross_down_left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_cross_down_left_MouseUp);
            // 
            // btn_x_left
            // 
            this.btn_x_left.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.btn_x_left, "btn_x_left");
            this.btn_x_left.Name = "btn_x_left";
            this.btn_x_left.UseVisualStyleBackColor = false;
            this.btn_x_left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_x_left_MouseDown);
            this.btn_x_left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_x_left_MouseUp);
            // 
            // gr_box_option
            // 
            this.gr_box_option.Controls.Add(this.lbl_stiching);
            this.gr_box_option.Controls.Add(this.lbl_motor);
            this.gr_box_option.Controls.Add(this.lbl_manu);
            resources.ApplyResources(this.gr_box_option, "gr_box_option");
            this.gr_box_option.Name = "gr_box_option";
            this.gr_box_option.TabStop = false;
            this.gr_box_option.Enter += new System.EventHandler(this.gr_box_option_Enter);
            // 
            // lbl_stiching
            // 
            resources.ApplyResources(this.lbl_stiching, "lbl_stiching");
            this.lbl_stiching.Name = "lbl_stiching";
            // 
            // lbl_motor
            // 
            resources.ApplyResources(this.lbl_motor, "lbl_motor");
            this.lbl_motor.Name = "lbl_motor";
            // 
            // lbl_manu
            // 
            resources.ApplyResources(this.lbl_manu, "lbl_manu");
            this.lbl_manu.Name = "lbl_manu";
            // 
            // gr_box_coor
            // 
            this.gr_box_coor.Controls.Add(this.txtBox_zaxis);
            this.gr_box_coor.Controls.Add(this.label_z);
            this.gr_box_coor.Controls.Add(this.txtBox_yaxis);
            this.gr_box_coor.Controls.Add(this.txtBox_xaxis);
            this.gr_box_coor.Controls.Add(this.label_y);
            this.gr_box_coor.Controls.Add(this.label_x);
            resources.ApplyResources(this.gr_box_coor, "gr_box_coor");
            this.gr_box_coor.Name = "gr_box_coor";
            this.gr_box_coor.TabStop = false;
            // 
            // txtBox_zaxis
            // 
            resources.ApplyResources(this.txtBox_zaxis, "txtBox_zaxis");
            this.txtBox_zaxis.Name = "txtBox_zaxis";
            this.txtBox_zaxis.ReadOnly = true;
            // 
            // label_z
            // 
            resources.ApplyResources(this.label_z, "label_z");
            this.label_z.Name = "label_z";
            // 
            // txtBox_yaxis
            // 
            resources.ApplyResources(this.txtBox_yaxis, "txtBox_yaxis");
            this.txtBox_yaxis.Name = "txtBox_yaxis";
            this.txtBox_yaxis.ReadOnly = true;
            // 
            // txtBox_xaxis
            // 
            resources.ApplyResources(this.txtBox_xaxis, "txtBox_xaxis");
            this.txtBox_xaxis.Name = "txtBox_xaxis";
            this.txtBox_xaxis.ReadOnly = true;
            // 
            // label_y
            // 
            resources.ApplyResources(this.label_y, "label_y");
            this.label_y.Name = "label_y";
            // 
            // label_x
            // 
            resources.ApplyResources(this.label_x, "label_x");
            this.label_x.Name = "label_x";
            // 
            // gr_box_auto
            // 
            this.gr_box_auto.Controls.Add(this.btn_0distance);
            this.gr_box_auto.Controls.Add(this.txtBox_ydistance);
            this.gr_box_auto.Controls.Add(this.label_ydistance);
            this.gr_box_auto.Controls.Add(this.txtBox_xdistance);
            this.gr_box_auto.Controls.Add(this.label_xdistance);
            this.gr_box_auto.Controls.Add(this.checkBox_y);
            this.gr_box_auto.Controls.Add(this.checkBox_x);
            this.gr_box_auto.Controls.Add(this.btn_move_auto);
            this.gr_box_auto.Controls.Add(this.label4);
            this.gr_box_auto.Controls.Add(this.numeric_pitch_y);
            this.gr_box_auto.Controls.Add(this.numeric_pitch_x);
            this.gr_box_auto.Controls.Add(this.label1);
            resources.ApplyResources(this.gr_box_auto, "gr_box_auto");
            this.gr_box_auto.Name = "gr_box_auto";
            this.gr_box_auto.TabStop = false;
            // 
            // btn_0distance
            // 
            resources.ApplyResources(this.btn_0distance, "btn_0distance");
            this.btn_0distance.Name = "btn_0distance";
            this.btn_0distance.UseVisualStyleBackColor = true;
            this.btn_0distance.Click += new System.EventHandler(this.btn_0distance_Click);
            // 
            // txtBox_ydistance
            // 
            resources.ApplyResources(this.txtBox_ydistance, "txtBox_ydistance");
            this.txtBox_ydistance.Name = "txtBox_ydistance";
            this.txtBox_ydistance.ReadOnly = true;
            // 
            // label_ydistance
            // 
            resources.ApplyResources(this.label_ydistance, "label_ydistance");
            this.label_ydistance.Name = "label_ydistance";
            // 
            // txtBox_xdistance
            // 
            resources.ApplyResources(this.txtBox_xdistance, "txtBox_xdistance");
            this.txtBox_xdistance.Name = "txtBox_xdistance";
            this.txtBox_xdistance.ReadOnly = true;
            // 
            // label_xdistance
            // 
            resources.ApplyResources(this.label_xdistance, "label_xdistance");
            this.label_xdistance.Name = "label_xdistance";
            // 
            // checkBox_y
            // 
            resources.ApplyResources(this.checkBox_y, "checkBox_y");
            this.checkBox_y.Name = "checkBox_y";
            this.checkBox_y.UseVisualStyleBackColor = true;
            // 
            // checkBox_x
            // 
            resources.ApplyResources(this.checkBox_x, "checkBox_x");
            this.checkBox_x.Name = "checkBox_x";
            this.checkBox_x.UseVisualStyleBackColor = true;
            // 
            // btn_move_auto
            // 
            resources.ApplyResources(this.btn_move_auto, "btn_move_auto");
            this.btn_move_auto.Name = "btn_move_auto";
            this.btn_move_auto.UseVisualStyleBackColor = true;
            this.btn_move_auto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_move_auto_MouseDown);
            this.btn_move_auto.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_move_auto_MouseUp);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // numeric_pitch_y
            // 
            this.numeric_pitch_y.DecimalPlaces = 1;
            this.numeric_pitch_y.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            resources.ApplyResources(this.numeric_pitch_y, "numeric_pitch_y");
            this.numeric_pitch_y.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numeric_pitch_y.Name = "numeric_pitch_y";
            // 
            // numeric_pitch_x
            // 
            this.numeric_pitch_x.DecimalPlaces = 1;
            this.numeric_pitch_x.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            resources.ApplyResources(this.numeric_pitch_x, "numeric_pitch_x");
            this.numeric_pitch_x.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numeric_pitch_x.Name = "numeric_pitch_x";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btn_rst_alarm
            // 
            resources.ApplyResources(this.btn_rst_alarm, "btn_rst_alarm");
            this.btn_rst_alarm.Name = "btn_rst_alarm";
            this.btn_rst_alarm.UseVisualStyleBackColor = true;
            this.btn_rst_alarm.Click += new System.EventHandler(this.btn_rst_alarm_Click);
            // 
            // timer_xy_stage
            // 
            this.timer_xy_stage.Interval = 10;
            this.timer_xy_stage.Tick += new System.EventHandler(this.timer_xy_stage_Tick);
            // 
            // Form_xystage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ControlBox = false;
            this.Controls.Add(this.btn_rst_alarm);
            this.Controls.Add(this.gr_box_auto);
            this.Controls.Add(this.gr_box_coor);
            this.Controls.Add(this.gr_box_option);
            this.Controls.Add(this.gr_box_move);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_xystage";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_xystage_FormClosed);
            this.Load += new System.EventHandler(this.form_xystage_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_xystage_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_xystage_KeyUp);
            this.gr_box_move.ResumeLayout(false);
            this.gr_box_option.ResumeLayout(false);
            this.gr_box_coor.ResumeLayout(false);
            this.gr_box_coor.PerformLayout();
            this.gr_box_auto.ResumeLayout(false);
            this.gr_box_auto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_pitch_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_pitch_x)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_x_right;
        private System.Windows.Forms.GroupBox gr_box_move;
        private System.Windows.Forms.Button btn_cross_down_right;
        private System.Windows.Forms.Button btn_cross_up_left;
        private System.Windows.Forms.Button btn_cross_up_right;
        private System.Windows.Forms.Button btn_y_out;
        private System.Windows.Forms.Button btn_origin;
        private System.Windows.Forms.Button btn_y_in;
        private System.Windows.Forms.Button btn_cross_down_left;
        private System.Windows.Forms.Button btn_x_left;
        private System.Windows.Forms.GroupBox gr_box_option;
        private System.Windows.Forms.GroupBox gr_box_coor;
        private System.Windows.Forms.TextBox txtBox_yaxis;
        private System.Windows.Forms.TextBox txtBox_xaxis;
        private System.Windows.Forms.Label label_y;
        private System.Windows.Forms.Label label_x;
        private System.Windows.Forms.GroupBox gr_box_auto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numeric_pitch_y;
        private System.Windows.Forms.NumericUpDown numeric_pitch_x;
        private System.Windows.Forms.Button btn_move_Zdown;
        private System.Windows.Forms.Button btn_move_Zup;
        private System.Windows.Forms.Button btn_Z;
        private System.Windows.Forms.Button btn_rst_alarm;
        private System.Windows.Forms.Button btn_move_auto;
        private System.Windows.Forms.Timer timer_xy_stage;
        private System.Windows.Forms.TextBox txtBox_zaxis;
        private System.Windows.Forms.Label label_z;
        private System.Windows.Forms.CheckBox checkBox_y;
        private System.Windows.Forms.CheckBox checkBox_x;
        private System.Windows.Forms.TextBox txtBox_ydistance;
        private System.Windows.Forms.Label label_ydistance;
        private System.Windows.Forms.TextBox txtBox_xdistance;
        private System.Windows.Forms.Label label_xdistance;
        private System.Windows.Forms.Button btn_0distance;
        private System.Windows.Forms.Label lbl_stiching;
        private System.Windows.Forms.Label lbl_motor;
        private System.Windows.Forms.Label lbl_manu;
    }
}

