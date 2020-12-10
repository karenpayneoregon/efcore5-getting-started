using System;

namespace StoredProcedureEntityFrameworkCore1.ProcedureClasses
{
    /// <summary>
    /// Container for stored procedure results
    /// </summary>
    public partial class CustomersByCountryIdentifierStoredProcedure
    {
        public int CustomerIdentifier { get; set; }
        public string CompanyName { get; set; }
        public int? ContactId { get; set; }
        public string ContactTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public int? ContactTypeIdentifier { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CountryIdentifier { get; set; }
        public string Name { get; set; }
    }
}
