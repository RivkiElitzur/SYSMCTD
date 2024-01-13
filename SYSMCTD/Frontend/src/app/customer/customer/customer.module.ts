import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { CustomerPageModule } from './customer-page/customer-page.module';
import { MatTableModule } from '@angular/material/table';

@NgModule({
  declarations: [CustomerListComponent],
  imports: [CustomerPageModule, CommonModule, MatTableModule],
})
export class CustomerModule {}
