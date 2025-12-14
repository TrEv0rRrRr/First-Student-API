using eb7414u20231b475.API.Shared.Domain.Model.Exceptions;

namespace eb7414u20231b475.API.Operations.Domain.Model.Entities
{
    /// <summary>
    /// Represents a student
    /// </summary>
    /// <remarks>Author: Valentino Solis</remarks>
    public partial class Student
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int DistrictId { get; private set; }
        public int ParentId { get; private set; }

        public Student(int Id, string FirstName, string LastName, int DistrictId, int ParentId)
        {
            ValidateDistrict(DistrictId);

            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DistrictId = DistrictId;
            this.ParentId = ParentId;
        }

        public void ValidateDistrict(int districtId)
        {
            if (districtId is < 1 or > 3) throw new BusinessRuleException("The district id must be greater than 1 and less than 3.");
        }
    }
}