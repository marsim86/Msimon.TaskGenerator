# Prueba t�cnica solicitada previa a entrevista de trabajo para la empresa Zimaltec Soluciones
# --------------------------------------------------------------------------------------------
# Enunciado 
 
Prueba T�cnica Zimaltec Soluciones - ebusiness
-----------------------------------------------------------------------------------------

Crea un repositorio en GitHub donde subas el c�digo de una Minimal API para la gesti�n de un listado de tareas con los siguiente requisitos:
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
Usa las buenas pr�cticas y patrones de dise�o que consideres

Short description what this api does.

# FIN de enunciado 


## Notas aclaratorias.
- Se ha intentado poner en foco en la arquitectura de la aplicaci�n, m�s que en el propio c�digo pues solucionar el mismo no tiene gran complejidad.
- La aplicaci�n se ha dividido en tres capas:
	1 - Application, donde se definen los controladores a levantar, as� como todas las configuraci�nes de la aplicaci�n.
        Aqu� est� el Program.cs que es el Main de la aplicacion.
    2 - Libary.  Incluye toda la capa de negocio, publica servicios que son consumidos desde la capa Application.  Consume los servicios proporcionados desde la capa de Infrastructure.
    3 - Infrastructue.  Engloba todos los servcios externos a consumir desde la capa Library, en nuestro caso el Acceso a DB, pero aqu� se incluirian el acceso a otras apis, FS, ...
- La clase Entidad se encuentra varias veces implementada, demasiadas para lo peque�o de nuestro proyecto, pero he querido hacer una implementaci�n completamente desacoplada entre el Model y los Dto(s).
- Incluso los dto he creado dos, que perfectamente podria ser uno �nico (ser�a m�s correcto para nuestro caso).
- He crado una prueba unitaria y otra prueba de integraci�n.  Habr�a que hacer pruebas de integraci�n para almenos todos los servicios de Library para todos los Controllers publicados.
- Los endpoints publicados utilizan un versionado para su publicaci�n, por si la aplicaci�n necesitase m�s de una versi�n publicada a la vez.
- Para el Sistema de Cach�, que nunca hab�a trabajado previamente, he utilizado el interfaz IMemoryCache que implementa Microsoft.
