using Kana.Model.Enums;

namespace Kana.Model.Entities
{
    public class Kana
    {
        public string Html { get; set; } 
        public string Romaji { get; set; }
        public KanaGroup Group { get; set; }
    }
}