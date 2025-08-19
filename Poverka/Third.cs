using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poverka
{
    public partial class Third : Form
    {
        private Fourth fourthForm;
        public Third()
        {
            InitializeComponent();
        }

        public bool IsPoint0Checked => Point0_CB.Checked;
        public bool IsPoint0_NumCalc1_RB_Checked => Point0_NumCalc1_RB.Checked;
        public bool IsPoint0_NumCalc2_RB_Checked => Point0_NumCalc2_RB.Checked;
        public bool IsPoint0_NumCalc3_RB_Checked => Point0_NumCalc3_RB.Checked;
        public bool IsPoint1Checked => Point1_CB.Checked;
        public bool IsPoint1_NumCalc1_RB_Checked => Point1_NumCalc1_RB.Checked;
        public bool IsPoint1_NumCalc2_RB_Checked => Point1_NumCalc2_RB.Checked;
        public bool IsPoint1_NumCalc3_RB_Checked => Point1_NumCalc3_RB.Checked;
        public bool IsPoint2Checked => Point2_CB.Checked;
        public bool IsPoint2_NumCalc1_RB_Checked => Point2_NumCalc1_RB.Checked;
        public bool IsPoint2_NumCalc2_RB_Checked => Point2_NumCalc2_RB.Checked;
        public bool IsPoint2_NumCalc3_RB_Checked => Point2_NumCalc3_RB.Checked;
        public bool IsPoint3Checked => Point3_CB.Checked;
        public bool IsPoint3_NumCalc1_RB_Checked => Point3_NumCalc1_RB.Checked;
        public bool IsPoint3_NumCalc2_RB_Checked => Point3_NumCalc2_RB.Checked;
        public bool IsPoint3_NumCalc3_RB_Checked => Point3_NumCalc3_RB.Checked;

        private void Third_Load(object sender, EventArgs e)
        {
            Point0_NumCalc1_RB.Enabled = false;
            Point0_NumCalc2_RB.Enabled = false;
            Point0_NumCalc3_RB.Enabled = false;
            Point0_rFlowSetpoint_TB.Enabled = false;
            Point0_rPermissibleErr_TB.Enabled = false;
            Point0_tmCheckingTime_TB.Enabled = false;
            Point0_rFlowSetpoint_TB.BackColor = this.BackColor;
            Point0_rFlowSetpoint_TB.ForeColor = Color.Black;
            Point0_rPermissibleErr_TB.BackColor = this.BackColor;
            Point0_rPermissibleErr_TB.ForeColor = Color.Black;
            Point0_tmCheckingTime_TB.BackColor = this.BackColor;
            Point0_tmCheckingTime_TB.ForeColor = Color.Black;

            Point1_NumCalc1_RB.Enabled = false;
            Point1_NumCalc2_RB.Enabled = false;
            Point1_NumCalc3_RB.Enabled = false;
            Point1_rFlowSetpoint_TB.Enabled = false;
            Point1_rPermissibleErr_TB.Enabled = false;
            Point1_tmCheckingTime_TB.Enabled = false;
            Point1_rFlowSetpoint_TB.BackColor = this.BackColor;
            Point1_rFlowSetpoint_TB.ForeColor = Color.Black;
            Point1_rPermissibleErr_TB.BackColor = this.BackColor;
            Point1_rPermissibleErr_TB.ForeColor = Color.Black;
            Point1_tmCheckingTime_TB.BackColor = this.BackColor;
            Point1_tmCheckingTime_TB.ForeColor = Color.Black;

            Point2_NumCalc1_RB.Enabled = false;
            Point2_NumCalc2_RB.Enabled = false;
            Point2_NumCalc3_RB.Enabled = false;
            Point2_rFlowSetpoint_TB.Enabled = false;
            Point2_rPermissibleErr_TB.Enabled = false;
            Point2_tmCheckingTime_TB.Enabled = false;
            Point2_rFlowSetpoint_TB.BackColor = this.BackColor;
            Point2_rFlowSetpoint_TB.ForeColor = Color.Black;
            Point2_rPermissibleErr_TB.BackColor = this.BackColor;
            Point2_rPermissibleErr_TB.ForeColor = Color.Black;
            Point2_tmCheckingTime_TB.BackColor = this.BackColor;
            Point2_tmCheckingTime_TB.ForeColor = Color.Black;

            Point3_NumCalc1_RB.Enabled = false;
            Point3_NumCalc2_RB.Enabled = false;
            Point3_NumCalc3_RB.Enabled = false;
            Point3_rFlowSetpoint_TB.Enabled = false;
            Point3_rPermissibleErr_TB.Enabled = false;
            Point3_tmCheckingTime_TB.Enabled = false;
            Point3_rFlowSetpoint_TB.BackColor = this.BackColor;
            Point3_rFlowSetpoint_TB.ForeColor = Color.Black;
            Point3_rPermissibleErr_TB.BackColor = this.BackColor;
            Point3_rPermissibleErr_TB.ForeColor = Color.Black;
            Point3_tmCheckingTime_TB.BackColor = this.BackColor;
            Point3_tmCheckingTime_TB.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Second second_form = new Second();
            second_form.FirstTime = false;
            second_form.ShowDialog();
            this.Close();
        }

        private void Point0_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (Point0_CB.Checked)
            {                
                Point0_NumCalc1_RB.Enabled = true;
                Point0_NumCalc2_RB.Enabled = true;
                Point0_NumCalc3_RB.Enabled = true;
                Point0_rFlowSetpoint_TB.Enabled = true;
                Point0_rPermissibleErr_TB.Enabled = true;
                Point0_tmCheckingTime_TB.Enabled = true;
                Point0_rFlowSetpoint_TB.BackColor = Color.White;
                Point0_rPermissibleErr_TB.BackColor = Color.White;
                Point0_tmCheckingTime_TB.BackColor = Color.White;

                Point0_NumCalc1_RB.Checked = true;
            }
            else
            {                   
                Point0_NumCalc1_RB.Enabled = false;
                Point0_NumCalc2_RB.Enabled = false;
                Point0_NumCalc3_RB.Enabled = false;
                Point0_rFlowSetpoint_TB.Enabled = false;
                Point0_rPermissibleErr_TB.Enabled = false;
                Point0_tmCheckingTime_TB.Enabled = false;
                Point0_rFlowSetpoint_TB.BackColor = this.BackColor;
                Point0_rPermissibleErr_TB.BackColor = this.BackColor;
                Point0_tmCheckingTime_TB.BackColor = this.BackColor;

                Point0_NumCalc1_RB.Checked = false;
                Point0_NumCalc2_RB.Checked = false;
                Point0_NumCalc3_RB.Checked = false;
            }
        }

        private void Point1_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (Point1_CB.Checked)
            {
                Point1_NumCalc1_RB.Enabled = true;
                Point1_NumCalc2_RB.Enabled = true;
                Point1_NumCalc3_RB.Enabled = true;
                Point1_rFlowSetpoint_TB.Enabled = true;
                Point1_rPermissibleErr_TB.Enabled = true;
                Point1_tmCheckingTime_TB.Enabled = true;
                Point1_rFlowSetpoint_TB.BackColor = Color.White;
                Point1_rPermissibleErr_TB.BackColor = Color.White;
                Point1_tmCheckingTime_TB.BackColor = Color.White;

                Point1_NumCalc1_RB.Checked = true;
            }
            else
            {
                Point1_NumCalc1_RB.Enabled = false;
                Point1_NumCalc2_RB.Enabled = false;
                Point1_NumCalc3_RB.Enabled = false;
                Point1_rFlowSetpoint_TB.Enabled = false;
                Point1_rPermissibleErr_TB.Enabled = false;
                Point1_tmCheckingTime_TB.Enabled = false;
                Point1_rFlowSetpoint_TB.BackColor = this.BackColor;
                Point1_rPermissibleErr_TB.BackColor = this.BackColor;
                Point1_tmCheckingTime_TB.BackColor = this.BackColor;

                Point1_NumCalc1_RB.Checked = false;
                Point1_NumCalc2_RB.Checked = false;
                Point1_NumCalc3_RB.Checked = false;
            }
        }

        private void Point2_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (Point2_CB.Checked)
            {
                Point2_NumCalc1_RB.Enabled = true;
                Point2_NumCalc2_RB.Enabled = true;
                Point2_NumCalc3_RB.Enabled = true;
                Point2_rFlowSetpoint_TB.Enabled = true;
                Point2_rPermissibleErr_TB.Enabled = true;
                Point2_tmCheckingTime_TB.Enabled = true;
                Point2_rFlowSetpoint_TB.BackColor = Color.White;
                Point2_rPermissibleErr_TB.BackColor = Color.White;
                Point2_tmCheckingTime_TB.BackColor = Color.White;

                Point2_NumCalc1_RB.Checked = true;
            }
            else
            {
                Point2_NumCalc1_RB.Enabled = false;
                Point2_NumCalc2_RB.Enabled = false;
                Point2_NumCalc3_RB.Enabled = false;
                Point2_rFlowSetpoint_TB.Enabled = false;
                Point2_rPermissibleErr_TB.Enabled = false;
                Point2_tmCheckingTime_TB.Enabled = false;
                Point2_rFlowSetpoint_TB.BackColor = this.BackColor;
                Point2_rPermissibleErr_TB.BackColor = this.BackColor;
                Point2_tmCheckingTime_TB.BackColor = this.BackColor;

                Point2_NumCalc1_RB.Checked = false;
                Point2_NumCalc2_RB.Checked = false;
                Point2_NumCalc3_RB.Checked = false;
            }
        }

        private void Point3_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (Point3_CB.Checked)
            {
                Point3_NumCalc1_RB.Enabled = true;
                Point3_NumCalc2_RB.Enabled = true;
                Point3_NumCalc3_RB.Enabled = true;
                Point3_rFlowSetpoint_TB.Enabled = true;
                Point3_rPermissibleErr_TB.Enabled = true;
                Point3_tmCheckingTime_TB.Enabled = true;
                Point3_rFlowSetpoint_TB.BackColor = Color.White;
                Point3_rPermissibleErr_TB.BackColor = Color.White;
                Point3_tmCheckingTime_TB.BackColor = Color.White;

                Point3_NumCalc1_RB.Checked = true;
            }
            else
            {
                Point3_NumCalc1_RB.Enabled = false;
                Point3_NumCalc2_RB.Enabled = false;
                Point3_NumCalc3_RB.Enabled = false;
                Point3_rFlowSetpoint_TB.Enabled = false;
                Point3_rPermissibleErr_TB.Enabled = false;
                Point3_tmCheckingTime_TB.Enabled = false;
                Point3_rFlowSetpoint_TB.BackColor = this.BackColor;
                Point3_rPermissibleErr_TB.BackColor = this.BackColor;
                Point3_tmCheckingTime_TB.BackColor = this.BackColor;

                Point3_NumCalc1_RB.Checked = false;
                Point3_NumCalc2_RB.Checked = false;
                Point3_NumCalc3_RB.Checked = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            //Выбрано точек
            UInt16 wPointsEnable = 0;

            //Если точек не выбрано
            if (!Point0_CB.Checked && !Point1_CB.Checked && !Point2_CB.Checked && !Point3_CB.Checked)
            {
                MessageBox.Show("Не выбрана ни одна поверочная точка");
                return;
            }
                
            //Если выбрана точка
            if (Point0_CB.Checked)
            {
                //Взводится первый(нулевой) бит
                wPointsEnable |= 1;
                try
                {                    
                    float Point0_rFlowSetPoint = (float)Convert.ToDouble(Point0_rFlowSetpoint_TB.Text);
                    UInt32 Point0_tmCalibrationTime = Convert.ToUInt32(Point0_tmCheckingTime_TB.Text);
                    float Point0_rPermissibleError = (float)Convert.ToDouble(Point0_rPermissibleErr_TB.Text);

                    Tags.Point0_rFlowSetpoint = Point0_rFlowSetPoint;
                    Tags.Point0_tmCalibrationTime = Point0_tmCalibrationTime;
                    Tags.Point0_rPermissibleError = Point0_rPermissibleError;

                    if (Point0_NumCalc1_RB.Checked) Tags.Point0_iMeasurementNumber = 1;
                    else if (Point0_NumCalc2_RB.Checked) Tags.Point0_iMeasurementNumber = 2;
                    else Tags.Point0_iMeasurementNumber = 3;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Проверьте правильность введенных данных для 1-ой точки");
                    return;
                }                
            }
            if (Point1_CB.Checked)
            {
                wPointsEnable |= 2;
                try
                {
                    float Point1_rFlowSetPoint = (float)Convert.ToDouble(Point1_rFlowSetpoint_TB.Text);
                    UInt32 Point1_tmCalibrationTime = Convert.ToUInt32(Point1_tmCheckingTime_TB.Text);
                    float Point1_rPermissibleError = (float)Convert.ToDouble(Point1_rPermissibleErr_TB.Text);

                    Tags.Point1_rFlowSetpoint = Point1_rFlowSetPoint;
                    Tags.Point1_tmCalibrationTime = Point1_tmCalibrationTime;
                    Tags.Point1_rPermissibleError = Point1_rPermissibleError;

                    if (Point1_NumCalc1_RB.Checked) Tags.Point1_iMeasurementNumber = 1;
                    else if (Point1_NumCalc2_RB.Checked) Tags.Point1_iMeasurementNumber = 2;
                    else Tags.Point1_iMeasurementNumber = 3;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Проверьте правильность введенных данных для 2-ой точки");
                    return;
                }
            }
            if (Point2_CB.Checked)
            {
                wPointsEnable |= 4;
                try
                {
                    float Point2_rFlowSetPoint = (float)Convert.ToDouble(Point2_rFlowSetpoint_TB.Text);
                    UInt32 Point2_tmCalibrationTime = Convert.ToUInt32(Point2_tmCheckingTime_TB.Text);
                    float Point2_rPermissibleError = (float)Convert.ToDouble(Point2_rPermissibleErr_TB.Text);

                    Tags.Point2_rFlowSetpoint = Point2_rFlowSetPoint;
                    Tags.Point2_tmCalibrationTime = Point2_tmCalibrationTime;
                    Tags.Point2_rPermissibleError = Point2_rPermissibleError;

                    if (Point2_NumCalc1_RB.Checked) Tags.Point2_iMeasurementNumber = 1;
                    else if (Point2_NumCalc2_RB.Checked) Tags.Point2_iMeasurementNumber = 2;
                    else Tags.Point2_iMeasurementNumber = 3;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Проверьте правильность введенных данных для 3-ей точки");
                    return;
                }
            }
            if (Point3_CB.Checked)
            {
                wPointsEnable |= 8;
                try
                {
                    float Point3_rFlowSetPoint = (float)Convert.ToDouble(Point3_rFlowSetpoint_TB.Text);
                    UInt32 Point3_tmCalibrationTime = Convert.ToUInt32(Point3_tmCheckingTime_TB.Text);
                    float Point3_rPermissibleError = (float)Convert.ToDouble(Point3_rPermissibleErr_TB.Text);

                    Tags.Point3_rFlowSetpoint = Point3_rFlowSetPoint;
                    Tags.Point3_tmCalibrationTime = Point3_tmCalibrationTime;
                    Tags.Point3_rPermissibleError = Point3_rPermissibleError;

                    if (Point3_NumCalc1_RB.Checked) Tags.Point3_iMeasurementNumber = 1;
                    else if (Point3_NumCalc2_RB.Checked) Tags.Point3_iMeasurementNumber = 2;
                    else Tags.Point3_iMeasurementNumber = 3;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Проверьте правильность введенных данных для 4-ей точки");
                    return;
                }
            }

            try
            {
                float rGmax = (float)Convert.ToDouble(Gmax_TB.Text);
                Tags.rGmax = rGmax;
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректно введен максимальный расход (Gmax)");
                return;
            }

            Tags.wPointsEnable = wPointsEnable;

            //Отправка имеющихся значений в контроллер
            Tags.SendToPLC();

            fourthForm = new Fourth(this);
            fourthForm.Show();
            this.Hide();
        }

        private void Point0_rFlowSetpoint_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextbox(sender, e);
        }

        private void Point1_rFlowSetpoint_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextbox(sender, e);
        }

        private void Point2_rFlowSetpoint_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextbox(sender, e);
        }

        private void Point3_rFlowSetpoint_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextbox(sender, e);
        }

        private void Point0_tmCheckingTime_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextbox(sender, e);
        }

        private void Point1_tmCheckingTime_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextbox(sender, e);
        }

        private void Point2_tmCheckingTime_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextbox(sender, e);
        }

        private void Point3_tmCheckingTime_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextbox(sender, e);
        }

        private void Point0_rPermissibleErr_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextbox(sender, e);
        }

        private void Point1_rPermissibleErr_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextbox(sender, e);
        }

        private void Point2_rPermissibleErr_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextbox(sender, e);
        }

        private void Point3_rPermissibleErr_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextbox(sender, e);
        }

        private void Gmax_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextbox(sender, e);
        }        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextbox(sender, e);
        }

        private void CheckTextbox(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }
    }
}