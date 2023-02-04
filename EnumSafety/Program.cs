/* enum safety problem
out of range integer value cause problem (number 7 for weekdays (0 to 6))
it's not extendable for fields and features
we can use type-safe pattern for enums
*/

#region problem
int x1 = 6;
DayOfWeekEnum x2 = (DayOfWeekEnum)x1;
Console.WriteLine($"problem region: value for {x1} is {x2}");

int y1 = 7;
DayOfWeekEnum y2 = (DayOfWeekEnum)y1;
Console.WriteLine($"problem region: value for {y1} is {y2}");
#endregion

#region sealed solution
var z1 = DayOfWeekSealed.Wednesday;
Console.WriteLine($"sealed solution region: value for {z1.GetDayOfWeekSealed()}");
#endregion

#region struct solution
var w1 = DayOfWeekStruct.Friday;
Console.WriteLine($"struct solution region: value for {w1.GetDayOfWeekStruct()}");
#endregion

enum DayOfWeekEnum
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

sealed class DayOfWeekSealed
{
    public static readonly DayOfWeekSealed Monday = new(0);
    public static readonly DayOfWeekSealed Tuesday = new(1);
    public static readonly DayOfWeekSealed Wednesday = new(2);
    public static readonly DayOfWeekSealed Thursday = new(3);
    public static readonly DayOfWeekSealed Friday = new(4);
    public static readonly DayOfWeekSealed Saturday = new(5);
    public static readonly DayOfWeekSealed Sunday = new(6);

    private readonly int _value;

    private DayOfWeekSealed(int value)
    {
        _value = value;
    }

    public int GetDayOfWeekSealed()
    {
        return _value;
    }
}

struct DayOfWeekStruct
{
    public static readonly DayOfWeekStruct Monday = new(0);
    public static readonly DayOfWeekStruct Tuesday = new(1);
    public static readonly DayOfWeekStruct Wednesday = new(2);
    public static readonly DayOfWeekStruct Thursday = new(3);
    public static readonly DayOfWeekStruct Friday = new(4);
    public static readonly DayOfWeekStruct Saturday = new(5);
    public static readonly DayOfWeekStruct Sunday = new(6);

    private readonly int _value;

    private DayOfWeekStruct(int value)
    {
        _value = value;
    }

    public int GetDayOfWeekStruct()
    {
        return _value;
    }

    public bool Equals(DayOfWeekStruct other)
    {
        return _value == other._value;
    }

    public override bool Equals(object obj)
    {
        if (obj is null)
        {
            return false;
        }
        return obj is DayOfWeekStruct @dayOfWeekStruct && Equals(@dayOfWeekStruct);
    }

    public override int GetHashCode()
    {
        return _value;
    }

    public static bool operator ==(DayOfWeekStruct op1, DayOfWeekStruct op2)
    {
        return op1.Equals(op2);
    }

    public static bool operator !=(DayOfWeekStruct op1, DayOfWeekStruct op2)
    {
        return !(op1 == op2);
    }
}