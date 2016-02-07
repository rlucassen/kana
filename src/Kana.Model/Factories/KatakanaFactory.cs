using System;
using System.Collections.Generic;
using System.Linq;
using Kana.Model.Enums;
using Kana.Model.Helpers;

namespace Kana.Model.Factories
{
    public class KatakanaFactory : KanaBaseFactory
    {
        public override IList<KanaGroup> DefaultKana => new List<KanaGroup> { KanaGroup.Vowels, KanaGroup.K, KanaGroup.K, KanaGroup.S, KanaGroup.T, KanaGroup.N, KanaGroup.H, KanaGroup.M, KanaGroup.Y, KanaGroup.R, KanaGroup.W, KanaGroup.NN };
        public override IList<KanaGroup> DakutenKana => new List<KanaGroup> { KanaGroup.G, KanaGroup.Z, KanaGroup.D, KanaGroup.B, KanaGroup.P };
        public override IList<KanaGroup> ComboKana => new List<KanaGroup> { KanaGroup.Ky, KanaGroup.Sh, KanaGroup.Ch, KanaGroup.Ny, KanaGroup.Hy, KanaGroup.My, KanaGroup.Ry, KanaGroup.Gy, KanaGroup.Jy, KanaGroup.Dzy, KanaGroup.By, KanaGroup.Py };

        public override IList<Entities.Kana> Kana(KanaGroup[] groups)
        {
            if (groups.Length == 0)
            {
                var allGroups = new List<KanaGroup>();
                allGroups.AddRange(DefaultKana);
                allGroups.AddRange(DakutenKana);
                allGroups.AddRange(ComboKana);
                groups = allGroups.ToArray();
            }

            var list = new List<Entities.Kana>();

            foreach (var kanaGroup in groups)
            {
                list.AddRange(KanaByGroup(kanaGroup));
            }

            return list;
        }

        public override IDictionary<KanaGroup, IList<Entities.Kana>> GroupedKana()
        {
            var groups = EnumHelper.EnumToList<KanaGroup>().Where(x => x != KanaGroup.Empty);
            return groups.ToDictionary(group => group, KanaByGroup);
        }

        public override IList<Entities.Kana> KanaByGroup(KanaGroup group)
        {
            switch (group)
            {
                case KanaGroup.Empty:
                    return new List<Entities.Kana>();
                case KanaGroup.Vowels:
                    return KatakanaVowels();
                case KanaGroup.K:
                    return KatakanaK();
                case KanaGroup.S:
                    return KatakanaS();
                case KanaGroup.T:
                    return KatakanaT();
                case KanaGroup.N:
                    return KatakanaN();
                case KanaGroup.H:
                    return KatakanaH();
                case KanaGroup.M:
                    return KatakanaM();
                case KanaGroup.Y:
                    return KatakanaY();
                case KanaGroup.R:
                    return KatakanaR();
                case KanaGroup.W:
                    return KatakanaW();
                case KanaGroup.NN:
                    return KatakanaNN();
                case KanaGroup.G:
                    return KatakanaG();
                case KanaGroup.Z:
                    return KatakanaZ();
                case KanaGroup.D:
                    return KatakanaD();
                case KanaGroup.B:
                    return KatakanaB();
                case KanaGroup.P:
                    return KatakanaP();
                case KanaGroup.Ky:
                    return KatakanaKy();
                case KanaGroup.Sh:
                    return KatakanaSh();
                case KanaGroup.Ch:
                    return KatakanaCh();
                case KanaGroup.Ny:
                    return KatakanaNy();
                case KanaGroup.Hy:
                    return KatakanaHy();
                case KanaGroup.My:
                    return KatakanaMy();
                case KanaGroup.Ry:
                    return KatakanaRy();
                case KanaGroup.Gy:
                    return KatakanaGy();
                case KanaGroup.Jy:
                    return KatakanaJy();
                case KanaGroup.Dzy:
                    return KatakanaDzy();
                case KanaGroup.By:
                    return KatakanaBy();
                case KanaGroup.Py:
                    return KatakanaPy();
                default:
                    throw new ArgumentOutOfRangeException(nameof(@group), @group, null);
            }
        }

        #region Default Katakana

