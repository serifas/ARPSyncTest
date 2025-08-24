using ARPSynchronos.API.Data;
using ARPSynchronos.API.Data.Enum;
using MessagePack;

namespace ARPSynchronos.API.Dto.Group;

[MessagePackObject(keyAsPropertyName: true)]
public record GroupPasswordDto(GroupData Group, string Password) : GroupDto(Group);

[MessagePackObject(keyAsPropertyName: true)]
public record GroupJoinDto(GroupData Group, string Password, GroupUserPreferredPermissions GroupUserPreferredPermissions) : GroupPasswordDto(Group, Password);