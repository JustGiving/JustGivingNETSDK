﻿namespace JustGivingSDK.Contracts.Fundraising
{
    public class Pagination
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int PageSizeRequested { get; set; }
        public int PageSizeReturned { get; set; }
        public int TotalResults { get; set; }
    }
}