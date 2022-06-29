# First part:generate a https certs
* how to generate a https certs by using dotnet
* $env:USERPROFILE is C:\Users\yournamefolder
* this new cert you can find it in C:\Users\yournamefolder\.aspnet\https\
dotnet dev-certs https  -ep $env:USERPROFILE\.aspnet\https\DockerAPI.pfx -p passw0rd!

# Second part: trust
* Then execute trust
* dotnet dev-certs https --trust

# Third part: add secrets
* user usersecrets provided by microsoft
* 1 in the .csproj file <propertyGroup> insert <UserSecretsId>GUID</UserSecretsId>
* 2 use command line to go to you code directory
* 3 in the code directory, execute the command: dotnet user-secrets set "Kestrel:Certificates:Development:Password" "passw0rd!"
* 4 after executing you can find a GUID folder in C:\Users\youname\AppData(this may be a hideen folder)\Roaming\Microsoft\UserSecrets\GUID. It is a secret.json file


# after all the above, you can build you docker image

# Then you can run your imgae(use the bellow commmand)

docker run 
-p 8080:80 -p 8081:443   
-e ASPNETCORE_URLS="https://+;http://+"  
-e ASPNETCORE_HTTPS_PORT=8081 
-e ASPNETCORE_ENVIRONMENT=Development 
-v $env:APPDATA\microsoft\UserSecrets\:/root/.microsoft/usersecrets 
-v $env:USERPROFILE\.aspnet\https:/root/.aspnet/https/  dockerimagename

