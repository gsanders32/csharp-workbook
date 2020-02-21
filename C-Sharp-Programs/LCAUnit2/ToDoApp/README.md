# To Do App

## LCA Unit 2 Checkpoint 2

This is a very simple app that uses a Sqlite database
1) Add To Do Item 
2) Delete To Do Items
3) Update To Do Item status
4) list To Do Items

## Actions/Menu

```
Add
Delete
Status Change
List All Items
List Pending
List Finished
Quit
```

##### Add

1. Type Add or A
2. The program will ask for a description of the task.
3. The program will display a success/error message

```
Example
1) [User Enters] Add
2) [Program Displays] Description: [User enters] Fill the car with gas!
3) [Program Displays] Item Added!
```

##### Delete

1. Type Delete or D
2. The program will ask for a Id of the item you want to delete.
3. The program will display a success/error message

```
Example
1) [User Enters] Delete
2) [Program Displays] Delete an item from the list. Please enter the Id of the item. [User enters] 1
3) [Program Displays] Item Deleted!
```

##### Status Change

1. Type Status or S
2. The program will ask for a Id of the item you want to change.
3. If the current status is Pending then it will be changed to Finished. If the status is Finished then it will be changed to Pending.
3. The program will display a success/error message

```
Example
1) [User Enters] Status
2) [Program Displays] Change the status of a todo item. Please enter the Id of the item. [User enters] 1
3) [Program Displays] Item Status Changed!
```

##### List All Items

1. Type List or L
2. The program will display all items.

```
Example
1) [User Enters] List
2) [Program Displays] ID  | Description       | Status
                      1   | Fill Car with gas | Pending
                      2   | Do homework       | Finished
```

##### List Pending Items

1. Type Pending or P
2. The program will display all pending items.

```
Example
1) [User Enters] Pending
2) [Program Displays] ID  | Description       | Status
                      1   | Fill Car with gas | Pending
```

##### List Finished Items

1. Type Finished or F
2. The program will display all finished items.

```
Example
1) [User Enters] Finished
2) [Program Displays] ID  | Description       | Status
                      2   | Do homework       | Finished
```

##### Quit

1. Type Quit or Q
2. The program will displays a Good Bye!.

```
Example
1) [User Enters] Quit
2) [Program Displays] Good Bye!
```

### Author

* Gray Sanders


