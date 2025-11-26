namespace Students.APIServer.DTO
{
    /// <summary>
    /// Статус входного испытания
    /// </summary>
    public class EntranceStatusDTO
    {
        /// <summary>
        /// Номер статуса в энуме
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Текстовое представление статуса
        /// </summary>
        public string Status { get; set; }
    }
}
