using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects.Entities
{
    internal class RobberyMessage : ValueChangedMessage<RobberyMessageDetailEntity>
    {
        public RobberyMessage(RobberyMessageDetailEntity value) : base(value)
        {
        }
    }
}
