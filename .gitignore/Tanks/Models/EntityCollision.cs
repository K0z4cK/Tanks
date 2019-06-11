using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks.Models
{
    public class EntityCollision
    {
        public Entity TargetEntity { get; private set; }

        public EntityCollision(Entity targetEntity)
        {
            this.TargetEntity = targetEntity;
        }
    }
}
