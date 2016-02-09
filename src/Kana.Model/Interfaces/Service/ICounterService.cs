using Kana.Model.Entities;

namespace Kana.Model.Interfaces.Service
{
    public interface ICounterService
    {
        Counter GetCounter(string name);
        void SetCounter(Counter counter);
        int Increment(string name);
        void Reset(string name);
    }
}