namespace General_Hospital_Management_System
{
    partial class frmPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPatient));
            this.patID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pOccupation = new System.Windows.Forms.TextBox();
            this.pNationalty = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pDoB = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pGender = new System.Windows.Forms.ComboBox();
            this.pResidentAd = new System.Windows.Forms.TextBox();
            this.pAge = new System.Windows.Forms.TextBox();
            this.pContact = new System.Windows.Forms.TextBox();
            this.pMiddlename = new System.Windows.Forms.TextBox();
            this.pSurname = new System.Windows.Forms.TextBox();
            this.pFirstname = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.gRelationship = new System.Windows.Forms.TextBox();
            this.gContact = new System.Windows.Forms.TextBox();
            this.gSurname = new System.Windows.Forms.TextBox();
            this.gFirstname = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCaptureImage = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.pPhoto = new System.Windows.Forms.PictureBox();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.tbBP = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tbTemp = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnViewPat = new System.Windows.Forms.Button();
            this.btnUpdatePat = new System.Windows.Forms.Button();
            this.btnviewPatVit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveDetails = new System.Windows.Forms.Button();
            this.dtSysDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pPhoto)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // patID
            // 
            this.patID.BackColor = System.Drawing.Color.White;
            this.patID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patID.Location = new System.Drawing.Point(112, 13);
            this.patID.Name = "patID";
            this.patID.Size = new System.Drawing.Size(91, 26);
            this.patID.TabIndex = 0;
            this.patID.TextChanged += new System.EventHandler(this.patID_TextChanged);
            this.patID.Leave += new System.EventHandler(this.patID_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "PatientID";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.label17);
            this.groupBox.Controls.Add(this.label12);
            this.groupBox.Controls.Add(this.label11);
            this.groupBox.Controls.Add(this.label10);
            this.groupBox.Controls.Add(this.pEmail);
            this.groupBox.Controls.Add(this.label9);
            this.groupBox.Controls.Add(this.label8);
            this.groupBox.Controls.Add(this.label7);
            this.groupBox.Controls.Add(this.pOccupation);
            this.groupBox.Controls.Add(this.pNationalty);
            this.groupBox.Controls.Add(this.label6);
            this.groupBox.Controls.Add(this.pDoB);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.pGender);
            this.groupBox.Controls.Add(this.pResidentAd);
            this.groupBox.Controls.Add(this.pAge);
            this.groupBox.Controls.Add(this.pContact);
            this.groupBox.Controls.Add(this.pMiddlename);
            this.groupBox.Controls.Add(this.pSurname);
            this.groupBox.Controls.Add(this.pFirstname);
            this.groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox.Location = new System.Drawing.Point(13, 49);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(653, 263);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Patient  Details";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(575, 99);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(28, 16);
            this.label17.TabIndex = 21;
            this.label17.Text = "Yrs";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 20);
            this.label12.TabIndex = 20;
            this.label12.Text = "Email";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "Contact";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "Occupation";
            this.label10.TextChanged += new System.EventHandler(this.pOccupation_TextChanged);
            // 
            // pEmail
            // 
            this.pEmail.Location = new System.Drawing.Point(96, 198);
            this.pEmail.Name = "pEmail";
            this.pEmail.Size = new System.Drawing.Size(187, 22);
            this.pEmail.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(304, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "ResidenceAdd";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(323, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Nationality";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(328, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Age";
            // 
            // pOccupation
            // 
            this.pOccupation.Location = new System.Drawing.Point(96, 126);
            this.pOccupation.Name = "pOccupation";
            this.pOccupation.Size = new System.Drawing.Size(188, 22);
            this.pOccupation.TabIndex = 3;
            this.pOccupation.Leave += new System.EventHandler(this.pOccupation_Leave);
            // 
            // pNationalty
            // 
            this.pNationalty.FormattingEnabled = true;
            this.pNationalty.Items.AddRange(new object[] {
            "",
            "Afghanistan",
            "Albania",
            "Algeria",
            "Andorra",
            "Angola",
            "Anguilla",
            "Antarctica",
            "Argentina",
            "Armenia",
            "Australia",
            "Austria",
            "Azerbaijan",
            "Bahamas",
            "Bahrain",
            "Bangladesh",
            "Barbados",
            "Belarus",
            "Belgium",
            "Benin",
            "Bermuda",
            "Bolivia",
            "Bosnia and Herzegovina",
            "Botswana",
            "Brazil",
            "Brunei",
            "Bulgaria",
            "Burkina Faso",
            "Burma",
            "Burundi",
            "Cambodia",
            "Cameroon",
            "Canada",
            "Cape Verde",
            "Central African Republic",
            "Chad",
            "Chile",
            "China",
            "Colombia",
            "Comoros",
            "Congo, Democratic Republic",
            "Congo, Republic",
            "Costa Rica",
            "Cote d\'Ivoire",
            "Croatia",
            "Cuba",
            "Cyprus",
            "Czech Republic",
            "Denmark",
            "Dominica",
            "Dominican Republic",
            "Ecuador",
            "Egypt",
            "El Salvador",
            "Equatorial Guinea",
            "Eritrea",
            "Estonia",
            "Ethiopia",
            "Faroe Islands",
            "Fiji",
            "Finland",
            "France",
            "Gabon",
            "Gambia",
            "Georgia",
            "Germany",
            "Ghana",
            "Gibraltar",
            "Greece",
            "Guam",
            "Guatemala",
            "Guinea",
            "Guinea-Bissau",
            "Haiti",
            "Honduras",
            "Hong Kong",
            "Hungary",
            "Iceland",
            "India",
            "Indonesia",
            "Iran",
            "Iraq",
            "Ireland",
            "Isle of Man",
            "Israel",
            "Italy",
            "Jamaica",
            "Japan",
            "Jersey",
            "Jordan",
            "Juan de Nova Island",
            "Kazakhstan",
            "Kenya",
            "North Korea",
            "South Korea",
            "Kuwait",
            "Kyrgyzstan",
            "Latvia",
            "Lebanon",
            "Lesotho",
            "Liberia",
            "Libya",
            "Liechtenstein",
            "Lithuania",
            "Luxembourg",
            "Macedonia",
            "Madagascar",
            "Malawi",
            "Malaysia",
            "Maldives",
            "Mali",
            "Malta",
            "Mauritania",
            "Mauritius",
            "Mexico",
            "Moldova",
            "Mongolia",
            "Montserrat",
            "Morocco",
            "Mozambique",
            "Namibia",
            "Nepal",
            "Netherlands",
            "Netherlands Antilles",
            "New Caledonia",
            "New Zealand",
            "Nicaragua",
            "Niger",
            "Nigeria",
            "Niue",
            "Norway",
            "Oman",
            "Pakistan",
            "Panama",
            "Paraguay",
            "Peru",
            "Philippines",
            "Pitcairn Islands",
            "Poland",
            "Portugal",
            "Puerto Rico",
            "Qatar",
            "Romania",
            "Russia",
            "Rwanda",
            "Samoa",
            "San Marino",
            "SaoTome and Principe",
            "Saudi Arabia",
            "Senegal",
            "Serbia and Montenegro",
            "Seychelles",
            "Sierra Leone",
            "Singapore",
            "Slovakia",
            "Slovenia",
            "Solomon Islands",
            "Somalia",
            "South Africa",
            "Spain",
            "Sri Lanka",
            "Sudan",
            "Swaziland",
            "Sweden",
            "Switzerland",
            "Syria",
            "Taiwan",
            "Tanzania",
            "Thailand",
            "Togo",
            "Trinidad and Tobago",
            "Tunisia",
            "Turkey",
            "Turkmenistan",
            "Uganda",
            "Ukraine",
            "United Arab Emirates",
            "United Kingdom",
            "United States",
            "Uruguay",
            "Uzbekistan",
            "Venezuela",
            "Vietnam",
            "Virgin Islands",
            "Yemen",
            "Zambia",
            "Zimbabwe"});
            this.pNationalty.Location = new System.Drawing.Point(423, 128);
            this.pNationalty.Name = "pNationalty";
            this.pNationalty.Size = new System.Drawing.Size(175, 24);
            this.pNationalty.TabIndex = 13;
            this.pNationalty.TextChanged += new System.EventHandler(this.pNationality_TextChanged);
            this.pNationalty.Leave += new System.EventHandler(this.pNationality_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "DoB";
            // 
            // pDoB
            // 
            this.pDoB.Location = new System.Drawing.Point(96, 93);
            this.pDoB.Name = "pDoB";
            this.pDoB.Size = new System.Drawing.Size(188, 22);
            this.pDoB.TabIndex = 11;
            this.pDoB.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Middlename";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(335, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Gender";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(335, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Surname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Firstname\r\n";
            // 
            // pGender
            // 
            this.pGender.FormattingEnabled = true;
            this.pGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.pGender.Location = new System.Drawing.Point(424, 62);
            this.pGender.Name = "pGender";
            this.pGender.Size = new System.Drawing.Size(174, 24);
            this.pGender.TabIndex = 6;
            // 
            // pResidentAd
            // 
            this.pResidentAd.Location = new System.Drawing.Point(423, 161);
            this.pResidentAd.Name = "pResidentAd";
            this.pResidentAd.Size = new System.Drawing.Size(175, 22);
            this.pResidentAd.TabIndex = 5;
            this.pResidentAd.TextChanged += new System.EventHandler(this.pResAddress_TextChanged);
            this.pResidentAd.Leave += new System.EventHandler(this.pResAddress_Leave);
            // 
            // pAge
            // 
            this.pAge.Location = new System.Drawing.Point(424, 96);
            this.pAge.Name = "pAge";
            this.pAge.Size = new System.Drawing.Size(145, 22);
            this.pAge.TabIndex = 4;
            // 
            // pContact
            // 
            this.pContact.Location = new System.Drawing.Point(96, 161);
            this.pContact.MaxLength = 11;
            this.pContact.Name = "pContact";
            this.pContact.Size = new System.Drawing.Size(187, 22);
            this.pContact.TabIndex = 3;
            this.pContact.TextChanged += new System.EventHandler(this.pContact_TextChanged);
            this.pContact.Leave += new System.EventHandler(this.pContact_Leave);
            // 
            // pMiddlename
            // 
            this.pMiddlename.BackColor = System.Drawing.Color.White;
            this.pMiddlename.Location = new System.Drawing.Point(96, 60);
            this.pMiddlename.Name = "pMiddlename";
            this.pMiddlename.Size = new System.Drawing.Size(189, 22);
            this.pMiddlename.TabIndex = 2;
            // 
            // pSurname
            // 
            this.pSurname.Location = new System.Drawing.Point(424, 26);
            this.pSurname.Name = "pSurname";
            this.pSurname.Size = new System.Drawing.Size(174, 22);
            this.pSurname.TabIndex = 1;
            this.pSurname.TextChanged += new System.EventHandler(this.pSurname_TextChanged);
            this.pSurname.Leave += new System.EventHandler(this.pSurname_Leave);
            // 
            // pFirstname
            // 
            this.pFirstname.BackColor = System.Drawing.Color.White;
            this.pFirstname.Location = new System.Drawing.Point(96, 26);
            this.pFirstname.Name = "pFirstname";
            this.pFirstname.Size = new System.Drawing.Size(190, 22);
            this.pFirstname.TabIndex = 0;
            this.pFirstname.TextChanged += new System.EventHandler(this.pFirstName_TextChanged);
            this.pFirstname.Leave += new System.EventHandler(this.pFirstName_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.gRelationship);
            this.groupBox1.Controls.Add(this.gContact);
            this.groupBox1.Controls.Add(this.gSurname);
            this.groupBox1.Controls.Add(this.gFirstname);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 333);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 177);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gaurdian Details";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(7, 127);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(97, 20);
            this.label16.TabIndex = 21;
            this.label16.Text = "Relationship";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(21, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 20);
            this.label15.TabIndex = 20;
            this.label15.Text = "Contact";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(18, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 20);
            this.label14.TabIndex = 9;
            this.label14.Text = "Surname";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(17, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 20);
            this.label13.TabIndex = 8;
            this.label13.Text = "Firstname\r\n";
            // 
            // gRelationship
            // 
            this.gRelationship.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gRelationship.Location = new System.Drawing.Point(119, 121);
            this.gRelationship.Name = "gRelationship";
            this.gRelationship.Size = new System.Drawing.Size(271, 26);
            this.gRelationship.TabIndex = 3;
            // 
            // gContact
            // 
            this.gContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gContact.Location = new System.Drawing.Point(119, 89);
            this.gContact.MaxLength = 11;
            this.gContact.Name = "gContact";
            this.gContact.Size = new System.Drawing.Size(271, 26);
            this.gContact.TabIndex = 2;
            // 
            // gSurname
            // 
            this.gSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gSurname.Location = new System.Drawing.Point(119, 57);
            this.gSurname.Name = "gSurname";
            this.gSurname.Size = new System.Drawing.Size(271, 26);
            this.gSurname.TabIndex = 1;
            // 
            // gFirstname
            // 
            this.gFirstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gFirstname.Location = new System.Drawing.Point(119, 25);
            this.gFirstname.Name = "gFirstname";
            this.gFirstname.Size = new System.Drawing.Size(271, 26);
            this.gFirstname.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCaptureImage);
            this.groupBox2.Controls.Add(this.btnUpload);
            this.groupBox2.Controls.Add(this.pPhoto);
            this.groupBox2.Location = new System.Drawing.Point(672, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 263);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Patient Photo";
            // 
            // btnCaptureImage
            // 
            this.btnCaptureImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCaptureImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCaptureImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaptureImage.Location = new System.Drawing.Point(103, 200);
            this.btnCaptureImage.Name = "btnCaptureImage";
            this.btnCaptureImage.Size = new System.Drawing.Size(91, 34);
            this.btnCaptureImage.TabIndex = 2;
            this.btnCaptureImage.Text = "Capture";
            this.btnCaptureImage.UseVisualStyleBackColor = false;
            this.btnCaptureImage.Click += new System.EventHandler(this.btnCaptureImage_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(10, 200);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(87, 34);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // pPhoto
            // 
            this.pPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pPhoto.Image = global::General_Hospital_Management_System.Properties.Resources.index1;
            this.pPhoto.Location = new System.Drawing.Point(14, 18);
            this.pPhoto.Name = "pPhoto";
            this.pPhoto.Size = new System.Drawing.Size(171, 156);
            this.pPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pPhoto.TabIndex = 0;
            this.pPhoto.TabStop = false;
            // 
            // tbHeight
            // 
            this.tbHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHeight.Location = new System.Drawing.Point(253, 16);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(57, 22);
            this.tbHeight.TabIndex = 8;
            this.tbHeight.TextChanged += new System.EventHandler(this.tbHeight_TextChanged);
            this.tbHeight.Leave += new System.EventHandler(this.tbHeight_Leave);
            // 
            // tbWeight
            // 
            this.tbWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWeight.Location = new System.Drawing.Point(392, 15);
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.Size = new System.Drawing.Size(47, 22);
            this.tbWeight.TabIndex = 9;
            this.tbWeight.TextChanged += new System.EventHandler(this.tbWeight_TextChanged);
            this.tbWeight.Leave += new System.EventHandler(this.tbWeight_Leave);
            // 
            // tbBP
            // 
            this.tbBP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBP.Location = new System.Drawing.Point(576, 13);
            this.tbBP.Name = "tbBP";
            this.tbBP.Size = new System.Drawing.Size(63, 22);
            this.tbBP.TabIndex = 10;
            this.tbBP.TextChanged += new System.EventHandler(this.tbBP_TextChanged);
            this.tbBP.Leave += new System.EventHandler(this.tbBP_Leave);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(207, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 16);
            this.label18.TabIndex = 11;
            this.label18.Text = "Height";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(341, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 16);
            this.label19.TabIndex = 12;
            this.label19.Text = "Weight";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(474, 17);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(101, 16);
            this.label20.TabIndex = 13;
            this.label20.Text = "Blood Pressure";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(311, 19);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(26, 16);
            this.label21.TabIndex = 14;
            this.label21.Text = "cm";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(441, 18);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(23, 16);
            this.label22.TabIndex = 15;
            this.label22.Text = "kg";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(640, 15);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(51, 16);
            this.label23.TabIndex = 16;
            this.label23.Text = "mm Hg";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(850, 18);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(24, 16);
            this.label24.TabIndex = 19;
            this.label24.Text = "0C";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(715, 17);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(86, 16);
            this.label25.TabIndex = 18;
            this.label25.Text = "Temperature";
            // 
            // tbTemp
            // 
            this.tbTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTemp.Location = new System.Drawing.Point(802, 16);
            this.tbTemp.Name = "tbTemp";
            this.tbTemp.Size = new System.Drawing.Size(47, 22);
            this.tbTemp.TabIndex = 17;
            this.tbTemp.TextChanged += new System.EventHandler(this.tbTemp_TextChanged);
            this.tbTemp.Leave += new System.EventHandler(this.tbTemp_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.guna2CirclePictureBox1);
            this.groupBox3.Controls.Add(this.btnViewPat);
            this.groupBox3.Controls.Add(this.btnUpdatePat);
            this.groupBox3.Controls.Add(this.btnviewPatVit);
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.btnSaveDetails);
            this.groupBox3.Controls.Add(this.dtSysDate);
            this.groupBox3.Location = new System.Drawing.Point(439, 336);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(435, 177);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Image = global::General_Hospital_Management_System.Properties.Resources.labs;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(323, 83);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.ShadowDecoration.Parent = this.guna2CirclePictureBox1;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(105, 86);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 14;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // btnViewPat
            // 
            this.btnViewPat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnViewPat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewPat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewPat.Location = new System.Drawing.Point(152, 60);
            this.btnViewPat.Name = "btnViewPat";
            this.btnViewPat.Size = new System.Drawing.Size(141, 31);
            this.btnViewPat.TabIndex = 13;
            this.btnViewPat.Text = "View Patient";
            this.btnViewPat.UseVisualStyleBackColor = false;
            this.btnViewPat.Click += new System.EventHandler(this.btnViewPat_Click);
            // 
            // btnUpdatePat
            // 
            this.btnUpdatePat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdatePat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePat.Location = new System.Drawing.Point(5, 60);
            this.btnUpdatePat.Name = "btnUpdatePat";
            this.btnUpdatePat.Size = new System.Drawing.Size(141, 28);
            this.btnUpdatePat.TabIndex = 12;
            this.btnUpdatePat.Text = "Update Patient";
            this.btnUpdatePat.UseVisualStyleBackColor = true;
            this.btnUpdatePat.Click += new System.EventHandler(this.btnUpdatePat_Click);
            // 
            // btnviewPatVit
            // 
            this.btnviewPatVit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnviewPatVit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnviewPatVit.Location = new System.Drawing.Point(152, 21);
            this.btnviewPatVit.Name = "btnviewPatVit";
            this.btnviewPatVit.Size = new System.Drawing.Size(136, 27);
            this.btnviewPatVit.TabIndex = 11;
            this.btnviewPatVit.Text = "View Patient Vitals";
            this.btnviewPatVit.UseVisualStyleBackColor = true;
            this.btnviewPatVit.Click += new System.EventHandler(this.btnviewPatVit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(180, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 31);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSaveDetails
            // 
            this.btnSaveDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSaveDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDetails.Location = new System.Drawing.Point(6, 138);
            this.btnSaveDetails.Name = "btnSaveDetails";
            this.btnSaveDetails.Size = new System.Drawing.Size(119, 33);
            this.btnSaveDetails.TabIndex = 9;
            this.btnSaveDetails.Text = "Save Details";
            this.btnSaveDetails.UseVisualStyleBackColor = false;
            // 
            // dtSysDate
            // 
            this.dtSysDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSysDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSysDate.Location = new System.Drawing.Point(5, 21);
            this.dtSysDate.Name = "dtSysDate";
            this.dtSysDate.Size = new System.Drawing.Size(138, 26);
            this.dtSysDate.TabIndex = 8;
            // 
            // frmPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(910, 522);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.tbTemp);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.tbBP);
            this.Controls.Add(this.tbWeight);
            this.Controls.Add(this.tbHeight);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.patID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPatient";
            this.Text = "Patient  Form    General Hospital Management Solution";
            this.Load += new System.EventHandler(this.form1_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pPhoto)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox patID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox pGender;
        private System.Windows.Forms.TextBox pResidentAd;
        private System.Windows.Forms.TextBox pAge;
        private System.Windows.Forms.TextBox pContact;
        private System.Windows.Forms.TextBox pMiddlename;
        private System.Windows.Forms.TextBox pSurname;
        private System.Windows.Forms.TextBox pFirstname;
        private System.Windows.Forms.TextBox pOccupation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker pDoB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox pEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox pNationalty;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox gRelationship;
        private System.Windows.Forms.TextBox gContact;
        private System.Windows.Forms.TextBox gSurname;
        private System.Windows.Forms.TextBox gFirstname;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCaptureImage;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.PictureBox pPhoto;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.TextBox tbWeight;
        private System.Windows.Forms.TextBox tbBP;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tbTemp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveDetails;
        private System.Windows.Forms.DateTimePicker dtSysDate;
        private System.Windows.Forms.Button btnViewPat;
        private System.Windows.Forms.Button btnUpdatePat;
        private System.Windows.Forms.Button btnviewPatVit;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
    }
}

