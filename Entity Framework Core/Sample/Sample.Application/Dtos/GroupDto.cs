using Sample.Domain.Enums;

namespace Sample.Application.Dtos
{
    public class GroupDto
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public string Description { get; set; }

        public GroupTypeEnum GroupTypeEnum { get; set; }

        public string CreatedBy { get; set; }
    }
}