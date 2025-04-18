/* CREATE */
import { CategoryGetResponse } from '@models/data/CategoryTypes.ts';
import { UserGetResponse } from '@models/data/UserTypes.ts';
import { CommentGetResponse } from '@models/data/CommentTypes.ts';

export type PostCreateRequest = {
  titulo: string,
  descricao: string,
  id_categoria: number,
  id_user: number,
  tags: string[],
  img_topico?: File
}

/* UPDATE */
export type PostUpdateRequest = {
  titulo?: string,
  descricao?: string,
  id_categoria?: number,
  id_user?: number,
  tags?: string[],
  img_topico?: File
}

/* DELETE */
export type PostDeleteRequest = {
  topico_id: number
}

/* GET */
export type PostGetRequest = {
  topico_id: number,
  id_usuario: string,
}
export type PostGetResponse = {
  id: 1;
  titulo: string;
  img_topico64: string;
  tags: string[] | 'None';
  descricao: string;
  categoria: CategoryGetResponse
  user: UserGetResponse
  comentarios: number;
  obj_comentarios: CommentGetResponse[]
  likes: number;
  created_at: Date;
  updated_at: Date;
  has_liked: boolean;
}