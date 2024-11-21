using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace test
{
    public partial class Form1 : Form
    {
        protected SerialPort i_comObj;
        public Form1()
        {
            InitializeComponent();
        }

        private string getTwoCharHex(byte inChar)
        {
            if (inChar <= 15)
            {
                return "0" + Conversion.Hex(inChar);
            }
            return Conversion.Hex(inChar);
        }


        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {/*
            string text = "";
            while (i_comObj.BytesToRead != 0)
            {
                text += getTwoCharHex(checked((byte)i_comObj.ReadByte()));
            }*/

            string s = i_comObj.ReadExisting();

            StringBuilder stringBuilder = new StringBuilder();
            foreach (char @string in s)
            {
                stringBuilder.Append(Strings.Asc(@string).ToString("X2"));
            }
            MessageBox.Show(stringBuilder.ToString());
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (i_comObj == null) {

                i_comObj = new SerialPort(textBoxComPort.Text, 2400);

                i_comObj.Parity = Parity.None;
                i_comObj.StopBits = StopBits.One;
                i_comObj.DataBits = 8;

                i_comObj.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            }

            if(!i_comObj.IsOpen)
            {
                i_comObj.Open();
            }

            transmitPacket();

        }

        protected bool i_transmit(string dataPacket, bool CRC_Already_Calculated)
        {
            if (i_comObj.IsOpen)
            {
/*                if (!CRC_Already_Calculated)
                {
                    byte[] Result = new byte[2];
                    getCRC(dataPacket, ref Result);
                }*/

                this.serialWrite(dataPacket);

                return true;
            }
            else
            {
                return false;
            }
        }

        private void serialWrite(string theData)
        {
            byte[] array = new byte[theData.Length];
            int num = theData.Length - 1;
            for (int i = 0; i <= num; i++)
            {
                array[i] = (byte)Strings.Asc(theData.Substring(i, 1));
            }
            if (i_comObj.IsOpen)
            {
                i_comObj.Write(array, 0, theData.Length);
            }
        }

        public int getCRC(string message, ref byte[] Result)
        {
           
                byte[] bytesToCRC = new byte[Strings.Len(message) + 1];
                int num = Strings.Len(message) - 1;
                for (int i = 0; i <= num; i++)
                {
                    bytesToCRC[i] = (byte)Strings.Asc(Strings.Mid(message, i + 1, 1));
                }
                return getCRC(ref bytesToCRC, 0, Strings.Len(message) - 3, ref Result);

        }

        public int getCRC(ref byte[] bytesToCRC, int startByte, int totalMessageLength, ref byte[] result)
        {
            if (totalMessageLength < 7)
            {
                return 1;
            }
            checked
            {
                byte[] array = new byte[totalMessageLength + 1];
                byte[] array2 = new byte[6] { 250, 11, 57, 106, 189, 46 };
                int num = 65535;
                int num2 = totalMessageLength - 1;
                int i;
                for (i = 0; i <= num2; i++)
                {
                    array[i] = bytesToCRC[i + startByte];
                }
                i = 1;
                do
                {
                    unchecked
                    {
                        array[i] = (byte)(array[i] ^ array2[checked(i - 1)]);
                    }
                    i++;
                }
                while (i <= 6);
                int num3 = totalMessageLength - 1;
                for (i = 0; i <= num3; i++)
                {
                    num ^= array[i];
                    int num4 = 0;
                    do
                    {
                        num = (((num & 1) != 1) ? (num >> 1) : ((num >> 1) ^ 0x8408));
                        num4++;
                    }
                    while (num4 <= 7);
                }
                result[0] = (byte)((num & 0xFF00) >> 8);
                result[1] = (byte)(num & 0xFF);
                return 0;
            }
        }

        public string constructPacket(string st_command)
        {
            byte[] Result = new byte[2];
            checked
            {
                st_command = "\u0002" + st_command + Conversions.ToString(Strings.Chr((int)Conversion.Int(256f * VBMath.Rnd()))) + "00\r";
                st_command = Strings.Mid(st_command, 1, 5) + Conversions.ToString(Strings.Chr(st_command.Length + 1)) + Strings.Mid(st_command, 6);
                if (getCRC(st_command, ref Result) != 0)
                {
                    Interaction.MsgBox("Couldnt Build CRC");
                    return "";
                }
                /*if (i_ignoreCRC.Checked)
                {
                    st_command = Strings.Mid(st_command, 1, st_command.Length - 4) + "0" + Strings.Mid(st_command, st_command.Length - 2);
                    Result[0] = 48;
                    Result[1] = 48;
                }*/
                st_command = Strings.Mid(st_command, 1, st_command.Length - 3) + Conversions.ToString(Strings.Chr(Result[0])) + Conversions.ToString(Strings.Chr(Result[1])) + "\r";
                return st_command;
            }
        }

        public string transmitPacket()
        {
            string text = textBoxColumn.Text;
            string frame = Conversions.ToString(Strings.Chr((int)Math.Round((double)(48.0 + Conversions.ToDouble(textBoxFrame.Text) * 2.0) - 1.0)));
            string column = Conversions.ToString(Strings.Chr((int)Math.Round((double)(48.0 + Conversions.ToDouble(ExtractSubString(ref text, 0))))));
            string drawer = textBoxDrawer.Text;


            string dataPacket = constructPacket(frame + column + drawer + "0E");

            StringBuilder stringBuilder = new StringBuilder();
            foreach (char @string in dataPacket)
            {
                stringBuilder.Append(Strings.Asc(@string).ToString("X2"));
            }

            i_transmit(dataPacket, false);

            return dataPacket;
        }

        public static string ExtractSubString(ref string sourceString, int fieldToReturn)
        {
            if (fieldToReturn < 0)
            {
                return "";
            }
            string[] array = Strings.Split(sourceString);
            if (fieldToReturn > array.GetUpperBound(0))
            {
                return "";
            }
            return array[fieldToReturn];
        }
    }
}
