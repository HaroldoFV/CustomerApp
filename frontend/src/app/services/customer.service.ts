import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer.model';
import { map } from 'rxjs/operators';

interface PaginatedResponse<T> {
    items: T[];
    totalItems: number;
    pageNumber: number;
    pageSize: number;
}

@Injectable({
    providedIn: 'root'
})
export class CustomerService {
    private apiUrl = 'http://localhost:8080/api/customers';

    constructor(private http: HttpClient) { }

    getCustomers(pageNumber: number = 1, pageSize: number = 10): Observable<Customer[]> {
        let params = new HttpParams()
            .set('pageNumber', pageNumber.toString())
            .set('pageSize', pageSize.toString());

        return this.http.get<PaginatedResponse<Customer>>(this.apiUrl, { params })
            .pipe(map((response: { items: any; }) => response.items));
    }

    addCustomer(customer: Customer): Observable<Customer> {
        return this.http.post<Customer>(this.apiUrl, customer);
    }

    updateCustomer(customer: Customer): Observable<void> {
        const updateCommand = {
            customerId: customer.id,
            companyName: customer.companyName,
            companySize: customer.companySize
        };
        return this.http.put<void>(`${this.apiUrl}/${customer.id}`, updateCommand);
    }

    deleteCustomer(id: string): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${id}`);
    }
}