using ARPSynchronos.API.Data;
using ARPSynchronos.API.Data.Enum;
using MessagePack;

namespace ARPSynchronos.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record UserPermissionsDto(UserData User, UserPermissions Permissions) : UserDto(User);
