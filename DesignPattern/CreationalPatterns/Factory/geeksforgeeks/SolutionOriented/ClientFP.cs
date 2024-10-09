using Factory.geeksforgeeks.ProblemOriented;

namespace Factory.geeksforgeeks.SolutionOriented;

public class ClientFP
{
    private VehicleFP pVehicle;

    public ClientFP(IVehicleFactory factory)
    {
        pVehicle = factory.createVehicle();
    }

    public VehicleFP getVehicle() => pVehicle;
}
