using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace CS_TickTackToe
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblNote;
		private System.Windows.Forms.PictureBox pic00;
		private System.Windows.Forms.PictureBox picO;
		private System.Windows.Forms.PictureBox pic01;
		private System.Windows.Forms.PictureBox pic02;
		private System.Windows.Forms.PictureBox picX;
		private System.Windows.Forms.PictureBox pic10;
		private System.Windows.Forms.PictureBox pic11;
		private System.Windows.Forms.PictureBox pic12;
		private System.Windows.Forms.PictureBox pic22;
		private System.Windows.Forms.PictureBox pic21;
		private System.Windows.Forms.PictureBox pic20;
		private System.Windows.Forms.StatusBar sbGameStatus;
		private System.Windows.Forms.StatusBarPanel sbpCurrentPlayer;
		private System.Windows.Forms.StatusBarPanel sbpScore;
		private System.Windows.Forms.MainMenu mnuMain;
		private System.Windows.Forms.MenuItem mnuFile;
		private System.Windows.Forms.MenuItem mnuDifficulty;
		private System.Windows.Forms.MenuItem mnuChkEasy;
		private System.Windows.Forms.MenuItem mnuChkMedium;
		private System.Windows.Forms.MenuItem mnuChkHard;
		private System.Windows.Forms.MenuItem mnuSeperator1;
		private System.Windows.Forms.MenuItem mnuExit;
		private System.Windows.Forms.MenuItem mnuHelp;
		private System.Windows.Forms.MenuItem mnuAbout;
		private System.Windows.Forms.MenuItem mnuNewGame;
        private System.Windows.Forms.StatusBarPanel sbpDifficulty;
        private IContainer components;

		public frmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.pic00 = new System.Windows.Forms.PictureBox();
            this.picO = new System.Windows.Forms.PictureBox();
            this.pic01 = new System.Windows.Forms.PictureBox();
            this.pic02 = new System.Windows.Forms.PictureBox();
            this.picX = new System.Windows.Forms.PictureBox();
            this.pic10 = new System.Windows.Forms.PictureBox();
            this.pic11 = new System.Windows.Forms.PictureBox();
            this.pic12 = new System.Windows.Forms.PictureBox();
            this.pic22 = new System.Windows.Forms.PictureBox();
            this.pic21 = new System.Windows.Forms.PictureBox();
            this.pic20 = new System.Windows.Forms.PictureBox();
            this.sbGameStatus = new System.Windows.Forms.StatusBar();
            this.sbpCurrentPlayer = new System.Windows.Forms.StatusBarPanel();
            this.sbpScore = new System.Windows.Forms.StatusBarPanel();
            this.sbpDifficulty = new System.Windows.Forms.StatusBarPanel();
            this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.mnuNewGame = new System.Windows.Forms.MenuItem();
            this.mnuSeperator1 = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.mnuDifficulty = new System.Windows.Forms.MenuItem();
            this.mnuChkEasy = new System.Windows.Forms.MenuItem();
            this.mnuChkMedium = new System.Windows.Forms.MenuItem();
            this.mnuChkHard = new System.Windows.Forms.MenuItem();
            this.mnuHelp = new System.Windows.Forms.MenuItem();
            this.mnuAbout = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pic00)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpCurrentPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpDifficulty)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(8, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(272, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Tic-Tac-Toe";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(160, 48);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(106, 13);
            this.lblNote.TabIndex = 1;
            this.lblNote.Text = "Single-Player Version";
            // 
            // pic00
            // 
            this.pic00.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic00.Location = new System.Drawing.Point(16, 72);
            this.pic00.Name = "pic00";
            this.pic00.Size = new System.Drawing.Size(62, 62);
            this.pic00.TabIndex = 2;
            this.pic00.TabStop = false;
            // 
            // picO
            // 
            this.picO.Image = ((System.Drawing.Image)(resources.GetObject("picO.Image")));
            this.picO.Location = new System.Drawing.Point(-32, 72);
            this.picO.Name = "picO";
            this.picO.Size = new System.Drawing.Size(60, 60);
            this.picO.TabIndex = 3;
            this.picO.TabStop = false;
            this.picO.Visible = false;
            // 
            // pic01
            // 
            this.pic01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic01.Location = new System.Drawing.Point(115, 72);
            this.pic01.Name = "pic01";
            this.pic01.Size = new System.Drawing.Size(62, 62);
            this.pic01.TabIndex = 4;
            this.pic01.TabStop = false;
            // 
            // pic02
            // 
            this.pic02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic02.Location = new System.Drawing.Point(216, 72);
            this.pic02.Name = "pic02";
            this.pic02.Size = new System.Drawing.Size(62, 62);
            this.pic02.TabIndex = 5;
            this.pic02.TabStop = false;
            // 
            // picX
            // 
            this.picX.Image = ((System.Drawing.Image)(resources.GetObject("picX.Image")));
            this.picX.Location = new System.Drawing.Point(-32, 120);
            this.picX.Name = "picX";
            this.picX.Size = new System.Drawing.Size(60, 60);
            this.picX.TabIndex = 6;
            this.picX.TabStop = false;
            this.picX.Visible = false;
            // 
            // pic10
            // 
            this.pic10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic10.Location = new System.Drawing.Point(16, 144);
            this.pic10.Name = "pic10";
            this.pic10.Size = new System.Drawing.Size(62, 62);
            this.pic10.TabIndex = 7;
            this.pic10.TabStop = false;
            // 
            // pic11
            // 
            this.pic11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic11.Location = new System.Drawing.Point(115, 144);
            this.pic11.Name = "pic11";
            this.pic11.Size = new System.Drawing.Size(62, 62);
            this.pic11.TabIndex = 8;
            this.pic11.TabStop = false;
            // 
            // pic12
            // 
            this.pic12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic12.Location = new System.Drawing.Point(216, 144);
            this.pic12.Name = "pic12";
            this.pic12.Size = new System.Drawing.Size(62, 62);
            this.pic12.TabIndex = 9;
            this.pic12.TabStop = false;
            // 
            // pic22
            // 
            this.pic22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic22.Location = new System.Drawing.Point(216, 216);
            this.pic22.Name = "pic22";
            this.pic22.Size = new System.Drawing.Size(62, 62);
            this.pic22.TabIndex = 12;
            this.pic22.TabStop = false;
            // 
            // pic21
            // 
            this.pic21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic21.Location = new System.Drawing.Point(115, 216);
            this.pic21.Name = "pic21";
            this.pic21.Size = new System.Drawing.Size(62, 62);
            this.pic21.TabIndex = 11;
            this.pic21.TabStop = false;
            // 
            // pic20
            // 
            this.pic20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic20.Location = new System.Drawing.Point(16, 216);
            this.pic20.Name = "pic20";
            this.pic20.Size = new System.Drawing.Size(62, 62);
            this.pic20.TabIndex = 10;
            this.pic20.TabStop = false;
            // 
            // sbGameStatus
            // 
            this.sbGameStatus.Location = new System.Drawing.Point(0, 289);
            this.sbGameStatus.Name = "sbGameStatus";
            this.sbGameStatus.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.sbpCurrentPlayer,
            this.sbpScore,
            this.sbpDifficulty});
            this.sbGameStatus.Size = new System.Drawing.Size(290, 21);
            this.sbGameStatus.TabIndex = 13;
            // 
            // sbpCurrentPlayer
            // 
            this.sbpCurrentPlayer.Name = "sbpCurrentPlayer";
            this.sbpCurrentPlayer.Text = "Your Move";
            // 
            // sbpScore
            // 
            this.sbpScore.Name = "sbpScore";
            this.sbpScore.Text = "You: 0 Computer: 0";
            this.sbpScore.Width = 120;
            // 
            // sbpDifficulty
            // 
            this.sbpDifficulty.Name = "sbpDifficulty";
            this.sbpDifficulty.Text = "Easy";
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFile,
            this.mnuDifficulty,
            this.mnuHelp});
            // 
            // mnuFile
            // 
            this.mnuFile.Index = 0;
            this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuNewGame,
            this.mnuSeperator1,
            this.mnuExit});
            this.mnuFile.Text = "&File";
            // 
            // mnuNewGame
            // 
            this.mnuNewGame.Index = 0;
            this.mnuNewGame.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
            this.mnuNewGame.Text = "&New Game";
            this.mnuNewGame.Click += new System.EventHandler(this.mnuNewGame_Click);
            // 
            // mnuSeperator1
            // 
            this.mnuSeperator1.Index = 1;
            this.mnuSeperator1.Text = "-";
            // 
            // mnuExit
            // 
            this.mnuExit.Index = 2;
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuDifficulty
            // 
            this.mnuDifficulty.Index = 1;
            this.mnuDifficulty.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuChkEasy,
            this.mnuChkMedium,
            this.mnuChkHard});
            this.mnuDifficulty.Text = "Difficulty";
            // 
            // mnuChkEasy
            // 
            this.mnuChkEasy.Checked = true;
            this.mnuChkEasy.Index = 0;
            this.mnuChkEasy.RadioCheck = true;
            this.mnuChkEasy.Text = "Easy";
            this.mnuChkEasy.Click += new System.EventHandler(this.mnuChkEasy_Click);
            // 
            // mnuChkMedium
            // 
            this.mnuChkMedium.Index = 1;
            this.mnuChkMedium.RadioCheck = true;
            this.mnuChkMedium.Text = "Medium";
            this.mnuChkMedium.Click += new System.EventHandler(this.mnuChkEasy_Click);
            // 
            // mnuChkHard
            // 
            this.mnuChkHard.Index = 2;
            this.mnuChkHard.RadioCheck = true;
            this.mnuChkHard.Text = "Hard";
            this.mnuChkHard.Click += new System.EventHandler(this.mnuChkEasy_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.Index = 2;
            this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuAbout});
            this.mnuHelp.Text = "&Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Index = 0;
            this.mnuAbout.Text = "&About...";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(290, 310);
            this.Controls.Add(this.sbGameStatus);
            this.Controls.Add(this.pic22);
            this.Controls.Add(this.pic21);
            this.Controls.Add(this.pic20);
            this.Controls.Add(this.pic12);
            this.Controls.Add(this.pic11);
            this.Controls.Add(this.pic10);
            this.Controls.Add(this.picX);
            this.Controls.Add(this.pic02);
            this.Controls.Add(this.pic01);
            this.Controls.Add(this.picO);
            this.Controls.Add(this.pic00);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Menu = this.mnuMain;
            this.Name = "frmMain";
            this.Text = "Tic-Tac-Toe";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic00)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpCurrentPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpDifficulty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		private clsPictureCollection picHolders;
		private clsGameplay clsGame;
		
		[DllImport("user32.dll")]
		private static extern short GetAsyncKeyState(int vKey);

		private void frmMain_Load(object sender, System.EventArgs e)
		{
			sbGameStatus.ShowPanels = true;	

			clsGame = new clsGameplay(picO);
			picHolders = new clsPictureCollection(this, clsGame, picX);
			picHolders.sbStatus = sbGameStatus;
			//Add the pictures to the collection
			for (int i = 0; i <= 2; i++)
			{
				for (int ii = 0; ii <= 2; ii++)
				{
					for (int x = 0; x < this.Controls.Count; x++)
					{
						if (this.Controls[x].Name.Equals("pic" + i.ToString() + ii.ToString()))
						{
							picHolders.AddPicture((PictureBox) this.Controls[x]);
						}
					}//End for
				}//End for
			}//End for
			//Start a new game
			clsGame.clsPicCol = picHolders;
			clsGame.NewGame();
		}

		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void mnuAbout_Click(object sender, System.EventArgs e)
		{
			frmAbout fAbout = new frmAbout();
			fAbout.ShowDialog();
		}

		private void mnuChkEasy_Click(object sender, System.EventArgs e)
		{
			//All of the difficulty menu items use this event
			//No, a switch would not work here do to the fact
			//that switchs only work with strings and intergers
			//and we are using objects!
			if (sender == mnuChkEasy)
			{
				mnuChkMedium.Checked = false;
				mnuChkHard.Checked = false;
				mnuChkEasy.Checked = true;
                clsGame.GameDifficulty = clsGameplay.EGameDifficulty.E_EASY;
				sbpDifficulty.Text = "Easy";
			}
			else if (sender == mnuChkMedium)
			{
				mnuChkEasy.Checked = false;
				mnuChkHard.Checked = false;
				mnuChkMedium.Checked = true;
                clsGame.GameDifficulty = clsGameplay.EGameDifficulty.E_MEDIUM;
				sbpDifficulty.Text = "Medium";
			}
			else if (sender == mnuChkHard)
			{
				mnuChkEasy.Checked = false;
				mnuChkMedium.Checked = false;
				mnuChkHard.Checked = true;
                clsGame.GameDifficulty = clsGameplay.EGameDifficulty.E_HARD;
				sbpDifficulty.Text = "Hard";
			}
		}

		private void mnuNewGame_Click(object sender, System.EventArgs e)
		{
			clsGame.NewGame();
			picHolders.intCompScore = 0;
			picHolders.intHumanScore = 0;
			sbGameStatus.Panels[1].Text = "You: " + picHolders.intHumanScore.ToString()
				+ " Computer: " + picHolders.intCompScore.ToString();
		}
	}//End class
}//End Namespace
