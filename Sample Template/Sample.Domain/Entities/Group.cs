using Sample.Domain.Enums;

namespace Sample.Domain.Entities
{
    public class Group : BaseEntity
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public string Description { get; set; }

        public GroupTypeEnum GroupTypeEnum { get; set; }
    }
}
