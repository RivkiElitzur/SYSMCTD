import { Component, OnInit } from '@angular/core';
import { CustomerModel } from 'src/app/models/customer.model';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.scss'],
})
export class CustomerListComponent implements OnInit {
  dataSource: CustomerModel[] = [];

  displayedColumns = ['Name', 'CustomerNumber'];
  constructor(private customerService: CustomerService) {}

  ngOnInit(): void {
    this.getData();
  }

  getData() {
    this.customerService
      .getCustomers()
      .subscribe((res) => (this.dataSource = res));
  }

  openCustomer(id : number){

  }
}
