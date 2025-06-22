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
  id: string,
}

/* UPDATE */
export type GameUpdateRequest = {
  id: string,
  name: string,
  description: string,
  emulatorId: number,
  categoryId: number,
  image?: File,
  file?: File,
}

/* DELETE */
export type GameDeleteRequest = {
  id: string
}

/* GET */
export type GameGetRequest = {
  id: string,
}
export type GameGetResponse = {
  id: string,
  name: string,
  description: string,
  imageBase64: string,
  fileName: string,
  emulator: EmulatorGetResponse,
  category: CategoryGetResponse,
}





