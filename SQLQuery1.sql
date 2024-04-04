use escola
go

create table Usuario
(
id_user varchar(5) not null,
name varchar (50) not null,
name_user  varchar(10) not null,
code varchar(10) not null,
id_type varchar(15) not null,
);
select*from Usuario 
insert into Usuario values ('00001','Cris', 'admin', 'admin', 'Administrador')

create table tipo
(
id_type char(5) not null,
name_type varchar(20) not null,
)

insert into tipo values ('T0001', 'Administrador')
insert into tipo values ('T0002', 'Secretaria')
insert into tipo values ('T0003', 'Professor')

go

insert into Usuario values ('T0001','Administrador')

create procedure sp_search_users

@name varchar(50)
as select id_user,u.name,name_user,t.id_type,name_type as tipo from usuario u, tipo t
where t.id_type=u.id_type and name like @name
go

create procedure sp_Users_list

as select id_user,u.name,name_user,t.id_type,name_type as tipo from usuario u, tipo t
where t.id_type=u.id_type order by id_user
go

create proc sp_login
@user varchar(5),
@code varchar(20)
as
select name_user, code, id_type, id_user from Usuario
where name_user=@user and code=@code
go

create procedure dealing_user
@id_user varchar(5),
@name varchar (50), 
@name_user  varchar(10),
@code varchar(10) ,
@id_type varchar(15),
@action varchar (50) output

as if(@action = '1')
begin declare @new varchar(5), @newMax varchar(5)
set @newMax = (select max(id_user) from usuario
set @newMax = isnull (@newMax,'0000')
set @newMax = '0' + RIGHT(right (@newMax,4)+ 10001,4)
insert into Usuario(id_user, name, name_user, code, id_type)values (@id_user, @name, @name_user, @code, @id_type)
set @action = 'User add' + @newMax
end

else if(@action='2')
begin update Usuario set name=@name, name_user=@name_user, id_type=@id_type where id_user=@id_user
set @action='User Refresh' + @newMax
end

else if(@action='3')
begin delete from Usuario where id_user=@id_user
set @action='User Deleted' + @newMax
end
