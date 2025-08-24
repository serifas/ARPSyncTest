﻿using ARPSynchronos.API.Data;
using MessagePack;

namespace ARPSynchronos.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileDto(UserData User, bool Disabled, bool? IsNSFW, string? ProfilePictureBase64, string? Description) : UserDto(User);