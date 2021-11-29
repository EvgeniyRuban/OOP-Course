using System.Text;

namespace OOP_GB.Coder
{
    public class BCoder : ICoder
    {
        public string Decode(string s) => Mirror(s, ('A', 'a'), ('Z', 'z'));

        public string Encode(string s) => Mirror(s, ('A', 'a'), ('Z', 'z'));

        private string Mirror(string s, (char, char) startLetter, (char, char) endLetter)
        {
            StringBuilder sBuilder = new StringBuilder(s.Length);
            int middleItem1 = (endLetter.Item1 - startLetter.Item1) / 2 + startLetter.Item1;
            int middleItem2 = (endLetter.Item2 - startLetter.Item2) / 2 + startLetter.Item2;

            for(int i=0; i < s.Length; i++)
            {
                char sym = s[i];

                if(sym >= startLetter.Item1 && sym <= endLetter.Item1)
                {
                    if (sym < middleItem1)
                    {
                        sBuilder.Append((char)(endLetter.Item1 - (sym - startLetter.Item1)));
                    }
                    else
                    {
                        sBuilder.Append((char)(startLetter.Item1 + (endLetter.Item1 - sym)));
                    }
                }

                if(sym >= startLetter.Item2 && sym <= endLetter.Item2)
                {
                    if (sym < middleItem2)
                    {
                        sBuilder.Append((char)(endLetter.Item2 - (sym - startLetter.Item2)));
                    }
                    else
                    {
                        sBuilder.Append((char)(startLetter.Item2 + (endLetter.Item2 - sym)));
                    }
                }
            }

            return sBuilder.ToString();
        }
    }
}
