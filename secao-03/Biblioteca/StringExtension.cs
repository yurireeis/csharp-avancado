
namespace Biblioteca
{
    // utilizando Method Extension
    public static class StringExtension
    {
        public static string FirstToUpper(this string str) => str.Substring(0,1).ToUpper() + str.Substring(1);
    }
}
