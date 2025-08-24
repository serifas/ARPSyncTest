using ARPSynchronos.API.Data;
using MessagePack;

namespace ARPSynchronos.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserIdentDto(UserData User, string Ident) : UserDto(User);