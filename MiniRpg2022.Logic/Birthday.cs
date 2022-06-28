namespace Videogame;

public partial class Birthday
{
    private DateOnly _birthday;

    private Birthday(DateOnly today, DateOnly birthday)
    {
        if (birthday == DateOnly.MinValue || birthday == DateOnly.MaxValue) throw new ArgumentException("Invalid birthday", nameof(birthday));
        if (today == DateOnly.MinValue || today == DateOnly.MaxValue) throw new ArgumentException("Invalid today", nameof(today));
        if (birthday > today) throw new ArgumentException("Cannot be born after today", nameof(birthday));
        if (today.Year - birthday.Year > 300) throw new ArgumentException("Cannot have more than 300 years", nameof(birthday));

        _birthday = birthday;
    }

    public override string ToString() => _birthday.ToString("yyyy/MM/dd");
}