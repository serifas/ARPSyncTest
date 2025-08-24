using ARPSynchronos.API.Data;
using MessagePack;

namespace ARPSynchronos.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record UserDto(UserData User);