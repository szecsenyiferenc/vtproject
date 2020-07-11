import { RestBackendService } from './shared/services/rest-backend.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BoardComponent } from './board/board.component';
import { TicketComponent } from './shared/components/ticket/ticket.component';
import { HttpClientModule } from '@angular/common/http';

import { DragDropModule } from '@angular/cdk/drag-drop';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
   declarations: [
      AppComponent,
      BoardComponent,
      TicketComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      DragDropModule,
      NoopAnimationsModule,
      HttpClientModule
   ],
   providers: [
     RestBackendService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
