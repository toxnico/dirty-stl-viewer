using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kitware.VTK;

namespace DirtySTL
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDirtySTL());
            //init();


        }

        static private void init()
        {

            vtkSTLReader rdr = vtkSTLReader.New();
            rdr.SetFileName("BODY-EXTRUDEUR-WADE.stl");



            // Créer une géométrie sphérique
            /*vtkSphereSource sphere = vtkSphereSource.New();
            sphere.SetRadius(1.0);
            sphere.SetThetaResolution(18);
            sphere.SetPhiResolution(18);*/

            // Transforme la géométrie en primitives graphiques (OpenGL dans notre cas)
            vtkPolyDataMapper map = vtkPolyDataMapper.New();
            map.SetInput(rdr.GetOutput());

            // L'acteur représente l'entitée géométrique.
            // Il permet de définir sa position, son orientation, sa couleur, etc.
            vtkActor aSphere = new vtkActor();
            aSphere.SetMapper(map);
            aSphere.GetProperty().SetColor(0.8, 0.8, 0.8); // color blue

            // Nous créons un renderer qui va faire le rendu de notre entitée.
            vtkRenderer ren1 = vtkRenderer.New();
            ren1.AddActor(aSphere);
            ren1.SetBackground(1, 1, 1); // background color white

            // Nous créons une fenêtre de rendu
            vtkRenderWindow renWin = vtkRenderWindow.New();
            renWin.AddRenderer(ren1);
            renWin.SetSize(300, 300);

            // Nous créons un interactor qui permet de bouger la caméra.
            vtkRenderWindowInteractor iren = new vtkRenderWindowInteractor();
            iren.SetRenderWindow(renWin);

            // Nous lançons le rendu et l'interaction
            renWin.Render();
            iren.Start();

            
            ////// CLEANUP ///////
            rdr.Dispose();
            map.Dispose();
            aSphere.Dispose();
            ren1.Dispose();
            renWin.Dispose();
            iren.Dispose();

        }

        
    }
}
