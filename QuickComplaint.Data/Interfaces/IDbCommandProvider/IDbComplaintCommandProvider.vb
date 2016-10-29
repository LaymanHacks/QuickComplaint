'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Generated by Merlin Version: 1.0.0.0
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------
Imports System
Imports System.Data

Namespace QuickComplaint.Data.DbCommandProvider
    Public Interface IDbComplaintCommandProvider
        ReadOnly Property ComplaintDbConnectionHolder() As DbConnectionHolder
        ReadOnly Property DbConnectionName As String
        Function GetGetDataDbCommand() As IDbCommand
        Function GetUpdateDbCommand( ByVal complaintTypeId As Int32,  ByVal description As String,  ByVal locationDetails As String,  ByVal reportingPartyId As Int32,  ByVal id As Int32) As IDbCommand
        Function GetDeleteDbCommand( ByVal id As Int32) As IDbCommand
        Function GetInsertDbCommand( ByVal complaintTypeId As Int32,  ByVal description As String,  ByVal locationDetails As String,  ByVal reportingPartyId As Int32) As IDbCommand
        Function GetGetDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetRowCountDbCommand() As IDbCommand
        Function GetGetDataByIdDbCommand( ByVal id As Int32) As IDbCommand
        Function GetGetDataByComplaintTypeIdDbCommand( ByVal complaintTypeId As Int32) As IDbCommand
        Function GetGetDataByComplaintTypeIdPageableDbCommand( ByVal complaintTypeId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetDataByComplaintTypeIdRowCountDbCommand( ByVal complaintTypeId As Int32) As IDbCommand
        Function GetGetDataByReportingPartyIdDbCommand( ByVal reportingPartyId As Int32) As IDbCommand
        Function GetGetDataByReportingPartyIdPageableDbCommand( ByVal reportingPartyId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetDataByReportingPartyIdRowCountDbCommand( ByVal reportingPartyId As Int32) As IDbCommand

    End Interface
End Namespace
