using System;
using System.Text;

namespace OOP_GB.Coder
{
    public class ACoder : ICoder
    {
        public string Decode(string s) => Decrement(s, ('A', 'a'), ('Z', 'z'));

        public string Encode(string s) => Increment(s, ('A', 'a'), ('Z', 'z'));

        private string Increment(string s, (char,char) startLetter, (char, char) endLetter)
        { 
            StringBuilder sBuilder = new StringBuilder(s.Length);

            for (int i = 0; i < s.Length; i++)
            {
                char sym = s[i];

                if (sym >= startLetter.Item1 && sym <= endLetter.Item1)
                {
                    if (sym == endLetter.Item1)
                    {
                        sBuilder.Append(startLetter.Item1);
                    }
                    else
                    {
                        sBuilder.Append(++sym);
                    }
                }
                if (sym >= startLetter.Item2 && sym <= endLetter.Item2)
                {
                    if (sym == endLetter.Item2)
                    {
                        sBuilder.Append(startLetter.Item2);
                    }
                    else
                    {
                        sBuilder.Append(++sym);
                    }
                }
            }
            return sBuilder.ToString();
        }

        private string Decrement(string s, (char, char) startLetter, (char, char) endLetter)
        {
            StringBuilder sBuilder = new StringBuilder(s.Length);

            for (int i = 0; i < s.Length; i++)
            {
                char sym = s[i];

                if (sym >= startLetter.Item1 && sym <= endLetter.Item1)
                {
                    if (sym == startLetter.Item1)
                    {
                        sBuilder.Append(endLetter.Item1);
                    }
                    else
                    {
                        sBuilder.Append(--sym);
                    }
                }
                if (sym >= startLetter.Item2 && sym <= endLetter.Item2)
                {
                    if (sym == startLetter.Item2)
                    {
                        sBuilder.Append(endLetter.Item2);
                    }
                    else
                    {
                        sBuilder.Append(--sym);
                    }
                }
            }
            return sBuilder.ToString();
        }
    }
}
