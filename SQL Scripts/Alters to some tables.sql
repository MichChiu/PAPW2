use PAPW2 
alter table AspNetUsers
add PhoneNumberConfirmed bit NULL
add constraint Asp_const_Perfil foreign key (perfil) references Perfiles(iD_Perfil)ON DELETE CASCADE

alter table Noticias
drop constraint const_AutN
alter column autor nvarchar (450)
add constraint Asp_const_AutN foreign key (autor) references AspNetUsers(Id) ON DELETE CASCADE

alter table Comentarios
drop constraint const_Coment_Aut
alter column autor nvarchar (450)
add constraint Asp_const_Coment_Aut foreign key (autor) references AspNetUsers(Id) ON DELETE CASCADE

alter table Respuestas 
drop constraint const_Coment_AutRes
alter column autor nvarchar (450)
add constraint Asp_const_Coment_AutRes foreign key (autor) references AspNetUsers(Id) ON DELETE CASCADE


delete from noticias
select * from noticias

delete from comentarios
select * from comentarios

delete from respuestas
select * from respuestas

delete from usuarios
select * from usuarios