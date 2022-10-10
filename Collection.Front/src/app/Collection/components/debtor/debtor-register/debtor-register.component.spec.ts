import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DebtorRegisterComponent } from './debtor-register.component';

describe('DebtorRegisterComponent', () => {
  let component: DebtorRegisterComponent;
  let fixture: ComponentFixture<DebtorRegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DebtorRegisterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DebtorRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
