import { Ticket } from './../../models/ticket.model';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.scss']
})
export class TicketComponent implements OnInit {
  @Input() ticket: Ticket;

  constructor() { }

  ngOnInit() {
  }

}
