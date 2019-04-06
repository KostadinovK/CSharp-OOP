
public class PrimitiveCalculator
{
    private IStrategy strategy;

    public PrimitiveCalculator()
    {
        strategy = new AdditionStrategy();
    }

    public void ChangeStrategy(char @operator)
    {
        switch (@operator)
        {
            case '+':
                strategy = new AdditionStrategy();
                break;
            case '-':
                strategy = new SubtractionStrategy();
                break;
            case '*':
                strategy = new MultiplicationStrategy();
                break;
            case '/':
                strategy = new DivisionStrategy();
                break;
        }
    }

    public int PerformCalculation(int firstOperand, int secondOperand)
    {
        return strategy.Calculate(firstOperand, secondOperand);
    }
}
