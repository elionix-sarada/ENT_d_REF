using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterfaceCorpDllWrap;
using System.Threading;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;


namespace sample2
{
    public partial class Form1 : Form
    {

		private AnalogCon.AD_DA ana;

		private ColumnHeader column_No;
		private ColumnHeader column_FILENAME;

        public int lines;
        public int vertex;
        public int wait_time;
		public int ioffset,ioffset2,iSamplingNum;
        public uint disp_range;
     

		public int Count;
		decimal pre_NUMERIC;
		SaveFileDialog sfd;
		string[] file_name;

		private ImagingSolution.Drawing.DoubleBuffer db1, db2, db3, db4,db5,db6;
        //public int Width;

		public Object pAd, pAd2;			// Area to store sampled data

		double start_raser,start_raser2;
		double pre_raser,pre_raser2;
		double f_max,f_max2;
		int fg,fg2;
		public string f_current;

        double[] xn = null;
        double[] wn = null;
        double[] ynr = null;
        double[] ynw = null;
        double[] iso = null;

        double[] xn2 = null;
        double[] wn2 = null;
        double[] ynr2 = null;
        double[] ynw2 = null;
        double[] iso2 = null;
		double[] xx = null;
        byte ad_out;

        double[] henni_range_haba = new double[3];
        double saisho_a, saisho_b;

		double A, B;
        int series_num = 0;

        private System.Threading.Thread thread;

        int f_maxnum,f_maxnum2;
        //double f_max;
        double P1,P2;
        double P1_2, P2_2;
        double pFG = 0;
        double pFG2 = 0;
		int S_CT;
        int GX0 = 0;
        int GY0 = 450;
        double laser_pos;
        int stage_z;
        int zstep;
      
       

        double[] henni = null;
        double[] pvolt = null;
        double[] PH = null;
        double[] henni2 = null;
		double[] k_henni = null;
		double[] k_henni2 = null;
        double[] pvolt2 = null;
        double[] PH2 = null;

        double PHA0 = 0;
        double PHA0_2 = 0;

        double r_henni,r_henni2;
        int pcount;
        int iso_offset;

        LinearGradientBrush gb;

        double XMAX, YMAX, CX, CY;

        Boolean kousei;
        Boolean PIEZO;
        Boolean bZero;
        Boolean GraphAll;
        Boolean TAB2;
        Boolean EmSTOP;


        int pi_count;
        int sign;
        int iso_count;

        ushort gmin,gmin2;
        int nData;
    
        CompClass CP = new CompClass();
        CompClass CP2 = new CompClass();


        public const int default_lines = 4;
        public const int default_vertex = 4;
        public const int default_width = 6;
        public const int default_height = 480;
        public const int default_wait = 0;

        private threadClass objThread;
        private threadClass objThread2;
        private Thread th1,th2,th3,th4;


        Graphics g1,pg,g2,g3,g4,g5,g6;
        Bitmap canvas,canvas2,canvas3,canvas4,canvas5,canvas6;

        const string parameter_file = "parameter.xml";

        double ve;
        double R1, R2, Ra, Rb, R3, R4, RL;
        double vc;
        double vb, V3;
        double V1, V2, Vin;
        double Ic;
        int fs = 1800;
        int size = 1800;

       
        public Form1()
        {
            InitializeComponent();
            ReadParameter();
        }


		private void Form1_Load(object sender, EventArgs e)
		{
			//this.WindowState = FormWindowState.Maximized;

	

			db1 = new ImagingSolution.Drawing.DoubleBuffer(pictureBox1);
			db2 = new ImagingSolution.Drawing.DoubleBuffer(pictureBox5);
            db3 = new ImagingSolution.Drawing.DoubleBuffer(pictureBox7);

            ana = new AnalogCon.AD_DA();

			//canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			//g = Graphics.FromImage(canvas);

			g1 = db1.Graphics;
			g2 = db2.Graphics;
            g3 = db3.Graphics;
		
			Pen p = Pens.SkyBlue;

			this.Size = new Size(1400, 900);//330);

			
            ana.init_dac();
            ana.init_adc();
            ana.init_adc2();
			

			kousei = false;
			PIEZO = false;
			GraphAll = false;

			sign = 1;
			r_henni = 0;
			pcount = 0;
			iso_count = 0;

			YMAX = 20000; //[nm]
			XMAX = 130;//[V]

			EmSTOP = false;
			TAB2 = false;
			iso_offset = 0;
			nData = 1024;

			//      init_adc2();

			listView1.View = View.Details;
			listView1.CheckBoxes = true;
			listView1.FullRowSelect = true;
			listView1.GridLines = true;
			listView1.Sorting = SortOrder.Ascending;

			column_No = new ColumnHeader();
			column_FILENAME = new ColumnHeader();

			column_No.Text = "No";
			column_No.Width = 50;
			column_FILENAME.Text = "ファイル名";
			column_FILENAME.Width = 250;

			ColumnHeader[] colHeaderRegValue = { this.column_No, this.column_FILENAME };

			listView1.Columns.AddRange(colHeaderRegValue);

			numericUpDown1.Value = 55;

			sfd = new SaveFileDialog();

			sfd.FileName = "新しいファイル.csv";
			sfd.InitialDirectory = @"C:\";
			f_current = @"C:\";

			sfd.Filter =
				"csvファイル(*.csv)|*.csv;*.csv|csv(*.csv)|*.csv";
			//[ファイルの種類]ではじめに
			//「すべてのファイル」が選択されているようにする
			sfd.FilterIndex = 2;
			//タイトルを設定する
			sfd.Title = "保存先のファイルを選択してください";
			//ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
			sfd.RestoreDirectory = false;
			//既に存在するファイル名を指定したとき警告する
			//デフォルトでTrueなので指定する必要はない
			sfd.OverwritePrompt = true;
			//存在しないパスが指定されたとき警告を表示する
			//デフォルトでTrueなので指定する必要はない
			sfd.CheckPathExists = true;
			sfd.AddExtension = true;


			Count = 0;
			//draw_grid(g, p);

			//g.Dispose();
		
			//PictureBox1に表示する
			//pictureBox1.Image = canvas;
			file_name = new string[300];

			offset.Text = "512";
			offset2.Text = "512";
			SamplingNum.Text = "2000";

			numericUpDown1.Value = 10;
			numericUpDown1.Minimum = 1;
			numericUpDown1.Maximum = 10;

			pre_NUMERIC = 10;
			//this.Refresh();
			//GC.Collect();
            DispRange_Combo.Items.Add("Aレンジ");
            DispRange_Combo.Items.Add("Bレンジ");
            DispRange_Combo.Items.Add("Cレンジ");
            DispRange_Combo.SelectedIndex = 0;

            disp_range = 2;
            //ana.adOutDO(ana.hDevice2, 0x02);

            henni_range_haba[0] = 4;
            henni_range_haba[2] = 20;
            henni_range_haba[1] = 100;

            stage_z = 0;
            zstep = 0;
            ad_out = 0x00;

            ana.adOutDO(ana.hDevice, 0x00);
            //ana.daOutDO(ana.hDA, 0x03);//laser off
           // ana.daOutDO(ana.hDA, 0x02);//laser on

            button_stage_down.Enabled = false;
            button_stage_reset.Enabled = false;
            button_stage_stop.Enabled = false;
            button_stage_up.Enabled = false;
            button_laser_stop.Enabled = false;
         
		}


