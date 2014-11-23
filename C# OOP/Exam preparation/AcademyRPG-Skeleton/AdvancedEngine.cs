using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class AdvancedEngine : Engine
    {
        public override void ExecuteCreateObjectCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "knight":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        int owner = int.Parse(commandWords[4]);
                        this.AddObject(new Knight(name, position, owner));
                        break;
                    }
                case "house":
                    {
                        Point position = Point.Parse(commandWords[2]);
                        int owner = int.Parse(commandWords[3]);
                        this.AddObject(new House(position, owner));
                        break;
                    }
                case "giant":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        this.AddObject(new Giant(name, position));
                        break;
                    }
                case "rock":
                    {
                        int hitPoints = int.Parse(commandWords[2]);
                        Point position = Point.Parse(commandWords[3]);
                        this.AddObject(new Rock(hitPoints, position));
                        break;
                    }
                case "ninja":
                    {
                        break;
                    }
                default: base.ExecuteCreateObjectCommand(commandWords); break;
            }
        }

        public override void ExecuteControllableCommand(string[] commandWords)
        {
            string controllableName = commandWords[0];
            IControllable current = null;

            for (int i = 0; i < this.controllables.Count; i++)
            {
                if (controllableName == this.controllables[i].Name)
                {
                    current = this.controllables[i];
                }
            }

            if (current != null)
            {
                switch (commandWords[1])
                {
                    case "go":
                        {
                            HandleGoCommand(commandWords, current);
                            break;
                        }
                    case "attack":
                        {
                            HandleAttackCommand(current);
                            break;
                        }
                    case "gather":
                        {
                            HandleGatherCommand(current);
                            break;
                        }
                }
            }
        }

        private void HandleGoCommand(string[] commandWords, IControllable current)
        {
            var currentAsMoving = current as MovingObject;
            currentAsMoving.GoTo(Point.Parse(commandWords[2]));
            Console.WriteLine("{0} is now at position {1}", current, current.Position);
        }

        private void HandleAttackCommand(IControllable current)
        {
            var currentAsFighter = current as IFighter;
            if (currentAsFighter != null)
            {
                List<WorldObject> availableTargets = new List<WorldObject>();
                foreach (var obj in this.allObjects)
                {
                    if (obj.Position == current.Position)
                    {
                        availableTargets.Add(obj);
                    }
                }

                int targetIndex = currentAsFighter.GetTargetIndex(availableTargets);
                if (targetIndex != -1)
                {
                    this.HandleBattle(currentAsFighter, availableTargets[targetIndex]);
                }
                else
                {
                    Console.WriteLine("No targets to attack at {0}'s position", current);
                }
            }
            else
            {
                Console.WriteLine("{0} can't do that", current);
            }
        }

        private void HandleBattle(IFighter attacker, WorldObject defender)
        {
            var defenderAsFighter = defender as IFighter;

            if (defenderAsFighter as Ninja == null)
            {
                int defenderDefensePoints = 0;
                if (defenderAsFighter != null)
                {
                    defenderDefensePoints = defenderAsFighter.DefensePoints;
                }

                int damage = attacker.AttackPoints - defenderDefensePoints;

                if (damage < 0)
                {
                    damage = 0;
                }

                if (damage > defender.HitPoints)
                {
                    damage = defender.HitPoints;
                }

                defender.HitPoints -= damage;

                Console.WriteLine("{0} attacked {1} and did {2} damage", attacker, defender, damage);
            }
        }

        private void HandleGatherCommand(IControllable current)
        {
            var currentAsGatherer = current as IGatherer;
            if (currentAsGatherer != null)
            {
                //List<WorldObject> objectsAtGathererPosition = new List<WorldObject>();
                IResource resource = null;
                foreach (var obj in this.resources)
                {
                    if (obj.Position == current.Position)
                    {
                        resource = obj;
                        break;
                    }
                }

                if (resource != null)
                {
                    HandleGathering(currentAsGatherer, resource);
                }
                else
                {
                    Console.WriteLine("No resource to gather at {0}'s position", current);
                }
            }
            else
            {
                Console.WriteLine("{0} can't do that", current);
            }
        }

        private void HandleGathering(IGatherer gatherer, IResource resource)
        {
            bool gatheringSuccess = gatherer.TryGather(resource);
            if (gatheringSuccess)
            {
                Console.WriteLine("{0} gathered {1} {2} from {3}", gatherer, resource.Quantity, resource.Type, resource);

                if (gatherer as Giant != null && resource.Type.Equals(ResourceType.Stone))
                {
                    (gatherer as Giant).IncreaseAttackPoints();
                }

                if (gatherer as Ninja != null && resource.Type.Equals(ResourceType.Lumber))
                {
                    (gatherer as Ninja).IncreaseAttackPointsLumber(resource.Quantity);
                }

                if (gatherer as Ninja != null && resource.Type.Equals(ResourceType.Stone))
                {
                    (gatherer as Ninja).IncreaseAttackPointsStone(resource.Quantity);
                }

                resource.HitPoints = 0;
            }
        }
    }
}
