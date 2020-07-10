using System.Drawing;

namespace PoE_Trade_Overlay
{
    public static class Constants
    {
        public static Color Normal = Color.FromArgb(200, 200, 200);
        public static Color Magic = Color.FromArgb(136, 136, 255);
        public static Color Rare = Color.FromArgb(255, 255, 119);
        public static Color Unique = Color.FromArgb(175, 96, 37);
        public static Color Gem = Color.FromArgb(27, 162, 155);
        public static Color Prophecy = Color.FromArgb(181, 56, 172);
        public static Color Relic = Color.FromArgb(27, 162, 155);
        public static Color Divination = Color.FromArgb(108, 127, 108);
        public static Color Currency = Color.FromArgb(170, 158, 130);
        public static Color HoverEnter = Color.FromArgb(33, 36, 39);
        public static Color HoverLeave = Color.FromArgb(24, 27, 30);
        public static Color Offline = Color.FromArgb(217, 83, 79);
        public static Color Online = Color.FromArgb(48, 150, 48);
        public static Color Afk = Color.FromArgb(169, 95, 0);
        public static Color Placeholder = Color.FromArgb(60, 100, 110);
        public static Color Fore = Color.FromArgb(140, 180, 190);
        public static Color TabBack = Color.FromArgb(20, 22, 24);
        public static Color Craft = Color.FromArgb(180, 180, 255);
        public static Color Corrupted = Color.FromArgb(210, 0, 0);

        public static Color Fire = Color.FromArgb(150, 0, 0); // 4
        public static Color Cold = Color.FromArgb(54, 100, 146); //5
        public static Color Lightning = Color.FromArgb(255, 215, 0); //6
        public static Color Chaos = Color.FromArgb(208, 32, 124); //7


        public static string SearchURL = "https://www.pathofexile.com/api/trade/search/";
        public static string CheckURL = "http://poeto.net/check.php";
        public static string VoteURL = "http://poeto.net/vote.php";
    }
}