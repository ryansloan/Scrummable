Scrummable
==========

Simple Sprint Planning App - designed to hook up to Bug Database to import and export state

Class/Interface descriptions
============================

BugDataBaseInterface
--------------------
This interface describes the necessary methods to interact with the frontend. Namely:
* **Connect()** - This method should make the connection to the bug database. Take whatever params will be required to do that.
* **Disconnect()** - Self explanatory :)
* **ImportBugsAssignedTo(String user)** - Given a username, this method should query the bug database for all bugs assigned to that user. It should return those bugs as a list.
* **ImportBugById(String id)** - Given a single ID, this method should query the bug database for the bug corresponding to that Id. If it doesn't exist, it should return Null, otherwise return the bug.
* **ImportBugById(String[] id)** -- Same as above, but takes in multiple ID's to minimize database calls. Should return a List of Bugs.
* **ExportBugChanges(Bug b)** -- The supplied bug should be updated in the Bug Database.

DummyDataConnection
-------------------
This is a sample implementation of BugDatabaseInterface that just reads from a File in the user's My Documents folder. That file should be semicolon delimited and formatted like so:
ID;Title;AssignedTo;FixBy;Estimate;NodeName

Bug
---
This represents a single Bug. Very creatively named.
* **Id** - Bug's ID in the Bug Database
* **Title**
* **AssignedTo** - Username of asignee in DB
* **FixBy** - Target for bug resolution
* **NodeName** - Area or Workgroup for Bug.
* **Estimate**


Windows
=======
* **MainWindow.xaml** is the primary app screen.
* **AddBugWindow** is the dialog in which one can enter bug ID(s) to be imported.
* **AddUserWindow** is the dialog in which one can enter Assignees to be imported.

