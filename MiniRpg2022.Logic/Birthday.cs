namespace Videogame;

public class Birthday
{
    public class Builder
    {
        private DateOnly _today = DateOnly.FromDateTime(DateTime.Now);
        private DateOnly _birthday;

        public Builder BeingToday(DateOnly today)
        {
            _today = today;
            return this;
        }

        public Builder BornOn(DateOnly birthday)
        {
            _birthday = birthday;
            return this;
        }

        public Birthday Build() => new(_today, _birthday);
    }

    private DateOnly _birthday;

    private Birthday(DateOnly today, DateOnly birthday)
    {
        if (birthday == DateOnly.MinValue) throw new ArgumentException("Invalid birthday", nameof(birthday));
        if (today == DateOnly.MinValue) throw new ArgumentException("Invalid today", nameof(today));
        if (Math.Abs(today.Year - birthday.Year) > 300) throw new ArgumentException("Invalid birthday", nameof(birthday));
        _birthday = birthday;
    }

    public override string ToString() => _birthday.ToString();
}