namespace Core.LLama.Common
{
    public static class LLamaExtensions
    {
        /// <summary>
        /// Combines the AntiPrompts list and AntiPrompt csv
        /// </summary>
        /// <param name="sessionConfig">The session configuration.</param>
        /// <returns>Combined AntiPrompts with duplicates removed</returns>
        public static List<String> GetAntiPrompts(this ISessionConfig sessionConfig)
        {
            return CombineCSV(sessionConfig.AntiPrompts, sessionConfig.AntiPrompt);
        }
        /// <summary>
        /// Combines the OutputFilters list and OutputFilter csv
        /// </summary>
        /// <param name="sessionConfig">The session configuration.</param>
        /// <returns>Combined OutputFilters with duplicates removed</returns>
        public static List<String> GetOutputFilters(this ISessionConfig sessionConfig)
        {
            return CombineCSV(sessionConfig.OutputFilters, sessionConfig.OutputFilter);
        }
        /// <summary>
        /// Combines a String list and a csv and removes duplicates
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="csv">The CSV.</param>
        /// <returns>Combined list with duplicates removed</returns>
        private static List<String> CombineCSV(List<String> list, String csv)
        {
            var results = list is null || list.Count == 0
                ? CommaSeparatedToList(csv)
                : CommaSeparatedToList(csv).Concat(list);
            return results
                .Distinct()
                .ToList();
        }
        private static List<String> CommaSeparatedToList(String value)
        {
            if (String.IsNullOrEmpty(value))
                return new List<String>();

            return value.Split(",", StringSplitOptions.RemoveEmptyEntries)
                 .Select(x => x.Trim())
                 .ToList();
        }
    }
}
