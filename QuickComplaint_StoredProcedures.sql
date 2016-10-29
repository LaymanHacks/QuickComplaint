
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Complaint_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Complaint_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId]
FROM [Complaint]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Complaint_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId]
FROM [Complaint]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Complaint_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Complaint_Update]
(
@ComplaintTypeId Int, 
@Description NVarChar(2000), 
@LocationDetails NVarChar(2000), 
@ReportingPartyId Int, 
@Id Int
  )

  AS
   SET NOCOUNT ON;
UPDATE [Complaint] SET [ComplaintTypeId]=@ComplaintTypeId
     , [Description]=@Description
     , [LocationDetails]=@LocationDetails
     , [ReportingPartyId]=@ReportingPartyId
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Complaint_Update]
(
@ComplaintTypeId Int, 
@Description NVarChar(2000), 
@LocationDetails NVarChar(2000), 
@ReportingPartyId Int, 
@Id Int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [Complaint] SET [ComplaintTypeId]=@ComplaintTypeId
     , [Description]=@Description
     , [LocationDetails]=@LocationDetails
     , [ReportingPartyId]=@ReportingPartyId
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Complaint_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Complaint_Delete]
(
@Id Int
  )

  AS
   SET NOCOUNT ON;
DELETE 
FROM [Complaint]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Complaint_Delete]
(
@Id Int
  )

  AS
   SET NOCOUNT ON;
   DELETE 
FROM [Complaint]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Complaint_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Complaint_Insert]
(
@ComplaintTypeId Int, 
@Description NVarChar(2000), 
@LocationDetails NVarChar(2000), 
@ReportingPartyId Int
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [Complaint] ([ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId]) VALUES (@ComplaintTypeId, @Description, @LocationDetails, @ReportingPartyId);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Complaint_Insert]
(
@ComplaintTypeId Int, 
@Description NVarChar(2000), 
@LocationDetails NVarChar(2000), 
@ReportingPartyId Int
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [Complaint] ([ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId]) VALUES (@ComplaintTypeId, @Description, @LocationDetails, @ReportingPartyId);SELECT SCOPE_IDENTITY();'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Complaint_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Complaint_GetDataPageable]
(
@sortExpression VarChar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId] FROM (
    SELECT [Id], [ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Complaint) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Complaint_GetDataPageable]
(
@sortExpression VarChar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId] FROM (
    SELECT [Id], [ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Complaint) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Complaint_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Complaint_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Complaint'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Complaint_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Complaint'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Complaint_GetDataById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Complaint_GetDataById]
(
@Id Int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId]
FROM [Complaint]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Complaint_GetDataById]
(
@Id Int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId]
FROM [Complaint]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Complaint_GetDataByComplaintTypeId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Complaint_GetDataByComplaintTypeId]
(
@ComplaintTypeId Int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId]
FROM [Complaint]
WHERE [ComplaintTypeId]=@ComplaintTypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Complaint_GetDataByComplaintTypeId]
(
@ComplaintTypeId Int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId]
FROM [Complaint]
WHERE [ComplaintTypeId]=@ComplaintTypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Complaint_GetDataByComplaintTypeIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Complaint_GetDataByComplaintTypeIdPageable]
(
@ComplaintTypeId Int, 
@sortExpression VarChar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000), 
 @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ComplaintTypeId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId] FROM (
		   SELECT [Id], [ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Complaint WHERE ComplaintTypeId = @INComplaintTypeId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INComplaintTypeId Int,@inStartRowIndex Int,@inPageSize Int'', @INComplaintTypeId = @ComplaintTypeId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Complaint_GetDataByComplaintTypeIdPageable]
(
@ComplaintTypeId Int, 
@sortExpression VarChar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000), 
 @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ComplaintTypeId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId] FROM (
		   SELECT [Id], [ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Complaint WHERE ComplaintTypeId = @INComplaintTypeId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INComplaintTypeId Int,@inStartRowIndex Int,@inPageSize Int'', @INComplaintTypeId = @ComplaintTypeId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Complaint_GetDataByComplaintTypeIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Complaint_GetDataByComplaintTypeIdRowCount]
(
@ComplaintTypeId Int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Complaint
WHERE [ComplaintTypeId]=@ComplaintTypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Complaint_GetDataByComplaintTypeIdRowCount]
(
@ComplaintTypeId Int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Complaint
WHERE [ComplaintTypeId]=@ComplaintTypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Complaint_GetDataByReportingPartyId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Complaint_GetDataByReportingPartyId]
(
@ReportingPartyId Int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId]
FROM [Complaint]
WHERE [ReportingPartyId]=@ReportingPartyId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Complaint_GetDataByReportingPartyId]
(
@ReportingPartyId Int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId]
FROM [Complaint]
WHERE [ReportingPartyId]=@ReportingPartyId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Complaint_GetDataByReportingPartyIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Complaint_GetDataByReportingPartyIdPageable]
(
@ReportingPartyId Int, 
@sortExpression VarChar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000), 
 @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ReportingPartyId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId] FROM (
		   SELECT [Id], [ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Complaint WHERE ReportingPartyId = @INReportingPartyId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INReportingPartyId Int,@inStartRowIndex Int,@inPageSize Int'', @INReportingPartyId = @ReportingPartyId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Complaint_GetDataByReportingPartyIdPageable]
(
@ReportingPartyId Int, 
@sortExpression VarChar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000), 
 @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ReportingPartyId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId] FROM (
		   SELECT [Id], [ComplaintTypeId], [Description], [LocationDetails], [ReportingPartyId],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Complaint WHERE ReportingPartyId = @INReportingPartyId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INReportingPartyId Int,@inStartRowIndex Int,@inPageSize Int'', @INReportingPartyId = @ReportingPartyId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Complaint_GetDataByReportingPartyIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Complaint_GetDataByReportingPartyIdRowCount]
