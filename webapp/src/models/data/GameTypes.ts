import { EmulatorGetResponse } from '@models/data/EmulatorTypes.ts';
import { CategoryGetResponse } from '@models/data/CategoryTypes.ts';

/* CREATE */
export type GameCreateRequest = {
  title: string,
  description: string,
  emulador: number,
  categoria: number,
  image?: File,
  file?: File,
}
export type GameCreateResponse ={
  rom_id: number,
  title: string,
  description: string,
  emulador: string,
  image_name: string,
  file_name: string,
}

/* UPDATE */
export type GameUpdateRequest = {
  rom_id: number,
  title: string,
  description: string,
  emulador: number,
  categoria: number,
  image?: File,
  file?: File,
}
export type GameUpdateResponse = {}

/* DELETE */
export type GameDeleteRequest = {
  rom_id: number
}
export type GameDeleteResponse = {}

/* GET */
export type GameGetRequest = {
  id: number,
}
export type GameGetResponse = {
  description: string,
  id: number,
  image_base64: string,
  file: string,
  title: string,
  emulador: EmulatorGetResponse,
  categoria: CategoryGetResponse,
}





