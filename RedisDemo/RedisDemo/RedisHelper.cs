using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    public class RedisHelper
    {
        private static string _conn = "127.0.0.1:6379";


        public static double StringIncrement(string key, double number)
        {
            try
            {
                using (var client = ConnectionMultiplexer.Connect(_conn))
                {
                    return client.GetDatabase().StringIncrement(key, number);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static string StringGet(string key)
        {
            try
            {
                using (var client = ConnectionMultiplexer.Connect(_conn))
                {
                    return client.GetDatabase().StringGet(key);
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static void StringSet(string key, string value)
        {
            try
            {
                using (var client = ConnectionMultiplexer.Connect(_conn))
                {
                    client.GetDatabase().StringSet(key, value);
                }
            }
            catch (Exception)
            {
              
            }
        }
    }
}