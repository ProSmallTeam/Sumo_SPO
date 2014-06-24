using System.Runtime.Serialization;

namespace WCF_Exploration
{
    [DataContract]
    public class ProductContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public MoneyContract UnitPrice { get; set; }
    }
}