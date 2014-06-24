using System.Runtime.Serialization;

namespace WCF_Exploration
{
    [DataContract]
    public class MoneyContract
    {
        [DataMember]
        public decimal Amount { get; set; }

        [DataMember]
        public string CurrencyCode { get; set; }
    }
}