using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP380_B2_BlockWebAPI.Models
{

    public class BlockSummary
    {
        // TODO
        public DateTime Timedate { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public DateTime TimeStamp { get; internal set; }

        public BlockSummary(DateTime TimeStamp, string PreviousHash, string Hash)
        {
            this.Timedate = TimeStamp;
            this.PreviousHash = PreviousHash;
            this.Hash = Hash;
        }
                public BlockSummary()
        {
        }
    }
}