        private void draw_grid(Graphics gg, Pen p)
        {
            int w = 1024;
                
			gg.Clear(pictureBox1.BackColor);

           
            for (int i = 0; i < w; i += 50)
            {
				gg.DrawLine(p, i, 0, i, 250);
            }
			gg.DrawLine(p, 0, 210, w, 210);
         
			
        }
        private void draw_scale(Graphics gg)
        {

            Font fnt = new Font("MS UI Gothic", 10);
            //文字列を位置(0,0)、青色で表示
         

            gg.Clear(pictureBox7.BackColor);
            gg.DrawLine(Pens.Blue, 40, 259, 100, 259);
            gg.DrawLine(Pens.Blue, 40, 259+20*5, 100, 259+20*5);
            gg.DrawLine(Pens.Blue, 40, 259 + 20 * 10, 100, 259 + 20 * 10);
            gg.DrawLine(Pens.Blue, 40, 259 - 20 * 5, 100, 259 - 20 * 5);
            gg.DrawLine(Pens.Blue, 40, 259 - 20 * 10, 100, 259 - 20 * 10);

            gg.DrawString("変位[um]", fnt, Brushes.Blue, 10, 250);
          
        }
        private void draw_grid2(Graphics gg, Pen p)
        {
            CX = 800/XMAX;
            CY = 400/YMAX;//YMAX=20000;
          
            gg.Clear(pictureBox1.BackColor);

       
            for (double i = 0; i <= 200; i+=20)
            {
                gg.DrawLine(p, GX0 + (int)(CX * i), GY0+100, GX0 +(int)(CX * i),GY0-450);
            }

            

            for (int i = -300; i < 300; i+=20)
            {
                gg.DrawLine(p, GX0, 250+i, GX0 + 1500, 250+i);
            }
            //gg.DrawLine(Pens.Black, GX0, GY0, GX0 + 1500, GY0);
         
            //gg.DrawLine(Pens.Black, GX0, GY0, GX0, GY0 - 400);
           
        }
        private void ReadParameter()
        {
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(parameter_file);

                System.Xml.XmlElement root = doc.DocumentElement;

                this.Width = Int32.Parse(root.GetElementsByTagName("Width").Item(0).InnerText);
                this.Height = Int32.Parse(root.GetElementsByTagName("Height").Item(0).InnerText);
                this.lines = Int32.Parse(root.GetElementsByTagName("Lines").Item(0).InnerText);
                this.vertex = Int32.Parse(root.GetElementsByTagName("Vertex").Item(0).InnerText);
                this.wait_time = Int32.Parse(root.GetElementsByTagName("WaitTime").Item(0).InnerText);
            }
            catch (Exception)
            {
                this.Width = default_width;
                this.Height = default_height;
                this.lines = default_lines;
                this.vertex = default_vertex;
                this.wait_time = default_wait;
            }
        }//ReadParameter
  
      
        public void SignalGen()
        {
            for (int n = 0; n < nData; n++)
                xn[n] = (double)(((ushort[])ana.pAd)[n] - gmin) * 0.005;

            for (int n = 0; n < nData; n++)
                xn2[n] = (double)(((ushort[])ana.pAd2)[n] - gmin2) * 0.005;
        }
        public void FindMaxh()
        {
            int m=0;
            double max;

            max = -1000;

            for (int j = 0; j <= nData / 2; j++)
            {
                if (ynr[j] > max && j > 3)
                {
                    max = ynr[j];
                    m = j;
                 }
            }
            f_maxnum = m;

            max = -1000;

            for (int j = 0; j <= nData / 2; j++)
            {
                if (ynr2[j] > max && j > 3)
                {
                    max = ynr2[j];
                    m = j;
                }
            }
            f_maxnum2 = m;

        }
     
        public void Spectrum(bool w_yn, double[] m, double[] p, int inout)
        {
            double[] xw = new double[1024];

            if (w_yn)
            {
                for (int n = 0; n < nData; n++)
                    xw[n] = xn[n] * wn[n];

                CP.set_data(xw);
                CP.execute();
                CP.GetAbsNorm(m);
                CP.GetArg(p);
            }
            else
            {
                CP.set_data(xn);
                CP.execute();
                if (inout==1) CP.GetMax();
                CP.GetAbsNorm(m);
                CP.GetArg(p);
            }
        }
        public void Spectrum2(bool w_yn, double[] m, double[] p, int inout)
        {
            double[] xw = new double[1024];

            if (w_yn)
            {
                for (int n = 0; n < nData; n++)
                    xw[n] = xn2[n] * wn2[n];

                CP2.set_data(xw);
                CP2.execute();
                CP2.GetAbsNorm(m);
                CP2.GetArg(p);
            }
            else
            {
                CP2.set_data(xn2);
                CP2.execute();
                if (inout == 1) CP2.GetMax();
                CP2.GetAbsNorm(m);
                CP2.GetArg(p);
            }
        }
        public void draw_fringe1(int num, Graphics g1)
        {
            ushort da;
            int pre;
            int gda;

            int cy = 210;
            pre = 0;

            for (int i = 0; i < 1024; i++)
            {
                da = ((ushort[])ana.pAd)[i];
              
                if (num < 5)
                {
                    if (da < gmin) gmin = da;
                }
                gda = da;
                gda -= gmin;
             
               
                gda /= 5;

                if (i != 0)
                    g1.DrawLine(Pens.Red, i, cy - pre, (i + 1), cy - gda);

                pre = gda;
            }
            pre = 0;
		}
		public void draw_fringe2(int num, Graphics g2)
		{
			ushort da, pre;
			int cy = 210;
			pre = 0;

            for (int i = 0; i < 500; i++)
            {
                da = ((ushort[])ana.pAd2)[i];

                if (num < 5)
                {
                    if (da < gmin2) gmin2 = da;
                }
                da -= gmin2;

                da /= 50;

                if (i != 0)
                    g2.DrawLine(Pens.Blue, i, cy - pre, i + 1, cy - da);

                pre = da;
            }
        }
        public void draw_graph3(Graphics gg, int i)
        {
            CX = 400 / XMAX;
            CY = 0.02;
            
            gg.DrawLine(Pens.Black, GX0 + (int)((i - 1)*0.2), 250+ (int)(CY * henni[i - 1]), GX0 + (int)(i*0.2), 250 + (int)(CY * henni[i]));
            /*
            double sc = 45;

            Pen P1 = new Pen(System.Drawing.Color.Blue, 1);
            Pen P3 = new Pen(System.Drawing.Color.SkyBlue, 1);
            Pen P4 = new Pen(System.Drawing.Color.Red, 1);

            g4.DrawLine(P3, 0, 150, 600, 150);
            g4.DrawLine(P3, 0, 150-(int)(3.14*sc),600,150-(int)(3.14*sc));
            g4.DrawLine(P3, 0, 150 + (int)(3.14 * sc), 600, 150 + (int)(3.14 * sc));

            Point[] pts = new Point[iso_count+1];
            Point[] pts2 = new Point[iso_count + 1];


           iso_offset -= 4;

            for (int i = 0; i < iso_count; i++)
                pts[i] = new Point(300+i * 4 + iso_offset, 150 - (int)(iso[i] * sc));
            for (int i = 0; i < iso_count; i++)
                pts2[i] = new Point(300 + i * 4 + iso_offset, 150 - (int)(iso2[i] * sc));

            for (int i = 0; i < iso_count - 1; i++)
            {
                g4.DrawLine(P1, pts[i + 1].X, pts[i + 1].Y, pts[i].X, pts[i].Y);
            }
            for (int i = 0; i < iso_count; i++)
            {
                int gy = 150 - (int)(sc * iso[i]);

                g4.DrawEllipse(P1,300+ i*4+iso_offset-2, gy-2, 4, 4);
            }

            for (int i = 0; i < iso_count - 1; i++)
            {
                g4.DrawLine(P4, pts2[i + 1].X, pts2[i + 1].Y, pts2[i].X, pts2[i].Y);
            }
            for (int i = 0; i < iso_count; i++)
            {
                int gy = 150 - (int)(sc * iso2[i]);

                g4.DrawEllipse(P4, 300 + i * 4 + iso_offset-2, gy-2, 4, 4);
            }

            P1.Dispose();
            P3.Dispose();
             * */

        }
        
        public void draw_graph2(Graphics gg, int t)
        {
            //g3.FillRectangle(gb, g3.VisibleClipBounds);

          
            
            CX = 300/XMAX;
            CY = 400/YMAX;


            Pen P1 = new Pen(System.Drawing.Color.Blue, 2);
        
            gg.DrawLine(Pens.Gray, GX0 + 200, 0, GX0 + 200, 600);

            for (int i = 0; i < t; i++)
            {
               // int py = 400 - (int)(CY * henni[t]);
               // int px = (int)(t * CX);


                //g2.DrawEllipse(P1, px, py, 3, 3);
             /*   if (t >= 1000)
                {
                    if (i != 1000)
                        gg.DrawLine(P1, GX0 + (int)((i - 1)), GY0-350 + (int)(CY * henni[i - 1]), GX0 + (int)(i), GY0-350 + (int)(CY * henni[i]));
                }
                else
                {
              */ 
                    if (i != 0)
                        gg.DrawLine(P1, GX0 + (int)((i - 1)), GY0 + (int)(CY * henni[i - 1]), GX0 + (int)(i), GY0 + (int)(CY * henni[i]));
                
               // gg.DrawLine(P1, GX0+(int)(pvolt[i-1]*CX), GY0-350-(int)(CY*henni[i-1]), GX0+(int)(pvolt[i]*CX), GY0-350-(int)(CY*henni[i]));
              
            }
            

            P1.Dispose();
          

        }
		void gauss(double[,] a)
		{
			int j, k, l, pivot;
			double[] x = new double[3];
			double p, q, m;
			double[,] b = new double[1, 4];


			int N = 3;


			for (int i = 0; i < N; i++)
			{
				m = 0;
				pivot = i;

				for (l = i; l < N; l++)
				{
					if (Math.Abs(a[l, i]) > m)
					{   //i列の中で一番値が大きい行を選ぶ
						m = Math.Abs(a[l, i]);
						pivot = l;
					}
				}

				if (pivot != i)
				{                          //pivotがiと違えば、行の入れ替え
					for (j = 0; j < N + 1; j++)
					{
						b[0, j] = a[i, j];
						a[i, j] = a[pivot, j];
						a[pivot, j] = b[0, j];
					}
				}
			}
			for (k = 0; k < N; k++)
			{
				p = a[k, k];              //対角要素を保存
				a[k, k] = 1;              //対角要素は１になることがわかっているから

				for (j = k + 1; j < N + 1; j++)
				{
					a[k, j] /= p;
				}
				for (int i = k + 1; i < N; i++)
				{
					q = a[i, k];
					for (j = k + 1; j < N + 1; j++)
					{
						a[i, j] -= q * a[k, j];
					}
					a[i, k] = 0;              //０となることがわかっているところ
				}
			}
			//解の計算
			for (int i = N - 1; i >= 0; i--)
			{
				x[i] = a[i, N];
				for (j = N - 1; j > i; j--)
				{
					x[i] -= a[i, j] * x[j];
				}
			}
			for (int i = 0; i < N; i++)
			{
				xx[i] = x[i];
			}
		}

