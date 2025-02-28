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
      nome: this.abbreviation,
      console: this.console,
      empresa: this.companyName,
    }
  }

  toUpdateDTO(): Requests.EmulatorUpdateRequest {
    return {
      id: this.id,
      nome: this.abbreviation,
      console: this.console,
      empresa: this.companyName,
    }
  }

  toDeleteDTO(): Requests.EmulatorDeleteRequest {
    return { id: this.id }
  }

  static fromGetDTO(dto: Requests.EmulatorGetResponse): Emulator {
    return new Emulator(
      dto.nome,
      dto.console,
      dto.empresa,
      dto.id,
    )
  }
}
