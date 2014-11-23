using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class ExtendedInteractionManager: InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new WoodItem(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new IronItem(itemNameString, itemLocation);
                    break;

                default: return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }

            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;

                default: return base.CreateLocation(locationTypeString, locationName);
            }
            return location;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default: return base.CreatePerson(personTypeString, personNameString, personLocation);
            }
            return person;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherCommand(actor, commandWords[2]);
                    break;
                case "craft":
                    HandleCraftCommand(actor, commandWords[2], commandWords[3]);
                    break;
                default: base.HandlePersonCommand(commandWords, actor); 
                    break;
            }
            
        }

        private void HandleCraftCommand(Person actor, string itemType, string itemName)
        {
            switch (itemType)
            {
                case "armor":
                    {
                        foreach (var item in actor.ListInventory())
                        {
                            if (item.ItemType.Equals(ItemType.Iron))
                            {
                                actor.AddToInventory(new Armor(itemName, null));
                            }
                        }

                        break;
                    }
                case "weapon":
                    {
                        bool hasWood = false;
                        bool hasIron = false;

                        foreach (var item in actor.ListInventory())
                        {
                            if (item.ItemType.Equals(ItemType.Iron))
                            {
                                hasIron = true;
                            }
                            if (item.ItemType.Equals(ItemType.Wood))
                            {
                                hasWood = true;
                            }
                        }

                        if (hasWood && hasIron)
                        {
                            actor.AddToInventory(new Weapon(itemName, null));
                        }

                        break;
                    }
                default:
                    break;
            };
        }


        private void HandleGatherCommand(Person actor, string itemName)
        {
            IGatheringLocation actorsLocation = actor.Location as IGatheringLocation;

            if (actorsLocation != null)
            {
                foreach (var item in actor.ListInventory())
                {
                    if (item.ItemType.Equals(actorsLocation.RequiredItem))
                    {
                        //this.AddToPerson(actor, actorsLocation.ProduceItem(itemName));
                          actor.AddToInventory(actorsLocation.ProduceItem(itemName));
                          break;
                    }
                }
            }
        }
    }
}
