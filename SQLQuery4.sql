create table tblClaims(
Policy_Number bigint primary key not null,
SA_ID_Number bigint  not null,
Cellphone_Number varchar(10) not null,
Branch_Name varchar(30) not null,
Branch_Code varchar(30) not null,
Card_NO varchar(30) not null,
Account_NO varchar(30) not null,
Deceased_SA_ID bigint not null,
Deceased_First_Name varchar(100) not null,
Deceased_Last_Name varchar(100) not null,
Death_Course varchar(300) not null,
);