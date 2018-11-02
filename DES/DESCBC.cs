using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    public class DESCBC : DESMain 
    {
        private string IV;
        private string cbcCipherText;
        private string cbcDecryptText;
        private List<int[]> block;

        public string CbcCipherText => cbcCipherText;
        public string CbcDecryptText => CbcDecryptText;

        public DESCBC(string key, string IV) : base(key)
        {
            this.IV = IV;
            cbcCipherText = "";
            block = new List<int[]>();
        }

        private void CBCSplit(string hex)
        {
            int[] input = modules.HexStringToBinArray(hex);
            for (int i = 0; i < (input.Length / 64); i++)
            {
                block.Add(modules.SubArray(input,i * 64, (i + 1) * 64 - 1));
            }
        }

        public void EncryptCBC(string hex)
        {
            CBCSplit(hex);
            int[] cbcRoundInput = block[0];
            int[] iv = modules.HexStringToBinArray(IV);
            cbcRoundInput = modules.XOR(cbcRoundInput, iv);
            Encrypt(modules.BinArrayToHex(cbcRoundInput, 16));
            cbcCipherText += CipherText;
            for(int i = 1; i < block.Count(); i++)
            {
                int[] prevOutput = modules.HexStringToBinArray(CipherText);
                cbcRoundInput = modules.XOR(block[i], prevOutput);
                Encrypt(modules.BinArrayToHex(cbcRoundInput, 16));
                cbcCipherText += CipherText;
            }
        }
        
        public void DecryptCBC(string hex)
        {
            CBCSplit(hex);
            int[] cbcRoundInput = block[0];
            int[] iv = modules.HexStringToBinArray(IV);
            cbcRoundInput = modules.XOR(cbcRoundInput, iv);
            Decrypt(modules.BinArrayToHex(cbcRoundInput, 16));
            cbcDecryptText += DecryptText;
            for (int i = 1; i < block.Count(); i++)
            {
                int[] prevOutput = modules.HexStringToBinArray(CipherText);
                cbcRoundInput = modules.XOR(block[i], prevOutput);
                Decrypt(modules.BinArrayToHex(cbcRoundInput, 16));
                cbcDecryptText += DecryptText;
            }
        }
    }
}
