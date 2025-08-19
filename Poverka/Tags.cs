using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Poverka
{    
    // Класс, хранящий значение тегов, для последующей передачи в контроллер
    // Типы должны строго соотвестовать
    // Целочисленные - UInt16
    // Вещественные - float
    // Переменные со временем отправляются в миллисекундах. (Uint32)


    public static class Tags
    {
        public static UInt16 wFlowmetersEnable = 0;
        public static float rGmax = 0;

        public static float rPulseWeight = 0;
        public static float FE02_rPulseWeight = 0;
        public static float FE03_rPulseWeight = 0;
        public static float FE04_rPulseWeight = 0;
        public static float FE05_rPulseWeight = 0;
        public static float FE06_rPulseWeight = 0;
        
        public static UInt16 wPointsEnable = 0;
        public static UInt16 Point0_iMeasurementNumber = 0;
        public static UInt16 Point1_iMeasurementNumber = 0;
        public static UInt16 Point2_iMeasurementNumber = 0;
        public static UInt16 Point3_iMeasurementNumber = 0;        
        
        public static float Point0_rFlowSetpoint = 0;
        public static float Point1_rFlowSetpoint = 0;
        public static float Point2_rFlowSetpoint = 0;
        public static float Point3_rFlowSetpoint = 0;

        public static UInt32 Point0_tmCalibrationTime = 0;
        public static UInt32 Point1_tmCalibrationTime = 0;
        public static UInt32 Point2_tmCalibrationTime = 0;
        public static UInt32 Point3_tmCalibrationTime = 0;

        public static float Point0_rPermissibleError = 0;
        public static float Point1_rPermissibleError = 0;
        public static float Point2_rPermissibleError = 0;
        public static float Point3_rPermissibleError = 0;
        
        //Отправить значения в контроллер
        public static void SendToPLC()
        {
            try
            {
                Plc plc = new Plc(CpuType.S71200, "192.168.0.150", 0, 1);
                plc.Open();
                
                //gMax
                plc.Write("DB20.DBD0", rGmax);
                //Выбранные расходомеры
                plc.Write("DB20.DBD4", wFlowmetersEnable);

                //Вес импульса
                plc.Write("DB20.DBD8", rPulseWeight);
                plc.Write("DB20.DBD286", FE02_rPulseWeight);
                plc.Write("DB20.DBD564", FE03_rPulseWeight);
                plc.Write("DB20.DBD842", FE04_rPulseWeight);
                plc.Write("DB20.DBD1120", FE05_rPulseWeight);
                plc.Write("DB20.DBD1398", FE06_rPulseWeight);

                //Количество поверочных точек будет одиннаковое для всех расходомеров
                plc.Write("DB20.DBD6", wPointsEnable);
                plc.Write("DB20.DBD284", wPointsEnable);
                plc.Write("DB20.DBD562", wPointsEnable);
                plc.Write("DB20.DBD840", wPointsEnable);
                plc.Write("DB20.DBD1118", wPointsEnable);
                plc.Write("DB20.DBD1396", wPointsEnable);

                //По хорошему, все что ниже указано, перенести в класс расходомер Flowmeter

                //
                //FE01
                //

                //Установка количество измерений для каждой поверочной точки 
                plc.Write("DB20.DBD12", Point0_iMeasurementNumber);
                plc.Write("DB20.DBD80", Point1_iMeasurementNumber);
                plc.Write("DB20.DBD148", Point2_iMeasurementNumber);
                plc.Write("DB20.DBD216", Point3_iMeasurementNumber);

                //Заданный расход
                plc.Write("DB20.DBD18", Point0_rFlowSetpoint);
                plc.Write("DB20.DBD86", Point1_rFlowSetpoint);
                plc.Write("DB20.DBD154", Point2_rFlowSetpoint);
                plc.Write("DB20.DBD222", Point3_rFlowSetpoint);

                //Время каждого измерения (сек). Но отправляем в контроллер в миллисекундах
                plc.Write("DB20.DBD14", Point0_tmCalibrationTime * 1000);
                plc.Write("DB20.DBD82", Point1_tmCalibrationTime * 1000);
                plc.Write("DB20.DBD150", Point2_tmCalibrationTime * 1000);
                plc.Write("DB20.DBD218", Point3_tmCalibrationTime * 1000);

                //Допустимая погрешность %
                plc.Write("DB20.DBD22", Point0_rPermissibleError);
                plc.Write("DB20.DBD90", Point1_rPermissibleError);
                plc.Write("DB20.DBD158", Point2_rPermissibleError);
                plc.Write("DB20.DBD226", Point3_rPermissibleError);


                //
                //FE02
                //

                //Установка количество измерений для каждой поверочной точки 
                plc.Write("DB20.DBD290", Point0_iMeasurementNumber);
                plc.Write("DB20.DBD358", Point1_iMeasurementNumber);
                plc.Write("DB20.DBD426", Point2_iMeasurementNumber);
                plc.Write("DB20.DBD494", Point3_iMeasurementNumber);

                //Заданный расход
                plc.Write("DB20.DBD296", Point0_rFlowSetpoint);
                plc.Write("DB20.DBD364", Point1_rFlowSetpoint);
                plc.Write("DB20.DBD432", Point2_rFlowSetpoint);
                plc.Write("DB20.DBD500", Point3_rFlowSetpoint);

                //Время каждого измерения (сек). Но отправляем в контроллер в миллисекундах
                plc.Write("DB20.DBD292", Point0_tmCalibrationTime * 1000);
                plc.Write("DB20.DBD360", Point1_tmCalibrationTime * 1000);
                plc.Write("DB20.DBD438", Point2_tmCalibrationTime * 1000);
                plc.Write("DB20.DBD496", Point3_tmCalibrationTime * 1000);

                //Допустимая погрешность %
                plc.Write("DB20.DBD300", Point0_rPermissibleError);
                plc.Write("DB20.DBD368", Point1_rPermissibleError);
                plc.Write("DB20.DBD436", Point2_rPermissibleError);
                plc.Write("DB20.DBD504", Point3_rPermissibleError);


                //
                //FE03
                //

                //Установка количество измерений для каждой поверочной точки 
                plc.Write("DB20.DBD568", Point0_iMeasurementNumber);
                plc.Write("DB20.DBD636", Point1_iMeasurementNumber);
                plc.Write("DB20.DBD704", Point2_iMeasurementNumber);
                plc.Write("DB20.DBD772", Point3_iMeasurementNumber);

                //Заданный расход
                plc.Write("DB20.DBD574", Point0_rFlowSetpoint);
                plc.Write("DB20.DBD642", Point1_rFlowSetpoint);
                plc.Write("DB20.DBD710", Point2_rFlowSetpoint);
                plc.Write("DB20.DBD778", Point3_rFlowSetpoint);

                //Время каждого измерения (сек). Но отправляем в контроллер в миллисекундах
                plc.Write("DB20.DBD570", Point0_tmCalibrationTime * 1000);
                plc.Write("DB20.DBD638", Point1_tmCalibrationTime * 1000);
                plc.Write("DB20.DBD706", Point2_tmCalibrationTime * 1000);
                plc.Write("DB20.DBD774", Point3_tmCalibrationTime * 1000);

                //Допустимая погрешность %
                plc.Write("DB20.DBD578", Point0_rPermissibleError);
                plc.Write("DB20.DBD646", Point1_rPermissibleError);
                plc.Write("DB20.DBD714", Point2_rPermissibleError);
                plc.Write("DB20.DBD782", Point3_rPermissibleError);


                //
                //FE04
                //

                //Установка количество измерений для каждой поверочной точки 
                plc.Write("DB20.DBD846", Point0_iMeasurementNumber);
                plc.Write("DB20.DBD914", Point1_iMeasurementNumber);
                plc.Write("DB20.DBD982", Point2_iMeasurementNumber);
                plc.Write("DB20.DBD1050", Point3_iMeasurementNumber);

                //Заданный расход
                plc.Write("DB20.DBD852", Point0_rFlowSetpoint);
                plc.Write("DB20.DBD920", Point1_rFlowSetpoint);
                plc.Write("DB20.DBD988", Point2_rFlowSetpoint);
                plc.Write("DB20.DBD1056", Point3_rFlowSetpoint);

                //Время каждого измерения (сек). Но отправляем в контроллер в миллисекундах
                plc.Write("DB20.DBD848", Point0_tmCalibrationTime * 1000);
                plc.Write("DB20.DBD916", Point1_tmCalibrationTime * 1000);
                plc.Write("DB20.DBD984", Point2_tmCalibrationTime * 1000);
                plc.Write("DB20.DBD1052", Point3_tmCalibrationTime * 1000);

                //Допустимая погрешность %
                plc.Write("DB20.DBD856", Point0_rPermissibleError);
                plc.Write("DB20.DBD924", Point1_rPermissibleError);
                plc.Write("DB20.DBD992", Point2_rPermissibleError);
                plc.Write("DB20.DBD1060", Point3_rPermissibleError);


                //
                //FE05
                //

                //Установка количество измерений для каждой поверочной точки 
                plc.Write("DB20.DBD1124", Point0_iMeasurementNumber);
                plc.Write("DB20.DBD1192", Point1_iMeasurementNumber);
                plc.Write("DB20.DBD1260", Point2_iMeasurementNumber);
                plc.Write("DB20.DBD1328", Point3_iMeasurementNumber);

                //Заданный расход
                plc.Write("DB20.DBD1130", Point0_rFlowSetpoint);
                plc.Write("DB20.DBD1198", Point1_rFlowSetpoint);
                plc.Write("DB20.DBD1266", Point2_rFlowSetpoint);
                plc.Write("DB20.DBD1334", Point3_rFlowSetpoint);

                //Время каждого измерения (сек). Но отправляем в контроллер в миллисекундах
                plc.Write("DB20.DBD1126", Point0_tmCalibrationTime * 1000);
                plc.Write("DB20.DBD1194", Point1_tmCalibrationTime * 1000);
                plc.Write("DB20.DBD1262", Point2_tmCalibrationTime * 1000);
                plc.Write("DB20.DBD1330", Point3_tmCalibrationTime * 1000);

                //Допустимая погрешность %
                plc.Write("DB20.DBD1134", Point0_rPermissibleError);
                plc.Write("DB20.DBD1202", Point1_rPermissibleError);
                plc.Write("DB20.DBD1270", Point2_rPermissibleError);
                plc.Write("DB20.DBD1338", Point3_rPermissibleError);


                //
                //FE06
                //

                //Установка количество измерений для каждой поверочной точки 
                plc.Write("DB20.DBD1402", Point0_iMeasurementNumber);
                plc.Write("DB20.DBD1470", Point1_iMeasurementNumber);
                plc.Write("DB20.DBD1538", Point2_iMeasurementNumber);
                plc.Write("DB20.DBD1606", Point3_iMeasurementNumber);

                //Заданный расход
                plc.Write("DB20.DBD1408", Point0_rFlowSetpoint);
                plc.Write("DB20.DBD1476", Point1_rFlowSetpoint);
                plc.Write("DB20.DBD1544", Point2_rFlowSetpoint);
                plc.Write("DB20.DBD1612", Point3_rFlowSetpoint);

                //Время каждого измерения (сек). Но отправляем в контроллер в миллисекундах
                plc.Write("DB20.DBD1404", Point0_tmCalibrationTime * 1000);
                plc.Write("DB20.DBD1472", Point1_tmCalibrationTime * 1000);
                plc.Write("DB20.DBD1540", Point2_tmCalibrationTime * 1000);
                plc.Write("DB20.DBD1608", Point3_tmCalibrationTime * 1000);

                //Допустимая погрешность %
                plc.Write("DB20.DBD1412", Point0_rPermissibleError);
                plc.Write("DB20.DBD1480", Point1_rPermissibleError);
                plc.Write("DB20.DBD1548", Point2_rPermissibleError);
                plc.Write("DB20.DBD1616", Point3_rPermissibleError);


                plc.Close();    
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);                
            }
            
            //float
            //float value1 = (float)Convert.ToDouble(textBox4.Text);
            //plc.Write("DB20.DBD0", value1);

            //word
            //UInt16 value2 = Convert.ToUInt16(textBox4.Text);
            //plc.Write("DB3.DBD68", value2);
        }

        //Чтение данных с контроллера и формирование списка
        public static List<Flowmeter> GetFromPLC()
        {
            try
            {
                Plc plc = new Plc(CpuType.S71200, "192.168.0.150", 0, 1);
                plc.Open();

                //xCheckingStartBtn
                //Запуск поверки
                //plc.Write("DB15.DBX1.1", 1);

                //(UInt32)plc.Read(DataType.DataBlock, 20, 14, VarType.DWord, 1);
                //

                //Если имется расходомер, реализуем конструктор, в противном случае null

                Flowmeter FE01 = (wFlowmetersEnable & 1) == 1? new Flowmeter(1, 26, plc) : null;
                Flowmeter FE02 = (wFlowmetersEnable & 2) == 2 ? new Flowmeter(2, 304, plc) : null;
                Flowmeter FE03 = (wFlowmetersEnable & 4) == 4 ? new Flowmeter(3, 582, plc) : null;
                Flowmeter FE04 = (wFlowmetersEnable & 8) == 8 ? new Flowmeter(4, 860, plc) : null;
                Flowmeter FE05 = (wFlowmetersEnable & 16) == 16 ? new Flowmeter(5, 1138, plc) : null;
                Flowmeter FE06 = (wFlowmetersEnable & 32) == 32 ? new Flowmeter(6, 1416, plc) : null;
                
                //MessageBox.Show(FE06.Point0_Calc0_rCalibratingFlow.ToString() + "|" + FE06.Point0_Calc0_rCheckingFlow.ToString() + "|" + FE06.Point0_Calc0_rError.ToString() + "|" + FE06.Point0_Calc0_tmCheckingTime.ToString());

                plc.Close();

                return new List<Flowmeter>() { FE01, FE02, FE03, FE04, FE05, FE06 };

            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                return null;
            }            
        }
    }
}