Program.cs loads every 5 minutes page status.php .  
if page returns 1 , then program calls shutdown.exe .  
You may want to add program to startup ,  
then just add registry key with path to program in  
HKEY_CURRENT_USER:\SOFTWARE\Microsoft\Windows\CurrentVersion\Run  
