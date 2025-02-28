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
      title: this.name,
      description: this.desc,
      emulador: this.emulator?.id  || 0,
      categoria: this.category?.id || 0,
      image: this.thumbnail?.file  || undefined,
      file: this.rom.file          || undefined,
    }
  }

  toUpdateDTO(): Requests.GameUpdateRequest {
    return {
      rom_id: this.id,
      title: this.name,
      description: this.desc,
      emulador: this.emulator?.id  || 0,
      categoria: this.category?.id || 0,
      image: this.thumbnail?.file  || undefined,
      file: this.rom.file          || undefined,
    }
  }

  toDeleteDTO(): Requests.GameDeleteRequest {
    return { rom_id: this.id };
  }

  static fromGetDTO(dto: Requests.GameGetResponse): Game {
    return new Game(
      dto.title,
      dto.description,
      Emulator.fromGetDTO(dto.emulador),
      new Thumbnail({ base64: dto.image_base64 }),
      new FileHolder({ name: dto.file }),
      new Category(dto.categoria.id, dto.categoria.nome),
      dto.id,
    )
  }
}