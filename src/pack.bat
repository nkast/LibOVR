set username=username

dotnet pack LibOVR\LibOVR.csproj /p:Configuration=Release -o LibOVR\bin\Release

"C:\Program Files (x86)\nuget\nuget.exe" delete nkast.libovr 2.1.0 -Source "C:\Users\%username%\.nuget\localPackages" -NonInteractive

"C:\Program Files (x86)\nuget\nuget.exe" add LibOVR\bin\Release\nkast.LibOVR.2.1.0.nupkg -Source "C:\Users\%username%\.nuget\localPackages"


pause