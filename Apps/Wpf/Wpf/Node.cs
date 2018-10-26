using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Wpf
{
    class Node
    {
        [JsonProperty("nid")]
        public int NodeId { get; set; }

        [JsonProperty("uri")]
        public Uri Uri { get; set; }
    }
}