		void sai2(int ct, double[] x, double[] y)
		{
			int i, j, k;

			int n = 3;
			int S = ct;

			double[,] A = new double[3, 4];



			//初期化
			for (i = 0; i < n; i++)
			{
				for (j = 0; j < n + 1; j++)
				{
					A[i, j] = 0.0;
				}
			}
			//ガウスの消去法で解く行列の作成
			for (i = 0; i < n; i++)
			{
				for (j = 0; j < n; j++)
				{
					for (k = 0; k < S; k++)
					{
						A[i, j] += Math.Pow(x[k], i + j);
					}
				}
			}
			for (i = 0; i < n; i++)
			{
				for (k = 0; k < S; k++)
				{
					A[i, n] += Math.Pow(x[k], i) * y[k];
				}
			}
			gauss(A);

		}
        public void sai12(int num, double[] x, double[] y)
        {
            double a = 0;
            double b = 0;
            double sum_xy = 0;
            double sum_x = 0;
            double sum_y = 0;
            double sum_x2 = 0;

            for (int i = 0; i < num; i++)
            {
                sum_xy += x[i] * y[i];
                sum_x += x[i];
                sum_y += y[i];
                sum_x2 += System.Math.Pow(x[i], 2);
            }
            a = (num * sum_xy - sum_x * sum_y) / (num * sum_x2 - System.Math.Pow(sum_x, 2));
            b = (sum_x2 * sum_y - sum_xy * sum_x) / (num * sum_x2 - System.Math.Pow(sum_x, 2));

            saisho_a = a;
            saisho_b = b;

        }
		public void sai1(double[] x, double[] y)
		{
			double A00, A01, A02, A11, A12;

			A00 = A01 = A02 = A11 = A12 = 0.0;

			for (int i = 0; i < S_CT-10; i++)
			{
				A00 += 1.0;
				A01 += x[i];
				A02 += y[i];
				A11 += x[i] * x[i];
				A12 += x[i] * y[i];
			}
			/*１次式の係数の計算*/
			A = (A02 * A11 - A01 * A12) / (A00 * A11 - A01 * A01);
			B = (A00 * A12 - A01 * A02) / (A00 * A11 - A01 * A01);

			/*   double p,q;
			   p = modf(A/B,&q);
			   int n=(int)(A/B);
			   if(fabs(p)>0.5)n=abs(n)+1;
			   else n=abs(n);

			   return (n-1);
			   */
		}
		public void draw_text(Graphics b)
		{
			int dx = pictureBox4.Left-pictureBox3.Left;
			int dy = pictureBox4.Top-pictureBox3.Top-1;

			Pen p = new Pen(Color.Black, 1);

			b.DrawLine(p,dx, dy, dx - 10, dy);

			if (numericUpDown1.Value == 10)
			{
				//フォントオブジェクトの作成
				Font fnt = new Font("MS UI Gothic", 20);
				//文字列を位置(0,0)、青色で表示
				b.DrawString("これはテストです。", fnt, Brushes.Blue, dx-10, dy);
			}
			p.Dispose();

		}
		public void draw_graph4(Graphics b3)
		{
			int prex, prey, px, py;
			double zansa, kaiki;
			int k;
			double divx = 1000 / (iSamplingNum);

			prex = 0;
			prey = 0;

			Pen P1 = new Pen(System.Drawing.Color.Blue, 1);
			Pen P2 = new Pen(System.Drawing.Color.Black, 1);
			Pen P3 = new Pen(System.Drawing.Color.Gray, 1);
			Pen P4 = new Pen(System.Drawing.Color.Red, 1);

			Pen Pen1 = new Pen(Brushes.DeepSkyBlue);

			// Set the pen's width.
			Pen1.Width = 1;

			// Set the LineJoin property.
			//Pen1.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
			Pen1.DashStyle = DashStyle.Dash;
			Pen p = Pens.SkyBlue;
			k = 0;
			for (int i = 10; i < S_CT; i++)
			{
				pvolt[k] = i;
				k_henni[k] = henni[i];
				k++;
			}
			sai1(pvolt, k_henni);
			//xx = new double[4];

			//sai2(S_CT, pvolt, k_henni);

			//b3.DrawLine(Pen1, 0, 150, 1000, 150);
			for (int i = 0; i < 10; i++)
			{
				b3.DrawLine(p, 0, 300 - i * 30, 1000,300- i * 30);
			}
			for (int i = 0; i < S_CT-10; i++)
			{
				px = (int)(i*divx);//(int)(CX * henni[i]);
				kaiki = A + B * pvolt[i];
				// kaiki = xx[0] + xx[1] * pvolt[i] + xx[2] * pvolt[i] * pvolt[i];


				zansa = k_henni[i] - kaiki;
				py = 150 + (int)(zansa * 125);
				if (i >= 1)
				{
					b3.DrawLine(P4, prex, prey, px, py);			
				}
				b3.DrawEllipse(P4, px - 2, py - 2, 4, 4);
				prex = px;
				prey = py;
			}
			k = 0;
			for (int i = 10; i < S_CT; i++)
			{
				k_henni2[k] = henni2[i];
				k++;
							
			}
			sai1(pvolt, k_henni2);

			for (int i = 0; i < S_CT-10; i++)
			{
				 px = (int)(i*divx);//(int)(CX * henni[i]);
				 kaiki = A + B * pvolt[i];
			     //kaiki = xx[0] + xx[1] * pvolt[i] + xx[2] * pvolt[i] * pvolt[i] + xx[3] * pvolt[i] * pvolt[i] * pvolt[i];

				zansa = k_henni2[i] - kaiki;
				py = 150 + (int)(zansa*125);
							   
				if (i >=1)
				{
					b3.DrawLine(P1, prex, prey, px, py);
					
				}
				b3.DrawEllipse(P1, px - 2, py - 2, 4, 4);
				 prex = px;
				 prey = py;
			}
						   
			// g6.DrawLine(P2, 0, 65, 600, 65);
			// g6.DrawLine(P3, 0, 35, 600, 35);
			// g6.DrawLine(P3, 0, 95, 600, 95);

			/*     pcount3 = pcount - 100;

				 sai1(henni, henni2);
				 for (int i = 0; i < pcount3; i++)
				 {
					 px = i;//(int)(CX * henni[i]);
					 kaiki = A + B * henni[i];

					 zansa = henni2[i] - kaiki;
					 py = 65 - (int)(zansa * 3);
					 if (i != 0)
					 {
						 //     g6.DrawLine(P4, prex, prey, px, py);
					 }

					 prex = px;
					 prey = py;
				 }
				 */
			string s;
			Font font = new Font("MS UI Gothic", 12);
			SolidBrush drawBrush = new SolidBrush(Color.Black);
			// s = "計算結果";
			// g2.DrawString(s, font, drawBrush, 100, 50);

			s = "計算結果" + B.ToString("F4");
			// g6.DrawString(s, font, drawBrush, 100, 10);


			P1.Dispose();
			P4.Dispose();
			P3.Dispose();
			P2.Dispose();
			font.Dispose();
			drawBrush.Dispose();

		//	MessageBox.Show(this, A.ToString()+"+"+B.ToString());
		

		}
        public void  fft_cal(int CT)
        {  
            if (CT != 0)
            {
               double d = ynw[f_maxnum] - PHA0;

               if (Math.Abs(d) >= 5.0)
               {
                   if (d>=4.0) //(d >= 5.0)
                   {
                       pFG -= 2;
                   }
                   else if (d<=-4.0)//(d <= -5.0)
                   {
                       pFG += 2;
                   }
               }
               if(kousei)
                  PH[CT] = ynw[f_maxnum] + Math.PI * pFG;
               else
                   P2 = ynw[f_maxnum] + Math.PI * pFG;
             
             }
             else
               P1 = ynw[f_maxnum];

             PHA0 = ynw[f_maxnum];

             if (kousei)
               henni[CT] = (PH[CT] - P1) * 316.4 / (2 * Math.PI);
             else
                r_henni = (P2 - P1)*316.4/(2*Math.PI);

       
             if (kousei)
                 laser_henni.Text = henni[CT].ToString("0.00");
             else
                 laser_henni.Text = r_henni.ToString("0.00");

            // iso[iso_count] = ynw[f_maxnum];
        }

