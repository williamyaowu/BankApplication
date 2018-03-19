import { TestBed, inject } from '@angular/core/testing';

import { PaymentService } from './payment.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { PaymentModel } from './PaymentModel';
import {FormsModule} from '@angular/forms';
describe('PaymentService', () => {

  let httpClientSpy: { post: jasmine.Spy };


  beforeEach(() => {
     httpClientSpy = jasmine.createSpyObj('HttpClient', ['post']);

    TestBed.configureTestingModule({
      providers: [PaymentService, {provide: HttpClient, useValue: httpClientSpy}],
    });
  });

  it('should be created', inject([PaymentService], (service: PaymentService) => {
    expect(service).toBeTruthy();
  }));

  it('api should be called to create payment', inject([PaymentService], (service: PaymentService) => {
    const paymentModel: PaymentModel = { BSB: '123456', AccountNumber: '123', AccountName: 'test', Reference: 'hello', PaymentAmount: 100};

     service.SavePayment(new PaymentModel());
     expect(httpClientSpy.post.calls.count()).toBe(1, 'one call');
  }));
});
