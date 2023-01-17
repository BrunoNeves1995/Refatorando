using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;

namespace Refatorando.Domain.Entities
{
    public class Entity : Notifiable<Notification>
    {
        public Entity()
        {
            Id = Guid.Parse(Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10));
        }

        public Guid Id { get; private set; }

       
    }
}