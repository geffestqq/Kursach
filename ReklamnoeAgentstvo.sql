set ansi_padding on
go
set ansi_nulls on
go
set quoted_identifier on
go

create database [Reklamnoe_Agentstvo]
go

use [Reklamnoe_Agentstvo]
go

create table [dbo].[Doljnost]
(
	[ID_Doljnost] [int] not null identity(1,1),
	[Name_Doljnost] [varchar] (30) not null,
	[Zarplata] [decimal] (32,2) not null,
	constraint [PK_Doljnost] primary key clustered ([ID_Doljnost] ASC) on [PRIMARY],
    constraint [UQ_Name_Doljnost] unique ([Name_Doljnost]),
	constraint [CH_Name_Doljnost] check ([Name_Doljnost] like '%[�-�]%'),
	constraint [CH_Zarplata] check ([Zarplata] >0),
)
go
 insert into [dbo].[Doljnost] ([Name_Doljnost],[Zarplata])
values ('��������','30000'),
	   ('�����������','60000'),
	   ('�������������','80000'),
	   ('��������','60000'),
	   ('�������������','60000'),
	   ('��������','70000'),
	   ('�������','80000'),
	   ('������','90000'),
	   ('�������','10000'),
	   ('����������','20000')
go



create table [dbo].[Role]
(
	[ID_Role] [int] not null identity (1,1),
	[Name_Role] [varchar] (30) not null,
	[Dostup] [int] not null,
	[Dostup_Role] [Varchar] (60) not null,

	constraint [PK_Role] primary key clustered ([ID_Role] ASC) on [PRIMARY],
	constraint [UQ_Name_Role] unique ([Name_Role]),
	constraint [CH_Name_Role] check ([Name_Role] like '%[�-�]%'),
	constraint [CH_Dostup_Role] check ([Dostup_Role] like '%[�-�]%'),

)

insert into [dbo].[Role] ([Name_Role],[Dostup],[Dostup_Role])
values ('�������������','1','��� ���� ����������, � ��� �������'),
	   ('�����������','2','���� �����, ���� ����������, ��������������� �������'),
	   ('��������','3','���� ������ ������, ���� ��������, ��������������� �������'),
	   ('��������','3','���� �����, ������� ����, ��������������� �������'),
	   ('��������','3','���� �����, ������� ����, ��������������� �������'),
	   ('�������','3','���� ������, ������� ����, ��������������� �������'),
	   ('�������������','3','���� �����, ������� ����, ��������������� �������'),
	   ('�������������','3','���� �����������, ������� ����, ��������������� �������'),
	   ('������','3','���� ���������, ������� ����, ��������������� �������'),
	   ('�������','3','���� ����, ������� ����, ��������������� �������')
	  
go

create table [dbo].[Authorization]
(
	[ID_Authorization] [int] not null identity (1,1),
	[Login] [varchar] (30) not null,
	[Password] [varchar] (30) not null,
	[Role_ID] [int] not null,
	
	constraint [UQ_Login] unique ([Login]),
	constraint [CH_Login1] check ([Login] like '%[A-Z]%' OR [Login] like '%[�-�]%' OR [Login] like '%[0-9]%'),
	constraint [CH_Password1] check ([Password] like '%[A-Z]%' OR [Password] like '%[�-�]%' OR [Password] like '%[0-9]%'),
	constraint [CH_Password] check (len([Password]) >= 8),
	constraint [CH_Login] check (len([Login]) >= 4),
	constraint [ID_Authorization] primary key clustered ([ID_Authorization] ASC) on [PRIMARY],
	constraint [FK_Role_ID] foreign key ([Role_ID])
	references [dbo].[Role] ([id_Role]),
	
)

insert into [dbo].[Authorization] ([Login],[Password],[Role_ID])
values ('Geffest','abcvbnml1','1'),
	   ('Aegis','abcvbnml','2'),
	   ('Techis','abcvbnml','3'),
	   ('Necroman','abcvbnml','4'),
	   ('Abbadon','abcvbnml','5'),
	   ('Snaiper','abcvbnml','6'),
	   ('Queen','abcvbnml','7'),
	   ('Necronamicon','abcvbnml','8'),
	   ('Daedalus','abcvbnml','9'),
	   ('Bloodthorn','abcvbnml','10')

go

create table [dbo].[Sotrudnik]
(
	[ID_Sotrudnik] [int] not null identity (1,1),
	[Name_Sotrudnik] [varchar] (30) not null,
	[Fam_Sotrudnik]  [varchar] (30) not null,
	[Otch_Sotrudnik] [varchar] (30) not null,
	[Date_Of_Rojdeniya] [varchar] (10) not null,
	[Seriya_Pass] [varchar] (4) not null,
	[Number_Pass][varchar] (6) not null,
	[Status] [varchar] (30) not null,
	[Date_Of_Priem][varchar] (10) not null,
	[Doljnost_ID] [int] not null,
	[Authorization_ID] [int] not null,

	constraint [UQ_Number_Pass] unique ([Number_Pass]),
	constraint [CH_Name_Sotrudnik] check ([Name_Sotrudnik] like '%[�-�]%'),
	constraint [CH_Fam_Sotrudnik] check ([Fam_Sotrudnik] like '%[�-�]%'),
	constraint [CH_Otch_Sotrudnik] check ([Otch_Sotrudnik] like '%[�-�]%'),
	constraint [CH_Status] check ([Status] like '%[�-�]%'),
	constraint [CH_Date_Of_Rojdeniya] check ([Date_Of_Rojdeniya] like '%[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9][0-9]%'),
	constraint [CH_Date_Of_Priem] check ([Date_Of_Priem] like '%[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9][0-9]%'),
	constraint [CH_Date_Of_Priem1] check ([Date_Of_Priem]<=GETDATE()),
	constraint [CH_Date_Of_Rojdeniya1] check ([Date_Of_Rojdeniya]<GETDATE()),
	constraint [PK_Sotrudnik] primary key clustered ([ID_Sotrudnik] ASC) on [PRIMARY],
	constraint [FK_Doljnost_ID] foreign key ([Doljnost_ID])
	references [dbo].[Doljnost] ([id_Doljnost]),

	constraint [FK_Authorization_ID] foreign key ([Authorization_ID])
	references [dbo].[Authorization] ([ID_Authorization]),

)
 insert into [dbo].[Sotrudnik] ([Name_Sotrudnik],[Fam_Sotrudnik],[Otch_Sotrudnik],[Date_Of_Rojdeniya],[Seriya_Pass],[Number_Pass],[Status],[Date_Of_Priem],[Doljnost_ID], [Authorization_ID])