        public void fft_cal2(int CT)
        {
            if (CT != 0)
            {
                double d = ynw2[f_maxnum2] - PHA0_2;

                if (Math.Abs(d) >= 5.0)
                {
                    if (d >= 4.0) //(d >= 5.0)
                    {
                        pFG2 -= 2;
                    }
                    else if (d <= -4.0)//(d <= -5.0)
                    {
                        pFG2 += 2;
                    }
                }
                if (kousei)
                    PH2[CT] = ynw2[f_maxnum2] + Math.PI * pFG2;
                else
                    P2_2 = ynw2[f_maxnum2] + Math.PI * pFG2;

            }
            else
                P1_2 = ynw2[f_maxnum2];

            PHA0_2 = ynw2[f_maxnum2];

            if (kousei)
                henni2[CT] = (PH2[CT] - P1_2) * 316.4 / (2 * Math.PI);
            else
                r_henni2 = -1 * (P2_2 - P1_2) * 316.4 / (2 * Math.PI);


            if (kousei)
                laser_henni2.Text = henni2[CT].ToString("0.00");
            else
                laser_henni2.Text = r_henni2.ToString("0.00");

            iso2[iso_count] = ynw2[f_maxnum2];
        }

        public void draw_FFT_graph()
        {
            double fdx = 1;
            //int gy1 = 0;

            for(float j=1; j<nData/2;j++)
            {
                pg.DrawLine(Pens.Black, (int)((Math.Log10(j*fdx))*250),100,(int)((Math.Log10(j*fdx))*250),100-(int)(ynr[(int)j]*0.02));
               // pg.DrawLine(Pens.Black, (int)((Math.Log10(j * fdx)) * 250),0, (int)((Math.Log10(j * fdx)) * 250), 20);
                //pg.DrawLine(Pens.Black, 20, 0, 100, 20);
            }
            pg.DrawLine(Pens.Red, (int)((Math.Log10(f_maxnum * fdx)) * 250), 100, 
                (int)((Math.Log10(f_maxnum * fdx)) * 250), 100 - (int)(ynr[f_maxnum] * 0.02));
        }

		public void reset_raser()
		{
			CP.init_FFT(nData);
			CP2.init_FFT(nData);

			SignalGen();

			Spectrum(false,ynr,ynw,1);
			Spectrum2(false,ynr2,ynw2,1);

			FindMaxh();
		
			start_raser = ynw[f_maxnum];
			start_raser2 = ynw2[f_maxnum2];

			pre_raser = start_raser;
			pre_raser2= start_raser2;

		}
		public double get_raser2()
		{
			int m;
			double l,p,d;
		

			CP2.init_FFT(nData);

			SignalGen();
	
			Spectrum2(false,ynr2,ynw2,1);
			//f_maxnum2 = FindMaxh(ynr2);
			f_max2 = ynr2[f_maxnum2];


			m = f_maxnum2;


			d = ynw2[m] - pre_raser2;

	
			if( Math.Abs(d) >= 4.0 )
			{
				if ( d >= 4.0)
					fg2 -= 2;
	
				else if( d <= -4.0)
					fg2 += 2;
			}
			p = ynw2[m] + Math.PI*fg2;

			l = (p - start_raser2)*632.82*0.5/(2*Math.PI);

			pre_raser2 = ynw2[m];


			return (l);

		}
		public double get_raser()
		{
			int m;
			double l,p,d;
			double th = 4;

		
			CP.init_FFT(nData);

			SignalGen();
	
			Spectrum(false,ynr,ynw,1);

			//f_maxnum = FindMaxh(ynr);
			f_max = ynr[f_maxnum];


			m = f_maxnum;


			d = ynw[m] - pre_raser;

	
			if( Math.Abs(d) >= th )
			{
				if ( d >= th)
					fg -= 2;
	
				else if( d <= -1*th)
					fg += 2;
			}
			p = ynw[m] + Math.PI*fg;

			l = (p - start_raser)*632.82*0.5/(2*Math.PI);
            

			//	str.Format("%5.2lf",f_max);
			//	wnd->SetDlgItemText(IDC_LASER_MAX, str);
			//	str.Format("%3d",f_maxnum);
			//	wnd->SetDlgItemText(IDC_SPECTLE_NUM, str);

			pre_raser = ynw[m];


			return (l);

		}

