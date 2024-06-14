Project Name: School Management System

Strcutaral Pattern: Onion Architecture, SOLID Principle Maintenance

SchoolMS.Core layer: this layer is used for design entity relationship buildup. Entity Desing uploads here.

SchoolMS.Repository: This layer is used for repository pattern work. This layer core file contains a generic repository and a generic interface repository. 
The contacts file contains all the interfaces for each entity model. then all interfaces inherit the base interface that has the generic repository interface of the core folder. 
All repositories inherit a base repository that has a core folder. Base repository abstarct class declear. All functions used are await and async features. All base functions use virtual keywords. 
because this function is implemented in the child class using an override keyword for the needed purpose. 

SchoolMs.Service: This layer is used for business logic. This layer core file contains generic service and generic interface service. 
The contacts file contains all interfaces.  then all interfaces inherit the base interface that is in the generic service interface of the core folder. 
All repositories inherit base services that have core folders. Base service abstarct class declear. All functions used are await and async features.


SchoolMS.Web: This layer is used for user applications on the frontend. The view model occurs here. The startup file is used for all services registered here. 
