namespace Sautom.Client.Comunication.Services
{
    internal class BoolWrapper
    {
        public BoolWrapper(bool value)
        {
            Value = value;
        }

        public bool Value { get; set; }
    }
}