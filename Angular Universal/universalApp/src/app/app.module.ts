import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {PostComponent} from './post/post.component';


import { AppComponent } from './app.component';


@NgModule({
  declarations: [
    AppComponent,
    PostComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
