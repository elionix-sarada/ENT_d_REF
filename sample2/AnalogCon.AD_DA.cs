using System;

using System.Runtime.InteropServices;

using InterfaceCorpDllWrap;


namespace AnalogCon
{
	public class AD_DA
	{
		public IFCAD.ADSMPLREQ gConfig, gConfig2;		// Sampling request condition structure
		public IFCAD.ADBOARDSPEC gInfo, gInfo2;					// Device information structure
		public IFCDA.DASMPLREQ DaSmplConfig;

		public IFCDA_ANY.DASMPLREQ gDAConfig;				// Sampling request condition structure
		public IFCDA_ANY.DABOARDSPEC gDAInfo;					// Device information structure

		public IFCAD.ADSMPLCHREQ[] AD_SmplChInf;
		public IFCDA_ANY.DASMPLCHREQ[] DA_SmplChInf;

//		 [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
//		private static extern IntPtr CreateEvent(IntPtr security, bool isManualReset,
//											  bool initialState, string name);

		public IntPtr hDA,hDA2;
		public Object pAd, pAd2;			// Area to store sampled data

		uint[]  hEVENT;

		public uint hDevice, hDevice2;
      

		int gnErrCode;

        // interop 
        private IntPtr _Handle;
        private bool _ManualReset;
        private bool _InitialState;
        private string _EventName;

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateEvent(IntPtr lpEventAttributes, bool bManualReset, bool bInitialState, string lpName);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        static extern bool ResetEvent(IntPtr hEvent);

        [DllImport("kernel32.dll")]
        internal static extern Int32 WaitForSingleObject(IntPtr handle, Int32 milliseconds);


		public AD_DA()
		{
			
		}
		~AD_DA()
        {
           Dispose();
        }

