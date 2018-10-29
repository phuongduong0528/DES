using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DES.Ults;
using DES;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DES.DES a = new DES.DES("aabb09182736ccdd");
            DESModules m = new DESModules();
            a.Create();
            string res = a.Encrypt("123456abcd132536");


            int[] l = m.HexStringToIntArray("5a78e394");
            int[] cpy = l;
            int[] r = m.HexStringToIntArray("4a1210f6");
            int[] temp = new int[32];
            m.Function(r, ref temp, a.roundKeys[2]);
            string testkey = m.BinArrayToHex(a.roundKeys[2]);
            int[] t2 = m.XOR(cpy, temp);
            string test = m.BinArrayToHex(t2);
        }
    }
}
