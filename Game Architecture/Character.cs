namespace GameArchitecture {
    public class Character
    {
        public string Name { get; set; }
        public Appearance Appearance { get; set; }
        public List<Ability> Abilities { get; set; }
        public List<Equipment> Equipment { get; set; }
        public Attributes Attributes { get; set; }

        public Character(string name)
        {
            Name = name;
            Abilities = new List<Ability>();
            Equipment = new List<Equipment>();
        }
    }
    public class Appearance
    {
        public string ?HairColor { get; set; }
        public string ?EyeColor { get; set; }
        public string ?ArmorStyle { get; set; }
    }

    public class Ability
    {
        public string Name { get; set; }
        public string ?Description { get; set; }
        public int Power { get; set; }
    }

    public class Equipment
    {
        public string Name { get; set; }
        public string ?Type { get; set; }
        public int Armor { get; set; }
    }

    public class Attributes
    {
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
    }
    public class WarriorFactory : CharacterFactory
    {
        public override Character CreateCharacter(string name)
        {
            var character = new Character(name)
            {
                Appearance = new Appearance
                {
                    HairColor = "Black",
                    EyeColor = "Brown",
                    ArmorStyle = "Plate"
                },
                Attributes = new Attributes
                {
                    Strength = 10,
                    Agility = 5,
                    Intelligence = 3
                }
            };
            character.Abilities.Add(new Ability { Name = "Slash", Description = "A powerful sword attack", Power = 8 });
            character.Equipment.Add(new Equipment { Name = "Sword", Type = "Weapon" });
            return character;
        }
    }

    public class MageFactory : CharacterFactory
    {
        public override Character CreateCharacter(string name)
        {
            var character = new Character(name)
            {
                Appearance = new Appearance
                {
                    HairColor = "White",
                    EyeColor = "Blue",
                    ArmorStyle = "Robe"
                },
                Attributes = new Attributes
                {
                    Strength = 3,
                    Agility = 6,
                    Intelligence = 10
                }
            };
            character.Abilities.Add(new Ability { Name = "Fireball", Description = "A fiery explosive spell", Power = 9 });
            character.Equipment.Add(new Equipment { Name = "Staff", Type = "Weapon" });
            return character;
        }
    }

    public class ArcherFactory : CharacterFactory
    {
        public override Character CreateCharacter(string name)
        {
            var character = new Character(name)
            {
                Appearance = new Appearance
                {
                    HairColor = "Blonde",
                    EyeColor = "Green",
                    ArmorStyle = "Leather"
                },
                Attributes = new Attributes
                {
                    Strength = 6,
                    Agility = 10,
                    Intelligence = 4
                }
            };
            character.Abilities.Add(new Ability { Name = "Piercing Arrow", Description = "A swift arrow strike", Power = 7 });
            character.Equipment.Add(new Equipment { Name = "Bow", Type = "Weapon", Armor = 2 });
            return character;
        }
    }
    public abstract class CharacterFactory
    {
        public abstract Character CreateCharacter(string name);
    }
}