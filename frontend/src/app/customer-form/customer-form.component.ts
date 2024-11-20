import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerService } from '../services/customer.service'; 
import { Customer } from '../models/customer.model';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {
  customerForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private customerService: CustomerService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.customerForm = this.fb.group({
      id: [''],
      companyName: ['', Validators.required],
      companySize: ['small', Validators.required]
    });
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.customerService.getCustomers().subscribe(customers => {
        const customer = customers.find(c => c.id === id);
        if (customer) {
          this.customerForm.patchValue(customer);
        }
      });
    }
  }

  saveCustomer(): void {
    if (this.customerForm.valid) {
      const customer: Customer = this.customerForm.value;
      if (!customer.id) {
        this.customerService.addCustomer(customer).subscribe(() => {
          this.router.navigate(['/']);
        });
      } else {
        this.customerService.updateCustomer(customer).subscribe(() => {
          this.router.navigate(['/']);
        });
      }
    }
  }
}
