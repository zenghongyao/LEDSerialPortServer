using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LEDSerialPort.Utils
{
    public static class CommUtils
    {

        /// <summary>
        /// 根据枚举字符串取枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumStr"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static T GetEnumValue<T>(this string enumStr) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }
            T val = ((T[])Enum.GetValues(typeof(T)))[0];
            if (!string.IsNullOrEmpty(enumStr))
            {
                foreach (T enumValue in (T[])Enum.GetValues(typeof(T)))
                {
                    if (enumValue.ToString().ToUpper().Equals(enumStr.ToUpper()))
                    {
                        val = enumValue;
                        break;
                    }
                }
            }

            return val;
        }


        /// <summary>
        /// 根据枚举值取枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static T GetEnumValue<T>(this int enumValue) where T : struct, IConvertible
        {
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }

            return (T)Enum.ToObject(enumType, enumValue);
        }


        /// <summary>
        /// 与字符串进行比较，忽略大小写
        /// </summary>
        /// <param name="s"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string s, string value)
        {
            return s.Equals(value, StringComparison.OrdinalIgnoreCase);
        }


        /// <summary>
        /// 判断字符串是否为Null、空
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNull(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// 判断字符串是否不为Null、空
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool NotNull(this string s)
        {
            return !string.IsNullOrWhiteSpace(s);
        }
        /// <summary>
        /// 对象转换成int
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static int ToInt(this object thisValue)
        {
            int reval = 0;
            if (thisValue == null) return 0;
            if (thisValue != null && thisValue != DBNull.Value && int.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return reval;
        }

        /// <summary>
        /// 对象转换成int
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="errorValue">默认值</param>
        /// <returns></returns>
        public static int ToInt(this object thisValue, int errorValue)
        {
            int reval;
            if (thisValue != null && thisValue != DBNull.Value && int.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return errorValue;
        }

        /// <summary>
        /// 转换成long
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long ToLong(this object s)
        {
            if (s == null || s == DBNull.Value)
                return 0L;

            long.TryParse(s.ToString(), out long result);
            return result;
        }

        /// <summary>
        /// 十进制转十六进制
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string DecimalToHexadecimal(this int value)
        {
            //string str=  Convert.ToString(value, 16);
            //if (str.Length <= 1)
            //{
            //    return str.PadLeft(2, '0');
            //}
            //return str;

            return value.ToString("X2");
        }

        /// <summary>
        /// 十六进制转十进制
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int HexadecimalToDecimal(this string value)
        {
            return Int32.Parse(value, System.Globalization.NumberStyles.HexNumber);
        }
        /// <summary>
        /// 判断是否为16进制字符串
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static bool IsHexadecimalString(this string hexString)
        {
            //十六进制发送时，发送框数据进行十六进制数据正则校验
            if (Regex.IsMatch(hexString, "^[0-9A-Fa-f]+$"))
            {
                //校验成功
                return true;
            }
            //校验失败
            return false;
        }


        // <summary>
        /// 判断是否十六进制格式字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsHexadecimal(this string str)
        {
            const string PATTERN = @"[A-Fa-f0-9]+$";
            return Regex.IsMatch(str, PATTERN);
        }

        /// <summary>
        /// 判断是否八进制格式字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsOctal(this string str)
        {
            const string PATTERN = @"[0-7]+$";
            return Regex.IsMatch(str, PATTERN);
        }

        /// <summary>
        /// 判断是否二进制格式字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsBinary(this string str)
        {
            const string PATTERN = @"[0-1]+$";
            return Regex.IsMatch(str, PATTERN);
        }

        /// <summary>
        /// 判断是否十进制格式字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDecimal(this string str)
        {
            const string PATTERN = @"[0-9]+$";
            return Regex.IsMatch(str, PATTERN);
        }


        /// <summary>
        /// 判断字符串中是否包含中文
        /// </summary>
        /// <param name="str">需要判断的字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsChinese(this string str)
        {
            return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
        }


        /// <summary>
        /// 判断字符串是否是数字
        /// </summary>
        public static bool IsNumber(this string str)
        {
            return Regex.IsMatch(str, @"^[0-9]*$");
        }

        /// <summary>
        /// 判断中间是否有空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsWhiteSpace(this string str)
        {
            return Regex.IsMatch(str,@"\s+");
        }

        /// <summary>
        /// 去除首尾空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToStartAndEndSpace(this string str)
        {
            return str.TrimStart().TrimEnd();
        }

        /// <summary>
        /// CRC异或校验
        /// </summary>
        /// <param name="cmdString">命令16进制字符串</param>
        /// <returns></returns>
        public static string CRCXORGeneration(this string cmdString)
        {
            cmdString = Regex.Replace(cmdString, @"\s+", "");
            //CRC寄存器
            int CRCCode = 0;
            //将字符串拆分成为16进制字节数据然后两位两位进行异或校验
            for (int i = 1; i < cmdString.Length / 2; i++)
            {
                string cmdHex = cmdString.Substring(i * 2, 2);
                if (i == 1)
                {
                    string cmdPrvHex = cmdString.Substring((i - 1) * 2, 2);
                    CRCCode = (byte)Convert.ToInt32(cmdPrvHex, 16) ^ (byte)Convert.ToInt32(cmdHex, 16);
                }
                else
                {
                    CRCCode = (byte)CRCCode ^ (byte)Convert.ToInt32(cmdHex, 16);
                }
            }
            return Convert.ToString(CRCCode, 16).ToUpper();//返回16进制校验码
        }


        /// <summary>
        /// 字符串包含中文转换HEX
        /// </summary>
        /// <param name="str"></param>
        /// <param name="spaceCharacter"></param>
        /// <returns></returns>
        public static string ChineseStrToHex(this string str, string spaceCharacter= " ")
        {
            byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(str);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                result.Append(bytes[i].ToString("X2") + spaceCharacter);
            }
            return result.ToString().TrimEnd();
        }


        /// <summary>
        /// HEX转换中文字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="spaceCharacter"></param>
        /// <returns></returns>
        public static string HexToChineseStr(this string str)
        {
            str = Regex.Replace(str, @"\s+", "");
            byte[] bytes = new byte[str.Length / 2];
            for (int i = 0; i < str.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(str.Substring(i, 2), 16);
            }
            // 字节转换成字符串
            return Encoding.GetEncoding("GB2312").GetString(bytes);

        }

        /// <summary>
        /// 16六进制字符串加运算
        /// </summary>
        /// <param name="hex"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static  string HexAddOperation(this string hex,int num = 1)
        {
            int val = hex.HexadecimalToDecimal();
            return (val+ num).DecimalToHexadecimal();
        }
    }
}
