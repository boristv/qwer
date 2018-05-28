using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AncApi.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string nameSender { get; set; }
        public string nameGetter { get; set; }
        public string text { get; set; }
    }
}
