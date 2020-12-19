import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BoardItemContainerComponent } from './board-item-container.component';

describe('BoardItemContainerComponent', () => {
  let component: BoardItemContainerComponent;
  let fixture: ComponentFixture<BoardItemContainerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BoardItemContainerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BoardItemContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
