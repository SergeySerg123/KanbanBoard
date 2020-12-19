import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { MainBoardComponent } from './components/main-board/main-board.component';
import { SubBoardComponent } from './components/sub-board/sub-board.component';
import { CreateButtonComponent } from './components/create-button/create-button.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialComponentsModule } from './components/common/material-components/material-components.module';
import { SubBoardHeaderComponent } from './components/sub-board-header/sub-board-header.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    MainBoardComponent,
    SubBoardComponent,
    CreateButtonComponent,
    SubBoardHeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialComponentsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
