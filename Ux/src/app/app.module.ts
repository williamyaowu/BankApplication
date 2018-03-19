import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { PaymentComponent } from './payment/payment.component';

import {FormsModule} from '@angular/forms';

import {HttpClientModule} from '@angular/common/http';
import { PaymentService } from './payment/payment.service';


@NgModule({
  declarations: [
    AppComponent,
    PaymentComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [PaymentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
