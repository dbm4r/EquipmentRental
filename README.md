# Equipment Rental System

## Description
Simple console app for managing equipment rentals in a university.  
It supports adding users and equipment, renting, returning, and calculating late penalties.

---
## Structure
- **Models** → data classes (Equipment, User, Rental)  
- **Services** → main logic (RentalService)  
- **Program.cs** → runs the demo  
---

## Cohesion
Each class has one role.  
Models store data, and RentalService handles all logic.
---

## Coupling
Classes are not tightly connected.  
All operations go through RentalService instead of being spread across classes.
---
## Responsibilities
- Models → data  
- Service → rules (limits, availability, penalties)  
- Program → execution  
---

## Design
I used inheritance for different equipment and user types.  
Keeping logic in one service makes it easier to manage and modify.
