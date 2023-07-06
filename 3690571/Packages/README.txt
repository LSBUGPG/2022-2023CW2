The attribute system is not a main component i just put it there cause i made it already

The other components are the main components can function properly

The state machine needs some set up on your player controller for it to work
A CustomStateMachine component and StateData component need to be on the player controller game object
The StateData needs the different parameters required by the player customstatemachine to decide which state is active, for example if the player is holding their walk buttons, or a trigger for when they jump
Along side this all the different states of the player can be created by extending the "state" script, this is where the state functionality is put
For each of this state they need their own set of states that they can transition to, these also need rules, these are used to determine if a new state should be transitioned to.

The interaction package has a Playerinteract component that is placed on the player camera, select a layer that you want to interact with, set the max distance, and the camera transform, 
E is the button to interact
For the other object it need a script that implement the IInteractable interface and is on the correct layer

The compass component was made with the help of this tutorial - //https://www.youtube.com/watch?v=XcpTC1VYVNE

Objective package, the objectivecontroller Component is the main component in this.
Then a World objective is needed on the game object that represent an actual objective in the world, a custom objective scriptable object can be created using the asset creation menu, this can be used to set the objective title and what the task is about
In the world objective component, add the custom objective into the available slot
To interact with a objective, you can create a script and extend the IInteractable interface.

My Game shows the implementaton of a compass system, state machine, objective system, and an interaction system