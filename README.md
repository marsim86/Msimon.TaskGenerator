# Prueba técnica solicitada previa a entrevista de trabajo para la empresa Zimaltec Soluciones
# --------------------------------------------------------------------------------------------
# Enunciado 
 
Prueba Técnica Zimaltec Soluciones - ebusiness
-----------------------------------------------------------------------------------------

Crea un repositorio en GitHub donde subas el código de una Minimal API para la gestión de un listado de tareas con los siguiente requisitos:
    - .NET 8
    - Guardado en base de datos usando un ORM 
    - Sistema de cache
    - Acciones:
        - Listar
        - Insertar
        - Reordenar tareas pendientes
        - Marcar como "hecho"

Si tienes tiempo y te apetece haz una interfaz de usuario sencilla que consuma la Minimal API

Aclaraciones
-----------------------------------------------------------------------------------------
Esta permitido el uso de paquetes Nuget y frameworks
Usa las buenas prácticas y patrones de diseño que consideres

Short description what this api does.

# FIN de enunciado 


## Notas aclaratorias.
- Se ha intentado poner en foco en la arquitectura de la aplicación, más que en el propio código pues solucionar el mismo no tiene gran complejidad.
- La aplicación se ha dividido en tres capas:
	1 - Application, donde se definen los controladores a levantar, así como todas las configuraciónes de la aplicación.
        Aquí está el Program.cs que es el Main de la aplicacion.
    2 - Libary.  Incluye toda la capa de negocio, publica servicios que son consumidos desde la capa Application.  Consume los servicios proporcionados desde la capa de Infrastructure.
    3 - Infrastructue.  Engloba todos los servcios externos a consumir desde la capa Library, en nuestro caso el Acceso a DB, pero aquí se incluirian el acceso a otras apis, FS, ...
- La clase Entidad se encuentra varias veces implementada, demasiadas para lo pequeño de nuestro proyecto, pero he querido hacer una implementación completamente desacoplada entre el Model y los Dto(s).
- Incluso los dto he creado dos, que perfectamente podria ser uno único (sería más correcto para nuestro caso).
- He crado una prueba unitaria y otra prueba de integración.  Habría que hacer pruebas de integración para almenos todos los servicios de Library para todos los Controllers publicados.
- Los endpoints publicados utilizan un versionado para su publicación, por si la aplicación necesitase más de una versión publicada a la vez.
- Para el Sistema de Caché, que nunca había trabajado previamente, he utilizado el interfaz IMemoryCache que implementa Microsoft.
