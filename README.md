# Multiplayer generator

## Info
A simple TCP Client-Server program that uses a config that controls
memory read/write commands for a game.

## Projects

### mp_gen
Client program
Needs config file

### mp_gen_srv
Server program
Needs config file

### mp_gen_cfg
Config generator program

## Usage
1. Get memory addresses to sync from a game
2. Input the necessary data into mp_gen_cfg
3. Copy the generated config to the Client and Server program
4. Run the server
5. Connect the clients to the server
6. Play
