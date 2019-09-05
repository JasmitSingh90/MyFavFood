The project weighs more in its architecture compared to the UI/UX.
It uses MVVM with data binding as it's underlying pattern. Also, developing same with Xamarin forms has made its code-sharing capability almost 100 percent across all the three platforms which means only 30 percent of the total manpower is required for its maintenance.

Brief of diff layers:
Views: The views dealing with the UI elements are totally separated using data binding.

Viewmodels: Handles the data binding and is responsible for maintaining the class state and behavior.

Models: Handles the UI data part.

Note: Models here only interact with the visual part of the project.


Also, with the above layers in place below files are added to accomplish design goals of maintaining loose coupling between the layers and making code unit testable.

BaseModel: Its responsible for intimating changes between UI elements and the class attributes.

Interfaces: These are added to remove Xamarin forms specific code from the Viewmodels which ultimately makes the Viewmodels unit testable and adds a capability to extend the project by having loose coupling between layers.

Services: Services implements the interfaces and serves as per the requirement.

The project has two different services:

 - ViewModel specific - Favourite food service
 - Global services  - Page service


Repositories: Responsible for getting data from services. (Hardcoded in our case)

Note: The data from repositories is mapped to the pure data class (Entities).
