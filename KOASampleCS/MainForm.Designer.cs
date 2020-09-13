namespace KOASampleCS
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.기본기능ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.로그인ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.로그아웃ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.접속상태ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.계좌조회ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.조회기능ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.시간외주문ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.axKHOpenAPI = new AxKHOpenAPILib.AxKHOpenAPI();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.API_LOG = new System.Windows.Forms.TabPage();
			this.lst일반 = new System.Windows.Forms.ListBox();
			this.REAL_TIME_LOG = new System.Windows.Forms.TabPage();
			this.lst실시간 = new System.Windows.Forms.ListBox();
			this.ERROR = new System.Windows.Forms.TabPage();
			this.lst에러 = new System.Windows.Forms.ListBox();
			this.QUERY = new System.Windows.Forms.TabPage();
			this.lst조회 = new System.Windows.Forms.ListBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbo계좌 = new System.Windows.Forms.ComboBox();
			this.menuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.API_LOG.SuspendLayout();
			this.REAL_TIME_LOG.SuspendLayout();
			this.ERROR.SuspendLayout();
			this.QUERY.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.기본기능ToolStripMenuItem,
            this.조회기능ToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
			this.menuStrip.Size = new System.Drawing.Size(1277, 35);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip";
			// 
			// 기본기능ToolStripMenuItem
			// 
			this.기본기능ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.로그인ToolStripMenuItem,
            this.로그아웃ToolStripMenuItem,
            this.접속상태ToolStripMenuItem,
            this.계좌조회ToolStripMenuItem,
            this.종료ToolStripMenuItem});
			this.기본기능ToolStripMenuItem.Name = "기본기능ToolStripMenuItem";
			this.기본기능ToolStripMenuItem.Size = new System.Drawing.Size(96, 29);
			this.기본기능ToolStripMenuItem.Text = "기본기능";
			// 
			// 로그인ToolStripMenuItem
			// 
			this.로그인ToolStripMenuItem.Name = "로그인ToolStripMenuItem";
			this.로그인ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
			this.로그인ToolStripMenuItem.Text = "로그인";
			this.로그인ToolStripMenuItem.Click += new System.EventHandler(this.로그인ToolStripMenuItem_Click);
			// 
			// 로그아웃ToolStripMenuItem
			// 
			this.로그아웃ToolStripMenuItem.Name = "로그아웃ToolStripMenuItem";
			this.로그아웃ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
			this.로그아웃ToolStripMenuItem.Text = "로그아웃";
			this.로그아웃ToolStripMenuItem.Click += new System.EventHandler(this.로그아웃ToolStripMenuItem_Click);
			// 
			// 접속상태ToolStripMenuItem
			// 
			this.접속상태ToolStripMenuItem.Name = "접속상태ToolStripMenuItem";
			this.접속상태ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
			this.접속상태ToolStripMenuItem.Text = "접속상태";
			this.접속상태ToolStripMenuItem.Click += new System.EventHandler(this.접속상태ToolStripMenuItem_Click);
			// 
			// 계좌조회ToolStripMenuItem
			// 
			this.계좌조회ToolStripMenuItem.Name = "계좌조회ToolStripMenuItem";
			this.계좌조회ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
			this.계좌조회ToolStripMenuItem.Text = "계좌조회";
			this.계좌조회ToolStripMenuItem.Click += new System.EventHandler(this.계좌조회ToolStripMenuItem_Click);
			// 
			// 종료ToolStripMenuItem
			// 
			this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
			this.종료ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
			this.종료ToolStripMenuItem.Text = "종료";
			this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
			// 
			// 조회기능ToolStripMenuItem
			// 
			this.조회기능ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.시간외주문ToolStripMenuItem});
			this.조회기능ToolStripMenuItem.Name = "조회기능ToolStripMenuItem";
			this.조회기능ToolStripMenuItem.Size = new System.Drawing.Size(60, 29);
			this.조회기능ToolStripMenuItem.Text = "주문";
			// 
			// 시간외주문ToolStripMenuItem
			// 
			this.시간외주문ToolStripMenuItem.Name = "시간외주문ToolStripMenuItem";
			this.시간외주문ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
			this.시간외주문ToolStripMenuItem.Text = "시간외주문";
			this.시간외주문ToolStripMenuItem.Click += new System.EventHandler(this.시간외주문ToolStripMenuItem_Click);
			// 
			// axKHOpenAPI
			// 
			ReceiveManager receiveManager = CoreManager.Instance.receiveManager;
			this.axKHOpenAPI.Enabled = true;
			this.axKHOpenAPI.Location = new System.Drawing.Point(7, 593);
			this.axKHOpenAPI.Margin = new System.Windows.Forms.Padding(4);
			this.axKHOpenAPI.Name = "axKHOpenAPI";
			this.axKHOpenAPI.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI.OcxState")));
			this.axKHOpenAPI.Size = new System.Drawing.Size(96, 29);
			this.axKHOpenAPI.TabIndex = 11;
			this.axKHOpenAPI.OnReceiveTrData += new AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEventHandler(receiveManager.OnReceiveTrData);
			this.axKHOpenAPI.OnReceiveRealData += new AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEventHandler(receiveManager.OnReceiveRealData);
			this.axKHOpenAPI.OnReceiveMsg += new AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveMsgEventHandler(receiveManager.OnReceiveMsg);
			this.axKHOpenAPI.OnReceiveChejanData += new AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveChejanDataEventHandler(receiveManager.OnReceiveChejanData);
			this.axKHOpenAPI.OnEventConnect += new AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEventHandler(this.axKHOpenAPI_OnEventConnect);
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.API_LOG);
			this.tabControl1.Controls.Add(this.REAL_TIME_LOG);
			this.tabControl1.Controls.Add(this.ERROR);
			this.tabControl1.Controls.Add(this.QUERY);
			this.tabControl1.Location = new System.Drawing.Point(10, 648);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1250, 212);
			this.tabControl1.TabIndex = 24;
			// 
			// API_LOG
			// 
			this.API_LOG.Controls.Add(this.lst일반);
			this.API_LOG.Location = new System.Drawing.Point(4, 28);
			this.API_LOG.Margin = new System.Windows.Forms.Padding(4);
			this.API_LOG.Name = "API_LOG";
			this.API_LOG.Padding = new System.Windows.Forms.Padding(4);
			this.API_LOG.Size = new System.Drawing.Size(1242, 180);
			this.API_LOG.TabIndex = 0;
			this.API_LOG.Text = "API 로그";
			this.API_LOG.UseVisualStyleBackColor = true;
			// 
			// lst일반
			// 
			this.lst일반.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lst일반.FormattingEnabled = true;
			this.lst일반.HorizontalScrollbar = true;
			this.lst일반.ItemHeight = 18;
			this.lst일반.Location = new System.Drawing.Point(4, 4);
			this.lst일반.Margin = new System.Windows.Forms.Padding(4);
			this.lst일반.Name = "lst일반";
			this.lst일반.Size = new System.Drawing.Size(1234, 172);
			this.lst일반.TabIndex = 4;
			// 
			// REAL_TIME_LOG
			// 
			this.REAL_TIME_LOG.Controls.Add(this.lst실시간);
			this.REAL_TIME_LOG.Location = new System.Drawing.Point(4, 28);
			this.REAL_TIME_LOG.Margin = new System.Windows.Forms.Padding(4);
			this.REAL_TIME_LOG.Name = "REAL_TIME_LOG";
			this.REAL_TIME_LOG.Padding = new System.Windows.Forms.Padding(4);
			this.REAL_TIME_LOG.Size = new System.Drawing.Size(1242, 180);
			this.REAL_TIME_LOG.TabIndex = 1;
			this.REAL_TIME_LOG.Text = "실시간";
			this.REAL_TIME_LOG.UseVisualStyleBackColor = true;
			// 
			// lst실시간
			// 
			this.lst실시간.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lst실시간.FormattingEnabled = true;
			this.lst실시간.HorizontalScrollbar = true;
			this.lst실시간.ItemHeight = 18;
			this.lst실시간.Location = new System.Drawing.Point(4, 4);
			this.lst실시간.Margin = new System.Windows.Forms.Padding(4);
			this.lst실시간.Name = "lst실시간";
			this.lst실시간.Size = new System.Drawing.Size(1234, 172);
			this.lst실시간.TabIndex = 3;
			// 
			// ERROR
			// 
			this.ERROR.Controls.Add(this.lst에러);
			this.ERROR.Location = new System.Drawing.Point(4, 28);
			this.ERROR.Margin = new System.Windows.Forms.Padding(4);
			this.ERROR.Name = "ERROR";
			this.ERROR.Size = new System.Drawing.Size(1242, 180);
			this.ERROR.TabIndex = 2;
			this.ERROR.Text = "애러";
			this.ERROR.UseVisualStyleBackColor = true;
			// 
			// lst에러
			// 
			this.lst에러.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lst에러.FormattingEnabled = true;
			this.lst에러.HorizontalScrollbar = true;
			this.lst에러.ItemHeight = 18;
			this.lst에러.Location = new System.Drawing.Point(0, 0);
			this.lst에러.Margin = new System.Windows.Forms.Padding(4);
			this.lst에러.Name = "lst에러";
			this.lst에러.Size = new System.Drawing.Size(1242, 180);
			this.lst에러.TabIndex = 6;
			// 
			// QUERY
			// 
			this.QUERY.Controls.Add(this.lst조회);
			this.QUERY.Location = new System.Drawing.Point(4, 28);
			this.QUERY.Margin = new System.Windows.Forms.Padding(4);
			this.QUERY.Name = "QUERY";
			this.QUERY.Size = new System.Drawing.Size(1242, 180);
			this.QUERY.TabIndex = 3;
			this.QUERY.Text = "조회";
			this.QUERY.UseVisualStyleBackColor = true;
			// 
			// lst조회
			// 
			this.lst조회.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lst조회.FormattingEnabled = true;
			this.lst조회.HorizontalScrollbar = true;
			this.lst조회.ItemHeight = 18;
			this.lst조회.Location = new System.Drawing.Point(0, 0);
			this.lst조회.Margin = new System.Windows.Forms.Padding(4);
			this.lst조회.Name = "lst조회";
			this.lst조회.Size = new System.Drawing.Size(1242, 180);
			this.lst조회.TabIndex = 5;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.cbo계좌);
			this.groupBox2.Location = new System.Drawing.Point(20, 39);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox2.Size = new System.Drawing.Size(1240, 87);
			this.groupBox2.TabIndex = 25;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "계좌정보";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 34);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(98, 18);
			this.label3.TabIndex = 25;
			this.label3.Text = "계좌번호 : ";
			// 
			// cbo계좌
			// 
			this.cbo계좌.FormattingEnabled = true;
			this.cbo계좌.Location = new System.Drawing.Point(111, 30);
			this.cbo계좌.Margin = new System.Windows.Forms.Padding(4);
			this.cbo계좌.Name = "cbo계좌";
			this.cbo계좌.Size = new System.Drawing.Size(171, 26);
			this.cbo계좌.TabIndex = 24;
			this.cbo계좌.SelectedIndexChanged += new System.EventHandler(this.cbo계좌_SelectedIndexChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1277, 921);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.axKHOpenAPI);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.Text = "장전 시간외 주문기";
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.API_LOG.ResumeLayout(false);
			this.REAL_TIME_LOG.ResumeLayout(false);
			this.ERROR.ResumeLayout(false);
			this.QUERY.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 기본기능ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 로그인ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 로그아웃ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 접속상태ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 계좌조회ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 조회기능ToolStripMenuItem;
		private AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage API_LOG;
        private System.Windows.Forms.ListBox lst일반;
        private System.Windows.Forms.TabPage REAL_TIME_LOG;
        private System.Windows.Forms.ListBox lst실시간;
        private System.Windows.Forms.TabPage ERROR;
        private System.Windows.Forms.ListBox lst에러;
        private System.Windows.Forms.TabPage QUERY;
        private System.Windows.Forms.ListBox lst조회;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbo계좌;
		private System.Windows.Forms.ToolStripMenuItem 시간외주문ToolStripMenuItem;
    }
}

