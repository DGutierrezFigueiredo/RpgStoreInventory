namespace McInventoryManagement.Domain.Entities
{
    public interface IMcFundsCalculator
    {
        public void McFundsSet(double fund);

        public void McFundsIncrease();

        public void McFundsDecrease();

        public double GetMcFunds();
        
    }
}