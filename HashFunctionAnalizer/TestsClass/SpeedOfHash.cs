using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace HashFunctionAnalizer.TestsClass
{
    class SpeedOfHash
    {
        public HashAlgorithm Alghorithm { get; set; }
        public string HashName { get; set; }
        public byte[] SomeData { get; set; }
        public int DataSize { get; set; }
    
        public void RunTest()
        {
            HashFunctionAnalizerForm hFA = new HashFunctionAnalizerForm();
            hFA.SpeedCounting(Alghorithm, HashName, SomeData, DataSize);
        }
    }
}
