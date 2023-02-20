using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LEDSerialPort
{
    /// <summary>
    /// LED 协议
    /// </summary>
    public static class LEDProtocol
    {
        /// <summary>
        /// 所有的执行(指令为十六进制)
        /// </summary>
        public static List<InstructionsClass> InstructionsList = new List<InstructionsClass>()
        {
           new InstructionsClass(){ Key="30", Name="清屏"},
           new InstructionsClass(){ Key="32", Name="实时字符串"},
           new InstructionsClass(){ Key="34", Name="实时图片"},
           new InstructionsClass(){ Key="36", Name="实时AD通道数值"},
           new InstructionsClass(){ Key="38", Name="在线测试"},
           new InstructionsClass(){ Key="3A", Name="修改通讯参数"},
           new InstructionsClass(){ Key="3C", Name="校时"},
           new InstructionsClass(){ Key="3E", Name="亮度设置"},
           new InstructionsClass(){ Key="40", Name="定时开关屏"},
           new InstructionsClass(){ Key="42", Name="手动开关屏"}
        };

        /// <summary>
        /// 发送指令
        /// </summary>
        public static string PingPrefix = "7E";

        /// <summary>
        /// 响应指令
        /// </summary>
        public static string TongPrefix = "7F";

        /// <summary>
        /// 判断是存在指令表里
        /// </summary>
        /// <param name="cmdStr"></param>
        /// <returns></returns>
        public static bool IsExistInstructions(this string cmdStr)
        {
            return InstructionsList.Where(i => i.Key==cmdStr.Trim()).Any();
        }


    }

    public class InstructionsClass
    {
        /// <summary>
        /// 指令
        /// </summary>
        public string? Key { get; set; } 

        /// <summary>
        /// 指令名称
        /// </summary>
        public string? Name { get; set; }
    }
}
