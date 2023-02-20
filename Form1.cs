using LEDSerialPort;
using LEDSerialPort.Utils;
using System;
using System.Drawing.Imaging;
using System.IO.Ports;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace LEDSerialPortServer
{
    public partial class Form1 : Form
    {
        // 串口打开状态
        private static bool openStatus = false;
        private readonly ISerialPortDataAdapter serialPortDataAdapter = new SerialPortDataAdapter();
        //声明CancellationTokenSource对象
        static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();
            //注入GB2312编码
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            string strReturn = "";//  存储转换后的编码
            //foreach (short shortx in strEncode.ToCharArray())
            //{
            //    strReturn += shortx.ToString("X4");
            //}
            string hex = "f801";
            string SS = hex.HexToChineseStr();
            InitAllSerialPort();
        }

        /// <summary>
        /// 初始化所有的串口
        /// </summary>
        /// <returns></returns>
        private void InitAllSerialPort()
        {
            string[] list = serialPortDataAdapter.GetAllSerialPort();
            serialPortCombx.Items.AddRange(list);
            serialPortCombx.SelectedIndex = -1;
        }


        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openSerialPortBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.parityComboBx.Text.IsNull() || this.baudRateCombx.Text.IsNull() || this.serialPortCombx.Text.IsNull()
                    || this.dataBitsComboBx.Text.IsNull() || this.stopBitscomboBx.Text.IsNull())
                {
                    MessageBox.Show("请先选择串口连接参数");
                    return;
                }

                if (!openStatus)
                {
                    var options = new SerialPortDataAdapterOptions
                    {
                        PortName = this.serialPortCombx.Text,
                        BaudRate = this.baudRateCombx.Text.ToInt(), //波特率
                        Parity = this.parityComboBx.Text.GetEnumValue<Parity>(), //校验位
                        DataBits = this.dataBitsComboBx.Text.ToInt(), //数据位
                        StopBits = this.stopBitscomboBx.Text.GetEnumValue<StopBits>() //数据位
                    };
                    serialPortDataAdapter.Config(options);
                    serialPortDataAdapter.Open();
                    openStatus = true;

                    //开启独立接受消息线程
                    cancelTokenSource = new CancellationTokenSource();
                    Task.Run(() => Read(cancelTokenSource.Token));

                    serialPortDataAdapter.ReceiveCount += result =>
                    {
                        this.Invoke((EventHandler)(delegate
                        {
                            acceptBytelab.Text = $"接受：{result}Bytes";
                        }));

                    };
                    serialPortDataAdapter.SendCount += result =>
                    {
                        this.Invoke((EventHandler)(delegate
                        {
                            sendBytelab.Text = $"发送：{result}Bytes";

                        }));

                    };

                    this.openSerialPortBtn.Text = "关闭串口";
                    this.statusLab.Text = "已连接：" + this.serialPortCombx.Text;
                    this.statusLab.ForeColor = System.Drawing.Color.Green;
                    this.openSerialPortBtn.ForeColor = System.Drawing.Color.Green;
                    this.parityComboBx.Enabled = false;
                    this.baudRateCombx.Enabled = false;
                    this.serialPortCombx.Enabled = false;
                    this.dataBitsComboBx.Enabled = false;
                    this.stopBitscomboBx.Enabled = false;
                    accpetTextBox.Text = "";  //清空接收区
                    sendTextBox.Text = "";     //清空发送区
                }
                else
                {
                    serialPortDataAdapter.Close();
                    this.openSerialPortBtn.Text = "打开串口";
                    this.statusLab.Text = "未连接";
                    openStatus = false;
                    cancelTokenSource.Cancel();
                    this.statusLab.ForeColor = System.Drawing.Color.Black;
                    this.openSerialPortBtn.ForeColor = System.Drawing.Color.Black;
                    this.parityComboBx.Enabled = true;
                    this.baudRateCombx.Enabled = true;
                    this.serialPortCombx.Enabled = true;
                    this.dataBitsComboBx.Enabled = true;
                    this.stopBitscomboBx.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                //响铃并显示异常给用户
                System.Media.SystemSounds.Beep.Play();
                this.parityComboBx.Enabled = true;
                this.baudRateCombx.Enabled = true;
                this.serialPortCombx.Enabled = true;
                this.dataBitsComboBx.Enabled = true;
                this.stopBitscomboBx.Enabled = true;
                this.openSerialPortBtn.Text = "打开串口";
                this.statusLab.Text = "未连接";
                openStatus = false;
                cancelTokenSource.Cancel();
                this.statusLab.ForeColor = System.Drawing.Color.Black;
                this.openSerialPortBtn.ForeColor = System.Drawing.Color.Black;
                serialPortDataAdapter.Close();
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 接受消息
        /// </summary>
        /// <param name="cancelToken"></param>
        private void Read(CancellationToken cancelToken)
        {
            while (!cancelToken.IsCancellationRequested)
            {
                try
                {
                    var message = serialPortDataAdapter.TryPullMessage();
                    if (message != null)
                    {
                        string accpteText = string.Empty;
                        if (this.acceptEncodingCheckBx.Checked)
                             accpteText = Encoding.GetEncoding("GB2312").GetString(message);
                        else
                            accpteText = Encoding.ASCII.GetString(message);
                        string[] accpteTextArray = accpteText.Split(" ");
                        //响应回复
                        string tongText = string.Empty;
                        if (accpteTextArray.Count() >= 3)
                        {
                            //默认大于等于3表示初步满足基础指令要求：头（1字节）+地址码（1字节）+指令码（1字节）+高位长度+低位长度+内容+异或截止
                            //指令判断是否响应
                            if (accpteTextArray[2].IsExistInstructions() && accpteTextArray[0] == LEDProtocol.PingPrefix)
                            {
                                //响应0x 00=成功，0x01=失败
                                tongText = $"{LEDProtocol.TongPrefix} {accpteTextArray[1]} {accpteTextArray[2].HexAddOperation()} 00 01 00";
                            }
                        }
                        accpteText = $"【{DateTime.Now.ToString("HH:dd:mm.fff")}】收到←{accpteText}";
                        //是否勾选回车换行
                        if (this.accpteSendCheckBx.Checked)
                        {
                            accpteText = $"{accpteText}\r\n";
                        }
                        //因为要访问UI资源，所以需要使用invoke方式同步ui
                        this.Invoke((EventHandler)(delegate
                        {
                            accpetTextBox.AppendText(accpteText);
                        }));

                        //是否响应
                        if (TongCheckBx.Checked && tongText.NotNull())
                        {
                            if (!string.IsNullOrWhiteSpace(accpteText))
                                tongText += " " + tongText.CRCXORGeneration();
                            //是否勾选回车换行
                            if (this.addSendCheckBx.Checked)
                            {
                                tongText = $"{tongText}\r\n";
                            }
                            //发送
                            serialPortDataAdapter.Send(tongText, Encoding.ASCII);
                            tongText = $"【{DateTime.Now.ToString("HH:dd:mm.fff")}】响应→{tongText}";
                            //是否勾选回车换行
                            if (!this.addSendCheckBx.Checked)
                            {
                                tongText = $"{tongText}\r\n";
                            }
                            //因为要访问UI资源，所以需要使用invoke方式同步ui
                            this.Invoke((EventHandler)(delegate
                            {
                                accpetTextBox.AppendText(tongText);

                            }));
                        }

                        // TEST:从添加延时可以测试到，接受消息和处理消息必须分不同线程处理。因为对于消息的处理或多或少都需要耗时，这样容易造成消息处理不及时。而添加到队列后，我们可以随时取出处理

                        // await Task.Delay(100 * 10);
                    }
                }
                catch (TimeoutException) { }
                catch (Exception) { }
            }
        }


        /// <summary>
        /// 波特率选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void baudRateCombx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.baudRateCombx.Text.EqualsIgnoreCase("Custom"))
            {
                baudRateCombx.DropDownStyle = ComboBoxStyle.DropDown;
            }
        }

        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acceptBtn_Click(object sender, EventArgs e)
        {
            //因为要访问UI资源，所以需要使用invoke方式同步ui
            this.Invoke((EventHandler)(delegate
            {
                accpetTextBox.Text = string.Empty;
                sendTextBox.Text = string.Empty;
                acceptBytelab.Text = $"接受：0Bytes";
                sendBytelab.Text = $"发送：0Bytes";
            }));
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (!openStatus) return;
            string accpteText = this.sendTextBox.Text;
            //判断是否发送十六进制数据
            if (this.send16ReadioBtn.Checked)
            {
                //除去收尾空格
                accpteText = accpteText.ToStartAndEndSpace();
                //正则格式化空格,并且去掉首尾空格
                accpteText = Regex.Replace(accpteText, @"\s+", " ").ToStartAndEndSpace();
                string[] strArray = accpteText.Split(' ');

                //进行校验数据格式
                if (strArray.Length < 3)
                {
                    MessageBox.Show("Hex发送数据格式至少要包含头（1字节）+地址码（1字节）+指令码（1字节）+内容,中间已间隔隔开");
                    return;
                }
                if (!accpteText.IsWhiteSpace())
                {
                    string sendData = accpteText.ToUpper();
                    if (sendData.Length % 2 != 0) //判断长度是否为偶数
                    {
                        //不为偶数,将倒数第二位添加一个'0'
                        sendData = sendData.Insert(sendData.Length - 1, "0");
                    }
                    int num = (sendData.Length - sendData.Length % 2) / 2;
                    StringBuilder tempStr = new StringBuilder();
                    for (int i = 0; i < num; i++)
                    {
                        tempStr.Append(sendData.Substring(i * 2, 2) + " ");
                    }
                    accpteText = tempStr.ToString();
                }

                //正则格式化空格,并且去掉首尾空格
                accpteText = Regex.Replace(accpteText, @"\s+", " ").ToStartAndEndSpace();
                strArray = accpteText.Split(' ');
                int itemIndex = 0; // 指令索引,固定格式不进行任何转换
                StringBuilder tempAccpteTextStr = new StringBuilder();
                string fixedStr = string.Empty; //固定类型:头（1字节）+地址码（1字节）+指令码（1字节）
                foreach (var item in strArray)
                {
                    //先把指定格式头格式化
                    if (itemIndex < 3)
                    {
                        fixedStr += $"{item} ";
                    }
                    else
                    {
                        //发送内容转换
                        if (item.IsNumber()) //如果为纯数字，则转换为16进制
                        {
                            //TODO：这里有个疑问，例如数字为：1024，转换成16进制为400，这里高位在前,低位在后
                            string hexStr = item.ToInt().DecimalToHexadecimal();
                            if (hexStr.Length % 2 != 0) //判断长度是否为偶数
                            {
                                //不为偶数,将倒数第二位添加一个'0'
                                hexStr = hexStr.Insert(0, "0");
                            }
                            if (hexStr.Length > 2)
                            {
                                //16进制长度为2位以上,则进行分割处理
                                int count = (hexStr.Length - hexStr.Length % 2) / 2;
                                StringBuilder tempStr = new StringBuilder();
                                for (int i = 0; i < count; i++)
                                {
                                    tempAccpteTextStr.Append(hexStr.Substring(i * 2, 2) + " ");
                                }
                            }
                            else
                            {
                                tempAccpteTextStr.Append(hexStr + " ");
                            }
                        }
                        else if (item.IsChinese())
                            tempAccpteTextStr.Append(item.ChineseStrToHex()+ " ");
                        else
                            tempAccpteTextStr.Append(item + " ");
                    }

                    itemIndex++;
                }
                if (tempAccpteTextStr.Length > 0)
                {
                    string lCountStr = Regex.Replace(tempAccpteTextStr.ToString(), @"\s+", " ").ToStartAndEndSpace();
                    //进行计算高位长度和地位长度
                    tempAccpteTextStr.Insert(0, $"00 {lCountStr.Split(' ').Count().DecimalToHexadecimal()} ");
                    accpteText = fixedStr + tempAccpteTextStr.ToString();
                    if (!string.IsNullOrWhiteSpace(accpteText))
                        accpteText += accpteText.CRCXORGeneration();

                }
            }

            //是否勾选回车换行
            if (this.addSendCheckBx.Checked)
            {
                accpteText = $"{accpteText}\r\n";
            }
            if (accpteText.IsChinese() && this.sendEncodingCheckBx.Checked)
            {
                serialPortDataAdapter.Send(accpteText, Encoding.GetEncoding("GB2312"));
            }
            else
            {
                serialPortDataAdapter.Send(accpteText, Encoding.ASCII);
            }
            accpteText = $"【{DateTime.Now.ToString("HH:dd:mm.fff")}】发送→{accpteText}";
            //是否勾选回车换行
            if (!this.addSendCheckBx.Checked)
            {
                accpteText = $"{accpteText}\r\n";
            }
            //因为要访问UI资源，所以需要使用invoke方式同步ui
            this.Invoke((EventHandler)(delegate
            {
                accpetTextBox.AppendText(accpteText);

            }));

        }

        /// <summary>
        /// 是否自动发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoSendCheckBx_CheckedChanged(object sender, EventArgs e)
        {
            if (this.autoSendCheckBx.Checked)
            {
                //自动发送功能选中,开始自动发送
                this.sendAutoTextBx.Enabled = false;     //禁用定时器输入
                this.timer1.Interval = sendAutoTextBx.Text.ToInt();     //定时器赋初值
                this.timer1.Start();     //启动定时器
                this.statusLab.Text = $"已连接：{this.serialPortCombx.Text},自动发送中...";
                this.sendBtn.Enabled = false; //禁用手动发送
            }
            else
            {
                //自动发送功能未选中,停止自动发送
                this.sendAutoTextBx.Enabled = true;     //启用定时器输入
                this.timer1.Stop();     //停止定时器
                this.statusLab.Text = $"已连接：{this.serialPortCombx.Text}";
                this.sendBtn.Enabled = true; //启用手动发送
            }
        }

        /// <summary>
        /// 计时器到了自动发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //定时时间到
            sendBtn_Click(sendBtn, new EventArgs());    //调用发送按钮回调函数
        }

        /// <summary>
        /// 打开帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label6_Click(object sender, EventArgs e)
        {
            UseHelp frm = new UseHelp();
            //显示窗体
            frm.ShowDialog();
        }

        /// <summary>
        /// 回车自动发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键
            {
                sendBtn_Click(sender, e);//触发button事件

            }
        }
    }
}