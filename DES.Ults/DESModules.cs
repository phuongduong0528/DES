using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES.Ults
{
    public class DESModules
    {
        public int[] XOR(int[] arg1, int[] arg2)
        {
            int[] re = new int[arg1.Length];
            for(int i = 0; i < arg1.Length; i++)
            {
                if (arg1[i] + arg2[i] == 1)
                    re[i] = 1;
                else
                    re[i] = 0;
            }
            return re;
        }

        private string HexStringToBinString(string hex)
        {
            string result = "";
            result = string.Join(string.Empty, hex.Select(h => 
                                    Convert.ToString(
                                        Convert.ToInt32(h.ToString(), 16), 2
                                        ).PadLeft(4, '0')));
            return result;
        }

        private int[] BinStringToBinArray(string bin)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < bin.Length; i++)
            {
                result.Add(int.Parse(bin[i].ToString()));
            }
            return result.ToArray();
        }

        public int[] HexStringToBinArray(string hex)
        {
            return BinStringToBinArray(HexStringToBinString(hex));
        }

        public string BinArrayToHex(int[] bin, int padding)
        {
            string re = string.Empty;
            for (int i = 0; i < bin.Length; i++)
            {
                re += bin[i].ToString();
            }
            if(padding == 8)
            {
                return Convert.ToUInt64(re, 2).ToString("X8");
            }
            if(padding == 12)
            {
                return Convert.ToUInt64(re, 2).ToString("X12");
            }
            else
            {
                return Convert.ToUInt64(re, 2).ToString("X16");
            }
        }

        public int[] SubArray(int[] src,int start, int end)
        {
            int[] temp = new int[end-start+1];
            int index = 0;
            for (int i = start; i <= end; i++)
            {
                temp[index] = src[i];
                index++;
            }
            return temp;
        }

        public int[][] GenerateRoundKey(int[] keys)
        {
            int[][] result = new int[16][];
            int[] tempkey = new int[56];
            int[] leftTempKey = new int[28];
            int[] rightTempKey= new int[28];
            int[] roundkey;
            Permute(keys, ref tempkey, DESConstants.ParityBitDrop);
            for (int i = 0; i < 16; i++)
            {
                roundkey = new int[48];
                leftTempKey = SubArray(tempkey, 0, 27);
                rightTempKey = SubArray(tempkey, 28, 55);
                ShiftLeft(ref leftTempKey, DESConstants.ScheduleBitShift[i]);
                ShiftLeft(ref rightTempKey, DESConstants.ScheduleBitShift[i]);
                tempkey = new int[56];
                leftTempKey.CopyTo(tempkey, 0);
                rightTempKey.CopyTo(tempkey, 28);
                Permute(tempkey, ref roundkey, DESConstants.KeyCompressionTable);
                result[i] = roundkey;
            }
            return result;
        }

        public void ShiftLeft(ref int[] block, int numberOfShifts)
        {
            int temp;
            for (int i = 0; i < numberOfShifts; i++)
            {
                temp = block[0];
                for (int j = 1; j < block.Length; j++)
                {
                    block[j - 1] = block[j];
                }
                block[block.Length-1] = temp;
            }
        }

        public void Swap(ref int[] leftBlock, ref int[] rightBlock)
        {
            int[] temp = leftBlock;
            leftBlock = rightBlock;
            rightBlock = temp;
        }

        public void Permute(int[] input, ref int[] output, int[] ptable)
        {
            for (int i = 0; i < ptable.Length; i++)
            {
                output[i] = input[ptable[i]-1];
            }
        }

        private void SubstituteRound(ref int[] inBlock, int[,] Sbox)
        {
            int temp = 3;
            int row = 0;
            int column = 0;
            for (int i = 1; i <= 4; i++)
            {
                column += inBlock[i] * (int)Math.Pow(2, temp);
                temp--;
            }
            row = 2 * inBlock[0] + inBlock[5];
            inBlock = HexStringToBinArray(Convert.ToString(Sbox[row, column], 16));
        }
        
        private void Substitude(int[] inputBlock, ref int[] outputBlock)
        {
            int[] temp;
            int[] result = new int[32];
            int[][,] Sboxs = new int[][,] {DESConstants.Sbox1,DESConstants.Sbox2,DESConstants.Sbox3,DESConstants.Sbox4,
                                           DESConstants.Sbox5,DESConstants.Sbox6,DESConstants.Sbox7,DESConstants.Sbox8};
            for (int i = 0; i < 8; i++)
            {
                temp = SubArray(inputBlock, i * 6, (i + 1) * 6 - 1);
                SubstituteRound(ref temp, Sboxs[i]);
                temp.CopyTo(result, i*4);
            }

            outputBlock = result;
        }

        public void InitialPermutation(ref int[] input)
        {
            int[] temp = new int[64];
            Permute(input, ref temp, DESConstants.InitialPermutation);
            input = temp;
        }

        public void FinalPermutation(ref int[] input)
        {
            int[] temp = new int[64];
            Permute(input, ref temp, DESConstants.FinalPermutation);
            input = temp;
        }

        public void Function(int[] rightInput, ref int[] output, int[] roundKey)
        {
            int[] temp = new int[48];
            int[] temp2 = new int[32];
            int[] temp3 = new int[32];
            Permute(rightInput, ref temp, DESConstants.ExpansionPermutation);
            temp = XOR(temp, roundKey);
            Substitude(temp, ref temp2);
            Permute(temp2, ref temp3, DESConstants.StraightPermutation);
            output = temp3;
        }
    }
}
