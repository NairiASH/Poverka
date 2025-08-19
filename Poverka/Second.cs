using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using S7.Net;
using S7.Net.Types;

namespace Poverka
{
    public partial class Second : Form
    {
        public bool FirstTime;

        public bool Rashodomer1_Enabled, Rashodomer2_Enabled, Rashodomer3_Enabled, Rashodomer4_Enabled, Rashodomer5_Enabled, Rashodomer6_Enabled;

        string connStr = "Host=localhost;Port=5432;Username=postgres;Password=ivan123;Database=postgres";
        public Second()
        {
            FirstTime = true;
            InitializeComponent();
            Rashodomer1_CB.Size = new Size(70, 50);
        }

        //Привязка данных к ComboBox
        private void Second_Load(object sender, EventArgs e)
        {
            //Первый запуск формы
            if (FirstTime)
            {
                Rashodomer1_CB.Checked = Rashodomer2_CB.Checked = Rashodomer3_CB.Checked = Rashodomer4_CB.Checked = Rashodomer5_CB.Checked = Rashodomer6_CB.Checked = false;
                Rashodomer1_Enabled = Rashodomer2_Enabled = Rashodomer3_Enabled = Rashodomer4_Enabled = Rashodomer5_Enabled = Rashodomer6_Enabled;
                
            }
            //Не первый запуск (Вернулись назад. Нужно вставить имеющиеся данные)
            else
            { 
                //Если выбран первый расходомер и т.д.
            }

            // SQL-запрос
            string query = "SELECT id, Номер_гос_реестра, Наименование_СИ, Документ_на_поверку FROM Гос_реестр";

            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();
            DataTable table3 = new DataTable();
            DataTable table4 = new DataTable();
            DataTable table5 = new DataTable();
            DataTable table6 = new DataTable();

            Flow1_GosReestr_CB.Items.Clear();
            Flow2_GosReestr_CB.Items.Clear();
            Flow3_GosReestr_CB.Items.Clear();
            Flow4_GosReestr_CB.Items.Clear();
            Flow5_GosReestr_CB.Items.Clear();
            Flow6_GosReestr_CB.Items.Clear();

            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();

                    using (var adapter = new NpgsqlDataAdapter(query, conn))
                    {
                        adapter.Fill(table1);
                        adapter.Fill(table2);
                        adapter.Fill(table3);
                        adapter.Fill(table4);
                        adapter.Fill(table5);
                        adapter.Fill(table6);
                    }
                }

                // Привязка таблицы к ComboBox
                Flow1_GosReestr_CB.DataSource = table1;
                Flow1_GosReestr_CB.DisplayMember = "Номер_гос_реестра";
                Flow1_GosReestr_CB.ValueMember = "id";
                Flow1_GosReestr_CB.SelectedIndex = -1;

                Flow2_GosReestr_CB.DataSource = table2;
                Flow2_GosReestr_CB.DisplayMember = "Номер_гос_реестра";
                Flow2_GosReestr_CB.ValueMember = "id";
                Flow2_GosReestr_CB.SelectedIndex = -1;

                Flow3_GosReestr_CB.DataSource = table3;
                Flow3_GosReestr_CB.DisplayMember = "Номер_гос_реестра";
                Flow3_GosReestr_CB.ValueMember = "id";
                Flow3_GosReestr_CB.SelectedIndex = -1;

                Flow4_GosReestr_CB.DataSource = table4;
                Flow4_GosReestr_CB.DisplayMember = "Номер_гос_реестра";
                Flow4_GosReestr_CB.ValueMember = "id";
                Flow4_GosReestr_CB.SelectedIndex = -1;

                Flow5_GosReestr_CB.DataSource = table5;
                Flow5_GosReestr_CB.DisplayMember = "Номер_гос_реестра";
                Flow5_GosReestr_CB.ValueMember = "id";
                Flow5_GosReestr_CB.SelectedIndex = -1;

