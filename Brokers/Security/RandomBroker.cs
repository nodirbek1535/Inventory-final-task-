//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================

using System;
using System.Security.Cryptography;

namespace Inventory_final_task_.Brokers.Security
{
    public class RandomBroker : IRandomBroker
    {
        public string GenerateString(int length)
        {
            byte[] bytes = RandomNumberGenerator.GetBytes(length);
            return Convert.ToBase64String(bytes);
        }
    }
}
