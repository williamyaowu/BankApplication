import { TestBed, async } from '@angular/core/testing';
import { AppComponent } from './app.component';
import {PaymentComponent} from './payment/payment.component';
import { FormsModule } from '@angular/forms';

import { PaymentService } from './payment/payment.service';
describe('AppComponent', () => {
  let paymentServiceSpy: jasmine.SpyObj<PaymentService>;

  beforeEach(async(() => {
    paymentServiceSpy = jasmine.createSpyObj('PaymentService', ['SavePayment']);
    TestBed.configureTestingModule({
      declarations: [
        AppComponent, PaymentComponent
      ],
      providers: [
        {provide: PaymentService, useValue: paymentServiceSpy}
      ],
      imports: [FormsModule]
    }).compileComponents();
  }));
  it('should create the app', async(() => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  }));
});
