using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CS_TickTackToe
{
	/// <summary>
	/// Summary description for frmAbout.
	/// </summary>
	public class frmAbout : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblTicTacToe;
		private System.Windows.Forms.Label lblBy;
		private System.Windows.Forms.LinkLabel llHexsoft;
		private System.Windows.Forms.Button btnOk;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmAbout()
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
				if(components != null)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAbout));
			this.lblTicTacToe = new System.Windows.Forms.Label();
			this.lblBy = new System.Windows.Forms.Label();
			this.llHexsoft = new System.Windows.Forms.LinkLabel();
			this.btnOk = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblTicTacToe
			// 
			this.lblTicTacToe.AutoSize = true;
			this.lblTicTacToe.Location = new System.Drawing.Point(40, 24);
			this.lblTicTacToe.Name = "lblTicTacToe";
			this.lblTicTacToe.Size = new System.Drawing.Size(90, 16);
			this.lblTicTacToe.TabIndex = 0;
			this.lblTicTacToe.Text = "Tic-Tac-Toe v1.0";
			// 
			// lblBy
			// 
			this.lblBy.AutoSize = true;
			this.lblBy.Location = new System.Drawing.Point(40, 56);
			this.lblBy.Name = "lblBy";
			this.lblBy.Size = new System.Drawing.Size(80, 16);
			this.lblBy.TabIndex = 1;
			this.lblBy.Text = "By Max_Power";
			// 
			// llHexsoft
			// 
			this.llHexsoft.AutoSize = true;
			this.llHexsoft.Location = new System.Drawing.Point(40, 88);
			this.llHexsoft.Name = "llHexsoft";
			this.llHexsoft.Size = new System.Drawing.Size(146, 16);
			this.llHexsoft.TabIndex = 2;
			this.llHexsoft.TabStop = true;
			this.llHexsoft.Text = "http://hexsoft.gifgraphix.com";
			this.llHexsoft.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llHexsoft_LinkClicked);
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(208, 120);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(72, 24);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "&OK";
			// 
			// frmAbout
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 156);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.llHexsoft);
			this.Controls.Add(this.lblBy);
			this.Controls.Add(this.lblTicTacToe);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmAbout";
			this.ShowInTaskbar = false;
			this.Text = "About Tic-Tac-Toe";
			this.ResumeLayout(false);

		}
		#endregion

		private void llHexsoft_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			llHexsoft.LinkVisited = true;
			System.Diagnostics.Process.Start("http://hexsoft.gifgraphix.com");
		}
	}
}
