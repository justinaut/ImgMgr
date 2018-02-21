(copied and re-formatted from word into markdown)

# Creating Client Applications in C#
Final Project  
University of Washington Extension

INSTRUCTOR: David Figge  
E-MAIL: [removed]

## Overview
### Project Description
The final project is to create a Windows program that presents photographs and their associated information to the user. The project will keep track of the photo and information about the photo. The UI will present the user with a list of photos, allow the user to display a photo, allow the user to select a photo based on keywords, and add new photos into the system’s data store.

### Project Objective
The purpose of the final project is to provide an opportunity for you to implement a solution of your own design on a somewhat larger-than-typical-lab project. This project can be done in many ways, both simple and complex. Your job is to use this program to explore and experiment with the various topics we’ve covered in this (and the previous) course. Use the best mechanisms, logic, and coding you can to get the job done.

Note also that, although we covered many things that are often used to take a good program and make it more flexible or more efficient, you should not feel compelled to include everything in the project just because we covered them. There are some required items for the project, but if a non-required item doesn’t add to or work well in the project, don’t feel obligated to include it. (For example, don’t be compelled to add a Stack object when it doesn’t really add any value to the project). Just focus on making the project work in the best way you know how.

### Project Deadline
The project is due one hour before the end of the last session of class. We will use the first two hours of class as a work period to help finish this project. The final hour will be used to work with each of you to review your code and give you feedback. This one-on-one review session is a course requirement. If you are ready before the deadline, let us know and we will endeavor to find a mutually agreeable time to “check you off” beforehand. Once the course material has been fully covered by the instructor (e.g. the end of week 9), all your required lab submissions have been supplied, and you are checked off for the final project, your course requirements have been met.
We will try to provide some class time to work on the final project, but this may not be enough time for you to complete the project. You are encouraged to work on this at home as well as during the in-class sessions. Most students should expect to work a minimum of 8 hours at home on the final project. 

## Final project details
The project is a photograph management system. The requirements are as follows:

### Project Requirements
#### Program Structure
The application keeps track of photographs and their related data. The specific data to be kept for each photo is:
* The title of the photo (Data type: String)
* The date the picture was taken (Data type: DateTime)
* The date the picture was added to the program (Data type: DateTime)
* A description of the photograph (Data type: String)
* The name of the artist who took the picture (Data type: String)
* A list of keywords associated with the photo (Data type: String, keywords separated by ,)
* The file location of the photo (Data type: String)

The data for each photo is to be kept in a Photograph class, which should contain the above elements.

You will need to build the information about the photos. You can usually find some sample photos (which is sufficient for the project) in the "C:\Users\Public\Pictures\Sample Pictures" directory. You can also use any other photos you may have or locate. The data about the photo (when it was taken, by whom, etc.) does not need to be accurate (e.g. feel free to make it up). Consider pre-populating several photos into your collection at start-up so you don’t need to enter them manually for every run of the program.

The user interface is to be written as a Windows WPF application. The main window must include at least:
* A DataGrid control displaying information about the collection of photos. It should (only) contain the columns for Title, Date Taken, and Description.
* A PictureBox. This is used to display the photograph itself. You will need to do some investigation/experimentation about how this control works. Set the image to display by using the “ImageLocation” property and try using the “Zoom” stretchMode to maintain proper aspect ratio. The photograph displayed must be the one currently selected in the DataGrid.
* Beside the picture box should be a series of label controls used to display the information (from the Photograph class object) to the user. This, obviously, should update as the selected picture changes like the image. The contents of these text boxes is to be set using data binding.
* A search (text) box and button. By entering information into this box, the information in the DataGrid is to be narrowed down to only those items where the specified text appears in:
	* The artist’s name
	* The title of the photo
	* The description of the photo
	* One of the keywords specified in the Keywords string of the photograph class
		* Multiple keywords can be entered separated by commas (,). To separate the keywords, use either the String class commands to split the string apart at the comma characters, or a Regex pattern (your choice).
		* Multiple keys represent “any of these” options. So “Dog, Cat” would match any photo with Dog and any photo with Cat  
Note that, because the contents of the DataGrid is driven by the search process, using data binding for this control may not be the most effective solution. It may also make sense to use a separate collection to drive the DataGrid than the photos collection (since it sometimes shows a subset of the entire photo collection).
* A New button, used to enter a new photograph into the collection
* A “New Photograph” dialog box is to appear asking for the relevant information about the photograph. The dialog box should have the typical “OK” and “Cancel” buttons. If the user presses OK, a new Photograph object should be properly populated and added to the collection of photograph objects. 
	* In your “New Photo” dialog box, make use of the OpenFileDialog component of C# to provide a dialog that navigates the file system to identify the photo on the disk. You will need to research/experiment with how to use this, but it is a powerful tool to know about.

#### Optional Extras
The above describes the minimum project requirements. If you have time and wish to add more to your project, you might consider the following:
* Saving/loading your project data between sessions. This could either be to a database or to a data file. If you use a database, use it in conjunction with the internal data collection, not as a replacement for that mechanism.
* In addition to entering new information about a photo, provide the option for editing an existing photo entry. You might even be able to reuse the “New” dialog box…
* Modify the Search function to do an “active search”, so when new characters are entered the selected list automatically narrows it’s choices. To do this, investigate tapping into the TextBox’s TextChanged event.
 
#### General
Comments block
All code should be adequately commented. Each function should include the standard header comments supported by C# using the XML header information (comments with ///). For example
```C#
   /// <summary>
   /// Create an XML file containing all the address entries
   /// </summary>
   /// <param name="initialLocation">Where to start the search</param>
   /// <returns>True location if successful, null if not</returns>
   private String LocatePhoto(string initialLocation)
   { ... }
```
This is generally considered minimum documentation for a program. This is only required in code that you specifically write (not in compiler generated code such as designer.cs modules). You should also comment any code lines that might be confusing to the reader. Rule of thumb: if it’s not crystal clear what’s happening in your code, add some comments.
#### Naming
All variable and function names (except short-term local counter or index-type variables) **MUST be meaningful**.  This means that no single letter (or ‘X1’) type variables in any significant role. When in doubt, make it meaningful. Further, variable and function names should be consistent.

### Project Grading
Although it is certainly a significant portion of this class, it is not graded as such. It is simply an opportunity for you to apply some of the knowledge you have learned in class to a larger-than-typical-lab project, and to allow you to design as well as implement the solution. It is not a graded exercise, it’s more of a learning opportunity and should be approached as such.
