Om de RAYCO planner aan het werk te krijgen zijn meerdere acties vereist. Deze acties bestaan uit een verbinding leggen met het HR-systeem van RAYCO en de juiste koppeling te creëren met de SQL-Lite database.

#1 HR-systeem
Het HR-systeem is benodigd om gegevens op te vragen die de RAYCO planner nodig heeft. De file ‘HR.py’ is te vinden in de MOODLE omgeving van school. Om deze file te kunnen runnen is een Python-installatie vereist op de computer waarmee de RAYCO planner wordt gebruikt. Als Python reeds is geïnstalleerd dan is het belangrijk om te weten dat het bestand gebruik maakt van flask, deze kan worden geïnstalleerd door in cmd.exe het volgende commando uit te voeren: ‘pip install flask’. Hierna kan het python bestand worden gestart.

#2 SQL-Lite database
In de file Db.cs is onder de class Db deze functie te vinden: ‘static SQLiteConnection CreateConnection()’. In deze functie kun je de lokale variabele ‘sqlite_conn’ vinden, deze bestaat uit een string die uiteindelijk de verbinding gaat leggen met de database. 
Het is de bedoeling dat de ‘Data Source’ wordt aangepast naar de locatie die verwijst naar ‘database.db’ die eveneens in rootfolder is te vinden. Mocht hier hulp voor nodig zijn dan kan dit mij persoonlijk worden gevraagd of deze link van de website stackoverflow kan worden geraadpleegd: https://stackoverflow.com/questions/5001980/app-config-connection-string-relative-path