		public void fake_sampling(int S_CT)
		{
			for (double i = 0; i < 1024; i++)
			{
				double j = (i - ioffset) / 128;
				double sig = 1.2;
				//double j = (i - 300) / 128;
				//double sig = 1.2;

				double se = (1 / (Math.Sqrt(2 * Math.PI) * sig));
				se *= Math.Exp(-j * j / (2 * sig * sig));

				((ushort[])ana.pAd)[(int)i] = (ushort)(se * (15000 * Math.Sin((2 * Math.PI * i) / 128 - S_CT * Math.PI / 10) + 15000));
				((ushort[])ana.pAd)[(int)i] += 32700;
			}
			for (double i = 0; i < 1024; i++)
			{
				double j = (i - ioffset2) / 128;
				double sig = 1.2;
				//double j = (i - 300) / 128;
				//double sig = 1.2;

				double se = (1 / (Math.Sqrt(2 * Math.PI) * sig));
				se *= Math.Exp(-j * j / (2 * sig * sig));

				((ushort[])ana.pAd2)[(int)i] = (ushort)(se * (15000 * Math.Sin((2 * Math.PI * i) / 128 - S_CT * Math.PI / 10) + 15000));
				((ushort[])ana.pAd2)[(int)i] += 32700;
			}
		}
        public void plot(int num, double[] h)
        {
            Series series1 = new Series("評価装置");
            Series series2 = new Series("DSC-01");
        

            // 波形生成
            for (int i = 1; i < num; i++)
            {
              
                series1.Points.AddXY(i, henni[i]);
            }
          
            series1.ChartType = SeriesChartType.Line; // グラフ形状
            series2.ChartType = SeriesChartType.Line; // グラフ形状
          

           // chart1.Series.Clear();
           // chart1.Series.Add(series1);
         //   chart1.Series.Add(series2);
       

            //Axis ax = chart1.ChartAreas[0].AxisX;
           // ax.MajorGrid.LineColor = Color.LightGray;
            //ax.Maximum = -1000;

            //Axis ay = chart1.ChartAreas[0].AxisY;
            //ay.MajorGrid.LineColor = Color.LightGray;
            

           // ay.Minimum = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            objThread = new threadClass(new deleDraw(t3_sub));

            objThread.gCount = 0;
            pcount = 0;
            objThread.bContinue = true;

            th1 = new Thread(new ThreadStart(objThread.wThread));

            th1.Start();

           

        }
        private void t3_sub(ref int Count)
        {
            try
            {

			double ld,ld2,int_ld;
            int count = 0;

            iSamplingNum = 5000;

			fg = 0;
			fg2 = 0;

			ana.pAd = new ushort[1024];
			ana.pAd2 = new ushort[1024];

            ana.pAd = new ushort[1024];
            ana.pAd2 = new ushort[1024];

            xn = new double[1024];
			xn2 = new double[1024];

            ynr = new double[1024];
			ynr2 = new double[1024];

            ynw = new double[1024];
			ynw2 = new double[1024];

			xx = new double[iSamplingNum+11];

            PH = new double[500];

			henni = new double[4000];
			pvolt = new double[4000];

            gmin = 50000;
			gmin2 = 50000;


            button_Test.Enabled = false;
            button_laser.Enabled = false;
            button_laser_stop.Enabled = false;
            button_stage_down.Enabled = false;
            button_stage_reset.Enabled = false;
            button_stage_stop.Enabled = false;
            button_stage_up.Enabled = false;
            
            //button_start.Enabled = false;

            ad_out = 0x05;
            ana.adOutDO(ana.hDevice, ad_out);

			//ana.adOutDO(ana.hDevice2,0x00);
          // ana.adOutDO(ana.hDevice2, 0x05);

			Pen p1 = new Pen(Brushes.SkyBlue);
			p1.DashStyle = DashStyle.DashDot;
  
            double pv=0;
            double da;
            double PIEZO_stroke, PIEZO_d;


            if (standard.Checked)
            {
                PIEZO_stroke = 120;
                PIEZO_d = 0.24;
            }
            else
            {
                PIEZO_stroke = 30;
                PIEZO_d = 0.05;
            }
            int pnum = 0;

            for (int S_CT = 0; S_CT < 200; S_CT++)
            {
               
                ana.ad_sampling(ana.hDevice);

                draw_grid(g1, p1);
                draw_fringe1(S_CT, g1);


                if (S_CT < 5)
                {
                    reset_raser();
                    ld = 0;
                    ld2 = 0;
                }
                else
                {
                    ld = get_raser();
                }

                db1.Refresh();

                pv = 0.0;
                //da = (129.5723 - pv) / 0.00395;

                pvolt[count] = pv;
                henni[count] = ld;


                ana.daOutDA(ana.hDA, pv,ld);

                draw_grid2(g2,p1);
                draw_graph2(g2,count);
                db2.Refresh();
                count++;

                laser_henni.Text = ld.ToString("0.00");
                laser_henni.Refresh();
            }

            //ピエゾステージ上昇
            pnum = (int)(PIEZO_stroke / PIEZO_d);

            for (S_CT = 0; S_CT < pnum; S_CT++)
            {
				ana.ad_sampling(ana.hDevice);


                pv = pv + PIEZO_d;
              //  da = (129.5723 - pv) / 0.00395;
            
              
                draw_grid(g1,p1);
                draw_fringe1(S_CT,g1);

                if (S_CT < 5)
                {
                    reset_raser();
                    ld = 0;
                    ld2 = 0;
                }
                else
                {
                    ld = get_raser();
                }
                ana.daOutDA(ana.hDA, pv,ld);

				db1.Refresh();
			
				laser_henni.Text = ld.ToString("0.00");
                //textBox1.Text = pv.ToString("0");
				laser_henni.Refresh();
		
                //textBox1.Refresh();

                pvolt[count] = pv;
				henni[count] = ld;
            
		
                draw_grid2(g2, p1);
                draw_graph2(g2,count);
                db2.Refresh();
                count++;
                
            }
            //待機///////////////////////////////
        
            count = 0;
            laser_pos = 0;
            bool l0 = false;

            for (S_CT = 0; S_CT < 200; S_CT++)
            {
               

                ana.ad_sampling(ana.hDevice);

                //  da = (129.5723 - pv) / 0.00395;


                draw_grid(g1, p1);
                draw_fringe1(S_CT, g1);

                ld = get_raser();
                ana.daOutDA(ana.hDA, pv, ld);

                if (S_CT > 100 && l0 == false)
                {
                    laser_pos = get_raser();
                    l0 = true;
                }

                db1.Refresh();

                laser_henni.Text = (ld-laser_pos).ToString("0.00");
                //textBox1.Text = pv.ToString("0");
                laser_henni.Refresh();

                //textBox1.Refresh();

                pvolt[count] = pv;
                henni[count] = ld;

                draw_grid2(g2, p1);
                draw_graph2(g2, count);
                db2.Refresh();
                count++;
            }
            //ピエゾステージ下降
            pnum = (int)(PIEZO_stroke / PIEZO_d) * 2;

            for (S_CT = 0; S_CT < pnum; S_CT++)
            {
                ana.ad_sampling(ana.hDevice);


                pv = pv - PIEZO_d*0.5;
                //da = (129.5723 - pv) / 0.00395;
             

                draw_grid(g1, p1);
                draw_fringe1(S_CT, g1);

                ld = get_raser();
                ana.daOutDA(ana.hDA, pv, ld);
                
                db1.Refresh();
                db2.Refresh();
                laser_henni.Text = (ld-laser_pos).ToString("0.00");
                //textBox1.Text = pv.ToString("0");
                laser_henni.Refresh();

                textBox3.Text = count.ToString("0");
                textBox3.Refresh();

                //textBox1.Refresh();
                
                pvolt[count] = pv;
                henni[count] = ld;
                
                draw_grid2(g2, p1);
                draw_graph2(g2, count);
                
                count++;
                
            }
            //待機
            for (S_CT = 0; S_CT < 50; S_CT++)
            {
                ana.ad_sampling(ana.hDevice);


             //   pv = pv + 0.2;
               // da = (129.5723 - pv) / 0.00395;
               
              
                draw_grid(g1, p1);
                draw_fringe1(S_CT, g1);

                ld = get_raser();

                ana.daOutDA(ana.hDA, pv,ld);
                db1.Refresh();
                db2.Refresh();
                laser_henni.Text = (ld-laser_pos).ToString("0.00");
                //textBox1.Text = pv.ToString("0");
                laser_henni.Refresh();

                //textBox1.Refresh();

                pvolt[count] = pv;
                henni[count] = ld;

                draw_grid2(g2, p1);
                draw_graph2(g2, count);
                count++;
            }

            pnum = (int)((PIEZO_stroke / PIEZO_d) * 0.5);
            for (S_CT = 0; S_CT < pnum; S_CT++)
            {
                ana.ad_sampling(ana.hDevice);


                pv = pv + PIEZO_d * 2;
                // da = (129.5723 - pv) / 0.00395;


                draw_grid(g1, p1);
                draw_fringe1(S_CT, g1);

                ld = get_raser();

                ana.daOutDA(ana.hDA, pv, ld);
                db1.Refresh();
                db2.Refresh();
                laser_henni.Text = (ld - laser_pos).ToString("0.00");
                //textBox1.Text = pv.ToString("0");
                laser_henni.Refresh();

                //textBox1.Refresh();

                pvolt[count] = pv;
                henni[count] = ld;

                draw_grid2(g2, p1);
                draw_graph2(g2, count-600);
                count++;
            }
            pnum = (int)((PIEZO_stroke / PIEZO_d) * 0.5);

            for (S_CT = 0; S_CT < pnum; S_CT++)
            {
                ana.ad_sampling(ana.hDevice);


                pv = pv - PIEZO_d * 2;
                // da = (129.5723 - pv) / 0.00395;


                draw_grid(g1, p1);
                draw_fringe1(S_CT, g1);

                ld = get_raser();

                ana.daOutDA(ana.hDA, pv, ld);
                db1.Refresh();
                db2.Refresh();
                laser_henni.Text = (ld - laser_pos).ToString("0.00");
                //textBox1.Text = pv.ToString("0");
                laser_henni.Refresh();

                //textBox1.Refresh();

                pvolt[count] = pv;
                henni[count] = ld;

                draw_grid2(g2, p1);
                draw_graph2(g2, count - 600);
                count++;
            }
			p1.Dispose();

            ana.daOutDA(ana.hDA, 0, 0);

            ad_out = 0x08;
            ana.adOutDO(ana.hDevice, ad_out);
            button_Test.Enabled = true;
          
            file_write2();
            file_write();

            button_Test.Enabled = true;
            button_laser.Enabled = true;
            button_laser_stop.Enabled = true;
            button_stage_down.Enabled = true;
            button_stage_reset.Enabled = true;
            button_stage_stop.Enabled = true;
            button_stage_up.Enabled = true;

            objThread.bContinue = false;
            MessageBox.Show("終了しました");

        }
             catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void file_write3()
        {
            DateTime now = DateTime.Now;
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");


            StreamWriter writer =
             new StreamWriter(@"C:\AIST_LASER\LOG\" + now.ToString("MMdd-HHmm") + ".csv", true, sjisEnc);

            writer.WriteLine("*1.0(Win10DELLPC)");
            writer.WriteLine("Model:  AIST-LASER  ");
            writer.WriteLine("*");
            writer.WriteLine("レーザー変位");


            for (int i = 0; i < 1024; i++)
            {
                writer.WriteLine("{0},{1},{2}", i,xn[i],ynr[i]);

            }


            writer.Close();


        }
        private void file_write2()
        {
               DateTime now = DateTime.Now;
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

         
            StreamWriter writer =
             new StreamWriter(@"C:\AIST_LASER\LOG\" + now.ToString("MMdd-HHmm") + ".csv", true, sjisEnc);

            writer.WriteLine("*1.0(Win10DELLPC)");
            writer.WriteLine("Model:  AIST-LASER  ");
            writer.WriteLine("*");
            writer.WriteLine("レーザー変位");


            for (int i = 200; i < 1200; i++)
            {
                writer.WriteLine("{0},{1},{2}", i - 200, henni[i] -laser_pos,pvolt[i]);

            }
         
            
            writer.Close();
        

        }
        private void file_write()
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");


            StreamWriter writer =
             new StreamWriter(@"C:\AIST_LASER\LOG\" + "hakei01" + ".csv", true, sjisEnc);

            writer.WriteLine("*1.0(Win10DELLPC)");
            writer.WriteLine("Model:  AIST-LASER  ");
            writer.WriteLine("*");
            writer.WriteLine("レーザー変位");


            for (int i = 0; i < 1024; i++)
            {
                writer.WriteLine("{0},{1}", i, ((ushort[])ana.pAd)[i]);

            }


            writer.Close();
        
            /*
            sfd.InitialDirectory = f_current;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
          
                Console.WriteLine(sfd.FileName);
                string[] date = new string[10];

                DateTime dt = DateTime.Now;

                Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                StreamWriter writer = new StreamWriter(sfd.FileName, true, sjisEnc);

                writer.WriteLine("{0}", dt.ToString("MM") + dt.ToString("dd") + "-" + dt.ToString("HH") + dt.ToString("mm") + dt.ToString("ss"));

          

                for (int i = 200; i < 1400; i++)
                {
                    writer.WriteLine("{0},{1}", i - 200, henni[i] - laser_pos);

                }
        
                f_current = Path.GetFullPath(sfd.FileName);
                file_name[Count] = sfd.FileName;

                Count++;
                writer.Close();

               
            }
            */
        }
		private void sokutei_tab_SelectedIndexChanged(object sender, EventArgs e)
		{
			canvas3 = new Bitmap(pictureBox3.Width, pictureBox3.Height);
			g3 = Graphics.FromImage(canvas3);
			canvas4 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
			g4 = Graphics.FromImage(canvas4);
			canvas5 = new Bitmap(pictureBox4.Width, pictureBox4.Height);
			g5 = Graphics.FromImage(canvas5);
			canvas6 = new Bitmap(pictureBox6.Width, pictureBox6.Height);
			g6 = Graphics.FromImage(canvas6);

			gb = new LinearGradientBrush(
					 g3.VisibleClipBounds,
					 Color.SkyBlue,
					 Color.White,
					 LinearGradientMode.Vertical);

			g3.FillRectangle(gb, g3.VisibleClipBounds);

			Pen p = Pens.SkyBlue;
			draw_grid(g4,p);
			draw_fringe1(0,g4);
			draw_fringe2(0,g4);
			draw_graph4(g5);
			draw_text(g3);


			g3.Dispose();
			g4.Dispose();
			g5.Dispose();
			g6.Dispose();


			//PictureBox1に表示する
			pictureBox3.Image = canvas3;
			pictureBox2.Image = canvas4;
			pictureBox4.Image = canvas5;
			pictureBox6.Image = canvas6;
			


			this.Refresh();
			GC.Collect();


			listView1.Items.Clear();

			for (int i = 0; i < Count; i++)
			{
				int n = i + 1;
				string[] item3 = { n.ToString(), file_name[i] };
				listView1.Items.Add(new ListViewItem(item3));
			}

			 
		}
       


        private void 線ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("aho");
        }

  //      private void StartCal_Click(object sender, EventArgs e)
  //      {
    //        int sokutei_num;
      //      sokutei_num = Convert.ToInt32(text_sokutei.Text);

        //    DialogResult result = MessageBox.Show("校正を開始します","校正開始",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
          //  if (result == DialogResult.OK)
           // {
             //   button_start.Enabled = false;

               // string[] fn = new string[10];
               // string[] date = new string[10];

                //DateTime dt = DateTime.Now;

               // canvas2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
               // fg = Graphics.FromImage(canvas2);

               // string drawString;

              //  Font drawFont = new Font("MS UI Gothic", 11);
              //  SolidBrush drawBrush = new SolidBrush(Color.Black);

           //     for(int sk=0; sk < sokutei_num; sk++)
           //     {
                //    fn[sk]="c:\\LOG\\laser_"+dt.ToString("MM")+dt.ToString("dd")+"-"+dt.ToString("HH")+dt.ToString("mm")+dt.ToString("ss");
                //    drawString = fn[sk];
                //    fg.DrawString(drawString, drawFont, drawBrush, 0, sk*25);
         //       }
	//
               // fg.Dispose();

               // pictureBox2.Image = canvas2;
            

               // drawFont.Dispose();
               // drawBrush.Dispose();
                
        //    }
       //     button_start.Enabled = true;

    //    }

        private void button_stop_Click(object sender, EventArgs e)
        {

            int bb;
            bb = ad_out;
            bb |= 0x10;
            ad_out = (byte)bb;

            ana.adOutDO(ana.hDevice, ad_out);

            zstep = 1;
            //objThread = new threadClass(new deleDraw(t5_sub));

            //objThread.gCount = 0;
            //pcount = 0;
            //objThread.bContinue = true;

            //th3 = new Thread(new ThreadStart(objThread.wThread));

            //th3.Start();

           
            //objThread.bContinue = false;
            //EmSTOP = true;
        }
        private void t1_sub(ref int Count)
        {
            double p_vout=0;
      
            double dac=0;

            double ld, ld2;

            gmin = 50000;
            gmin2 = 50000;

            button_Test.Enabled = false;
            //button_start.Enabled = false;

         
			ana.adOutDO(ana.hDevice, 0x00);
			ana.adOutDO(ana.hDevice2, 0x00);

            try
            {
        
                if (PIEZO)
                {
                    ushort[] wData = new ushort[2];
                    uint[] ghChannel = new uint[2];


                    if (sign == 1)
                        dac = 32768 + pi_count * 40;
                    else if (pi_count <(int)(32768/40))
                        dac = 65535 - pi_count * 40;
                    else
                    {
                        dac = 32768;
                        PIEZO = false;
                        GraphAll = true;
                    }

                    if (dac >= 65500)
                    {
                        pi_count = 0;
                        sign = -1;
                    }

                    wData[0] = (ushort)(1 * dac);

                    p_vout = (dac * 20 / 65535) - 10;
                    
                    SamplingNum.Text = p_vout.ToString("f");

                    pvolt[pcount] = p_vout;
                   
                    IFCDA_ANY.DaOutputDA(ana.hDA, 1, ana.DA_SmplChInf, wData);                 
  
                }
                if (bZero)
                {
                    Count = 0;
                    pFG = 0;

                    bZero = false;
                }
                /*
             
			
                 */

                //textBox1.Text = Count.ToString("d");
				/*ana.start_sampling(ana.hDevice);
				ana.start_sampling(ana.hDevice2);

				ana.adOutDO(ana.hDevice, 0x00);
				ana.adOutDO(ana.hDevice2, 0x00);

				ana.get_data1(ana.hDevice);
				ana.get_data2(ana.hDevice2);
                */

                ana.ad_sampling(ana.hDevice);


				Pen p = Pens.SkyBlue;
                draw_grid(g1,p);
                draw_grid(g2,p);
         
                    draw_fringe1(0,g1);
					draw_fringe2(0,g2);

                /*    CP.init_FFT(nData); 
                    CP2.init_FFT(nData);

                    SignalGen();
                    Spectrum(false, ynr, ynw, 1);

                    Spectrum2(false, ynr2, ynw2, 1);

                    FindMaxh();
                  //  draw_FFT_graph();
                    fft_cal(Count);
                    fft_cal2(Count);
                */
                    if (Count < 5)
                    {
                        reset_raser();
                        ld = 0;
                        ld2 = 0;
                    }
                    else
                    {
                        ld = get_raser();
                      //  ld2 = get_raser2();
                    } 
                    henni[pcount] = r_henni;
                    henni2[pcount] = r_henni2;

                  
                    if (PIEZO)
                    {
                            iso_count++;
                           // draw_graph3();
                    }
                        
                    
                    
                //    draw_graph2();

                    if (PIEZO || GraphAll)
                    {
                       // draw_graph2();
                        if(PIEZO)  pcount++;
                    }

                    db1.Refresh();
                    db2.Refresh();

             
                    Count++;
                    pi_count++;
                
            }
            catch (ThreadAbortException)
            {
				ana.close();
             
                button_Test.Enabled = true;
               // button_start.Enabled = true;

                MessageBox.Show("スレッドが停止した", "メッセージ");
            }
        }
        private void t2_sub(ref int Count)
        {
            double v;

            try
            {
                ushort[] wData = new ushort[2];
                uint[] ghChannel = new uint[2];
                int gnErrCode = -1;

                // Output one analog data on the board.
                for (double i = 32768; i < 65535; i += 0.04)
                {
                    wData[0] = (ushort)(1 * i);
                    v = (i * 20 / 65535) - 10;
                    SamplingNum.Text = v.ToString("f");

                    if (objThread2.bContinue==false) break;
                    gnErrCode = IFCDA_ANY.DaOutputDA(ana.hDA, 1, ana.DA_SmplChInf, wData);
                    Count++;
                }
                for (double i = 65535; i > 32768; i -= 0.04)
                {
                    wData[0] = (ushort)(1 * i);
                    v = (i * 20 / 65535) - 10;
                    SamplingNum.Text = v.ToString("f");

                    if (objThread2.bContinue==false) break;

                    gnErrCode = IFCDA_ANY.DaOutputDA(ana.hDA, 1, ana.DA_SmplChInf, wData);
                    Count++;
                }
                objThread2.bContinue = false;

               
            }
            catch (ThreadAbortException)
            {

                IFCDA_ANY.DaClose(ana.hDA);

                MessageBox.Show("スレッドが停止した", "メッセージ");
            }
            // IFCDA_ANY.DaClose(hDA);
        }

        private void threadSub2()
        {

            double ld, ld2;
            int data_num = 5000;
            ushort[] wData = new ushort[2];

            string stroffset = offset.Text;
            ioffset = int.Parse(stroffset);
            string stroffset2 = offset2.Text;
            ioffset2 = int.Parse(stroffset2);
            string strSamplingNum = SamplingNum.Text;
            iSamplingNum = int.Parse(strSamplingNum);

            fg = 0;
            fg2 = 0;

            pAd = new ushort[1024];
            pAd2 = new ushort[1024];

            ana.pAd = new ushort[1024];
            ana.pAd2 = new ushort[1024];

            xn = new double[1024];
            xn2 = new double[1024];

            ynr = new double[1024];
            ynr2 = new double[1024];

            ynw = new double[1024];
            ynw2 = new double[1024];

            xx = new double[data_num*2];

            PH = new double[500];

            henni = new double[data_num*2];
            henni2 = new double[data_num*2];

            pvolt = new double[data_num*2];

            k_henni = new double[data_num*2];
            k_henni2 = new double[data_num*2];


            ////////////////

            //ana.daOutDO(ana.hDA, 0x0001);
            ana.adOutDO(ana.hDevice, 0x00);


            //ana.daOutDO(ana.hDA, 0x003);

            //////////

            gmin = 50000;
            gmin2 = 50000;


            button_Test.Enabled = false;
            //button_start.Enabled = false;


    

            Pen p1 = new Pen(Brushes.SkyBlue);
            p1.DashStyle = DashStyle.DashDot;

       
        
            // int hEvent = CreateEvent(0, TRUE, FALSE, NULL);
            double h2 = 0.0;
            double h0 = 0.0;
            int num = 0;

     

            for (S_CT = 0; S_CT < 2000; S_CT++)
            {
               textBox2.Text = S_CT.ToString("d");
                ana.ad_sampling(ana.hDevice);
                textBox2.Refresh();

                draw_grid(g1, p1);
             //   draw_grid(g2, p1);

                //  draw_grid2();
                draw_fringe1(S_CT,g1);
              //  draw_fringe2(S_CT,g2);

             

                if (S_CT < 5)
                {
                    reset_raser();
                    ld = 0;
                    ld2 = 0;
                }
                else
                {
                    ld = get_raser();
                    ld2 = get_raser2();
                }
                if (S_CT > 5)
                {
                    db1.Refresh();
           
                    laser_henni.Text = ld.ToString("0.00");
            
                
                    laser_henni.Refresh();
        
                    num++;
                    //plot(S_CT, henni);
                }

            }
     

            p1.Dispose();
            //ana.close();

            button_Test.Enabled = true;
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stage_z = 0;
         
        }
        private void dig_out_Click(object sender, EventArgs e)
        {
            ana.daOutDO(ana.hDA, 0x03);
        }
        private void ZERO_Click(object sender, EventArgs e)
        {
            int bb;
            bb = ad_out;
            bb |= 0x40;
            zstep = 10;

            ana.adOutDO(ana.hDevice, (byte)bb);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ana.adOutDO(ana.hDevice2, 0x00);
        }

        private void dig_out2_Click(object sender, EventArgs e)
        {
            ana.daOutDO(ana.hDA, 0x02);
            button_Test.Enabled = true;
            button_laser.Enabled = true;
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TAB2 = true;
        }

		private void OK_Click(object sender, EventArgs e)
		{
			//ana.close();
			Application.Exit();
		}

		private void w_apply_Click(object sender, EventArgs e)
		{
			Pen p = Pens.Black;
			draw_grid(g1,p);
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			decimal s = numericUpDown1.Value;

			if (s < pre_NUMERIC)
			{
				switch ((int)s)
				{
					case 9:
						numericUpDown1.Value = 4;
						break;
					//piezo_test_show();
					case 3:
						numericUpDown1.Value = 2;
						break;
				}
			}
			else if (s > pre_NUMERIC)
			{
				switch ((int)s)
				{
					case 3:
						numericUpDown1.Value = 4;
						break;
					case 5:
						numericUpDown1.Value = 10;
						break;
					default:
						break;
				}
			}
			pre_NUMERIC = (int)numericUpDown1.Value;

/*
			canvas3 = new Bitmap(pictureBox3.Width, pictureBox3.Height);
			g3 = Graphics.FromImage(canvas3);
			canvas5 = new Bitmap(pictureBox4.Width, pictureBox4.Height);
			g5 = Graphics.FromImage(canvas5);
			canvas6 = new Bitmap(pictureBox6.Width, pictureBox6.Height);
			g6 = Graphics.FromImage(canvas6);

			gb = new LinearGradientBrush(
					 g3.VisibleClipBounds,
					 Color.SkyBlue,
					 Color.White,
					 LinearGradientMode.Vertical);

			g3.FillRectangle(gb, g3.VisibleClipBounds);

			Pen p = Pens.SkyBlue;
		
			//draw_graph4(g5);
			draw_text(g3);


			g3.Dispose();
			g4.Dispose();
			g5.Dispose();
			g6.Dispose();


			//PictureBox1に表示する
			pictureBox3.Image = canvas3;
			pictureBox4.Image = canvas5;
			pictureBox6.Image = canvas6;



			this.Refresh();
			GC.Collect();

			draw_text(g3);
 */
		}

		private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
		{
		
			int inc = (int)numericUpDown1.Increment;

		
		}

		private void numericUpDown1_KeyUp(object sender, KeyEventArgs e)
		{

		}

        private void button1_Click_1(object sender, EventArgs e)
        {
            objThread.bContinue = false;

            button_stage_down.Enabled = false;
            button_stage_reset.Enabled = false;
            button_stage_stop.Enabled = false;
            button_stage_up.Enabled = false;
            button_laser_stop.Enabled = false;
        }
        public double Sin(int freq, int i)
        {
            double sin = Math.Sin(2 * (freq * fs / 180) * i * Math.PI / fs);
            return sin;
        }

      
        private void Async_laser_Click(object sender, EventArgs e)
        {
            button_stage_down.Enabled = true;
            button_stage_reset.Enabled = true;
            button_stage_stop.Enabled = true;
            button_stage_up.Enabled = true;
            button_laser_stop.Enabled = true;


            objThread = new threadClass(new deleDraw(t4_sub));

            objThread.gCount = 0;
            pcount = 0;
            objThread.bContinue = true;

            th1 = new Thread(new ThreadStart(objThread.wThread));

            th1.Start();

           
        }
        private void t4_sub(ref int Count)
        {
            double ld, ld2;

            string stroffset = offset.Text;
            ioffset = int.Parse(stroffset);
            string stroffset2 = offset2.Text;
            ioffset2 = int.Parse(stroffset2);
            string strSamplingNum = SamplingNum.Text;
            iSamplingNum = 5000;// int.Parse(strSamplingNum);


            fg = 0;
            fg2 = 0;

            ana.pAd = new ushort[1024];
            ana.pAd2 = new ushort[1024];

            pAd = new ushort[1024];
            pAd2 = new ushort[1024];

            xn = new double[1024];
            xn2 = new double[1024];

            ynr = new double[1024];
            ynr2 = new double[1024];

            ynw = new double[1024];
            ynw2 = new double[1024];

            xx = new double[iSamplingNum + 11];

            PH = new double[500];

            henni = new double[iSamplingNum + 11];
            henni2 = new double[iSamplingNum + 11];

            pvolt = new double[iSamplingNum + 11];

            k_henni = new double[iSamplingNum + 11];
            k_henni2 = new double[iSamplingNum + 11];



            gmin = 35000;
            gmin2 = 35000;


            button_Test.Enabled = false;
            //button_start.Enabled = false;

            int bb;
            bb = ad_out;
            bb = 0x00;
            ad_out = (byte)bb;

            ana.adOutDO(ana.hDevice, ad_out);

            bb = ad_out;
            bb = 0x05;
            ad_out = (byte)bb;

            ana.adOutDO(ana.hDevice, ad_out);
          
            Pen p1 = new Pen(Brushes.SkyBlue);
            p1.DashStyle = DashStyle.DashDot;

          

           // int hEvent = CreateEvent(0, TRUE, FALSE, NULL);
            int count = 0;
            draw_grid2(g2, p1);
            draw_scale(g3);
            db3.Refresh();

            for (S_CT = 0; S_CT < 6000; S_CT++)
            {
                //textBox1.Text = S_CT.ToString("d");
                //ana.ad_sampling2(ana.hDevice, ana.hDevice2);
                ana.ad_sampling(ana.hDevice);
                //{
                //    MessageBox.Show("Error");
                //}

                if (objThread.bContinue == false)
                    break;

                draw_grid(g1, p1);
               // draw_grid(g2, p1);

                //  draw_grid2();
                draw_fringe1(S_CT,g1);
               // draw_fringe2(S_CT,g2);


                if (S_CT < 5)
                {
                    reset_raser();
                    ld = 0;
                   // ld2 = 0;
                }
                else
                {
                    ld = get_raser();
                    //ld2 = get_raser2();
                }

                db1.Refresh();
            
               // db2.Refresh();
                laser_henni.Text = ld.ToString("0.000");
               // laser_henni2.Text = ld2.ToString("0.000");
                textBox1.Text = S_CT.ToString("0");
                laser_henni.Refresh();
               // laser_henni2.Refresh();
                textBox1.Refresh();

                stage_z += zstep;
                double dz = (double)stage_z;

                dz *= (0.2 / 933);
             


                //System.Threading.Thread.Sleep(20);
                henni[S_CT] = ld;
               // henni2[S_CT] = ld2;

                textBox3.Text = S_CT.ToString();
                textBox3.Refresh();

               if(count>10)
                draw_graph3(g2, count-10);

                db2.Refresh();
                
                count++;
            }
            p1.Dispose();
            //ana.close();
            objThread.bContinue = false;

            button_Test.Enabled = true;
            //button_start.Enabled = true;

            bb = ad_out;
            bb = 0x08;
            ad_out = (byte)bb;
       

            ana.adOutDO(ana.hDevice, ad_out);
            file_write3();
        }
     
        private void DispRange_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int range = DispRange_Combo.SelectedIndex;

            switch (range)
            {
                case 0:
                    disp_range = 0;
                    ana.adOutDO(ana.hDevice2, 0x00);
                    break;
                case 1:
                    disp_range = 2;
                    ana.adOutDO(ana.hDevice2, 0x02);
                    break;
                case 2:
                    disp_range = 1;
                    ana.adOutDO(ana.hDevice2, 0x01);
                    break;
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.FileName = "aho.csv";

            sfd.InitialDirectory = @"C:\Users\elionix\Documents\sarada\DATA";

            sfd.Filter = "csvファイル|*.csv";

            sfd.FilterIndex = 2;

            sfd.Title = "保存先のファイルを選択してください";

            sfd.RestoreDirectory = true;

            sfd.OverwritePrompt = true;

            sfd.CheckPathExists = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                System.IO.Stream stream;

                stream = sfd.OpenFile();

                if (stream != null)
                {
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(stream);

                    double ld = 0;
                    for (int i = 0; i < 2600; i++)
                    {
                        string ss = pvolt[i].ToString("F4") +","+henni[i].ToString("F4") + "\n";
                        sw.Write(ss);
                    }
                    for (int i = 0; i < 1000; i++)
                    {
                  //      string ss = disp_data3[i].ToString("F4") + "," + Load_data3[i].ToString("F5") + "\n";
                 //       sw.Write(ss);
                    }
                    sw.Close();
                    stream.Close();
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Axis ax2 = chart2.ChartAreas[0].AxisX;
            Axis ay2 = chart2.ChartAreas[0].AxisY;

            //chart2.ChartAreas[0].InnerPlotPosition.Auto = false;
            //chart2.ChartAreas[0].InnerPlotPosition.Width = 1;
            int start_num = 0;
            int end_num = 0;
            saisho_a = 0;
            saisho_b = 0;

            chart2.Series.Clear();

            ax2.Maximum = 2000;
            ax2.Interval = 200;
            ax2.Minimum = 0;

            ay2.Minimum = -50;
            ay2.Interval = 10;
            ay2.Maximum = 50;


            ax2.MajorGrid.LineColor = Color.LightGray;
            ay2.MajorGrid.LineColor = Color.LightGray;

            ax2.Title = "[変位[um]]";
            ay2.Title = "[残差[nm]]";

            chart2.Series.Add("リニアリティ");
            chart2.Series["リニアリティ"].ChartType = SeriesChartType.Line;

            start_num = 100;
            end_num = 1900;
/*
            int k = 0;
            for (int i = 0; i < 2000; i++)
            {
                k_henni[k] = henni[i];
                k_henni2[k] = henni2[i];
                k++;
            }
            sai12(end_num-start_num, k_henni, k_henni2);
            //sai1(k_henni2, k_henni);
            textBox2.Text = saisho_a.ToString("0.00");
            textBox3.Text = saisho_b.ToString("0.00");

            double ld = 0;
            for (int i = start_num; i < end_num - 1; i++)
            {
                ld = k_henni[i];
                double kaiki = saisho_a * ld + saisho_b;
                double zansa = (k_henni2[i] - kaiki) * 1000;

                chart2.Series["リニアリティ"].Points.AddXY(i, zansa);
            }
           chart2.Series.Add("除荷");
            chart2.Series["除荷"].ChartType = SeriesChartType.Line;

            k = 0;
            for (int i = start_num; i < end_num; i++)
            {
                Load_data4[k] = Load_data3[i];
                disp_data4[k] = disp_data3[i];
                k++;
            }
            sai12(Load_data4, disp_data4);

            ld = 0;
            for (int i = 0; i < end_num - start_num - 1; i++)
            {
                ld = Load_data4[i];
                double kaiki = saisho_a2 * ld + saisho_b2;
                double zansa = (disp_data4[i] - kaiki) * 1000;
                chart2.Series["除荷"].Points.AddXY(kaiki, zansa);
            }

            */
            //string s,s2;
            // s = saisho_a.ToString();
            // s2 = saisho_b.ToString();
            // MessageBox.Show(s +"+"+ s2);

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int bb;
            bb = ad_out;
            bb &= 0x0F;
            ad_out = (byte)bb;

            ana.adOutDO(ana.hDevice, ad_out);

            zstep = 0;
            //objThread.bContinue = false;
           // ana.adOutDO(ana.hDevice, 0x05);
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ana.daOutDO(ana.hDA, 0x01);
            int bb;
            bb = ad_out;
            bb |= 0x20;

            ad_out = (byte)bb;
            ana.adOutDO(ana.hDevice, ad_out);

            zstep = -1;
            //objThread = new threadClass(new deleDraw(t6_sub));

            //objThread.gCount = 0;
            //pcount = 0;
            //objThread.bContinue = true;

            //th4 = new Thread(new ThreadStart(objThread.wThread));

            //th4.Start();
        }
    
        private void button5_Click(object sender, EventArgs e)
        {
            int bb;
            bb = ad_out;
            bb |= 0x00;
            zstep = 1;

            ana.adOutDO(ana.hDevice, (byte)bb);
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
  OpenFileDialog ofd = new OpenFileDialog();

            ofd.FileName = "default.csv";

            ofd.InitialDirectory = @"C:\Users\ENT_setubi\Documents\sarada\Data";

            ofd.Filter = "csvファイル|*.csv";

            ofd.FilterIndex = 2;

            ofd.Title = "開くファイルを選択してください";

            ofd.RestoreDirectory = true;

            ofd.CheckFileExists = true;

            ofd.CheckPathExists = true;
            
            //chart2.Series.Clear();
            //chart2.Series.Add("0");

            //chart2.Series["0"].ChartType = SeriesChartType.Line;

            iSamplingNum = 3000;

            henni2 = new double[iSamplingNum + 11];
            pvolt2 = new double[iSamplingNum + 11];

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream stream;

                stream = ofd.OpenFile();
    
               // gCount = 0;
               // max_tmp = 20; 
                //chart1.Legends.Clear();

            
                if (stream != null)
                {
                    series_num++;

                   // s1[series_num].LegendText = Path.GetFileName(ofd.FileName);

                    file_name[series_num] = Path.GetFileName(ofd.FileName);
                    chart2.Series.Add(file_name[series_num]);

                   // s1[series_num].ChartType = SeriesChartType.Line;
                    chart2.Series[file_name[series_num]].ChartType = SeriesChartType.Line;

                    //chart1.Series.Add(s1[series_num]);
                  
                   // checkedListBox1.Items.Add(ofd.FileName);

                    Axis ax = chart2.ChartAreas[0].AxisX;
                    Axis ay = chart2.ChartAreas[0].AxisY;

                    ax.MajorGrid.LineColor = Color.LightGray;
                    ax.Maximum = 130.0;
                    ax.Interval = 6.0;
                    ax.Minimum = -15;
                    ay.Maximum = 18000;
                    ay.Interval = 1000;
                    ay.Minimum = -1000;


                    ax.Title = "[電圧(V)]";
                    ay.Title = "[変位(nm)]";

                    System.IO.StreamReader sr = new System.IO.StreamReader(stream);
                    int ct = 0;

                    double pre_time = 0.0;

                    try
                    {
                        while (sr.EndOfStream == false)
                        {

                            string line = sr.ReadLine();
                            string[] fields = line.Split(',');

                            pvolt2[ct] = double.Parse(fields[0]);
                            henni2[ct]      = double.Parse(fields[1]);


                           /* if (aho[ct] > max_tmp)
                                max_tmp = aho[ct];

                            if (aho_time[ct] > 50)
                            {
                                ax.Maximum = aho_time[ct]; ;
                            }
                            
                            if (aho[ct] > max_tmp)
                                ay.Maximum = 10 * Math.Ceiling(aho[ct] / 10);
                            else
                                ay.Maximum = 10 * Math.Ceiling(max_tmp / 10);

                            */
                           
                            //s1[series_num].Points.AddXY(aho_time[ct], aho[ct]);

                            if (ct > 0)
                            {
                               
                                 chart2.Series[file_name[series_num]].Points.AddXY(pvolt2[ct], henni2[ct]);

                               
                            }

                         
                            ct++;
                        }
                    }
                    finally
                    {
                        sr.Close();
                    }
                    stream.Close();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ana.daOutDO(ana.hDA, 0x03);//laser_off
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ana.adOutDO(ana.hDevice, 0x05);
        }

        private void button7_Click(object sender, EventArgs e)
        {
          
        }

      


    }
}
/*                for (int i = 0; i < 1024; i++)
                {
                    szTemp = System.String.Format("{0:d4}: {1:f4}", (i + 1), ((ushort[])pAd)[i]);
                    listBox1.Items.Add(szTemp);
                } */
