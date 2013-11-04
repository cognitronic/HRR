namespace HRR.Web.Reporting
{
    partial class GoalMilestones
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.sqlGoalMilestones = new Telerik.Reporting.SqlDataSource();
            this.labelsGroupHeader = new Telerik.Reporting.GroupHeaderSection();
            this.labelsGroupFooter = new Telerik.Reporting.GroupFooterSection();
            this.labelsGroup = new Telerik.Reporting.Group();
            this.titleCaptionTextBox = new Telerik.Reporting.TextBox();
            this.milestonetitleCaptionTextBox = new Telerik.Reporting.TextBox();
            this.milestonedescriptionCaptionTextBox = new Telerik.Reporting.TextBox();
            this.titleGroupHeader = new Telerik.Reporting.GroupHeaderSection();
            this.titleGroupFooter = new Telerik.Reporting.GroupFooterSection();
            this.titleGroup = new Telerik.Reporting.Group();
            this.titleDataTextBox = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.milestonetitleDataTextBox = new Telerik.Reporting.TextBox();
            this.milestonedescriptionDataTextBox = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlGoalMilestones
            // 
            this.sqlGoalMilestones.ConnectionString = "HRR.Web.Properties.Settings.HRR_Performance";
            this.sqlGoalMilestones.Name = "sqlGoalMilestones";
            this.sqlGoalMilestones.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@reviewid", System.Data.DbType.Int32, "=Parameters.reviewid.Value")});
            this.sqlGoalMilestones.SelectCommand = "dbo.selectGoalMilestonesByReview";
            this.sqlGoalMilestones.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // labelsGroupHeader
            // 
            this.labelsGroupHeader.Height = new Telerik.Reporting.Drawing.Unit(0.23333333432674408D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.labelsGroupHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleCaptionTextBox,
            this.milestonetitleCaptionTextBox,
            this.milestonedescriptionCaptionTextBox});
            this.labelsGroupHeader.Name = "labelsGroupHeader";
            this.labelsGroupHeader.PrintOnEveryPage = true;
            this.labelsGroupHeader.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // labelsGroupFooter
            // 
            this.labelsGroupFooter.Height = new Telerik.Reporting.Drawing.Unit(0.22499999403953552D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.labelsGroupFooter.Name = "labelsGroupFooter";
            this.labelsGroupFooter.Style.Visible = false;
            // 
            // labelsGroup
            // 
            this.labelsGroup.GroupFooter = this.labelsGroupFooter;
            this.labelsGroup.GroupHeader = this.labelsGroupHeader;
            this.labelsGroup.Name = "labelsGroup";
            // 
            // titleCaptionTextBox
            // 
            this.titleCaptionTextBox.CanGrow = true;
            this.titleCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.01666666753590107D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.01666666753590107D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.titleCaptionTextBox.Name = "titleCaptionTextBox";
            this.titleCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.58333331346511841D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.titleCaptionTextBox.Style.Font.Bold = true;
            this.titleCaptionTextBox.Style.Font.Name = "Arial";
            this.titleCaptionTextBox.StyleName = "Caption";
            this.titleCaptionTextBox.Value = "Goal";
            // 
            // milestonetitleCaptionTextBox
            // 
            this.milestonetitleCaptionTextBox.CanGrow = true;
            this.milestonetitleCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.60000002384185791D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.01666666753590107D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.milestonetitleCaptionTextBox.Name = "milestonetitleCaptionTextBox";
            this.milestonetitleCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.7000000476837158D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.milestonetitleCaptionTextBox.Style.Font.Bold = true;
            this.milestonetitleCaptionTextBox.Style.Font.Name = "Arial";
            this.milestonetitleCaptionTextBox.StyleName = "Caption";
            this.milestonetitleCaptionTextBox.Value = "Milestone";
            // 
            // milestonedescriptionCaptionTextBox
            // 
            this.milestonedescriptionCaptionTextBox.CanGrow = true;
            this.milestonedescriptionCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.3000788688659668D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.01666666753590107D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.milestonedescriptionCaptionTextBox.Name = "milestonedescriptionCaptionTextBox";
            this.milestonedescriptionCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(3.149921178817749D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.milestonedescriptionCaptionTextBox.Style.Font.Bold = true;
            this.milestonedescriptionCaptionTextBox.Style.Font.Name = "Arial";
            this.milestonedescriptionCaptionTextBox.StyleName = "Caption";
            this.milestonedescriptionCaptionTextBox.Value = "Description";
            // 
            // titleGroupHeader
            // 
            this.titleGroupHeader.Height = new Telerik.Reporting.Drawing.Unit(0.23333333432674408D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.titleGroupHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleDataTextBox});
            this.titleGroupHeader.Name = "titleGroupHeader";
            // 
            // titleGroupFooter
            // 
            this.titleGroupFooter.Height = new Telerik.Reporting.Drawing.Unit(0.22499999403953552D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.titleGroupFooter.Name = "titleGroupFooter";
            // 
            // titleGroup
            // 
            this.titleGroup.GroupFooter = this.titleGroupFooter;
            this.titleGroup.GroupHeader = this.titleGroupHeader;
            this.titleGroup.Groupings.AddRange(new Telerik.Reporting.Data.Grouping[] {
            new Telerik.Reporting.Data.Grouping("=Fields.title")});
            this.titleGroup.Name = "titleGroup";
            // 
            // titleDataTextBox
            // 
            this.titleDataTextBox.CanGrow = true;
            this.titleDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.01666666753590107D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.01666666753590107D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.titleDataTextBox.Name = "titleDataTextBox";
            this.titleDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4.1833333969116211D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.titleDataTextBox.Style.Font.Bold = true;
            this.titleDataTextBox.Style.Font.Name = "Arial";
            this.titleDataTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12D, Telerik.Reporting.Drawing.UnitType.Point);
            this.titleDataTextBox.StyleName = "Data";
            this.titleDataTextBox.Value = "=Fields.title";
            // 
            // reportHeader
            // 
            this.reportHeader.Height = new Telerik.Reporting.Drawing.Unit(0.40000000596046448D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox});
            this.reportHeader.Name = "reportHeader";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.4666666984558105D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.40000000596046448D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.titleTextBox.Style.Font.Name = "Arial";
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "Goals & Milestones";
            // 
            // detail
            // 
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(0.23333333432674408D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.milestonetitleDataTextBox,
            this.milestonedescriptionDataTextBox});
            this.detail.Name = "detail";
            // 
            // milestonetitleDataTextBox
            // 
            this.milestonetitleDataTextBox.CanGrow = true;
            this.milestonetitleDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.10000000149011612D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.01666666753590107D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.milestonetitleDataTextBox.Name = "milestonetitleDataTextBox";
            this.milestonetitleDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(3.2000000476837158D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.21666666865348816D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.milestonetitleDataTextBox.Style.Font.Name = "Arial";
            this.milestonetitleDataTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(10D, Telerik.Reporting.Drawing.UnitType.Point);
            this.milestonetitleDataTextBox.StyleName = "Data";
            this.milestonetitleDataTextBox.Value = "=Fields.milestonetitle";
            // 
            // milestonedescriptionDataTextBox
            // 
            this.milestonedescriptionDataTextBox.CanGrow = true;
            this.milestonedescriptionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.3000788688659668D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.01666666753590107D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.milestonedescriptionDataTextBox.Name = "milestonedescriptionDataTextBox";
            this.milestonedescriptionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(3.149921178817749D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.21666666865348816D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.milestonedescriptionDataTextBox.Style.Font.Name = "Arial";
            this.milestonedescriptionDataTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(10D, Telerik.Reporting.Drawing.UnitType.Point);
            this.milestonedescriptionDataTextBox.StyleName = "Data";
            this.milestonedescriptionDataTextBox.Value = "=Fields.milestonedescription";
            // 
            // GoalMilestones
            // 
            this.DataSource = this.sqlGoalMilestones;
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.labelsGroup,
            this.titleGroup});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.labelsGroupHeader,
            this.labelsGroupFooter,
            this.titleGroupHeader,
            this.titleGroupFooter,
            this.reportHeader,
            this.detail});
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = new Telerik.Reporting.Drawing.Unit(1D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Left = new Telerik.Reporting.Drawing.Unit(1D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Right = new Telerik.Reporting.Drawing.Unit(1D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Top = new Telerik.Reporting.Drawing.Unit(1D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "reviewid";
            reportParameter1.Text = "reviewid";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule1.Style.Color = System.Drawing.Color.Black;
            styleRule1.Style.Font.Bold = true;
            styleRule1.Style.Font.Italic = false;
            styleRule1.Style.Font.Name = "Tahoma";
            styleRule1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(20D, Telerik.Reporting.Drawing.UnitType.Point);
            styleRule1.Style.Font.Strikeout = false;
            styleRule1.Style.Font.Underline = false;
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule2.Style.Color = System.Drawing.Color.Black;
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(11D, Telerik.Reporting.Drawing.UnitType.Point);
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(11D, Telerik.Reporting.Drawing.UnitType.Point);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(11D, Telerik.Reporting.Drawing.UnitType.Point);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = new Telerik.Reporting.Drawing.Unit(6.4666666984558105D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.Name = "GoalMilestones";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlGoalMilestones;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeader;
        private Telerik.Reporting.TextBox titleCaptionTextBox;
        private Telerik.Reporting.TextBox milestonetitleCaptionTextBox;
        private Telerik.Reporting.TextBox milestonedescriptionCaptionTextBox;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooter;
        private Telerik.Reporting.Group labelsGroup;
        private Telerik.Reporting.GroupHeaderSection titleGroupHeader;
        private Telerik.Reporting.TextBox titleDataTextBox;
        private Telerik.Reporting.GroupFooterSection titleGroupFooter;
        private Telerik.Reporting.Group titleGroup;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox milestonetitleDataTextBox;
        private Telerik.Reporting.TextBox milestonedescriptionDataTextBox;

    }
}