## Requisitos Previos

Antes de comenzar, asegúrese de tener instalados los siguientes requisitos en su sistema:

- .NET SDK - Versión 5.0 o superior
- Postman - Herramienta para probar API

## Instrucciones de Instalación

Siga los pasos a continuación para ejecutar el programa y usar Postman correctamente:

1. Clone el repositorio en su máquina local:
   `git clone https://github.com/David-Zeballos/Prueba-03`

2. Restaure las dependencias y compile el proyecto:
   `dotnet restore`
   `dotnet build`

3. Verificar la instalación de packetes de Entity Framework Core:
   `dotnet tool install --global dotnet-ef`

4. Ejecute las migraciones de la base de datos:
   `dotnet ef database update 0`
   `dotnet ef migrations add InitialCreate`
   `dotnet ef database update`
   (En caso de que el comando no funcione, remplace "dotnet ef" por "dotnet-ef" dentro de los comandos)

5. Inicie la aplicación:
   `dotnet run`

La aplicación se ejecutará en `http://localhost:5150`

Para probar la API con Postman, la aplicación deberá primero ser inicializada (paso 5).
Dentro de la carpeta 'Postman' se encuentra el importable que contiene las URL que se utilizaron para probar el programa.
Toda la información de la base de datos está dentro de `Context/SeedData.cs`
