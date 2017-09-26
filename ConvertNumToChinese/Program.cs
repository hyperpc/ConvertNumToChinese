using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace ConvertNumToChinese
{
    class Program
    {
        static string ConvertToChinese(decimal numbers)
        {
            string str = numbers.ToString("#L#E#D#C#K#E#D#C#J#E#D#C#I#E#D#C#H#E#D#C#G#E#D#C#F#E#D#C#.0B0A");
            string dec = Regex.Replace(str, @"((?<=-|^)[^1-9]*)|((?'z'0)[0A-E]*((?=[1-9])|(?'-z'(?=[F-L\.]|$))))|((?'b'[F-L])(?'z'0)[0A-L]*((?=[1-9])|(?'-z'(?=[\.]|$))))", "${b}${z}");
            //return Regex.Replace(dec, ".", delegate(Match match) { return "负元空零壹贰叁肆伍陆柒捌玖空空空空空空空分角拾佰仟萬億兆京垓秭穰"[match.Value[0] - '-'].ToString(); });
            return Regex.Replace(dec, ".", delegate(Match match) { return "负元空零壹贰叁肆伍陆柒捌玖空空空空空空空分角拾佰仟萬億兆京垓杼穰沟涧正载极恒河沙阿僧祗那由他不可思议无量大数"[match.Value[0] - '-'].ToString(); });
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                double x = random.Next() / 100.0;
                //double x = random.Next() * 100 + 0.66;//test overflow
                Console.WriteLine("{0,14:N2}:{1}", x, ConvertToChinese(decimal.Parse(x.ToString())));
            }
            Console.ReadKey();
        }
    }
}
