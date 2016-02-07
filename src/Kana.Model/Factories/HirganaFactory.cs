using System;
using System.Collections.Generic;
using System.Linq;
using Kana.Model.Enums;
using Kana.Model.Helpers;

namespace Kana.Model.Factories
{
    public class HirganaFactory : KanaBaseFactory
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
                    return HiraganaVowels();
                case KanaGroup.K:
                    return HiraganaK();
                case KanaGroup.S:
                    return HiraganaS();
                case KanaGroup.T:
                    return HiraganaT();
                case KanaGroup.N:
                    return HiraganaN();
                case KanaGroup.H:
                    return HiraganaH();
                case KanaGroup.M:
                    return HiraganaM();
                case KanaGroup.Y:
                    return HiraganaY();
                case KanaGroup.R:
                    return HiraganaR();
                case KanaGroup.W:
                    return HiraganaW();
                case KanaGroup.NN:
                    return HiraganaNN();
                case KanaGroup.G:
                    return HiraganaG();
                case KanaGroup.Z:
                    return HiraganaZ();
                case KanaGroup.D:
                    return HiraganaD();
                case KanaGroup.B:
                    return HiraganaB();
                case KanaGroup.P:
                    return HiraganaP();
                case KanaGroup.Ky:
                    return HiraganaKy();
                case KanaGroup.Sh:
                    return HiraganaSh();
                case KanaGroup.Ch:
                    return HiraganaCh();
                case KanaGroup.Ny:
                    return HiraganaNy();
                case KanaGroup.Hy:
                    return HiraganaHy();
                case KanaGroup.My:
                    return HiraganaMy();
                case KanaGroup.Ry:
                    return HiraganaRy();
                case KanaGroup.Gy:
                    return HiraganaGy();
                case KanaGroup.Jy:
                    return HiraganaJy();
                case KanaGroup.Dzy:
                    return HiraganaDzy();
                case KanaGroup.By:
                    return HiraganaBy();
                case KanaGroup.Py:
                    return HiraganaPy();
                default:
                    throw new ArgumentOutOfRangeException(nameof(@group), @group, null);
            }
        }

        #region Default Hiragana

        public static IList<Entities.Kana> HiraganaVowels()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Vowels, Html = "&#12354;", Romaji = "a"},
                new Entities.Kana {Group = KanaGroup.Vowels, Html = "&#12356;", Romaji = "i"},
                new Entities.Kana {Group = KanaGroup.Vowels, Html = "&#12358;", Romaji = "u"},
                new Entities.Kana {Group = KanaGroup.Vowels, Html = "&#12360;", Romaji = "e"},
                new Entities.Kana {Group = KanaGroup.Vowels, Html = "&#12362;", Romaji = "o"}
            };
        }

        public static IList<Entities.Kana> HiraganaK()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.K, Html = "&#12363;", Romaji = "ka"},
                new Entities.Kana {Group = KanaGroup.K, Html = "&#12365;", Romaji = "ki"},
                new Entities.Kana {Group = KanaGroup.K, Html = "&#12367;", Romaji = "ku"},
                new Entities.Kana {Group = KanaGroup.K, Html = "&#12369;", Romaji = "ke"},
                new Entities.Kana {Group = KanaGroup.K, Html = "&#12371;", Romaji = "ko"}
            };
        }

        public static IList<Entities.Kana> HiraganaS()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.S, Html = "&#12373;", Romaji = "sa"},
                new Entities.Kana {Group = KanaGroup.S, Html = "&#12375;", Romaji = "shi"},
                new Entities.Kana {Group = KanaGroup.S, Html = "&#12377;", Romaji = "su"},
                new Entities.Kana {Group = KanaGroup.S, Html = "&#12379;", Romaji = "se"},
                new Entities.Kana {Group = KanaGroup.S, Html = "&#12381;", Romaji = "so"}
            };
        }

        public static IList<Entities.Kana> HiraganaT()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.T, Html = "&#12383;", Romaji = "ta"},
                new Entities.Kana {Group = KanaGroup.T, Html = "&#12385;", Romaji = "chi"},
                new Entities.Kana {Group = KanaGroup.T, Html = "&#12387;", Romaji = "tsu"},
                new Entities.Kana {Group = KanaGroup.T, Html = "&#12390;", Romaji = "te"},
                new Entities.Kana {Group = KanaGroup.T, Html = "&#12392;", Romaji = "to"}
            };
        }

        public static IList<Entities.Kana> HiraganaN()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.N, Html = "&#12394;", Romaji = "na"},
                new Entities.Kana {Group = KanaGroup.N, Html = "&#12395;", Romaji = "ni"},
                new Entities.Kana {Group = KanaGroup.N, Html = "&#12396;", Romaji = "nu"},
                new Entities.Kana {Group = KanaGroup.N, Html = "&#12397;", Romaji = "ne"},
                new Entities.Kana {Group = KanaGroup.N, Html = "&#12398;", Romaji = "no"}
            };
        }

        public static IList<Entities.Kana> HiraganaH()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.H, Html = "&#12399;", Romaji = "ha"},
                new Entities.Kana {Group = KanaGroup.H, Html = "&#12402;", Romaji = "hi"},
                new Entities.Kana {Group = KanaGroup.H, Html = "&#12405;", Romaji = "fu/hu"},
                new Entities.Kana {Group = KanaGroup.H, Html = "&#12408;", Romaji = "he"},
                new Entities.Kana {Group = KanaGroup.H, Html = "&#12411;", Romaji = "ho"}
            };
        }

        public static IList<Entities.Kana> HiraganaM()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.M, Html = "&#12414;", Romaji = "ma"},
                new Entities.Kana {Group = KanaGroup.M, Html = "&#12415;", Romaji = "mi"},
                new Entities.Kana {Group = KanaGroup.M, Html = "&#12416;", Romaji = "mu"},
                new Entities.Kana {Group = KanaGroup.M, Html = "&#12417;", Romaji = "me"},
                new Entities.Kana {Group = KanaGroup.M, Html = "&#12418;", Romaji = "mo"}
            };
        }

        public static IList<Entities.Kana> HiraganaY()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Y, Html = "&#12420;", Romaji = "ya"},
                new Entities.Kana {Group = KanaGroup.Empty},
                new Entities.Kana {Group = KanaGroup.Y, Html = "&#12422;", Romaji = "yu"},
                new Entities.Kana {Group = KanaGroup.Empty},
                new Entities.Kana {Group = KanaGroup.Y, Html = "&#12424;", Romaji = "yo"}
            };
        }

        public static IList<Entities.Kana> HiraganaR()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.R, Html = "&#12425;", Romaji = "ra"},
                new Entities.Kana {Group = KanaGroup.R, Html = "&#12426;", Romaji = "ri"},
                new Entities.Kana {Group = KanaGroup.R, Html = "&#12427;", Romaji = "ru"},
                new Entities.Kana {Group = KanaGroup.R, Html = "&#12428;", Romaji = "re"},
                new Entities.Kana {Group = KanaGroup.R, Html = "&#12429;", Romaji = "ro"}
            };
        }

        public static IList<Entities.Kana> HiraganaW()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.W, Html = "&#12431;", Romaji = "wa"},
                new Entities.Kana {Group = KanaGroup.Empty},
                new Entities.Kana {Group = KanaGroup.Empty},
                new Entities.Kana {Group = KanaGroup.Empty},
                new Entities.Kana {Group = KanaGroup.W, Html = "&#12434;", Romaji = "wo"}
            };
        }

        public static IList<Entities.Kana> HiraganaNN()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.NN, Html = "&#12435;", Romaji = "n"},
                new Entities.Kana {Group = KanaGroup.Empty},
                new Entities.Kana {Group = KanaGroup.Empty},
                new Entities.Kana {Group = KanaGroup.Empty},
                new Entities.Kana {Group = KanaGroup.Empty},
            };
        }

        #endregion

        #region Dakuten Hiragana

        public static IList<Entities.Kana> HiraganaG()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.G, Html = "&#12364;", Romaji = "ga"},
                new Entities.Kana {Group = KanaGroup.G, Html = "&#12366;", Romaji = "gi"},
                new Entities.Kana {Group = KanaGroup.G, Html = "&#12368;", Romaji = "gu"},
                new Entities.Kana {Group = KanaGroup.G, Html = "&#12370;", Romaji = "ge"},
                new Entities.Kana {Group = KanaGroup.G, Html = "&#12372;", Romaji = "go"}
            };
        }

        public static IList<Entities.Kana> HiraganaZ()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Z, Html = "&#12374;", Romaji = "za"},
                new Entities.Kana {Group = KanaGroup.Z, Html = "&#12376;", Romaji = "ji"},
                new Entities.Kana {Group = KanaGroup.Z, Html = "&#12378;", Romaji = "zu"},
                new Entities.Kana {Group = KanaGroup.Z, Html = "&#12380;", Romaji = "ze"},
                new Entities.Kana {Group = KanaGroup.Z, Html = "&#12382;", Romaji = "zo"}
            };
        }

        public static IList<Entities.Kana> HiraganaD()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.D, Html = "&#12384;", Romaji = "da"},
                new Entities.Kana {Group = KanaGroup.D, Html = "&#12386;", Romaji = "dzi"},
                new Entities.Kana {Group = KanaGroup.D, Html = "&#12389;", Romaji = "dzu"},
                new Entities.Kana {Group = KanaGroup.D, Html = "&#12391;", Romaji = "de"},
                new Entities.Kana {Group = KanaGroup.D, Html = "&#12393;", Romaji = "do"}
            };
        }

        public static IList<Entities.Kana> HiraganaB()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.B, Html = "&#12400;", Romaji = "ba"},
                new Entities.Kana {Group = KanaGroup.B, Html = "&#12403;", Romaji = "bi"},
                new Entities.Kana {Group = KanaGroup.B, Html = "&#12406;", Romaji = "bu"},
                new Entities.Kana {Group = KanaGroup.B, Html = "&#12409;", Romaji = "be"},
                new Entities.Kana {Group = KanaGroup.B, Html = "&#12412;", Romaji = "bo"}
            };
        }

        public static IList<Entities.Kana> HiraganaP()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.P, Html = "&#12401;", Romaji = "pa"},
                new Entities.Kana {Group = KanaGroup.P, Html = "&#12404;", Romaji = "pi"},
                new Entities.Kana {Group = KanaGroup.P, Html = "&#12407;", Romaji = "pu"},
                new Entities.Kana {Group = KanaGroup.P, Html = "&#12410;", Romaji = "pe"},
                new Entities.Kana {Group = KanaGroup.P, Html = "&#12413;", Romaji = "po"}
            };
        }

        #endregion

        #region Combo Hiragana

        public static IList<Entities.Kana> HiraganaKy()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Ky, Html = "&#12365;&#12419;", Romaji = "kya"},
                new Entities.Kana {Group = KanaGroup.Ky, Html = "&#12365;&#12421;", Romaji = "kyu"},
                new Entities.Kana {Group = KanaGroup.Ky, Html = "&#12365;&#12423;", Romaji = "kyo"}
            };
        }

        public static IList<Entities.Kana> HiraganaSh()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Sh, Html = "&#12375;&#12419;", Romaji = "sha"},
                new Entities.Kana {Group = KanaGroup.Sh, Html = "&#12375;&#12421;", Romaji = "shu"},
                new Entities.Kana {Group = KanaGroup.Sh, Html = "&#12375;&#12423;", Romaji = "sho"}
            };
        }

        public static IList<Entities.Kana> HiraganaCh()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Sh, Html = "&#12385;&#12419;", Romaji = "cha"},
                new Entities.Kana {Group = KanaGroup.Sh, Html = "&#12385;&#12421;", Romaji = "chu"},
                new Entities.Kana {Group = KanaGroup.Sh, Html = "&#12385;&#12423;", Romaji = "cho"}
            };
        }

        public static IList<Entities.Kana> HiraganaNy()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Ny, Html = "&#12395;&#12419;", Romaji = "nya"},
                new Entities.Kana {Group = KanaGroup.Ny, Html = "&#12395;&#12421;", Romaji = "nyu"},
                new Entities.Kana {Group = KanaGroup.Ny, Html = "&#12395;&#12423;", Romaji = "nyo"}
            };
        }

        public static IList<Entities.Kana> HiraganaHy()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Hy, Html = "&#12402;&#12419;", Romaji = "hya"},
                new Entities.Kana {Group = KanaGroup.Hy, Html = "&#12402;&#12421;", Romaji = "hyu"},
                new Entities.Kana {Group = KanaGroup.Hy, Html = "&#12402;&#12423;", Romaji = "hyo"}
            };
        }

        public static IList<Entities.Kana> HiraganaMy()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.My, Html = "&#12415;&#12419;", Romaji = "mya"},
                new Entities.Kana {Group = KanaGroup.My, Html = "&#12415;&#12421;", Romaji = "myu"},
                new Entities.Kana {Group = KanaGroup.My, Html = "&#12415;&#12423;", Romaji = "myo"}
            };
        }

        public static IList<Entities.Kana> HiraganaRy()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Ry, Html = "&#12426;&#12419;", Romaji = "rya"},
                new Entities.Kana {Group = KanaGroup.Ry, Html = "&#12426;&#12421;", Romaji = "ryu"},
                new Entities.Kana {Group = KanaGroup.Ry, Html = "&#12426;&#12423;", Romaji = "ryo"}
            };
        }

        public static IList<Entities.Kana> HiraganaGy()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Gy, Html = "&#12366;&#12419;", Romaji = "gya"},
                new Entities.Kana {Group = KanaGroup.Gy, Html = "&#12366;&#12421;", Romaji = "gyu"},
                new Entities.Kana {Group = KanaGroup.Gy, Html = "&#12366;&#12423;", Romaji = "gyo"}
            };
        }

        public static IList<Entities.Kana> HiraganaJy()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Jy, Html = "&#12376;&#12419;", Romaji = "jya"},
                new Entities.Kana {Group = KanaGroup.Jy, Html = "&#12376;&#12421;", Romaji = "jyu"},
                new Entities.Kana {Group = KanaGroup.Jy, Html = "&#12376;&#12423;", Romaji = "jyo"}
            };
        }

        public static IList<Entities.Kana> HiraganaDzy()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Dzy, Html = "&#12386;&#12419;", Romaji = "dzya"},
                new Entities.Kana {Group = KanaGroup.Dzy, Html = "&#12386;&#12421;", Romaji = "dzyu"},
                new Entities.Kana {Group = KanaGroup.Dzy, Html = "&#12386;&#12423;", Romaji = "dzyo"}
            };
        }

        public static IList<Entities.Kana> HiraganaBy()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.By, Html = "&#12403;&#12419;", Romaji = "bya"},
                new Entities.Kana {Group = KanaGroup.By, Html = "&#12403;&#12421;", Romaji = "byu"},
                new Entities.Kana {Group = KanaGroup.By, Html = "&#12403;&#12423;", Romaji = "byo"}
            };
        }

        public static IList<Entities.Kana> HiraganaPy()
        {
            return new List<Entities.Kana>
            {
                new Entities.Kana {Group = KanaGroup.Py, Html = "&#12404;&#12419;", Romaji = "pya"},
                new Entities.Kana {Group = KanaGroup.Py, Html = "&#12404;&#12421;", Romaji = "pyu"},
                new Entities.Kana {Group = KanaGroup.Py, Html = "&#12404;&#12423;", Romaji = "pyo"}
            };                                                                                                                                  
        }


        #endregion

    }
}