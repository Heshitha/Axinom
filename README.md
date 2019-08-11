# Axinom
 Axinom Test Zip Uploader
 
 Steps to run the application
	Open BackendApp solution from visual studio.
	Install missing Nuget packages.
	Change the DataContext connection string in web.config in BackendApp project to an empty MSSQL DB created by you.
	Run migrations after that so you would have two sample users.
		Username : Heshitha | Password : srilanka
		Username : Liis | Password : estonia
	Run the application to verify URL
	
	Open the ZipFileUploader.sln in another VS Console
	Check if "backendApp" property in it's web.config same as the backend application. Otherwise replace with your application url.
	Now run the ZipFileUploader project as well.
	You will see Homepage in your browser.
	Upload a zip file and try it out.
	If you haven't created any user accounts in DB feel free to use user accounts above mentioned.
	
This application developed to demo following
	Communication between two applications via HTTP
	Read a Zip file content as Tree Hierarchy
	Usage of AES Encription
	Usage of Basic Authentication
	Usage of Log4Net
	
Happy Coding!!!
