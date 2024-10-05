namespace Students.APIServer.Report.Services
{
    /// <summary>
    /// Аттрибут.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal class AttributeTitleEntity : Attribute
    {
        public string Title { get; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="title">Название.</param>
        public AttributeTitleEntity(string title)
        {
            Title = title;
        }
    }
}
