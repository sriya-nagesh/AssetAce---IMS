namespace AssetAce
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.panel_sidemenu = new System.Windows.Forms.Panel();
            this.panel_content = new System.Windows.Forms.Panel();
            this.panel_customers = new System.Windows.Forms.Panel();
            this.btn_updateCus = new System.Windows.Forms.Button();
            this.btn_addCus = new System.Windows.Forms.Button();
            this.btn_customers = new System.Windows.Forms.Button();
            this.panel_orders = new System.Windows.Forms.Panel();
            this.btn_updateO = new System.Windows.Forms.Button();
            this.btn_addO = new System.Windows.Forms.Button();
            this.btn_orders = new System.Windows.Forms.Button();
            this.panel_categories = new System.Windows.Forms.Panel();
            this.btn_updateC = new System.Windows.Forms.Button();
            this.btn_addC = new System.Windows.Forms.Button();
            this.btn_categories = new System.Windows.Forms.Button();
            this.panel_products = new System.Windows.Forms.Panel();
            this.btn_updateP = new System.Windows.Forms.Button();
            this.btn_addP = new System.Windows.Forms.Button();
            this.btn_products = new System.Windows.Forms.Button();
            this.panel_profile = new System.Windows.Forms.Panel();
            this.btn_logout = new System.Windows.Forms.Button();
            this.btn_editPassword = new System.Windows.Forms.Button();
            this.btn_editProfile = new System.Windows.Forms.Button();
            this.btn_profile = new System.Windows.Forms.Button();
            this.btn_home = new System.Windows.Forms.Button();
            this.lbl_fname = new System.Windows.Forms.Label();
            this.panel_logo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_header = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.Label();
            this.panel_con = new System.Windows.Forms.Panel();
            this.panel_sidemenu.SuspendLayout();
            this.panel_content.SuspendLayout();
            this.panel_customers.SuspendLayout();
            this.panel_orders.SuspendLayout();
            this.panel_categories.SuspendLayout();
            this.panel_products.SuspendLayout();
            this.panel_profile.SuspendLayout();
            this.panel_logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_header.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_sidemenu
            // 
            this.panel_sidemenu.AutoScroll = true;
            this.panel_sidemenu.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel_sidemenu.Controls.Add(this.panel_content);
            this.panel_sidemenu.Controls.Add(this.panel_logo);
            this.panel_sidemenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_sidemenu.Location = new System.Drawing.Point(0, 0);
            this.panel_sidemenu.Name = "panel_sidemenu";
            this.panel_sidemenu.Size = new System.Drawing.Size(201, 614);
            this.panel_sidemenu.TabIndex = 0;
            // 
            // panel_content
            // 
            this.panel_content.Controls.Add(this.panel_customers);
            this.panel_content.Controls.Add(this.btn_customers);
            this.panel_content.Controls.Add(this.panel_orders);
            this.panel_content.Controls.Add(this.btn_orders);
            this.panel_content.Controls.Add(this.panel_categories);
            this.panel_content.Controls.Add(this.btn_categories);
            this.panel_content.Controls.Add(this.panel_products);
            this.panel_content.Controls.Add(this.btn_products);
            this.panel_content.Controls.Add(this.panel_profile);
            this.panel_content.Controls.Add(this.btn_profile);
            this.panel_content.Controls.Add(this.btn_home);
            this.panel_content.Controls.Add(this.lbl_fname);
            this.panel_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_content.Location = new System.Drawing.Point(0, 62);
            this.panel_content.Name = "panel_content";
            this.panel_content.Size = new System.Drawing.Size(201, 552);
            this.panel_content.TabIndex = 1;
            // 
            // panel_customers
            // 
            this.panel_customers.Controls.Add(this.btn_updateCus);
            this.panel_customers.Controls.Add(this.btn_addCus);
            this.panel_customers.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_customers.Location = new System.Drawing.Point(0, 634);
            this.panel_customers.Name = "panel_customers";
            this.panel_customers.Size = new System.Drawing.Size(201, 80);
            this.panel_customers.TabIndex = 12;
            // 
            // btn_updateCus
            // 
            this.btn_updateCus.BackColor = System.Drawing.Color.Silver;
            this.btn_updateCus.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_updateCus.FlatAppearance.BorderSize = 0;
            this.btn_updateCus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_updateCus.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_updateCus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_updateCus.Location = new System.Drawing.Point(0, 40);
            this.btn_updateCus.Name = "btn_updateCus";
            this.btn_updateCus.Size = new System.Drawing.Size(201, 40);
            this.btn_updateCus.TabIndex = 5;
            this.btn_updateCus.Text = "Update Customer";
            this.btn_updateCus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_updateCus.UseVisualStyleBackColor = false;
            this.btn_updateCus.Click += new System.EventHandler(this.btn_updateCus_Click);
            // 
            // btn_addCus
            // 
            this.btn_addCus.BackColor = System.Drawing.Color.Silver;
            this.btn_addCus.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_addCus.FlatAppearance.BorderSize = 0;
            this.btn_addCus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addCus.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addCus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_addCus.Location = new System.Drawing.Point(0, 0);
            this.btn_addCus.Name = "btn_addCus";
            this.btn_addCus.Size = new System.Drawing.Size(201, 40);
            this.btn_addCus.TabIndex = 4;
            this.btn_addCus.Text = "Add Customer";
            this.btn_addCus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_addCus.UseVisualStyleBackColor = false;
            this.btn_addCus.Click += new System.EventHandler(this.btn_addCus_Click);
            // 
            // btn_customers
            // 
            this.btn_customers.BackColor = System.Drawing.Color.LightSlateGray;
            this.btn_customers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_customers.FlatAppearance.BorderSize = 0;
            this.btn_customers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_customers.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_customers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_customers.Location = new System.Drawing.Point(0, 594);
            this.btn_customers.Name = "btn_customers";
            this.btn_customers.Size = new System.Drawing.Size(201, 40);
            this.btn_customers.TabIndex = 11;
            this.btn_customers.Text = "Customers";
            this.btn_customers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_customers.UseVisualStyleBackColor = false;
            this.btn_customers.Click += new System.EventHandler(this.btn_customers_Click);
            // 
            // panel_orders
            // 
            this.panel_orders.Controls.Add(this.btn_updateO);
            this.panel_orders.Controls.Add(this.btn_addO);
            this.panel_orders.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_orders.Location = new System.Drawing.Point(0, 514);
            this.panel_orders.Name = "panel_orders";
            this.panel_orders.Size = new System.Drawing.Size(201, 80);
            this.panel_orders.TabIndex = 10;
            // 
            // btn_updateO
            // 
            this.btn_updateO.BackColor = System.Drawing.Color.Silver;
            this.btn_updateO.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_updateO.FlatAppearance.BorderSize = 0;
            this.btn_updateO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_updateO.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_updateO.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_updateO.Location = new System.Drawing.Point(0, 40);
            this.btn_updateO.Name = "btn_updateO";
            this.btn_updateO.Size = new System.Drawing.Size(201, 40);
            this.btn_updateO.TabIndex = 5;
            this.btn_updateO.Text = "Update Order";
            this.btn_updateO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_updateO.UseVisualStyleBackColor = false;
            this.btn_updateO.Click += new System.EventHandler(this.btn_updateO_Click);
            // 
            // btn_addO
            // 
            this.btn_addO.BackColor = System.Drawing.Color.Silver;
            this.btn_addO.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_addO.FlatAppearance.BorderSize = 0;
            this.btn_addO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addO.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addO.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_addO.Location = new System.Drawing.Point(0, 0);
            this.btn_addO.Name = "btn_addO";
            this.btn_addO.Size = new System.Drawing.Size(201, 40);
            this.btn_addO.TabIndex = 4;
            this.btn_addO.Text = "Add Order";
            this.btn_addO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_addO.UseVisualStyleBackColor = false;
            this.btn_addO.Click += new System.EventHandler(this.btn_addO_Click);
            // 
            // btn_orders
            // 
            this.btn_orders.BackColor = System.Drawing.Color.LightSlateGray;
            this.btn_orders.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_orders.FlatAppearance.BorderSize = 0;
            this.btn_orders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_orders.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_orders.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_orders.Location = new System.Drawing.Point(0, 474);
            this.btn_orders.Name = "btn_orders";
            this.btn_orders.Size = new System.Drawing.Size(201, 40);
            this.btn_orders.TabIndex = 9;
            this.btn_orders.Text = "Orders";
            this.btn_orders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_orders.UseVisualStyleBackColor = false;
            this.btn_orders.Click += new System.EventHandler(this.btn_orders_Click);
            // 
            // panel_categories
            // 
            this.panel_categories.Controls.Add(this.btn_updateC);
            this.panel_categories.Controls.Add(this.btn_addC);
            this.panel_categories.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_categories.Location = new System.Drawing.Point(0, 394);
            this.panel_categories.Name = "panel_categories";
            this.panel_categories.Size = new System.Drawing.Size(201, 80);
            this.panel_categories.TabIndex = 8;
            // 
            // btn_updateC
            // 
            this.btn_updateC.BackColor = System.Drawing.Color.Silver;
            this.btn_updateC.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_updateC.FlatAppearance.BorderSize = 0;
            this.btn_updateC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_updateC.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_updateC.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_updateC.Location = new System.Drawing.Point(0, 40);
            this.btn_updateC.Name = "btn_updateC";
            this.btn_updateC.Size = new System.Drawing.Size(201, 40);
            this.btn_updateC.TabIndex = 5;
            this.btn_updateC.Text = "Update Category";
            this.btn_updateC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_updateC.UseVisualStyleBackColor = false;
            this.btn_updateC.Click += new System.EventHandler(this.btn_updateC_Click);
            // 
            // btn_addC
            // 
            this.btn_addC.BackColor = System.Drawing.Color.Silver;
            this.btn_addC.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_addC.FlatAppearance.BorderSize = 0;
            this.btn_addC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addC.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addC.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_addC.Location = new System.Drawing.Point(0, 0);
            this.btn_addC.Name = "btn_addC";
            this.btn_addC.Size = new System.Drawing.Size(201, 40);
            this.btn_addC.TabIndex = 4;
            this.btn_addC.Text = "Add Category";
            this.btn_addC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_addC.UseVisualStyleBackColor = false;
            this.btn_addC.Click += new System.EventHandler(this.btn_addC_Click);
            // 
            // btn_categories
            // 
            this.btn_categories.BackColor = System.Drawing.Color.LightSlateGray;
            this.btn_categories.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_categories.FlatAppearance.BorderSize = 0;
            this.btn_categories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_categories.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_categories.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_categories.Location = new System.Drawing.Point(0, 354);
            this.btn_categories.Name = "btn_categories";
            this.btn_categories.Size = new System.Drawing.Size(201, 40);
            this.btn_categories.TabIndex = 7;
            this.btn_categories.Text = "Categories";
            this.btn_categories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_categories.UseVisualStyleBackColor = false;
            this.btn_categories.Click += new System.EventHandler(this.btn_categories_Click);
            // 
            // panel_products
            // 
            this.panel_products.Controls.Add(this.btn_updateP);
            this.panel_products.Controls.Add(this.btn_addP);
            this.panel_products.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_products.Location = new System.Drawing.Point(0, 274);
            this.panel_products.Name = "panel_products";
            this.panel_products.Size = new System.Drawing.Size(201, 80);
            this.panel_products.TabIndex = 6;
            // 
            // btn_updateP
            // 
            this.btn_updateP.BackColor = System.Drawing.Color.Silver;
            this.btn_updateP.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_updateP.FlatAppearance.BorderSize = 0;
            this.btn_updateP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_updateP.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_updateP.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_updateP.Location = new System.Drawing.Point(0, 40);
            this.btn_updateP.Name = "btn_updateP";
            this.btn_updateP.Size = new System.Drawing.Size(201, 40);
            this.btn_updateP.TabIndex = 5;
            this.btn_updateP.Text = "Update Product";
            this.btn_updateP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_updateP.UseVisualStyleBackColor = false;
            this.btn_updateP.Click += new System.EventHandler(this.btn_updateP_Click);
            // 
            // btn_addP
            // 
            this.btn_addP.BackColor = System.Drawing.Color.Silver;
            this.btn_addP.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_addP.FlatAppearance.BorderSize = 0;
            this.btn_addP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addP.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addP.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_addP.Location = new System.Drawing.Point(0, 0);
            this.btn_addP.Name = "btn_addP";
            this.btn_addP.Size = new System.Drawing.Size(201, 40);
            this.btn_addP.TabIndex = 4;
            this.btn_addP.Text = "Add Product";
            this.btn_addP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_addP.UseVisualStyleBackColor = false;
            this.btn_addP.Click += new System.EventHandler(this.btn_addP_Click);
            // 
            // btn_products
            // 
            this.btn_products.BackColor = System.Drawing.Color.LightSlateGray;
            this.btn_products.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_products.FlatAppearance.BorderSize = 0;
            this.btn_products.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_products.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_products.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_products.Location = new System.Drawing.Point(0, 234);
            this.btn_products.Name = "btn_products";
            this.btn_products.Size = new System.Drawing.Size(201, 40);
            this.btn_products.TabIndex = 5;
            this.btn_products.Text = "Products";
            this.btn_products.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_products.UseVisualStyleBackColor = false;
            this.btn_products.Click += new System.EventHandler(this.btn_products_Click);
            // 
            // panel_profile
            // 
            this.panel_profile.Controls.Add(this.btn_logout);
            this.panel_profile.Controls.Add(this.btn_editPassword);
            this.panel_profile.Controls.Add(this.btn_editProfile);
            this.panel_profile.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_profile.Location = new System.Drawing.Point(0, 114);
            this.panel_profile.Name = "panel_profile";
            this.panel_profile.Size = new System.Drawing.Size(201, 120);
            this.panel_profile.TabIndex = 4;
            // 
            // btn_logout
            // 
            this.btn_logout.BackColor = System.Drawing.Color.Silver;
            this.btn_logout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_logout.FlatAppearance.BorderSize = 0;
            this.btn_logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_logout.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_logout.Location = new System.Drawing.Point(0, 80);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(201, 40);
            this.btn_logout.TabIndex = 5;
            this.btn_logout.Text = "Logout";
            this.btn_logout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_logout.UseVisualStyleBackColor = false;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // btn_editPassword
            // 
            this.btn_editPassword.BackColor = System.Drawing.Color.Silver;
            this.btn_editPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_editPassword.FlatAppearance.BorderSize = 0;
            this.btn_editPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editPassword.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editPassword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_editPassword.Location = new System.Drawing.Point(0, 40);
            this.btn_editPassword.Name = "btn_editPassword";
            this.btn_editPassword.Size = new System.Drawing.Size(201, 40);
            this.btn_editPassword.TabIndex = 4;
            this.btn_editPassword.Text = "Edit Password";
            this.btn_editPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_editPassword.UseVisualStyleBackColor = false;
            this.btn_editPassword.Click += new System.EventHandler(this.btn_editPassword_Click);
            // 
            // btn_editProfile
            // 
            this.btn_editProfile.BackColor = System.Drawing.Color.Silver;
            this.btn_editProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_editProfile.FlatAppearance.BorderSize = 0;
            this.btn_editProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editProfile.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editProfile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_editProfile.Location = new System.Drawing.Point(0, 0);
            this.btn_editProfile.Name = "btn_editProfile";
            this.btn_editProfile.Size = new System.Drawing.Size(201, 40);
            this.btn_editProfile.TabIndex = 3;
            this.btn_editProfile.Text = "Edit Profile";
            this.btn_editProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_editProfile.UseVisualStyleBackColor = false;
            this.btn_editProfile.Click += new System.EventHandler(this.btn_editProfile_Click);
            // 
            // btn_profile
            // 
            this.btn_profile.BackColor = System.Drawing.Color.LightSlateGray;
            this.btn_profile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_profile.FlatAppearance.BorderSize = 0;
            this.btn_profile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_profile.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_profile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_profile.Location = new System.Drawing.Point(0, 74);
            this.btn_profile.Name = "btn_profile";
            this.btn_profile.Size = new System.Drawing.Size(201, 40);
            this.btn_profile.TabIndex = 3;
            this.btn_profile.Text = "Profile";
            this.btn_profile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_profile.UseVisualStyleBackColor = false;
            this.btn_profile.Click += new System.EventHandler(this.btn_profile_Click);
            // 
            // btn_home
            // 
            this.btn_home.BackColor = System.Drawing.Color.LightSlateGray;
            this.btn_home.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_home.FlatAppearance.BorderSize = 0;
            this.btn_home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_home.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_home.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_home.Location = new System.Drawing.Point(0, 34);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(201, 40);
            this.btn_home.TabIndex = 2;
            this.btn_home.Text = "Home";
            this.btn_home.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_home.UseVisualStyleBackColor = false;
            this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
            // 
            // lbl_fname
            // 
            this.lbl_fname.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_fname.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fname.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_fname.Location = new System.Drawing.Point(0, 0);
            this.lbl_fname.Name = "lbl_fname";
            this.lbl_fname.Size = new System.Drawing.Size(201, 34);
            this.lbl_fname.TabIndex = 1;
            // 
            // panel_logo
            // 
            this.panel_logo.Controls.Add(this.pictureBox1);
            this.panel_logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_logo.Location = new System.Drawing.Point(0, 0);
            this.panel_logo.Name = "panel_logo";
            this.panel_logo.Size = new System.Drawing.Size(201, 62);
            this.panel_logo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel_header
            // 
            this.panel_header.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel_header.Controls.Add(this.btn_exit);
            this.panel_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_header.Location = new System.Drawing.Point(201, 0);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(592, 32);
            this.panel_header.TabIndex = 1;
            // 
            // btn_exit
            // 
            this.btn_exit.AutoSize = true;
            this.btn_exit.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_exit.Location = new System.Drawing.Point(568, 5);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(21, 24);
            this.btn_exit.TabIndex = 0;
            this.btn_exit.Text = "X";
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // panel_con
            // 
            this.panel_con.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_con.Location = new System.Drawing.Point(201, 32);
            this.panel_con.Name = "panel_con";
            this.panel_con.Size = new System.Drawing.Size(592, 582);
            this.panel_con.TabIndex = 2;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 614);
            this.Controls.Add(this.panel_con);
            this.Controls.Add(this.panel_header);
            this.Controls.Add(this.panel_sidemenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel_sidemenu.ResumeLayout(false);
            this.panel_content.ResumeLayout(false);
            this.panel_customers.ResumeLayout(false);
            this.panel_orders.ResumeLayout(false);
            this.panel_categories.ResumeLayout(false);
            this.panel_products.ResumeLayout(false);
            this.panel_profile.ResumeLayout(false);
            this.panel_logo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_sidemenu;
        private System.Windows.Forms.Panel panel_content;
        private System.Windows.Forms.Button btn_home;
        private System.Windows.Forms.Label lbl_fname;
        private System.Windows.Forms.Panel panel_logo;
        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.Panel panel_profile;
        private System.Windows.Forms.Button btn_editPassword;
        private System.Windows.Forms.Button btn_editProfile;
        private System.Windows.Forms.Button btn_profile;
        private System.Windows.Forms.Button btn_products;
        private System.Windows.Forms.Panel panel_customers;
        private System.Windows.Forms.Button btn_updateCus;
        private System.Windows.Forms.Button btn_addCus;
        private System.Windows.Forms.Button btn_customers;
        private System.Windows.Forms.Panel panel_orders;
        private System.Windows.Forms.Button btn_updateO;
        private System.Windows.Forms.Button btn_addO;
        private System.Windows.Forms.Button btn_orders;
        private System.Windows.Forms.Panel panel_categories;
        private System.Windows.Forms.Button btn_updateC;
        private System.Windows.Forms.Button btn_addC;
        private System.Windows.Forms.Button btn_categories;
        private System.Windows.Forms.Panel panel_products;
        private System.Windows.Forms.Button btn_updateP;
        private System.Windows.Forms.Button btn_addP;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel_con;
        private System.Windows.Forms.Label btn_exit;
    }
}