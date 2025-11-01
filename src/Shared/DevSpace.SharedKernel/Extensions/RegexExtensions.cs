using System.Text.RegularExpressions;

namespace DevSpace.SharedKernel.Extensions;

public static class RegexExtensions
{
    public static bool MatchesApiVersion(string apiVersion, string text)
    {
        string pattern = $@"(?<=\/|^){Regex.Escape(apiVersion)}(?=\/|$)";

        Regex exactMatchRegex = new Regex(pattern, RegexOptions.Compiled);

        return exactMatchRegex.IsMatch(text);
    }
}