values ('���������','�����','����������','18.01.2001','4455','123455','����','18.02.2012','1','1'),
	   ('�����','����������','����������','18.01.2002','3465','355456','������','12.02.2012','2','2'),
	   ('�������','�����������','����������','19.12.2003','7465','755556','������','18.02.2017','3','3'),
	   ('�������','��������','���������','01.05.2003','7467','753417','����','13.02.2013','4','4'),	   
	   ('���������','������������','��������','21.07.2003','7567','353457','����','01.02.2015','5','5'),
	   ('������','��������','�������������','12.03.2008','9567','151457','����','08.02.2013','6','6'),
	   ('������','���������','����������','13.02.2004','6567','513457','������','02.02.2017','7','7'),
	   ('������','�����������','�������������','18.03.2002','7567','353447','������','04.06.2013','8','8'),
	   ('���������','������','���������','12.07.2008','6567','754458','����','08.02.2019','9','9'),
	   ('����','�������','����������','12.03.2004','9567','958417','������','08.02.2017','10','10')
go

create table [dbo].[Sobesedovanie]
(
	[ID_Sobesedovanie] [int] not null identity (1,1),
	[Date_Sobesedovanie] [varchar] (10) not null,
	[Result_Sobesedovanie] [varchar] (30) not null,

	constraint [PK_Sobesedovanie] primary key clustered ([ID_Sobesedovanie] ASC) on [PRIMARY],
	constraint [CH_Date_Sobesedovanie] check ([Date_Sobesedovanie] like '%[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9][0-9]%'),
	constraint [CH_Date_Sobesedovanie1] check ([Date_Sobesedovanie]<=GETDATE()),
	constraint [CH_Result_Sobesedovanie] check ([Result_Sobesedovanie] like '%[�-�]%'),
)
go

insert into [dbo].[Sobesedovanie] ([Date_Sobesedovanie],[Result_Sobesedovanie])
values ('18.01.2001','�������� �� ������'),
	   ('19.03.2005','�������� �� ������'),
	   ('10.11.2004','�������� �� ������'),
	   ('18.02.2005','�������� �� ������'),
	   ('17.05.2007','����� � �������� �� ������'),
	   ('11.08.2008','����� � �������� �� ������'),
	   ('12.03.2009','����� � �������� �� ������'),
	   ('13.07.2001','����� � �������� �� ������'),
	   ('17.02.2001','����� � �������� �� ������'),
	   ('18.01.2005','�������� �� ������')

go

create table [dbo].[Sotrudnik_Sobesedovanie]
(
	[ID_Sotrudnik_Sobesedovanie] [int] not null identity (1,1),
	[Sobesedovanie_ID] [int] not null,
	[Sotrudnik_Sobesedovanie_ID] [int] not null,

	constraint [PK_Sotrudnik_Sobesedovanie] primary key clustered ([ID_Sotrudnik_Sobesedovanie] ASC) on [PRIMARY],

	constraint [FK_Sobesedovanie_ID] foreign key ([Sobesedovanie_ID])
	references [dbo].[Sobesedovanie] ([id_Sobesedovanie]),

	constraint [FK_Sotrudnik_Sobesedovanie_ID] foreign key ([Sotrudnik_Sobesedovanie_ID])
	references [dbo].[Sotrudnik] ([ID_Sotrudnik]),
)
go

insert into [dbo].[Sotrudnik_Sobesedovanie] ([Sobesedovanie_ID],[Sotrudnik_Sobesedovanie_ID])
values ('1','1'),
	   ('2','2'),
	   ('3','3'),
	   ('4','4'),
	   ('5','5'),
	   ('6','6'),
	   ('7','7'),
	   ('8','8'),
	   ('9','9'),
	   ('10','10')
go

create table [dbo].[Klient]
(
	[ID_Klient] [int] not null identity (1,1),
	[Name_Klient] [varchar] (30) not null,
	[Fam_Klient] [varchar] (30) not null,
	[Otch_Klient] [varchar] (30) not null,
	[Phone_Number_K] [varchar] (16) not null,
	[Email_Klient] [varchar] (30) not null,
	[Authorization_Klient_ID] [int] not null,

	constraint [PK_Klient] primary key clustered ([ID_Klient] ASC) on [PRIMARY],
	constraint [UQ_Phone_Number_K] unique ([Phone_Number_K]),
	constraint [UQ_Email_Klient] unique ([Email_Klient]),
	constraint [CH_Name_Klient] check ([Name_Klient] like '%[�-�]%'),
	constraint [CH_Fam_Klient] check ([Fam_Klient] like '%[�-�]%'),
	constraint [CH_Otch_Klient] check ([Otch_Klient] like '%[�-�]%'),
	constraint [CH_Email_Klient] check ([Email_Klient] like '%[A-Z]%' AND [Email_Klient] like '%[@]%'  AND [Email_Klient] like '%[.]%'),
	constraint [CH_Phone_Number_K] check ([Phone_Number_K] like '%+7([0-9][0-9][0-9])[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]%'),

	constraint [FK_Authorization_Klient_ID] foreign key ([Authorization_Klient_ID])
	references [dbo].[Authorization] ([ID_Authorization]),
)
go

insert into [dbo].[Klient] ([Name_Klient],[Fam_Klient],[Otch_Klient],[Phone_Number_K],[Email_Klient],[Authorization_Klient_ID])
values ('�����','�������','���������','+7(977)322-22-22','gad22d@gmail.com','1'),
	   ('����','������','��������','+7(247)322-22-22','had2d@yandex.ru','2'),
	   ('����','�������','��������','+7(577)622-62-22','Yad22d@rambler.com','3'),
	   ('�����','�������','���������','+7(765)622-32-21','uad@mpt.ru','4'),
	   ('�������','��������','����������','+7(113)512-42-52','add@gmail.com','5'),
	   ('�������','�������','�����������','+7(550)124-52-32','Pochta@mail.ru','6'),
	   ('������','�������','���������','+7(091)122-12-21','gred@gmail.com','7'),
	   ('������','�������','���������','+7(831)321-29-92','grin@gmail.com','8'),
	   ('�����','������','��������','+7(708)322-32-29','Yellow@gmail.com','9'),
	   ('�������','��������','�������','+7(903)362-72-92','Purple@gmail.com','10')

go

create table [dbo].[Status]
(
	[ID_Status] [int] not null identity (1,1),
	[Name_Status] [varchar] (30) not null,

	constraint [PK_Status] primary key clustered ([ID_Status] ASC) on [PRIMARY],
	constraint [UQ_Name_Status] unique ([Name_Status]),
	constraint [CH_Name_Status] check ([Name_Status] like '%[�-�]%'),
)
go

