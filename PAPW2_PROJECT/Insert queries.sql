insert into Perfiles(tipo_Perfil) values ('Editor');
insert into Perfiles(tipo_Perfil) values ('Usuario Registrado');
insert into Perfiles(tipo_Perfil) values ('Reportero');

insert into Colores(nombre_Color) values ('#FF6666');
insert into Colores(nombre_Color) values ('#FFB266'); 
insert into Colores(nombre_Color) values ('#FFFF66'); 

insert into Estatus (nombre_Estatus) values ('En redacción');
insert into Estatus (nombre_Estatus) values ('Terminada');
insert into Estatus (nombre_Estatus) values ('Publicada');

Insert into Paises (nombre_Pais) values ('México');
Insert into Paises (nombre_Pais) values ('Estados Unidos');
Insert into Paises (nombre_Pais) values ('Canada');

Insert into Ciudades (iD_PaisF, nombre_Ciudad) values (1, 'Monterrey');
Insert into Ciudades (iD_PaisF, nombre_Ciudad) values (1, 'CDMX');
Insert into Ciudades (iD_PaisF, nombre_Ciudad) values (1, 'Guadalajara');
Insert into Ciudades (iD_PaisF, nombre_Ciudad) values (2, 'Washington');
Insert into Ciudades (iD_PaisF, nombre_Ciudad) values (2, 'New York');
Insert into Ciudades (iD_PaisF, nombre_Ciudad) values (2, 'Los Ángeles');
Insert into Ciudades (iD_PaisF, nombre_Ciudad) values (3, 'Toronto');
Insert into Ciudades (iD_PaisF, nombre_Ciudad) values (3, 'Vancouver');

insert into Colonias (iD_CiudadF, nombre_Colonia) values ( 1, 'Cumbres');
insert into Colonias (iD_CiudadF, nombre_Colonia) values ( 2, 'Avenue 3');
insert into Colonias (iD_CiudadF, nombre_Colonia) values ( 7, 'YorkNew');
insert into Colonias (iD_CiudadF, nombre_Colonia) values ( 8, 'Downtown');

insert into Secciones(nombre_Seccion,color) values ('Entretenimiento',1);
insert into Secciones(nombre_Seccion,color) values ('Torneo',2);

select * from Noticias

insert into Noticias (paisF,ciudadF,coloniaF,fecha_Hora_Acontecimiento,autor,titulo_Noticia,descripcion_Noticia,texto_Noticia,palabra_Clave,seccion_Noticia,estatus_Noticia)
values (2,1,1,'2021-01-04T17:16:40',3,'test tituloSQL','test descripcionSQL','test texto SQL','test claveSQL',2,1);