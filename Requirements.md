# Warlock

- Team Americano: Bade Habib, Peyton Cysewski, Trevor Stubbs

## User Stories
### User Story 1
- Title: Lobby
- User Story sentence: As a user, I want to connect to a lobby before I start a game so that I can be matched with other players. 
- Feature Tasks: 
    - When enough users connect to a new game the server will start up a new instance of the game.
    -The Users will be told that they are waiting for enough players to play.
- Acceptance Tests: 
    - Client's visuals will show a waiting screen
    - When 2 players are connected to the server then the game will automatically start.

### User Story 2
- Title: Card Handling
- User Story sentence: As a server, I want to have a system for handling unique card abilities so that I can process how different abilities work properly.
- Feature Tasks: 
    - Provide methods for the server to be able to give unique abilities to the cards/monsters 
- Acceptance Tests: 
    - A monster's ability will be applied only to that monster.

### User Story 3
- Title: Card Database
- User Story sentence: As a server, I want to maintain a database of cards so that I can know what information belongs to which card and new cards can be added or modified quickly.
- Feature Tasks: 
    - Have a database with a table that holds the monsters cards
    - The server will be able to access this information anytime a monster card is in play.
    - Give an admin/developer the ability to Add/Remove/Update any monster card.
- Acceptance Tests: 
    - Have a database of monster objects.
    - Provide CRUD operations for a game dev to update the monsters' stats so we can balance the game.

### User Story 4
- Title: Server Game State
- User Story sentence: As a server, I want a game state to be maintained based on client input so that I can process what is happening before sending updates.
- Feature Tasks: 
    - The server compute and update the game state and send that new state to the clients
        - During the reset phase the client will update the players' hands and mana number
        - The server will take input from the players of what monsters they play and the location of each monster in their line-up
        - During the fight phase the client will calculate each attack following a set of game rules and then send the clients the results of all the attacks.
- Acceptance Tests: 
    - The server will follow each phase correctly
    - The server will compute the fight phase correctly.
    - The server will be able to update the clients with the game state without any loss of data.

### User Story 5
- Title: Commands and UI
- User Story sentence: As a user, I want to have a clear and understandable UI so that I can make inputs in the game so that I can interact with another player.
- Feature Tasks: 
    - A clear UI that:
        - Display the user's mana
        - Display the user's hand of cards
        - Display the game board
        - Display the user's opponent's monsters
    - A UI that allows the user:
        - to play monsters.
        - move monsters in their line-up
        - press a "Next Turn" button
    - Acceptance Tests: 
        - All UI display elements are functional and are easy to understand
        - All UI input elements are functional and are easy to understand.

### User Story 6
- Title: Client Side Animations
- User Story sentence: As a user, I want to see my actions in the game to be rendered so that I can see what I'm doing and what is going on.
- Feature Tasks: 
    - All the key actions of the server is displayed to the user as animations.
    - When monsters are played into the game an animation will be played
    - When monsters move positions in the line-up an animation will play
    - During the attack phase all attacks are displayed as animations
    - All counters (mana or win/loss counters) will have an animation play when their values are changed.
    - The client will take commands from the server and the appropriate animation will be played. 
- Acceptance Tests: 
    - All animations will be played at the appropriate time. 
    - Enough time will be given between each animation to allow them to finish and to have a clear indication of what is happening in the game. 

## Software Requirements
- Vision:
> The vision of this project is to create both a game and a game server that will allow two people to play against one another, regardless of their location, over the internet. Game servers are fundamentally what allow two or more people to engage with each other in a game environment. There has been no greater need for people to interface at a distance and over the internet than the current year, so we wanted to expand our knowledge of sending and receiving data over the internet. The protocol we are using is TCP/IP which is relevant in many current-day online systems.

### Scope:
#### IN
1. Our product will connect clients to a server via TCP/IP.
2. Our product will render game states to the client views.
3. Our product will receive and handle input from clients.
4. Our product will maintain a synchronized game state on a server.
5. Our product will perform calculations on the server using cards in a database.

#### OUT
1. Our product will not be a fully real-time game.
2. Our product will not compute any game logic on the client-side.

### Minimum Viable Product:
What will your minimum viable product functionality be?
Two clients will connect to the same game server, play through a game together, then disconnect. Our server will do all logic computing, receive input from the client, and send commands to render the game state on clients. Clients and servers will communicate over TCP. Our server will be hosted on Playfab using a Docker image. Our clients will be created in Unity.

#### What are your stretch goals?
1. Add ability/spell system
2. Add a waiting lobby
3. Add a chat client between players
4. Add cheat detection on server end (bad packet detection)
5. Add traits and trait combos mechanic
6. Add monster rarities
7. Add monster upgrading mechanic
8. Add items that can be equipped to monsters

#### Functional Requirements
1. A user can download and run the game client on their local system.
2. A user can choose to join a game and play against another player in real-time (permitting other users are also online).
3. After a game has been completed, the user is returned to the menu and has the choice to play again or quit the application.

#### Data Flow
1. The server will be listening for any incoming client connections (players starting up their game and searching for a game to join).
2. Incoming connections will be added into a "game" cycle that allows them to play through a game.
Note: Each game has a multitude of data transactions between the server and client, but that will be self-contained within each "game".
3. Once a game ends, the client connections that are registered on the server will be moved out of the "game" cycle and back into a "waiting room" state.
4. If a user quits the client application, then they will signal to the server to disconnect them, and they will be disconnected, ending the data flow between server and client.
Visual: here

#### Non-Functional Requirements
1. Usability: We will implement strong UI/UX design to make the game as simple and understandable as possible. Visual queues using both color and language will ensure that the user is aware of the current state of the game at all times.
2. Reliability: We will make sure that what the client sends in will be processed correctly and return an expected outcome every time. We will be testing the outcomes of all the functions so that when many are used in conjunction, then they will be reliable as a whole when processing any number of commands in any given order.

## Domain Modeling

- [Server UML](https://drive.google.com/file/d/1AVUHRoDJWiBx5ARuW1Mlz0JQHUgKJCYg/view?usp=sharing)

- [Client UML](https://drive.google.com/file/d/1z3WW_wIZ7HgBdLVTVeygnFmYZxYzauQQ/view?usp=sharing)

- [Game Cycle](https://drive.google.com/file/d/1mlvmJFeoh_oU5DEuLuC8i7ePkWEBN8hc/view?usp=sharing)

- [Object and Method List](https://docs.google.com/document/d/1naycr5DdYP_TxichYkIHmgr1S97uLP27F4MrzNpYTto/edit?usp=sharing)


