using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ClarizenSSISIntegration
{
    internal class CsvParser : IDisposable
    {
        private readonly List<string> _headerFields;
        private TextReader _reader;
        private bool _readHeder;

        public CsvParser(TextReader reader)
        {
            _reader = reader;
            _headerFields = new List<string>();
            CurrentDic = new Dictionary<string, string>();
        }

        public IEnumerable<string> HeaderFields
        {
            get { return _headerFields; }
        }


        public Dictionary<string, string> CurrentDic { get; private set; }

        private void ReadHeader()
        {
            var header = _reader.ReadLine();
            var headerDic = new Dictionary<string, string>();
            Debug.Assert(header != null, "header != null");
            foreach (var field in header.Split(','))
            {
                _headerFields.Add(field);
                headerDic.Add(field, field);
            }
            _readHeder = true;
        }

        public bool ReadNextRecord()
        {
            if (!_readHeder)
                ReadHeader();

            var line = _reader.ReadLine();
            CurrentDic=new Dictionary<string, string>();
            if (line != null)
            {
                var splitedLine = line.Split(',');
                var i = 0;
                foreach (var fName in _headerFields)
                {
                    CurrentDic.Add(fName, splitedLine[i]);
                    i++;
                }

                return true;
            }
            
            return false;
        }

        public void Dispose()
        {
            if (_reader != null)
            {
                _reader.Dispose();
                _reader = null;
            }
        }
    }
}