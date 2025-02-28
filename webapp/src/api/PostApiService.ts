import * as DTO from "@models/data/PostTypes.ts";
import Post from "@models/Post";
import ApiService from "./ApiService";

export default class PostApiService {
  private static readonly endpoints = {
    get: 'api/topicos/list/',
    detail: 'api/topicos/detail/',
    search: 'api/topicos/search/',
    post: 'api/topicos/create/',
    put: 'api/topicos/update/',
    delete: 'api/topicos/delete/',
  };

  static async getAll(token?: string): Promise<Post[]> {
    const res  =
        await ApiService.get<DTO.PostGetResponse[]>(PostApiService.endpoints.get, {
          headers: token !== undefined ? { 'Authorization': 'Bearer ' + token } : undefined
        });
    return res.data.map(dto => Post.fromGetResponse(dto));
  }

  static async get(id: number, token?: string): Promise<Post> {
    const res =
        await ApiService.get<DTO.PostGetResponse>(PostApiService.endpoints.detail, {
          params: { topico_id: id },
          headers: token !== undefined ? { 'Authorization': 'Bearer ' + token } : undefined
        });
    return Post.fromGetResponse(res.data);
  }

  static async search(search: string, token?: string): Promise<Post[]> {
    const res =
        await ApiService.get<{ topicos: DTO.PostGetResponse[] }>(PostApiService.endpoints.search, {
          params: { search: search },
          headers: token !== undefined ? { 'Authorization': 'Bearer ' + token } : undefined
        });
    return res.data.topicos.map(dto => Post.fromGetResponse(dto));
  }

  public static async delete(post: Post, token: string): Promise<void> {
    await ApiService.delete(
      PostApiService.endpoints.delete,
      {
        data: { topico_id: post.id },
        headers: { 'Authorization': 'Bearer ' + token }
      }
    );
  }

  public static async create(dto: DTO.PostCreateRequest, token: string): Promise<DTO.PostGetResponse> {
    const res = await ApiService.post<DTO.PostGetResponse>(
      PostApiService.endpoints.post,
      dto,
      { headers: {
        'Authorization': 'Bearer ' + token,
        'Content-Type': 'multipart/form-data'
      }}
    );
    return res.data
  }

  public static async update(dto: DTO.PostUpdateRequest, token: string): Promise<DTO.PostGetResponse> {
    const res = await ApiService.put<DTO.PostGetResponse>(
      PostApiService.endpoints.put,
      dto,
      { headers: {
        'Authorization': 'Bearer ' + token,
        'Content-Type': 'multipart/form-data'
      }}
    );
    return res.data
  }
}