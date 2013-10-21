namespace DirtySTL
{
    partial class frmDirtySTL
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDirtySTL));
            this.vtkRenderCtl = new Kitware.VTK.RenderWindowControl();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ouvrirLeRepertoireParentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblStatus = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chargerRepertoireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.affichageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aretesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chargerRepertoireRecursivementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vtkRenderCtl
            // 
            this.vtkRenderCtl.AddTestActors = false;
            resources.ApplyResources(this.vtkRenderCtl, "vtkRenderCtl");
            this.vtkRenderCtl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vtkRenderCtl.Name = "vtkRenderCtl";
            this.vtkRenderCtl.TestText = null;
            // 
            // listView1
            // 
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.HideSelection = false;
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ouvrirLeRepertoireParentToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // ouvrirLeRepertoireParentToolStripMenuItem
            // 
            this.ouvrirLeRepertoireParentToolStripMenuItem.Name = "ouvrirLeRepertoireParentToolStripMenuItem";
            resources.ApplyResources(this.ouvrirLeRepertoireParentToolStripMenuItem, "ouvrirLeRepertoireParentToolStripMenuItem");
            this.ouvrirLeRepertoireParentToolStripMenuItem.Click += new System.EventHandler(this.ouvrirLeRepertoireParentToolStripMenuItem_Click);
            // 
            // lblStatus
            // 
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.Name = "lblStatus";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.affichageToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chargerRepertoireToolStripMenuItem,
            this.chargerRepertoireRecursivementToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            resources.ApplyResources(this.fichierToolStripMenuItem, "fichierToolStripMenuItem");
            // 
            // chargerRepertoireToolStripMenuItem
            // 
            this.chargerRepertoireToolStripMenuItem.Name = "chargerRepertoireToolStripMenuItem";
            resources.ApplyResources(this.chargerRepertoireToolStripMenuItem, "chargerRepertoireToolStripMenuItem");
            this.chargerRepertoireToolStripMenuItem.Click += new System.EventHandler(this.ouvrirRepertoireToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            resources.ApplyResources(this.quitterToolStripMenuItem, "quitterToolStripMenuItem");
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // affichageToolStripMenuItem
            // 
            this.affichageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aretesToolStripMenuItem,
            this.volumeToolStripMenuItem});
            this.affichageToolStripMenuItem.Name = "affichageToolStripMenuItem";
            resources.ApplyResources(this.affichageToolStripMenuItem, "affichageToolStripMenuItem");
            // 
            // aretesToolStripMenuItem
            // 
            this.aretesToolStripMenuItem.Name = "aretesToolStripMenuItem";
            resources.ApplyResources(this.aretesToolStripMenuItem, "aretesToolStripMenuItem");
            this.aretesToolStripMenuItem.Click += new System.EventHandler(this.aretesToolStripMenuItem_Click);
            // 
            // volumeToolStripMenuItem
            // 
            this.volumeToolStripMenuItem.Name = "volumeToolStripMenuItem";
            resources.ApplyResources(this.volumeToolStripMenuItem, "volumeToolStripMenuItem");
            this.volumeToolStripMenuItem.Click += new System.EventHandler(this.volumeToolStripMenuItem_Click);
            // 
            // chargerRepertoireRecursivementToolStripMenuItem
            // 
            this.chargerRepertoireRecursivementToolStripMenuItem.Name = "chargerRepertoireRecursivementToolStripMenuItem";
            resources.ApplyResources(this.chargerRepertoireRecursivementToolStripMenuItem, "chargerRepertoireRecursivementToolStripMenuItem");
            this.chargerRepertoireRecursivementToolStripMenuItem.Click += new System.EventHandler(this.chargerRepertoireRecursivementToolStripMenuItem_Click);
            // 
            // frmDirtySTL
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.vtkRenderCtl);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmDirtySTL";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Kitware.VTK.RenderWindowControl vtkRenderCtl;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ouvrirLeRepertoireParentToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chargerRepertoireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem affichageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aretesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volumeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chargerRepertoireRecursivementToolStripMenuItem;
    }
}

