using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7.Net;

namespace Poverka
{
    public class Tag
    {
        string _Name, _Adress;
        int _DB, _Offset;

        int _ByteNumber; //В случае если переменная булевская

        VarType _Type;        

        //Конструктор с заданием адресса в виде строки
        public Tag(string name, string adress, VarType type)
        {
            _Name = name;
            _Adress = adress;
            _Type = type;            
        }

        //Конструктор с заданием адреса двумя числами
        public Tag(string name, int dB, int offset, VarType type)
        {
            _Name = name;            
            _DB = dB;
            _Offset = offset;
            _Type = type;            
        }

        //Конструктор с заданием адреса тремя числами (битовый тег)
        public Tag(string name, int dB, int offset, int bytenumber, VarType type)
        {
            _Name = name;
            _DB = dB;
            _Offset = offset;
            _ByteNumber = bytenumber;
            _Type = type;
        }

        public string Name
        {
            get { return _Name; }
        }

        public string Adress
        {
            get { return _Adress; }
        }

        public VarType Type
        {
            get { return _Type; }
        }

        //public override string ToString()
        //{
        //    if (StringAdressFormat)
        //        return _Name + " | " + _Adress + " | " + _Type;
        //    else
        //}
    }
}