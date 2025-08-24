using ARPSynchronos.API.Data;
using ARPSynchronos.API.Data.Enum;
using MessagePack;

namespace ARPSynchronos.API.Dto.Group;

[MessagePackObject(keyAsPropertyName: true)]
public record GroupPairUserInfoDto(GroupData Group, UserData User, GroupPairUserInfo GroupUserInfo) : GroupPairDto(Group, User);