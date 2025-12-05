using System.ComponentModel.DataAnnotations;
using Students.Models;

namespace TestAPI.ModelsTests;

[TestFixture]
public class StudentTests
{
  private static IEnumerable<string> IncorrectEmailTestCases()
  {
    yield return "plainaddress"; // Нет символа '@'
    yield return "@missingusername.com"; // Нет имени пользователя перед '@'
    yield return "username@.com"; // Нет доменного имени
    yield return "username@com"; // Нет домена верхнего уровня
    yield return "username@sub_domain..com"; // Две точки подряд
    yield return "username@domain,com"; // Запятая вместо точки
    yield return "username@domain"; // Нет домена верхнего уровня
    yield return "username@domain.c"; // Слишком короткий домен верхнего уровня
    yield return "username@domain#mail.com"; // Недопустимый символ в доменном имени
    yield return "username@@domain.com"; // Две '@'
    yield return "username@domain..com"; // Две точки в доменном имени
    yield return "username@domain.com."; // Точка в конце
    yield return "user name@domain.com"; // Пробел в имени пользователя
    yield return ".username@domain.com"; // Точка в начале имени пользователя
    yield return "username@-domain.com"; // Дефис в начале доменного имени

  }

  private static IEnumerable<string> IncorrectPhoneTestCases()
  {
    yield return "123456"; // Слишком короткий номер
    yield return "abcdefghij"; // Только буквы, нет цифр
    yield return "+12-3456-78901a"; // Буква в номере
    yield return "+1(234)567-8901-234"; // Слишком длинный номер
    yield return "+12345678901234"; // Слишком длинный номер с кодом страны
    yield return "++1234567890"; // Двойной знак '+'
    yield return "+12-345-67"; // Слишком короткий номер с кодом страны
    yield return "+123 45*6789"; // Недопустимый символ '*'
    yield return "+12 3456/7890"; // Недопустимый символ '/'
    yield return "+1 (234) 567 89"; // Недостаточное количество цифр
    yield return "123-456-789-0"; // Неправильный формат разделения
    yield return "+1-234-567 89012"; // Слишком длинный номер
    yield return "(12345) 678-901"; // Слишком много цифр в коде города
    yield return "+1 234--567-890"; // Двойной дефис
  }

  private static IEnumerable<string> IncorrectSNILSTestCases()
  {
    yield return "123-456-789"; // Отсутствует контрольное число
    yield return "12345678912"; // Нет дефисов и пробела
    yield return "123-45-6789 12"; // Неправильное количество цифр в группах
    yield return "123-456-7891 23"; // Лишняя цифра в основной части
    yield return "12-3456-789 12"; // Неправильное количество цифр в первой группе
    yield return "123-456-789-12"; // Лишний дефис перед контрольным числом
    yield return "123-456-78912"; // Нет пробела перед контрольным числом
    yield return "123-456-789 AA"; // Буквы вместо контрольного числа
    yield return "123-456-78A 12"; // Буква в основной части
    yield return "123 456 789 12"; // Нет дефисов, пробелы вместо них
    yield return "123-456-789 123"; // Лишняя цифра в контрольном числе
    yield return "123-456-789"; // Нет контрольного числа
    yield return "AAA-BBB-CCC DD"; // Буквы вместо цифр
    yield return "123-456-789 1"; // Одноцифренное контрольное число
    yield return "123-456-78 12"; // Недостаточно цифр в основной части
  }

  [Test]
  public void StudentCreate_Success()
  {
    //Act
    TestDelegate act = () =>
    {
      var student = new Student
      {
        Family = "null",
        BirthDate = default,
        Sex = default,
        Address = "null",
        Phone = "+7 (123) 456-78-90",
        Email = "test@gmail.com",
        SNILS = "333-333-333 32",
        IT_Experience = "null",
        ScopeOfActivityLevelOneId = default
      };
    };

    //Assert
    Assert.DoesNotThrow(act);
  }

  [TestCaseSource(nameof(IncorrectEmailTestCases))]
  public void StudentCreate_IncorrectEmail(string email)
  {
    //Act
    TestDelegate act = () =>
    {
      var student = new Student
      {
        Family = "null",
        BirthDate = default,
        Sex = default,
        Address = "null",
        Phone = "+7 (123) 456-78-90",
        Email = email,
        IT_Experience = "null",
        ScopeOfActivityLevelOneId = default
      };
    };

    //Assert
    Assert.That(act, Throws.InstanceOf<ValidationException>());
  }

  [TestCaseSource(nameof(IncorrectPhoneTestCases))]
  public void StudentCreate_IncorrectPhone(string phone)
  {
    //Act
    TestDelegate act = () =>
    {
      var student = new Student
      {
        Family = "null",
        BirthDate = default,
        Sex = default,
        Address = "null",
        Phone = phone,
        Email = "test@gmail.com",
        IT_Experience = "null",
        ScopeOfActivityLevelOneId = default
      };
    };

    //Assert
    Assert.That(act, Throws.InstanceOf<ValidationException>());
  }

  [TestCaseSource(nameof(IncorrectSNILSTestCases))]
  public void StudentCreate_IncorrectSNILS(string SNILS)
  {
    //Act
    TestDelegate act = () =>
    {
      var student = new Student
      {
        Family = "null",
        BirthDate = default,
        Sex = default,
        Address = "null",
        SNILS = SNILS,
        Phone = "+7 (123) 456-78-90",
        Email = "test@gmail.com",
        IT_Experience = "null",
        ScopeOfActivityLevelOneId = default
      };
    };

    //Assert
    Assert.That(act, Throws.InstanceOf<ValidationException>());
  }
}
