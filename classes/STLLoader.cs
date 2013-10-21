using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitware.VTK;

namespace DirtySTL.classes
{
    public class STLLoader
    {
        private vtkRenderer _renderer;
        private vtkSTLReader _stlReader;
        private vtkPolyDataMapper _volumeMapper;
        private vtkActor _volumeActor;

        private vtkExtractEdges _edgeExtractor;
        private vtkPolyDataMapper _edgeMapper;
        private vtkActor _edgeActor;

        private Color _volumeColor;
        private Color _edgeColor;
        private Boolean _showEdges;
        private Boolean _showVolume;

        /// <summary>
        /// Couleur du volume
        /// </summary>
        public Color VolumeColor
        {
            get { return _volumeColor; }
            set
            {
                _volumeColor = value;
                Render();
            }
        }

        /// <summary>
        /// Couleur des aretes
        /// </summary>
        public Color EdgeColor
        {
            get { return _edgeColor; }
            set
            {
                _edgeColor = value;
                Render();
            }
        }

        /// <summary>
        /// Affiche le volume
        /// </summary>
        public Boolean ShowVolume
        {
            get { return _showVolume; }
            set
            {
                if (value == _showVolume)
                    return;

                _showVolume = value;

                if (!_showVolume)
                    _renderer.RemoveActor(_volumeActor);
                else
                    _renderer.AddActor(_volumeActor);

                Render();
            }
        }

        /// <summary>
        /// Affiche les arêtes
        /// </summary>
        public Boolean ShowEdges
        {
            get { return _showEdges; }
            set
            {
                if (value == _showEdges)
                    return;

                _showEdges = value;

                if (!_showEdges)
                    _renderer.RemoveActor(_edgeActor);
                else
                    _renderer.AddActor(_edgeActor);

                Render();
            }
        }
        
        public STLLoader(vtkRenderer renderer)
        {
            
            vtkPolyDataMapper.SetResolveCoincidentTopologyToPolygonOffset();
 
            this._renderer = renderer;
        }

        /// <summary>
        /// Charge le ficheir STL fourni en parametre.
        /// Si un STL est déjà chargé, on le décharge avant.
        /// </summary>
        /// <param name="filePath"></param>
        public void load(String filePath)
        {
            //décharge les objets existants
            this.destroy();

            _stlReader = vtkSTLReader.New();
            _stlReader.SetFileName(filePath);
            
            createVolumeObjects();
            createEdgeObjects();

            if(ShowVolume)
                _renderer.AddActor(this._volumeActor);

            if(ShowEdges)
                _renderer.AddActor(this._edgeActor);

            Render();
        }

        public void Render()
        {
            try
            {
                _renderer.GetRenderWindow().Render();
            }
            catch (Exception)
            {

            }

        }

        private double[] colorToRGB(Color c)
        {
            double[] rgb = new double[3];

            rgb[0] = (double)c.R / (double)255;
            rgb[1] = (double)c.G / (double)255;
            rgb[2] = (double)c.B / (double)255;

            return rgb;
        }

        /// <summary>
        /// Crée le nécessaire pour l'affichage du volume
        /// </summary>
        private void createVolumeObjects()
        {
            _volumeMapper = vtkPolyDataMapper.New();
            _volumeMapper.SetInput(_stlReader.GetOutput());
            _volumeActor = vtkActor.New();

            //couleur du volume
            double[] rgb=colorToRGB(VolumeColor);
            _volumeActor.GetProperty().SetColor(rgb[0], rgb[1], rgb[2]);
            _volumeActor.SetMapper(_volumeMapper);

        }

        /// <summary>
        /// Crée le nécessaire pour l'affichage des  arêtes
        /// </summary>
        private void createEdgeObjects()
        {
            _edgeExtractor = vtkExtractEdges.New();
            _edgeExtractor.SetInput(_stlReader.GetOutput());
            _edgeMapper = vtkPolyDataMapper.New();
            _edgeMapper.SetInput(_edgeExtractor.GetOutput());
            _edgeActor = vtkActor.New();

            double[] rgb = colorToRGB(EdgeColor);

            //couleurs des aretes
            _edgeActor.GetProperty().SetColor(rgb[0], rgb[1], rgb[2]);
            _edgeActor.SetMapper(_edgeMapper);
            
        }

        /// <summary>
        /// Détruit proprement les objets
        /// </summary>
        public void destroy()
        {

            _renderer.RemoveActor(_volumeActor);
            
            if (_stlReader != null)
                _stlReader.Dispose();

            if (_volumeMapper != null)
                _volumeMapper.Dispose();

            if (_volumeActor != null)
            {
                _renderer.RemoveActor(_volumeActor);
                _volumeActor.Dispose();
            }

            if (_edgeMapper != null)
                _edgeMapper.Dispose();

            if (_edgeActor != null)
            {
                _renderer.RemoveActor(_edgeActor);
                _edgeActor.Dispose();
            }

            Render();

        }

    }
}
