/* CREATE */
export type CategoryCreateRequest = {
  nome: string,
}
export type CategoryCreateResponse ={
  id: number,
  nome: string,
}

/* UPDATE */
export type CategoryUpdateRequest = {
  id: number,
  nome: string,
}
export type CategoryUpdateResponse = {}

/* DELETE */
export type CategoryDeleteRequest = {
  id: number
}
export type CategoryDeleteResponse = {}

/* GET */
export type CategoryGetRequest = {
  id: number,
}
export type CategoryGetResponse = {
  id: number,
  nome: string,
}