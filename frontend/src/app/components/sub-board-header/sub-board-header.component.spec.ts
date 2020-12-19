import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SubBoardHeaderComponent } from './sub-board-header.component';

describe('SubBoardHeaderComponent', () => {
  let component: SubBoardHeaderComponent;
  let fixture: ComponentFixture<SubBoardHeaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SubBoardHeaderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SubBoardHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
