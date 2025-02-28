/* CREATE */
export type EmulatorCreateRequest = {
  nome: string,
  console: string,
  empresa: string,
}
export type EmulatorCreateResponse ={
  id: number,
  nome: string,
  console: string,
  empresa: string,
}

/* UPDATE */
export type EmulatorUpdateRequest = {
  id: number,
  nome: string,
  console: string,
  empresa: string,
}
export type EmulatorUpdateResponse = {}

/* DELETE */
export type EmulatorDeleteRequest = {
  id: number
}
export type EmulatorDeleteResponse = {}

/* GET */
export type EmulatorGetRequest = {
  emulador_id: number,
}
export type EmulatorGetResponse = {
  id: number,
  nome: string,
  console: string,
  empresa: string,
}