export abstract class BaseModel {
  // ======================================= //
  public id         : number;
  public description: string;
  public title      : string;
  public created    : Date  ;
  // ======================================= //
  constructor(id: number, description: string, title: string, created: Date) {
    this.id          = id         ;
    this.description = description;
    this.title       = title      ;
    this.created     = created    ;
  }
  // ======================================= //
}
