using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FundDataMaintenance.Models
{
    public class UmbrellaIndexVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Custodian { get; set; }
        public bool Active { get; set; }
        public int ActiveFundCount { get; set; }
    }
}