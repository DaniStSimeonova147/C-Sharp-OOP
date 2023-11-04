using E06.Elite.Models;

namespace E06.Elite.Factories
{
    public class RepairFactory
    {
        public Repair MakeRepair(string partName, int hoursWorked)
        {
            Repair repair = new Repair(partName, hoursWorked);

            return repair;
        }
    }
}