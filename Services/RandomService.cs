namespace Backend.Services
{
    public class RandomService : IRandomService
    {
        private readonly int _value;

        public int Value { get { return _value; } }

        public RandomService()
        {
            _value = new Random().Next(0, 1000);
        }
    }
}
