﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class EventItem
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string EventImageUrl { get; set; }
        public DateTime EventStartTime { get; set; }
        public DateTime EventEndTime { get; set; }


        public int OrganizerId { get; set; }
        public int AddressId { get; set; }
        public int TypeId { get; set; }
        public int CatagoryId { get; set; }

       

        public EventOrganizer  EventOrganizer { get; set; }
        public Address  Address { get; set; }
        public EventCategory EventCategory { get; set; }
        public EventType EventType { get; set; }



    }
}
