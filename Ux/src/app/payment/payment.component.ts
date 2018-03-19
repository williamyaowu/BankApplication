import { Component, OnInit, Input } from '@angular/core';
import { PaymentService } from './payment.service';
import { PaymentModel } from './PaymentModel';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css'],
  providers: []
})
export class PaymentComponent implements OnInit {
  public paymentModel: PaymentModel;
  public errors: string[];
  constructor(private paymentService: PaymentService) {
    this.paymentModel = new PaymentModel();
    this.errors = [];
  }

  ngOnInit() {}

  save(): void {
    this.errors = [];
    if (!this.paymentValidation()) {
      return;
    }
    this.paymentService.SavePayment(this.paymentModel).subscribe(result => {
      this.paymentModel = new PaymentModel();
    });
  }

  isWithError(): boolean {
    return this.errors.length > 0;
  }

  private paymentValidation(): boolean {
    let check = true;
    if (this.paymentModel.BSB.length !== 6) {
      this.errors.splice(0, 0, 'wrong bsb number');
      check = false;
    }

    if (
      this.paymentModel.AccountName === undefined ||
      this.paymentModel.AccountName === ''
    ) {
      this.errors.splice(0, 0, 'wrong account name');
      check = false;
    }

    if (
      this.paymentModel.AccountNumber === undefined ||
      this.paymentModel.AccountNumber === ''
    ) {
      this.errors.splice(0, 0, 'wrong account number');
      check = false;
    }

    if (
      this.paymentModel.Reference === undefined ||
      this.paymentModel.Reference === ''
    ) {
      this.errors.splice(0, 0, 'reference could not be null');
      check = false;
    }

    if (this.paymentModel.PaymentAmount <= 0) {
      this.errors.splice(0, 0, 'wrong payment amount');
      check = false;
    }

    return check;
  }
}
