import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  schemeCode: string;
  schemeCodes: Array<string> = [];
  users: Array<any> = [];
  selectedUserId: string;

  constructor() { }
}