                Flow6_GosReestr_CB.DataSource = table6;
                Flow6_GosReestr_CB.DisplayMember = "Номер_гос_реестра";
                Flow6_GosReestr_CB.ValueMember = "id";
                Flow6_GosReestr_CB.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке: " + ex.Message);
            }
        }

        //
        // Выбор госреестра для каждого расходомера
        //

        private void GosReestrCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEverything(Flow1_GosReestr_CB, Flow1_Name_SI_CB, Flow1_Document_CB, Flow1_Modification_CB, Flow1_Diameter_CB);
        }

        private void Flow2_GosReestr_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEverything(Flow2_GosReestr_CB, Flow2_Name_SI_CB, Flow2_Document_CB, Flow2_Modification_CB, Flow2_Diameter_CB);
        }

        private void Flow3_GosReestr_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEverything(Flow3_GosReestr_CB, Flow3_Name_SI_CB, Flow3_Document_CB, Flow3_Modification_CB, Flow3_Diameter_CB);
        }

        private void Flow4_GosReestr_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEverything(Flow4_GosReestr_CB, Flow4_Name_SI_CB, Flow4_Document_CB, Flow4_Modification_CB, Flow4_Diameter_CB);
        }

        private void Flow5_GosReestr_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEverything(Flow5_GosReestr_CB, Flow5_Name_SI_CB, Flow5_Document_CB, Flow5_Modification_CB, Flow5_Diameter_CB);
        }

        private void Flow6_GosReestr_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEverything(Flow6_GosReestr_CB, Flow6_Name_SI_CB, Flow6_Document_CB, Flow6_Modification_CB, Flow6_Diameter_CB);
        }


        private void LoadEverything(ComboBox gosReestr_CB, ComboBox name_SI_CB, ComboBox Document_CB, ComboBox Modification_CB, ComboBox Diametr_Cb)
        {
            if (gosReestr_CB.SelectedIndex != -1)
            {
                int selectedId;
                if (int.TryParse(gosReestr_CB.SelectedValue.ToString(), out selectedId))
                {
                    //Отбор записей в массив по выбранному айди
                    DataRow[] rows = ((DataTable)gosReestr_CB.DataSource).Select($"id = {selectedId}");
                    if (rows.Length > 0)
                    {
                        string Name_SI = rows[0]["Наименование_СИ"].ToString();
                        name_SI_CB.Items.Clear();
                        name_SI_CB.Items.Add(Name_SI);
                        name_SI_CB.SelectedIndex = 0;
                        
                        string Document = rows[0]["Документ_на_поверку"].ToString();
                        Document_CB.Items.Clear();
                        Document_CB.Items.Add(Document);
                        Document_CB.SelectedIndex = 0;

                        //Заполняем модификацию и диаметр
                        LoadModifikaciya(selectedId, Modification_CB);
                        LoadDiameters(selectedId, Diametr_Cb);
                    }
                }
            }
        }

        private void LoadModifikaciya(int reestrId, ComboBox Modifikaciya_CB)
        {            
            //Выбор модификаций по гос реестру
            string query = "SELECT Модификация_расходомера FROM Модификации_Расходомеров WHERE гос_реестр_id = @id";

            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("id", reestrId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            Modifikaciya_CB.Items.Clear();
                            Modifikaciya_CB.SelectedIndex = -1;

                            while (reader.Read())
                            {
                                string modif = reader["Модификация_расходомера"].ToString();
                                Modifikaciya_CB.Items.Add(modif);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке модификаций: " + ex.Message);
            }
        }
        
        private void LoadDiameters(int reestrId, ComboBox Diametr_CB)
        {
            //Выборка по госреестру. С сортировкой по диаметру
            string query = "SELECT Диаметр FROM Диаметры WHERE гос_реестр_id = @id ORDER BY Диаметр";

            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("id", reestrId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            Diametr_CB.Items.Clear();
                            Diametr_CB.SelectedIndex = -1;

                            while (reader.Read())
                            {
                                int diameter = reader.GetInt32(0); // или reader["Диаметр"]
                                Diametr_CB.Items.Add(diameter);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке диаметров: " + ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Передача тегов в контроллер
        private void Next_B_Click(object sender, EventArgs e)
        {
            if (!Rashodomer1_Enabled && !Rashodomer2_Enabled && !Rashodomer3_Enabled && !Rashodomer4_Enabled && !Rashodomer5_Enabled && !Rashodomer6_Enabled)
            {
                MessageBox.Show("Не добавлено ни одного расходомера");
                return;
            }            

            //
            //Проверка правильности ввода
            //

            int counter = 1;
            try
            {
                float check;
                if (Rashodomer1_CB.Checked)
                    check = (float)Convert.ToDouble(Flow1_WeightImpulse_TB.Text);

                counter++;
                if (Rashodomer2_CB.Checked)
                    check = (float)Convert.ToDouble(Flow2_WeightImpulse_TB.Text);

                counter++;
                if (Rashodomer3_CB.Checked)
                    check = (float)Convert.ToDouble(Flow3_WeightImpulse_TB.Text);

                counter++;
                if (Rashodomer4_CB.Checked)
                    check = (float)Convert.ToDouble(Flow4_WeightImpulse_TB.Text);

                counter++;
                if (Rashodomer5_CB.Checked)
                    check = (float)Convert.ToDouble(Flow5_WeightImpulse_TB.Text);

                counter++;
                if (Rashodomer6_CB.Checked)
                    check = (float)Convert.ToDouble(Flow6_WeightImpulse_TB.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный формат веса импульса у расходомера №" + counter.ToString(), "Предупреждение", MessageBoxButtons.OK);
                return;
            }

            //
            //Подключение к контроллеру и передача значений
            //

            //Plc plc = new Plc(CpuType.S71200, "192.168.0.150", 0, 1);
            //plc.Open();

            
            UInt16 FlowmetersEnable = 0;

            //Если выбран один расходомер, взводиться нулевой бит, если выбрано два расходомера, то первый и т.д.
            //FlowmetersEnable |= (ushort)(1 << FlowCount-1);


            //FlowmetersEnable |= 1; - Выбран первый расходомер
            //FlowmetersEnable |= 2;
            //FlowmetersEnable |= 4;
            //FlowmetersEnable |= 8;
            //FlowmetersEnable |= 16;
            //FlowmetersEnable |= 32;

            if (Rashodomer1_CB.Checked)
            {
                FlowmetersEnable |= 1;
                Tags.rPulseWeight = (float)Convert.ToDouble(Flow1_WeightImpulse_TB.Text);
            }

            if (Rashodomer2_CB.Checked)
            {
                FlowmetersEnable |= 2;
                Tags.FE02_rPulseWeight = (float)Convert.ToDouble(Flow2_WeightImpulse_TB.Text);
            }

            if (Rashodomer3_CB.Checked)
            {
                FlowmetersEnable |= 4;
                Tags.FE03_rPulseWeight = (float)Convert.ToDouble(Flow3_WeightImpulse_TB.Text);
            }

            if (Rashodomer4_CB.Checked)
            {
                FlowmetersEnable |= 8;
                Tags.FE04_rPulseWeight = (float)Convert.ToDouble(Flow4_WeightImpulse_TB.Text);
            }

            if (Rashodomer5_CB.Checked)
            {
                FlowmetersEnable |= 16;
                Tags.FE05_rPulseWeight = (float)Convert.ToDouble(Flow5_WeightImpulse_TB.Text);
            }

            if (Rashodomer6_CB.Checked)
            {
                FlowmetersEnable |= 32;
                Tags.FE06_rPulseWeight = (float)Convert.ToDouble(Flow6_WeightImpulse_TB.Text);
            }
                

            //MessageBox.Show(Convert.ToString(FlowmetersEnable, 2));

            Tags.wFlowmetersEnable = FlowmetersEnable;
            

            //1 2 4 8 16 32
            //НЕПРАВИЛЬНО. Расходомеры могут выбираться произвольно. А каждый бит отвечает отдельно за каждый расходомер. 100001 - первый и шестой расходомер в работе

            //MessageBox.Show(Convert.ToString(FlowmetersEnable));


            //plc.Write("DB20.DBD4", FlowmetersEnable);


            //float write
            //plc.Write("DB20.DBD0", value1);


            //
            //И надо организовать передачу значений расходмеров. Те что выбраны
            //

            //plc.Close();

            Third thirdForm = new Third();
            thirdForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Plc plc = new Plc(CpuType.S71200, "192.168.0.150", 0, 1);
            plc.Open();
            FlowmetersEnable_TB.Text = ((ushort)plc.Read(DataType.DataBlock, 20, 4, VarType.Word, 1)).ToString();
            plc.Close();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void Rashodomer1_CB_CheckedChanged(object sender, EventArgs e)
        {
            Rashodomer1_Enabled = Rashodomer1_CB.Checked;
            Rashodomer1_GB.Enabled = Rashodomer1_Enabled;
        }

        private void Flow1_Name_SI_CB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Rashodomer2_CB_CheckedChanged(object sender, EventArgs e)
        {
            Rashodomer2_Enabled = Rashodomer2_CB.Checked;
            Rashodomer2_GB.Enabled = Rashodomer2_Enabled;
        }

        private void Rashodomer3_CB_CheckedChanged(object sender, EventArgs e)
        {
            Rashodomer3_Enabled = Rashodomer3_CB.Checked;
            Rashodomer3_GB.Enabled = Rashodomer3_Enabled;
        }

        private void Rashodomer4_CB_CheckedChanged(object sender, EventArgs e)
        {
            Rashodomer4_Enabled = Rashodomer4_CB.Checked;
            Rashodomer4_GB.Enabled = Rashodomer4_Enabled;
        }

        private void Rashodomer5_CB_CheckedChanged(object sender, EventArgs e)
        {
            Rashodomer5_Enabled = Rashodomer5_CB.Checked;
            Rashodomer5_GB.Enabled = Rashodomer5_Enabled;
        }

        private void Rashodomer6_CB_CheckedChanged(object sender, EventArgs e)
        {
            Rashodomer6_Enabled = Rashodomer6_CB.Checked;
            Rashodomer6_GB.Enabled = Rashodomer6_Enabled;
        }        
    }
}