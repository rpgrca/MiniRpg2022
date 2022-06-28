namespace Videogame;

public partial class Character
{
    public class Builder
    {
        private string _name;
        private string _nickname;
        private Birthday _birthday;
        private IOccupation _occupation;
        private int _speed;
        private int _dexterity;
        private int _strength;

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

        public Builder WithSpeedOf(int speed)
        {
            _speed = speed;
            return this;
        }

        public Builder WithDexterityOf(int dexterity)
        {
            _dexterity = dexterity;
            return this;
        }

        public Builder WithStrengthOf(int strength)
        {
            _strength = strength;
            return this;
        }

        public Character Build() => new(_name, _nickname, _birthday, _occupation, _speed, _dexterity, _strength);
    }
}