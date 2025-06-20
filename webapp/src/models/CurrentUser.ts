import { CurrentUserLoginResponse } from '@models/data/CurrentUserTypes.ts';
import { Role } from '@/hooks/usePermission.ts';
import Thumbnail from '@models/utility/Thumbnail.ts';
import userImageNotFound from '@/assets/media/user-image-not-found.webp'

export default class CurrentUser {
  id: string;
  userName: string;
  email: string;
  token: string;
  profilePic: Thumbnail;
  role: Role;

  constructor(id: string, userName: string, token: string, email: string, role: Role, profilePic?: Thumbnail) {
    this.id         = id;
    this.userName   = userName;
    this.token      = token;
    this.email      = email;
    this.role       = role;
    this.profilePic = profilePic || new Thumbnail({ url: userImageNotFound });
  }

  static fromLoginResponseDTO(dto: CurrentUserLoginResponse): CurrentUser {
    return new CurrentUser(
      dto.id,
      dto.name,
      dto.userTokens.accessToken,
      dto.email,
      dto.role == "Admin" ? Role.ADMIN : Role.USER,
      new Thumbnail({ base64: dto.profileImageBase64, fallbackUrl: userImageNotFound }),
    )
  }
}