insert into [dbo].[Status] ([Name_Status])
values ('��������'),
	   ('���������'),
	   ('� ������'),
	   ('��������'),
	   ('������� �������������'),
	   ('������� ��������'),
	   ('������'),
	   ('�� ��������'),
	   ('�� �����������'),
	   ('�������� �� ���������')
go

create table [dbo].[Zakaz]
(
	[ID_Zakaz] [int] identity (1,1),
	[Tema_Zakaz] [Varchar] (30) not null,
	[Date_Of_Prinat] [varchar] (10) not null,
	[Date_Of_End] [varchar] (10) not null,
	[Utverjdenie] [varchar] (30) not null,
	[Status_ID] [int] not null,
	[Sotrudnik_Zakaz_ID] [int] not null,
	[Klient_Zakaz_ID] [int] not null,

	constraint [PK_Zakaz] primary key clustered ([ID_Zakaz] ASC) on [PRIMARY],
	constraint [FK_Status_ID] foreign key ([Status_ID])
	references [dbo].[Status] ([ID_Status]),
	constraint [FK_Sotrudnik_Zakaz_ID] foreign key ([Sotrudnik_Zakaz_ID])
	references [dbo].[Sotrudnik] ([ID_Sotrudnik]),
	constraint [FK_Klient_Zakaz_ID] foreign key ([Klient_Zakaz_ID])
	references [dbo].[Klient] ([ID_Klient]),
	constraint [CH_Tema_Zakaz] check ([Tema_Zakaz] like '%[�-�]%'),
	constraint [CH_Date_Of_Prinat] check ([Date_Of_Prinat] like '%[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9][0-9]%'),
	constraint [CH_Date_Of_Prinat1] check ([Date_Of_Prinat]<=GETDATE()),
	constraint [CH_Date_Of_End] check ([Date_Of_End] like '%[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9][0-9]%'),
	constraint [CH_Date_Of_End1] check ([Date_Of_End]>=GETDATE()),
	constraint [CH_Utverjdenie] check ([Utverjdenie] like '%[�-�]%'),

)
go

insert into [dbo].[Zakaz] ([Tema_Zakaz],[Date_Of_Prinat],[Date_Of_End],[Utverjdenie],[Status_ID],[Sotrudnik_Zakaz_ID],[Klient_Zakaz_ID])
values ('������� ���','18.01.2001','20.02.2022','���������','1','1','1'),
	   ('������� ���','18.01.2001','10.03.2023','�� ���������','2','2','2'),
	   ('������� ����������','18.01.2001','17.01.2024','�� ���������','3','3','3'),
	   ('������� ����','18.01.2001','22.03.2025','���������','4','4','4'),
	   ('������� �����','18.01.2001','13.02.2021','�� ���������','5','5','5'),
	   ('������� �����������','18.01.2001','14.12.2021','���������','6','6','6'),
	   ('������� ��� �������','18.01.2001','08.07.2023','���������','7','7','7'),
	   ('������� �����������','18.01.2001','13.08.2022','�� ���������','8','8','8'),
	   ('������� ���������','18.01.2001','18.09.2021','���������','9','9','9'),
	   ('������� �����','18.01.2001','10.10.2023','�� ���������','10','10','10')
go

create table [dbo].[Reklama]
(
	[ID_Reklama] [int] not null identity (1,1),
	[Status] [varchar] (30) not null,
	[Date_Of_Begin] [varchar] (10) not null,
	[Zakaz_Reklama_ID] [int] not null,
	[Sotrudnik_Reklama_ID] [int] not null,

	constraint [PK_Reklama] primary key clustered ([ID_Reklama] ASC) on [PRIMARY],
	constraint [FK_Zakaz_Reklama_ID] foreign key ([Zakaz_Reklama_ID])
	references [dbo].[Zakaz] ([ID_Zakaz]),
	constraint [FK_Sotrudnik_Reklama_ID] foreign key ([Sotrudnik_Reklama_ID])
	references [dbo].[Sotrudnik] ([ID_Sotrudnik]),
	constraint [CH_Status_Reklama] check ([Status] like '%[�-�]%'),
	constraint [CH_Date_Of_Begin] check ([Date_Of_Begin]<=GETDATE()),
	constraint [CH_Date_Of_Begin1] check ([Date_Of_Begin] like '%[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9][0-9]%'),

)
go

insert into [dbo].[Reklama] ([Status],[Date_Of_Begin],[Zakaz_Reklama_ID],[Sotrudnik_Reklama_ID])
values ('�������� � ����������','11.01.2017','1','1'),
	   ('�������� ������������ ������','18.01.2001','2','2'),
	   ('�������� ������','13.11.2019','3','3'),
	   ('�������� �������','11.12.2018','4','4'),
	   ('�������� �� ���������','08.05.2017','5','5'),
	   ('�������� ������','09.03.2018','6','6'),
	   ('�������� � ����������','12.11.2011','7','7'),
	   ('�������� ������������ ������','14.11.2013','8','8'),
	   ('�������� �������','19.03.2019','9','9'),
	   ('�������� � ����������','19.07.2016','10','10')
go

create table [dbo].[Price_List]
(
	[ID_Price_List] [int] not null identity (1,1),
	[Name_Price_List] [varchar] (30) not null,
	[Srok_Price_List] [varchar] (30) not null,
	[Cena_Price_List] [int] not null,

	constraint [PK_Price_List] primary key clustered ([ID_Price_List] ASC) on [PRIMARY],
	constraint [CH_Name_Price_List] check ([Name_Price_List] like '%[�-�]%'),
	constraint [CH_Srok_Price_List] check ([Srok_Price_List] like '%[�-�]%' and [Srok_Price_List] like '%[0-9]%'),

)
go
insert into [dbo].[Price_List] ([Name_Price_List],[Srok_Price_List],[Cena_Price_List])
values ('������� �������','7 ������','10000'),
	   ('������� �������','1 ������','100000'),
	   ('����������� �������','4 ������','30000'),
	   ('����������� �������','5 ������','60000'),
	   ('������� �������','8 ������','70000'),
	   ('����������� �������','1 ������','20000'),
	   ('������� �������','3 ������','90000'),
	   ('���������� �������','8 ������','70000'),
	   ('������ �������','22 ������','80000'),
	   ('������ �������','17 ������','10000')

go

