namespace Enums
{
    [System.Flags]
    public enum Ingredients
    {
        Eggs           =        0b1,
        Bacon          =       0b10,
        Sausages       =      0b100,
        Mushrooms      =     0b1000,
        Tomato         =   0b1_0000,
        BlackPudding   =  0b10_0000,
        BakedBeans     = 0b100_0000,
        TheFullEnglish = 0b111_1111
    }
}