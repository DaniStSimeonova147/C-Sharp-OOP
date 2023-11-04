namespace E06.Elite.Constraints
{
   public interface IMission
    {
        string CodeName { get; }

        string State { get; }

        void CompleteMission();
    }
}
