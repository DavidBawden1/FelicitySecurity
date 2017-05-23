use FelicityLive

create Table AdminTable
(
AdminID int NOT NULL, 
AdminName varchar(MAX), 
AdminEmail varchar(MAX), 
AdminPinCode varchar(MAX)

PRIMARY KEY(AdminID)

)

create table MemberTable
(
MemID int NOT NULL, 
MemFirstname varchar(MAX), 
MemLastname varchar(MAX), 
MemPhonenumber varchar(MAX),
MemDOB Date, 
MemPostcode varchar(MAX), 
MemStatus Bit, 
MemRegDate Date DEFAULT(Getdate()), 
AdminID int not null

PRIMARY KEY(MemID), 
FOREIGN KEY(AdminID) REFERENCES AdminTable(AdminID)
)

create table FacesTable
(
	FaceID int NOT NULL, 
	MemFace0 image, 
	MemFace1 image, 
	MemFace2 image, 
	MemFace3 image, 
	MemFace4 image, 
	MemFace5 image, 
	MemFace6 image, 
	MemFace7 image, 
	MemFace8 image, 
	MemFace9 image, 
	MemFace10 image, 
	MemFace11 image, 
	MemFace12 image, 
	MemFace13 image, 
	MemFace14 image, 
	MemFace15 image, 
	MemFace16 image, 
	MemFace17 image, 
	MemFace18 image, 
	MemFace19 image,
	MemFace20 image,  
	IsStaff bit, 
	MemID int not null

	PRIMARY KEY(FaceID)
	FOREIGN KEY(MemID) REFERENCES MemberTable(MemID)
)

create table StaffTable
(
	StaffID int NOT NULL, 
	BadgeNo int,
	MemID int not null

	PRIMARY KEY(StaffID)
	FOREIGN KEY(MemID) REFERENCES MemberTable(MemID)
)

