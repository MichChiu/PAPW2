create database PAPW2
use PAPW2

create table Perfiles /*#Aqui se almacenan los tipos de perfil, solo habra 3 campos de esta tabla*/
(
iD_Perfil int identity(1,1)not null primary key,
tipo_Perfil varchar(50) /*// Tipo de perfil que va a tener 1. Editor, 2. Reportero, 3. Usuario*/
);



create table Usuarios
(
iD_Usuario int identity(1,1)not null primary key,
nombre varchar(100) not null,
apellido varchar (100) not null,
pp VARBINARY (max),
correoE varchar(100) not null,
contraseña varchar(100) not null,
nombreUsuario varchar(50) not null,
telefono varchar(50) not null,
perfil int not null,/* #Tipo de perfil que va a tener 1. Editor, 2. Reportero, 3. Usuario*/
constraint const_Perfil foreign key (perfil) references Perfiles(iD_Perfil)ON DELETE CASCADE
);


create table Colores
(
iD_Color int identity(1,1) not null,
nombre_Color varchar(255),
primary key (iD_Color)
);

create table Secciones
(
iD_Seccion int identity(1,1) not null ,
nombre_Seccion varchar(100) not null,
color int not null,
pos int,
constraint const_Color foreign key (color) references Colores (iD_Color)ON DELETE CASCADE,
primary key(iD_Seccion)
);


create table Estatus /*#Solo habra 3 campos en esta tabla*/
(
iD_Estatus int identity(1,1) not null ,
nombre_Estatus varchar(100),
primary key(iD_Estatus)
);

create table Paises 
(
iD_Pais int identity(1,1) not null ,
nombre_Pais varchar(100),
primary key	(iD_Pais)
);

create table Ciudades
(
iD_Ciudad int identity(1,1) not null ,
iD_PaisF int not null,
nombre_Ciudad varchar(100),
primary key (iD_Ciudad),
constraint const_Pais foreign key (iD_PaisF) references Paises(iD_Pais)ON DELETE CASCADE
);

create table Colonias
(
iD_Colonia int identity(1,1) not null ,
iD_CiudadF int not null,
nombre_Colonia varchar(100),
primary key (iD_Colonia),
constraint const_Ciudad foreign key (iD_CiudadF) references Ciudades (iD_Ciudad)ON DELETE CASCADE
);


create table Noticias
(
iD_Noticia int identity(1,1) not null ,
paisF int not null,
ciudadF int not null,
coloniaF int not null,
fecha_Hora_Acontecimiento datetime not null,
fecha_Publicacion datetime, 
autor int not null,
titulo_Noticia varchar(100) not null,
descripcion_Noticia varchar(100) not null,
texto_Noticia varchar(1500) not null,
palabra_Clave varchar(100) not null, 
seccion_Noticia int not null,
estatus_Noticia int not null,
likes int,
visitas int,
comentarios_editor varchar(1500),
constraint const_SeccionN foreign key(seccion_Noticia) references Secciones(iD_Seccion)ON DELETE CASCADE,
constraint const_EstatusN foreign key(estatus_Noticia) references Estatus(iD_Estatus)ON DELETE CASCADE,
constraint const_PaisN foreign key(paisF) references Paises (iD_Pais)ON DELETE CASCADE,
constraint const_CiudadN foreign key(ciudadF) references Ciudades (iD_Ciudad),/**/
constraint const_ColoniaN foreign key(coloniaF) references Colonias (iD_Colonia),/**/
constraint const_AutN foreign key (autor) references Usuarios(iD_Usuario) ON DELETE CASCADE,
primary key(iD_Noticia)
);

create table LikesUsuarios /*#tabla de relacion para ver si un usuario tiene like en la noticia en la que estamos posicionados */
(
iD_NoticiaF int not null,
iD_UsuarioF int not null,
constraint const_Like_Noti foreign key(iD_NoticiaF) references Noticias(iD_Noticia)ON DELETE CASCADE,
constraint const_Like_Usu foreign key(iD_UsuarioF) references Usuarios(iD_Usuario)/**/
);

create table Comentarios
(
iD_Comentarios int identity(1,1) not null ,
texto varchar(1500) not null,
autor int not null,
que_Noticia int not null,
constraint const_QueNoti foreign key(que_Noticia) references Noticias (iD_Noticia) ON DELETE CASCADE,
constraint const_Coment_Aut foreign key(autor) references Usuarios (iD_Usuario),/**/
primary key	(iD_Comentarios)
);

create table NoticiaComentarios /*#Tabla de relacion, entre la noticia en la que estamos posicionados, los comentarios que hay en ella e informacion del usuario que comenta*/ 
(
iD_NoticiasF int not null,
iD_ComentarioF int not null,
iD_UsuarioF int not null,/* #QUITAR*/
constraint const_NotiComent_Usu foreign key(iD_UsuarioF) references Usuarios (iD_Usuario),
constraint const_NotiComent_Noti foreign key(iD_NoticiasF) references Noticias (iD_Noticia),
foreign key(iD_ComentarioF) references Comentarios (iD_Comentarios)ON DELETE CASCADE
);

create table Respuestas
(
iD_Respuesta int identity(1,1) not null ,
respuesta_Texto varchar(1500) not null,
autor int not null,
que_Comentario int not null,
constraint const_QueComent foreign key(que_Comentario) references Comentarios(iD_Comentarios)ON DELETE CASCADE,
constraint const_Coment_AutRes foreign key(autor) references Usuarios (iD_Usuario),/**/
primary key(iD_Respuesta)
);

create table Comentario_Respuestas /*#Tabla de relacion, entre Un comentario, sus respuestas y que usuario esta haciendo la respuesta */
(
iD_ComentarioF int not null,
iD_RespuestaF int not null,
iD_UsuarioF int not null,
constraint const_ComRes_Coment foreign key(iD_ComentarioF) references Comentarios (iD_Comentarios)ON DELETE CASCADE,
constraint const_ComRes_Respu foreign key(iD_RespuestaF) references Respuestas (iD_Respuesta),/**/
constraint const_ComRes_Usu foreign key(iD_UsuarioF) references Usuarios (iD_Usuario)/**/
);

create table Videos
(
iD_Video int identity(1,1) not null ,
iD_Noticia int not null,
video_URL varchar(1000),
constraint const_Vid_Noti foreign key (iD_Noticia) references Noticias (iD_Noticia)ON DELETE CASCADE,
primary key (iD_Video)
);

create table Imagenes
(
iD_Imagen int identity(1,1) not null ,
iD_Noticia int not null,
imagen_URL VARBINARY (max),
constraint const_IMG_Noti foreign key (iD_Noticia) references Noticias (iD_Noticia)ON DELETE CASCADE,
primary key (iD_Imagen)
);