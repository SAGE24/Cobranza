create database collectiondb
use collectiondb



create table Debtor(
	DebtorCode int identity(1,1),
	Document varchar(15) not null,
	DocumentType varchar(10) not null,
	Name varchar(50) not null,
	BirthdayDate date,
	Work varchar(50),
	Salary decimal(10,2),
	CreatorUser varchar(10) not null,
	CreationDate datetime default getdate(),
	ModifierUser varchar(10),
	ModificationDate datetime,
	Status bit default 1,
	primary key (DebtorCode),
	unique (Document)
)

create table DebtorPhone(
	PhoneCode int identity(1,1),
	DebtorCode int not null,
	Phone varchar(15) not null,
	PhoneType varchar(20),
	Supplier varchar(20),
	CreatorUser varchar(10) not null,
	CreationDate datetime default getdate(),
	ModifierUser varchar(10),
	ModificationDate datetime,
	status bit default 1,
	primary key (PhoneCode),
	FOREIGN KEY (DebtorCode) references debtor(DebtorCode),
	unique (DebtorCode,Phone)
)

create table DebtorAccounts(
	Code int identity(1,1) not null,
	DebtorCode int not null,
	FinancialEntityCode int not null,
	OperationNumber varchar(30) not null,
	Totaldebt decimal(10,2),
	Capitaldebt decimal(10,2),
	Product varchar(50),
	CreatorUser varchar(10) not null,
	CreationDate datetime default getdate(),
	ModifierUser varchar(10),
	ModificationDate datetime,
	status bit default 1,
	primary key (Code),
	FOREIGN KEY (DebtorCode) references debtor(DebtorCode),
	unique (DebtorCode,FinancialEntityCode,OperationNumber)
)

create table ManagementResult(
	ResultCode int identity(1,1) not null,
	Code varchar(10) not null,
	Description varchar(50),
	Value int not null,
	CreatorUser varchar(10) not null,
	CreationDate datetime default getdate(),
	ModifierUser varchar(10),
	ModificationDate datetime,
	status bit default 1,
	primary key (ResultCode),
	unique (Code,Description)
)

create table Negotiations(
    Code int identity(1,1) not null,
	FinancialEntityCode int not null,
	DebtorCode int not null,
	PhoneCode int not null,
	CallDate date not null,
	ResultCode int not null,
	Observation varchar(100) not null,
	PaymentType int null,
	PaymentDate date null,
	PaymentAmount decimal(10,2) null,
	CreatorUser varchar(10) not null,
	CreationDate datetime default getdate(),
	ModifierUser varchar(10),
	ModificationDate datetime,
	status bit default 1,
	primary key (Code),
	foreign key (DebtorCode) references debtor(DebtorCode),
	foreign key (PhoneCode) references debtorPhone(PhoneCode),
	foreign key (ResultCode) references managementResult(ResultCode)
)

select * from [dbo].[Debtor]
select * from [dbo].[DebtorPhone]
select * from [dbo].[DebtorAccounts]
select * from [dbo].[ManagementResult]
select * from [dbo].[Negotiations]