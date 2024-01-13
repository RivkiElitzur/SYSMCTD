import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerPageComponent } from './customer-page.component';
import { AddressListComponent } from './address-list/address-list.component';
import { ContactListComponent } from './contact-list/contact-list.component';
import { NewContactComponent } from './contact-list/new-contact/new-contact.component';



@NgModule({
  declarations: [
    CustomerPageComponent,
    AddressListComponent,
    ContactListComponent,
    NewContactComponent
  ],
  imports: [
    CommonModule
  ]
})
export class CustomerPageModule { }