create table [dbo].[Zakaz_Price]
(
	[ID_Zakaz_Price] [int] not null identity (1,1),
	[Zakaz_ID] [int] not null,
	[Price_List_ID] [int] not null,
	
	constraint [PK_Zakaz_Price] primary key clustered ([ID_Zakaz_Price] ASC) on [PRIMARY],
	constraint [FK_Zakaz_ID] foreign key ([Zakaz_ID])
	references [dbo].[Zakaz] ([ID_Zakaz]),
	constraint [FK_Price_List_ID] foreign key ([Price_List_ID])
	references [dbo].[Price_List] ([ID_Price_List]),
)
go

insert into [dbo].[Zakaz_Price] ([Zakaz_ID],[Price_List_ID])
values ('1','1'),
	   ('2','2'),
	   ('3','3'),
	   ('4','4'),
	   ('5','5'),
	   ('6','6'),
	   ('7','7'),
	   ('8','8'),
	   ('9','9'),
	   ('10','10')
go

create table [dbo].[Chek]
(
	[ID_Chek] [int] not null identity (1,1),
	[Date_Of_Pechat] [varchar] (10) not null,
	[Type_Of_Oplata] [varchar] (30) not null,
	[Zakaz_Price_ID] [int] not null,
	[Sotrudnik_Chek_ID] [int] not null,
	[Klient_Chek_ID] [int] not null,

	constraint [PK_Chek] primary key clustered ([ID_Chek] ASC) on [PRIMARY],
	constraint [FK_Zakaz_Price_ID] foreign key ([Zakaz_Price_ID])
	references [dbo].[Zakaz_Price] ([ID_Zakaz_Price]),
	constraint [FK_Sotrudnik_Chek_ID] foreign key ([Sotrudnik_Chek_ID])
	references [dbo].[Sotrudnik] ([ID_Sotrudnik]),
	constraint [FK_Klient_Chek_ID] foreign key ([Klient_Chek_ID])
	references [dbo].[Klient] ([ID_Klient]),
	constraint [CH_Type_Of_Oplata] check ([Type_Of_Oplata] like '%[�-�]%'),
	constraint [CH_Date_Of_Pechat] check ([Date_Of_Pechat]<=GETDATE()),
	constraint [CH_Date_Of_Pechat1] check ([Date_Of_Pechat] like '%[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9][0-9]%'),

)
go

insert into [dbo].[Chek] ([Date_Of_Pechat],[Type_Of_Oplata],[Zakaz_Price_ID],[Sotrudnik_Chek_ID],[Klient_Chek_ID])
values ('18.01.2009','��������','1','1','1'),
	   ('08.08.2007','�����','2','2','2'),
	   ('21.09.2004','��������','3','3','3'),
	   ('17.02.2004','�����','4','4','4'),
	   ('10.06.2002','�����','5','5','5'),
	   ('11.04.2006','��������','6','6','6'),
	   ('03.02.2008','��������','7','7','7'),
	   ('25.01.2009','�����','8','8','8'),
	   ('03.09.2002','�����','9','9','9'),
	   ('19.03.2000','��������','10','10','10')
go

--PROCEDURE

--Table DOLJNOST
create procedure [dbo].[Doljnost_insert]
 @Name_Doljnost[varchar] (30), @Zarplata  [int]
as
	insert into [dbo].[Doljnost] ([Name_Doljnost],[Zarplata])
	values (@Name_Doljnost,@Zarplata)
go

create procedure [dbo].[Doljnost_updated]
 @ID_Doljnost [int], @Name_Doljnost[varchar] (30), @Zarplata  [int]
 as 
	update [dbo].[Doljnost] set
	[Name_Doljnost] = @Name_Doljnost,
	[Zarplata] = @Zarplata
	where
		[ID_Doljnost] = @ID_Doljnost

go

create procedure [dbo].[Doljnost_delete]
@ID_Doljnost [int]
as
	delete from [dbo].[Doljnost]
	where
		[ID_Doljnost] = @ID_Doljnost
go

--Table ROLE

create procedure [dbo].[Role_insert]
 @Name_Role[varchar] (30), @Dostup [int], @Dostup_Role [varchar] (60)
as
	insert into [dbo].[Role] ([Name_Role],[Dostup],[Dostup_Role])
	values (@Name_Role,@Dostup,@Dostup_Role)
go

create procedure [dbo].[Role_updated]
 @ID_Role [int],  @Name_Role[varchar] (30), @Dostup [int], @Dostup_Role [varchar] (60)
 as 
	update [dbo].[Role] set
	[Name_Role] = @Name_Role,
	[Dostup] = @Dostup,
	[Dostup_Role] = @Dostup_Role
	where
		[ID_Role] = @ID_Role

go

create procedure [dbo].[Role_delete]
@ID_Role [int]
as
	delete from [dbo].[Role]
	where
		[ID_Role] = @ID_Role
go

--Table AUTHORIZATION

create procedure [dbo].[Authorization_insert]
 @Login [varchar] (30), @Password [varchar] (30), @Role_ID [int]
as
	insert into [dbo].[Authorization] ([Login],[Password],[Role_ID])
	values (@Login,@Password,@Role_ID)
go

create procedure [dbo].[Authorization_updated]
 @ID_Authorization [int], @Login [varchar] (30), @Password [varchar] (30), @Role_ID [int]
 as 
	update [dbo].[Authorization] set
	[Login] = @Login,
	[Password] = @Password,
	[Role_ID] = @Role_ID
	where
		[ID_Authorization] = @ID_Authorization

go







--Password
create procedure [dbo].[Password_updated]
 @ID_Authorization [int], @Password [varchar] (30)
 as 
	update [dbo].[Authorization] set
	[Password] = @Password
	where
		[ID_Authorization] = @ID_Authorization

go

create procedure [dbo].[Authorization_delete]
@ID_Authorization [int]
as
	delete from [dbo].[Authorization]
	where
		[ID_Authorization] = @ID_Authorization
go

--Table SOTDUNIK
create procedure [dbo].[Sotrudnik_insert]
 @Name_Sotrudnik [varchar] (30), @Fam_Sotrudnik [varchar] (30), @Otch_Sotrudnik [varchar] (30), @Date_Of_Rojdeniya [varchar] (10),
 @Seriya_Pass [varchar] (4), @Number_Pass [varchar] (30), @Status [varchar] (30), @Date_Of_Priem [varchar] (10), @Doljnost_ID [int],@Authorization_ID [int]
