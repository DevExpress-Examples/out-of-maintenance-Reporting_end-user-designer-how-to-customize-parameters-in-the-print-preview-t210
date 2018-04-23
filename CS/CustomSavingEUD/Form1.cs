using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.Design;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UserDesigner;

namespace CustomSavingEUD {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        public Form1() {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e) {
            ShowReportDesigner();
        }
        private void ShowReportDesigner() {
            XRDesignForm form = new XRDesignForm();
            XRDesignMdiController mdiController = form.DesignMdiController;
            mdiController.DesignPanelLoaded += new DesignerLoadedEventHandler(mdiController_DesignPanelLoaded);
            mdiController.OpenReport(new XtraReport1());
            form.ShowDialog();
            if (mdiController.ActiveDesignPanel != null) {
                mdiController.ActiveDesignPanel.CloseReport();
            }
        }
        private void mdiController_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e) {
            ReportTabControl tabControl = e.DesignerHost.GetService(typeof(ReportTabControl)) as ReportTabControl;
            if (tabControl == null) {
                return;
            }
            tabControl.PreviewReportCreated += tabControl_PreviewReportCreated;
        }
        private void tabControl_PreviewReportCreated(object sender, EventArgs e) {
            ReportTabControl tabControl = sender as ReportTabControl;
            if (tabControl != null && tabControl.PreviewReport != null) {
                tabControl.PreviewReport.ParametersRequestBeforeShow += PreviewReport_ParametersRequestBeforeShow;
            }
        }
        private void PreviewReport_ParametersRequestBeforeShow(object sender, ParametersRequestEventArgs e) {
            //customize parameters
            if (e.ParametersInformation.Length == 0) {
                return;
            }
            ParameterInfo info = e.ParametersInformation[0];
            if (info.Parameter.Type == typeof(Int32)) {
                info.Editor = new SpinEdit();
                info.Parameter.Value = 100;
            }
        }
    }
}
