# Lista de Tareas API

## Descripción

Esta aplicación backend está construida en C# utilizando .NET y proporciona una API para gestionar una lista de tareas. Los usuarios pueden agregar, actualizar y eliminar tareas. La API está diseñada para ser simple y eficiente, permitiendo operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en las tareas.

## Características

- **Agregar Tareas**: Permite a los usuarios añadir nuevas tareas a la lista.
- **Actualizar Tareas**: Permite a los usuarios modificar tareas existentes.
- **Eliminar Tareas**: Permite a los usuarios eliminar tareas de la lista.
- **Listar Tareas**: Proporciona una lista de todas las tareas almacenadas.

## Tecnologías Utilizadas

- **.NET 8**: Plataforma de desarrollo para construir aplicaciones web modernas.
- **Entity Framework Core**: ORM para interactuar con la base de datos.
- **PostgreSQL**: Sistema de gestión de bases de datos relacional.

## Instalación

1. **Clona el Repositorio**

    ```bash
    git clone https://github.com/tu_usuario/tu_repositorio.git
    ```

2. **Navega al Directorio del Proyecto**

    ```bash
    cd tu_repositorio
    ```

3. **Restaurar Dependencias**

    Asegúrate de tener el SDK de .NET 8 instalado. Luego, ejecuta el siguiente comando para restaurar las dependencias del proyecto:

    ```bash
    dotnet restore
    ```

4. **Configurar la Base de Datos**

    Crea una base de datos PostgreSQL y actualiza la cadena de conexión en `appsettings.json` con los detalles de tu base de datos.

5. **Aplicar Migraciones**

    Ejecuta las migraciones para crear las tablas necesarias en la base de datos:

    ```bash
    dotnet ef database update
    ```

6. **Ejecutar la Aplicación**

    Inicia la aplicación con el siguiente comando:

    ```bash
    dotnet run
    ```

    La API estará disponible en `http://localhost:5000` por defecto.

## Endpoints de la API

### `GET /api/tasks`

Obtiene la lista de todas las tareas.

**Respuesta:**

- Código 200 OK
- Tipo de Contenido: `application/json`

### `GET /api/tasks/{id}`

Obtiene una tarea específica por su ID.

**Parámetros:**

- `id`: El identificador de la tarea.

**Respuesta:**

- Código 200 OK
- Tipo de Contenido: `application/json`
- Cuerpo: Detalles de la tarea.

### `POST /api/tasks`

Agrega una nueva tarea.

**Cuerpo de la Solicitud:**

```json
{
  "title": "Título de la tarea",
  "description": "Descripción de la tarea"
}
