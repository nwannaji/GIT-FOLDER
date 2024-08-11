namespace General_Hospital_Management_System
{
    partial class frmSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplier));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddSuppier = new System.Windows.Forms.Button();
            this.dtpSupplierAgreemtDate = new System.Windows.Forms.DateTimePicker();
            this.tbSupAddress = new System.Windows.Forms.TextBox();
            this.tbSupEmail = new System.Windows.Forms.TextBox();
            this.cbSupCountry = new System.Windows.Forms.ComboBox();
            this.cbSupType = new System.Windows.Forms.ComboBox();
            this.tbPersonIncharegContact = new System.Windows.Forms.TextBox();
            this.tbPersonIncharge = new System.Windows.Forms.TextBox();
            this.tbSupContact = new System.Windows.Forms.TextBox();
            this.tbSupName = new System.Windows.Forms.TextBox();
            this.tbSupID = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSreachSupllierID = new System.Windows.Forms.Button();
            this.tbId = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(34, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(657, 586);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(649, 560);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add New Supplier";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(218, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "           Add Supplier Account";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnAddSuppier);
            this.groupBox1.Controls.Add(this.dtpSupplierAgreemtDate);
            this.groupBox1.Controls.Add(this.tbSupAddress);
            this.groupBox1.Controls.Add(this.tbSupEmail);
            this.groupBox1.Controls.Add(this.cbSupCountry);
            this.groupBox1.Controls.Add(this.cbSupType);
            this.groupBox1.Controls.Add(this.tbPersonIncharegContact);
            this.groupBox1.Controls.Add(this.tbPersonIncharge);
            this.groupBox1.Controls.Add(this.tbSupContact);
            this.groupBox1.Controls.Add(this.tbSupName);
            this.groupBox1.Controls.Add(this.tbSupID);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(91, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 479);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Supplier";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1, 379);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(168, 19);
            this.label11.TabIndex = 30;
            this.label11.Text = "Supplier Aggreement Date";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(57, 340);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 19);
            this.label10.TabIndex = 29;
            this.label10.Text = "Supplier Address";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(127, 299);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 19);
            this.label9.TabIndex = 28;
            this.label9.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(114, 264);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 19);
            this.label8.TabIndex = 27;
            this.label8.Text = "Country";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 19);
            this.label7.TabIndex = 26;
            this.label7.Text = "Person In Charge Contact";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(55, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 19);
            this.label6.TabIndex = 25;
            this.label6.Text = "Person In Charge";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(77, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 19);
            this.label5.TabIndex = 24;
            this.label5.Text = "Supplier Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 19);
            this.label4.TabIndex = 23;
            this.label4.Text = "Supplier Contact";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(68, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 19);
            this.label3.TabIndex = 22;
            this.label3.Text = "Supplier Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 19);
            this.label2.TabIndex = 21;
            this.label2.Text = "SupplierID";
            // 
            // btnAddSuppier
            // 
            this.btnAddSuppier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAddSuppier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSuppier.Location = new System.Drawing.Point(295, 419);
            this.btnAddSuppier.Name = "btnAddSuppier";
            this.btnAddSuppier.Size = new System.Drawing.Size(119, 37);
            this.btnAddSuppier.TabIndex = 20;
            this.btnAddSuppier.Text = "Add";
            this.btnAddSuppier.UseVisualStyleBackColor = false;
            this.btnAddSuppier.Click += new System.EventHandler(this.btnAddSuppier_Click);
            // 
            // dtpSupplierAgreemtDate
            // 
            this.dtpSupplierAgreemtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSupplierAgreemtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSupplierAgreemtDate.Location = new System.Drawing.Point(173, 376);
            this.dtpSupplierAgreemtDate.Name = "dtpSupplierAgreemtDate";
            this.dtpSupplierAgreemtDate.Size = new System.Drawing.Size(241, 26);
            this.dtpSupplierAgreemtDate.TabIndex = 19;
            // 
            // tbSupAddress
            // 
            this.tbSupAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSupAddress.Location = new System.Drawing.Point(173, 337);
            this.tbSupAddress.Name = "tbSupAddress";
            this.tbSupAddress.Size = new System.Drawing.Size(241, 26);
            this.tbSupAddress.TabIndex = 18;
            this.tbSupAddress.TextChanged += new System.EventHandler(this.tbSupAddress_TextChanged);
            this.tbSupAddress.Leave += new System.EventHandler(this.tbSupAddress_Leave);
            // 
            // tbSupEmail
            // 
            this.tbSupEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSupEmail.Location = new System.Drawing.Point(173, 296);
            this.tbSupEmail.Name = "tbSupEmail";
            this.tbSupEmail.Size = new System.Drawing.Size(241, 26);
            this.tbSupEmail.TabIndex = 17;
            // 
            // cbSupCountry
            // 
            this.cbSupCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSupCountry.FormattingEnabled = true;
            this.cbSupCountry.Items.AddRange(new object[] {
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
            this.cbSupCountry.Location = new System.Drawing.Point(173, 259);
            this.cbSupCountry.Name = "cbSupCountry";
            this.cbSupCountry.Size = new System.Drawing.Size(241, 28);
            this.cbSupCountry.TabIndex = 16;
            // 
            // cbSupType
            // 
            this.cbSupType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSupType.FormattingEnabled = true;
            this.cbSupType.Items.AddRange(new object[] {
            "Drug",
            "Equipment"});
            this.cbSupType.Location = new System.Drawing.Point(173, 144);
            this.cbSupType.Name = "cbSupType";
            this.cbSupType.Size = new System.Drawing.Size(241, 28);
            this.cbSupType.TabIndex = 15;
            // 
            // tbPersonIncharegContact
            // 
            this.tbPersonIncharegContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPersonIncharegContact.Location = new System.Drawing.Point(173, 220);
            this.tbPersonIncharegContact.MaxLength = 15;
            this.tbPersonIncharegContact.Name = "tbPersonIncharegContact";
            this.tbPersonIncharegContact.Size = new System.Drawing.Size(241, 26);
            this.tbPersonIncharegContact.TabIndex = 14;
            this.tbPersonIncharegContact.TextChanged += new System.EventHandler(this.tbPeronInchargeContact_TextChanged);
            this.tbPersonIncharegContact.Leave += new System.EventHandler(this.tbPersonInchargeContact_Leave);
            // 
            // tbPersonIncharge
            // 
            this.tbPersonIncharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPersonIncharge.Location = new System.Drawing.Point(173, 182);
            this.tbPersonIncharge.Name = "tbPersonIncharge";
            this.tbPersonIncharge.Size = new System.Drawing.Size(241, 26);
            this.tbPersonIncharge.TabIndex = 13;
            this.tbPersonIncharge.TextChanged += new System.EventHandler(this.tbPersonIncharge_TextChanged);
            this.tbPersonIncharge.Leave += new System.EventHandler(this.tbPeronIncharge_Leave);
            // 
            // tbSupContact
            // 
            this.tbSupContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSupContact.Location = new System.Drawing.Point(173, 106);
            this.tbSupContact.MaxLength = 15;
            this.tbSupContact.Name = "tbSupContact";
            this.tbSupContact.Size = new System.Drawing.Size(241, 26);
            this.tbSupContact.TabIndex = 12;
            this.tbSupContact.TextChanged += new System.EventHandler(this.tbSupContact_TextChanged);
            this.tbSupContact.Leave += new System.EventHandler(this.tbSupContact_Leave);
            // 
            // tbSupName
            // 
            this.tbSupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSupName.Location = new System.Drawing.Point(173, 68);
            this.tbSupName.Name = "tbSupName";
            this.tbSupName.Size = new System.Drawing.Size(241, 26);
            this.tbSupName.TabIndex = 11;
            this.tbSupName.TextChanged += new System.EventHandler(this.tbSupName_TextChanged);
            this.tbSupName.Leave += new System.EventHandler(this.tbSupName_Leave);
            // 
            // tbSupID
            // 
            this.tbSupID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSupID.Location = new System.Drawing.Point(173, 32);
            this.tbSupID.Name = "tbSupID";
            this.tbSupID.Size = new System.Drawing.Size(241, 26);
            this.tbSupID.TabIndex = 10;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tabPage2.Controls.Add(this.btnSreachSupllierID);
            this.tabPage2.Controls.Add(this.tbId);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(649, 560);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "View Supplier";
            // 
            // btnSreachSupllierID
            // 
            this.btnSreachSupllierID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSreachSupllierID.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSreachSupllierID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSreachSupllierID.Location = new System.Drawing.Point(406, 28);
            this.btnSreachSupllierID.Name = "btnSreachSupllierID";
            this.btnSreachSupllierID.Size = new System.Drawing.Size(158, 29);
            this.btnSreachSupllierID.TabIndex = 3;
            this.btnSreachSupllierID.Text = "Sreach For Supplier";
            this.btnSreachSupllierID.UseVisualStyleBackColor = false;
            this.btnSreachSupllierID.Click += new System.EventHandler(this.btnSreachSupllierID_Click);
            // 
            // tbId
            // 
            this.tbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbId.Location = new System.Drawing.Point(141, 28);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(218, 26);
            this.tbId.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(37, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 20);
            this.label12.TabIndex = 1;
            this.label12.Text = "Enter ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(37, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(575, 407);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View Supplier";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(307, 343);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 28);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(33, 359);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 16);
            this.label13.TabIndex = 1;
            this.label13.Text = "label13";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(542, 291);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // frmSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(747, 636);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSupplier";
            this.Text = "Supplier";
            this.Load += new System.EventHandler(this.frmSupplier_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddSuppier;
        private System.Windows.Forms.DateTimePicker dtpSupplierAgreemtDate;
        private System.Windows.Forms.TextBox tbSupAddress;
        private System.Windows.Forms.TextBox tbSupEmail;
        private System.Windows.Forms.ComboBox cbSupCountry;
        private System.Windows.Forms.ComboBox cbSupType;
        private System.Windows.Forms.TextBox tbPersonIncharegContact;
        private System.Windows.Forms.TextBox tbPersonIncharge;
        private System.Windows.Forms.TextBox tbSupContact;
        private System.Windows.Forms.TextBox tbSupName;
        private System.Windows.Forms.TextBox tbSupID;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSreachSupllierID;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}