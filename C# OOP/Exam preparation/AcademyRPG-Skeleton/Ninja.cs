using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter, IGatherer
    {
        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 1;
        }

        public int AttackPoints
        {
            get { return this.AttackPoints; }
            private set { }
        }

        public int DefensePoints
        {
            get { return this.DefensePoints; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            availableTargets.Sort();
            availableTargets.Reverse();

            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0 && availableTargets[i].Owner != this.Owner)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone || resource.Type == ResourceType.Lumber)
            {
                return true;
            }

            return false;
        }

        internal void IncreaseAttackPointsLumber(int lumberQuantity)
        {
            this.AttackPoints += lumberQuantity;
        }

        internal void IncreaseAttackPointsStone(int stoneQuantity)
        {
            this.AttackPoints += stoneQuantity * 2;
        }
    }
}
