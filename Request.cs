using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA23101205
{
    class Request
    {
        public string Address { get; set; }
        public bool HaveDomain => !char.IsDigit(Address.Last());
        public DateTime TimeStamp { get; set; }
        public string File { get; set; }
        public int Status { get; set; }
        public int ByteSize { get; set; }

        public Request(string row)
        {
            var splts = row.Split('*');
            Address = splts[0];
            var d = splts[1].Split('/', ':');
            TimeStamp = DateTime.Parse($"{d[2]}-{d[1]}-{d[0]} {d[3]}:{d[4]}:{d[5]}");
            File = splts[2];
            var srv = splts[3].Split(' ');
            Status = int.Parse(srv[0]);
            ByteSize = srv[1] == "-" ? 0 : int.Parse(srv[1]);
        }
    }
}
