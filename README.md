# teamcowboy-api
A library for  coding in C# API for TeamCowboy  

This library is meant to aid you to code using the TeamCowboy API as quickly as possible across any platform using .NET.

```csharp
var teamCowboyClient = new TeamCowboyClient(new TeamCowboyClientOptions() {
    ApiKey = "",
    ApiSecret = ""
});

var userToken = await teamCowboyClient.GetUserTokenAsync(username, password);
var teams = await teamCowboyClient.GetUserTeamsAsync(userToken);
```