using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects.Entities
{
    internal class PersonMessage : ValueChangedMessage<string>

    {
        public PersonMessage(string value) : base(value)
        {
        }
    }
}
