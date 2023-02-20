namespace LEDSerialPortServer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openSerialPortBtn = new System.Windows.Forms.Button();
            this.parityComboBx = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.stopBitscomboBx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataBitsComboBx = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.baudRateCombx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.serialPortCombx = new System.Windows.Forms.ComboBox();
            this.serialPortText = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.acceptEncodingCheckBx = new System.Windows.Forms.CheckBox();
            this.TongCheckBx = new System.Windows.Forms.CheckBox();
            this.accpteSendCheckBx = new System.Windows.Forms.CheckBox();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sendEncodingCheckBx = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.addSendCheckBx = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sendASCIIradioBtn = new System.Windows.Forms.RadioButton();
            this.sendAutoTextBx = new System.Windows.Forms.TextBox();
            this.send16ReadioBtn = new System.Windows.Forms.RadioButton();
            this.autoSendCheckBx = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.acceptBytelab = new System.Windows.Forms.Label();
            this.sendBytelab = new System.Windows.Forms.Label();
            this.sendBtn = new System.Windows.Forms.Button();
            this.statusLab = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.accpetTextBox = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.openSerialPortBtn);
            this.panel1.Controls.Add(this.parityComboBx);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.stopBitscomboBx);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dataBitsComboBx);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.baudRateCombx);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.serialPortCombx);
            this.panel1.Controls.Add(this.serialPortText);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 256);
            this.panel1.TabIndex = 0;
            // 
            // openSerialPortBtn
            // 
            this.openSerialPortBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.openSerialPortBtn.Location = new System.Drawing.Point(21, 210);
            this.openSerialPortBtn.Name = "openSerialPortBtn";
            this.openSerialPortBtn.Size = new System.Drawing.Size(164, 34);
            this.openSerialPortBtn.TabIndex = 12;
            this.openSerialPortBtn.Text = "打开串口";
            this.openSerialPortBtn.UseVisualStyleBackColor = true;
            this.openSerialPortBtn.Click += new System.EventHandler(this.openSerialPortBtn_Click);
            // 
            // parityComboBx
            // 
            this.parityComboBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parityComboBx.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.parityComboBx.FormattingEnabled = true;
            this.parityComboBx.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Space",
            "Mark"});
            this.parityComboBx.Location = new System.Drawing.Point(63, 168);
            this.parityComboBx.Name = "parityComboBx";
            this.parityComboBx.Size = new System.Drawing.Size(121, 29);
            this.parityComboBx.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(0, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "校验位";
            // 
            // stopBitscomboBx
            // 
            this.stopBitscomboBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stopBitscomboBx.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stopBitscomboBx.FormattingEnabled = true;
            this.stopBitscomboBx.Items.AddRange(new object[] {
            "One",
            "Two",
            "OnePointFive"});
            this.stopBitscomboBx.Location = new System.Drawing.Point(63, 129);
            this.stopBitscomboBx.Name = "stopBitscomboBx";
            this.stopBitscomboBx.Size = new System.Drawing.Size(121, 29);
            this.stopBitscomboBx.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(0, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "停止位";
            // 
            // dataBitsComboBx
            // 
            this.dataBitsComboBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataBitsComboBx.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dataBitsComboBx.FormattingEnabled = true;
            this.dataBitsComboBx.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.dataBitsComboBx.Location = new System.Drawing.Point(64, 90);
            this.dataBitsComboBx.Name = "dataBitsComboBx";
            this.dataBitsComboBx.Size = new System.Drawing.Size(121, 29);
            this.dataBitsComboBx.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "数据位";
            // 
            // baudRateCombx
            // 
            this.baudRateCombx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudRateCombx.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.baudRateCombx.FormattingEnabled = true;
            this.baudRateCombx.Items.AddRange(new object[] {
            "Custom",
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200",
            "128000",
            "230400",
            "256000",
            "460800",
            "500000",
            "512000",
            "600000",
            "750000",
            "921600",
            "1000000",
            "1500000",
            "2000000"});
            this.baudRateCombx.Location = new System.Drawing.Point(64, 47);
            this.baudRateCombx.Name = "baudRateCombx";
            this.baudRateCombx.Size = new System.Drawing.Size(121, 29);
            this.baudRateCombx.TabIndex = 3;
            this.baudRateCombx.SelectedIndexChanged += new System.EventHandler(this.baudRateCombx_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(4, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "波特率";
            // 
            // serialPortCombx
            // 
            this.serialPortCombx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serialPortCombx.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.serialPortCombx.FormattingEnabled = true;
            this.serialPortCombx.Location = new System.Drawing.Point(65, 9);
            this.serialPortCombx.Name = "serialPortCombx";
            this.serialPortCombx.Size = new System.Drawing.Size(120, 29);
            this.serialPortCombx.TabIndex = 1;
            // 
            // serialPortText
            // 
            this.serialPortText.AutoSize = true;
            this.serialPortText.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.serialPortText.Location = new System.Drawing.Point(4, 10);
            this.serialPortText.Name = "serialPortText";
            this.serialPortText.Size = new System.Drawing.Size(57, 21);
            this.serialPortText.TabIndex = 0;
            this.serialPortText.Text = "串   口";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(1, 253);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(202, 122);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.acceptEncodingCheckBx);
            this.groupBox1.Controls.Add(this.TongCheckBx);
            this.groupBox1.Controls.Add(this.accpteSendCheckBx);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(0, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 122);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "接受";
            // 
            // acceptEncodingCheckBx
            // 
            this.acceptEncodingCheckBx.AutoSize = true;
            this.acceptEncodingCheckBx.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.acceptEncodingCheckBx.Location = new System.Drawing.Point(13, 92);
            this.acceptEncodingCheckBx.Name = "acceptEncodingCheckBx";
            this.acceptEncodingCheckBx.Size = new System.Drawing.Size(119, 25);
            this.acceptEncodingCheckBx.TabIndex = 8;
            this.acceptEncodingCheckBx.Text = "启用GB2312";
            this.acceptEncodingCheckBx.UseVisualStyleBackColor = true;
            // 
            // TongCheckBx
            // 
            this.TongCheckBx.AutoSize = true;
            this.TongCheckBx.Checked = true;
            this.TongCheckBx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TongCheckBx.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TongCheckBx.Location = new System.Drawing.Point(13, 61);
            this.TongCheckBx.Name = "TongCheckBx";
            this.TongCheckBx.Size = new System.Drawing.Size(157, 25);
            this.TongCheckBx.TabIndex = 7;
            this.TongCheckBx.Text = "自动响应指定命令";
            this.TongCheckBx.UseVisualStyleBackColor = true;
            // 
            // accpteSendCheckBx
            // 
            this.accpteSendCheckBx.AutoSize = true;
            this.accpteSendCheckBx.Checked = true;
            this.accpteSendCheckBx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.accpteSendCheckBx.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.accpteSendCheckBx.Location = new System.Drawing.Point(13, 29);
            this.accpteSendCheckBx.Name = "accpteSendCheckBx";
            this.accpteSendCheckBx.Size = new System.Drawing.Size(93, 25);
            this.accpteSendCheckBx.TabIndex = 6;
            this.accpteSendCheckBx.Text = "换行显示";
            this.accpteSendCheckBx.UseVisualStyleBackColor = true;
            // 
            // acceptBtn
            // 
            this.acceptBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.acceptBtn.ForeColor = System.Drawing.Color.Red;
            this.acceptBtn.Location = new System.Drawing.Point(701, 3);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(103, 37);
            this.acceptBtn.TabIndex = 3;
            this.acceptBtn.Text = "清   空";
            this.acceptBtn.UseVisualStyleBackColor = true;
            this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Location = new System.Drawing.Point(1, 376);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(202, 150);
            this.panel3.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sendEncodingCheckBx);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.addSendCheckBx);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.sendASCIIradioBtn);
            this.groupBox2.Controls.Add(this.sendAutoTextBx);
            this.groupBox2.Controls.Add(this.send16ReadioBtn);
            this.groupBox2.Controls.Add(this.autoSendCheckBx);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(-1, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(198, 145);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送";
            // 
            // sendEncodingCheckBx
            // 
            this.sendEncodingCheckBx.AutoSize = true;
            this.sendEncodingCheckBx.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sendEncodingCheckBx.Location = new System.Drawing.Point(7, 83);
            this.sendEncodingCheckBx.Name = "sendEncodingCheckBx";
            this.sendEncodingCheckBx.Size = new System.Drawing.Size(119, 25);
            this.sendEncodingCheckBx.TabIndex = 13;
            this.sendEncodingCheckBx.Text = "启用GB2312";
            this.sendEncodingCheckBx.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(144, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 21);
            this.label6.TabIndex = 12;
            this.label6.Text = "帮助";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // addSendCheckBx
            // 
            this.addSendCheckBx.AutoSize = true;
            this.addSendCheckBx.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addSendCheckBx.Location = new System.Drawing.Point(7, 114);
            this.addSendCheckBx.Name = "addSendCheckBx";
            this.addSendCheckBx.Size = new System.Drawing.Size(109, 25);
            this.addSendCheckBx.TabIndex = 11;
            this.addSendCheckBx.Text = "加回车换行";
            this.addSendCheckBx.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(135, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "ms/次";
            // 
            // sendASCIIradioBtn
            // 
            this.sendASCIIradioBtn.AutoSize = true;
            this.sendASCIIradioBtn.Checked = true;
            this.sendASCIIradioBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sendASCIIradioBtn.Location = new System.Drawing.Point(9, 22);
            this.sendASCIIradioBtn.Name = "sendASCIIradioBtn";
            this.sendASCIIradioBtn.Size = new System.Drawing.Size(69, 25);
            this.sendASCIIradioBtn.TabIndex = 2;
            this.sendASCIIradioBtn.TabStop = true;
            this.sendASCIIradioBtn.Text = "ASCII";
            this.sendASCIIradioBtn.UseVisualStyleBackColor = true;
            // 
            // sendAutoTextBx
            // 
            this.sendAutoTextBx.Location = new System.Drawing.Point(64, 49);
            this.sendAutoTextBx.Name = "sendAutoTextBx";
            this.sendAutoTextBx.Size = new System.Drawing.Size(66, 28);
            this.sendAutoTextBx.TabIndex = 9;
            this.sendAutoTextBx.Text = "1000";
            // 
            // send16ReadioBtn
            // 
            this.send16ReadioBtn.AutoSize = true;
            this.send16ReadioBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.send16ReadioBtn.Location = new System.Drawing.Point(111, 22);
            this.send16ReadioBtn.Name = "send16ReadioBtn";
            this.send16ReadioBtn.Size = new System.Drawing.Size(57, 25);
            this.send16ReadioBtn.TabIndex = 8;
            this.send16ReadioBtn.Text = "Hex";
            this.send16ReadioBtn.UseVisualStyleBackColor = true;
            // 
            // autoSendCheckBx
            // 
            this.autoSendCheckBx.AutoSize = true;
            this.autoSendCheckBx.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.autoSendCheckBx.Location = new System.Drawing.Point(6, 52);
            this.autoSendCheckBx.Name = "autoSendCheckBx";
            this.autoSendCheckBx.Size = new System.Drawing.Size(61, 25);
            this.autoSendCheckBx.TabIndex = 5;
            this.autoSendCheckBx.Text = "自动";
            this.autoSendCheckBx.UseVisualStyleBackColor = true;
            this.autoSendCheckBx.CheckedChanged += new System.EventHandler(this.autoSendCheckBx_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.acceptBytelab);
            this.panel4.Controls.Add(this.sendBytelab);
            this.panel4.Controls.Add(this.acceptBtn);
            this.panel4.Controls.Add(this.sendBtn);
            this.panel4.Controls.Add(this.statusLab);
            this.panel4.Location = new System.Drawing.Point(1, 529);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(917, 46);
            this.panel4.TabIndex = 3;
            // 
            // acceptBytelab
            // 
            this.acceptBytelab.AutoSize = true;
            this.acceptBytelab.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.acceptBytelab.Location = new System.Drawing.Point(479, 12);
            this.acceptBytelab.Name = "acceptBytelab";
            this.acceptBytelab.Size = new System.Drawing.Size(107, 21);
            this.acceptBytelab.TabIndex = 3;
            this.acceptBytelab.Text = "接受：0Bytes";
            // 
            // sendBytelab
            // 
            this.sendBytelab.AutoSize = true;
            this.sendBytelab.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sendBytelab.Location = new System.Drawing.Point(262, 11);
            this.sendBytelab.Name = "sendBytelab";
            this.sendBytelab.Size = new System.Drawing.Size(107, 21);
            this.sendBytelab.TabIndex = 2;
            this.sendBytelab.Text = "发送：0Bytes";
            // 
            // sendBtn
            // 
            this.sendBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sendBtn.ForeColor = System.Drawing.Color.Green;
            this.sendBtn.Location = new System.Drawing.Point(810, 3);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(95, 36);
            this.sendBtn.TabIndex = 1;
            this.sendBtn.Text = "发   送";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // statusLab
            // 
            this.statusLab.AutoSize = true;
            this.statusLab.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusLab.Location = new System.Drawing.Point(19, 8);
            this.statusLab.Name = "statusLab";
            this.statusLab.Size = new System.Drawing.Size(58, 21);
            this.statusLab.TabIndex = 0;
            this.statusLab.Text = "未连接";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.accpetTextBox);
            this.panel5.Location = new System.Drawing.Point(203, 1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(715, 395);
            this.panel5.TabIndex = 4;
            // 
            // accpetTextBox
            // 
            this.accpetTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.accpetTextBox.Location = new System.Drawing.Point(-2, -2);
            this.accpetTextBox.Multiline = true;
            this.accpetTextBox.Name = "accpetTextBox";
            this.accpetTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.accpetTextBox.Size = new System.Drawing.Size(715, 395);
            this.accpetTextBox.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.sendTextBox);
            this.panel6.Location = new System.Drawing.Point(203, 393);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(715, 133);
            this.panel6.TabIndex = 5;
            // 
            // sendTextBox
            // 
            this.sendTextBox.Location = new System.Drawing.Point(-2, -2);
            this.sendTextBox.Multiline = true;
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sendTextBox.Size = new System.Drawing.Size(715, 135);
            this.sendTextBox.TabIndex = 0;
            this.sendTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sendTextBox_KeyDown);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 578);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LED串口软件";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Label serialPortText;
        private ComboBox serialPortCombx;
        private Button openSerialPortBtn;
        private ComboBox parityComboBx;
        private Label label4;
        private ComboBox stopBitscomboBx;
        private Label label3;
        private ComboBox dataBitsComboBx;
        private Label label2;
        private ComboBox baudRateCombx;
        private Label label1;
        private Button acceptBtn;
        private CheckBox autoSendCheckBx;
        private RadioButton sendASCIIradioBtn;
        private Label statusLab;
        private TextBox accpetTextBox;
        private Button sendBtn;
        private TextBox sendTextBox;
        private Label acceptBytelab;
        private Label sendBytelab;
        private RadioButton send16ReadioBtn;
        private Label label5;
        private TextBox sendAutoTextBx;
        private System.Windows.Forms.Timer timer1;
        private GroupBox groupBox1;
        private CheckBox accpteSendCheckBx;
        private GroupBox groupBox2;
        private CheckBox addSendCheckBx;
        private Label label6;
        private CheckBox TongCheckBx;
        private CheckBox acceptEncodingCheckBx;
        private CheckBox sendEncodingCheckBx;
    }
}