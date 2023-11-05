# Backend

## Structure

Currently abtracted with 3 Projects
- Application  (API, Controller Stuff, DI, DTO)
- Domain (Entites, Contracts)
- Infrastructure (DatabaseContext, EF-Core)


### Application

- Validation created by Fluent Validation and Data Annotation 
- DTOS 
- Automapper (Mapping DTOs to Entites and vice versa)
- Use Serilog for basic logging
- Create a IBaseResponse Interface that every response MUST have a Message and optional a result of Type T (same implementation in Frontend)
- Has Servcices which has BL
- Use DI (register Repositories,Services, UnitOfwork etc.)


### Domain
- Entities for Domain
- Create contracts (Interfaces)


### Infarstructure 
- Implements Interfaces
- Use Unit of Work Pattern
- Use Repository Pattern
- Use EF-Core for Data access (+ Migrations)


## TestProject

- Using Fixture
- Using Moq
- Test Fluent Validation and Data Annotation 
- Test Controllers