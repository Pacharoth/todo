# Initialize Database Server
```sh
$ ./docker.sh
```
# Start and stop database 
```sh
$ docker start sql_connect
$ docker stop sql_connect
``` 
# To Start the Project
```bash
$ dotnet run
```
# Watch the project
```bash
$ dotnet run watch
```

# Use Azure Data Studio in order to connect and run sql 
# generate token key
```sh
$  node -e "console.log(require('crypto').randomBytes(32).toString('hex'))"
```
# CRUD API Task using Swagger and /swagger/index.html
