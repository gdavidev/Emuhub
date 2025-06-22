import * as DTO from "@models/data/EmulatorTypes.ts";
import Emulator from "@models/Emulator";
import ApiService from "./ApiService";
import { AxiosResponse } from 'axios'

export default class EmulatorApiService {
  private static endpoints = {
    get: 'api/Emulators/Get',
    list: 'api/Emulators/List',
  };

  static async getAll(): Promise<Emulator[]> {
    const res: AxiosResponse<DTO.EmulatorGetResponse[]> =
        await ApiService.get(EmulatorApiService.endpoints.list);
    return res.data.map(dto => Emulator.fromGetResponse(dto));
  }

  static async get(id: number): Promise<Emulator> {
    const res: AxiosResponse<DTO.EmulatorGetResponse> =
        await ApiService.get(EmulatorApiService.endpoints.get, { data: { id: id } });
    return Emulator.fromGetResponse(res.data);
  }
}