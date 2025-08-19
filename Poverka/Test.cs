using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using S7.Net;
using S7.Net.Types;
using System.IO;
//using Sharp7;

namespace Poverka
{
    public partial class Test : Form
    {
        //Объект класса Контроллер
        Plc plc;

        public Test()
        {
            InitializeComponent();            
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

                var value4 = (UInt32)plc.Read(DataType.DataBlock, 20, 14, VarType.DWord, 1);

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

        private void Form1_Load(object sender, EventArgs e)
        {
            //При создании объекта класса Plc сразу идет попытка подключения. На этапе создания объекта нужно проверять подключение
            //Plc plc = new Plc(CpuType.S71200, "192.168.0.150", 0, 1);
            //plc.Open();
            //plc.Write("DB20.DBD14", 2 * 1000);
            //MessageBox.Show(((UInt32)plc.Read(DataType.DataBlock, 20, 14, VarType.DWord, 1)).ToString());            
            //plc.Close();
            //MessageBox.Show(plc.IsConnected.ToString());            
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            First form = new First();
            form.ShowDialog();            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Plc currentPlc = new Plc(CpuType.S71200, "192.168.0.150", 0, 1);
            //    currentPlc.Open();

            //    Flowmeter test = new Flowmeter(1, 26, currentPlc);



            //    chart1.Series[0].Points.AddXY(test.Point0_Calc0_tmCheckingTime, test.calibratingFlows[0]);
            //    chart1.Series[1].Points.AddXY(test.Point0_Calc0_tmCheckingTime, test.checkingFlows[0]);


            //    for (double x = 0; x < 10; x++)
            //    {
            //        double y = x + 3;
            //        chart1.Series[0].Points.AddXY(x, y);
            //    }

            //    chart1.Series[0].Points.AddXY(test.Point0_Calc0_tmCheckingTime, test.calibratingFlows[0]);
            //    chart1.Series[1].Points.AddXY(test.Point0_Calc0_tmCheckingTime, test.checkingFlows[0]);

            //    //chart1.Series[0].Points.AddXY(Tags.Point1_tmCalibrationTime, Tags.Point1_rFlowSetpoint);
            //    //chart1.Series[1].Points.AddXY(Tags.Point1_tmCalibrationTime, Tags.Point1_rFlowSetpoint);

            //    currentPlc.Open();
            //}
            //catch(Exception E) 
            //{
            //    MessageBox.Show(E.Message);
            //}            

            var filePath1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", 
                                                                               "ВЗЛЕТ 420Л",
                                                                               "protocol_vnesh.rtf");

            var filePath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports",
                                                                               "ВЗЛЕТ 420Л",
                                                                               "protocol_vnesh.rtf");

            var filePath3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports",
                                                                               "ВЗЛЕТ 420Л",
                                                                               "protocol_vnesh.rtf");

            var filePath4 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports",
                                                                               "ВЗЛЕТ 420Л",
                                                                               "protocol_vnesh.rtf");

            var filePath5 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports",
                                                                               "ВЗЛЕТ 420Л",
                                                                               "protocol_vnesh.rtf");

            richTextBox1.LoadFile(filePath1);


        }
    }
}