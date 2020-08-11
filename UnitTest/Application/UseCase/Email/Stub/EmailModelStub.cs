using BlockbusterApp.src.Shared.Domain;

namespace UnitTest.Application.UseCase.Email.Stub
{
    public class EmailModelStub
    {
        public const string FROM = "blockbusterApp@mail.com";
        public const string TO = "blockbuster@mail.com";
        public const string SUBJECT = "Welcome";
        public const string BODY = "Welcome to blockbusterapp";

        public static EmailModel ByDefault()
        {
            return Create(FROM,TO, SUBJECT, BODY);            
        }

        private static EmailModel Create(string From,string To, string Subject, string Body)
        {
            return new EmailModel(From,To, Subject, Body);
        }
    }
}
