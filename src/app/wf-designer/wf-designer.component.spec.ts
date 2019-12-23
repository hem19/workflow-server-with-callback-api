import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WfDesignerComponent } from './wf-designer.component';

describe('WfDesignerComponent', () => {
  let component: WfDesignerComponent;
  let fixture: ComponentFixture<WfDesignerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WfDesignerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WfDesignerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
