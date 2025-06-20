import * as Requests from '@models/data/EmulatorTypes.ts';

export default class Emulator {
  id: number;
  abbreviation: string;
  console: string;
  companyName: string;

  constructor(
      abbreviation: string,
      console: string,
      companyName: string,
      id?: number)
  constructor(
      abbreviation: string,
      console: string,
      companyName: string,
      id: number = 0)
  {
    this.id               = id;
    this.abbreviation     = abbreviation;
    this.console          = console;
    this.companyName      = companyName;
  }

  toCreateDTO(): Requests.EmulatorCreateRequest {
    return { 
      name: this.abbreviation,
      console: this.console,
      companyName: this.companyName,
    }
  }

  toUpdateDTO(): Requests.EmulatorUpdateRequest {
    return {
      id: this.id,
      name: this.abbreviation,
      console: this.console,
      companyName: this.companyName,
    }
  }

  toDeleteDTO(): Requests.EmulatorDeleteRequest {
    return { id: this.id }
  }

  static fromGetResponse(dto: Requests.EmulatorGetResponse): Emulator {
    return new Emulator(
      dto.name,
      dto.console,
      dto.companyName,
      dto.id,
    )
  }
}
