import { Person } from './person.model';

export interface Ticket {
  name: string;
  description: string;
  shortName: string;
  storypoint: number;
  assigned: Person;
}
