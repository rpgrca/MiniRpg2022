namespace Videogame;

public partial class Character
{
    public class Builder
    {
        private string _name;
        private string _nickname;
        private Birthday _birthday;
        private IOccupation _occupation;

        public Builder()
        {
            _name = string.Empty;
            _nickname = string.Empty;
        }

        public Builder Called(string name)
        {
            _name = name;
            return this;
        }

        public Builder AlsoKnownAs(string nickname)
        {
            _nickname = nickname;
            return this;
        }

        public Builder BornOn(Birthday birthday)
        {
            _birthday = birthday;
            return this;
        }

        public Builder As(IOccupation occupation)
        {
            _occupation = occupation;
            return this;
        }

        public Character Build() => new(_name, _nickname, _birthday, _occupation);
    }
}