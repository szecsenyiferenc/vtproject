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

  constructor() { }

  board: Board = new Board('test board', [
    new Column('Ideas', [
      {
        name: '1. name',
        description: '1. desc',
        assigned: '1. assigned',
        image: null
      },
      {
        name: '2. name',
        description: '2. desc',
        assigned: '2. assigned',
        image: null
      }
    ]),
    new Column('Research', [
      {
        name: '1. name',
        description: '1. desc',
        assigned: '1. assigned',
        image: null
      },
      {
        name: '2. name',
        description: '2. desc',
        assigned: '2. assigned',
        image: null
      }
    ]),
    new Column('Todo', [
      {
        name: '1. name',
        description: '1. desc',
        assigned: '1. assigned',
        image: null
      },
      {
        name: '2. name',
        description: '2. desc',
        assigned: '2. assigned',
        image: null
      }
    ]),
    new Column('Done', [

    ]),
  ]);

  ngOnInit() {
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

  drop(event: CdkDragDrop<string[]>) {
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
