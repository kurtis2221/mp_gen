namespace mp_gen_cfg
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dt_nr_stat = new System.Windows.Forms.NumericUpDown();
            this.dt_game = new System.Windows.Forms.TextBox();
            this.dt_update = new System.Windows.Forms.NumericUpDown();
            this.dt_port = new System.Windows.Forms.NumericUpDown();
            this.lb_split = new System.Windows.Forms.Label();
            this.bt_load = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dt_st_cur = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dt_st_addr = new System.Windows.Forms.TextBox();
            this.dt_st_val = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dt_st_ptr = new System.Windows.Forms.CheckBox();
            this.dt_st_offs = new System.Windows.Forms.DataGridView();
            this.offs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dt_pl_addr = new System.Windows.Forms.TextBox();
            this.dt_pl_ptr = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dt_nt_addr = new System.Windows.Forms.TextBox();
            this.dt_nt_ptr = new System.Windows.Forms.CheckBox();
            this.dt_pl_offs = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dt_nt_offs = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dt_buffer = new System.Windows.Forms.NumericUpDown();
            this.dt_offset = new System.Windows.Forms.TextBox();
            this.dt_base = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dt_nr_addr = new System.Windows.Forms.NumericUpDown();
            this.dt_st_addrc = new System.Windows.Forms.NumericUpDown();
            this.bt_reset = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.dt_maxpl = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dt_nr_stat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_update)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_port)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_st_cur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_st_offs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_pl_offs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_nt_offs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_buffer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_nr_addr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_st_addrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_maxpl)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Update interval (ms)";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Game EXE";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Number of states";
            // 
            // dt_nr_stat
            // 
            this.dt_nr_stat.Location = new System.Drawing.Point(146, 79);
            this.dt_nr_stat.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.dt_nr_stat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dt_nr_stat.Name = "dt_nr_stat";
            this.dt_nr_stat.Size = new System.Drawing.Size(64, 20);
            this.dt_nr_stat.TabIndex = 3;
            this.dt_nr_stat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dt_game
            // 
            this.dt_game.Location = new System.Drawing.Point(146, 54);
            this.dt_game.Name = "dt_game";
            this.dt_game.Size = new System.Drawing.Size(128, 20);
            this.dt_game.TabIndex = 2;
            // 
            // dt_update
            // 
            this.dt_update.Location = new System.Drawing.Point(146, 31);
            this.dt_update.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.dt_update.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.dt_update.Name = "dt_update";
            this.dt_update.Size = new System.Drawing.Size(64, 20);
            this.dt_update.TabIndex = 1;
            this.dt_update.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // dt_port
            // 
            this.dt_port.Location = new System.Drawing.Point(146, 7);
            this.dt_port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.dt_port.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dt_port.Name = "dt_port";
            this.dt_port.Size = new System.Drawing.Size(128, 20);
            this.dt_port.TabIndex = 0;
            this.dt_port.Value = new decimal(new int[] {
            7777,
            0,
            0,
            0});
            // 
            // lb_split
            // 
            this.lb_split.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_split.Location = new System.Drawing.Point(0, 112);
            this.lb_split.Name = "lb_split";
            this.lb_split.Size = new System.Drawing.Size(594, 2);
            this.lb_split.TabIndex = 4;
            // 
            // bt_load
            // 
            this.bt_load.Location = new System.Drawing.Point(454, 12);
            this.bt_load.Name = "bt_load";
            this.bt_load.Size = new System.Drawing.Size(128, 24);
            this.bt_load.TabIndex = 19;
            this.bt_load.Text = "Load File";
            this.bt_load.UseVisualStyleBackColor = true;
            this.bt_load.Click += new System.EventHandler(this.bt_load_Click);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(454, 42);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(128, 24);
            this.bt_save.TabIndex = 20;
            this.bt_save.Text = "Save File";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = "State";
            // 
            // dt_st_cur
            // 
            this.dt_st_cur.Location = new System.Drawing.Point(146, 127);
            this.dt_st_cur.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.dt_st_cur.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dt_st_cur.Name = "dt_st_cur";
            this.dt_st_cur.Size = new System.Drawing.Size(59, 20);
            this.dt_st_cur.TabIndex = 6;
            this.dt_st_cur.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dt_st_cur.ValueChanged += new System.EventHandler(this.dt_st_cur_ValueChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "Address";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "State value";
            // 
            // dt_st_addr
            // 
            this.dt_st_addr.Location = new System.Drawing.Point(146, 150);
            this.dt_st_addr.Name = "dt_st_addr";
            this.dt_st_addr.Size = new System.Drawing.Size(128, 20);
            this.dt_st_addr.TabIndex = 7;
            this.dt_st_addr.Text = "00000000";
            this.dt_st_addr.Validated += new System.EventHandler(this.dt_st_addr_Validated);
            // 
            // dt_st_val
            // 
            this.dt_st_val.Location = new System.Drawing.Point(146, 174);
            this.dt_st_val.Name = "dt_st_val";
            this.dt_st_val.Size = new System.Drawing.Size(128, 20);
            this.dt_st_val.TabIndex = 8;
            this.dt_st_val.Validated += new System.EventHandler(this.dt_st_addr_Validated);
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(0, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(594, 2);
            this.label8.TabIndex = 9;
            // 
            // dt_st_ptr
            // 
            this.dt_st_ptr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dt_st_ptr.Location = new System.Drawing.Point(304, 127);
            this.dt_st_ptr.Name = "dt_st_ptr";
            this.dt_st_ptr.Size = new System.Drawing.Size(150, 24);
            this.dt_st_ptr.TabIndex = 11;
            this.dt_st_ptr.Text = "Pointer";
            this.dt_st_ptr.UseVisualStyleBackColor = true;
            this.dt_st_ptr.CheckedChanged += new System.EventHandler(this.dt_st_ptr_CheckedChanged);
            // 
            // dt_st_offs
            // 
            this.dt_st_offs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_st_offs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_st_offs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.offs});
            this.dt_st_offs.Enabled = false;
            this.dt_st_offs.Location = new System.Drawing.Point(304, 157);
            this.dt_st_offs.Name = "dt_st_offs";
            this.dt_st_offs.Size = new System.Drawing.Size(275, 90);
            this.dt_st_offs.TabIndex = 11;
            this.dt_st_offs.TabStop = false;
            this.dt_st_offs.Visible = false;
            this.dt_st_offs.Validated += new System.EventHandler(this.dt_st_offs_Validated);
            // 
            // offs
            // 
            this.offs.HeaderText = "Offsets";
            this.offs.Name = "offs";
            this.offs.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.offs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(13, 306);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 24);
            this.label9.TabIndex = 6;
            this.label9.Text = "Address";
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(296, 260);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(2, 210);
            this.label10.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(12, 272);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(278, 24);
            this.label11.TabIndex = 6;
            this.label11.Text = "Player";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(304, 272);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(278, 24);
            this.label12.TabIndex = 6;
            this.label12.Text = "Network";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dt_pl_addr
            // 
            this.dt_pl_addr.Location = new System.Drawing.Point(147, 303);
            this.dt_pl_addr.Name = "dt_pl_addr";
            this.dt_pl_addr.Size = new System.Drawing.Size(128, 20);
            this.dt_pl_addr.TabIndex = 12;
            this.dt_pl_addr.Text = "00000000";
            this.dt_pl_addr.Validated += new System.EventHandler(this.dt_st_addr_Validated);
            // 
            // dt_pl_ptr
            // 
            this.dt_pl_ptr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dt_pl_ptr.Location = new System.Drawing.Point(12, 333);
            this.dt_pl_ptr.Name = "dt_pl_ptr";
            this.dt_pl_ptr.Size = new System.Drawing.Size(150, 24);
            this.dt_pl_ptr.TabIndex = 13;
            this.dt_pl_ptr.Text = "Pointer";
            this.dt_pl_ptr.UseVisualStyleBackColor = true;
            this.dt_pl_ptr.CheckedChanged += new System.EventHandler(this.dt_st_ptr_CheckedChanged);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(305, 306);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 24);
            this.label13.TabIndex = 6;
            this.label13.Text = "Address";
            // 
            // dt_nt_addr
            // 
            this.dt_nt_addr.Location = new System.Drawing.Point(439, 303);
            this.dt_nt_addr.Name = "dt_nt_addr";
            this.dt_nt_addr.Size = new System.Drawing.Size(128, 20);
            this.dt_nt_addr.TabIndex = 14;
            this.dt_nt_addr.Text = "00000000";
            this.dt_nt_addr.Validated += new System.EventHandler(this.dt_st_addr_Validated);
            // 
            // dt_nt_ptr
            // 
            this.dt_nt_ptr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dt_nt_ptr.Location = new System.Drawing.Point(304, 333);
            this.dt_nt_ptr.Name = "dt_nt_ptr";
            this.dt_nt_ptr.Size = new System.Drawing.Size(150, 24);
            this.dt_nt_ptr.TabIndex = 15;
            this.dt_nt_ptr.Text = "Pointer";
            this.dt_nt_ptr.UseVisualStyleBackColor = true;
            this.dt_nt_ptr.CheckedChanged += new System.EventHandler(this.dt_st_ptr_CheckedChanged);
            // 
            // dt_pl_offs
            // 
            this.dt_pl_offs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_pl_offs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_pl_offs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dt_pl_offs.Enabled = false;
            this.dt_pl_offs.Location = new System.Drawing.Point(12, 363);
            this.dt_pl_offs.Name = "dt_pl_offs";
            this.dt_pl_offs.Size = new System.Drawing.Size(278, 90);
            this.dt_pl_offs.TabIndex = 11;
            this.dt_pl_offs.TabStop = false;
            this.dt_pl_offs.Visible = false;
            this.dt_pl_offs.Validated += new System.EventHandler(this.dt_st_offs_Validated);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Offsets";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dt_nt_offs
            // 
            this.dt_nt_offs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_nt_offs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_nt_offs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.dt_nt_offs.Enabled = false;
            this.dt_nt_offs.Location = new System.Drawing.Point(304, 363);
            this.dt_nt_offs.Name = "dt_nt_offs";
            this.dt_nt_offs.Size = new System.Drawing.Size(278, 90);
            this.dt_nt_offs.TabIndex = 11;
            this.dt_nt_offs.TabStop = false;
            this.dt_nt_offs.Visible = false;
            this.dt_nt_offs.Validated += new System.EventHandler(this.dt_st_offs_Validated);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Offsets";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Location = new System.Drawing.Point(0, 469);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(594, 2);
            this.label14.TabIndex = 13;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(13, 486);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(128, 24);
            this.label15.TabIndex = 6;
            this.label15.Text = "Data size (bytes)";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(301, 486);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(128, 24);
            this.label16.TabIndex = 6;
            this.label16.Text = "Data offset";
            // 
            // dt_buffer
            // 
            this.dt_buffer.Location = new System.Drawing.Point(147, 484);
            this.dt_buffer.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.dt_buffer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dt_buffer.Name = "dt_buffer";
            this.dt_buffer.Size = new System.Drawing.Size(64, 20);
            this.dt_buffer.TabIndex = 16;
            this.dt_buffer.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.dt_buffer.Validated += new System.EventHandler(this.dt_buffer_Validated);
            // 
            // dt_offset
            // 
            this.dt_offset.Location = new System.Drawing.Point(439, 483);
            this.dt_offset.Name = "dt_offset";
            this.dt_offset.Size = new System.Drawing.Size(128, 20);
            this.dt_offset.TabIndex = 17;
            this.dt_offset.Text = "0";
            this.dt_offset.Validated += new System.EventHandler(this.dt_st_addr_Validated);
            // 
            // dt_base
            // 
            this.dt_base.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dt_base.Location = new System.Drawing.Point(432, 76);
            this.dt_base.Name = "dt_base";
            this.dt_base.Size = new System.Drawing.Size(150, 24);
            this.dt_base.TabIndex = 5;
            this.dt_base.Text = "Use base address";
            this.dt_base.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(12, 201);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(128, 24);
            this.label17.TabIndex = 6;
            this.label17.Text = "Number of addresses";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(13, 225);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(128, 24);
            this.label18.TabIndex = 6;
            this.label18.Text = "Current address";
            // 
            // dt_nr_addr
            // 
            this.dt_nr_addr.Location = new System.Drawing.Point(146, 199);
            this.dt_nr_addr.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.dt_nr_addr.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dt_nr_addr.Name = "dt_nr_addr";
            this.dt_nr_addr.Size = new System.Drawing.Size(59, 20);
            this.dt_nr_addr.TabIndex = 9;
            this.dt_nr_addr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dt_nr_addr.ValueChanged += new System.EventHandler(this.dt_buffer_Validated);
            // 
            // dt_st_addrc
            // 
            this.dt_st_addrc.Location = new System.Drawing.Point(146, 223);
            this.dt_st_addrc.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.dt_st_addrc.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dt_st_addrc.Name = "dt_st_addrc";
            this.dt_st_addrc.Size = new System.Drawing.Size(59, 20);
            this.dt_st_addrc.TabIndex = 10;
            this.dt_st_addrc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dt_st_addrc.ValueChanged += new System.EventHandler(this.dt_st_addrc_ValueChanged);
            // 
            // bt_reset
            // 
            this.bt_reset.Location = new System.Drawing.Point(320, 12);
            this.bt_reset.Name = "bt_reset";
            this.bt_reset.Size = new System.Drawing.Size(128, 24);
            this.bt_reset.TabIndex = 18;
            this.bt_reset.Text = "Reset";
            this.bt_reset.UseVisualStyleBackColor = true;
            this.bt_reset.Click += new System.EventHandler(this.bt_reset_Click);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(216, 81);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(128, 24);
            this.label19.TabIndex = 0;
            this.label19.Text = "Max Players";
            // 
            // dt_maxpl
            // 
            this.dt_maxpl.Location = new System.Drawing.Point(350, 79);
            this.dt_maxpl.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.dt_maxpl.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.dt_maxpl.Name = "dt_maxpl";
            this.dt_maxpl.Size = new System.Drawing.Size(64, 20);
            this.dt_maxpl.TabIndex = 4;
            this.dt_maxpl.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 522);
            this.Controls.Add(this.dt_offset);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dt_nt_offs);
            this.Controls.Add(this.dt_pl_offs);
            this.Controls.Add(this.dt_st_offs);
            this.Controls.Add(this.dt_nt_ptr);
            this.Controls.Add(this.dt_pl_ptr);
            this.Controls.Add(this.dt_base);
            this.Controls.Add(this.dt_st_ptr);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dt_st_val);
            this.Controls.Add(this.dt_nt_addr);
            this.Controls.Add(this.dt_pl_addr);
            this.Controls.Add(this.dt_st_addr);
            this.Controls.Add(this.dt_st_addrc);
            this.Controls.Add(this.dt_nr_addr);
            this.Controls.Add(this.dt_st_cur);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.bt_reset);
            this.Controls.Add(this.bt_load);
            this.Controls.Add(this.lb_split);
            this.Controls.Add(this.dt_port);
            this.Controls.Add(this.dt_game);
            this.Controls.Add(this.dt_buffer);
            this.Controls.Add(this.dt_update);
            this.Controls.Add(this.dt_maxpl);
            this.Controls.Add(this.dt_nr_stat);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dt_nr_stat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_update)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_port)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_st_cur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_st_offs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_pl_offs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_nt_offs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_buffer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_nr_addr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_st_addrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_maxpl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown dt_nr_stat;
        private System.Windows.Forms.TextBox dt_game;
        private System.Windows.Forms.NumericUpDown dt_update;
        private System.Windows.Forms.NumericUpDown dt_port;
        private System.Windows.Forms.Label lb_split;
        private System.Windows.Forms.Button bt_load;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown dt_st_cur;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox dt_st_addr;
        private System.Windows.Forms.TextBox dt_st_val;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox dt_st_ptr;
        private System.Windows.Forms.DataGridView dt_st_offs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox dt_pl_addr;
        private System.Windows.Forms.CheckBox dt_pl_ptr;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox dt_nt_addr;
        private System.Windows.Forms.CheckBox dt_nt_ptr;
        private System.Windows.Forms.DataGridView dt_pl_offs;
        private System.Windows.Forms.DataGridView dt_nt_offs;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown dt_buffer;
        private System.Windows.Forms.TextBox dt_offset;
        private System.Windows.Forms.CheckBox dt_base;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown dt_nr_addr;
        private System.Windows.Forms.NumericUpDown dt_st_addrc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn offs;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button bt_reset;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown dt_maxpl;
    }
}