as
	insert into [dbo].[Sotrudnik] ([Name_Sotrudnik],[Fam_Sotrudnik],[Otch_Sotrudnik],[Date_Of_Rojdeniya],[Seriya_Pass],[Number_Pass],[Status],[Date_Of_Priem],[Doljnost_ID],[Authorization_ID])
	values (@Name_Sotrudnik,@Fam_Sotrudnik,@Otch_Sotrudnik,@Date_Of_Rojdeniya,@Seriya_Pass,@Number_Pass,@Status,@Date_Of_Priem,@Doljnost_ID,@Authorization_ID)
go

create procedure [dbo].[Sotrudnik_updated]
 @ID_Sotrudnik [int],@Name_Sotrudnik [varchar] (30), @Fam_Sotrudnik [varchar] (30), @Otch_Sotrudnik [varchar] (30), @Date_Of_Rojdeniya [varchar] (10),
 @Seriya_Pass [varchar] (4), @Number_Pass [varchar] (30), @Status [varchar] (30), @Date_Of_Priem [varchar] (10), @Doljnost_ID [int],@Authorization_ID [int]
 as 
	update [dbo].[Sotrudnik] set
	[Name_Sotrudnik] = @Name_Sotrudnik,
	[Fam_Sotrudnik] = @Fam_Sotrudnik,
	[Otch_Sotrudnik] = @Otch_Sotrudnik,
	[Date_Of_Rojdeniya] = @Date_Of_Rojdeniya,
	[Seriya_Pass] = @Seriya_Pass,
	[Number_Pass] = @Number_Pass,
	[Status] = @Status,
	[Date_Of_Priem] = @Date_Of_Priem,
	[Doljnost_ID] = @Doljnost_ID,
	[Authorization_ID] = @Authorization_ID
	where
		[ID_Sotrudnik] = @ID_Sotrudnik

go

create procedure [dbo].[Sotrudnik_delete]
@ID_Sotrudnik [int]
as
	delete from [dbo].[Sotrudnik]
	where
		[ID_Sotrudnik] = @ID_Sotrudnik
go

--Table SOBESEDOVANIE
create procedure [dbo].[Sobesedovanie_insert]
 @Date_Sobesedovanie[varchar] (10), @Result_Sobesedovanie [varchar] (30)
as
	insert into [dbo].[Sobesedovanie] ([Date_Sobesedovanie],[Result_Sobesedovanie])
	values (@Date_Sobesedovanie,@Result_Sobesedovanie)
go

create procedure [dbo].[Sobesedovanie_updated]
 @ID_Sobesedovanie [int],  @Date_Sobesedovanie[varchar] (10), @Result_Sobesedovanie [varchar] (30)
 as 
	update [dbo].[Sobesedovanie] set
	[Date_Sobesedovanie] = @Date_Sobesedovanie,
	[Result_Sobesedovanie] = @Result_Sobesedovanie
	where
		[ID_Sobesedovanie] = @ID_Sobesedovanie

go

create procedure [dbo].[Sobesedovanie_delete]
@ID_Sobesedovanie [int]
as
	delete from [dbo].[Sobesedovanie]
	where
		[ID_Sobesedovanie] = @ID_Sobesedovanie
go

--Table KLIENT
create procedure [dbo].[Klient_insert]
 @Name_Klient[varchar] (30) , @Fam_Klient [varchar] (30), @Otch_Klient [varchar] (30), @Phone_Number_K [varchar] (16),@Email_Klient [varchar] (30) ,@Authorization_Klient_ID [int]
as
	insert into [dbo].[Klient] ([Name_Klient],[Fam_Klient],[Otch_Klient],[Phone_Number_K],[Email_Klient],[Authorization_Klient_ID])
	values (@Name_Klient,@Fam_Klient,@Otch_Klient,@Phone_Number_K,@Email_Klient,@Authorization_Klient_ID)
go

create procedure [dbo].[Klient_updated]
 @ID_Klient [int], @Name_Klient[varchar] (30) , @Fam_Klient [varchar] (30), @Otch_Klient [varchar] (30), @Phone_Number_K [varchar] (16),@Email_Klient [varchar] (30) ,@Authorization_Klient_ID [int]
 as 
	update [dbo].[Klient] set
	[Name_Klient] = @Name_Klient,
	[Fam_Klient] = @Fam_Klient,
	[Otch_Klient] = @Otch_Klient,
	[Phone_Number_K] = @Phone_Number_K,
	[Email_Klient] = @Email_Klient,
	[Authorization_Klient_ID] = @Authorization_Klient_ID
	where
		[ID_Klient] = @ID_Klient

go

create procedure [dbo].[Klient_delete]
@ID_Klient [int]
as
	delete from [dbo].[Klient]
	where
		[ID_Klient] = @ID_Klient
go

--Table STATUS
create procedure [dbo].[Status_insert]
 @Name_Status[varchar] (30) 
as
	insert into [dbo].[Status] ([Name_Status])
	values (@Name_Status)
go

create procedure [dbo].[Status_updated]
 @ID_Status [int],   @Name_Status[varchar] (30) 
 as 
	update [dbo].[Status] set
	[Name_Status] = @Name_Status
	where
		[ID_Status] = @ID_Status

go

create procedure [dbo].[Status_delete]
@ID_Status [int]
as
	delete from [dbo].[Status]
	where
		[ID_Status] = @ID_Status
go

--Table ZAKAZ
create procedure [dbo].[Zakaz_insert]
 @Tema_Zakaz[varchar] (30) , @Date_Of_Prinat [varchar] (10), @Date_Of_End [varchar] (10), @Utverjdenie [varchar] (16),@Status_ID [int], @Sotrudnik_Zakaz_ID [int], @Klient_Zakaz_ID[int]
as
	insert into [dbo].[Zakaz] ([Tema_Zakaz],[Date_Of_Prinat],[Date_Of_End],[Utverjdenie],[Status_ID],[Sotrudnik_Zakaz_ID],[Klient_Zakaz_ID])
	values (@Tema_Zakaz,@Date_Of_Prinat,@Date_Of_End,@Utverjdenie,@Status_ID,@Sotrudnik_Zakaz_ID,@Klient_Zakaz_ID)
go

create procedure [dbo].[Zakaz_updated]
 @ID_Zakaz [int], @Tema_Zakaz[varchar] (30) , @Date_Of_Prinat [varchar] (10), @Date_Of_End [varchar] (10), @Utverjdenie [varchar] (16),@Status_ID [int], @Sotrudnik_Zakaz_ID [int], @Klient_Zakaz_ID[int]
 as 
	update [dbo].[Zakaz] set
	[Tema_Zakaz] = @Tema_Zakaz,
	[Date_Of_Prinat] = @Date_Of_Prinat,
	[Date_Of_End] = @Date_Of_End,
	[Utverjdenie] = @Utverjdenie,
	[Status_ID] = @Status_ID,
	[Sotrudnik_Zakaz_ID] = @Sotrudnik_Zakaz_ID,
	[Klient_Zakaz_ID] = @Klient_Zakaz_ID
	where
		[ID_Zakaz] = @ID_Zakaz

