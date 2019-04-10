namespace AnimalCentre.Models.Contracts
{
    public interface IProcedure
    {
        void DoService(IAnimal animal, int procedureTime);

        string History();
    }
}
