using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Nethereum.ABI.Encoders;
using Nethereum.Web3.Accounts;
namespace nt.Shared.Constants.AccountAddresses
{
    public class TestEthAccounts
    {
        public TestEthAccounts()
        {
            Array.Copy(bytes, 0, PrivKeyByteArray, 0, bytes.Length);
            TesterAcct = new Account(PrivKeyByteArray);

        }
        public static byte[] PrivKeyByteArray = new byte[32];

        string TestEthAccountAddress = "0x12833d6fADd206dEd2fcE84936d8D78326AB8EfA";
        internal static string TestEthPrivateKey = "307F685A376C5BF8296B4BE1D3703F068315BCD3115280B52C4CA0F8BA83C474";
        readonly byte[] bytes = Encoding.UTF8.GetBytes(TestEthPrivateKey);
        public static Account TesterAcct { get; set; }
    }
}
