import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerTypeService {

  constructor(private httpClient: HttpClient) { }

  public GetCustomerTypes(): Observable<string[]> {
    return this.httpClient.get<string[]>('http://localhost:63235/customertype');
  }
}
