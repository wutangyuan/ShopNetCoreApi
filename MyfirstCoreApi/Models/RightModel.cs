using System;
using System.Collections.Generic;

namespace MyfirstCoreApi.Models
{
    public class RightModel
    {
        public RightModel()
        {
        }

        public List<RightDetail> data { get; set; } = new List<RightDetail>();

        public Meta meta { get; set; } = new Meta();

    }

    public class RightDetail
    {
        public int id { get; set; }

        public string authName { get; set; }

        public string level { get; set; } = "0";

        public int pid { get; set; }

        public string path { get; set; }

    }


}