(
@ReportingPartyId Int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Complaint
WHERE [ReportingPartyId]=@ReportingPartyId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Complaint_GetDataByReportingPartyIdRowCount]
(
@ReportingPartyId Int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Complaint
WHERE [ReportingPartyId]=@ReportingPartyId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ComplaintType_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ComplaintType_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [Name]
FROM [ComplaintType]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ComplaintType_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name]
FROM [ComplaintType]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ComplaintType_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ComplaintType_Update]
(
@Name NVarChar(160), 
@Id Int
  )

  AS
   SET NOCOUNT ON;
UPDATE [ComplaintType] SET [Name]=@Name
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ComplaintType_Update]
(
@Name NVarChar(160), 
@Id Int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [ComplaintType] SET [Name]=@Name
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ComplaintType_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ComplaintType_Delete]
(
@Id Int
  )

  AS
   SET NOCOUNT ON;
DELETE 
FROM [ComplaintType]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ComplaintType_Delete]
(
@Id Int
  )

  AS
   SET NOCOUNT ON;
   DELETE 
FROM [ComplaintType]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ComplaintType_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ComplaintType_Insert]
(
@Name NVarChar(160)
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [ComplaintType] ([Name]) VALUES (@Name);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ComplaintType_Insert]
(
@Name NVarChar(160)
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [ComplaintType] ([Name]) VALUES (@Name);SELECT SCOPE_IDENTITY();'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ComplaintType_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ComplaintType_GetDataPageable]
(
@sortExpression VarChar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [Name] FROM (
    SELECT [Id], [Name],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM ComplaintType) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ComplaintType_GetDataPageable]
(
@sortExpression VarChar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [Name] FROM (
    SELECT [Id], [Name],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM ComplaintType) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ComplaintType_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ComplaintType_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM ComplaintType'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ComplaintType_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM ComplaintType'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ComplaintType_GetDataById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ComplaintType_GetDataById]
(
@Id Int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [Name]
FROM [ComplaintType]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ComplaintType_GetDataById]
(
@Id Int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name]
FROM [ComplaintType]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhoneType_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PhoneType_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [Name]
FROM [PhoneType]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[PhoneType_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name]
FROM [PhoneType]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhoneType_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PhoneType_Update]
(
@Name NVarChar(100), 
@Id Int
  )

  AS
   SET NOCOUNT ON;
