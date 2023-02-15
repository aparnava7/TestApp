namespace TestApplication.Models
{
    public class GroupDto
    {
        public String GroupCode { get; set; }
        public String GroupDescription { get; set; }
        public string GroupType { get; set; }

        public GroupDto(string groupCode, string groupDescription, string groupType)
        {
            GroupCode = groupCode;
            GroupDescription = groupDescription;
            GroupType = groupType;
        }
    }
}
