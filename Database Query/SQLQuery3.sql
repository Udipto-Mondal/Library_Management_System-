select * from StudentInfo
create table StudentInfo(
stname varchar(250) not null,
stuid int not null primary key,
stdep varchar(250) not null,
stsem varchar(250) not null,
stcontact bigint not null,
stemail varchar(250) not null
)
stname,stuid,stdep,stsem,stcontact,stemail


create table IRBook(
idcount int not null identity(1,1) primary key,
studentID int not null,
st_name varchar(250) not null,
st_dep varchar(250) not null,
st_sem varchar(250) not null,
st_contact bigint not null,
st_email varchar(250) not null,
book_name varchar(1250) not null,
book_issue_date varchar(250) not null,
book_return_date varchar(250),
);

select * from IRBook
studentID,st_name,st_dep,st_sem,st_contact,st_email,book_name,book_issue_date,book_return_date