namespace ClientOne2One
{
	partial class ClientForm1
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
			this.listView1 = new System.Windows.Forms.ListView();
			this.EndPoint = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.LastMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.LastRecvTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EndPoint,
            this.ID,
            this.LastMessage,
            this.LastRecvTime});
			this.listView1.Location = new System.Drawing.Point(12, 12);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(618, 332);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// EndPoint
			// 
			this.EndPoint.Text = "EndPoint";
			this.EndPoint.Width = 150;
			// 
			// ID
			// 
			this.ID.Text = "ID";
			this.ID.Width = 149;
			// 
			// LastMessage
			// 
			this.LastMessage.Text = "LastMessage";
			this.LastMessage.Width = 148;
			// 
			// LastRecvTime
			// 
			this.LastRecvTime.Text = "LastRecvTime";
			this.LastRecvTime.Width = 167;
			// 
			// ClientForm1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(642, 368);
			this.Controls.Add(this.listView1);
			this.Name = "ClientForm1";
			this.Text = "ClientForm1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader EndPoint;
		private System.Windows.Forms.ColumnHeader ID;
		private System.Windows.Forms.ColumnHeader LastMessage;
		private System.Windows.Forms.ColumnHeader LastRecvTime;
	}
}