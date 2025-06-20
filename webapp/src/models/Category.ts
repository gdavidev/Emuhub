import * as Requests from "@models/data/CategoryTypes.ts";

export default class Category {
  id: number;
  name: string;

  constructor(id?: number, name?: string) {
    this.id   = id    || 0;
    this.name = name  || "";
  }

  toCreateDTO(): Requests.CategoryCreateRequest {
    return { name: this.name }
  }

  toUpdateDTO(): Requests.CategoryUpdateRequest {
    return {
      id: this.id,
      name: this.name,
    }
  }

  toDeleteDTO(): Requests.CategoryDeleteRequest {
    return { id: this.id }
  }

  static fromGetResponse(dto: Requests.CategoryGetResponse): Category {
    return new Category(
      dto.id,
      dto.name,
    )
  }
}