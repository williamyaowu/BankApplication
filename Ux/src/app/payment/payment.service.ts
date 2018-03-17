import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {PaymentModel} from './PaymentModel';
import { Observable } from 'rxjs/Observable';
import { environment } from '../../environments/environment';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*' })
};

@Injectable()
export class PaymentService {
  private apiBaseUrl: string;
  private resourceUrl = 'payment';

  constructor(private http: HttpClient) {
    this.apiBaseUrl = environment.apiHost;
   }


  SavePayment(payment: PaymentModel): Observable<any> {
    const url = `${this.apiBaseUrl}/${this.resourceUrl}`;
    return this.http.post(url, payment, httpOptions);
 }
}
