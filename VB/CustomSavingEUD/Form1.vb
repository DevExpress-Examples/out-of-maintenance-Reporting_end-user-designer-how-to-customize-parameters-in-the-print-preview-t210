Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.Design
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.XtraReports.UserDesigner

Namespace CustomSavingEUD
    Partial Public Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
            ShowReportDesigner()
        End Sub
        Private Sub ShowReportDesigner()
            Dim form As New XRDesignForm()
            Dim mdiController As XRDesignMdiController = form.DesignMdiController
            AddHandler mdiController.DesignPanelLoaded, AddressOf mdiController_DesignPanelLoaded
            mdiController.OpenReport(New XtraReport1())
            form.ShowDialog()
            If mdiController.ActiveDesignPanel IsNot Nothing Then
                mdiController.ActiveDesignPanel.CloseReport()
            End If
        End Sub
        Private Sub mdiController_DesignPanelLoaded(ByVal sender As Object, ByVal e As DesignerLoadedEventArgs)
            Dim tabControl As ReportTabControl = TryCast(e.DesignerHost.GetService(GetType(ReportTabControl)), ReportTabControl)
            If tabControl Is Nothing Then
                Return
            End If
            AddHandler tabControl.PreviewReportCreated, AddressOf tabControl_PreviewReportCreated
        End Sub
        Private Sub tabControl_PreviewReportCreated(ByVal sender As Object, ByVal e As EventArgs)
            Dim tabControl As ReportTabControl = TryCast(sender, ReportTabControl)
            If tabControl IsNot Nothing AndAlso tabControl.PreviewReport IsNot Nothing Then
                AddHandler tabControl.PreviewReport.ParametersRequestBeforeShow, AddressOf PreviewReport_ParametersRequestBeforeShow
            End If
        End Sub
        Private Sub PreviewReport_ParametersRequestBeforeShow(ByVal sender As Object, ByVal e As ParametersRequestEventArgs)
            'customize parameters
            If e.ParametersInformation.Length = 0 Then
                Return
            End If
            Dim info As ParameterInfo = e.ParametersInformation(0)
            If info.Parameter.Type Is GetType(Int32) Then
                info.Editor = New SpinEdit()
                info.Parameter.Value = 100
            End If
        End Sub
    End Class
End Namespace
