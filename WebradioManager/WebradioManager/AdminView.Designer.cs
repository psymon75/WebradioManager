namespace WebradioManager
{
    partial class AdminView
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            Calendar.DrawTool drawTool1 = new Calendar.DrawTool();
            this.dayView1 = new Calendar.DayView();
            this.SuspendLayout();
            // 
            // dayView1
            // 
            drawTool1.DayView = this.dayView1;
            this.dayView1.ActiveTool = drawTool1;
            this.dayView1.AmPmDisplay = false;
            this.dayView1.AppHeightMode = Calendar.DayView.AppHeightDrawMode.EndHalfHourBlocksShort;
            this.dayView1.DaysToShow = 7;
            this.dayView1.DrawAllAppBorder = false;
            this.dayView1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.dayView1.Location = new System.Drawing.Point(12, 103);
            this.dayView1.MinHalfHourApp = false;
            this.dayView1.Name = "dayView1";
            this.dayView1.SelectionEnd = new System.DateTime(((long)(0)));
            this.dayView1.SelectionStart = new System.DateTime(((long)(0)));
            this.dayView1.Size = new System.Drawing.Size(734, 301);
            this.dayView1.SlotsPerHour = 2;
            this.dayView1.StartDate = new System.DateTime(((long)(0)));
            this.dayView1.TabIndex = 0;
            this.dayView1.Text = "dayView1";
            this.dayView1.WorkingHourEnd = 23;
            this.dayView1.WorkingHourStart = 0;
            this.dayView1.WorkingMinuteEnd = 0;
            this.dayView1.WorkingMinuteStart = 0;
            this.dayView1.ResolveAppointments += new Calendar.ResolveAppointmentsEventHandler(this.dayView1_ResolveAppointments);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 608);
            this.Controls.Add(this.dayView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Calendar.DayView dayView1;

    }
}

