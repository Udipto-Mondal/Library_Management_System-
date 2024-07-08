create table loginTable(
id int NOT NULL IDENTITY(1,1) primary key,
username varchar(150) not null,
pass varchar(150) NOT NULL
)

insert into loginTable (username,pass) values('Anonymous','1234');
insert into loginTable (username,pass) values('Udipta','1234');
insert into loginTable (username,pass) values('Aditta','1234');
insert into loginTable (username,pass) values('Shihab','1234');


select * from loginTable