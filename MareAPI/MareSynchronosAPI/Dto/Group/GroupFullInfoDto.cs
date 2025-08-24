using ARPSynchronos.API.Data;
using ARPSynchronos.API.Data.Enum;
using MessagePack;

namespace ARPSynchronos.API.Dto.Group;

[MessagePackObject(keyAsPropertyName: true)]
public record GroupFullInfoDto(GroupData Group, UserData Owner, GroupPermissions GroupPermissions,
    GroupUserPreferredPermissions GroupUserPermissions, GroupPairUserInfo GroupUserInfo,
    Dictionary<string, GroupPairUserInfo> GroupPairUserInfos) : GroupInfoDto(Group, Owner, GroupPermissions)
{
    public GroupUserPreferredPermissions GroupUserPermissions { get; set; } = GroupUserPermissions;
    public GroupPairUserInfo GroupUserInfo { get; set; } = GroupUserInfo;
}