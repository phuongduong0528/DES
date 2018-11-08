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
        protected DESModules modules;
        protected string key;
        private string cipherText;
        private string decryptedText;
        private int[][] roundKeys;
        private string traceInit;
        private string traceFinal;
        private string[][] traceRound;
        private string cipherKey;

        public string CipherText => cipherText;
        public string DecryptText => decryptedText;
        public string TraceInit => traceInit;
        public string TraceFinal => traceFinal;
        public string CipherKey => cipherKey;
        public string[][] TraceRound => traceRound;

        public DESMain(string key)
        {
            this.key = key;
            cipherText = "";
            decryptedText = "";
            roundKeys = new int[16][];
            traceInit = "";
            traceFinal = "";
            cipherKey = "";
            traceRound = new string[16][];
        }

        public void Create()
        {
            modules = new DESModules();
            roundKeys = modules.GenerateRoundKey(modules.HexStringToBinArray(key));
            cipherKey = modules.CipherKey;
        }

        public void Encrypt(string hexString)
        {
            int[] binArray = modules.HexStringToBinArray(hexString);
            
            modules.InitialPermutation(ref binArray);
            traceInit = modules.BinArrayToHex(binArray,0);
            
            int[] left = modules.SubArray(binArray, 0, 31);
            int[] right = modules.SubArray(binArray, 32, 63);
            
            for(int i = 0; i < 16; i++)
            {
                int[] outputF = new int[32];

                modules.Function(right, ref outputF, roundKeys[i]);

                left = modules.XOR(outputF, left);

                if (i < 15)
                    modules.Swap(ref left, ref right);

                traceRound[i] = new string[]{modules.BinArrayToHex(left,8),
                                             modules.BinArrayToHex(right,8),
                                             modules.BinArrayToHex(roundKeys[i],12)};
            }
            
            int[] final = new int[64];
            left.CopyTo(final, 0);
            right.CopyTo(final, 32);
            traceFinal = modules.BinArrayToHex(final,0);

            modules.FinalPermutation(ref final);

            cipherText = modules.BinArrayToHex(final,0);
        }

        public void Decrypt(string hexString)
        {
            int[] binArray = modules.HexStringToBinArray(hexString);

            modules.InitialPermutation(ref binArray);
            traceInit = modules.BinArrayToHex(binArray, 0);

            int[] left = modules.SubArray(binArray, 0, 31);
            int[] right = modules.SubArray(binArray, 32, 63);
            for (int i = 15; i >= 0; i--)
            {
                int[] outputF = new int[32];
                modules.Function(right, ref outputF, roundKeys[i]);
                left = modules.XOR(outputF, left);

                if (i > 0)
                    modules.Swap(ref left, ref right);

                traceRound[Math.Abs(i-15)] = new string[]{modules.BinArrayToHex(left,8),
                                             modules.BinArrayToHex(right,8),
                                             modules.BinArrayToHex(roundKeys[i],12)};
            }

            int[] final = new int[64];
            left.CopyTo(final, 0);
            right.CopyTo(final, 32);
            traceFinal = modules.BinArrayToHex(final, 0);

            modules.FinalPermutation(ref final);
            decryptedText = modules.BinArrayToHex(final,0);
        }
    }
}
