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

## Creación del primer usuario

La aplicación requiere un usuario registrado en la tabla `Usuarios` para acceder al módulo de gestión de clientes.

Por motivos de seguridad, el proyecto no incluye usuarios ni contraseñas predeterminadas.

### 1. Generar el hash de la contraseña

El proyecto utiliza PBKDF2-HMAC-SHA256 para proteger las contraseñas, mediante la clase `PasswordHelper.vb`, ubicada en la carpeta `Seguridad`.

Para generar el hash inicial durante la configuración local:

1. Abrir el proyecto en Visual Studio.
2. Abrir `Login.aspx.vb`.
3. Agregar temporalmente dentro de `Page_Load`:

```vb
If Not IsPostBack Then
    Dim hash As String = PasswordHelper.GenerarHash("CONTRASEÑA_DE_PRUEBA")
    System.Diagnostics.Debug.WriteLine("HASH GENERADO: " & hash)
End If
```

4. Reemplazar `CONTRASEÑA_DE_PRUEBA` por una contraseña elegida para el entorno local.
5. Ejecutar `Login.aspx` y consultar **View → Output → Debug**.
6. Copiar el hash generado, que comienza por `PBKDF2-SHA256$`.
7. Eliminar inmediatamente el código temporal de `Page_Load`.

### 2. Registrar el usuario en SQL Server

Abrir SQL Server Management Studio y ejecutar:

```sql
USE PruebaTecnicaDB;
GO

INSERT INTO Usuarios (nombreUsuario, PasswordHash)
VALUES ('admin', 'PEGAR_AQUI_EL_HASH_GENERADO');
```

Reemplazar `PEGAR_AQUI_EL_HASH_GENERADO` por el hash obtenido anteriormente.

### 3. Verificar el registro

```sql
SELECT IdUsuario, nombreUsuario, FechaCreacion
FROM Usuarios;
```

El usuario `admin` debería aparecer registrado.

### 4. Iniciar sesión

Ejecutar la aplicación y acceder a `Login.aspx`.

Introducir el nombre de usuario y la contraseña utilizada para generar el hash.

Si las credenciales son válidas, el sistema permitirá acceder al módulo de gestión de clientes.

**Nota de seguridad:** el usuario y la contraseña deben crearse localmente. No se deben publicar contraseñas, hashes generados ni credenciales reales en el repositorio.


## Seguridad

Las consultas SQL utilizan parámetros para reducir el riesgo de inyección SQL. Las contraseñas se verifican mediante PBKDF2-SHA256 con sal aleatoria y las operaciones del CRUD se registran mediante transacciones SQL.

El proyecto está orientado a demostración técnica y ejecución local.

## Autor

Rafael Mena
