/* CREATE */
export type EmulatorCreateRequest = {
  name: string,
  console: string,
  companyName: string,
}
export type EmulatorCreateResponse ={
  id: number,
  name: string,
  console: string,
  companyName: string,
}

/* UPDATE */
export type EmulatorUpdateRequest = {
  id: number,
  name: string,
  console: string,
  companyName: string,
}

/* DELETE */
export type EmulatorDeleteRequest = {
  id: number
}

/* GET */
export type EmulatorGetResponse = {
  id: number,
  name: string,
  console: string,
  companyName: string,
}