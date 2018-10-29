//===================================================================================================//
//                                         *UNFINISHED WORK*                                         //
//===================================================================================================//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DES.Ults;

namespace DES
{
    public class DES
    {
        DESModules modules;
        private string key;
        private string cipherText;
        private string decriptedText;
        private int[][] roundKeys;

        public DES(string key)
        {
            this.key = key;
            cipherText = "";
            decriptedText = "";
            roundKeys = new int[16][];
        }

        public void Create()
        {
            modules = new DESModules();
            roundKeys = modules.GenerateRoundKey(modules.BinStringToIntArray(modules.HexToBin(key)));
        }

        public string Encript(string hexString)
        {
            string result = "";
            int[] binArray = modules.BinStringToIntArray(modules.HexToBin(hexString));
            int[] temp;
            return result;
        }
    }
}
