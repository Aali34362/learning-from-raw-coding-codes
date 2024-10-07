using Builder.GPTExample.Model;
using System.Diagnostics;
using System;

namespace Builder.GPTExample;


//Create a Director Class (Optional)
//The Director class (optional) is used to manage the building process.
//It knows the order in which to execute the building steps to construct a
//particular type of car.This is useful when you have predefined configurations
//or want to abstract the build logic even further.

public class Director
{
    public void ConstructSportsCar(ICarBuilder builder)
    {
        builder.SetModel("Sports Car")
               .SetEngine("V8")
               .SetNumberOfSeats(2)
               .SetTransmission("Manual")
               .SetGPS(true);
    }

    public void ConstructSUV(ICarBuilder builder)
    {
        builder.SetModel("SUV")
               .SetEngine("V6")
               .SetNumberOfSeats(7)
               .SetTransmission("Automatic")
               .SetGPS(true);
    }
}
