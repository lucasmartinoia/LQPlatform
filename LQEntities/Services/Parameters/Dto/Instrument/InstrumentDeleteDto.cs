﻿using System;

namespace INOM.Entities.Services.Parameters.Dto.Instrument
{
    public class InstrumentDeleteDto
    {
        public int? InstrumentFamilyID { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime? VerifiedDateTime { get; set; }
        public string VerifiedUser { get; set; }
    }
}
