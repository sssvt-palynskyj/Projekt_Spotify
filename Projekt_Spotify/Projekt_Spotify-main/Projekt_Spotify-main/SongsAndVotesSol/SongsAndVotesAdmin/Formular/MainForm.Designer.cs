
namespace SongsAndVotesAdmin.Formular
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.songsAndVotesUsersDataSet = new SongsAndVotesAdmin.SongsAndVotesUsersDataSet();
            this.songsAndVotesUsersDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.songsAndVotesUsersDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.songsAndVotesUsersDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.songsAndVotesUsersDataSetBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(59, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(685, 346);
            this.dataGridView1.TabIndex = 0;
            // 
            // songsAndVotesUsersDataSet
            // 
            this.songsAndVotesUsersDataSet.DataSetName = "SongsAndVotesUsersDataSet";
            this.songsAndVotesUsersDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // songsAndVotesUsersDataSetBindingSource
            // 
            this.songsAndVotesUsersDataSetBindingSource.DataSource = this.songsAndVotesUsersDataSet;
            this.songsAndVotesUsersDataSetBindingSource.Position = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.songsAndVotesUsersDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.songsAndVotesUsersDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource songsAndVotesUsersDataSetBindingSource;
        private SongsAndVotesUsersDataSet songsAndVotesUsersDataSet;
    }
}