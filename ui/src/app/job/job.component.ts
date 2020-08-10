import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EngineerService } from '../services/engineer.service';
import { JobService } from '../services/job.service';
import { CustomerService } from '../services/customer.service';
import { JobModel } from '../models/job.model';
import { CustomerModel } from '../models/customer.model';

@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.scss']
})
export class JobComponent implements OnInit {

  public engineers: string[] = [];

  public jobs: JobModel[] = [];
  selected:any;
 

  public customers: CustomerModel[] = [];

  public newJob: JobModel = {
    jobId: null,
    engineer: null,
    when: null,
    customerId:null,
    customer:null
  };

  constructor(
    private engineerService: EngineerService,
    private jobService: JobService,private customerService: CustomerService) { }

  ngOnInit() {
    this.engineerService.GetEngineers().subscribe(engineers => this.engineers = engineers);
    this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
    this.jobService.GetJobs().subscribe(jobs => this.jobs = jobs);
  }

  setCustomer(id: any): void {
   
    this.newJob.customerId=parseInt(id);
    
}

customerName(id: any): any {
  
 return this.customers.filter(value => value.customerId === parseInt(id));
  
}

  public createJob(form: NgForm): void {
    if (form.invalid) {
      alert('form is not valid');
    } else {
      this.jobService.CreateJob(this.newJob).then(() => {
        this.jobService.GetJobs().subscribe(jobs => this.jobs = jobs);
      });
    }
  }

}