        public static IList<Entities.Kana> KatakanaVowels()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Vowels, Html = "&#12450;", Romaji = "a"},
                new Entities.Kana {Group = KanaGroup.Vowels, Html = "&#12452;", Romaji = "i"},
                new Entities.Kana {Group = KanaGroup.Vowels, Html = "&#12454;", Romaji = "u"},
                new Entities.Kana {Group = KanaGroup.Vowels, Html = "&#12456;", Romaji = "e"},
                new Entities.Kana {Group = KanaGroup.Vowels, Html = "&#12458;", Romaji = "o"}
            };
        }

        public static IList<Entities.Kana> KatakanaK()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.K, Html = "&#12459;", Romaji = "ka"},
                new Entities.Kana {Group = KanaGroup.K, Html = "&#12461;", Romaji = "ki"},
                new Entities.Kana {Group = KanaGroup.K, Html = "&#12463;", Romaji = "ku"},
                new Entities.Kana {Group = KanaGroup.K, Html = "&#12465;", Romaji = "ke"},
                new Entities.Kana {Group = KanaGroup.K, Html = "&#12467;", Romaji = "ko"}
            };
        }

        public static IList<Entities.Kana> KatakanaS()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.S, Html = "&#12469;", Romaji = "sa"},
                new Entities.Kana {Group = KanaGroup.S, Html = "&#12471;", Romaji = "shi"},
                new Entities.Kana {Group = KanaGroup.S, Html = "&#12473;", Romaji = "su"},
                new Entities.Kana {Group = KanaGroup.S, Html = "&#12475;", Romaji = "se"},
                new Entities.Kana {Group = KanaGroup.S, Html = "&#12477;", Romaji = "so"}
            };
        }

        public static IList<Entities.Kana> KatakanaT()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.T, Html = "&#12479;", Romaji = "ta"},
                new Entities.Kana {Group = KanaGroup.T, Html = "&#12481;", Romaji = "chi"},
                new Entities.Kana {Group = KanaGroup.T, Html = "&#12483;", Romaji = "tsu"},
                new Entities.Kana {Group = KanaGroup.T, Html = "&#12486;", Romaji = "te"},
                new Entities.Kana {Group = KanaGroup.T, Html = "&#12488;", Romaji = "to"}
            };
        }

        public static IList<Entities.Kana> KatakanaN()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.N, Html = "&#12490;", Romaji = "na"},
                new Entities.Kana {Group = KanaGroup.N, Html = "&#12491;", Romaji = "ni"},
                new Entities.Kana {Group = KanaGroup.N, Html = "&#12492;", Romaji = "nu"},
                new Entities.Kana {Group = KanaGroup.N, Html = "&#12493;", Romaji = "ne"},
                new Entities.Kana {Group = KanaGroup.N, Html = "&#12494;", Romaji = "no"}
            };
        }

        public static IList<Entities.Kana> KatakanaH()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.H, Html = "&#12495;", Romaji = "ha"},
                new Entities.Kana {Group = KanaGroup.H, Html = "&#12498;", Romaji = "hi"},
                new Entities.Kana {Group = KanaGroup.H, Html = "&#12501;", Romaji = "fu/hu"},
                new Entities.Kana {Group = KanaGroup.H, Html = "&#12504;", Romaji = "he"},
                new Entities.Kana {Group = KanaGroup.H, Html = "&#12507;", Romaji = "ho"}
            };
        }

        public static IList<Entities.Kana> KatakanaM()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.M, Html = "&#12510;", Romaji = "ma"},
                new Entities.Kana {Group = KanaGroup.M, Html = "&#12511;", Romaji = "mi"},
                new Entities.Kana {Group = KanaGroup.M, Html = "&#12512;", Romaji = "mu"},
                new Entities.Kana {Group = KanaGroup.M, Html = "&#12513;", Romaji = "me"},
                new Entities.Kana {Group = KanaGroup.M, Html = "&#12514;", Romaji = "mo"}
            };
        }

        public static IList<Entities.Kana> KatakanaY()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Y, Html = "&#12516;", Romaji = "ya"},
                new Entities.Kana {Group = KanaGroup.Empty},
                new Entities.Kana {Group = KanaGroup.Y, Html = "&#12518;", Romaji = "yu"},
                new Entities.Kana {Group = KanaGroup.Empty},
                new Entities.Kana {Group = KanaGroup.Y, Html = "&#12520;", Romaji = "yo"}
            };
        }

        public static IList<Entities.Kana> KatakanaR()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.R, Html = "&#12521;", Romaji = "ra"},
                new Entities.Kana {Group = KanaGroup.R, Html = "&#12522;", Romaji = "ri"},
                new Entities.Kana {Group = KanaGroup.R, Html = "&#12523;", Romaji = "ru"},
                new Entities.Kana {Group = KanaGroup.R, Html = "&#12524;", Romaji = "re"},
                new Entities.Kana {Group = KanaGroup.R, Html = "&#12525;", Romaji = "ro"}
            };
        }

        public static IList<Entities.Kana> KatakanaW()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.W, Html = "&#12527;", Romaji = "wa"},
                new Entities.Kana {Group = KanaGroup.Empty},
                new Entities.Kana {Group = KanaGroup.Empty},
                new Entities.Kana {Group = KanaGroup.Empty},
                new Entities.Kana {Group = KanaGroup.W, Html = "&#12530;", Romaji = "wo"}
            };
        }

        public static IList<Entities.Kana> KatakanaNN()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.NN, Html = "&#12531;", Romaji = "n"},
                new Entities.Kana {Group = KanaGroup.Empty},
                new Entities.Kana {Group = KanaGroup.Empty},
                new Entities.Kana {Group = KanaGroup.Empty},
                new Entities.Kana {Group = KanaGroup.Empty},
            };
        }

        #endregion

        #region Dakuten Katakana

        public static IList<Entities.Kana> KatakanaG()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.G, Html = "&#12460;", Romaji = "ga"},
                new Entities.Kana {Group = KanaGroup.G, Html = "&#12462;", Romaji = "gi"},
                new Entities.Kana {Group = KanaGroup.G, Html = "&#12464;", Romaji = "gu"},
                new Entities.Kana {Group = KanaGroup.G, Html = "&#12466;", Romaji = "ge"},
                new Entities.Kana {Group = KanaGroup.G, Html = "&#12468;", Romaji = "go"}
            };
        }

        public static IList<Entities.Kana> KatakanaZ()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Z, Html = "&#12470;", Romaji = "za"},
                new Entities.Kana {Group = KanaGroup.Z, Html = "&#12472;", Romaji = "ji"},
                new Entities.Kana {Group = KanaGroup.Z, Html = "&#12474;", Romaji = "zu"},
                new Entities.Kana {Group = KanaGroup.Z, Html = "&#12476;", Romaji = "ze"},
                new Entities.Kana {Group = KanaGroup.Z, Html = "&#12478;", Romaji = "zo"}
            };
        }

        public static IList<Entities.Kana> KatakanaD()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.D, Html = "&#12480;", Romaji = "da"},
                new Entities.Kana {Group = KanaGroup.D, Html = "&#12482;", Romaji = "dzi"},
                new Entities.Kana {Group = KanaGroup.D, Html = "&#12485;", Romaji = "dzu"},
                new Entities.Kana {Group = KanaGroup.D, Html = "&#12487;", Romaji = "de"},
                new Entities.Kana {Group = KanaGroup.D, Html = "&#12489;", Romaji = "do"}
            };
        }

        public static IList<Entities.Kana> KatakanaB()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.B, Html = "&#12496;", Romaji = "ba"},
                new Entities.Kana {Group = KanaGroup.B, Html = "&#12499;", Romaji = "bi"},
                new Entities.Kana {Group = KanaGroup.B, Html = "&#12502;", Romaji = "bu"},
                new Entities.Kana {Group = KanaGroup.B, Html = "&#12505;", Romaji = "be"},
                new Entities.Kana {Group = KanaGroup.B, Html = "&#12508;", Romaji = "bo"}
            };
        }

        public static IList<Entities.Kana> KatakanaP()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.P, Html = "&#12497;", Romaji = "pa"},
                new Entities.Kana {Group = KanaGroup.P, Html = "&#12500;", Romaji = "pi"},
                new Entities.Kana {Group = KanaGroup.P, Html = "&#12503;", Romaji = "pu"},
                new Entities.Kana {Group = KanaGroup.P, Html = "&#12506;", Romaji = "pe"},
                new Entities.Kana {Group = KanaGroup.P, Html = "&#12509;", Romaji = "po"}
            };
        }

        #endregion

        #region Combo Katakana

        public static IList<Entities.Kana> KatakanaKy()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Ky, Html = "&#12461;&#12419;", Romaji = "kya"},
                new Entities.Kana {Group = KanaGroup.Ky, Html = "&#12461;&#12421;", Romaji = "kyu"},
                new Entities.Kana {Group = KanaGroup.Ky, Html = "&#12461;&#12423;", Romaji = "kyo"}
            };
        }

        public static IList<Entities.Kana> KatakanaSh()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Sh, Html = "&#12471;&#12419;", Romaji = "sha"},
                new Entities.Kana {Group = KanaGroup.Sh, Html = "&#12471;&#12421;", Romaji = "shu"},
                new Entities.Kana {Group = KanaGroup.Sh, Html = "&#12471;&#12423;", Romaji = "sho"}
            };
        }

        public static IList<Entities.Kana> KatakanaCh()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Sh, Html = "&#12481;&#12419;", Romaji = "cha"},
                new Entities.Kana {Group = KanaGroup.Sh, Html = "&#12481;&#12421;", Romaji = "chu"},
                new Entities.Kana {Group = KanaGroup.Sh, Html = "&#12481;&#12423;", Romaji = "cho"}
            };
        }

        public static IList<Entities.Kana> KatakanaNy()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Ny, Html = "&#12491;&#12419;", Romaji = "nya"},
                new Entities.Kana {Group = KanaGroup.Ny, Html = "&#12491;&#12421;", Romaji = "nyu"},
                new Entities.Kana {Group = KanaGroup.Ny, Html = "&#12491;&#12423;", Romaji = "nyo"}
            };
        }

        public static IList<Entities.Kana> KatakanaHy()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Hy, Html = "&#12498;&#12419;", Romaji = "hya"},
                new Entities.Kana {Group = KanaGroup.Hy, Html = "&#12498;&#12421;", Romaji = "hyu"},
                new Entities.Kana {Group = KanaGroup.Hy, Html = "&#12498;&#12423;", Romaji = "hyo"}
            };
        }

        public static IList<Entities.Kana> KatakanaMy()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.My, Html = "&#12511;&#12419;", Romaji = "mya"},
                new Entities.Kana {Group = KanaGroup.My, Html = "&#12511;&#12421;", Romaji = "myu"},
                new Entities.Kana {Group = KanaGroup.My, Html = "&#12511;&#12423;", Romaji = "myo"}
            };
        }

        public static IList<Entities.Kana> KatakanaRy()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Ry, Html = "&#12522;&#12419;", Romaji = "rya"},
                new Entities.Kana {Group = KanaGroup.Ry, Html = "&#12522;&#12421;", Romaji = "ryu"},
                new Entities.Kana {Group = KanaGroup.Ry, Html = "&#12522;&#12423;", Romaji = "ryo"}
            };
        }

        public static IList<Entities.Kana> KatakanaGy()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Gy, Html = "&#12462;&#12419;", Romaji = "gya"},
                new Entities.Kana {Group = KanaGroup.Gy, Html = "&#12462;&#12421;", Romaji = "gyu"},
                new Entities.Kana {Group = KanaGroup.Gy, Html = "&#12462;&#12423;", Romaji = "gyo"}
            };
        }

        public static IList<Entities.Kana> KatakanaJy()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Jy, Html = "&#12472;&#12419;", Romaji = "jya"},
                new Entities.Kana {Group = KanaGroup.Jy, Html = "&#12472;&#12421;", Romaji = "jyu"},
                new Entities.Kana {Group = KanaGroup.Jy, Html = "&#12472;&#12423;", Romaji = "jyo"}
            };
        }

        public static IList<Entities.Kana> KatakanaDzy()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Dzy, Html = "&#12482;&#12419;", Romaji = "dzya"},
                new Entities.Kana {Group = KanaGroup.Dzy, Html = "&#12482;&#12421;", Romaji = "dzyu"},
                new Entities.Kana {Group = KanaGroup.Dzy, Html = "&#12482;&#12423;", Romaji = "dzyo"}
            };
        }

        public static IList<Entities.Kana> KatakanaBy()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.By, Html = "&#12499;&#12419;", Romaji = "bya"},
                new Entities.Kana {Group = KanaGroup.By, Html = "&#12499;&#12421;", Romaji = "byu"},
                new Entities.Kana {Group = KanaGroup.By, Html = "&#12499;&#12423;", Romaji = "byo"}
            };
        }

        public static IList<Entities.Kana> KatakanaPy()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Py, Html = "&#12500;&#12419;", Romaji = "pya"},
                new Entities.Kana {Group = KanaGroup.Py, Html = "&#12500;&#12421;", Romaji = "pyu"},
                new Entities.Kana {Group = KanaGroup.Py, Html = "&#12500;&#12423;", Romaji = "pyo"}
            };                                                                                                                                  
        }


        #endregion

    }
}