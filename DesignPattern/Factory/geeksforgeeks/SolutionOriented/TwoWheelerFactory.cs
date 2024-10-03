using Factory.geeksforgeeks.ProblemOriented;

namespace Factory.geeksforgeeks.SolutionOriented;

// Concrete Factory for TwoWheeler
public class TwoWheelerFactory : IVehicleFactory
{
    public VehicleFP createVehicle()
    {
        return new TwoWheelerFP();
    }
}
