
namespace CPC2020_2_Lab3.Forms
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.dataGridViewAppointments = new System.Windows.Forms.DataGridView();
            this.labelCovid = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelPatientsFirstName = new System.Windows.Forms.Label();
            this.labelPatientsLastName = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.buttonClearTextBoxes = new System.Windows.Forms.Button();
            this.labelLastAction = new System.Windows.Forms.Label();
            this.dateTimePickerVaccinationDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxPatiendsFirstName = new System.Windows.Forms.TextBox();
            this.textBoxPatientsLastName = new System.Windows.Forms.TextBox();
            this.labelVaccineType = new System.Windows.Forms.Label();
            this.labelDoctorsLastName = new System.Windows.Forms.Label();
            this.labelLocationName = new System.Windows.Forms.Label();
            this.labelPhoneNumber = new System.Windows.Forms.Label();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.comboBoxVaccineType = new System.Windows.Forms.ComboBox();
            this.comboBoxDoctorsLastName = new System.Windows.Forms.ComboBox();
            this.comboBoxLocationName = new System.Windows.Forms.ComboBox();
            this.buttonAddVaccination = new System.Windows.Forms.Button();
            this.buttonDeleteAppointment = new System.Windows.Forms.Button();
            this.buttonAddAppointment = new System.Windows.Forms.Button();
            this.buttonUpdateAppointment = new System.Windows.Forms.Button();
            this.buttonAddPatient = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAppointments
            // 
            this.dataGridViewAppointments.AllowUserToAddRows = false;
            this.dataGridViewAppointments.AllowUserToDeleteRows = false;
            this.dataGridViewAppointments.AllowUserToOrderColumns = true;
            this.dataGridViewAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAppointments.Location = new System.Drawing.Point(9, 30);
            this.dataGridViewAppointments.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewAppointments.Name = "dataGridViewAppointments";
            this.dataGridViewAppointments.ReadOnly = true;
            this.dataGridViewAppointments.RowTemplate.Height = 24;
            this.dataGridViewAppointments.Size = new System.Drawing.Size(837, 198);
            this.dataGridViewAppointments.TabIndex = 0;
            this.dataGridViewAppointments.SelectionChanged += new System.EventHandler(this.dataGridViewAppointments_SelectionChanged);
            // 
            // labelCovid
            // 
            this.labelCovid.AutoSize = true;
            this.labelCovid.Location = new System.Drawing.Point(6, 9);
            this.labelCovid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCovid.Name = "labelCovid";
            this.labelCovid.Size = new System.Drawing.Size(83, 13);
            this.labelCovid.TabIndex = 4;
            this.labelCovid.Text = "Covid Database";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(11, 283);
            this.labelDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(33, 13);
            this.labelDate.TabIndex = 11;
            this.labelDate.Text = "Data:";
            // 
            // labelPatientsFirstName
            // 
            this.labelPatientsFirstName.AutoSize = true;
            this.labelPatientsFirstName.Location = new System.Drawing.Point(11, 312);
            this.labelPatientsFirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPatientsFirstName.Name = "labelPatientsFirstName";
            this.labelPatientsFirstName.Size = new System.Drawing.Size(73, 13);
            this.labelPatientsFirstName.TabIndex = 12;
            this.labelPatientsFirstName.Text = "Imię pacjenta:";
            // 
            // labelPatientsLastName
            // 
            this.labelPatientsLastName.AutoSize = true;
            this.labelPatientsLastName.Location = new System.Drawing.Point(11, 342);
            this.labelPatientsLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPatientsLastName.Name = "labelPatientsLastName";
            this.labelPatientsLastName.Size = new System.Drawing.Size(100, 13);
            this.labelPatientsLastName.TabIndex = 13;
            this.labelPatientsLastName.Text = "Nazwisko pacjenta:";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(11, 254);
            this.labelId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(19, 13);
            this.labelId.TabIndex = 17;
            this.labelId.Text = "Id:";
            // 
            // textBoxId
            // 
            this.textBoxId.Enabled = false;
            this.textBoxId.Location = new System.Drawing.Point(128, 254);
            this.textBoxId.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(200, 20);
            this.textBoxId.TabIndex = 16;
            // 
            // buttonClearTextBoxes
            // 
            this.buttonClearTextBoxes.Location = new System.Drawing.Point(587, 254);
            this.buttonClearTextBoxes.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClearTextBoxes.Name = "buttonClearTextBoxes";
            this.buttonClearTextBoxes.Size = new System.Drawing.Size(104, 68);
            this.buttonClearTextBoxes.TabIndex = 18;
            this.buttonClearTextBoxes.Text = "Wyczyść pola";
            this.buttonClearTextBoxes.UseVisualStyleBackColor = true;
            this.buttonClearTextBoxes.Click += new System.EventHandler(this.buttonClearTextBoxes_Click);
            // 
            // labelLastAction
            // 
            this.labelLastAction.AutoSize = true;
            this.labelLastAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLastAction.Location = new System.Drawing.Point(2, 508);
            this.labelLastAction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLastAction.Name = "labelLastAction";
            this.labelLastAction.Size = new System.Drawing.Size(302, 42);
            this.labelLastAction.TabIndex = 19;
            this.labelLastAction.Text = "Ostatnia akcja...";
            // 
            // dateTimePickerVaccinationDate
            // 
            this.dateTimePickerVaccinationDate.Location = new System.Drawing.Point(128, 283);
            this.dateTimePickerVaccinationDate.Name = "dateTimePickerVaccinationDate";
            this.dateTimePickerVaccinationDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerVaccinationDate.TabIndex = 20;
            this.dateTimePickerVaccinationDate.Value = new System.DateTime(2021, 3, 26, 0, 0, 0, 0);
            // 
            // textBoxPatiendsFirstName
            // 
            this.textBoxPatiendsFirstName.Location = new System.Drawing.Point(128, 312);
            this.textBoxPatiendsFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPatiendsFirstName.Name = "textBoxPatiendsFirstName";
            this.textBoxPatiendsFirstName.Size = new System.Drawing.Size(200, 20);
            this.textBoxPatiendsFirstName.TabIndex = 21;
            // 
            // textBoxPatientsLastName
            // 
            this.textBoxPatientsLastName.Location = new System.Drawing.Point(128, 342);
            this.textBoxPatientsLastName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPatientsLastName.Name = "textBoxPatientsLastName";
            this.textBoxPatientsLastName.Size = new System.Drawing.Size(200, 20);
            this.textBoxPatientsLastName.TabIndex = 22;
            // 
            // labelVaccineType
            // 
            this.labelVaccineType.AutoSize = true;
            this.labelVaccineType.Location = new System.Drawing.Point(14, 412);
            this.labelVaccineType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVaccineType.Name = "labelVaccineType";
            this.labelVaccineType.Size = new System.Drawing.Size(86, 13);
            this.labelVaccineType.TabIndex = 24;
            this.labelVaccineType.Text = "Typ szczepionki:";
            // 
            // labelDoctorsLastName
            // 
            this.labelDoctorsLastName.AutoSize = true;
            this.labelDoctorsLastName.Location = new System.Drawing.Point(16, 443);
            this.labelDoctorsLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDoctorsLastName.Name = "labelDoctorsLastName";
            this.labelDoctorsLastName.Size = new System.Drawing.Size(95, 13);
            this.labelDoctorsLastName.TabIndex = 26;
            this.labelDoctorsLastName.Text = "Nazwisko doktora:";
            // 
            // labelLocationName
            // 
            this.labelLocationName.AutoSize = true;
            this.labelLocationName.Location = new System.Drawing.Point(16, 472);
            this.labelLocationName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLocationName.Name = "labelLocationName";
            this.labelLocationName.Size = new System.Drawing.Size(46, 13);
            this.labelLocationName.TabIndex = 28;
            this.labelLocationName.Text = "Miejsce:";
            // 
            // labelPhoneNumber
            // 
            this.labelPhoneNumber.AutoSize = true;
            this.labelPhoneNumber.Location = new System.Drawing.Point(14, 373);
            this.labelPhoneNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPhoneNumber.Name = "labelPhoneNumber";
            this.labelPhoneNumber.Size = new System.Drawing.Size(82, 13);
            this.labelPhoneNumber.TabIndex = 32;
            this.labelPhoneNumber.Text = "Numer telefonu:";
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(128, 373);
            this.textBoxPhoneNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(200, 20);
            this.textBoxPhoneNumber.TabIndex = 34;
            // 
            // comboBoxVaccineType
            // 
            this.comboBoxVaccineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVaccineType.FormattingEnabled = true;
            this.comboBoxVaccineType.Location = new System.Drawing.Point(128, 409);
            this.comboBoxVaccineType.Name = "comboBoxVaccineType";
            this.comboBoxVaccineType.Size = new System.Drawing.Size(200, 21);
            this.comboBoxVaccineType.TabIndex = 35;
            // 
            // comboBoxDoctorsLastName
            // 
            this.comboBoxDoctorsLastName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDoctorsLastName.FormattingEnabled = true;
            this.comboBoxDoctorsLastName.Location = new System.Drawing.Point(128, 440);
            this.comboBoxDoctorsLastName.Name = "comboBoxDoctorsLastName";
            this.comboBoxDoctorsLastName.Size = new System.Drawing.Size(200, 21);
            this.comboBoxDoctorsLastName.TabIndex = 36;
            // 
            // comboBoxLocationName
            // 
            this.comboBoxLocationName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLocationName.FormattingEnabled = true;
            this.comboBoxLocationName.Location = new System.Drawing.Point(128, 469);
            this.comboBoxLocationName.Name = "comboBoxLocationName";
            this.comboBoxLocationName.Size = new System.Drawing.Size(200, 21);
            this.comboBoxLocationName.TabIndex = 37;
            // 
            // buttonAddVaccination
            // 
            this.buttonAddVaccination.Location = new System.Drawing.Point(587, 422);
            this.buttonAddVaccination.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddVaccination.Name = "buttonAddVaccination";
            this.buttonAddVaccination.Size = new System.Drawing.Size(104, 68);
            this.buttonAddVaccination.TabIndex = 38;
            this.buttonAddVaccination.Text = "Dodaj szczepienie";
            this.buttonAddVaccination.UseVisualStyleBackColor = true;
            this.buttonAddVaccination.Click += new System.EventHandler(this.buttonAddVaccination_Click);
            // 
            // buttonDeleteAppointment
            // 
            this.buttonDeleteAppointment.Location = new System.Drawing.Point(711, 422);
            this.buttonDeleteAppointment.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDeleteAppointment.Name = "buttonDeleteAppointment";
            this.buttonDeleteAppointment.Size = new System.Drawing.Size(104, 68);
            this.buttonDeleteAppointment.TabIndex = 39;
            this.buttonDeleteAppointment.Text = "Usuń wizytę";
            this.buttonDeleteAppointment.UseVisualStyleBackColor = true;
            this.buttonDeleteAppointment.Click += new System.EventHandler(this.buttonDeleteAppointment_Click);
            // 
            // buttonAddAppointment
            // 
            this.buttonAddAppointment.Location = new System.Drawing.Point(711, 254);
            this.buttonAddAppointment.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddAppointment.Name = "buttonAddAppointment";
            this.buttonAddAppointment.Size = new System.Drawing.Size(104, 68);
            this.buttonAddAppointment.TabIndex = 40;
            this.buttonAddAppointment.Text = "Dodaj wizytę ";
            this.buttonAddAppointment.UseVisualStyleBackColor = true;
            this.buttonAddAppointment.Click += new System.EventHandler(this.buttonAddAppointment_Click);
            // 
            // buttonUpdateAppointment
            // 
            this.buttonUpdateAppointment.Location = new System.Drawing.Point(711, 337);
            this.buttonUpdateAppointment.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUpdateAppointment.Name = "buttonUpdateAppointment";
            this.buttonUpdateAppointment.Size = new System.Drawing.Size(104, 68);
            this.buttonUpdateAppointment.TabIndex = 41;
            this.buttonUpdateAppointment.Text = "Edytuj wizytę";
            this.buttonUpdateAppointment.UseVisualStyleBackColor = true;
            this.buttonUpdateAppointment.Click += new System.EventHandler(this.buttonUpdateAppointment_Click);
            // 
            // buttonAddPatient
            // 
            this.buttonAddPatient.Location = new System.Drawing.Point(587, 337);
            this.buttonAddPatient.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddPatient.Name = "buttonAddPatient";
            this.buttonAddPatient.Size = new System.Drawing.Size(104, 68);
            this.buttonAddPatient.TabIndex = 42;
            this.buttonAddPatient.Text = "Dodaj pacjenta";
            this.buttonAddPatient.UseVisualStyleBackColor = true;
            this.buttonAddPatient.Click += new System.EventHandler(this.buttonAddPatient_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 559);
            this.Controls.Add(this.buttonAddPatient);
            this.Controls.Add(this.buttonUpdateAppointment);
            this.Controls.Add(this.buttonAddAppointment);
            this.Controls.Add(this.buttonDeleteAppointment);
            this.Controls.Add(this.buttonAddVaccination);
            this.Controls.Add(this.comboBoxLocationName);
            this.Controls.Add(this.comboBoxDoctorsLastName);
            this.Controls.Add(this.comboBoxVaccineType);
            this.Controls.Add(this.textBoxPhoneNumber);
            this.Controls.Add(this.labelPhoneNumber);
            this.Controls.Add(this.labelLocationName);
            this.Controls.Add(this.labelDoctorsLastName);
            this.Controls.Add(this.labelVaccineType);
            this.Controls.Add(this.textBoxPatientsLastName);
            this.Controls.Add(this.textBoxPatiendsFirstName);
            this.Controls.Add(this.dateTimePickerVaccinationDate);
            this.Controls.Add(this.labelLastAction);
            this.Controls.Add(this.buttonClearTextBoxes);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.labelPatientsLastName);
            this.Controls.Add(this.labelPatientsFirstName);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelCovid);
            this.Controls.Add(this.dataGridViewAppointments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "Covid Vaccinations Database App";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.FormMain_HelpButtonClicked);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAppointments;
        private System.Windows.Forms.Label labelCovid;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelPatientsFirstName;
        private System.Windows.Forms.Label labelPatientsLastName;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Button buttonClearTextBoxes;
        private System.Windows.Forms.Label labelLastAction;
        private System.Windows.Forms.DateTimePicker dateTimePickerVaccinationDate;
        private System.Windows.Forms.TextBox textBoxPatiendsFirstName;
        private System.Windows.Forms.TextBox textBoxPatientsLastName;
        private System.Windows.Forms.Label labelVaccineType;
        private System.Windows.Forms.Label labelDoctorsLastName;
        private System.Windows.Forms.Label labelLocationName;
        private System.Windows.Forms.Label labelPhoneNumber;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.ComboBox comboBoxVaccineType;
        private System.Windows.Forms.ComboBox comboBoxDoctorsLastName;
        private System.Windows.Forms.ComboBox comboBoxLocationName;
        private System.Windows.Forms.Button buttonAddVaccination;
        private System.Windows.Forms.Button buttonDeleteAppointment;
        private System.Windows.Forms.Button buttonAddAppointment;
        private System.Windows.Forms.Button buttonUpdateAppointment;
        private System.Windows.Forms.Button buttonAddPatient;
    }
}

