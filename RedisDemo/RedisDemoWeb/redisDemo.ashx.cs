using RedisDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedisDemoWeb
{
    /// <summary>
    /// redisDemo 的摘要说明
    /// </summary>
    public class redisDemo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //是否中奖
            bool isDraw = false;
            Random ran = new Random();
            int RandKey = ran.Next(1, 100);
            if (RandKey > 0)
            {
                isDraw = true;
            }

            if (isDraw)
            {
                //获取库存
                //var result = Convert.ToInt32(RedisHelper.StringGet("draw"));
                //result--;
                //RedisHelper.StringSet("draw", result.ToString());
                var result = RedisHelper.StringIncrement("draw", -1);

                if (result < 0)
                {
                    //库存不足
                    context.Response.Write("谢谢参与");
                }
                else
                {
                    //记录中奖总数
                    RedisHelper.StringIncrement("drawnumber", 1);
                    context.Response.Write("中奖了");
                }
            }
            else
            {
                //未中奖
                context.Response.Write("谢谢参与");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}