import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentComponent } from './payment.component';
import { PaymentService } from './payment.service';
import { PaymentModel } from './PaymentModel';

import { FormsModule } from '@angular/forms';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';

describe('PaymentComponent', () => {
  let component: PaymentComponent;
  let fixture: ComponentFixture<PaymentComponent>;


  let paymentServiceSpy: jasmine.SpyObj<PaymentService>;

  beforeEach(async(() => {
    paymentServiceSpy = jasmine.createSpyObj('PaymentService', ['SavePayment']);

    TestBed.configureTestingModule({
      declarations: [PaymentComponent],
      providers: [{provide: PaymentService, useValue: paymentServiceSpy}],
      imports: [ FormsModule ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PaymentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should payment be saved', () => {
    paymentServiceSpy.SavePayment.and.returnValue(Observable.of(null));

    component.paymentModel.BSB = '123456';
    component.paymentModel.AccountName = 'testUser';
    component.paymentModel.AccountNumber = '123';
    component.paymentModel.Reference = 'dfdfd';
    component.paymentModel.PaymentAmount = 100;
    component.save();

    expect(paymentServiceSpy.SavePayment.calls.count()).toBe(1, 'one call');

  });

  it('should validation work', () => {
    paymentServiceSpy.SavePayment.and.returnValue(Observable.of(null));

    component.paymentModel.BSB = '';
    component.paymentModel.AccountName = 'testUser';
    component.paymentModel.AccountNumber = '123';
    component.paymentModel.Reference = 'dfdfd';
    component.paymentModel.PaymentAmount = 100;
    component.save();
    expect(component.isWithError()).toBe(true, 'has error');
    expect(paymentServiceSpy.SavePayment.calls.count()).toBe(0, 'no call');
  });
});
