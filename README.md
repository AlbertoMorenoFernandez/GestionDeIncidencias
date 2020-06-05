# GestionDeIncidencias
1. Guía de instalación de Wamp para base de datos mySql:
[lynk](https://ortizvivas.com/blog/configurar-wamp/)
2. Mediante el script incidenciasDefinitivo.sql genera la base de datos local, la aplicación generará una webApi a partir de ella
La aplicación tiene definidio el usuario "tienda" y la contraseña "1234",  usar cualquier otro usuario que tengas definido, pero deberás modificar el archivo "Startup.cs" del Proyecto ApiIncidencias con los valores de usuario y contraseña de tu base de datos.  Para crear el usuario desde un cliente mySql puedes:

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

3. Para poder ejectur el proyecto es necesario descargar los siguientes recursos:
[link](https://www.dropbox.com/sh/4uks71rvehhzlt3/AAAfe_1TDmTGVLdevgwMhhPha?dl=0)
Dentro del proyecto, copia las carpetas imagenes y sonido en la carpeta Capa_Presentación
4. una vez copiadas se debe indicar en la solución:
- Iniciar múltiples proyectos
- E iniciar la capa presentación y la ApiIncidencias.
