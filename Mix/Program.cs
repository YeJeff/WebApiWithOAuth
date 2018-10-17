using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Reflection;
using System.ComponentModel;
using System.Data;
using System.Net.Http;

namespace Mix
{
    public class Employees
    {
        public int id { get; set; }
        public int depid { get; set; }
        public string name { get; set; }
    }

    public class Department
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class Man
    {
        public string Name { get; set; } = "JK";
        public int Age { get; set; } = 30;
        private string _gender { get; set; } = "Male";

        public string Gender => _gender;

        public override string ToString() => "Man";

        public string From = "zh-cn";
    }
    class Program
    {

        public static bool PasswordValidate<T1, T2>(Func<T1, T2, bool> func, T1 pwd, T2 size)
        {
            return func(pwd, size);
        }

        static void Main(string[] args)
        {

            Guid gd = Guid.NewGuid();
            Console.WriteLine(gd.ToString());
            foreach (var ft in new[] {"N", "D", "", "P", "X" , "B"})
            {
                Console.WriteLine($"{ft} - {gd.ToString(ft)}");
            }


            string @string = "OK";

            Console.WriteLine(@string);

            return;


            WxPayData wxPayData = new WxPayData();

            var xml = @"<xml><appid><![CDATA[wxce8cc81beefb6a8f]]></appid>
                <bank_type><![CDATA[CFT]]></bank_type>
                <cash_fee><![CDATA[1]]></cash_fee>
                <fee_type><![CDATA[CNY]]></fee_type>
                <is_subscribe><![CDATA[Y]]></is_subscribe>
                <mch_id><![CDATA[1232482102]]></mch_id>
                <nonce_str><![CDATA[SWE1eUY25A5uNU6n]]></nonce_str>
                <openid><![CDATA[oPrM-uLKAoTjN9XcqesrctIUFsD4]]></openid>
                <out_trade_no><![CDATA[20180913172840416429]]></out_trade_no>
                <result_code><![CDATA[SUCCESS]]></result_code>
                <return_code><![CDATA[SUCCESS]]></return_code>
                <sign><![CDATA[B10C5F33BA8D2612035672AA3FB4CE27]]></sign>
                <time_end><![CDATA[20180913172845]]></time_end>
                <total_fee>1</total_fee>
                <trade_type><![CDATA[JSAPI]]></trade_type>
                <transaction_id><![CDATA[4200000160201809139715441647]]></transaction_id>
                </xml>";

            wxPayData.FromXml(xml);





            return;
            string noncestr = "AGjY2s5mhbayC2dSk2rPlwKluf20ZjsQ";
            string timestamp = "1535618735";
            string originalSignature = "fa8d635314a3ab746303c30dc995b09cd0a8fe23";
            string url = "http://192.168.81.67:8080/";

            string unencryStr = $"noncestr={noncestr}&timestamp={timestamp}&url={url}";

            unencryStr = "jsapi_ticket=bxLdikRXVbTPdHSM05e5uzEsX7gVA9LjIRUdaZKyQBcZpGnwARmunusWpuu3bmlK6baL_DkCKcd3cXXvuuFtow&nonceStr=a9d8f4bd-73f3-40fb-b9fc-f445528f97f7&timestamp=1535677533&url=https%3A%2F%2Fzqhd.chainew.com%2Fflowq%2Ffront%2Fshare%2FshareProductWxPage%3Fcode%3D023YK25F0aDSVk2wFb1F0ep15F0YK25N%26state%3D1015556%257C13138162543";

            string signature = Sha1Helper.Sha1Encrypter(unencryStr, Encoding.UTF8);

            string s1 = Sha1Helper.Sha1MangedEncryter(unencryStr, Encoding.UTF8);


            return;
            Md5Helper.Md5Encrypt32("asiapeak123", "MD5");

            return;

            List<Employees> emp = new List<Employees>()
            {
                new Employees {id = 1, depid = 1, name = "小李"},
                new Employees {id = 2, depid = 2, name = "小张"},
                new Employees {id = 3, depid = 3, name = "小陈"},
            };

            //b表
            List<Department> dept = new List<Department>()
            {
                new Department {id = 1, title = "财务"},
                new Department {id = 2, title = "人事"},
                new Department {id = 20, title = "行政"}
            };

            var query = from e in emp
                        join d in dept on e.depid equals d.id into ed
                        from x in ed.DefaultIfEmpty()
                        select new { e.name, x?.title };

            var query2 = from d in dept
                         join e in emp on d.id equals e.depid into ed
                         from x in ed.DefaultIfEmpty()
                         select new { x?.name, d.title };

            foreach (var obj in query2)
            {
                Console.WriteLine(JsonConvert.SerializeObject(obj, Formatting.Indented));
            }


            Man man = new Man();

            Console.WriteLine(JsonConvert.SerializeObject(man, Formatting.Indented));


            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(Man));
            for (int idx = 0; idx < props.Count; idx++)
            {
                Console.WriteLine($"{props[idx].Name} {props[idx].DisplayName}");
            }

            foreach (var prop in typeof(Man).GetProperties())
            {

                Console.WriteLine($"{prop.GetType().Name} - {prop.PropertyType.Name}");
                Console.WriteLine($"{prop.Name} - {prop.GetValue(man)}");
            }

            Console.WriteLine(String.Format("OK", 10, 20, 30));

            FieldInfo[] fileds = typeof(Man).GetFields();

            foreach (var field in fileds)
            {
                Console.WriteLine(field.Name);
            }

            Console.ReadLine();


        }

    }
}
