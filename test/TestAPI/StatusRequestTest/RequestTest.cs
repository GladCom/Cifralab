using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace TestAPI.StatusRequestTest
{
    /// <summary>
    /// Модель запроса с свойством Name и проверкой
    /// </summary>
    internal class RequestTest
    {
        /// <summary>
        /// Название статуса
        /// </summary>
        [Required(ErrorMessage = "Название обязательно")]
        [RegularExpression("^(?=.*[А-Яа-яЁё])[А-Яа-яЁё\\s\\-]+$", ErrorMessage = "Название должно содержать только кириллицу.")]
        public string? Name { get; set; }

        /// <summary>
        /// Метод для проверки правильности данных
        /// </summary>
        /// <returns>Список ошибок валидации</returns>
        public IList<ValidationResult> Validate()
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this);
            Validator.TryValidateObject(this, context, results, validateAllProperties: true);

            // Дополнительная проверка, что Name не null, не пустая и не только из пробелов
            if (string.IsNullOrWhiteSpace(Name))
            {
                results.Add(new ValidationResult("Название обязательно", new[] { nameof(Name) }));
            }
            return results;
        }
    }

    [TestFixture]
    public class ПроверкаНазванияСтатуса
    {
        [Test]
        public void Название_НаКириллице_Проходит()
        {
            var запрос = new RequestTest { Name = "Статус" };
            var результаты = запрос.Validate();
            Assert.IsEmpty(результаты, "Должна пройти валидация без ошибок");
        }

        [Test]
        public void Название_СПробелами_Дефисами_Проходит()
        {
            var запрос = new RequestTest { Name = "Новый-Статус" };
            var результаты = запрос.Validate();
            Assert.IsEmpty(результаты, "Допустимые символы должны проходить");
        }

        [Test]
        public void Название_НаЛатинице_НеПроходит()
        {
            var запрос = new RequestTest { Name = "Status" };
            var результаты = запрос.Validate();
            Assert.IsNotEmpty(результаты);
            Assert.IsTrue(результаты.Any(r => r.ErrorMessage == "Название должно содержать только кириллицу."));
        }

        [Test]
        public void Название_СоСпецсимволами_НеПроходит()
        {
            var запрос = new RequestTest { Name = "Статус!" };
            var результаты = запрос.Validate();
            Assert.IsNotEmpty(результаты);
            Assert.IsTrue(результаты.Any(r => r.ErrorMessage == "Название должно содержать только кириллицу."));
        }

        [Test]
        public void Название_Пустое_НеПроходит()
        {
            var запрос = new RequestTest { Name = null };
            var результаты = запрос.Validate();
            Assert.IsNotEmpty(результаты, "Пустое название не должно проходить");
            Assert.IsTrue(результаты.Any(r => r.ErrorMessage == "Название обязательно"));
        }

        [Test]
        public void Название_ТолькоПробелы_НеПроходит()
        {
            var запрос = new RequestTest { Name = "   " };
            var результаты = запрос.Validate();
            Assert.IsNotEmpty(результаты, "Название из только пробелов не должно проходить");
            Assert.IsTrue(результаты.Any(r => r.ErrorMessage == "Название обязательно"));
        }

        [Test]
        public void Название_Null_НеПроходит()
        {
            var запрос = new RequestTest { Name = null };
            var результаты = запрос.Validate();
            Assert.IsNotEmpty(результаты, "Null значение не должно проходить");
            Assert.IsTrue(результаты.Any(r => r.ErrorMessage == "Название обязательно"));
        }
    }
}