using System;
using System.Collections.Generic;

#nullable disable

namespace Airline_H3.Models
{
    public partial class FlightRoute
    {
        public int Id { get; set; }
        public int? Ownerid { get; set; }
        public int? Operatorid { get; set; }
        public int? FromDestAirport { get; set; }
        public int? ToDestAirport { get; set; }
        public int? AirplainId { get; set; }

        public virtual Airplain Airplain { get; set; }
        public virtual Airport FromDestAirportNavigation { get; set; }
        public virtual Airline Operator { get; set; }
        public virtual Airline Owner { get; set; }
        public virtual Airport ToDestAirportNavigation { get; set; }
    }
}
