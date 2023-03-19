
# インストール
dotnet add package Microsoft.EntityFrameworkCore  
dotnet add package Microsoft.EntityFrameworkCore.SqlServer  
dotnet add package Microsoft.EntityFrameworkCore.Design  
  

dotnet tool install --global dotnet-ef  
  
  
dotnet ef migrations add InitialCreate  
→コマンドが見つからない場合は、dotnet-efをインストールする必要がある。  

dotnet ef database update


# エラー

