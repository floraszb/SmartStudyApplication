export type Role = "Admin" | "Teacher" | "Student" | "Mentor";

export interface User {
  id: string;
  email: string;
  role: Role;
}