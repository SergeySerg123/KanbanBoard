import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { MainBoardComponent } from './components/main-board/main-board.component';
import { SubBoardComponent } from './components/sub-board/sub-board.component';
import { CreateButtonComponent } from './components/create-button/create-button.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    MainBoardComponent,
    SubBoardComponent,
    CreateButtonComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
