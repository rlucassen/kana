namespace Kana.Model.Enums
{
    public static class StringHelper
    {
        public static string Capitalize(this string input)
        {
            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }
}