import { EmulatorGetResponse } from '@models/data/EmulatorTypes.ts';
import { CategoryGetResponse } from '@models/data/CategoryTypes.ts';

/* CREATE */
export type GameCreateRequest = {
  name: string,
  description: string,
  emulatorId: number,
  categoryId: number,
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
  id: number,
  name: string,
  description: string,
  emulatorId: number,
  categoryId: number,
  image?: File,
  file?: File,
}

/* DELETE */
export type GameDeleteRequest = {
  id: number
}

/* GET */
export type GameGetRequest = {
  id: number,
}
export type GameGetResponse = {
  id: number,
  name: string,
  description: string,
  imageBase64: string,
  fileName: string,
  emulator: EmulatorGetResponse,
  category: CategoryGetResponse,
}





