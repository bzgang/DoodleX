using DoodleX.Models;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoodleX.utilsClass
{
    public class JwtIdentity
    {
        //私钥 
        private static string secret = "BopopioqweHGBFFAUYIYAasdkaksdZooioiG";

        /// <summary>
        /// 生成JwtToken
        /// </summary>
        /// <param name="payload">不敏感的用户数据</param>
        /// <returns></returns>
        public static string SetJwtEncode(Dictionary<string, object> payload)
        {

            //格式如下
            //var payload = new Dictionary<string, object>
            //{
            //    { "username","admin" },
            //    { "pwd", "claim2-value" }
            //};

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            payload.Add("timeout", DateTime.Now.AddDays(1));  //token过期时间

            var token = encoder.Encode(payload, secret);
            return token;
        }

        /// <summary>
        /// 根据jwtToken  获取实体
        /// </summary>
        /// <param name="token">jwtToken</param>
        /// <returns></returns>
        public static string GetJwtDecode(string token)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
                //token为之前生成的字符串
                var userInfo = decoder.DecodeToObject(token, secret, verify: true);
                //此处json为IDictionary<string, object> 类型
                string username = userInfo["username"].ToString();  //可获取当前用户名
                DateTime timeout = (DateTime)userInfo["timeout"];  //获取token过期时间
                if (timeout < DateTime.Now)
                {
                    throw new TokenExpiredException("Token过期，请重新登陆");
                }
                userInfo.Remove("timeout");
                return "OK";
            }
            catch (TokenExpiredException tokenEx)
            {
                return "[Error]Token过期:--" + tokenEx.Message;
            }
            catch (SignatureVerificationException tokenEx)
            {
                return "[Error] 无效的Token:--" + tokenEx.Message;
            }
            catch (Exception ex)
            {
                return "[Error]:" + ex.Message;
            }
        }
    }
}