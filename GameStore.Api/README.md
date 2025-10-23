
dotnet --info

dotnet build

dotnet run

dotnet user-secrets init

{
  "ConnectionStrings": {
    "GameStoreContext": "Server=localhost;Database=GameStore;User Id=sa;Password=Your_password_here;TrustServerCertificate=True;MultipleActiveResultSets=true"
  }
}


dotnet add "c:\Courses\JulioCasalRestAPI\GameStore\GameStore.Api\GameStore.Api.csproj" package Microsoft.EntityFrameworkCore.SqlServer
dotnet add "c:\Courses\JulioCasalRestAPI\GameStore\GameStore.Api\GameStore.Api.csproj" package Microsoft.EntityFrameworkCore.Design
dotnet add "c:\Courses\JulioCasalRestAPI\GameStore\GameStore.Api\GameStore.Api.csproj" package Microsoft.EntityFrameworkCore.Tools
dotnet tool install --global dotnet-ef


dotnet ef migrations add InitialCreate --output-dir Data\Migrations  

