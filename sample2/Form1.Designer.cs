namespace sample2
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_Test = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.線ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_stage_up = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.laser_henni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.SamplingNum = new System.Windows.Forms.TextBox();
            this.button_stage_reset = new System.Windows.Forms.Button();
            this.ZERO = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.laser_henni2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.sokutei_tab = new System.Windows.Forms.TabControl();
            this.zero2 = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tankyori = new System.Windows.Forms.RadioButton();
            this.standard = new System.Windows.Forms.RadioButton();
            this.dig_out = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dig_out2 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.DispRange_Combo = new System.Windows.Forms.ComboBox();
            this.offset2 = new System.Windows.Forms.TextBox();
            this.offset = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_stage_stop = new System.Windows.Forms.Button();
            this.button_stage_down = new System.Windows.Forms.Button();
            this.button_laser = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button_laser_stop = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.sokutei_tab.SuspendLayout();
            this.zero2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Test
            // 
            this.button_Test.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_Test.Location = new System.Drawing.Point(1250, 572);
            this.button_Test.Name = "button_Test";
            this.button_Test.Size = new System.Drawing.Size(98, 48);
            this.button_Test.TabIndex = 0;
            this.button_Test.Text = "測定開始";
            this.button_Test.UseVisualStyleBackColor = true;
            this.button_Test.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(207, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1025, 226);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設定ToolStripMenuItem,
            this.ファイルToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1374, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 設定ToolStripMenuItem
            // 
            this.設定ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.線ToolStripMenuItem});
            this.設定ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("設定ToolStripMenuItem.Image")));
            this.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            this.設定ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.設定ToolStripMenuItem.Text = "設定";
            // 
            // 線ToolStripMenuItem
            // 
            this.線ToolStripMenuItem.Name = "線ToolStripMenuItem";
            this.線ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.線ToolStripMenuItem.Text = "線";
            this.線ToolStripMenuItem.Click += new System.EventHandler(this.線ToolStripMenuItem_Click);
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem,
            this.開くToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 開くToolStripMenuItem
            // 
            this.開くToolStripMenuItem.Name = "開くToolStripMenuItem";
            this.開くToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.開くToolStripMenuItem.Text = "開く";
            this.開くToolStripMenuItem.Click += new System.EventHandler(this.開くToolStripMenuItem_Click);
            // 
            // button_stage_up
            // 
            this.button_stage_up.Location = new System.Drawing.Point(15, 41);
            this.button_stage_up.Name = "button_stage_up";
            this.button_stage_up.Size = new System.Drawing.Size(63, 24);
            this.button_stage_up.TabIndex = 4;
            this.button_stage_up.Text = "UP";
            this.button_stage_up.UseVisualStyleBackColor = true;
            this.button_stage_up.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(658, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "干渉縞強度";
            // 
            // laser_henni
            // 
            this.laser_henni.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.laser_henni.Location = new System.Drawing.Point(24, 61);
            this.laser_henni.Name = "laser_henni";
            this.laser_henni.Size = new System.Drawing.Size(131, 34);
            this.laser_henni.TabIndex = 7;
            this.laser_henni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(161, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "[nm]";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(3, 272);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1252, 697);
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // SamplingNum
            // 
            this.SamplingNum.Location = new System.Drawing.Point(1182, 913);
            this.SamplingNum.Name = "SamplingNum";
            this.SamplingNum.Size = new System.Drawing.Size(25, 19);
            this.SamplingNum.TabIndex = 25;
            // 
            // button_stage_reset
            // 
            this.button_stage_reset.Location = new System.Drawing.Point(15, 165);
            this.button_stage_reset.Name = "button_stage_reset";
            this.button_stage_reset.Size = new System.Drawing.Size(63, 23);
            this.button_stage_reset.TabIndex = 20;
            this.button_stage_reset.Text = "リセット";
            this.button_stage_reset.UseVisualStyleBackColor = true;
            this.button_stage_reset.Click += new System.EventHandler(this.button3_Click);
            // 
            // ZERO
            // 
            this.ZERO.ForeColor = System.Drawing.Color.Black;
            this.ZERO.Location = new System.Drawing.Point(1278, 947);
            this.ZERO.Name = "ZERO";
            this.ZERO.Size = new System.Drawing.Size(53, 23);
            this.ZERO.TabIndex = 21;
            this.ZERO.Text = "高速";
            this.ZERO.UseVisualStyleBackColor = true;
            this.ZERO.Click += new System.EventHandler(this.ZERO_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(217, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1025, 226);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // laser_henni2
            // 
            this.laser_henni2.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.laser_henni2.Location = new System.Drawing.Point(512, 934);
            this.laser_henni2.Name = "laser_henni2";
            this.laser_henni2.Size = new System.Drawing.Size(121, 20);
            this.laser_henni2.TabIndex = 27;
            this.laser_henni2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(21, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "変位：";
            // 
            // sokutei_tab
            // 
            this.sokutei_tab.Controls.Add(this.zero2);
            this.sokutei_tab.Controls.Add(this.tabPage2);
            this.sokutei_tab.Location = new System.Drawing.Point(956, 1081);
            this.sokutei_tab.Name = "sokutei_tab";
            this.sokutei_tab.SelectedIndex = 0;
            this.sokutei_tab.Size = new System.Drawing.Size(143, 39);
            this.sokutei_tab.TabIndex = 1;
            this.sokutei_tab.SelectedIndexChanged += new System.EventHandler(this.sokutei_tab_SelectedIndexChanged);
            // 
            // zero2
            // 
            this.zero2.BackColor = System.Drawing.SystemColors.Control;
            this.zero2.Controls.Add(this.button6);
            this.zero2.Controls.Add(this.ZERO);
            this.zero2.Controls.Add(this.button5);
            this.zero2.Controls.Add(this.tankyori);
            this.zero2.Controls.Add(this.standard);
            this.zero2.Controls.Add(this.dig_out);
            this.zero2.Controls.Add(this.SamplingNum);
            this.zero2.Controls.Add(this.textBox2);
            this.zero2.Controls.Add(this.tabControl1);
            this.zero2.Controls.Add(this.DispRange_Combo);
            this.zero2.Controls.Add(this.laser_henni2);
            this.zero2.Controls.Add(this.offset2);
            this.zero2.Controls.Add(this.offset);
            this.zero2.Location = new System.Drawing.Point(4, 22);
            this.zero2.Margin = new System.Windows.Forms.Padding(0);
            this.zero2.Name = "zero2";
            this.zero2.Padding = new System.Windows.Forms.Padding(3);
            this.zero2.Size = new System.Drawing.Size(135, 13);
            this.zero2.TabIndex = 0;
            this.zero2.Text = "測定";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1213, 886);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 54;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1276, 925);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(53, 23);
            this.button5.TabIndex = 47;
            this.button5.Text = "低速";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tankyori
            // 
            this.tankyori.AutoSize = true;
            this.tankyori.Location = new System.Drawing.Point(1213, 954);
            this.tankyori.Name = "tankyori";
            this.tankyori.Size = new System.Drawing.Size(59, 16);
            this.tankyori.TabIndex = 51;
            this.tankyori.Text = "短距離";
            this.tankyori.UseVisualStyleBackColor = true;
            // 
            // standard
            // 
            this.standard.AutoSize = true;
            this.standard.Checked = true;
            this.standard.Location = new System.Drawing.Point(1213, 932);
            this.standard.Name = "standard";
            this.standard.Size = new System.Drawing.Size(47, 16);
            this.standard.TabIndex = 50;
            this.standard.TabStop = true;
            this.standard.Text = "通常";
            this.standard.UseVisualStyleBackColor = true;
            // 
            // dig_out
            // 
            this.dig_out.Location = new System.Drawing.Point(639, 932);
            this.dig_out.Name = "dig_out";
            this.dig_out.Size = new System.Drawing.Size(122, 25);
            this.dig_out.TabIndex = 42;
            this.dig_out.Text = "レーザーOFF(0x01)";
            this.dig_out.UseVisualStyleBackColor = true;
            this.dig_out.Click += new System.EventHandler(this.dig_out_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1182, 938);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(25, 19);
            this.textBox2.TabIndex = 44;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(798, 890);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(367, 67);
            this.tabControl1.TabIndex = 43;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dig_out2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(359, 41);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dig_out2
            // 
            this.dig_out2.Location = new System.Drawing.Point(203, 22);
            this.dig_out2.Name = "dig_out2";
            this.dig_out2.Size = new System.Drawing.Size(98, 36);
            this.dig_out2.TabIndex = 44;
            this.dig_out2.Text = "レーザーON(0x02)";
            this.dig_out2.UseVisualStyleBackColor = true;
            this.dig_out2.Click += new System.EventHandler(this.dig_out2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chart2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(359, 41);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.chart2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart2.Legends.Add(legend1);
            this.chart2.Location = new System.Drawing.Point(109, 74);
            this.chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(990, 457);
            this.chart2.TabIndex = 0;
            this.chart2.Text = "chart2";
            // 
            // DispRange_Combo
            // 
            this.DispRange_Combo.FormattingEnabled = true;
            this.DispRange_Combo.Location = new System.Drawing.Point(385, 934);
            this.DispRange_Combo.Name = "DispRange_Combo";
            this.DispRange_Combo.Size = new System.Drawing.Size(121, 20);
            this.DispRange_Combo.TabIndex = 28;
            this.DispRange_Combo.SelectedIndexChanged += new System.EventHandler(this.DispRange_Combo_SelectedIndexChanged);
            // 
            // offset2
            // 
            this.offset2.Location = new System.Drawing.Point(1182, 888);
            this.offset2.Name = "offset2";
            this.offset2.Size = new System.Drawing.Size(25, 19);
            this.offset2.TabIndex = 37;
            // 
            // offset
            // 
            this.offset.Location = new System.Drawing.Point(1182, 863);
            this.offset.Name = "offset";
            this.offset.Size = new System.Drawing.Size(25, 19);
            this.offset.TabIndex = 37;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.OK);
            this.tabPage2.Controls.Add(this.numericUpDown1);
            this.tabPage2.Controls.Add(this.pictureBox6);
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.pictureBox4);
            this.tabPage2.Controls.Add(this.pictureBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(135, 13);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "解析";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(658, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 30;
            this.label9.Text = "干渉縞強度";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(87, 809);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(100, 33);
            this.OK.TabIndex = 27;
            this.OK.Text = "終了";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numericUpDown1.Location = new System.Drawing.Point(111, 301);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(76, 31);
            this.numericUpDown1.TabIndex = 26;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.numericUpDown1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown1_KeyDown);
            this.numericUpDown1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDown1_KeyUp);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.White;
            this.pictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox6.Location = new System.Drawing.Point(217, 634);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(1001, 291);
            this.pictureBox6.TabIndex = 25;
            this.pictureBox6.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(1286, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(184, 895);
            this.listView1.TabIndex = 24;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(217, 301);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(1001, 301);
            this.pictureBox4.TabIndex = 23;
            this.pictureBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(287, 941);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 55;
            this.label4.Text = "経過時間";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox5.Location = new System.Drawing.Point(261, 329);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(955, 500);
            this.pictureBox5.TabIndex = 42;
            this.pictureBox5.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_stage_up);
            this.groupBox1.Controls.Add(this.button_stage_stop);
            this.groupBox1.Controls.Add(this.button_stage_down);
            this.groupBox1.Controls.Add(this.button_stage_reset);
            this.groupBox1.Location = new System.Drawing.Point(1250, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(98, 223);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "移動鏡 Z動";
            // 
            // button_stage_stop
            // 
            this.button_stage_stop.Location = new System.Drawing.Point(15, 123);
            this.button_stage_stop.Name = "button_stage_stop";
            this.button_stage_stop.Size = new System.Drawing.Size(63, 25);
            this.button_stage_stop.TabIndex = 46;
            this.button_stage_stop.Text = "STOP";
            this.button_stage_stop.UseVisualStyleBackColor = true;
            this.button_stage_stop.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button_stage_down
            // 
            this.button_stage_down.Location = new System.Drawing.Point(15, 84);
            this.button_stage_down.Name = "button_stage_down";
            this.button_stage_down.Size = new System.Drawing.Size(63, 23);
            this.button_stage_down.TabIndex = 46;
            this.button_stage_down.Text = "DOWN";
            this.button_stage_down.UseVisualStyleBackColor = true;
            this.button_stage_down.Click += new System.EventHandler(this.button4_Click);
            // 
            // button_laser
            // 
            this.button_laser.Location = new System.Drawing.Point(1250, 61);
            this.button_laser.Name = "button_laser";
            this.button_laser.Size = new System.Drawing.Size(98, 44);
            this.button_laser.TabIndex = 31;
            this.button_laser.Text = "レーザー読取 ";
            this.button_laser.UseVisualStyleBackColor = true;
            this.button_laser.Click += new System.EventHandler(this.Async_laser_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(424, 941);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "[分]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1546, 446);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 12);
            this.label5.TabIndex = 49;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(346, 934);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(63, 19);
            this.textBox3.TabIndex = 45;
            // 
            // button_laser_stop
            // 
            this.button_laser_stop.Location = new System.Drawing.Point(1250, 122);
            this.button_laser_stop.Name = "button_laser_stop";
            this.button_laser_stop.Size = new System.Drawing.Size(98, 41);
            this.button_laser_stop.TabIndex = 39;
            this.button_laser_stop.Text = "レーザーSTOP";
            this.button_laser_stop.UseVisualStyleBackColor = true;
            this.button_laser_stop.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.White;
            this.pictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox7.Location = new System.Drawing.Point(207, 319);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(1025, 528);
            this.pictureBox7.TabIndex = 56;
            this.pictureBox7.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(55, 144);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 19);
            this.textBox1.TabIndex = 57;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 859);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sokutei_tab);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.laser_henni);
            this.Controls.Add(this.button_Test);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_laser);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_laser_stop);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.sokutei_tab.ResumeLayout(false);
            this.zero2.ResumeLayout(false);
            this.zero2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Test;
		private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 線ToolStripMenuItem;
        private System.Windows.Forms.Button button_stage_up;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox laser_henni;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox SamplingNum;
        private System.Windows.Forms.Button button_stage_reset;
        private System.Windows.Forms.Button ZERO;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox laser_henni2;
        private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TabControl sokutei_tab;
		private System.Windows.Forms.TabPage zero2;
		private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox offset;
        private System.Windows.Forms.TextBox offset2;
        private System.Windows.Forms.Button button_laser_stop;
        private System.Windows.Forms.Button button_laser;
        private System.Windows.Forms.ComboBox DispRange_Combo;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.Button dig_out;
        private System.Windows.Forms.Button dig_out2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button_stage_down;
        private System.Windows.Forms.Button button_stage_stop;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem 開くToolStripMenuItem;
        private System.Windows.Forms.RadioButton tankyori;
        private System.Windows.Forms.RadioButton standard;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.TextBox textBox1;
    }
}

