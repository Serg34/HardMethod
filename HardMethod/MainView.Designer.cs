namespace HardMethod
{
	partial class MainView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
			this.btsDayOfWeek = new DevExpress.XtraEditors.RadioGroup();
			this.timeEdit = new DevExpress.XtraEditors.TimeEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
			this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
			this.txtKey = new DevExpress.XtraEditors.TextEdit();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.lbLog = new DevExpress.XtraEditors.LabelControl();
			this.lbAnswer = new DevExpress.XtraEditors.LabelControl();
			this.txtFreeOperatorsCount = new DevExpress.XtraEditors.TextEdit();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			((System.ComponentModel.ISupportInitialize)(this.btsDayOfWeek.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timeEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
			this.tablePanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFreeOperatorsCount.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// btsDayOfWeek
			// 
			this.tablePanel1.SetColumn(this.btsDayOfWeek, 0);
			this.tablePanel1.SetColumnSpan(this.btsDayOfWeek, 2);
			this.btsDayOfWeek.Dock = System.Windows.Forms.DockStyle.Top;
			this.btsDayOfWeek.Location = new System.Drawing.Point(2, 25);
			this.btsDayOfWeek.Margin = new System.Windows.Forms.Padding(2);
			this.btsDayOfWeek.Name = "btsDayOfWeek";
			this.btsDayOfWeek.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Понедельник"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Вторник"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Среда"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Четверг"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Пятница"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Суббота"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Воскресение")});
			this.tablePanel1.SetRow(this.btsDayOfWeek, 1);
			this.btsDayOfWeek.Size = new System.Drawing.Size(580, 114);
			this.btsDayOfWeek.TabIndex = 0;
			this.btsDayOfWeek.SelectedIndexChanged += new System.EventHandler(this.BtsDayOfWeek_SelectedIndexChanged);
			// 
			// timeEdit
			// 
			this.tablePanel1.SetColumn(this.timeEdit, 1);
			this.timeEdit.EditValue = new System.DateTime(2019, 10, 12, 0, 0, 0, 0);
			this.timeEdit.Location = new System.Drawing.Point(286, 144);
			this.timeEdit.Name = "timeEdit";
			this.timeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.tablePanel1.SetRow(this.timeEdit, 2);
			this.timeEdit.Size = new System.Drawing.Size(295, 24);
			this.timeEdit.TabIndex = 1;
			this.timeEdit.EditValueChanged += new System.EventHandler(this.TimeEdit_EditValueChanged);
			// 
			// labelControl1
			// 
			this.tablePanel1.SetColumn(this.labelControl1, 0);
			this.labelControl1.Location = new System.Drawing.Point(3, 3);
			this.labelControl1.Name = "labelControl1";
			this.tablePanel1.SetRow(this.labelControl1, 0);
			this.labelControl1.Size = new System.Drawing.Size(136, 17);
			this.labelControl1.TabIndex = 3;
			this.labelControl1.Text = "Выберите день недели";
			// 
			// tablePanel1
			// 
			this.tablePanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 5F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F)});
			this.tablePanel1.Controls.Add(this.labelControl5);
			this.tablePanel1.Controls.Add(this.txtKey);
			this.tablePanel1.Controls.Add(this.labelControl4);
			this.tablePanel1.Controls.Add(this.lbLog);
			this.tablePanel1.Controls.Add(this.lbAnswer);
			this.tablePanel1.Controls.Add(this.txtFreeOperatorsCount);
			this.tablePanel1.Controls.Add(this.labelControl3);
			this.tablePanel1.Controls.Add(this.labelControl2);
			this.tablePanel1.Controls.Add(this.btsDayOfWeek);
			this.tablePanel1.Controls.Add(this.labelControl1);
			this.tablePanel1.Controls.Add(this.timeEdit);
			this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tablePanel1.Location = new System.Drawing.Point(0, 0);
			this.tablePanel1.Name = "tablePanel1";
			this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 5F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 26F)});
			this.tablePanel1.Size = new System.Drawing.Size(584, 557);
			this.tablePanel1.TabIndex = 4;
			// 
			// labelControl5
			// 
			this.labelControl5.Appearance.BackColor = System.Drawing.Color.DimGray;
			this.labelControl5.Appearance.Options.UseBackColor = true;
			this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.tablePanel1.SetColumn(this.labelControl5, 0);
			this.tablePanel1.SetColumnSpan(this.labelControl5, 2);
			this.labelControl5.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelControl5.Location = new System.Drawing.Point(0, 254);
			this.labelControl5.Margin = new System.Windows.Forms.Padding(0);
			this.labelControl5.Name = "labelControl5";
			this.tablePanel1.SetRow(this.labelControl5, 6);
			this.labelControl5.Size = new System.Drawing.Size(584, 1);
			this.labelControl5.TabIndex = 12;
			// 
			// txtKey
			// 
			this.tablePanel1.SetColumn(this.txtKey, 1);
			this.txtKey.Location = new System.Drawing.Point(286, 204);
			this.txtKey.Name = "txtKey";
			this.txtKey.Properties.Mask.EditMask = "n0";
			this.txtKey.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.tablePanel1.SetRow(this.txtKey, 4);
			this.txtKey.Size = new System.Drawing.Size(295, 24);
			this.txtKey.TabIndex = 11;
			this.txtKey.EditValueChanged += new System.EventHandler(this.TxtKey_EditValueChanged);
			// 
			// labelControl4
			// 
			this.tablePanel1.SetColumn(this.labelControl4, 0);
			this.labelControl4.Location = new System.Drawing.Point(3, 204);
			this.labelControl4.Name = "labelControl4";
			this.tablePanel1.SetRow(this.labelControl4, 4);
			this.labelControl4.Size = new System.Drawing.Size(108, 17);
			this.labelControl4.TabIndex = 10;
			this.labelControl4.Text = "Нажмите клавишу";
			// 
			// lbLog
			// 
			this.tablePanel1.SetColumn(this.lbLog, 0);
			this.tablePanel1.SetColumnSpan(this.lbLog, 2);
			this.lbLog.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbLog.Location = new System.Drawing.Point(3, 262);
			this.lbLog.Name = "lbLog";
			this.tablePanel1.SetRow(this.lbLog, 7);
			this.lbLog.Size = new System.Drawing.Size(22, 17);
			this.lbLog.TabIndex = 9;
			this.lbLog.Text = "Лог";
			// 
			// lbAnswer
			// 
			this.tablePanel1.SetColumn(this.lbAnswer, 0);
			this.tablePanel1.SetColumnSpan(this.lbAnswer, 2);
			this.lbAnswer.Location = new System.Drawing.Point(3, 234);
			this.lbAnswer.Name = "lbAnswer";
			this.tablePanel1.SetRow(this.lbAnswer, 5);
			this.lbAnswer.Size = new System.Drawing.Size(35, 17);
			this.lbAnswer.TabIndex = 7;
			this.lbAnswer.Text = "Ответ";
			// 
			// txtFreeOperatorsCount
			// 
			this.tablePanel1.SetColumn(this.txtFreeOperatorsCount, 1);
			this.txtFreeOperatorsCount.Location = new System.Drawing.Point(286, 174);
			this.txtFreeOperatorsCount.Name = "txtFreeOperatorsCount";
			this.txtFreeOperatorsCount.Properties.Mask.EditMask = "n0";
			this.txtFreeOperatorsCount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.tablePanel1.SetRow(this.txtFreeOperatorsCount, 3);
			this.txtFreeOperatorsCount.Size = new System.Drawing.Size(295, 24);
			this.txtFreeOperatorsCount.TabIndex = 6;
			this.txtFreeOperatorsCount.EditValueChanged += new System.EventHandler(this.TxtFreeOperatorsCount_EditValueChanged);
			// 
			// labelControl3
			// 
			this.tablePanel1.SetColumn(this.labelControl3, 0);
			this.labelControl3.Location = new System.Drawing.Point(3, 174);
			this.labelControl3.Name = "labelControl3";
			this.tablePanel1.SetRow(this.labelControl3, 3);
			this.labelControl3.Size = new System.Drawing.Size(277, 17);
			this.labelControl3.TabIndex = 5;
			this.labelControl3.Text = "Выберите количество свободных операторов";
			// 
			// labelControl2
			// 
			this.tablePanel1.SetColumn(this.labelControl2, 0);
			this.labelControl2.Location = new System.Drawing.Point(3, 144);
			this.labelControl2.Name = "labelControl2";
			this.tablePanel1.SetRow(this.labelControl2, 2);
			this.labelControl2.Size = new System.Drawing.Size(100, 17);
			this.labelControl2.TabIndex = 4;
			this.labelControl2.Text = "Выберите время";
			// 
			// MainView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 557);
			this.Controls.Add(this.tablePanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "MainView";
			this.Text = "MainView";
			((System.ComponentModel.ISupportInitialize)(this.btsDayOfWeek.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timeEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
			this.tablePanel1.ResumeLayout(false);
			this.tablePanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFreeOperatorsCount.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.RadioGroup btsDayOfWeek;
		private DevExpress.XtraEditors.TimeEdit timeEdit;
		private DevExpress.Utils.Layout.TablePanel tablePanel1;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.TextEdit txtFreeOperatorsCount;
		private DevExpress.XtraEditors.LabelControl lbLog;
		private DevExpress.XtraEditors.LabelControl lbAnswer;
		private DevExpress.XtraEditors.TextEdit txtKey;
		private DevExpress.XtraEditors.LabelControl labelControl4;
		private DevExpress.XtraEditors.LabelControl labelControl5;
	}
}