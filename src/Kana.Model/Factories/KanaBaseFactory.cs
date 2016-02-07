using System.Collections.Generic;
using Kana.Model.Enums;

namespace Kana.Model.Factories
{
    public abstract class KanaBaseFactory
    {
        public abstract IList<KanaGroup> DefaultKana { get; }
        public abstract IList<KanaGroup> DakutenKana { get; }
        public abstract IList<KanaGroup> ComboKana { get; }

        public abstract IList<Entities.Kana> Kana(KanaGroup[] groups);
        public abstract IDictionary<KanaGroup, IList<Entities.Kana>> GroupedKana();
        public abstract IList<Entities.Kana> KanaByGroup(KanaGroup group);

    }
}