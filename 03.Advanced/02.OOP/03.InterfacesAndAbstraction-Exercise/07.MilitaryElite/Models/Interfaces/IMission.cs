namespace MilitaryElite.Models.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }
        string State { get; }//inProgress, Finished

        void CompleteMission();
    }
}
