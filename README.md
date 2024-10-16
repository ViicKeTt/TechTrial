

# TechTrial

# Proyecto Web API en .NET Core 8 con Entity Framework Core

Este proyecto es una Web API desarrollado en **.NET Core 8** que implementa **Entity Framework Core** usando los patrones **Repositorio** y **Unit of Work**, siguiendo el enfoque **Code First**.

## Requisitos previos

Antes de clonar y configurar el proyecto, asegúrate de tener instalados los siguientes componentes:

- **.NET Core SDK 8.0**: [Descargar .NET SDK](https://dotnet.microsoft.com/download)
- **SQL Server** 
- **Visual Studio 2022** o **VS Code** con soporte para desarrollo en .NET Core
- **Git**: [Descargar Git](https://git-scm.com/downloads)

## Clonar el repositorio

Clona el repositorio desde GitHub usando el siguiente comando:

```bash
git clone https://github.com/ViicKeTt/TechTrial.git
```

Luego, navega al directorio del proyecto:

```bash
cd TechTrial
```

# Configuración del entorno

## 1. Configurar la base de datos
El proyecto está configurado para utilizar Entity Framework Core con un enfoque Code First, lo que significa que la base de datos se generará a partir de las entidades definidas en el código.

Abre el archivo **appsettings.json** y localiza la sección de conexión de base de datos:

```bash
{
  "ConnectionStrings": {
    "TechTrialConnection": "Server=.;Database=NombreDeTuBaseDeDatos;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

Actualiza la cadena de conexión **(TechTrialConnection)** con la información de tu servidor SQL Server o base de datos preferida.
 
## 2. Actualizar base de datos
Para poder crear la base de datos según el modelo del context sigue los siguientes pasos:
 
1. Abrir la Consola del Administrador de Paquetes (Package Manager Console).
    1. En el menú superior de Visual Studio, dirígete a Herramientas.
    2. Selecciona Administrador de paquetes NuGet.
    3. Haz clic en Consola del Administrador de Paquetes.

Esto abrirá la ventana de la Consola del Administrador de Paquetes en la parte inferior de Visual Studio.

2. Seleccionar el Proyecto de Inicio
    1. Selecciona el proyecto de T.DataAccess, en este proyecto estan alojados todas la migraciones.
    2. Una vez abierta la consola, ejecuta el siguiente comando
```bash
Update-Database
```
3. Verificación de la Ejecución.
 Al ejecutar el comando, verás mensajes en la consola indicando el proceso de la migración. Algunos puntos importantes que puedes notar:
* El contexto de la base de datos que se está utilizando.
* Las migraciones que se están aplicando.
* Mensajes de confirmación si el proceso es exitoso.

Si todo va bien, tu base de datos será actualizada conforme a las migraciones definidas en el proyecto.

4. Verificar en la Base de Datos
Finalmente, puedes verificar si los cambios han sido aplicados correctamente:
    1. Abre SQL Server Management Studio (o cualquier otra herramienta de gestión de base de datos que estés utilizando).
    2. Conéctate a la base de datos definida en tu archivo **appsettings.json.**
    3. Verifica si las tablas o cambios especificados en las migraciones han sido aplicados.

# Solución de Problemas
Si te encuentras con algún error, verifica lo siguiente:
1. La cadena de conexión en appsettings.json esté correcta.
2. En este proyecto me aseguraré de tener migraciones generadas. En caso de no tener ninguna migracion aún, usa el comando:

```bash
Add-Migration "Init"
```
Y luego ejecutas el comando:

```bash
Update-Database
```
3. Confirma que el proyecto correcto esté seleccionado en el combo box de la consola (T.DataAccess).

##### Con estos pasos deberías poder actualizar tu base de datos con las migraciones aplicadas correctamente y poder utilizar la APi de TechTrial.

# Uso de la Api

## Gestión de Candidatos
Este proyecto expone un API RESTful para gestionar las operaciones CRUD para la entidad Candidato y para registrar métricas de consumo del API. A continuación se detallan los endpoints disponibles, sus descripciones, y cómo interactuar con ellos.

### Entidad Candidato

La entidad Candidato representa a un solicitante que aplica para un puesto de trabajo. Los atributos principales de la entidad son:

- ID: Identificador único.
- Nombres: Nombre del candidato.
- Apellidos: Apellido del candidato.
- Correo Electrónico: Email del candidato.
- Teléfono: Número telefónico de contacto.
- Fecha de nacimiento: Fecha de nacimiento del candidato.
- Puesto Aplicado: Nombre del puesto al cual está aplicando.
- Fecha de aplicación Puesto: Fecha en que se realizó la aplicación.

### Endpoints Disponibles

#### Crear un Candidato
Método: **POST**
Ruta: **/candidatos**

##### Descripción
Crea un nuevo registro para un candidato.

##### Ejemplo de Solicitud
```bash
{
    "id": 0,
    "nombres": "Juan",
    "apellidos": "Pérez",
    "correoElectronico": "juan.perez@example.com", 
    "fechaNacimiento": "1990-01-01",
    "telefono": "+123456789",
    "fechaAplicacion":  "2024-10-10",
    "puestoAplicado": "Desarrollador Web"
} 
```
Respuesta Exitosa (Código 201 - Created) 

#### Obtener todos los Candidatos
Método: **GET**
Ruta: **/candidatos**

##### Descripción 
Obtiene una lista de todos los candidatos registrados.

##### Ejemplo de Solicitud
```bash
[
    {
        "id": 0,
        "nombres": "Juan",
        "apellidos": "Pérez",
        "correoElectronico": "juan.perez@example.com", 
        "fechaNacimiento": "1990-01-01",
        "telefono": "+123456789",
        "fechaAplicacion":  "2024-10-10",
        "puestoAplicado": "Desarrollador Web"
    } 
]
```

#### Obtener un Candidato por ID
Método: **GET**
Ruta: **/candidatos/{id}**

##### Descripción 
Obtiene la información de un candidato específico por su ID.

##### Parámetros de Ruta
- id: Identificador único del candidato.

Respuesta Exitosa (Código 200 - OK)

```bash
[
    {
        "id": 0,
        "nombres": "Juan",
        "apellidos": "Pérez",
        "correoElectronico": "juan.perez@example.com", 
        "fechaNacimiento": "1990-01-01",
        "telefono": "+123456789",
        "fechaAplicacion":  "2024-10-10",
        "puestoAplicado": "Desarrollador Web"
    } 
]
```

#### Actualizar un Candidato 
Método: **PUT**
Ruta: **/candidatos/{id}**

##### Descripción 
Actualiza la información de un candidato existente.

##### Ejemplo de Solicitud
```bash
[
    {
        "id": 0,
        "nombres": "Juan",
        "apellidos": "Pérez",
        "correoElectronico": "juan.perez@example.com", 
        "fechaNacimiento": "1990-01-01",
        "telefono": "+123456789",
        "fechaAplicacion":  "2024-10-10",
        "puestoAplicado": "Desarrollador Web"
    } 
]
```

Respuesta Exitosa (Código 200 - OK)


#### Eliminar un Candidato
Método: **DELETE**
Ruta: **/candidatos/{id}**

##### Descripción 
Elimina un candidato del sistema por su ID.

Respuesta Exitosa (Código 200 - OK)
