using System.ComponentModel;

namespace Kana.Model.Enums
{
    public enum SheetType
    {
        [Description("Kana questions Romaji answers")]
        Kana = 1,
        [Description("Romaji questions Kana answers")]
        Romaji = 2,
        [Description("Kana and Romaji questions shuffled")]
        Combined = 3,
        [Description("Alternate rows")]
        Alternate = 4,
    }
}