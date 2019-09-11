using System;
using System.Collections.Generic;
using System.Text;

namespace UnimedAgendamentos.BLL.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
