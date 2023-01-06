using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit
{
    internal class Transaction
    {
        [Index(0)] public string OriginBankCode { get; set; }
        [Index(1)] public string OriginBranch { get; set; }
        [Index(2)] public string OriginNumber { get; set; }
        [Index(3)] public string TargetBankCode { get; set; }
        [Index(4)] public string TargetBranch { get; set; }
        [Index(5)] public string TargetNumber { get; set; }
        [Index(6)] public string Type { get; set; }

        public decimal Value { get; set; }

        public Transaction(string OriginBankCode, string OriginBranch, string OriginNumber, string TargetBankCode, string TargetBranch, string TargetNumber, string Type, decimal Value) {
            this.OriginBankCode = OriginBankCode;
            this.OriginNumber = OriginNumber;
            this.OriginBranch = OriginBranch;
            this.TargetBankCode = TargetBankCode;
            this.TargetNumber = TargetNumber;
            this.TargetBranch = TargetBranch;
            this.Type = Type;
            this.Value = Value;
        }
    }
}
