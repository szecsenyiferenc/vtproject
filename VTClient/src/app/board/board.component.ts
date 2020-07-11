import { RestBackendService } from './../shared/services/rest-backend.service';
import { Board } from './../shared/models/board.model';
import { Component, OnInit } from '@angular/core';
import { Column } from '../shared/models/column.model';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.scss']
})
export class BoardComponent implements OnInit {
  board: Board;

  constructor(private rest: RestBackendService) { }

  ngOnInit(): void {
    this.board = new Board('test board', [
      new Column('Ideas', [

      ]),
      new Column('Research', [

      ]),
      new Column('Todo', [

      ]),
      new Column('Done', [

      ]),
    ]);

    this.rest.getTickets().subscribe(a => this.board.columns[0].tickets = a);
  }




  // todo = [
  //   'Get to work',
  //   'Pick up groceries',
  //   'Go home',
  //   'Fall asleep'
  // ];

  // done = [
  //   'Get up',
  //   'Brush teeth',
  //   'Take a shower',
  //   'Check e-mail',
  //   'Walk dog'
  // ];

  drop(event: CdkDragDrop<string[]>): void {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(event.previousContainer.data,
                        event.container.data,
                        event.previousIndex,
                        event.currentIndex);
    }
  }

}
