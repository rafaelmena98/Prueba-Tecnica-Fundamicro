# Prueba Técnica Fundamicro

Sistema de gestión de clientes desarrollado con ASP.NET Web Forms, VB.NET y SQL Server.

## Tecnologías utilizadas

- ASP.NET Web Forms
- VB.NET
- .NET Framework 4.7.2
- SQL Server LocalDB
- ADO.NET
- Git y GitHub

## Funcionalidades

- Inicio y cierre de sesión.
- Autenticación de usuarios con contraseñas protegidas mediante PBKDF2-SHA256.
- Gestión de clientes: crear, consultar, actualizar y eliminar.
- Validación de campos obligatorios, longitudes y formato de correo.
- Protección de acceso mediante sesiones.
- Bitácora de operaciones que registra usuario, cliente, acción y fecha.
- Transacciones SQL para mantener la consistencia entre las operaciones y su auditoría.

## Estructura del proyecto

- **Modelos:** clases que representan los datos de clientes y usuarios.
- **Datos:** clases DAO encargadas de las operaciones SQL.
- **Seguridad:** generación y verificación de hashes de contraseñas.
- **Login.aspx:** formulario de autenticación.
- **Clientes.aspx:** interfaz de gestión de clientes.
- **database.sql:** script de creación de la base de datos.

## Requisitos

- Visual Studio con soporte para ASP.NET y desarrollo web.
- .NET Framework 4.7.2.
- SQL Server LocalDB o una instancia compatible de SQL Server.

## Instalación

1. Clonar el repositorio.
2. Abrir la solución en Visual Studio.
3. Ejecutar `database.sql` en SQL Server para crear la base de datos y las tablas.
4. Verificar la cadena de conexión `ConexionDB` en `Web.config`.
5. Crear un usuario inicial en SQL Server, generando previamente su hash mediante `PasswordHelper.GenerarHash()`.
6. Compilar y ejecutar la aplicación mediante IIS Express.
7. Acceder a `Login.aspx` para iniciar sesión.

## Seguridad

Las consultas SQL utilizan parámetros para reducir el riesgo de inyección SQL. Las contraseñas se verifican mediante PBKDF2-SHA256 con sal aleatoria y las operaciones del CRUD se registran mediante transacciones SQL.

El proyecto está orientado a demostración técnica y ejecución local.

## Autor

Rafael Mena