		public void Dispose()
		{
			//if (myBuffer != null)
			//{
				//myBuffer.Dispose();
				//myBuffer = null;
			//}
			//_Control.Paint -= new System.Windows.Forms.PaintEventHandler(this.Paint);
		}
		public void init_adc2()
		{
			
            /*
			hDevice2 = IFCAD.AdOpen("FBIAD2");

			if (hDevice2 == IFCAD.INVALID_HANDLE_VALUE)
			{
				//MessageBox.Show("正しい値を入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				IFCAD.AdClose(hDevice2);
			}
			//initialize struct
			gConfig2.InitializeArray();
			// Retrieves sampling conditions on the board.

			int nRet = IFCAD.AdGetSamplingConfig(hDevice2, out gConfig2);
			if (nRet != 0)
			{
				IFCAD.AdClose(hDevice2);
				//MessageBox.Show("GetSamplingError", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			// Retrieves specifications of the board.
			nRet = IFCAD.AdGetDeviceInfo(hDevice2, out gInfo2);
			if (nRet != 0)
			{
				IFCAD.AdClose(hDevice2);
				//MessageBox.Show("GetDeviceError", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			gConfig2.ulSmplNum = 1024;

            gConfig2.ulSmplEventNum = 0;;

            gConfig2.ulSingleDiff = IFCAD.AD_INPUT_DIFF;
			gConfig2.fSmplFreq = 100000.0f;

			gConfig2.ulTrigDI = 0;
			gConfig2.ulFastMode = IFCAD.AD_NORMAL_MODE;		// AD_NORMAL_MODE: Normal mode (default setting) 

			gConfig2.SetChNo(0, 1);

			gConfig2.ulChCount = 1;

			// Configures sampling conditions of the board.
			gnErrCode = IFCAD.AdSetSamplingConfig(hDevice2, ref gConfig2);
			if (gnErrCode != 0)
			{
				//MessageBox.Show("SetSamplingConfig", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
        
           */

        
		}
		public void init_dac()
		{
            int nRet;         

 	    	hDA = IFCDA_ANY.DaOpen("FBIDA2");

			if (hDevice.Equals(new IntPtr(-1)))
			{
				//MessageBox.Show("fail!!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				IFCDA_ANY.DaClose(hDA);
			}
			gDAConfig.InitializeArray();

			// Retrieves sampling conditions on the board.
			nRet = IFCDA_ANY.DaGetSamplingConfig(hDA, out gDAConfig);
			if (nRet != 0)
			{
				IFCDA_ANY.DaClose(hDA);
				// DaSmplForm.DsplyErrMessage(nRet);
				return;
			}

			// Retrieves specifications of the board.
			nRet = IFCDA_ANY.DaGetDeviceInfo(hDA, out gDAInfo);
			if (nRet != 0)
			{
				IFCDA_ANY.DaClose(hDA);
				//DaSmplForm.DsplyErrMessage(nRet);
				return;
			}

          
		}
		public void init_adc()
		{
           // _Handle = CreateEvent(IntPtr.Zero, _ManualReset, _InitialState, _EventName);
            _Handle = CreateEvent(IntPtr.Zero, true, false, null);

			hDevice = IFCAD.AdOpen("FBIAD1");

        
			hEVENT = new uint[2];
			string s = "aho";

		//	hEVENT[0] = CreateEvent(0, false, false, ref s);

		//	gnErrCode = IFCAD.AdSetBoardConfig(hDevice, hEVENT[0], null, 0);
		//	hEVENT[1] = CreateEvent(0, false, false, null);
		//	gnErrCode = IFCAD.AdSetBoardConfig(hDevice2, hEVENT[1], null, 0);

			if (gnErrCode != 0)
			{
				IFCAD.AdClose(hEVENT[0]);
				//str.Format(_T("AdSetBoardConfig error= ( %lx )"), gnErrCode);
				//AfxMessageBox(str);
			}

			if (hDevice == IFCAD.INVALID_HANDLE_VALUE)
			{
				//MessageBox.Show("正しい値を入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				IFCAD.AdClose(hDevice);
			}
			//initialize struct
			gConfig.InitializeArray();
			// Retrieves sampling conditions on the board.

			int nRet = IFCAD.AdGetSamplingConfig(hDevice, out gConfig);
			if (nRet != 0)
			{
				IFCAD.AdClose(hDevice);
				//MessageBox.Show("GetSamplingError", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			// Retrieves specifications of the board.
			nRet = IFCAD.AdGetDeviceInfo(hDevice, out gInfo);
			if (nRet != 0)
			{
				IFCAD.AdClose(hDevice);
				//MessageBox.Show("GetDeviceError", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
            gConfig.ulSmplNum = 1024;
			
			gConfig.ulSmplEventNum = 0;
			//    SmplChInf[0].ulChNo = 2;
			//    SmplChInf[0].ulRange = IFCAD.AD_10V;


			gConfig.fSmplFreq = 0.0f;
			gConfig.ulTrigPoint = IFCAD.AD_TRIG_START;	// AD_TRIG_START: Start-trigger (default setting) 
			gConfig.ulTrigMode = IFCAD.AD_EXTTRG;

		
		

			gConfig.ulSingleDiff = IFCAD.AD_INPUT_DIFF;
			gConfig.ulTrigEdge = IFCAD.AD_DOWN_EDGE;			// AD_DOWN_EDGE: Falling edge (default setting) 

			gConfig.ulTrigDI = 0;
			gConfig.ulFastMode = IFCAD.AD_NORMAL_MODE;		// AD_NORMAL_MODE: Normal mode (default setting) 

			gConfig.SetChNo(0, 2);

			gConfig.ulChCount = 1;

			// Configures sampling conditions of the board.
			gnErrCode = IFCAD.AdSetSamplingConfig(hDevice, ref gConfig);
			if (gnErrCode != 0)
			{
				//MessageBox.Show("SetSamplingConfig", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}
      
		public void adOutDO(uint h, uint d)
		{
			IFCAD.AdOutputDO( h, d );
		}
        public void daOutDO(IntPtr h, uint d)
        {
            IFCDA_ANY.DaOutputDO(h, d);
        }
        public void daOutDA(IntPtr h, double d,double ld)
        {
            ////////////////
            uint[] ghChannel = new uint[2];
            IFCDA_ANY.DASMPLCHREQ[] SmplChInf = new IFCDA_ANY.DASMPLCHREQ[2];
            ushort[] wData = new ushort[2];
            uint ulCh;
            int gnErrCode = -1;

         

            SmplChInf[0].ulChNo = 1;
            SmplChInf[0].ulRange = gDAConfig.GetChRange(0);
            SmplChInf[1].ulChNo = 2;
            SmplChInf[1].ulRange = gDAConfig.GetChRange(0);

            // Configure the output data.
            
            //d : 0～120 [volt]
            //DA : 32803～0(0～-10V)
            double da = 32767.0 - (32767/120)* d;// (129.5723 - d) / 0.00395;
            //double da = (32767 / 120) * d;
            double v = ld / 1800;
            double da2 = 32767 + (32767 * v / 10);


            wData[0] = (ushort)da;
            wData[1] = (ushort)da2;

            ulCh = 2;

/*            if (ghChannel[1] == 0)
            {
                ulCh = 1;
            }
            else
            {
                ulCh = 2;
                SmplChInf[1].ulChNo = ghChannel[1];
                SmplChInf[1].ulRange = gConfig.GetChRange(0);
                wData[1] = 0;
            }
*/
            // Output one analog data on the board.
            gnErrCode = IFCDA_ANY.DaOutputDA(h, ulCh, SmplChInf, wData);
           
            ////////////////
           // IFCDA_ANY.DaOutputDA(h, 1,ref DA_SmplChInf[0], ref d);
        }

        public void daOutDA2(IntPtr h, uint d)
        {
            ////////////////
            uint[] ghChannel = new uint[2];
            IFCDA_ANY.DASMPLCHREQ[] SmplChInf = new IFCDA_ANY.DASMPLCHREQ[2];
            uint[] wData = new uint[2];
            uint ulCh;
            int gnErrCode = -1;



            SmplChInf[0].ulChNo = 2;
            SmplChInf[0].ulRange = gDAConfig.GetChRange(0);
            SmplChInf[1].ulChNo = 2;
            SmplChInf[1].ulRange = gDAConfig.GetChRange(0);

            // Configure the output data.
            wData[0] = d;
            wData[1] = d;

            ulCh = 1;

          
            gnErrCode = IFCDA_ANY.DaOutputDA(h, ulCh, SmplChInf, wData);

            ////////////////
            // IFCDA_ANY.DaOutputDA(h, 1,ref DA_SmplChInf[0], ref d);
        }
		public int ad_sampling(uint h1)
		{
	        uint dwlength = 1024;
           //uint dwlength = 512;

			gnErrCode = IFCAD.AdStartSampling(h1, IFCAD.FLAG_SYNC);
			if (gnErrCode != 0)
			{
				//MessageBox.Show("AdStartSampling", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return 0;
			}
			//IFCAD.AdOutputDO(h1, 0x00);

			gnErrCode = IFCAD.AdGetSamplingData(h1, (ushort[])pAd, ref dwlength);
            return 1;
		}
        public void ad_sampling2(uint h1, uint h2)
        {
            uint dwlength = 1024;

            IFCAD.AdSetBoardConfig(h2, (uint)(_Handle), null, 0);

            gnErrCode = IFCAD.AdStartSampling(h2, IFCAD.FLAG_ASYNC);
           // gnErrCode = IFCAD.AdStartSampling(h1, IFCAD.FLAG_ASYNC);
            if (gnErrCode != 0)
            {
                //MessageBox.Show("AdStartSampling", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            WaitForSingleObject(_Handle, 100000);
            ResetEvent(_Handle);

            IFCAD.AdOutputDO(h2, 0x00);
            //IFCAD.AdOutputDO(h2, 0x00);

            gnErrCode = IFCAD.AdGetSamplingData(h2, (ushort[])pAd, ref dwlength);
           // gnErrCode = IFCAD.AdGetSamplingData(h1, (ushort[])pAd2, ref dwlength);

        }
        public void ad_sampling3(uint h1, uint h2)
        {
            uint dwlength = 1024;

            IFCAD.AdSetBoardConfig(h2, (uint)(_Handle), null, 0);

            gnErrCode = IFCAD.AdStartSampling(h2, IFCAD.FLAG_ASYNC);
            gnErrCode = IFCAD.AdStartSampling(h1, IFCAD.FLAG_ASYNC);
            if (gnErrCode != 0)
            {
                //MessageBox.Show("AdStartSampling", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            WaitForSingleObject(_Handle, 100000);
            ResetEvent(_Handle);

            IFCAD.AdOutputDO(h2, 0x10);
            //IFCAD.AdOutputDO(h2, 0x00);

            gnErrCode = IFCAD.AdGetSamplingData(h2, (ushort[])pAd, ref dwlength);
            gnErrCode = IFCAD.AdGetSamplingData(h1, (ushort[])pAd2, ref dwlength);

        }
		public void start_sampling(uint h1)
		{
			gnErrCode = IFCAD.AdStartSampling(h1, IFCAD.FLAG_SYNC);
			if (gnErrCode != 0)
			{
				//MessageBox.Show("AdStartSampling", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}
		
		public void get_data1(uint h)
		{
			uint dwlength = 1024;

			gnErrCode = IFCAD.AdGetSamplingData(h, (ushort[])pAd, ref dwlength);
		}
		public void get_data2(uint h)
		{
			uint dwlength = 1024;

			gnErrCode = IFCAD.AdGetSamplingData(h, (ushort[])pAd2, ref dwlength);
		}
		public void close()
		{
			IFCAD.AdOutputDO(hDevice, 0x08);
			IFCAD.AdClose(hDevice);
			IFCAD.AdClose(hDevice2);
		}
	}
}