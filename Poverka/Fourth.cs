using S7.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Poverka
{
    public partial class Fourth : Form
    {
        private int flowmetersCount = 0;

        private Third thirdForm;

        //item1 - стартовый индекс для строки, item2 - кол-во измерений (строк) в точке, item3 - наименование точки, item4 - индекс точки
        private List<Tuple<int, int, string, int>> mergedCellsInfo = new List<Tuple<int, int, string, int>>();
        //Для удобства
        private List<bool> flowmetersEnabled = new List<bool>() { false, false, false, false, false, false};
        private List<bool> pointsEnabled = new List<bool>() { false, false, false, false };
        private int[] calcsEnabled= new int[4];
        double xTime = 0;


        public Fourth(Third thirdForm)
        {
            flowmetersEnabled[0] = (Tags.wFlowmetersEnable & 1) == 1;
            flowmetersEnabled[1] = (Tags.wFlowmetersEnable & 2) == 2;
            flowmetersEnabled[2] = (Tags.wFlowmetersEnable & 4) == 4;
            flowmetersEnabled[3] = (Tags.wFlowmetersEnable & 8) == 8;
            flowmetersEnabled[4] = (Tags.wFlowmetersEnable & 16) == 16;
            flowmetersEnabled[5] = (Tags.wFlowmetersEnable & 32) == 32;

            foreach (bool el in flowmetersEnabled)
                if (el)
                    flowmetersCount++;

            InitializeComponent();
            this.thirdForm = thirdForm;
            SetupDataGridView();
            AddRowsFromSettings();

            pointsEnabled[0] = thirdForm.Point0_CB.Checked;
            pointsEnabled[1] = thirdForm.Point1_CB.Checked;
            pointsEnabled[2] = thirdForm.Point2_CB.Checked;
            pointsEnabled[3] = thirdForm.Point3_CB.Checked;            
        }

        private void SetupDataGridView()
        {
            dgv.Columns.Clear();
            
            DataGridViewTextBoxColumn extraColumn = new DataGridViewTextBoxColumn();
            extraColumn.Name = "";
            extraColumn.HeaderText = "";
            dgv.Columns.Insert(0, extraColumn);

            dgv.Columns.Add("number", "№");
            dgv.Columns.Add("task_flow", "Расход заданный,м3/ч");
            dgv.Columns.Add("time", "Время,с");
            dgv.Columns.Add("perfect_flow", "Эталонный,V,м3");

            //Тут в зависимости от того сколько будет расходомеров - соответсвущее количество столбцов

            for (int i = 0; i < flowmetersEnabled.Count; i++)
            {
                if (flowmetersEnabled[i])
                {
                    dgv.Columns.Add("current_flow", "V,м3");
                    dgv.Columns.Add("error", "di,%");
                }
            }                                    

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.Columns[0].Width = 30;
            dgv.Columns[1].Width = 30;                        
            dgv.RowTemplate.Height = 30;
            dgv.ColumnHeadersHeight = 60;
            dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            int totalWidth = 0;

            for (int i = 0; i < dgv.Columns.Count; i++)
                totalWidth += dgv.Columns[i].Width;            
            
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;            
                           

            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgv.Paint += DataGridView1_Paint;
            dgv.CellPainting += DataGridView1_CellPainting;
            dgv.Width = totalWidth;
            this.Width = totalWidth + 40;            
            chart1.ChartAreas["title1"].AxisX.Title = "Время";
            chart1.ChartAreas["title1"].AxisY.Title = "Расход, м3";
        }

        private void AddRowsFromSettings()
        {
            if (thirdForm.IsPoint0Checked)
            {
                if (thirdForm.IsPoint0_NumCalc1_RB_Checked) AddRows(1, "P1", 0);
                else if (thirdForm.IsPoint0_NumCalc2_RB_Checked) AddRows(2, "P1", 0);
                else if (thirdForm.IsPoint0_NumCalc3_RB_Checked) AddRows(3, "P1", 0);
            }

            if (thirdForm.IsPoint1Checked)
            {
                if (thirdForm.IsPoint1_NumCalc1_RB_Checked) AddRows(1, "P2", 1);
                else if (thirdForm.IsPoint1_NumCalc2_RB_Checked) AddRows(2, "P2", 1);
                else if (thirdForm.IsPoint1_NumCalc3_RB_Checked) AddRows(3, "P2", 1);
            }

            if (thirdForm.IsPoint2Checked)
            {
                if (thirdForm.IsPoint2_NumCalc1_RB_Checked) AddRows(1, "P3", 2);
                else if (thirdForm.IsPoint2_NumCalc2_RB_Checked) AddRows(2, "P3", 2);
                else if (thirdForm.IsPoint2_NumCalc3_RB_Checked) AddRows(3, "P3", 2);
            }

            if (thirdForm.IsPoint3Checked)
            {
                if (thirdForm.IsPoint3_NumCalc1_RB_Checked) AddRows(1, "P4", 3);
                else if (thirdForm.IsPoint3_NumCalc2_RB_Checked) AddRows(2, "P4", 3);
                else if (thirdForm.IsPoint3_NumCalc3_RB_Checked) AddRows(3, "P4", 3);
            }

            //int totalHeight = 0;
            //for (int i = 0; i < dgv.Rows.Count; i++)
            //    totalHeight += dgv.Rows[i].Height;
            //dgv.Height = totalHeight + dgv.ColumnHeadersHeight;
        }

        private void DataGridView1_Paint(object sender, PaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            bool[] copy = new bool[6];
            flowmetersEnabled.CopyTo(copy);

            //От кол-ва расходомеров зависит сколько пар столбцов (V,м3 и di,%) добавить
            for (int i = 0; i < flowmetersCount; i++)
            {
                // Объединённый заголовок над столбцами
                Rectangle r1 = dgv.GetCellDisplayRectangle(5+i*2, -1, true);
                Rectangle r5 = dgv.GetCellDisplayRectangle(6+i*2, -1, true);

                int adjust = 1;
                int width = r5.Right - r1.Left + adjust - 1;
                int height = dgv.ColumnHeadersHeight / 2;

                Rectangle merged = new Rectangle(r1.Left - adjust, r1.Top, width, height);

                using (SolidBrush backBrush = new SolidBrush(dgv.ColumnHeadersDefaultCellStyle.BackColor))
                    e.Graphics.FillRectangle(backBrush, merged);

                using (Pen gridPen = new Pen(dgv.GridColor))
                {
                    // Левая и правая границы объединённого заголовка
                    e.Graphics.DrawRectangle(gridPen, merged);                    

                    // Ячейка заголовка "di,%" — нарисовать верхнюю и правую границу
                    //Rectangle col6 = dgv.GetCellDisplayRectangle(5, -1, true);
                    //e.Graphics.DrawLine(gridPen, col6.Left, col6.Top, col6.Right, col6.Top);  // верхняя
                    //e.Graphics.DrawLine(gridPen, col6.Right - 1, col6.Top, col6.Right - 1, col6.Bottom);  // правая
                }

                using (StringFormat format = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                })
                using (Brush textBrush = new SolidBrush(dgv.ColumnHeadersDefaultCellStyle.ForeColor))
                {
                    for (int j = 0; j < copy.Length; j++)
                        if (copy[j])
                        {
                            e.Graphics.DrawString("Расходомер №" + (j + 1).ToString(), new Font(this.dgv.Font, FontStyle.Bold), textBrush, merged, format);
                            copy[j] = false;
                            break;
                        }
                            
                }
            }            
        }

        private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //Объединённые вертикальные ячейки в первом столбце
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                foreach (var info in mergedCellsInfo)
                {
                    int start = info.Item1;
                    int span = info.Item2;
                    string text = info.Item3;

                    if (e.RowIndex >= start && e.RowIndex < start + span)
                    {
                        if (e.RowIndex == start)
                        {
                            // Получаем объединённый прямоугольник
                            Rectangle mergedRect = dgv.GetCellDisplayRectangle(0, start, true);
                            for (int i = 1; i < span; i++)
                            {
                                Rectangle nextRect = dgv.GetCellDisplayRectangle(0, start + i, true);
                                mergedRect.Height += nextRect.Height;
                            }

                            // Отладочная заливка (прозрачный красный фон)
                            using (SolidBrush debugBrush = new SolidBrush(Color.FromArgb(30, Color.Red)))
                                e.Graphics.FillRectangle(debugBrush, mergedRect);

                            // Рисуем фон
                            using (SolidBrush backBrush = new SolidBrush(e.CellStyle.BackColor))
                                e.Graphics.FillRectangle(backBrush, mergedRect);

                            // Рисуем все 4 стороны вручную
                            using (Pen gridPen = new Pen(dgv.GridColor))
                            {
                                //e.Graphics.DrawLine(gridPen, mergedRect.Left, mergedRect.Top, mergedRect.Right - 1, mergedRect.Top);       // top
                                e.Graphics.DrawLine(gridPen, mergedRect.Left, mergedRect.Bottom - 1, mergedRect.Right - 1, mergedRect.Bottom - 1); // bottom
                                //e.Graphics.DrawLine(gridPen, mergedRect.Left, mergedRect.Top, mergedRect.Left, mergedRect.Bottom - 1);   // left
                                e.Graphics.DrawLine(gridPen, mergedRect.Right - 1, mergedRect.Top, mergedRect.Right - 1, mergedRect.Bottom - 1); // right
                            }

                            // Центрированный текст
                            TextRenderer.DrawText(e.Graphics, text, e.CellStyle.Font,
                                mergedRect, e.CellStyle.ForeColor,
                                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);

                            e.Handled = true;
                        }
                        else
                        {
                            // Не рисуем ничего — просто блокируем отрисовку, чтобы не перекрывали
                            e.Handled = true;
                        }

                        break;
                    }
                }
            }

            // Нижняя половина заголовков
            if (e.RowIndex == -1 && e.ColumnIndex >= 5 && e.ColumnIndex <= 4 + flowmetersCount * 2)
            {
                e.PaintBackground(e.CellBounds, true);
                Rectangle half = e.CellBounds;
                half.Y += e.CellBounds.Height / 2;
                half.Height = e.CellBounds.Height / 2;

                TextRenderer.DrawText(e.Graphics, e.Value?.ToString() ?? "", e.CellStyle.Font,
                    half, e.CellStyle.ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }

        public int AddRows(int count, string name, int pointNumber)
        {
            int startIndex = dgv.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                dgv.Rows.Add();
                dgv[1, dgv.RowCount - 1].Value = (i + 1).ToString();
            }

            mergedCellsInfo.Add(Tuple.Create(startIndex, count, name, pointNumber));

            return startIndex;
        }

        private void Fourth_Load(object sender, EventArgs e)
        {
            
        }

        private void Go_Third_Click(object sender, EventArgs e)
        {
            if (thirdForm == null || thirdForm.IsDisposed)
                thirdForm = Application.OpenForms.OfType<Third>().FirstOrDefault();

            if (thirdForm != null)
            {
                thirdForm.Show();
                this.Hide();
            }
        }

        //Заполнение DGV значениями
        private void FillDGV()
        {
            List<Flowmeter> flowmeters = Tags.GetFromPLC();

            float[] SetFloat = { Tags.Point0_rFlowSetpoint * Tags.rGmax / 100, 
                                 Tags.Point1_rFlowSetpoint * Tags.rGmax / 100, 
                                 Tags.Point2_rFlowSetpoint * Tags.rGmax / 100,
                                 Tags.Point3_rFlowSetpoint * Tags.rGmax / 100 };

            UInt32[] calibrationTime = { Tags.Point0_tmCalibrationTime,
                                         Tags.Point1_tmCalibrationTime, 
                                         Tags.Point2_tmCalibrationTime, 
                                         Tags.Point3_tmCalibrationTime };

            UInt16[] MeasurementNumbersForEachPoint = { Tags.Point0_iMeasurementNumber,
                                                        Tags.Point1_iMeasurementNumber,
                                                        Tags.Point2_iMeasurementNumber,
                                                        Tags.Point3_iMeasurementNumber };

            //Первый столбец. Заполняем заданный расход (м3/час) по каждой точке по формуле %Gmax * Gmax / 100            
            for (int i = 0; i < mergedCellsInfo.Count; i++)
            {
                for (int j = 0; j < mergedCellsInfo[i].Item2; j++)
                {
                    dgv[2, j + mergedCellsInfo[i].Item1].Value = SetFloat[mergedCellsInfo[i].Item4].ToString();                    
                }
            }            

            //Первый выбранный расходомер
            int FirstChosen = 0;
            for (; FirstChosen < flowmetersEnabled.Count; FirstChosen++)
                if (flowmetersEnabled[FirstChosen])
                    break;

            //Второй и третий столбец. Берем первый выбранный расходомер и его время поверки с эталоном
            int rowInc = 0;
            for (int i = 0; i < pointsEnabled.Count; i++)
                if (pointsEnabled[i])
                {
                    for (int j = 0; j < MeasurementNumbersForEachPoint[i]; j++)
                    {
                        dgv[3, rowInc].Value = flowmeters[FirstChosen].checkingTimes[i * 3 + j]/1000;
                        dgv[4, rowInc].Value = flowmeters[FirstChosen].calibratingFlows[i * 3 + j];
                        rowInc++;
                    }
                }

            //Четвертый и пятый столбцы относятся к каждому расходомеру
            //rCheckingFlow
            //rError            

            int flowInc = 0;
            rowInc = 0;           
            //Перебираем точки
            for (int i = 0; i < pointsEnabled.Count; i++)
                if (pointsEnabled[i])
                {
                    //Перебор по измерениям
                    for (int j = 0; j < MeasurementNumbersForEachPoint[i]; j++)
                    {
                        flowInc = 0;
                        //Перебор по расходомерам
                        for (int k = 0; k < flowmetersEnabled.Count; k++)
                            if (flowmetersEnabled[k])
                            {
                                dgv[5 + 2 * flowInc, rowInc].Value = flowmeters[k].checkingFlows[i * 3 + j];
                                dgv[6 + 2 * flowInc, rowInc].Value = flowmeters[k].errors[i * 3 + j];
                                flowInc++;                                
                            }
                        rowInc++;
                    }
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillDGV();

            //string result = "";
            //for (int i = 0; i < mergedCellsInfo.Count; i++)
            //    result += mergedCellsInfo[i].Item3 + "(" + mergedCellsInfo[i].Item2.ToString() + ", " + mergedCellsInfo[i].Item4.ToString() + ")";
            //MessageBox.Show(result);

            //CalibratingFlow, CheckingFlow, tmCheckingTime
            //tmCheckingTime - Время

            //foreach Calc in Points show tmCheckingTime (X),             
        }

        private void Start_B_Click(object sender, EventArgs e)
        {
            Plc plc = new Plc(CpuType.S71200, "192.168.0.150", 0, 1);
            plc.Open();

            plc.Write("DB15.DBX1.1", 1);

            plc.Close();
        }

        private void Stop_B_Click(object sender, EventArgs e)
        {
            Plc plc = new Plc(CpuType.S71200, "192.168.0.150", 0, 1);
            plc.Open();

            plc.Write("DB15.DBX1.2", 1);

            plc.Close();
        }

        private void Continue_B_Click(object sender, EventArgs e)
        {
            Plc plc = new Plc(CpuType.S71200, "192.168.0.150", 0, 1);
            plc.Open();

            plc.Write("DB15.DBX1.3", 1);

            plc.Close();
        }

        private void Repeat_B_Click(object sender, EventArgs e)
        {
            Plc plc = new Plc(CpuType.S71200, "192.168.0.150", 0, 1);
            plc.Open();

            plc.Write("DB15.DBX1.4", 1);

            plc.Close();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {            
            double y1 = xTime + 2;
            double y2 = xTime + 1;
            chart1.Series[0].Points.AddXY(xTime, y1);
            chart1.Series[1].Points.AddXY(xTime, y2);

            xTime++;            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reports_F form = new Reports_F();
            form.Show();
        }
    }
}