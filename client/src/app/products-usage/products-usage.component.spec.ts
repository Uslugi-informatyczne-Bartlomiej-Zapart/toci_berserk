import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductsUsageComponent } from './products-usage.component';

describe('ProductsUsageComponent', () => {
  let component: ProductsUsageComponent;
  let fixture: ComponentFixture<ProductsUsageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductsUsageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductsUsageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
