namespace Builder.GPTExample.Model;

//Define the Car Class
//The Car class represents the complex object that we want to build using the Builder pattern.
public class Car
{
    public string? Model { get; set; }
    public string? EngineType { get; set; }
    public int NumberOfSeats { get; set; }
    public string? Transmission { get; set; }
    public bool HasGPS { get; set; }

    public override string ToString()
    {
        return $"Model: {Model}, Engine: {EngineType}, Seats: {NumberOfSeats}, Transmission: {Transmission}, GPS: {(HasGPS ? "Yes" : "No")}";
    }
}
