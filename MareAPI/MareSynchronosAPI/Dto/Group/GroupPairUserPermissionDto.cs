using ARPSynchronos.API.Data;
using ARPSynchronos.API.Data.Enum;
using MessagePack;

namespace ARPSynchronos.API.Dto.Group;

[MessagePackObject(keyAsPropertyName: true)]
public record GroupPairUserPermissionDto(GroupData Group, UserData User, GroupUserPreferredPermissions GroupPairPermissions) : GroupPairDto(Group, User);