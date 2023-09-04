/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, ObservableInput } from 'rxjs';
import { Couriers } from './Couriers';
import { PriceResult } from './PriceResult';



@Injectable({
  providedIn: 'root'
})
export class CouriersService {

  apiUrl: string = "https://localhost:44340/";
  constructor(private http: HttpClient) { }

  checkPrice(courier: Couriers): Observable<PriceResult> {
    const headers = { 'content-type': 'application/json' }
    const body = JSON.stringify(courier);
    return this.http.post<PriceResult>(this.apiUrl + 'PageUPCouriers', body, { 'headers': headers });

  }

}