go

create procedure [dbo].[Zakaz_delete]
@ID_Zakaz [int]
as
	delete from [dbo].[Zakaz]
	where
		[ID_Zakaz] = @ID_Zakaz
go

--Table REKLAMA
create procedure [dbo].[Reklama_insert]
 @Status[varchar] (30) , @Date_Of_Begin [varchar] (10), @Zakaz_Reklama_ID [int], @Sotrudnik_Reklama_ID [int]
as
	insert into [dbo].[Reklama] ([Status],[Date_Of_Begin],[Zakaz_Reklama_ID],[Sotrudnik_Reklama_ID])
	values (@Status,@Date_Of_Begin,@Zakaz_Reklama_ID,@Sotrudnik_Reklama_ID)
go

create procedure [dbo].[Reklama_updated]
 @ID_Reklama [int], @Status[varchar] (30) , @Date_Of_Begin [varchar] (10), @Zakaz_Reklama_ID [int], @Sotrudnik_Reklama_ID [int]
 as 
	update [dbo].[Reklama] set
	[Status] = @Status,
	[Date_Of_Begin] = @Date_Of_Begin,
	[Zakaz_Reklama_ID] = @Zakaz_Reklama_ID,
	[Sotrudnik_Reklama_ID] = @Sotrudnik_Reklama_ID
	where
		[ID_Reklama] = @ID_Reklama

go

create procedure [dbo].[Reklama_delete]
@ID_Reklama [int]
as
	delete from [dbo].[Reklama]
	where
		[ID_Reklama] = @ID_Reklama
go

--Table PRICE_LIST
create procedure [dbo].[Price_List_insert]
 @Name_Price_List [varchar] (30), @Srok_Price_List [varchar] (30), @Cena_Price_List [int]
as
	insert into [dbo].[Price_List] ([Name_Price_List],[Srok_Price_List],[Cena_Price_List])
	values (@Name_Price_List,@Srok_Price_List,@Cena_Price_List)
go

create procedure [dbo].[Price_List_updated]
 @ID_Price_List [int], @Name_Price_List [varchar] (30), @Srok_Price_List [varchar] (30), @Cena_Price_List [int]
 as 
	update [dbo].[Price_List] set
	[Name_Price_List] = @Name_Price_List,
	[Srok_Price_List] = @Srok_Price_List,
	[Cena_Price_List] = @Cena_Price_List
	where
		[ID_Price_List] = @ID_Price_List

go

create procedure [dbo].[Price_List_delete]
@ID_Price_List [int]
as
	delete from [dbo].[Price_List]
	where
		[ID_Price_List] = @ID_Price_List
go

--Table Chek
create procedure [dbo].[Chek_insert]
 @Date_Of_Pechat[varchar] (10) , @Type_Of_Oplata [varchar] (30), @Zakaz_Price_ID [int], @Sotrudnik_Chek_ID [int],@Klient_Chek_ID [int]
as
	insert into [dbo].[Chek] ([Date_Of_Pechat],[Type_Of_Oplata],[Zakaz_Price_ID],[Sotrudnik_Chek_ID],[Klient_Chek_ID])
	values (@Date_Of_Pechat,@Type_Of_Oplata,@Zakaz_Price_ID,@Sotrudnik_Chek_ID,@Klient_Chek_ID)
go

create procedure [dbo].[Chek_updated]
 @ID_Chek [int],@Date_Of_Pechat[varchar] (10) , @Type_Of_Oplata [varchar] (30), @Zakaz_Price_ID [int], @Sotrudnik_Chek_ID [int],@Klient_Chek_ID [int]
 as 
	update [dbo].[Chek] set
	[Date_Of_Pechat] = @Date_Of_Pechat,
	[Type_Of_Oplata] = @Type_Of_Oplata,
	[Zakaz_Price_ID] = @Zakaz_Price_ID,
	[Sotrudnik_Chek_ID] = @Sotrudnik_Chek_ID,
	[Klient_Chek_ID] = @Klient_Chek_ID
	where
		[ID_Chek] = @ID_Chek

go

create procedure [dbo].[Chek_delete]
@ID_Chek [int]
as
	delete from [dbo].[Chek]
	where
		[ID_Chek] = @ID_Chek
go
--VIEW
create view [dbo].[KlientSotr]
("��� ����������","������� ����������","�������� ����������","���� ������")
as
	select [Name_Sotrudnik] , [Fam_Sotrudnik] ,[Otch_Sotrudnik] ,  [Tema_Zakaz] 
	from [dbo].[Sotrudnik] inner join [dbo].[Zakaz] on [dbo].[Sotrudnik].[ID_Sotrudnik] = [dbo].[Zakaz].[Status_ID]
	
go



create view [dbo].[DoljnostRole]
("�������� ���������","��������� ����")
as
	select [Name_Doljnost] , [Dostup_Role] 
	from [dbo].[Doljnost] inner join [dbo].[Role] on [dbo].[Doljnost].[ID_Doljnost] = [dbo].[Role].[ID_Role]
	
go

create view [dbo].[ZakazPrice]
("���� ������","����","��� �������","������ �������","�������� �������")
as
	select [Tema_Zakaz] , [Cena_Price_List] , [Name_Klient] , [Fam_Klient] ,[Otch_Klient] 
	from [dbo].[Zakaz] inner join [dbo].[Price_List] on [dbo].[Zakaz].[ID_Zakaz] = [dbo].[Price_List].[ID_Price_List] inner join [dbo].[Klient] on [dbo].[Zakaz].[Klient_Zakaz_ID] = [dbo].[Klient].[ID_Klient]
	
go

--select * from [dbo].[ZakazPrice]

create view [dbo].[KlientZakaz]
("���� ������","��� �������","������ �������","�������� �������")
as
	select [Tema_Zakaz] , [Name_Klient] , [Fam_Klient] ,[Otch_Klient] 
	from [dbo].[Zakaz] inner join [dbo].[Klient] on [dbo].[Zakaz].[ID_Zakaz] = [dbo].[Klient].[ID_Klient]
	
go


---�����������

