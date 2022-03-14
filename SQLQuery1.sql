create table tblClaims(
Policy_Number bigint Primary key not null,
SA_ID_Number bigint not null,
Cellphone_Number varchar(10) not null,
Account_Number varchar(30),
Deceased_SA_ID bigint not null,
Deceased_First_Name varchar(30) not null,
Deceaseed_Last_Name varchar(30) not null,
Dearth_Course varchar(50) not null,
)