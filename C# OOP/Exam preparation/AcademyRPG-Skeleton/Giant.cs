using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Giant : Character, IFighter, IGatherer
    {
        private int attackPoints;

        public Giant(string name, Point position)
            : base(name, position, 0)
        {
            this.HitPoints = 200;
            GatheredRock = false;
            this.attackPoints = 150;
        }

        public bool GatheredRock { get; private set; }

        public int AttackPoints
        {
            get { return attackPoints; }
            private set { }
        }

        public int DefensePoints
        {
            get { return 80; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                return true;
            }

            return false;
        }

        public void IncreaseAttackPoints()
        {
            this.attackPoints += 100;
        }
    }
}