--������� "�������"
create table [dbo].[History] 
(
    [ID_History] [int] not null identity(1,1),
	[ProductId] [int] not null,
    [Operation] [varchar] (400) not null,
    [CreateAt] DATETIME NOT NULL DEFAULT GETDATE(),
)
go 

--������� ���������� ������ �����������
create TRIGGER Authorization_Insert_Trigger
ON [dbo].[Authorization]
AFTER INSERT
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Authorization, '����������� ������������ ' +' '+'�����' + ' '+ [Login] + ' ' +'������'+' '+ [Password]
FROM INSERTED
go

--������� ���������� �����������
CREATE TRIGGER Authorization_update_Trigger
ON [dbo].[Authorization]
AFTER update
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Authorization, '��������� ������: ����������� ' +' '+'�����' + ' '+ [Login] + ' ' +'������'+' '+ [Password]
FROM INSERTED
go


--������� �������� �����������
create trigger Authorization_delete_Trigger
on [dbo].[Authorization]
after delete
as
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Authorization, '������� ������: ����������� '  +' '+'�����' + ' '+ [Login] + ' ' +'������'+' '+ [Password]
FROM deleted
go




--������� ���������� ������ ���������
create TRIGGER Doljnost_Insert_Trigger
ON [dbo].[Doljnost]
AFTER INSERT
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Doljnost, '���������� ��������� ' +' '+'��������' + ' '+ [Name_Doljnost] + ' ' +'��������'+' '+ Convert([varchar] (max),[Zarplata])
FROM INSERTED
go

--������� ���������� ���������
CREATE TRIGGER Doljnost_update_Trigger
ON [dbo].[Doljnost]
AFTER update
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Doljnost, '��������� ������: ��������� ' +' '+'��������' + ' '+ [Name_Doljnost] + ' ' +'��������'+' '+ Convert([varchar] (max),[Zarplata])
FROM INSERTED
go


--������� �������� ���������
create trigger Doljnost_delete_Trigger
on [dbo].[Doljnost]
after delete
as
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Doljnost, '������� ������: ��������� '  +' '+'��������' + ' '+ [Name_Doljnost] + ' ' +'��������'+' '+ Convert([varchar] (max),[Zarplata])
FROM deleted
go


--������� ���������� ������ ����� ����
create TRIGGER Price_List_Insert_Trigger
ON [dbo].[Price_List]
AFTER INSERT
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Price_List, '�������� ����� ����' +' '+'��������' + ' '+ [Name_Price_List] + ' ' +'����'+' '+ [Srok_Price_List]+' '+'����'+' ' +Convert([varchar] (max),[Cena_Price_List])
FROM INSERTED
go

--������� ���������� ����� ����
create TRIGGER Price_List_update_Trigger
ON [dbo].[Price_List]
AFTER update
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Price_List, '��������� ������: ����� ���� ' +' '+'��������' + ' '+ [Name_Price_List] + ' ' +'����'+' '+ [Srok_Price_List]+' '+'����'+' ' +Convert([varchar] (max),[Cena_Price_List])
FROM INSERTED
go


--������� �������� ����� ����
create trigger Price_List_delete_Trigger
on [dbo].[Price_List]
after delete
as
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Price_List, '������� ������: ����� ���� '  +' '+'��������' + ' '+ [Name_Price_List] + ' ' +'����'+' '+ [Srok_Price_List]+' '+'����'+' ' + Convert([varchar] (max),[Cena_Price_List])
FROM deleted
go



--������� ���������� ������ �������
create TRIGGER Reklama_Insert_Trigger
ON [dbo].[Reklama]
AFTER INSERT
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Reklama, '��������� �������' +' '+'������' + ' '+ [Status] + ' ' +'���� ������'+' '+ [Date_Of_Begin]+' '+'�����'+' ' +Convert([varchar] (max),[Zakaz_Reklama_ID])+' '+'���������'+' ' +Convert([varchar] (max),[Sotrudnik_Reklama_ID])
FROM INSERTED
go

--������� ���������� �������
create TRIGGER Reklama_update_Trigger
ON [dbo].[Reklama]
AFTER update
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Reklama, '��������� ������: ������� '+' '+'������' + ' '+ [Status] + ' ' +'���� ������'+' '+ [Date_Of_Begin]+' '+'�����'+' ' +Convert([varchar] (max),[Zakaz_Reklama_ID])+' '+'���������'+' ' +Convert([varchar] (max),[Sotrudnik_Reklama_ID])
FROM INSERTED
go


--������� �������� �������
create trigger Reklama_delete_Trigger
on [dbo].[Reklama]
after delete
as
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Reklama, '������� ������: ������� ' +' '+'������' + ' '+ [Status] + ' ' +'���� ������'+' '+ [Date_Of_Begin]+' '+'�����'+' ' +Convert([varchar] (max),[Zakaz_Reklama_ID])+' '+'���������'+' ' +Convert([varchar] (max),[Sotrudnik_Reklama_ID])
FROM deleted
go



--������� ���������� ������ ����
create TRIGGER Role_Insert_Trigger
ON [dbo].[Role]
AFTER INSERT
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Role, '��������� ����' +' '+'��������' + ' '+ [Name_Role] + ' ' +'������'+' '+ Convert([varchar] (max),[Dostup])+' '+'������'+' ' +[Dostup_Role]
FROM INSERTED
go

--������� ���������� ����
create TRIGGER Role_update_Trigger
ON [dbo].[Role]
AFTER update
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Role, '��������� ������: ���� ' +' '+'��������' + ' '+ [Name_Role] + ' ' +'������'+' '+ Convert([varchar] (max),[Dostup])+' '+'������'+' ' +[Dostup_Role]
FROM INSERTED
go


--������� �������� ����
create trigger Role_delete_Trigger
on [dbo].[Role]
after delete
as
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Role, '������� ������: ���� '  +' '+'��������' + ' '+ [Name_Role] + ' ' +'������'+' '+ Convert([varchar] (max),[Dostup])+' '+'������'+' ' +[Dostup_Role]
FROM deleted
go


--������� ���������� ������ ���������
create  TRIGGER Sotrudnik_Insert_Trigger
ON [dbo].[Sotrudnik]
AFTER INSERT
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Sotrudnik, '�������� ���������' +' '+'���' + ' '+ [Name_Sotrudnik] + ' ' + [Fam_Sotrudnik]+ ' '+[Otch_Sotrudnik]+' '+'���� ��������'+' ' + [Date_Of_Rojdeniya] + ' ' +
'����� ��������' + ' ' + [Seriya_Pass] + ' '+'����� ��������' + ' ' + [Number_Pass]+ ' ' + '������'+' '+ [Status] + ' '+'���� ������'+' '+[Date_Of_Priem]+ ' '+ '���������'+ ' ' +
Convert([varchar](max),[Doljnost_ID]) + ' ' +'�����������'+ ' ' +Convert([varchar](max),[Authorization_ID])
FROM INSERTED
go

