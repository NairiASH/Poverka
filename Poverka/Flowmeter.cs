using S7.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poverka
{
    public class Flowmeter
    {        
        public List<float> calibratingFlows = new List<float>();
        public List<float> checkingFlows = new List<float>();
        public List<float> errors = new List<float>();
        public List<UInt32> checkingTimes = new List<UInt32>();

        private int StartAdress;

        public float Point0_Calc0_rCalibratingFlow = 0;
        public float Point0_Calc0_rCheckingFlow = 0;
        public float Point0_Calc0_rError = 0;
        public UInt32 Point0_Calc0_tmCheckingTime = 0;

        public float Point0_Calc1_rCalibratingFlow = 0;
        public float Point0_Calc1_rCheckingFlow = 0;
        public float Point0_Calc1_rError = 0;
        public UInt32 Point0_Calc1_tmCheckingTime = 0;

        public float Point0_Calc2_rCalibratingFlow = 0;
        public float Point0_Calc2_rCheckingFlow = 0;
        public float Point0_Calc2_rError = 0;
        public UInt32 Point0_Calc2_tmCheckingTime = 0;

        public float Point1_Calc0_rCalibratingFlow = 0;
        public float Point1_Calc0_rCheckingFlow = 0;
        public float Point1_Calc0_rError = 0;
        public UInt32 Point1_Calc0_tmCheckingTime = 0;

        public float Point1_Calc1_rCalibratingFlow = 0;
        public float Point1_Calc1_rCheckingFlow = 0;
        public float Point1_Calc1_rError = 0;
        public UInt32 Point1_Calc1_tmCheckingTime = 0;

        public float Point1_Calc2_rCalibratingFlow = 0;
        public float Point1_Calc2_rCheckingFlow = 0;
        public float Point1_Calc2_rError = 0;
        public UInt32 Point1_Calc2_tmCheckingTime = 0;

        public float Point2_Calc0_rCalibratingFlow = 0;
        public float Point2_Calc0_rCheckingFlow = 0;
        public float Point2_Calc0_rError = 0;
        public UInt32 Point2_Calc0_tmCheckingTime = 0;

        public float Point2_Calc1_rCalibratingFlow = 0;
        public float Point2_Calc1_rCheckingFlow = 0;
        public float Point2_Calc1_rError = 0;
        public UInt32 Point2_Calc1_tmCheckingTime = 0;

        public float Point2_Calc2_rCalibratingFlow = 0;
        public float Point2_Calc2_rCheckingFlow = 0;
        public float Point2_Calc2_rError = 0;
        public UInt32 Point2_Calc2_tmCheckingTime = 0;

        public float Point3_Calc0_rCalibratingFlow = 0;
        public float Point3_Calc0_rCheckingFlow = 0;
        public float Point3_Calc0_rError = 0;
        public UInt32 Point3_Calc0_tmCheckingTime = 0;

        public float Point3_Calc1_rCalibratingFlow = 0;
        public float Point3_Calc1_rCheckingFlow = 0;
        public float Point3_Calc1_rError = 0;
        public UInt32 Point3_Calc1_tmCheckingTime = 0;

        public float Point3_Calc2_rCalibratingFlow = 0;
        public float Point3_Calc2_rCheckingFlow = 0;
        public float Point3_Calc2_rError = 0;
        public UInt32 Point3_Calc2_tmCheckingTime = 0;

        public Flowmeter(int number, int startAddress, Plc plc) 
        {
            Number = number;
            StartAdress = startAddress;
            FillData(plc);

            calibratingFlows.Add(Point0_Calc0_rCalibratingFlow);
            calibratingFlows.Add(Point0_Calc1_rCalibratingFlow);
            calibratingFlows.Add(Point0_Calc2_rCalibratingFlow);
            calibratingFlows.Add(Point1_Calc0_rCalibratingFlow);
            calibratingFlows.Add(Point1_Calc1_rCalibratingFlow);
            calibratingFlows.Add(Point1_Calc2_rCalibratingFlow);
            calibratingFlows.Add(Point2_Calc0_rCalibratingFlow);
            calibratingFlows.Add(Point2_Calc1_rCalibratingFlow);
            calibratingFlows.Add(Point2_Calc2_rCalibratingFlow);
            calibratingFlows.Add(Point3_Calc0_rCalibratingFlow);
            calibratingFlows.Add(Point3_Calc1_rCalibratingFlow);
            calibratingFlows.Add(Point3_Calc2_rCalibratingFlow);

            checkingFlows.Add(Point0_Calc0_rCheckingFlow);
            checkingFlows.Add(Point0_Calc1_rCheckingFlow);
            checkingFlows.Add(Point0_Calc2_rCheckingFlow);
            checkingFlows.Add(Point1_Calc0_rCheckingFlow);
            checkingFlows.Add(Point1_Calc1_rCheckingFlow);
            checkingFlows.Add(Point1_Calc2_rCheckingFlow);
            checkingFlows.Add(Point2_Calc0_rCheckingFlow);
            checkingFlows.Add(Point2_Calc1_rCheckingFlow);
            checkingFlows.Add(Point2_Calc2_rCheckingFlow);
            checkingFlows.Add(Point3_Calc0_rCheckingFlow);
            checkingFlows.Add(Point3_Calc1_rCheckingFlow);
            checkingFlows.Add(Point3_Calc2_rCheckingFlow);

            errors.Add(Point0_Calc0_rError);
            errors.Add(Point0_Calc1_rError);
            errors.Add(Point0_Calc2_rError);
            errors.Add(Point1_Calc0_rError);
            errors.Add(Point1_Calc1_rError);
            errors.Add(Point1_Calc2_rError);
            errors.Add(Point2_Calc0_rError);
            errors.Add(Point2_Calc1_rError);
            errors.Add(Point2_Calc2_rError);
            errors.Add(Point3_Calc0_rError);
            errors.Add(Point3_Calc1_rError);
            errors.Add(Point3_Calc2_rError);

            checkingTimes.Add(Point0_Calc0_tmCheckingTime);
            checkingTimes.Add(Point0_Calc1_tmCheckingTime);
            checkingTimes.Add(Point0_Calc2_tmCheckingTime);
            checkingTimes.Add(Point1_Calc0_tmCheckingTime);
            checkingTimes.Add(Point1_Calc1_tmCheckingTime);
            checkingTimes.Add(Point1_Calc2_tmCheckingTime);
            checkingTimes.Add(Point2_Calc0_tmCheckingTime);
            checkingTimes.Add(Point2_Calc1_tmCheckingTime);
            checkingTimes.Add(Point2_Calc2_tmCheckingTime);
            checkingTimes.Add(Point3_Calc0_tmCheckingTime);
            checkingTimes.Add(Point3_Calc1_tmCheckingTime);
            checkingTimes.Add(Point3_Calc2_tmCheckingTime);
        }

        public void FillData(Plc plc)
        {
            try
            {                                                
                //Первая точка
                Point0_Calc0_rCalibratingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point0_Calc0_rCheckingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point0_Calc0_rError = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point0_Calc0_tmCheckingTime = (UInt32)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.DWord, 1);
                StartAdress += 6;

                Point0_Calc1_rCalibratingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point0_Calc1_rCheckingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point0_Calc1_rError = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point0_Calc1_tmCheckingTime = (UInt32)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.DWord, 1);
                StartAdress += 6;

                Point0_Calc2_rCalibratingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point0_Calc2_rCheckingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point0_Calc2_rError = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point0_Calc2_tmCheckingTime = (UInt32)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.DWord, 1);
                StartAdress += 20;

                //Вторая точка
                Point1_Calc0_rCalibratingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point1_Calc0_rCheckingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point1_Calc0_rError = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point1_Calc0_tmCheckingTime = (UInt32)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.DWord, 1);
                StartAdress += 6;

                Point1_Calc1_rCalibratingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point1_Calc1_rCheckingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point1_Calc1_rError = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point1_Calc1_tmCheckingTime = (UInt32)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.DWord, 1);
                StartAdress += 6;

                Point1_Calc2_rCalibratingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point1_Calc2_rCheckingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point1_Calc2_rError = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point1_Calc2_tmCheckingTime = (UInt32)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.DWord, 1);
                StartAdress += 20;

                //Третья точка
                Point2_Calc0_rCalibratingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point2_Calc0_rCheckingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point2_Calc0_rError = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point2_Calc0_tmCheckingTime = (UInt32)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.DWord, 1);
                StartAdress += 6;

                Point2_Calc1_rCalibratingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point2_Calc1_rCheckingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point2_Calc1_rError = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point2_Calc1_tmCheckingTime = (UInt32)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.DWord, 1);
                StartAdress += 6;

                Point2_Calc2_rCalibratingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point2_Calc2_rCheckingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point2_Calc2_rError = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point2_Calc2_tmCheckingTime = (UInt32)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.DWord, 1);
                StartAdress += 20;

                //Четвертая точка
                Point3_Calc0_rCalibratingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point3_Calc0_rCheckingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point3_Calc0_rError = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point3_Calc0_tmCheckingTime = (UInt32)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.DWord, 1);
                StartAdress += 6;

                Point3_Calc1_rCalibratingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point3_Calc1_rCheckingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point3_Calc1_rError = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point3_Calc1_tmCheckingTime = (UInt32)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.DWord, 1);
                StartAdress += 6;

                Point3_Calc2_rCalibratingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point3_Calc2_rCheckingFlow = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point3_Calc2_rError = (float)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.Real, 1);
                StartAdress += 4;
                Point3_Calc2_tmCheckingTime = (UInt32)plc.Read(DataType.DataBlock, 20, StartAdress, VarType.DWord, 1);                               
            }
            catch(Exception E)
            {
                MessageBox.Show(E.Message);
            }                
        }
        
        public int Number { get; }
    }    
}