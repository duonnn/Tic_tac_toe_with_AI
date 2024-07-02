create table trangthai(
	matrangthai int primary key not null,
	tentrangthai nvarchar(10),
);

create table nut(
	manut nvarchar(10) primary key not null,
	matrangthai int not null foreign key references trangthai,
);

insert into trangthai values
	(1,'X'),
	(2,'O'),
	(3,'');

select tentrangthai from trangthai inner join nut on trangthai.matrangthai = nut.matrangthai
where manut = 'btn_1'
select * from nut