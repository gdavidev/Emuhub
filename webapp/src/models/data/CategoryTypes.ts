/* CREATE */
export type CategoryCreateRequest = {
  name: string,
}

/* UPDATE */
export type CategoryUpdateRequest = {
  id: number,
  name: string,
}

/* DELETE */
export type CategoryDeleteRequest = {
  id: number
}

/* GET */
export type CategoryGetRequest = {
  id: number,
}
export type CategoryGetResponse = {
  id: number,
  name: string,
}