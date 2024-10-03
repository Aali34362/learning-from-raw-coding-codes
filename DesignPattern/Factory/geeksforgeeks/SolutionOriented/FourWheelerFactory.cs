using Factory.geeksforgeeks.ProblemOriented;

namespace Factory.geeksforgeeks.SolutionOriented;

public class FourWheelerFactory : IVehicleFactory
{
    public VehicleFP createVehicle()
    {
        return new FourWheelerFP();
    }
}
