import { Component, OnInit } from '@angular/core';
import { CustomerModel } from '../models/customer.model';
import { CustomerTypeService } from '../services/customer-type.service';
import { CustomerService } from '../services/customer.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  public customers: CustomerModel[] = [];
  public types: string[] = [];

  public newCustomer: CustomerModel = {
    customerId:null,
    name: null,
    type: null
  };

  constructor(
    private customerTypeService: CustomerTypeService,
    private customerService: CustomerService) { }

  ngOnInit() {
    this.customerTypeService.GetCustomerTypes().subscribe(types => this.types = types);
    this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
  }

  public createCustomer(form: NgForm): void {
    var cust = this.newCustomer;
    if (!cust.name || cust.name.trim().length===0) {
      alert('form is not valid');
  }
  else
  {
    if (form.invalid) {
      alert('form is not valid');
    } else {
      this.customerService.CreateCustomer(this.newCustomer).then(() => {
        this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
      });
    }
  }
  }

}
