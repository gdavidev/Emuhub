import * as Requests from "@models/data/PostTypes.ts";
import User from "./User";
import Category from '@models/Category.ts';
import Thumbnail from '@models/utility/Thumbnail.ts';
import Comment from '@models/Comment.ts';
import { CommentGetResponse } from '@models/data/CommentTypes.ts';

export default class Post {
  id: number;
  owner: User;
  title: string;
  content: string;
  category: Category;
  tags: string[];
  createdDate: Date;
  updatedDate: Date;
  image: Thumbnail | null;
  hasLiked: boolean;
  likeCount: number;
  commentCount: number;
  comments: Comment[];

  constructor(
      title: string,
      owner: User,
      category: Category,
      content: string,
      tags: string[],
      image?: Thumbnail)
  constructor(
      title: string,
      owner: User,
      category: Category,
      content: string,
      tags: string[],
      image: Thumbnail | null,
      id: number,
      hasLiked: boolean,
      likeCount: number,
      commentCount: number,
      createdDate: Date,
      updatedDate: Date,
      comments: Comment[])
  constructor(
      title: string,
      owner: User,
      category: Category,
      content: string,
      tags: string[],
      image: Thumbnail | null = null,
      id: number = 0,
      hasLiked: boolean = false,
      likeCount: number = 0,
      commentCount: number = 0,
      createdDate: Date = new Date(0),
      updatedDate: Date = new Date(0),
      comments: Comment[] = [])
  {
    this.title        = title;
    this.owner        = owner;
    this.category     = category;
    this.content      = content;
    this.tags         = tags;
    this.image        = image;
    this.id           = id;
    this.hasLiked     = hasLiked;
    this.likeCount    = likeCount;
    this.commentCount = commentCount;
    this.createdDate  = createdDate;
    this.updatedDate  = updatedDate;
    this.comments     = comments;
  }

  static fromGetResponse(res: Requests.PostGetResponse): Post {
    return new Post(
      res.titulo,
      new User(res.user.id, res.user.username, new Thumbnail({ base64: res.user.img_perfil })),
      new Category(res.categoria.id, res.categoria.nome),
      res.descricao,
      res.tags !== 'None' ? res.tags : [],
      res.img_topico64 ? new Thumbnail({ base64: res.img_topico64 }) : null,
      res.id,
      res.has_liked,
      res.likes,
      res.comentarios,
      new Date(res.created_at),
      new Date(res.updated_at),
      res.obj_comentarios ?
          res.obj_comentarios.map((comm: CommentGetResponse) => Comment.fromGetDTO(comm)) :
          []
    )
  }

  public toCreateRequest(): Requests.PostCreateRequest {
    return {
      titulo: this.title,
      descricao: this.content,
      id_categoria: this.category.id,
      id_user: this.owner.id,
      tags: this.tags,
      img_topico: this.image?.file ?? undefined,
    }
  }

  public toUpdateRequest(): Requests.PostUpdateRequest {
    return {
      titulo: this.title,
      descricao: this.content,
      id_categoria: this.category.id,
      id_user: this.owner.id,
      tags: this.tags,
      img_topico: this.image?.file ?? undefined,
    }
  }
}