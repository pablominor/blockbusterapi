using BlockbusterApp.src.Shared.Domain;
using BlockbusterApp.src.Shared.Domain.Exception;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Stub.Email;

namespace UnitTest.Shared.Domain
{
    [TestFixture]
    public class EmailModelTest
    {

        [Test]
        public void ItShouldThrowExceptionFromInvalidFrom()
        {

            string invalidFrom = "blockbusterinvalidfrom";

            var Exception = Assert.Throws<InvalidAttributeException>(() => 
            new EmailModel(
                invalidFrom, 
                EmailModelStub.TO, 
                EmailModelStub.SUBJECT, 
                EmailModelStub.BODY));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromValue("from", invalidFrom));
            Assert.IsInstanceOf<InvalidEmailException>(Exception);
        }

        [Test]
        public void ItShouldThrowExceptionFromInvalidTo()
        {

            string invalidTo = "blockbusterinvalidto";

            var Exception = Assert.Throws<InvalidAttributeException>(() =>
            new EmailModel(
                EmailModelStub.FROM,
                invalidTo,
                EmailModelStub.SUBJECT,
                EmailModelStub.BODY));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromValue("to", invalidTo));
            Assert.IsInstanceOf<InvalidEmailException>(Exception);
        }

        [Test]
        public void ItShouldThrowExceptionFromInvalidSubject()
        {

            string invalidSubject = "";

            var Exception = Assert.Throws<InvalidAttributeException>(() =>
            new EmailModel(
                EmailModelStub.FROM,
                EmailModelStub.TO,
                invalidSubject,
                EmailModelStub.BODY));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromEmpty("subject"));
            Assert.IsInstanceOf<InvalidEmailException>(Exception);
        }

        [Test]
        public void ItShouldThrowExceptionFromInvalidBody()
        {

            string invalidBody = "";

            var Exception = Assert.Throws<InvalidAttributeException>(() =>
            new EmailModel(
                EmailModelStub.FROM,
                EmailModelStub.TO,
                EmailModelStub.SUBJECT,
                invalidBody));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromEmpty("body"));
            Assert.IsInstanceOf<InvalidEmailException>(Exception);
        }

        [Test]
        public void ItShouldCreateNewEmailModel()
        {

            EmailModel emailModel = new EmailModel(
                EmailModelStub.FROM,
                EmailModelStub.TO,
                EmailModelStub.SUBJECT,
                EmailModelStub.BODY);

            Assert.IsNotNull(emailModel);
            Assert.AreEqual(emailModel.GetFrom(), EmailModelStub.FROM);
            Assert.AreEqual(emailModel.GetTo(), EmailModelStub.TO);
            Assert.AreEqual(emailModel.GetSubject(), EmailModelStub.SUBJECT);
            Assert.AreEqual(emailModel.GetBody(), EmailModelStub.BODY);
        }
    }
}
