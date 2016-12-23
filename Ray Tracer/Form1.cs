using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Ray_Tracer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class RayTracer : System.Windows.Forms.Form
	{
		/// <summary>
		// Graphics object
		private System.Drawing.Graphics memPage, page;
		private System.Drawing.Graphics indicator;
		private System.Windows.Forms.Panel Panel;
		private System.Windows.Forms.Panel Indicator;
		private Bitmap tmpBitMap = new Bitmap(400, 400,
			System.Drawing.Imaging.PixelFormat.Format24bppRgb);
		private System.Windows.Forms.Button btnDraw;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtLightX;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtLightY;
		private System.Windows.Forms.TextBox txtLightZ;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtSphere1X;
		private System.Windows.Forms.TextBox txtSphere1Y;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtSphere1Z;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtSphere1G;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtSphere1B;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtSphere1Rad;
		private System.Windows.Forms.TextBox txtSphere1R;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtSphere2X;
		private System.Windows.Forms.TextBox txtSphere2Y;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtSphere2Rad;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox txtSphere2B;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox txtSphere2G;
		private System.Windows.Forms.TextBox txtSphere2R;
		private System.Windows.Forms.TextBox txtSphere2Z;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox txtSphere3X;
		private System.Windows.Forms.TextBox txtSphere3Y;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox txtSphere3Z;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox txtSphere3Rad;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox txtSphere3B;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox txtSphere3G;
		private System.Windows.Forms.TextBox txtSphere3R;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem mnuFile;
		private System.Windows.Forms.MenuItem mnuFileSaveBitmap;
		private System.Windows.Forms.MenuItem mnuOptions;
		private System.Windows.Forms.MenuItem mnuOptionsWhileRendering;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.MenuItem mnuOptionsContextHelp;
		private System.Windows.Forms.TrackBar trackBar;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.MenuItem mnuHelp;
		private System.Windows.Forms.MenuItem mnuHelpAbout;
		private System.ComponentModel.IContainer components;

		public RayTracer()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Initialize context help
			String coordRange = " coord. Range -999 to 999";
			toolTip.SetToolTip(txtSphere1X, "X"+coordRange);
			toolTip.SetToolTip(txtSphere1Y, "Y"+coordRange);
			toolTip.SetToolTip(txtSphere1Z, "Z"+coordRange);
			toolTip.SetToolTip(txtSphere2X, "X"+coordRange);
			toolTip.SetToolTip(txtSphere2Y, "Y"+coordRange);
			toolTip.SetToolTip(txtSphere2Z, "Z"+coordRange);
			toolTip.SetToolTip(txtSphere3X, "X"+coordRange);
			toolTip.SetToolTip(txtSphere3Y, "Y"+coordRange);
			toolTip.SetToolTip(txtSphere3Z, "Z"+coordRange);
			toolTip.SetToolTip(txtLightX, "X"+coordRange);
			toolTip.SetToolTip(txtLightY, "Y"+coordRange);
			toolTip.SetToolTip(txtLightZ, "Z"+coordRange);

			String colorRange = ". Range 0 to 255";
			toolTip.SetToolTip(txtSphere1R, "Red"+colorRange);
			toolTip.SetToolTip(txtSphere1G, "Green"+colorRange);
			toolTip.SetToolTip(txtSphere1B, "Blue"+colorRange);
			toolTip.SetToolTip(txtSphere2R, "Red"+colorRange);
			toolTip.SetToolTip(txtSphere2G, "Green"+colorRange);
			toolTip.SetToolTip(txtSphere2B, "Blue"+colorRange);
			toolTip.SetToolTip(txtSphere3R, "Red"+colorRange);
			toolTip.SetToolTip(txtSphere3G, "Green"+colorRange);
			toolTip.SetToolTip(txtSphere3B, "Blue"+colorRange);

			String radiusRange = "Radius. Range 0 to 999";
			toolTip.SetToolTip(txtSphere1Rad, radiusRange);
			toolTip.SetToolTip(txtSphere2Rad, radiusRange);
			toolTip.SetToolTip(txtSphere3Rad, radiusRange);

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(RayTracer));
			this.Panel = new System.Windows.Forms.Panel();
			this.Indicator = new System.Windows.Forms.Panel();
			this.btnDraw = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtLightX = new System.Windows.Forms.TextBox();
			this.txtLightY = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtLightZ = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtSphere1X = new System.Windows.Forms.TextBox();
			this.txtSphere1Y = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtSphere1Z = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtSphere1Rad = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtSphere1B = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtSphere1G = new System.Windows.Forms.TextBox();
			this.txtSphere1R = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtSphere2X = new System.Windows.Forms.TextBox();
			this.txtSphere2Y = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtSphere2Z = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtSphere2Rad = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.txtSphere2B = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.txtSphere2G = new System.Windows.Forms.TextBox();
			this.txtSphere2R = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label18 = new System.Windows.Forms.Label();
			this.txtSphere3X = new System.Windows.Forms.TextBox();
			this.txtSphere3Y = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.txtSphere3Z = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.txtSphere3Rad = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.txtSphere3B = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.txtSphere3G = new System.Windows.Forms.TextBox();
			this.txtSphere3R = new System.Windows.Forms.TextBox();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuFileSaveBitmap = new System.Windows.Forms.MenuItem();
			this.mnuOptions = new System.Windows.Forms.MenuItem();
			this.mnuOptionsWhileRendering = new System.Windows.Forms.MenuItem();
			this.mnuOptionsContextHelp = new System.Windows.Forms.MenuItem();
			this.mnuHelp = new System.Windows.Forms.MenuItem();
			this.mnuHelpAbout = new System.Windows.Forms.MenuItem();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.trackBar = new System.Windows.Forms.TrackBar();
			this.label25 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// Panel
			// 
			this.Panel.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.Panel.Location = new System.Drawing.Point(25, 25);
			this.Panel.Name = "Panel";
			this.Panel.Size = new System.Drawing.Size(400, 400);
			this.Panel.TabIndex = 0;
			this.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);
			// 
			// Indicator
			// 
			this.Indicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Indicator.Location = new System.Drawing.Point(24, 432);
			this.Indicator.Name = "Indicator";
			this.Indicator.Size = new System.Drawing.Size(100, 10);
			this.Indicator.TabIndex = 1;
			this.Indicator.Visible = false;
			// 
			// btnDraw
			// 
			this.btnDraw.Location = new System.Drawing.Point(472, 392);
			this.btnDraw.Name = "btnDraw";
			this.btnDraw.Size = new System.Drawing.Size(176, 32);
			this.btnDraw.TabIndex = 2;
			this.btnDraw.Text = "Draw";
			this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtLightX);
			this.groupBox1.Controls.Add(this.txtLightY);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtLightZ);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(432, 240);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(80, 128);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Light Source";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(16, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "X";
			// 
			// txtLightX
			// 
			this.txtLightX.Location = new System.Drawing.Point(32, 32);
			this.txtLightX.MaxLength = 4;
			this.txtLightX.Name = "txtLightX";
			this.txtLightX.Size = new System.Drawing.Size(32, 20);
			this.txtLightX.TabIndex = 4;
			this.txtLightX.Text = "0";
			this.txtLightX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLightX_KeyPress);
			this.txtLightX.Leave += new System.EventHandler(this.txtLightX_Leave);
			// 
			// txtLightY
			// 
			this.txtLightY.Location = new System.Drawing.Point(32, 64);
			this.txtLightY.MaxLength = 4;
			this.txtLightY.Name = "txtLightY";
			this.txtLightY.Size = new System.Drawing.Size(32, 20);
			this.txtLightY.TabIndex = 6;
			this.txtLightY.Text = "0";
			this.txtLightY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLightY_KeyPress);
			this.txtLightY.Leave += new System.EventHandler(this.txtLightY_Leave);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "Y";
			// 
			// txtLightZ
			// 
			this.txtLightZ.Location = new System.Drawing.Point(32, 96);
			this.txtLightZ.MaxLength = 4;
			this.txtLightZ.Name = "txtLightZ";
			this.txtLightZ.Size = new System.Drawing.Size(32, 20);
			this.txtLightZ.TabIndex = 8;
			this.txtLightZ.Text = "400";
			this.txtLightZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLightZ_KeyPress);
			this.txtLightZ.Leave += new System.EventHandler(this.txtLightZ_Leave);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 100);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 16);
			this.label3.TabIndex = 9;
			this.label3.Text = "Z";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.txtSphere1X);
			this.groupBox2.Controls.Add(this.txtSphere1Y);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.txtSphere1Z);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.txtSphere1Rad);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.txtSphere1B);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.txtSphere1G);
			this.groupBox2.Controls.Add(this.txtSphere1R);
			this.groupBox2.Location = new System.Drawing.Point(432, 24);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(80, 208);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Sphere 1";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 28);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(16, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "X";
			// 
			// txtSphere1X
			// 
			this.txtSphere1X.Location = new System.Drawing.Point(32, 24);
			this.txtSphere1X.MaxLength = 4;
			this.txtSphere1X.Name = "txtSphere1X";
			this.txtSphere1X.Size = new System.Drawing.Size(32, 20);
			this.txtSphere1X.TabIndex = 4;
			this.txtSphere1X.Text = "0";
			this.txtSphere1X.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere1X_KeyPress);
			this.txtSphere1X.Leave += new System.EventHandler(this.txtSphere1X_Leave);
			// 
			// txtSphere1Y
			// 
			this.txtSphere1Y.Location = new System.Drawing.Point(32, 50);
			this.txtSphere1Y.MaxLength = 4;
			this.txtSphere1Y.Name = "txtSphere1Y";
			this.txtSphere1Y.Size = new System.Drawing.Size(32, 20);
			this.txtSphere1Y.TabIndex = 6;
			this.txtSphere1Y.Text = "0";
			this.txtSphere1Y.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere1Y_KeyPress);
			this.txtSphere1Y.Leave += new System.EventHandler(this.txtSphere1Y_Leave);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 54);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(16, 16);
			this.label5.TabIndex = 7;
			this.label5.Text = "Y";
			// 
			// txtSphere1Z
			// 
			this.txtSphere1Z.Location = new System.Drawing.Point(32, 76);
			this.txtSphere1Z.MaxLength = 4;
			this.txtSphere1Z.Name = "txtSphere1Z";
			this.txtSphere1Z.Size = new System.Drawing.Size(32, 20);
			this.txtSphere1Z.TabIndex = 8;
			this.txtSphere1Z.Text = "0";
			this.txtSphere1Z.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere1Z_KeyPress);
			this.txtSphere1Z.Leave += new System.EventHandler(this.txtSphere1Z_Leave);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 80);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(16, 16);
			this.label6.TabIndex = 9;
			this.label6.Text = "Z";
			// 
			// txtSphere1Rad
			// 
			this.txtSphere1Rad.Location = new System.Drawing.Point(32, 102);
			this.txtSphere1Rad.MaxLength = 3;
			this.txtSphere1Rad.Name = "txtSphere1Rad";
			this.txtSphere1Rad.Size = new System.Drawing.Size(32, 20);
			this.txtSphere1Rad.TabIndex = 10;
			this.txtSphere1Rad.Text = "100";
			this.txtSphere1Rad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere1Rad_KeyPress);
			this.txtSphere1Rad.Leave += new System.EventHandler(this.txtSphere1Rad_Leave);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 106);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(16, 16);
			this.label7.TabIndex = 11;
			this.label7.Text = "r";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 132);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(16, 16);
			this.label8.TabIndex = 11;
			this.label8.Text = "R";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(16, 184);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(16, 16);
			this.label10.TabIndex = 15;
			this.label10.Text = "B";
			// 
			// txtSphere1B
			// 
			this.txtSphere1B.Location = new System.Drawing.Point(32, 180);
			this.txtSphere1B.MaxLength = 3;
			this.txtSphere1B.Name = "txtSphere1B";
			this.txtSphere1B.Size = new System.Drawing.Size(32, 20);
			this.txtSphere1B.TabIndex = 14;
			this.txtSphere1B.Text = "0";
			this.txtSphere1B.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere1B_KeyPress);
			this.txtSphere1B.Leave += new System.EventHandler(this.txtSphere1B_Leave);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 158);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(16, 16);
			this.label9.TabIndex = 13;
			this.label9.Text = "G";
			// 
			// txtSphere1G
			// 
			this.txtSphere1G.Location = new System.Drawing.Point(32, 154);
			this.txtSphere1G.MaxLength = 3;
			this.txtSphere1G.Name = "txtSphere1G";
			this.txtSphere1G.Size = new System.Drawing.Size(32, 20);
			this.txtSphere1G.TabIndex = 12;
			this.txtSphere1G.Text = "0";
			this.txtSphere1G.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere1G_KeyPress);
			this.txtSphere1G.Leave += new System.EventHandler(this.txtSphere1G_Leave);
			// 
			// txtSphere1R
			// 
			this.txtSphere1R.Location = new System.Drawing.Point(32, 128);
			this.txtSphere1R.MaxLength = 3;
			this.txtSphere1R.Name = "txtSphere1R";
			this.txtSphere1R.Size = new System.Drawing.Size(32, 20);
			this.txtSphere1R.TabIndex = 11;
			this.txtSphere1R.Text = "200";
			this.txtSphere1R.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere1R_KeyPress);
			this.txtSphere1R.Leave += new System.EventHandler(this.txtSphere1R_Leave);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.txtSphere2X);
			this.groupBox3.Controls.Add(this.txtSphere2Y);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.txtSphere2Z);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.txtSphere2Rad);
			this.groupBox3.Controls.Add(this.label14);
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.txtSphere2B);
			this.groupBox3.Controls.Add(this.label17);
			this.groupBox3.Controls.Add(this.txtSphere2G);
			this.groupBox3.Controls.Add(this.txtSphere2R);
			this.groupBox3.Location = new System.Drawing.Point(520, 24);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(80, 208);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Sphere 2";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(16, 28);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(16, 16);
			this.label11.TabIndex = 5;
			this.label11.Text = "X";
			// 
			// txtSphere2X
			// 
			this.txtSphere2X.Location = new System.Drawing.Point(32, 24);
			this.txtSphere2X.MaxLength = 4;
			this.txtSphere2X.Name = "txtSphere2X";
			this.txtSphere2X.Size = new System.Drawing.Size(32, 20);
			this.txtSphere2X.TabIndex = 4;
			this.txtSphere2X.Text = "75";
			this.txtSphere2X.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere2X_KeyPress);
			this.txtSphere2X.Leave += new System.EventHandler(this.txtSphere2X_Leave);
			// 
			// txtSphere2Y
			// 
			this.txtSphere2Y.Location = new System.Drawing.Point(32, 50);
			this.txtSphere2Y.MaxLength = 4;
			this.txtSphere2Y.Name = "txtSphere2Y";
			this.txtSphere2Y.Size = new System.Drawing.Size(32, 20);
			this.txtSphere2Y.TabIndex = 6;
			this.txtSphere2Y.Text = "75";
			this.txtSphere2Y.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere2Y_KeyPress);
			this.txtSphere2Y.Leave += new System.EventHandler(this.txtSphere2Y_Leave);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(16, 54);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(16, 16);
			this.label12.TabIndex = 7;
			this.label12.Text = "Y";
			// 
			// txtSphere2Z
			// 
			this.txtSphere2Z.Location = new System.Drawing.Point(32, 76);
			this.txtSphere2Z.MaxLength = 4;
			this.txtSphere2Z.Name = "txtSphere2Z";
			this.txtSphere2Z.Size = new System.Drawing.Size(32, 20);
			this.txtSphere2Z.TabIndex = 8;
			this.txtSphere2Z.Text = "75";
			this.txtSphere2Z.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere2Z_KeyPress);
			this.txtSphere2Z.Leave += new System.EventHandler(this.txtSphere2Z_Leave);
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(16, 80);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(16, 16);
			this.label13.TabIndex = 9;
			this.label13.Text = "Z";
			// 
			// txtSphere2Rad
			// 
			this.txtSphere2Rad.Location = new System.Drawing.Point(32, 102);
			this.txtSphere2Rad.MaxLength = 3;
			this.txtSphere2Rad.Name = "txtSphere2Rad";
			this.txtSphere2Rad.Size = new System.Drawing.Size(32, 20);
			this.txtSphere2Rad.TabIndex = 10;
			this.txtSphere2Rad.Text = "50";
			this.txtSphere2Rad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere2Rad_KeyPress);
			this.txtSphere2Rad.Leave += new System.EventHandler(this.txtSphere2Rad_Leave);
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(16, 106);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(16, 16);
			this.label14.TabIndex = 11;
			this.label14.Text = "r";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(16, 132);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(16, 16);
			this.label15.TabIndex = 11;
			this.label15.Text = "R";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(16, 184);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(16, 16);
			this.label16.TabIndex = 15;
			this.label16.Text = "B";
			// 
			// txtSphere2B
			// 
			this.txtSphere2B.Location = new System.Drawing.Point(32, 180);
			this.txtSphere2B.MaxLength = 3;
			this.txtSphere2B.Name = "txtSphere2B";
			this.txtSphere2B.Size = new System.Drawing.Size(32, 20);
			this.txtSphere2B.TabIndex = 14;
			this.txtSphere2B.Text = "100";
			this.txtSphere2B.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere2B_KeyPress);
			this.txtSphere2B.Leave += new System.EventHandler(this.txtSphere2B_Leave);
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(16, 158);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(16, 16);
			this.label17.TabIndex = 13;
			this.label17.Text = "G";
			// 
			// txtSphere2G
			// 
			this.txtSphere2G.Location = new System.Drawing.Point(32, 154);
			this.txtSphere2G.MaxLength = 3;
			this.txtSphere2G.Name = "txtSphere2G";
			this.txtSphere2G.Size = new System.Drawing.Size(32, 20);
			this.txtSphere2G.TabIndex = 12;
			this.txtSphere2G.Text = "200";
			this.txtSphere2G.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere2G_KeyPress);
			this.txtSphere2G.Leave += new System.EventHandler(this.txtSphere2G_Leave);
			// 
			// txtSphere2R
			// 
			this.txtSphere2R.Location = new System.Drawing.Point(32, 128);
			this.txtSphere2R.MaxLength = 3;
			this.txtSphere2R.Name = "txtSphere2R";
			this.txtSphere2R.Size = new System.Drawing.Size(32, 20);
			this.txtSphere2R.TabIndex = 11;
			this.txtSphere2R.Text = "0";
			this.txtSphere2R.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere2R_KeyPress);
			this.txtSphere2R.Leave += new System.EventHandler(this.txtSphere2R_Leave);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label18);
			this.groupBox4.Controls.Add(this.txtSphere3X);
			this.groupBox4.Controls.Add(this.txtSphere3Y);
			this.groupBox4.Controls.Add(this.label19);
			this.groupBox4.Controls.Add(this.txtSphere3Z);
			this.groupBox4.Controls.Add(this.label20);
			this.groupBox4.Controls.Add(this.txtSphere3Rad);
			this.groupBox4.Controls.Add(this.label21);
			this.groupBox4.Controls.Add(this.label22);
			this.groupBox4.Controls.Add(this.label23);
			this.groupBox4.Controls.Add(this.txtSphere3B);
			this.groupBox4.Controls.Add(this.label24);
			this.groupBox4.Controls.Add(this.txtSphere3G);
			this.groupBox4.Controls.Add(this.txtSphere3R);
			this.groupBox4.Location = new System.Drawing.Point(608, 24);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(80, 208);
			this.groupBox4.TabIndex = 6;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Sphere 3";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(16, 28);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(16, 16);
			this.label18.TabIndex = 5;
			this.label18.Text = "X";
			// 
			// txtSphere3X
			// 
			this.txtSphere3X.Location = new System.Drawing.Point(32, 24);
			this.txtSphere3X.MaxLength = 4;
			this.txtSphere3X.Name = "txtSphere3X";
			this.txtSphere3X.Size = new System.Drawing.Size(32, 20);
			this.txtSphere3X.TabIndex = 4;
			this.txtSphere3X.Text = "-50";
			this.txtSphere3X.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere3X_KeyPress);
			this.txtSphere3X.Leave += new System.EventHandler(this.txtSphere3X_Leave);
			// 
			// txtSphere3Y
			// 
			this.txtSphere3Y.Location = new System.Drawing.Point(32, 50);
			this.txtSphere3Y.MaxLength = 4;
			this.txtSphere3Y.Name = "txtSphere3Y";
			this.txtSphere3Y.Size = new System.Drawing.Size(32, 20);
			this.txtSphere3Y.TabIndex = 6;
			this.txtSphere3Y.Text = "-80";
			this.txtSphere3Y.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere3Y_KeyPress);
			this.txtSphere3Y.Leave += new System.EventHandler(this.txtSphere3Y_Leave);
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(16, 54);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(16, 16);
			this.label19.TabIndex = 7;
			this.label19.Text = "Y";
			// 
			// txtSphere3Z
			// 
			this.txtSphere3Z.Location = new System.Drawing.Point(32, 76);
			this.txtSphere3Z.MaxLength = 4;
			this.txtSphere3Z.Name = "txtSphere3Z";
			this.txtSphere3Z.Size = new System.Drawing.Size(32, 20);
			this.txtSphere3Z.TabIndex = 8;
			this.txtSphere3Z.Text = "125";
			this.txtSphere3Z.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere3Z_KeyPress);
			this.txtSphere3Z.Leave += new System.EventHandler(this.txtSphere3Z_Leave);
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(16, 80);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(16, 16);
			this.label20.TabIndex = 9;
			this.label20.Text = "Z";
			// 
			// txtSphere3Rad
			// 
			this.txtSphere3Rad.Location = new System.Drawing.Point(32, 102);
			this.txtSphere3Rad.MaxLength = 3;
			this.txtSphere3Rad.Name = "txtSphere3Rad";
			this.txtSphere3Rad.Size = new System.Drawing.Size(32, 20);
			this.txtSphere3Rad.TabIndex = 10;
			this.txtSphere3Rad.Text = "25";
			this.txtSphere3Rad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere3Rad_KeyPress);
			this.txtSphere3Rad.Leave += new System.EventHandler(this.txtSphere3Rad_Leave);
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(16, 106);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(16, 16);
			this.label21.TabIndex = 11;
			this.label21.Text = "r";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(16, 132);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(16, 16);
			this.label22.TabIndex = 11;
			this.label22.Text = "R";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(16, 184);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(16, 16);
			this.label23.TabIndex = 15;
			this.label23.Text = "B";
			// 
			// txtSphere3B
			// 
			this.txtSphere3B.Location = new System.Drawing.Point(32, 180);
			this.txtSphere3B.MaxLength = 3;
			this.txtSphere3B.Name = "txtSphere3B";
			this.txtSphere3B.Size = new System.Drawing.Size(32, 20);
			this.txtSphere3B.TabIndex = 14;
			this.txtSphere3B.Text = "0";
			this.txtSphere3B.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere3B_KeyPress);
			this.txtSphere3B.Leave += new System.EventHandler(this.txtSphere3B_Leave);
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(16, 158);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(16, 16);
			this.label24.TabIndex = 13;
			this.label24.Text = "G";
			// 
			// txtSphere3G
			// 
			this.txtSphere3G.Location = new System.Drawing.Point(32, 154);
			this.txtSphere3G.MaxLength = 3;
			this.txtSphere3G.Name = "txtSphere3G";
			this.txtSphere3G.Size = new System.Drawing.Size(32, 20);
			this.txtSphere3G.TabIndex = 12;
			this.txtSphere3G.Text = "200";
			this.txtSphere3G.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere3G_KeyPress);
			this.txtSphere3G.Leave += new System.EventHandler(this.txtSphere3G_Leave);
			// 
			// txtSphere3R
			// 
			this.txtSphere3R.Location = new System.Drawing.Point(32, 128);
			this.txtSphere3R.MaxLength = 3;
			this.txtSphere3R.Name = "txtSphere3R";
			this.txtSphere3R.Size = new System.Drawing.Size(32, 20);
			this.txtSphere3R.TabIndex = 11;
			this.txtSphere3R.Text = "150";
			this.txtSphere3R.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSphere3R_KeyPress);
			this.txtSphere3R.Leave += new System.EventHandler(this.txtSphere3R_Leave);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuFile,
																					  this.mnuOptions,
																					  this.mnuHelp});
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuFileSaveBitmap});
			this.mnuFile.Text = "&File";
			// 
			// mnuFileSaveBitmap
			// 
			this.mnuFileSaveBitmap.Index = 0;
			this.mnuFileSaveBitmap.Text = "&Save Image...";
			this.mnuFileSaveBitmap.Click += new System.EventHandler(this.mnuFileSaveBitmap_Click);
			// 
			// mnuOptions
			// 
			this.mnuOptions.Index = 1;
			this.mnuOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mnuOptionsWhileRendering,
																					   this.mnuOptionsContextHelp});
			this.mnuOptions.Text = "&Options";
			// 
			// mnuOptionsWhileRendering
			// 
			this.mnuOptionsWhileRendering.Index = 0;
			this.mnuOptionsWhileRendering.Text = "Clear image while rendering";
			this.mnuOptionsWhileRendering.Click += new System.EventHandler(this.mnuOptionsWhileRendering_Click);
			// 
			// mnuOptionsContextHelp
			// 
			this.mnuOptionsContextHelp.Index = 1;
			this.mnuOptionsContextHelp.Text = "Disable tool tip";
			this.mnuOptionsContextHelp.Click += new System.EventHandler(this.mnuOptionsContextHelp_Click);
			// 
			// mnuHelp
			// 
			this.mnuHelp.Index = 2;
			this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuHelpAbout});
			this.mnuHelp.Text = "Help";
			// 
			// mnuHelpAbout
			// 
			this.mnuHelpAbout.Index = 0;
			this.mnuHelpAbout.Text = "About...";
			this.mnuHelpAbout.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// trackBar
			// 
			this.trackBar.Location = new System.Drawing.Point(40, 16);
			this.trackBar.Maximum = 1;
			this.trackBar.Name = "trackBar";
			this.trackBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.trackBar.Size = new System.Drawing.Size(40, 42);
			this.trackBar.TabIndex = 7;
			this.trackBar.Value = 1;
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(8, 24);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(24, 16);
			this.label25.TabIndex = 8;
			this.label25.Text = "dull";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(88, 24);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(32, 16);
			this.label26.TabIndex = 9;
			this.label26.Text = "shiny";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.label26);
			this.groupBox5.Controls.Add(this.trackBar);
			this.groupBox5.Controls.Add(this.label25);
			this.groupBox5.Location = new System.Drawing.Point(528, 240);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(128, 64);
			this.groupBox5.TabIndex = 10;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Specular Light";
			// 
			// RayTracer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(698, 463);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnDraw);
			this.Controls.Add(this.Indicator);
			this.Controls.Add(this.Panel);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox4);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "RayTracer";
			this.Text = "OKS\'s Ray Tracer";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
			this.groupBox5.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new RayTracer());
		}

		private void BeginRayTracing() 
		{
			memPage = Graphics.FromImage(tmpBitMap);

			Pen pen = new Pen(Color.Black, 1);
			pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

			Pen indicatorPen = new Pen(Color.Firebrick);

			indicator = this.Indicator.CreateGraphics();

			//points for the ray
			Point p1 = new Point(0, 0, 600, null);
			Point p2 = new Point(0, 0, 300, null);

			//light source, ray and array of spheres
			Light light = new Light(double.Parse(txtLightX.Text),
				double.Parse(txtLightY.Text),
				double.Parse(txtLightZ.Text),
				new RGB(255,255,255));
			Ray ray = new Ray(p1, p2);
			Sphere[] spheres = new Sphere[3];

			//create individual spheres
			spheres[0] =
				new Sphere(new Point(double.Parse(txtSphere1X.Text),
				double.Parse(txtSphere1Y.Text),
				double.Parse(txtSphere1Z.Text),
				new RGB(int.Parse(txtSphere1R.Text),
				int.Parse(txtSphere1G.Text),
				int.Parse(txtSphere1B.Text))),
				double.Parse(txtSphere1Rad.Text));
			spheres[1] =
				new Sphere(new Point(double.Parse(txtSphere2X.Text),
				double.Parse(txtSphere2Y.Text),
				double.Parse(txtSphere2Z.Text),
				new RGB(int.Parse(txtSphere2R.Text),
				int.Parse(txtSphere2G.Text),
				int.Parse(txtSphere2B.Text))),
				double.Parse(txtSphere2Rad.Text));
			spheres[2] =
				new Sphere(new Point(double.Parse(txtSphere3X.Text),
				double.Parse(txtSphere3Y.Text),
				double.Parse(txtSphere3Z.Text),
				new RGB(int.Parse(txtSphere3R.Text),
				int.Parse(txtSphere3G.Text),
				int.Parse(txtSphere3B.Text))),
				double.Parse(txtSphere3Rad.Text));

			//the RGB object
			RGB pixel;

			//clear previous image if the corresponding item
			//in the Options menu is checked
			if(mnuOptionsWhileRendering.Checked == true) 
			{
				page = this.Panel.CreateGraphics();
				page.Clear(Color.Black);
				page.Dispose();
			}


			//before rendering make indicator visible
			this.Indicator.Visible = true;

			//begin ray tracing starting from the top left corner
			//and going across
			for (int y=200; y >= -200; y--) 
			{
				ray.P2.Y = y;
				//update indicator every four rows
				if (y%4 == 0) 
				{
					indicator.DrawLine(indicatorPen, (200-y)/4,0,(200-y)/4,9);
				}

				for (int x=-200; x <= 200; x++)
				{
					ray.P2.X = x;

					//get the color of the current pixel
					pixel = PixelColor.getRGB(ray, spheres, light, trackBar.Value);

					//set the drawing color to this color
					pen.Color = Color.FromArgb(pixel.R, pixel.G, pixel.B);

					//draw
					memPage.DrawLine(pen, x+200, 200-y, x+200, 201-y);
				}
			}

			//force a call the paint event to show rendered image
			this.Panel.Invalidate();
		}

		//this method simply displays the memory bitmap onto the form's Panel
		private void Panel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			page = this.Panel.CreateGraphics();
			page.Clear(Color.Black);
			page.DrawImage(tmpBitMap, 0, 0);
			this.Indicator.Visible = false;

			page.Dispose();
		}

		private void btnDraw_Click(object sender, System.EventArgs e)
		{
			btnDraw.Enabled = false;
			BeginRayTracing();
			btnDraw.Enabled = true;
		}

		private void CheckCorrectPosition(System.Windows.Forms.KeyPressEventArgs e,
			System.Windows.Forms.TextBox txt)
		{
			//only numbers and '-' in the begining are allowed
			//range is -999 to 999
			if(!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b' || (e.KeyChar == '-' && txt.Text.Length == 0))
				|| (txt.Text.Length == 3 && !txt.Text.StartsWith("-") && e.KeyChar != '\b'))
			{
				e.Handled = true;
			}
		}

		private void CheckEmptyTxtBox(System.Windows.Forms.TextBox txt,
			String defaultVal)
		{
			if (txt.Text == "")
				txt.Text = defaultVal;
		}


		private void txtSphere1X_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPosition(e, txtSphere1X);
		}

		private void txtSphere1X_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere1X, "0");
		}

		private void txtSphere1Y_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPosition(e, txtSphere1Y);
		}

		private void txtSphere1Y_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere1Y, "0");
		}

		private void txtSphere1Z_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPosition(e, txtSphere1Z);
		}

		private void txtSphere1Z_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere1Z, "0");
		}

		private void txtSphere2X_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPosition(e, txtSphere2X);
		}

		private void txtSphere2X_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere2X, "0");
		}

		private void txtSphere2Y_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPosition(e, txtSphere2Y);
		}

		private void txtSphere2Y_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere2Y, "0");
		}

		private void txtSphere2Z_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPosition(e, txtSphere2Z);
		}

		private void txtSphere2Z_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere2Z, "0");
		}

		private void txtSphere3X_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPosition(e, txtSphere3X);
		}

		private void txtSphere3X_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere3X, "0");
		}

		private void txtSphere3Y_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPosition(e, txtSphere3Y);
		}

		private void txtSphere3Y_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere3Y, "0");
		}

		private void txtSphere3Z_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPosition(e, txtSphere3Z);
		}

		private void txtSphere3Z_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere3Z, "0");
		}

		private void CheckCorrectPositiveRange(System.Windows.Forms.KeyPressEventArgs e,
			System.Windows.Forms.TextBox txt,
			int max)
		{
			//only positive numbers are allowed
			//range is 0 to max
			if(!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b')
				|| (txt.Text != "" && e.KeyChar >= '0' && e.KeyChar <= '9' && int.Parse(txt.Text + e.KeyChar) > max))
			{
				e.Handled = true;
			}
		}

		private void txtSphere1Rad_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPositiveRange(e, txtSphere1Rad, 999);
		}

		private void txtSphere1Rad_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere1Rad, "10");
		}

		private void txtSphere2Rad_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPositiveRange(e, txtSphere2Rad, 999);
		}

		private void txtSphere2Rad_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere2Rad, "10");
		}

		private void txtSphere3Rad_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPositiveRange(e, txtSphere3Rad, 999);
		}

		private void txtSphere3Rad_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere3Rad, "10");
		}

		private void txtSphere1R_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPositiveRange(e, txtSphere1R, 255);
		}

		private void txtSphere1R_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere1R, "200");
		}

		private void txtSphere1G_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPositiveRange(e, txtSphere1G, 255);
		}

		private void txtSphere1G_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere1G, "0");
		}

		private void txtSphere1B_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPositiveRange(e, txtSphere1B, 255);
		}

		private void txtSphere1B_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere1B, "0");
		}

		private void txtSphere2R_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPositiveRange(e, txtSphere2R, 255);
		}

		private void txtSphere2R_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere2R, "0");
		}

		private void txtSphere2G_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPositiveRange(e, txtSphere2G, 255);
		}

		private void txtSphere2G_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere2G, "200");
		}

		private void txtSphere2B_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPositiveRange(e, txtSphere2B, 255);
		}

		private void txtSphere2B_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere2B, "100");
		}

		private void txtSphere3R_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPositiveRange(e, txtSphere3R, 255);
		}

		private void txtSphere3R_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere3R, "150");
		}

		private void txtSphere3G_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPositiveRange(e, txtSphere3G, 255);
		}

		private void txtSphere3G_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere3G, "200");
		}

		private void txtSphere3B_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPositiveRange(e, txtSphere3B, 255);
		}

		private void txtSphere3B_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtSphere3B, "0");
		}

		private void txtLightX_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPosition(e, txtLightX);
		}

		private void txtLightX_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtLightX, "0");
		}

		private void txtLightY_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPosition(e, txtLightY);
		}

		private void txtLightY_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtLightY, "0");
		}

		private void txtLightZ_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CheckCorrectPosition(e, txtLightZ);
		}

		private void txtLightZ_Leave(object sender, System.EventArgs e)
		{
			CheckEmptyTxtBox(txtLightZ, "400");
		}

		private void mnuFileSaveBitmap_Click(object sender, System.EventArgs e)
		{
			saveFileDialog.Title = "Specify Image file name";
			saveFileDialog.Filter = "JPEG|*.jpg|24bit Bitmap|*.bmp";
			if (saveFileDialog.ShowDialog() != DialogResult.Cancel) 
			{
				System.Drawing.Imaging.ImageFormat format = null;
				switch (saveFileDialog.FilterIndex) 
				{
					case 1:
						format = System.Drawing.Imaging.ImageFormat.Jpeg;
						break;
					case 2:
						format = System.Drawing.Imaging.ImageFormat.Bmp;
						break;
					default:
						//impossible to get here
						break;
				}
				tmpBitMap.Save(saveFileDialog.FileName, format);
			}
		}

		private void mnuOptionsWhileRendering_Click(object sender, System.EventArgs e)
		{
			mnuOptionsWhileRendering.Checked = !mnuOptionsWhileRendering.Checked;
		}

		private void mnuOptionsContextHelp_Click(object sender, System.EventArgs e)
		{
			if(mnuOptionsContextHelp.Text.StartsWith("D"))
			{
				mnuOptionsContextHelp.Text =
					mnuOptionsContextHelp.Text.Replace("Dis","En");
				toolTip.Active = false;
			}
			else 
			{
				mnuOptionsContextHelp.Text =
					mnuOptionsContextHelp.Text.Replace("En","Dis");
				toolTip.Active = true;
			}
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			About about = new About();
			if(about.ShowDialog() == DialogResult.OK)
				about.Close();
		}

	}
}
