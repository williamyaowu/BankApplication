import { Component, OnInit, Input } from '@angular/core';
import {PaymentService} from './payment.service';
import {PaymentModel} from './PaymentModel';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css'],
  providers: [PaymentService]
})
export class PaymentComponent implements OnInit {

public paymentModel: PaymentModel;

  constructor(private paymentService: PaymentService) {
    this.paymentModel = new PaymentModel();
  }

  ngOnInit() {
  }

  save(): void {
     this.paymentService.SavePayment(this.paymentModel).subscribe(
       result => {
         this.paymentModel = new PaymentModel();
       }
     );
  }

}
