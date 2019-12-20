using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailOperations.Models
{
    public class EmailViewModel
    {
        public string From { get; set; }
        public string Text { get; set; }
        public DateTime date { get; set; }
        public string MessageSubject { get; set; }


    }
}
