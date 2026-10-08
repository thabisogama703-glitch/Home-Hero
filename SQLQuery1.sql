ALTER TABLE dbo.ServiceProviders
ADD
    BusinessName NVARCHAR(100) NULL,
    ServiceCategory NVARCHAR(100) NULL,
    ServiceOffered NVARCHAR(200) NULL,
    YearsOfExperience INT NULL,
    ServiceArea NVARCHAR(100) NULL,
    ServiceDescription NVARCHAR(500) NULL;