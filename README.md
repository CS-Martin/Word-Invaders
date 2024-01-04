# **Word Invaders - Software Engineering** <!-- omit in toc -->
> <sup>Short Description</sup>

- [**Introduction**](#introduction)
    - [**Core Members:**](#core-members)
    - [**Frontend Team:**](#frontend-team)
    - [**Backend Team:**](#backend-team)
- [**Directories**](#directories)
- [**Conventions**](#conventions)
- [**Dependencies**](#dependencies)
- [**Installation**](#installation)
- [**Usage**](#usage)

## **Introduction**
> @Brief: 
> - A fast-paced typing game.
> - Cursed-words will fall on top of the screen and player must type them as quick as possible.
> - Cursed-words are words that are related to real-life social problems in the Philippines.
> - Player shoots down cursed-words by typing them out as fast as possible.
> - Inspired by Monkeytype, Typeracer, and Z-type.

> Goal: To entertain, improve typing skills, and to raise awareness about social issues in the Philippines.

### **Core Members:**
- Martin Edgar Atole
- Ben Jenon Alpuerto
- Noel B. Emaas

### **Frontend Team:**
- [**Martin Edgar Atole**](https://github.com/jobb-rodriguez) *(Lead)*
- [**Ben Jenon Alpuerto**](https://github.com/rtakhr) *(A. Lead)*

### **Backend Team:**
- [**Noel B. Emaas**](https://github.com/Jiostorm) *(Lead)*

---

## **Conventions**
1. **Github**
    - Commits:
        ``` shell
        git commit -m [action]: [description]
        ```
        - Action:
            | Option | Information |
            | :---: | :--- |
            | `feat`        | New feature for the user, not a new feature for build script.         |
            | `fix`         | Bug fix for the user, not a fix to a build script.                    |
            | `docs`        | Changes to the documentation.                                         |
            | `style`       | Formatting, missing semi colons, etc; no production code change       |
            | `refactor`    | Refactoring production code, eg. renaming a variable                  |
            | `test`        | Adding missing tests, refactoring tests; no production code change    |
            | `chore`       | Updating grunt tasks etc; no production code change.                  |
            
    - Branching:
        ``` shell
            git branch '[layer]/[description]' '[commit-hash]'
            --- or ---
            git checkout -b '[layer]/[description]' '[commit-hash]'
        ```
        - Layer:
            - `frontend` - A branch that concerns the frontend (**presentation layer**) of the project.
            - `backend` - A branch that concerns the backend (**data access layer**) of the project.
        - Description:
            - Options: `feature`, `description`, or `bugfix`.
        - Commit Hash (Optional):
            - Create a branch of `[layer]/[description]` from a previous commit using the `[commit-hash]`.
