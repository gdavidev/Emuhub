import { UserGetResponse } from '@models/data/UserTypes.ts';

/* CREATE */
export type CommentCreateRequest = {
	id_topico: number,
	descricao: string,
	is_helpful: boolean,
	id_parent?: number
}

/* UPDATE */
export type CommentUpdateRequest = {
	id_topico: number,
	descricao: string,
	comentario_delete: boolean
}

/* DELETE */
export type CommentDeleteRequest = {
	id: number
}

/* GET */
export type CommentGetRequest = {
	id: number,
}
export type CommentGetResponse = {
	id: number;
	id_topico: number;
	descricao: string;
	type_content: string;
	user: UserGetResponse;
	is_helpful: boolean;
	id_parent: number | 'None';
	created_at: Date;
	updated_at: Date;
	has_liked: boolean;
	children: CommentGetResponse[]
}