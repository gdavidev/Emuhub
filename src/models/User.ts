import Thumbnail from '@models/utility/Thumbnail.ts';

export default class User {
  id: number
  name: string
  image: Thumbnail;

  constructor(id?: number, name?: string, image?: string) {
    this.id     = id      || 0;
    this.name   = name    || '';
    this.image  = new Thumbnail({ base64: image });
  }
}