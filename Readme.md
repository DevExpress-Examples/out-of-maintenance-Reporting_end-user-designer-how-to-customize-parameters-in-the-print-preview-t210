<!-- default file list -->
*Files to look at*:

* **[Form1.cs](./CS/CustomSavingEUD/Form1.cs) (VB: [Form1.vb](./VB/CustomSavingEUD/Form1.vb))**
* [Program.cs](./CS/CustomSavingEUD/Program.cs) (VB: [Program.vb](./VB/CustomSavingEUD/Program.vb))
* [XtraReport1.cs](./CS/CustomSavingEUD/XtraReport1.cs) (VB: [XtraReport1.vb](./VB/CustomSavingEUD/XtraReport1.vb))
<!-- default file list end -->
# End-User Designer - How to customize parameters in the Print Preview


This example demonstrates how to customize parameters displayed in the Print Preview of the End-User Designer. <br />The main idea is to use the <a href="https://documentation.devexpress.com/#XtraReports/DevExpressXtraReportsUserDesignerXRDesignMdiController_DesignPanelLoadedtopic">XRDesignMdiController.DesignPanelLoaded</a> event handler. In this event handler, subscribe to the ReportTabControl.PreviewReportCreated event where you can get a report instance by using the ReportTabControl.PreviewReport object. Use it to subscribe to the <a href="https://documentation.devexpress.com/#XtraReports/DevExpressXtraReportsUIXtraReport_ParametersRequestBeforeShowtopic">XtraReport.ParametersRequestBeforeShow</a> event. <br /><br />For more details, see <a href="https://www.devexpress.com/Support/Center/p/T210793">End-User Designer - How to customize parameters in the Print Preview</a>.

<br/>