UPDATE [PhoneType] SET [Name]=@Name
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[PhoneType_Update]
(
@Name NVarChar(100), 
@Id Int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [PhoneType] SET [Name]=@Name
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhoneType_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PhoneType_Delete]
(
@Id Int
  )

  AS
   SET NOCOUNT ON;
DELETE 
FROM [PhoneType]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[PhoneType_Delete]
(
@Id Int
  )

  AS
   SET NOCOUNT ON;
   DELETE 
FROM [PhoneType]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhoneType_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PhoneType_Insert]
(
@Name NVarChar(100)
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [PhoneType] ([Name]) VALUES (@Name);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[PhoneType_Insert]
(
@Name NVarChar(100)
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [PhoneType] ([Name]) VALUES (@Name);SELECT SCOPE_IDENTITY();'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhoneType_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PhoneType_GetDataPageable]
(
@sortExpression VarChar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [Name] FROM (
    SELECT [Id], [Name],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM PhoneType) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[PhoneType_GetDataPageable]
(
@sortExpression VarChar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [Name] FROM (
    SELECT [Id], [Name],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM PhoneType) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhoneType_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PhoneType_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM PhoneType'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[PhoneType_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM PhoneType'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhoneType_GetDataById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PhoneType_GetDataById]
(
@Id Int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [Name]
FROM [PhoneType]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[PhoneType_GetDataById]
(
@Id Int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name]
FROM [PhoneType]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportingParty_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ReportingParty_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId]
FROM [ReportingParty]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ReportingParty_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId]
FROM [ReportingParty]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportingParty_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ReportingParty_Update]
(
@Name NVarChar(100), 
@Email NVarChar(256), 
@Phone1 NVarChar(100), 
@Phone1TypeId Int, 
@Phone2 NVarChar(100), 
@Phone2TypeId Int, 
@Id Int
  )

  AS
   SET NOCOUNT ON;
UPDATE [ReportingParty] SET [Name]=@Name
     , [Email]=@Email
     , [Phone1]=@Phone1
     , [Phone1TypeId]=@Phone1TypeId
     , [Phone2]=@Phone2
     , [Phone2TypeId]=@Phone2TypeId
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ReportingParty_Update]
(
@Name NVarChar(100), 
@Email NVarChar(256), 
@Phone1 NVarChar(100), 
@Phone1TypeId Int, 
@Phone2 NVarChar(100), 
@Phone2TypeId Int, 
@Id Int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [ReportingParty] SET [Name]=@Name
     , [Email]=@Email
     , [Phone1]=@Phone1
     , [Phone1TypeId]=@Phone1TypeId
     , [Phone2]=@Phone2
     , [Phone2TypeId]=@Phone2TypeId
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportingParty_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ReportingParty_Delete]
(
@Id Int
  )

  AS
   SET NOCOUNT ON;
DELETE 
FROM [ReportingParty]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ReportingParty_Delete]
(
@Id Int
  )

  AS
   SET NOCOUNT ON;
   DELETE 
