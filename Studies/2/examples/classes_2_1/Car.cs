using System;

namespace classes_2_1
{
    class Car
    {
        Person Owner { get; set; }
        string LicenseNr { get; set; }
        byte Seating { get; set; } = 5;
        string MakeAndModel { get; }
        string VIN { get; }
        bool AirConditioning { get; } = true;
        
        public Car(string makeModel)
        {
            MakeAndModel = makeModel;
        }
        public void CopyFrom(Car s) // set car's data according to s
        {
            LicenseNr = s.LicenseNr;
            // VIN = s.VIN; // getter-only, we can set a value only in constructor
        }
    }
}
