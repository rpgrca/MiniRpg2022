namespace Videogame;

public partial class Birthday
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
}