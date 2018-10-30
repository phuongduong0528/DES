using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DES.Ults;

namespace DES
{
    public class DESMain
    {
        DESModules modules;
        private string key;
        private string cipherText;
        private string decryptedText;
        public int[][] roundKeys;

        public DESMain(string key)
        {
            this.key = key;
            cipherText = "";
            decryptedText = "";
            roundKeys = new int[16][];
        }

        public void Create()
        {
            modules = new DESModules();
            roundKeys = modules.GenerateRoundKey(modules.HexStringToIntArray(key));
        }

        public void Encrypt(string hexString)
        {
            int[] binArray = modules.HexStringToIntArray(hexString);

            modules.InitialPermutation(ref binArray);
            int[] left = modules.SubArray(binArray, 0, 31);
            int[] right = modules.SubArray(binArray, 32, 63);

            for(int i = 0; i < 16; i++)
            {
                int[] outputF = new int[32];
                modules.Function(right, ref outputF, roundKeys[i]);
                left = modules.XOR(outputF, left);
                if (i < 15)
                    modules.Swap(ref left, ref right);
            }
            
            int[] final = new int[64];
            left.CopyTo(final, 0);
            right.CopyTo(final, 32);
            modules.FinalPermutation(ref final);
            cipherText = modules.BinArrayToHex(final);
        }

        public void Decrypt(string hexString)
        {
            int[] binArray = modules.HexStringToIntArray(hexString);

            modules.InitialPermutation(ref binArray);
            int[] left = modules.SubArray(binArray, 0, 31);
            int[] right = modules.SubArray(binArray, 32, 63);
            for (int i = 15; i >= 0; i--)
            {
                int[] outputF = new int[32];
                modules.Function(right, ref outputF, roundKeys[i]);
                left = modules.XOR(outputF, left);
                if (i > 0)
                    modules.Swap(ref left, ref right);
            }

            int[] final = new int[64];
            left.CopyTo(final, 0);
            right.CopyTo(final, 32);
            modules.FinalPermutation(ref final);
            decryptedText = modules.BinArrayToHex(final);
        }
    }
}
