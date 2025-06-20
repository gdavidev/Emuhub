import * as Requests from "@models/data/GameTypes.ts";
import Emulator from "@models/Emulator";
import Category from "@models/Category";
import Thumbnail from "@models/utility/Thumbnail";
import imageNotFound from '@/assets/media/image-not-found.png'
import FileHolder from '@models/utility/FileHolder.ts';

export default class Game {
  id: number;
  name: string;
  desc: string;
  emulator: Emulator;
  category: Category;
  thumbnail: Thumbnail;
  rom: FileHolder;

  constructor(
      name: string,
      desc: string,
      emulator: Emulator,
      thumbnail: Thumbnail | null,
      rom: FileHolder | null,
      category: Category,
      id?: number)
  constructor(
      name: string,
      desc: string,
      emulator: Emulator,
      thumbnail: Thumbnail | null,
      rom: FileHolder | null,
      category: Category,
      id: number = 0)
    {
    this.id           = id;
    this.name         = name;
    this.desc         = desc;
    this.emulator     = emulator;
    this.category     = category;
    this.thumbnail    = thumbnail ?? new Thumbnail({ url: imageNotFound });
    this.rom          = rom ?? new FileHolder();
  }

  getDesktopAppQueryString() {
    return `emuhub:${this.emulator.abbreviation.toUpperCase()}&${this.name}`;
  }

  toCreateDTO(): Requests.GameCreateRequest {
    return {
      name: this.name,
      description: this.desc,
      emulatorId: this.emulator?.id  || 0,
      categoryId: this.category?.id || 0,
      image: this.thumbnail?.file  || undefined,
      file: this.rom.file          || undefined,
    }
  }

  toUpdateDTO(): Requests.GameUpdateRequest {
    return {
      id: this.id,
      name: this.name,
      description: this.desc,
      emulatorId: this.emulator?.id  || 0,
      categoryId: this.category?.id || 0,
      image: this.thumbnail?.file  || undefined,
      file: this.rom.file          || undefined,
    }
  }

  toDeleteDTO(): Requests.GameDeleteRequest {
    return { id: this.id };
  }

  static fromGetResponse(dto: Requests.GameGetResponse): Game {
    return new Game(
      dto.name,
      dto.description,
      Emulator.fromGetResponse(dto.emulator),
      new Thumbnail({ base64: dto.imageBase64 }),
      new FileHolder({ name: dto.fileName }),
      Category.fromGetResponse(dto.category),
      dto.id,
    )
  }
}