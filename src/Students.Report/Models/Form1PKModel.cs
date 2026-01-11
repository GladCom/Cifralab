

namespace Students.Reports.Models
{
    // это модель предворительная, для шаблона из корня проекта 
    public class Form1PKModel
    {
        #region Раздел 2.1. Распределение слушателей по программам (Стр. 6 PDF)

        /// <summary>
        /// Всего слушателей, обученных по программам.
        /// (Раздел 2.1, Строка 01, Графа 3)
        /// </summary>
        public int TotalListeners { get; set; }

        /// <summary>
        /// Из них женщины.
        /// (Раздел 2.1, Строка 01, Графа 10)
        /// </summary>
        public int WomenCount { get; set; }

        #endregion

        #region Раздел 2.4. Распределение слушателей по возрасту (Стр. 14 PDF)

        // Примечание из PDF: "Число полных лет по состоянию на 1 января следующего за отчетным года"

        /// <summary>
        /// Моложе 25 лет.
        /// (Раздел 2.4, Строка 01, Графа 4)
        /// </summary>
        public int AgeUnder25 { get; set; }

        /// <summary>
        /// 25 - 29 лет.
        /// (Раздел 2.4, Строка 01, Графа 5)
        /// </summary>
        public int Age25_29 { get; set; }

        /// <summary>
        /// 30 - 34 лет.
        /// (Раздел 2.4, Строка 01, Графа 6)
        /// </summary>
        public int Age30_34 { get; set; }

        /// <summary>
        /// 35 - 39 лет.
        /// (Раздел 2.4, Строка 01, Графа 7)
        /// </summary>
        public int Age35_39 { get; set; }

        /// <summary>
        /// 40 - 44 лет.
        /// (Раздел 2.4, Строка 01, Графа 8)
        /// </summary>
        public int Age40_44 { get; set; }

        /// <summary>
        /// 45 - 49 лет.
        /// (Раздел 2.4, Строка 01, Графа 9)
        /// </summary>
        public int Age45_49 { get; set; }

        /// <summary>
        /// 50 - 54 лет.
        /// (Раздел 2.4, Строка 01, Графа 10)
        /// </summary>
        public int Age50_54 { get; set; }

        /// <summary>
        /// 55 - 59 лет.
        /// (Раздел 2.4, Строка 01, Графа 11)
        /// </summary>
        public int Age55_59 { get; set; }

        /// <summary>
        /// 60 - 64 лет.
        /// (Раздел 2.4, Строка 01, Графа 12)
        /// </summary>
        public int Age60_64 { get; set; }

        /// <summary>
        /// 65 лет и более.
        /// (Раздел 2.4, Строка 01, Графа 13)
        /// </summary>
        public int Age65AndOlder { get; set; }

        #endregion

        #region Раздел 2.2. Распределение по источникам финансирования (Стр. 8 PDF)

        /// <summary>
        /// За счет бюджетных ассигнований федерального бюджета.
        /// (Раздел 2.2, Строка 01, Графа 4)
        /// </summary>
        public int BudgetFederal { get; set; }

        /// <summary>
        /// За счет бюджетных ассигнований бюджетов субъектов РФ.
        /// (Раздел 2.2, Строка 01, Графа 5)
        /// </summary>
        public int BudgetRegional { get; set; }

        /// <summary>
        /// За счет бюджетных ассигнований местных бюджетов.
        /// (Раздел 2.2, Строка 01, Графа 6)
        /// </summary>
        public int BudgetLocal { get; set; }

        /// <summary>
        /// По договорам об оказании платных образовательных услуг (Всего).
        /// Сумма граф 8 и 9.
        /// (Раздел 2.2, Строка 01, Графа 7)
        /// </summary>
        public int PaidContractsTotal { get; set; }

        /// <summary>
        /// Из них: за счет средств физических лиц.
        /// (Раздел 2.2, Строка 01, Графа 8)
        /// </summary>
        public int PaidIndividuals { get; set; }

        /// <summary>
        /// Из них: за счет средств юридических лиц.
        /// (Раздел 2.2, Строка 01, Графа 9)
        /// </summary>
        public int PaidLegalEntities { get; set; }

        #endregion
    }
}
