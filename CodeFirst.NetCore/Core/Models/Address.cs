using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class Address : Entity
    {
        public int UserId { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public Coordinate Coordinates { get; set; }

        public Address()
        {

        }

        public Address(int id,int userId,string street, string suite, string city, string zipCode, Coordinate coordinates)
        {
            Id = id;
            UserId = userId;
            Street = street;
            Suite = suite;
            City = city;
            ZipCode = zipCode;
            Coordinates = coordinates;
        }
    }
}
