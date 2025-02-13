# PRUEBA TECNICA PARA ABANK

##API DE USUARIOS

ESTA API ESTA REALIZADA POR MI PERSONA CHRISTIAN MONGE 
COMO PRIMER PASO PARA PODER ACCEDER A TODOS LOS RECURSOS DEL SISTEMA SERA NECESARIO ABRIR LA CARPETA BASE DE DATOS JUNTO A ESTE DOCUMENTO DE TEXTO
Y EJECUTAR EL QUERY LLAMADO QUERY PARA TABLA 

POSTERIORMENTE ABRIR LA CARPETA APIAbank Y EL ARCHIVO CON EXTENSION .SLN 

LUEGO DE ELLOS DIRIGIRSE A LA APLICACION DE LA API Y LA CLASE Program.cs y modificar el servidor en la cadena de conexion el cual seria el de la PC 
de la cual se esta abriendo la solucion

El sistema de usuario cuenta con 6 endpoints

1-login con autenticacion por telefono y contraseña
2-lista de todos los usuarios
3-datos de usuario por id
4-creacion de un nuevo usuario
5-modifacion de un usuario ya creado
6-eliminacion de un usuario 

cada uno de los endpoints cuentan manejo de exepciones en el cual si da un error por x motivo arrojara un status 500 de cada uno

La arquitectura que se ha utilizado ha sido arquitectura limpia separando los datos sensibles 

Se hizo uso se JWT para la generacion de un token a la hora de acertar con el inicio de sesion en el endpoint de autenticacion 

tambien se agrego una carpeta llamada CAPTURAS junto a la base de datos y el sistema donde se ven los status de cada endpoint en 200 y las pruebas del mismo


Muchas gracias de antemano por la oportunidad, bendiciones.
