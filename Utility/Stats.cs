public record class Element()
{

}


public record class Class()
{
    public required Stats Stats { get; init; }
}

public record class Stats()
{
    public required Attribute Wisdom { get; init; }
    public required Attribute Perception { get; init; }
    public required Attribute Charisma { get; init; }
    public required Attribute Vitality { get; init; }
    public required Attribute Fortitude { get; init; }
    public required Attribute Strength { get; init; }
    public required Attribute Dexterity { get; init; }
    public required Attribute Luck { get; init; }
}


public record struct Attribute(int Base, double Multiplier = 1)
{
    public int Level { get; set; }
}

public static class Classes
{
    public static Class Warrior { get; } = new()
    {
        Stats = new()
        {
            Wisdom = new(5),
            Perception = new(5),
            Charisma = new(5),
            Vitality = new(5),
            Fortitude = new(5),
            Strength = new(5),
            Dexterity = new(5),
            Luck = new(5),
        },
    };
    public static Class Mage { get; } = new()
    {
        Stats = new()
        {
            Wisdom = new(5),
            Perception = new(5),
            Charisma = new(5),
            Vitality = new(5),
            Fortitude = new(5),
            Strength = new(5),
            Dexterity = new(5),
            Luck = new(5),
        },
    };
    public static Class Rogue { get; } = new()
    {
        Stats = new()
        {
            Wisdom = new(5),
            Perception = new(5),
            Charisma = new(5),
            Vitality = new(5),
            Fortitude = new(5),
            Strength = new(5),
            Dexterity = new(5),
            Luck = new(5),
        },
    };
}