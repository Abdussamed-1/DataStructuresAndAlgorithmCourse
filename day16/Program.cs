public class Solution
{
    public IList<string> FullJustify(string[] words, int maxWidth)
    {

        IList<string> result = new List<string>();
        int index = 0;
        while (index < words.Length)
        {
            int totalChars = words[index].Length;
            int last = index + 1;
            while (last < words.Length)
            {
                if (totalChars + 1 + words[last].Length > maxWidth) break;
                totalChars += 1 + words[last].Length;
                last++;
            }
            StringBuilder sb = new StringBuilder();
            int gaps = last - index - 1;
            if (last == words.Length || gaps == 0)
            {
                for (int i = index; i < last; i++)
                {
                    sb.Append(words[i]);
                    if (i < last - 1) sb.Append(' ');
                }
                sb.Append(' ', maxWidth - sb.Length);
            }
            else
            {
                int spaces = (maxWidth - totalChars) / gaps;
                int extraSpaces = (maxWidth - totalChars) % gaps;
                for (int i = index; i < last; i++)
                {
                    sb.Append(words[i]);
                    if (i < last - 1)
                    {
                        sb.Append(' ', spaces + (i - index < extraSpaces ? 1 : 0));
                    }
                }
            }
            result.Add(sb.ToString());
            index = last;
        }
        return result;
    }
}