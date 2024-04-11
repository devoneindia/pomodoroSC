import { Entry } from "./Entry";

export interface User {
  userId: number;
  userName: string;
  password: string;
  entries: Entry[];
}
