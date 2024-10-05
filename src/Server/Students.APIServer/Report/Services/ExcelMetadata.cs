namespace Students.APIServer.Report.Services
{
    /// <summary>
    /// Информация по Excel.
    /// </summary>
    public record ExcelMetadata
    {
        /// <summary>
        /// Названия колонок Excel.
        /// </summary>
        public static char[] ExcelColumnName = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
    }
}
