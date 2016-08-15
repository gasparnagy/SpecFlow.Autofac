namespace MyCalculator
{
    public interface ICalculator
    {
        int Result { get; }
        void Enter(int operand);
        void Add();
        void Multiply();
    }
}