using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Email.SendUserWelcome
{
    public class WelcomeEmailConverter
    {
        public WelcomeEmailConverter() { }

        public virtual IResponse Convert()
        {
            return new SendUserWelcomeEmailResponse();
        }
    }
}
