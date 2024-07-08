create table NewBookP(
bid int NOT NULL identity(1,1) primary key,
bname varchar(250) not null,
baurthorname varchar(250) not null,
bpublication varchar(250) not null,
bpdate varchar(250) not null,
bprice bigint not null,
bquan bigint not null
)
bname,baurthorname,bpublication, bpdate, bprice,bquan
select * from NewBookP