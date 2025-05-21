using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using S7.Net;
using S7.Net.Types;
//using Sharp7;

namespace Poverka
{
    public partial class Form1 : Form
    {
        //Объект класса Контроллер
        Plc plc = new Plc(CpuType.S71200, "192.168.0.150", 0, 1);

        public Form1()
        {
            InitializeComponent();
            //Открытие связи
            plc.Open();
        }

        //
        //Чтение значений
        //
        private void button1_Click(object sender, EventArgs e)
        {                        
            try
            {                                                                                
                textBox3.Text = plc.IsConnected? "Соединение успешно": "Соединение не успешно";

                Tag tag_float = new Tag("float_tag", 20, 0, VarType.Real);

                //float
                var value1 = (float)plc.Read(DataType.DataBlock, 20, 0, VarType.Real, 1);                                

                //word
                var value2 = (ushort)plc.Read(DataType.DataBlock, 3, 68, VarType.Word, 1);                

                //byte
                //var value3 = (bool)plc.Read("DB3.DBX22.0");
                var value3 = (bool)plc.Read(DataType.DataBlock, 3, 22, VarType.Bit, 1, 0);                

                //Типы данных boolean читаются с помощью перегрузки метода Read с одним параметром,также с 6-ью 
                //Типы данных word, float читаются помощью перегрузки метода Read с 5-ью параметрами

                textBox1.Text = value1.ToString();
                textBox2.Text = value2.ToString();
                checkBox1.Checked = value3;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Close();
            }            

            //var client = new S7Client();
            //client.ConnectTo("192.168.0.150", 0, 1);
            //MessageBox.Show(client.Connected ? "Соединение успешно" : "Соединение не успешно");
        }

        //
        //Запись значений
        //
        private void button2_Click(object sender, EventArgs e)
        {
            //float
            //float value1 = (float)Convert.ToDouble(textBox4.Text);
            //plc.Write("DB20.DBD0", value1);

            //word
            //UInt16 value2 = Convert.ToUInt16(textBox4.Text);
            //plc.Write("DB3.DBD68", value2);

            //boolean
            //bool value3 = checkBox1.Checked;
            //plc.Write("DB3.DBX46.0", value3);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Закрытие связи
            plc.Close();
        }
    }
}