import { Component, OnInit } from '@angular/core'; 
import { CustomerService } from '../services/customer.service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Customer } from '../models/customer.model';

@Component({
  selector: 'app-customer-list',  
  templateUrl: './customer-list.component.html',
  styles: ['./customer-list.component.css'],
})
export class CustomerListComponent implements OnInit {
  customers: Customer[] = [];

  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
    this.customerService.getCustomers().subscribe((data) => {
      this.customers = data;
      console.log("this.customers", this.customers);
    });
  }

  deleteCustomer(id: string): void {
    this.customerService.deleteCustomer(id).subscribe(() => {
      this.customers = this.customers.filter((customer) => customer.id !== id);
    });
  }
}