FROM [ReportingParty]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportingParty_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ReportingParty_Insert]
(
@Name NVarChar(100), 
@Email NVarChar(256), 
@Phone1 NVarChar(100), 
@Phone1TypeId Int, 
@Phone2 NVarChar(100), 
@Phone2TypeId Int
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [ReportingParty] ([Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId]) VALUES (@Name, @Email, @Phone1, @Phone1TypeId, @Phone2, @Phone2TypeId);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ReportingParty_Insert]
(
@Name NVarChar(100), 
@Email NVarChar(256), 
@Phone1 NVarChar(100), 
@Phone1TypeId Int, 
@Phone2 NVarChar(100), 
@Phone2TypeId Int
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [ReportingParty] ([Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId]) VALUES (@Name, @Email, @Phone1, @Phone1TypeId, @Phone2, @Phone2TypeId);SELECT SCOPE_IDENTITY();'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportingParty_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ReportingParty_GetDataPageable]
(
@sortExpression VarChar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId] FROM (
    SELECT [Id], [Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM ReportingParty) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ReportingParty_GetDataPageable]
(
@sortExpression VarChar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId] FROM (
    SELECT [Id], [Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM ReportingParty) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportingParty_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ReportingParty_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM ReportingParty'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ReportingParty_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM ReportingParty'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportingParty_GetDataById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ReportingParty_GetDataById]
(
@Id Int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId]
FROM [ReportingParty]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ReportingParty_GetDataById]
(
@Id Int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId]
FROM [ReportingParty]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportingParty_GetDataByPhone1TypeId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ReportingParty_GetDataByPhone1TypeId]
(
@Phone1TypeId Int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId]
FROM [ReportingParty]
WHERE [Phone1TypeId]=@Phone1TypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ReportingParty_GetDataByPhone1TypeId]
(
@Phone1TypeId Int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId]
FROM [ReportingParty]
WHERE [Phone1TypeId]=@Phone1TypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportingParty_GetDataByPhone1TypeIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ReportingParty_GetDataByPhone1TypeIdPageable]
(
@Phone1TypeId Int, 
@sortExpression VarChar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000), 
 @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Phone1TypeId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId] FROM (
		   SELECT [Id], [Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM ReportingParty WHERE Phone1TypeId = @INPhone1TypeId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INPhone1TypeId Int,@inStartRowIndex Int,@inPageSize Int'', @INPhone1TypeId = @Phone1TypeId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ReportingParty_GetDataByPhone1TypeIdPageable]
(
@Phone1TypeId Int, 
@sortExpression VarChar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000), 
 @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Phone1TypeId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId] FROM (
		   SELECT [Id], [Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM ReportingParty WHERE Phone1TypeId = @INPhone1TypeId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INPhone1TypeId Int,@inStartRowIndex Int,@inPageSize Int'', @INPhone1TypeId = @Phone1TypeId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportingParty_GetDataByPhone1TypeIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ReportingParty_GetDataByPhone1TypeIdRowCount]
(
@Phone1TypeId Int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM ReportingParty
WHERE [Phone1TypeId]=@Phone1TypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ReportingParty_GetDataByPhone1TypeIdRowCount]
(
@Phone1TypeId Int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM ReportingParty
WHERE [Phone1TypeId]=@Phone1TypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportingParty_GetDataByPhone2TypeId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ReportingParty_GetDataByPhone2TypeId]
(
@Phone2TypeId Int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId]
FROM [ReportingParty]
WHERE [Phone2TypeId]=@Phone2TypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ReportingParty_GetDataByPhone2TypeId]
(
@Phone2TypeId Int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId]
FROM [ReportingParty]
WHERE [Phone2TypeId]=@Phone2TypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportingParty_GetDataByPhone2TypeIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ReportingParty_GetDataByPhone2TypeIdPageable]
(
@Phone2TypeId Int, 
@sortExpression VarChar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000), 
 @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Phone2TypeId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId] FROM (
		   SELECT [Id], [Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM ReportingParty WHERE Phone2TypeId = @INPhone2TypeId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INPhone2TypeId Int,@inStartRowIndex Int,@inPageSize Int'', @INPhone2TypeId = @Phone2TypeId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ReportingParty_GetDataByPhone2TypeIdPageable]
(
@Phone2TypeId Int, 
@sortExpression VarChar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000), 
 @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Phone2TypeId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId] FROM (
		   SELECT [Id], [Name], [Email], [Phone1], [Phone1TypeId], [Phone2], [Phone2TypeId],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM ReportingParty WHERE Phone2TypeId = @INPhone2TypeId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INPhone2TypeId Int,@inStartRowIndex Int,@inPageSize Int'', @INPhone2TypeId = @Phone2TypeId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportingParty_GetDataByPhone2TypeIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ReportingParty_GetDataByPhone2TypeIdRowCount]
(
@Phone2TypeId Int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM ReportingParty
WHERE [Phone2TypeId]=@Phone2TypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ReportingParty_GetDataByPhone2TypeIdRowCount]
(
@Phone2TypeId Int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM ReportingParty
WHERE [Phone2TypeId]=@Phone2TypeId'
  END
GO
