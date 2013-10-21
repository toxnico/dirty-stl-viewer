using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kitware.VTK;
using DirtySTL.classes;

namespace DirtySTL
{
    public partial class frmDirtySTL : Form
    {
        private String _currentDirectory;

        private vtkRenderer _renderer;
        private vtkRenderWindowInteractor _interactor;

        private STLLoader _stlLoader;

        private vtkCamera Camera
        {
            get
            {
                return _renderer.GetActiveCamera();
            }
        }

        public frmDirtySTL()
        {
            InitializeComponent();

            String[] args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                if (Directory.Exists(args[1]))
                    saveSetting("LastDirectory", args[1]);
            }
                
            _currentDirectory = loadSetting("LastDirectory").ToString();
            reloadFileList();
        }


        /// <summary>
        /// Crée un acteur pour l'objet fourni et l'ajoute au renderer
        /// </summary>
        /// <param name="polydata"></param>
        private void addActor(vtkPolyData polydata)
        {
            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInput(polydata);

            vtkActor act = vtkActor.New();
            act.SetMapper(mapper);
            
            _renderer.AddActor(act);
        }

        /// <summary>
        /// Crée les objets de base : renderer, axes, interactor.
        /// </summary>
        private void initBaseObjects()
        {
            // Nous créons un renderer qui va faire le rendu de notre entitée.
            _renderer = vtkRenderer.New();

            _stlLoader = new STLLoader(this._renderer);
            _stlLoader.VolumeColor = Properties.Settings.Default.VolumeColor;
            _stlLoader.EdgeColor = Properties.Settings.Default.EdgeColor;
            _stlLoader.ShowVolume = Properties.Settings.Default.ShowVolume;
            _stlLoader.ShowEdges = Properties.Settings.Default.ShowEdges;

            this.aretesToolStripMenuItem.Checked = (bool)loadSetting("ShowEdges");
            this.volumeToolStripMenuItem.Checked = (bool)loadSetting("ShowVolume");


            _renderer.SetBackground(1, 1, 1); // background color white
            
            vtkRenderCtl.RenderWindow.AddRenderer(_renderer);
            
            // Nous créons un interactor qui permet de bouger la caméra.
            _interactor = vtkRenderWindowInteractor.New();

            _interactor.SetRenderWindow(vtkRenderCtl.RenderWindow);

            //axes
            vtkAxes axes = vtkAxes.New();
            axes.SetScaleFactor(10);
            
            addActor(axes.GetOutput());

            /*
            //outil de mesure
            vtkDistanceWidget wdgDistance = vtkDistanceWidget.New();
            wdgDistance.SetInteractor(_interactor);
            wdgDistance.CreateDefaultRepresentation();
            ((vtkDistanceRepresentation)wdgDistance.GetRepresentation()).SetLabelFormat("%-#6.3g mm");
            wdgDistance.On();
            */

            Camera.SetPosition(0, 0, -300);

            vtkRenderCtl.RenderWindow.Render();

            _interactor.RenderEvt += _interactor_RenderEvt;

            vtkInteractorStyleSwitch style = vtkInteractorStyleSwitch.New();
            style.SetCurrentStyleToTrackballCamera();

            _interactor.SetInteractorStyle(style);

            _interactor.Start();
            
        }

        /// <summary>
        /// Refresh l'affichage de la position de la caméra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _interactor_RenderEvt(vtkObject sender, vtkObjectEventArgs e)
        {
            double x, y, z;
            x = Math.Round(Camera.GetPosition()[0], 1);
            y =  Math.Round(Camera.GetPosition()[1], 1);
            z =  Math.Round(Camera.GetPosition()[2], 1);
            String s = String.Format("Position : {0},{1},{2}", x, y, z);

            lblStatus.Text = s;
        }
                    
        private void Form1_Shown(object sender, EventArgs e)
        {
            initBaseObjects();
        }

        /// <summary>
        /// Charge la liste des STL contenus dans _currentDirectory (non récursif)
        /// </summary>
        private void reloadFileList()
        {
            reloadFileList(false);
        }
     
        /// <summary>
        /// Charge la liste des fichiers STL de _currentDirectory, récursivement ou pas,
        /// et remplit la listbox.
        /// </summary>
        private void reloadFileList(Boolean recursive)
        {
            if (!Directory.Exists(_currentDirectory))
                return;
            
            String[] file_arr = getFiles(_currentDirectory, "*.stl", recursive);

            listView1.Items.Clear();
            foreach (String file in file_arr)
            {
                ListViewItem itm = new ListViewItem();
                itm.Text = Path.GetFileName(file);
                FileInfo fi = new FileInfo(file);
                itm.Tag = fi;
                listView1.Items.Add(itm);
                
            }
        }

        /// <summary>
        /// Fait une recherche récursive selon l'extension
        /// </summary>
        /// <param name="_currentDirectory"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private String[] getFiles(String folder, String pattern, Boolean recursive)
        {
            List<String> lst = new List<String>();

            //Bloc try/catch dans le cas où certains répertoires seraient inaccessibles.
            try
            {
                String[] file_arr = Directory.GetFiles(folder, pattern);
                lst.AddRange(file_arr);

                //Chargement récursif?
                if (recursive)
                {
                    String[] folder_arr = Directory.GetDirectories(folder);
                    foreach (String f in folder_arr)
                        lst.AddRange(getFiles(f, pattern, recursive));
                }
            }
            catch (Exception)
            { }
            
            return lst.ToArray();
        }
        
        /// <summary>
        /// Sélection d'un fichier dans le navigateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count == 0)
                return;

            String path = listView1.SelectedItems[0].Tag.ToString();
            
            _stlLoader.load(path);
            
        }

        /// <summary>
        /// Ouvre le dossier du STL sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ouvrirLeRepertoireParentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count == 0)
                return;

            ListViewItem itm = listView1.SelectedItems[0];
            
            FileInfo fi = itm.Tag as FileInfo;

            Process p = new Process();
            p.StartInfo.FileName = "explorer.exe";
            p.StartInfo.Arguments = fi.Directory.FullName;

            p.Start();
        }

        /// <summary>
        /// Boite de sélection d'un répertoire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ouvrirRepertoireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            browseAndLoad(false);
        }

        private void browseAndLoad(Boolean recursive)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = _currentDirectory;

            if (fbd.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;

            _currentDirectory = fbd.SelectedPath;

            saveSetting("LastDirectory", _currentDirectory);

            reloadFileList(recursive);
        }

        /// <summary>
        /// Quitte l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Active / désactive l'affichage des arêtes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aretesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.aretesToolStripMenuItem.Checked = !this.aretesToolStripMenuItem.Checked;

            saveSetting("ShowEdges", this.aretesToolStripMenuItem.Checked);

            _stlLoader.ShowEdges = this.aretesToolStripMenuItem.Checked;

        }

        /// <summary>
        /// Mémorise un paramètre de l'application
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void saveSetting(String name, Object value)
        {
            Properties.Settings.Default[name] = value;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// charge un paramètre de l'application
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Object loadSetting(String name)
        {
            return Properties.Settings.Default[name];
        }

        /// <summary>
        /// Active / désactive l'affichage du volume
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void volumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.volumeToolStripMenuItem.Checked = !this.volumeToolStripMenuItem.Checked;

            saveSetting("ShowVolume", this.volumeToolStripMenuItem.Checked);

            _stlLoader.ShowVolume = this.volumeToolStripMenuItem.Checked;
        }

        private void chargerRepertoireRecursivementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            browseAndLoad(true);
        }
    }
}
