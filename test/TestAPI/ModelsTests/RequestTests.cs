using System.ComponentModel.DataAnnotations;
using Students.Models;

namespace TestAPI.ModelsTests;

[TestFixture]
public class RequestTests
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

  [Test]
  public void RequestCreate_Success()
  {
    //Act
    TestDelegate act = () =>
    {
      var request = new Request
      {
        Phone = "+7 (123) 456-78-90",
        Email = "test@gmail.com",
        Agreement = false,
      };
    };

    //Assert
    Assert.DoesNotThrow(act);
  }

  [TestCaseSource(nameof(IncorrectEmailTestCases))]
  public void RequestCreate_IncorrectEmail(string email)
  {
    //Act
    TestDelegate act = () =>
    {
      var request = new Request
      {
        Phone = "+7 (123) 456-78-90",
        Email = email,
        Agreement = false,
      };
    };

    //Assert
    Assert.That(act, Throws.InstanceOf<ValidationException>());
  }

  [TestCaseSource(nameof(IncorrectPhoneTestCases))]
  public void RequestCreate_IncorrectPhone(string phone)
  {
    //Act
    TestDelegate act = () =>
    {
      var student = new Request
      {
        Phone = phone,
        Email = "test@gmail.com",
        Agreement = false
      };
    };

    //Assert
    Assert.That(act, Throws.InstanceOf<ValidationException>());
  }
}