--������� ���������� ���������
create  TRIGGER Sotrudnik_update_Trigger
ON [dbo].[Sotrudnik]
AFTER update
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Sotrudnik, '��������� ������: ��������� '+' '+'���' + ' '+ [Name_Sotrudnik] + ' ' + [Fam_Sotrudnik]+ ' '+[Otch_Sotrudnik]+' '+'���� ��������'+' ' + [Date_Of_Rojdeniya] + ' ' +
'����� ��������' + ' ' + [Seriya_Pass] + ' '+'����� ��������' + ' ' + [Number_Pass]+ ' ' + '������'+' '+ [Status] + ' '+'���� ������'+' '+[Date_Of_Priem]+ ' '+ '���������'+ ' ' +
Convert([varchar](max),[Doljnost_ID]) + ' ' +'�����������'+ ' ' +Convert([varchar](max),[Authorization_ID])
FROM INSERTED
go


--������� �������� ���������
create trigger Sotrudnik_delete_Trigger
on [dbo].[Sotrudnik]
after delete
as
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Sotrudnik, '������� ������: ���������' +' '+'���' + ' '+ [Name_Sotrudnik] + ' ' + [Fam_Sotrudnik]+ ' '+[Otch_Sotrudnik]+' '+'���� ��������'+' ' + [Date_Of_Rojdeniya] + ' ' +
'����� ��������' + ' ' + [Seriya_Pass] + ' '+'����� ��������' + ' ' + [Number_Pass]+ ' ' + '������'+' '+ [Status] + ' '+'���� ������'+' '+[Date_Of_Priem]+ ' '+ '���������'+ ' ' +
Convert([varchar](max),[Doljnost_ID]) + ' ' +'�����������'+ ' ' +Convert([varchar](max),[Authorization_ID])
FROM deleted
go


--������� ���������� ������ ������
create TRIGGER Klient_Insert_Trigger
ON [dbo].[Klient]
AFTER INSERT
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Klient, '�������� ������' +' '+'���' + ' '+ [Name_Klient] + ' ' +[Fam_Klient]+' '+[Otch_Klient]+' '+'����� ��������'+[Phone_Number_K]+' ' +
'�����'+' '+[Email_Klient]+' '+'�����'+' ' + convert([varchar](max),[Authorization_Klient_ID])
FROM INSERTED
go

--������� ���������� ������
create TRIGGER Klient_update_Trigger
ON [dbo].[Klient]
AFTER update
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Klient, '��������� ������: ������ ' +' '+'���' + ' '+ [Name_Klient] + ' ' +[Fam_Klient]+' '+[Otch_Klient]+' '+'����� ��������'+[Phone_Number_K]+' ' +
'�����'+' '+[Email_Klient]+' '+'�����'+' ' + convert([varchar](max),[Authorization_Klient_ID])
FROM INSERTED
go


--������� �������� ������
create trigger Klient_delete_Trigger
on [dbo].[Klient]
after delete
as
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Klient, '������� ������: ������ '  +' '+'���' + ' '+ [Name_Klient] + ' ' +[Fam_Klient]+' '+[Otch_Klient]+' '+'����� ��������'+[Phone_Number_K]+' ' +
'�����'+' '+[Email_Klient]+' '+'�����'+' ' + convert([varchar](max),[Authorization_Klient_ID])
FROM deleted
go


--������� ���������� ������ �����
create TRIGGER Zakaz_Insert_Trigger
ON [dbo].[Zakaz]
AFTER INSERT
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Zakaz, '�������� �����' +' '+'���� ������' + ' '+ [Tema_Zakaz] + ' ' +'���� ��������' + ' '+ [Date_Of_Prinat] + ' '  +'���� ���������' + ' '+ [Date_Of_End] + ' ' +
'�����������' + ' '+ [Utverjdenie] + ' ' +'������' + ' '+ Convert([varchar](max),[Status_ID]) + ' ' +'���������'+' '+Convert([varchar](max),[Sotrudnik_Zakaz_ID])+' ' +
'������' + ' '+Convert([varchar](max),[Klient_Zakaz_ID])
FROM INSERTED
go

--������� ���������� �����
create TRIGGER Zakaz_update_Trigger
ON [dbo].[Zakaz]
AFTER update
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Zakaz, '��������� ������: ����� '  +' '+'���� ������' + ' '+ [Tema_Zakaz] + ' ' +'���� ��������' + ' '+ [Date_Of_Prinat] + ' '  +'���� ���������' + ' '+ [Date_Of_End] + ' ' +
'�����������' + ' '+ [Utverjdenie] + ' ' +'������' + ' '+ Convert([varchar](max),[Status_ID]) + ' ' +'���������'+' '+Convert([varchar](max),[Sotrudnik_Zakaz_ID])+' ' +
'������' + ' '+Convert([varchar](max),[Klient_Zakaz_ID])
FROM INSERTED
go


--������� �������� �����
create trigger Zakaz_delete_Trigger
on [dbo].[Zakaz]
after delete
as
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Zakaz, '������� ������: ����� '  +' '+'���� ������' + ' '+ [Tema_Zakaz] + ' ' +'���� ��������' + ' '+ [Date_Of_Prinat] + ' '  +'���� ���������' + ' '+ [Date_Of_End] + ' ' +
'�����������' + ' '+ [Utverjdenie] + ' ' +'������' + ' '+ Convert([varchar](max),[Status_ID]) + ' ' +'���������'+' '+Convert([varchar](max),[Sotrudnik_Zakaz_ID])+' ' +
'������' + ' '+Convert([varchar](max),[Klient_Zakaz_ID])
FROM deleted
go

CREATE FUNCTION OkladChas()

returns[int]
with execute as caller
as 
begin
declare @Oklad[int]
declare @[int] = (select @Oklad,[Zarplata]/22.5/8 from [dbo].[Doljnost])
return(@)
end
go 

create function [dbo].[Sotrudnik] (@Login [varchar] (16), @Password [varchar] (16))
returns [int]
with execute as caller 
as 
begin
	declare @ID_Record [int] = (select [ID_Authorization] from [dbo].[Authorization] where [Login] = @Login and [Password] = @Password)
	if @ID_Record is null
		begin
			set @ID_Record = 0
		end
	return(@ID_record)
end
go