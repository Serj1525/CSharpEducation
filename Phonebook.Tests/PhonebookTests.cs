using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Phonebook.Tests
{
    [TestFixture]
    public class PhonebookTests
    {
        private Phonebook _phonebook;

        [SetUp]
        public void Setup()
        {
            _phonebook = new Phonebook();
        }
        
        /// <summary>
        /// Проверка на добавление абонента.
        /// </summary>
        [TestCase("123","88005553535")]
        [TestCase("!fwfw  w32","+71581581655")]
        [TestCase("1rr","168462315")]
        [TestCase("//wd","1")]
        [TestCase("88413dg"," ")]
        [TestCase("Ctht;rf","awsdsdfs")]
        [TestCase("fkafdbn jlyfrj","//////")]
        [TestCase("Дмитрий","123456791011121314151617181920")]
        [TestCase("Димоон!!!","88005553535")]
        
        public void AddSubscriber_CheckAddSubscriber(string name, string phoneNumber)
        {
            var subscriber = new Subscriber(name,
                new List<PhoneNumber> { new PhoneNumber(phoneNumber, PhoneNumberType.Personal) });
            _phonebook.AddSubscriber(subscriber);

            Assert.That(_phonebook.GetAll(), Has.Member(subscriber));
        }
        
        /// <summary>
        /// Проверка на добавление существующего абонента (с вызовом исключения).
        /// </summary>
        [TestCase("123","88005553535")]
        [TestCase("!fwfw  w32","+71581581655")]
        [TestCase("1rr","168462315")]
        [TestCase("//wd","1")]
        [TestCase("88413dg"," ")]
        [TestCase("Ctht;rf","awsdsdfs")]
        [TestCase("fkafdbn jlyfrj","//////")]
        [TestCase("Дмитрий","123456791011121314151617181920")]
        [TestCase("Димоон!!!","88005553535")]
        public void AddSubscriber_ExistingSubscriber_CheckThrowException(string name, string phoneNumber)
        {
            var subscriber = new Subscriber(name, new List<PhoneNumber> { new PhoneNumber(phoneNumber, PhoneNumberType.Personal) });
            _phonebook.AddSubscriber(subscriber);

            Assert.Throws<InvalidOperationException>(() => _phonebook.AddSubscriber(subscriber));
        }
        
        /// <summary>
        /// Проверка на получение абонента по существующему ID.
        /// </summary>
        [Test]
        public void GetSubscriber_ExistingId_CheckReturnSubscriber()
        {
            var subscriber = new Subscriber("Димоон!", new List<PhoneNumber> { new PhoneNumber("88005553535", PhoneNumberType.Personal) });
            _phonebook.AddSubscriber(subscriber);

            var result = _phonebook.GetSubscriber(subscriber.Id);

            Assert.That(result,Is.EqualTo(subscriber));
        }

        /// <summary>
        /// Проверка на получение несуществующего абонента (с вызовом исключения).
        /// </summary>
        [Test]
        public void GetSubscriber_NonExistingId_CheckThrowException()
        {
            var nonExistingId = Guid.NewGuid();
            Assert.Throws<InvalidOperationException>(() => _phonebook.GetSubscriber(nonExistingId));
        }
        
        /// <summary>
        /// Проверка на удаление абонента из телефонной книги.
        /// </summary>
        [Test]
        public void DeleteSubscriber_CheckRemoveSubscriber()
        {
            var subscriber = new Subscriber("Димоон!", new List<PhoneNumber> { new PhoneNumber("88005553535", PhoneNumberType.Personal) });
            _phonebook.AddSubscriber(subscriber);
            _phonebook.DeleteSubscriber(subscriber);
            _phonebook.DeleteSubscriber(subscriber);
            _phonebook.DeleteSubscriber(subscriber);
            Assert.That(_phonebook.GetAll(), Is.Empty);
        }
        
        /// <summary>
        /// Проверка на обновление имени абонента.
        /// </summary>
        [Test]
        public void RenameSubscriber_CheckUpdateSubscriberName()
        {
            var subscriber = new Subscriber("Димоон!", new List<PhoneNumber> { new PhoneNumber("88005553535", PhoneNumberType.Personal) });
            _phonebook.AddSubscriber(subscriber);
            string newName = "АААААААААА!!!";

            _phonebook.RenameSubscriber(subscriber, newName);
            var updatedSubscriber = _phonebook.GetSubscriber(subscriber.Id);

            Assert.That(updatedSubscriber.Name,Is.EqualTo(newName));
        }
        
        /// <summary>
        /// Проверка на привязку нового номера к абоненту.
        /// </summary>
        [Test]
        public void AddNumberToSubscriber_CheckAddPhoneNumber()
        {
            var subscriber = new Subscriber("Димоон!", new List<PhoneNumber> { new PhoneNumber("88005553535", PhoneNumberType.Personal) });
            _phonebook.AddSubscriber(subscriber);
            var newNumber = new PhoneNumber("88005553536", PhoneNumberType.Work);

            _phonebook.AddNumberToSubscriber(subscriber, newNumber);
            var updatedSubscriber = _phonebook.GetSubscriber(subscriber.Id);

            Assert.That(updatedSubscriber.PhoneNumbers, Has.Member(newNumber));
        }
        
        /// <summary>
        /// Проверка номера телефона с вызовом исключения при валидации
        /// </summary>
        [Test]
        public void Validate_InvalidPhoneNumber_CheckThrowException()
        {
            var invalidNumber = new PhoneNumber("ЭЭЭххххх как звонят КОЛОКОЛАААА!!!", PhoneNumberType.Personal);

            Assert.Throws<ArgumentException>(() => PhoneNumberValidator.Validate(invalidNumber));
        }
        
        /// <summary>
        /// Проверка на вызов исключений рабочего номера
        /// </summary>
        [Test]
        public void Validate_ValidPhoneNumber_CheckNotThrowException()
        {
            var validNumber = new PhoneNumber("88005553535", PhoneNumberType.Work);

            Assert.DoesNotThrow(() => PhoneNumberValidator.Validate(validNumber));
        }
        
    }
}