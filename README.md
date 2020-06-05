# Gestión De Incidencias
![Imagen no disponible](https://image.freepik.com/foto-gratis/hombre-reparando-placa-circuito-computadora-portatil_1098-14844.jpg)


El proyecto está compuesto por varios subproyectos de visual studio, para poder ejecutarlos es necesario:
* Tener instalado el servidor MySql de la base de datos y mediante algún gestor ejecutar el script "*incidenciasDefinitivo.sql*"
* Descargar los recursos de imagenes y audio tal y como indicamos en el paso 3 y copiarlos en la estructura del proyecto siguiendo las indicaciones.
* A la hora de ejecutar el proyecto desde Visual Studio es importante asegurarse de tener escogida la opción "iniciar múltiples proyectos" y seleccionados los proyectos "*Capa Presentación*" y  "*ApiIncidencias*"

En las próximas líneas se mostrarán más datos que permitan ejecutar la aplicación, junto a los enlaces de recursos necearios.

1. Guía de instalación de Wamp para base de datos mySql:
[lynk](https://ortizvivas.com/blog/configurar-wamp/)

2. Mediante el script incidenciasDefinitivo.sql genera la base de datos local, la aplicación generará una webApi a partir de ella
La aplicación tiene definidio el usuario "*tienda*" y la contraseña "*1234*", puedes usar cualquier otro usuario que tengas definido, pero deberás modificar el archivo "*Startup.cs*" del Proyecto ApiIncidencias con los valores de usuario y contraseña de tu base de datos.

Para crear el usuario desde un cliente mySql puedes:
```
CREATE USER 'tienda'@'localhost' IDENTIFIED BY '1234';
GRANT EXECUTE, PROCESS, SELECT, SHOW DATABASES, SHOW VIEW, ALTER, ALTER
ROUTINE, CREATE, CREATE ROUTINE, CREATE TABLESPACE, CREATE TEMPORARY
TABLES, CREATE VIEW, DELETE, DROP, EVENT, INDEX, INSERT, REFERENCES,
TRIGGER, UPDATE, CREATE USER, FILE, LOCK TABLES, RELOAD, REPLICATION
CLIENT, REPLICATION SLAVE, SHUTDOWN, SUPER ON *.* TO 'tienda'@'localhost';
FLUSH PRIVILEGES;
CREATE USER 'tienda'@'%' IDENTIFIED BY '1234';
GRANT EXECUTE, PROCESS, SELECT, SHOW DATABASES, SHOW VIEW, ALTER, ALTER
ROUTINE, CREATE, CREATE ROUTINE, CREATE TABLESPACE, CREATE TEMPORARY
TABLES, CREATE VIEW, DELETE, DROP, EVENT, INDEX, INSERT, REFERENCES,
TRIGGER, UPDATE, CREATE USER, FILE, LOCK TABLES, RELOAD, REPLICATION
CLIENT, REPLICATION SLAVE, SHUTDOWN, SUPER ON *.* TO 'tienda'@'%';
FLUSH PRIVILEGES;
SHOW GRANTS FOR 'tienda'@'%';
```
3. Puedes descargar los recursos necesarios para ejecutar el proyecto desde el siguiente enlace:
[link](https://www.dropbox.com/sh/4uks71rvehhzlt3/AAAfe_1TDmTGVLdevgwMhhPha?dl=0)d

NOTA: los usuarios tienen la contraseña "1111"  por facilidad en las pruebas de la aplicación, sin embargo si se pretende editar un usuario la contraseña debe tener de 8 a 12 caracteres y contener una mayúsculas, un número y un caracter especial.

Una vez descargados, dentro del proyecto, debes copiar las carpetas "**Imagenes**" y "**Sonido**" en la carpeta "**Capa_Presentación**"
Muchas gracias, para cualquier aclaración no dudeis en preguntarme.
