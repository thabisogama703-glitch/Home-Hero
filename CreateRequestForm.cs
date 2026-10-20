using HomeHero;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Home_Hero
{
    public partial class frmCreateRequest : FitForm
    {
        private const int MinDescriptionLength = 20;
        private const int MinAddressLength = 5;

        private readonly System.Windows.Forms.Timer aiTimer = new System.Windows.Forms.Timer();
        private int aiTick;
        private AiSuggestion? lastSuggestion;
        private bool applyingSuggestion;

        public frmCreateRequest()
        {
            InitializeComponent();
            ScrollWholeForm = false;   // this page scrolls its own body under a fixed header
            BuildUi();
            AcceptButton = btnSubmitRequest;
            SetupDefaults();

            aiTimer.Interval = 250;
            aiTimer.Tick += AiTimer_Tick;
            FormClosed += (s, e) => aiTimer.Dispose();

            ResetAiPanel();
            UpdateDescriptionUi();
            UpdateCompleteness();
        }

        private void SetupDefaults()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Plumbing");
            cmbCategory.Items.Add("Electrical");
            cmbCategory.Items.Add("Painting");
            cmbCategory.Items.Add("Appliance Repair");
            cmbCategory.Items.Add("General Maintenance");

            cmbTimeSlot.Items.Clear();
            cmbTimeSlot.Items.Add("08:00 AM - 10:00 AM");
            cmbTimeSlot.Items.Add("10:00 AM - 12:00 PM");
            cmbTimeSlot.Items.Add("12:00 PM - 02:00 PM");
            cmbTimeSlot.Items.Add("02:00 PM - 04:00 PM");

            cmbCategory.SelectedIndex = -1;
            cmbTimeSlot.SelectedIndex = -1;

            dtpDatePreferred.MinDate = DateTime.Today;
            dtpDatePreferred.Value = DateTime.Today;

            UpdateCost();
        }

        // ------------------------------------------------------------------
        //  SUBMIT
        // ------------------------------------------------------------------
        private void btnSubmitRequest_Click(object? sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a service category.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtProblemDescription.Text))
            {
                MessageBox.Show(
                    "Please provide a detailed description of the problem.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (txtProblemDescription.Text.Trim().Length < MinDescriptionLength)
            {
                MessageBox.Show(
                    "Please provide a more detailed description of the problem (at least " + MinDescriptionLength + " characters).",
                    "Invalid Description",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show(
                    "Please enter the property address.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (txtAddress.Text.Trim().Length < MinAddressLength)
            {
                MessageBox.Show(
                    "Please enter a valid property address.",
                    "Invalid Address",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (dtpDatePreferred.Value.Date < DateTime.Today)
            {
                MessageBox.Show(
                    "Please select a date that is today or later.",
                    "Invalid Date",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (cmbTimeSlot.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a preferred time slot.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (dtpDatePreferred.Value.Date == DateTime.Today)
            {
                string selectedTime = cmbTimeSlot.SelectedItem!.ToString()!;
                int startHour = SlotStartHour(selectedTime);

                if (startHour >= 0 && DateTime.Now.TimeOfDay >= new TimeSpan(startHour, 0, 0))
                {
                    MessageBox.Show(
                        "The selected time slot has already passed. Please choose another time.",
                        "Invalid Time",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            string CurrentCustomerId = CustomerSession.CustomerId;
            MaintenanceRequest newRequest = new MaintenanceRequest(
                CurrentCustomerId,
                cmbCategory.SelectedItem!.ToString()!,
                txtProblemDescription.Text.Trim(),
                txtAddress.Text.Trim(),
                dtpDatePreferred.Value.Date,
                cmbTimeSlot.SelectedItem!.ToString()!
                );
            if (!newRequest.ValidateRequest(out string errorMessage))
            {
                MessageBox.Show(
                    errorMessage,
                    "Invalid Request",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataManager.AddRequest(newRequest);

            DialogResult result;
            using (RequestSubmittedDialog dialog = new RequestSubmittedDialog(
                newRequest.RequestNumber,
                newRequest.ServiceCategory,
                newRequest.PreferredDate,
                newRequest.PreferredTime,
                newRequest.EstimatedCost,
                newRequest.Status.ToString()))
            {
                result = dialog.ShowDialog(this);
            }

            if (result == DialogResult.No)
            {
                frmCustomerDashboard returnToDashBoard = new frmCustomerDashboard();
                this.Hide();
                returnToDashBoard.Show();
            }

            ClearForm();
        }

        private static int SlotStartHour(string slot)
        {
            if (slot.StartsWith("08:00")) return 8;
            if (slot.StartsWith("10:00")) return 10;
            if (slot.StartsWith("12:00")) return 12;
            if (slot.StartsWith("02:00")) return 14;
            return -1;
        }

        private void ClearForm()
        {
            cmbCategory.SelectedIndex = -1;
            cmbTimeSlot.SelectedIndex = -1;
            txtAddress.Clear();
            txtProblemDescription.Clear();
            dtpDatePreferred.Value = DateTime.Today;
            RdbxNormalPriorityLevel1.Checked = true;
            UpdateCost();
            ResetAiPanel();
            UpdateDescriptionUi();
            UpdateCompleteness();
        }

        // ------------------------------------------------------------------
        //  CATEGORY + COST
        // ------------------------------------------------------------------
        private void cmbCategory_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdateCost();
            SyncCategoryChips();
            UpdateCompleteness();
        }

        private void categoryChip_Click(object? sender, EventArgs e)
        {
            if (sender is ModernButton chip && chip.Tag is string category)
                cmbCategory.SelectedItem = category;
        }

        private void SyncCategoryChips()
        {
            string? selected = cmbCategory.SelectedItem as string;
            foreach (ModernButton chip in categoryChips)
            {
                chip.Outline = !(selected != null && (string)chip.Tag! == selected);
                chip.Invalidate();
            }
        }

        private void UpdateCost()
        {
            if (cmbCategory.SelectedIndex == -1)
            {
                lblEstimatedCost.Text = "R0.00";
                lblCostBreakdown.Text = "Pick a category to see the breakdown";
                return;
            }

            string category = cmbCategory.SelectedItem!.ToString()!;
            MaintenanceRequest temp = new MaintenanceRequest();
            decimal estimate = temp.CalculateEstimatedCost(category);
            decimal callOut = temp.CalculateEstimatedCost("");
            decimal labour = estimate - callOut;

            lblEstimatedCost.Text = $"R{estimate:F2}";
            lblCostBreakdown.Text = $"Call-out R{callOut:F2}  +  {category} R{labour:F2}";
        }

        // ------------------------------------------------------------------
        //  DESCRIPTION + SMART ASSISTANT
        // ------------------------------------------------------------------
        private void txtProblemDescription_TextChanged(object? sender, EventArgs e)
        {
            UpdateDescriptionUi();
            UpdateCompleteness();

            if (applyingSuggestion) return;

            string text = txtProblemDescription.Text.Trim();
            if (text.Length < 12)
            {
                aiTimer.Stop();
                ResetAiPanel();
                return;
            }

            // short "thinking" animation, then show the analysis
            aiTick = 0;
            lblAiStatus.Text = "Analysing";
            btnAiApply.Enabled = false;
            aiTimer.Stop();
            aiTimer.Start();
        }

        private void UpdateDescriptionUi()
        {
            int len = txtProblemDescription.Text.Trim().Length;

            if (len >= MinDescriptionLength)
            {
                lblMinimumCharacters.Text = len + " chars - looking good";
                lblMinimumCharacters.ForeColor = Theme.Green;
            }
            else
            {
                lblMinimumCharacters.Text = len + " chars (" + (MinDescriptionLength - len) + " more needed)";
                lblMinimumCharacters.ForeColor = Theme.Muted;
            }
            lblMinimumCharacters.Left = lblMinimumCharacters.Parent!.ClientSize.Width - lblMinimumCharacters.Width - 30;

            AiSuggestion s = SmartAssistant.Analyse(txtProblemDescription.Text);
            barQuality.Value = s.QualityScore;
            barQuality.BarColor = s.QualityScore < 35 ? Theme.Red : (s.QualityScore < 65 ? Theme.Amber : Theme.Green);
            lblQuality.Text = s.QualityLabel;
            lblQualityHint.Text = s.QualityHint;
        }

        private void AiTimer_Tick(object? sender, EventArgs e)
        {
            aiTick++;

            if (aiTick < 3)
            {
                lblAiStatus.Text = "Analysing" + new string('.', aiTick);
                return;
            }

            aiTimer.Stop();
            ShowAiResult(SmartAssistant.Analyse(txtProblemDescription.Text));
        }

        private void ResetAiPanel()
        {
            lastSuggestion = null;
            lblAiStatus.Text = "Ready";
            lblAiHeadline.Text = "Start typing and I will analyse your problem.";
            pillAiCategory.Visible = false;
            pillAiPriority.Visible = false;
            lblAiConfidence.Text = "";
            lblAiTip.Text = "I can suggest the right service category, flag urgent problems and give safety tips while you wait.";
            btnAiApply.Enabled = false;
        }

        private void ShowAiResult(AiSuggestion s)
        {
            lastSuggestion = s;
            lblAiStatus.Text = "Analysis complete";
            lblAiHeadline.Text = s.Headline;

            if (s.Category == null)
            {
                pillAiCategory.Visible = false;
                pillAiPriority.Visible = false;
                lblAiConfidence.Text = "";
                lblAiTip.Text = "The more specific you are, the better I can help.";
                btnAiApply.Enabled = false;
                return;
            }

            pillAiCategory.PillText = s.Category;
            pillAiCategory.PillBack = Theme.PurpleSoft;
            pillAiCategory.PillFore = Theme.Purple;
            pillAiCategory.Width = Math.Max(110, TextRenderer.MeasureText(s.Category, pillAiCategory.Font).Width + 34);
            pillAiCategory.Visible = true;

            pillAiPriority.PillText = s.Urgent ? "Urgent recommended" : "Normal priority";
            pillAiPriority.PillBack = s.Urgent ? Theme.RedSoft : Theme.GreenSoft;
            pillAiPriority.PillFore = s.Urgent ? Theme.Red : Theme.Green;
            pillAiPriority.Width = Math.Max(130, TextRenderer.MeasureText(pillAiPriority.PillText, pillAiPriority.Font).Width + 34);
            pillAiPriority.Left = pillAiCategory.Right + 10;
            pillAiPriority.Visible = true;

            lblAiConfidence.Text = s.Confidence + "% match";
            lblAiConfidence.Left = pillAiPriority.Right + 14;

            lblAiTip.Text = s.Tip;
            btnAiApply.Enabled = true;
        }

        private void btnAiApply_Click(object? sender, EventArgs e)
        {
            if (lastSuggestion == null || lastSuggestion.Category == null) return;

            applyingSuggestion = true;
            try
            {
                cmbCategory.SelectedItem = lastSuggestion.Category;

                if (lastSuggestion.Urgent)
                {
                    RdbtnUrgent1.Checked = true;
                    PickEarliestSlot();
                }
                else
                {
                    RdbxNormalPriorityLevel1.Checked = true;
                }
            }
            finally
            {
                applyingSuggestion = false;
            }

            lblAiStatus.Text = "Suggestions applied";
            UpdateCompleteness();
        }

        private void PickEarliestSlot()
        {
            dtpDatePreferred.Value = DateTime.Today;
            for (int i = 0; i < cmbTimeSlot.Items.Count; i++)
            {
                int start = SlotStartHour(cmbTimeSlot.Items[i]!.ToString()!);
                if (start >= 0 && DateTime.Now.TimeOfDay < new TimeSpan(start, 0, 0))
                {
                    cmbTimeSlot.SelectedIndex = i;
                    return;
                }
            }

            // every slot today has passed - use the first slot tomorrow
            dtpDatePreferred.Value = DateTime.Today.AddDays(1);
            cmbTimeSlot.SelectedIndex = 0;
        }

        // ------------------------------------------------------------------
        //  COMPLETENESS METER
        // ------------------------------------------------------------------
        private void UpdateCompleteness()
        {
            int done = 0;
            if (cmbCategory.SelectedIndex != -1) done++;
            if (txtProblemDescription.Text.Trim().Length >= MinDescriptionLength) done++;
            if (txtAddress.Text.Trim().Length >= MinAddressLength) done++;
            if (cmbTimeSlot.SelectedIndex != -1) done++;
            if (RdbxNormalPriorityLevel1.Checked || RdbtnUrgent1.Checked) done++;

            int pct = done * 20;
            barCompleteness.Value = pct;
            barCompleteness.BarColor = pct < 100 ? Theme.Orange : Theme.Green;
            lblCompleteness.Text = pct < 100
                ? "Request completeness  " + pct + "%"
                : "Request completeness  100% - ready to submit";
        }

        // ------------------------------------------------------------------
        private void btnBack_Click(object? sender, EventArgs e)
        {
            frmCustomerDashboard Customerdashboard = new frmCustomerDashboard();
            Customerdashboard.Show();
            this.Hide();
        }
    }
}
