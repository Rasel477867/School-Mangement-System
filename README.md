Project Name: School Mangement System 

Strcutaral Pattern: Onion Architecture, SOLID  principle maintance

SchoolMS.Core layerd: this layer Used for design  Entity Relationship build up. Entity Desing upload here 

SchoolMS.Repository: This layer used for Repository pattern work. This layer  Core file contains Generic Repository and Generic Interface Repository.  
The contacts file contains all interface of each entity model. then all interface inherit base interface that have in generic repository interface of core folder. 
all Repository inherit base repository that have core folder. Base repository abstarct class declear . all function used await and async feature used. all base function used virtual keyword 
becouse that this function  implement in child class using override keyword for needed purpose. 

SchoolMs.Service: This layer used for bussiness logic . This layer  Core file contains Generic Service and Generic Interface Service.  
The contacts file contains all interface .  then all interface inherit base interface that have in generic service interface of core folder. 
all Repository inherit base service that have core folder. Base service abstarct class declear . all function used await and async feature used


SchoolMS.Web:  This layerd used for user application for frontend.  View model occures here. Startup file used for all service register here. 
