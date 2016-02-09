using System.Runtime.Serialization;

namespace Kana.Model.Entities
{
    [DataContract]
    public class Counter
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Count { get; set; }

        public void Increment()
        {
            Count += 1;
        }

        public void Reset()
        {
            Count = 0;
        }
    }
}