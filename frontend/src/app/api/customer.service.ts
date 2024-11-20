import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Customer, PaginatedResponse } from "../models/customer";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: "root",
})
export class CustomerService {
  apiUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAll(pageNumber: number = 1, pageSize: number = 10): Observable<Customer[]> {
    let params = new HttpParams()
      .set('pageNumber', pageNumber.toString())
      .set('pageSize', pageSize.toString());

    return this.http.get<PaginatedResponse<Customer>>(this.apiUrl, { params })
      .pipe(map(response => response.items));
  }

  insert(customer: Customer) {
    return this.http.post(`${this.apiUrl}/api/customers/`, customer);
  }

  update(customer: Customer) {
    return this.http.put(`${this.apiUrl}/api/customers/${customer.id}`, customer);
  }

  delete(id: string) {
    return this.http.delete(`${this.apiUrl}/api/customers/${id}`);
  }
}