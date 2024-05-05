using Sample.Domain.Enums;

namespace Sample.Application.Models.Request.Group
{
    public class UpdateGroupRequest
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public string Description { get; set; }

        public GroupTypeEnum GroupTypeEnum { get; set; }
    }
}
