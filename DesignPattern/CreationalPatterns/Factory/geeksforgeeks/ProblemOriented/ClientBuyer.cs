namespace Factory.geeksforgeeks.ProblemOriented;

public class ClientBuyer
{
    private Vehicle pVehicle;
    public ClientBuyer(int type)
    {
        if (type == 1)
            pVehicle = new TwoWheeler();
        else if (type == 2)
            pVehicle = new FourWheeler();
        else
            pVehicle = null!;
    }

    public void cleanup()
    {
        if (pVehicle != null)
            pVehicle = null!;
    }

    public Vehicle getVehicle() => pVehicle;
}
