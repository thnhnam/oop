using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace bai_tap_ve_nha
{
    public class person
    {
        private string name;
        private string stid;
        private string lop;
        private string username;
        private string email;

        public person(string name, string stid, string lop, string username, string email)
        {
            this.name = name;
            this.stid = stid;
            this.lop = lop;
            this.username = username;
            this.email = email;
        }
        public void printinformation()
        {
            Console.WriteLine(name + '\t' + stid + '\t' + lop + '\t' + username + '\t' + email);
        }
    }
        internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            person ps = new person("Nguyễn Thế Thành Nam","12422013","12422TN","thnhnam","nguyenthethanhnam2232004@gmail.com");
            ps.printinformation();
            Console.ReadKey();
        }
    }
}
