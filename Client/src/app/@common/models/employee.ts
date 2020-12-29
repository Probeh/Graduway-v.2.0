import { BaseModel } from '@models/base-model';

export class Employee extends BaseModel {
  // ======================================= //
  public firstName: string;
  public lastName : string;
  public gender   : string;
  public picture  : string;
  // ======================================= //
  constructor(id: number, description: string, title: string, created: Date, firstName: string, lastName: string, gender: string, picture: string) {
    super(id, description, title, created);
    this.firstName = firstName;
    this.lastName  = lastName ;
    this.gender    = gender   ;
    this.picture   = picture  ;
  }
  // ======================================= //
}