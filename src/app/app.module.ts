import {  HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import {BrowserAnimationsModule} from "@angular/platform-browser/animations"
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MagicTheGatheringDetailsComponent } from './magic-the-gathering-details/magic-the-gathering-details.component';
import { MagicTheGatheringFormComponent } from './magic-the-gathering-details/magic-the-gathering-form/magic-the-gathering-form.component';

@NgModule({
  declarations: [
    AppComponent,
    MagicTheGatheringDetailsComponent,
    MagicTheGatheringFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
