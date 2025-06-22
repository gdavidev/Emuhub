import * as Requests from '@models/data/EmulatorTypes.ts';

export default class Emulator {
  id: number;
  name: string;
  abbreviation: string;

  constructor(
      abbreviation: string,
      name: string,
      id?: number)
  constructor(
      abbreviation: string,
      name: string,
      id: number = 0)
  {
    this.id           = id;
    this.abbreviation = abbreviation;
    this.name         = name;
  }

  static fromGetResponse(dto: Requests.EmulatorGetResponse): Emulator {
    return new Emulator(
      dto.abbreviation,
      dto.name,
      dto.id,
    )
  }
}
