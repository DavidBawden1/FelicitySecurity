using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using FelicitySecurity.Services.Data.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace FelicitySecurity.Applications.Config.Resources.ImageProcessing.FaceRecognition
{
    public enum TrainingModel { fisherFaces, eigenFace, localBinaryPatternHistogram }
    public class SuspectFacialPrediction : IDisposable
    {
        #region Declarations
        FaceRecognizer facerec;
        #endregion

        #region Constructors
        public SuspectFacialPrediction ChooseTrainingModel(TrainingModel trainingModel)
        {
            var suspectFacialPrediction = new SuspectFacialPrediction();
            suspectFacialPrediction.ChooseTrainingModel(trainingModel);
            return suspectFacialPrediction;
        }
        #endregion

        #region Properties
        public List<Image<Gray, Byte>> TrainingImages
        {
            get;
            set;
        }

        public List<string> NameList
        {
            get;
            set;
        }

        public List<string> LastNameList
        {
            get;
            set;
        }

        public List<string> PostCodeList
        {
            get;
            set;
        }

        public List<int> PersonsID
        {
            get;
            set;
        }

        private int _numberOfLabels;
        public int NumberOfLables
        {
            get
            {
                return _numberOfLabels;
            }
            set
            {

            }
        }

        private float _neighbourDistance;
        /// <summary>
        /// The distance of neighbours within the Face
        /// </summary>
        public float NeighbourDistance
        {
            get
            {
                return _neighbourDistance = 1;
            }
            set
            {

            }
        }

        private string _nameLabel;
        public string NameLabel
        {
            get
            {
                return _nameLabel;
            }
            set
            {

            }
        }

        private string _lastNameLabel;
        public string LastNameLabel
        {
            get
            {
                return _lastNameLabel;
            }
            set
            {

            }
        }

        private string _postCodeLabel;
        public string PostCodeLabel
        {
            get
            {
                return _postCodeLabel;
            }
            set
            {

            }
        }

        private int _modelThreshold;
        public int ModelThreshold
        {
            get
            {
                return _modelThreshold;
            }
            set
            {

            }
        }

        private string _error;
        private string Error
        {
            get
            {
                return _error;
            }
            set
            {

            }
        }

        private bool _isDataSetPopulated = false;
        public bool IsDataSetPopulated
        {
            get
            {
                FelicitySecurityRepository repo = new FelicitySecurityRepository();
                var x = repo.FindAllMembersFaces();
                if (x.Count == 0)
                {
                    _isDataSetPopulated = false;
                }
                else
                {
                    _isDataSetPopulated = true;
                }
                return _isDataSetPopulated;
            }
            set
            {

            }
        }

        private string _recognizerType = "EMGU.CV.Face.FisherFaceRecognizer";
        public string RecognizerType
        {
            get
            {
                return _recognizerType;
            }
            set
            {

            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns a name on a successful recognition result
        /// </summary>
        /// <param name="inputImage"></param>
        /// <param name="threshold"></param>
        /// <returns>Positive matches name</returns>
        public string GetPositiveMatchOnFacialRecognition(Image<Gray, byte> inputImage, int threshold = -1)
        {
            //if the image is trained predict a result. 
            if (IsDataSetPopulated)
            {
                FaceRecognizer.PredictionResult FishR = facerec.Predict(inputImage);
                if (FishR.Label == -1)// -1 will be intruder but anything above -1 (positive)  will be a match. 
                {
                    _nameLabel = "Intruder Alert";
                    _neighbourDistance = 0;
                    return NameLabel;
                }
                else
                {
                    _nameLabel = NameList[FishR.Label];
                    _lastNameLabel = LastNameList[FishR.Label];
                    _postCodeLabel = PostCodeList[FishR.Label];
                    _neighbourDistance = (float)FishR.Distance;

                    if (_neighbourDistance > _modelThreshold)
                    {
                        _nameLabel = "Intruder Alert";
                        return _nameLabel;
                    }
                    else
                    {
                        return _nameLabel;
                    }
                }
            }
            return threshold.ToString();
        }

        /// <summary>
        ///Dispose of Class call Garbage Collector
        /// </summary>
        public void Dispose()
        {
            facerec = null;
            TrainingImages = null;
            NameList = null;
            LastNameList = null;
            PostCodeList = null;
            _error = null;
            GC.Collect();
        }

        /// <summary>
        /// Gets
        /// </summary>
        /// <param name="FolderLocation"></param>
        /// <returns></returns>
        private bool LoadTrainingData(string FolderLocation)
        {
            if (File.Exists(FolderLocation + "\\TrainedLabels.xml"))
            {
                try
                {
                    NameList.Clear();
                    LastNameList.Clear();
                    PostCodeList.Clear();
                    TrainingImages.Clear();

                    FileStream filestream = File.OpenRead(FolderLocation + "\\TrainedLabels.xml");
                    long filelength = filestream.Length;
                    byte[] xmlBytes = new byte[filelength];
                    filestream.Read(xmlBytes, 0, (int)filelength); //read the contents of the trained labels xml
                    filestream.Close();

                    MemoryStream xmlStream = new MemoryStream(xmlBytes);

                    using (XmlReader xmlreader = XmlTextReader.Create(xmlStream))
                    {
                        while (xmlreader.Read())
                        {
                            if (xmlreader.IsStartElement())
                            {
                                switch (xmlreader.Name)

                                {
                                    case "NAME":
                                        if (xmlreader.Read())
                                        {
                                            PersonsID.Add(NameList.Count); //0, 1, 2, 3....
                                            PersonsID.Add(LastNameList.Count);
                                            PersonsID.Add(PostCodeList.Count);
                                            NameList.Add(xmlreader.Value.Trim());
                                            LastNameList.Add(xmlreader.Value.Trim());
                                            PostCodeList.Add(xmlreader.Value.Trim());
                                            _numberOfLabels += 1;
                                        }
                                        break;
                                    case "SURNAME":
                                        if (xmlreader.Read())
                                        {
                                            PersonsID.Add(LastNameList.Count); //0, 1, 2, 3....
                                            NameList.Add(xmlreader.Value.Trim());
                                            LastNameList.Add(xmlreader.Value.Trim());
                                            PostCodeList.Add(xmlreader.Value.Trim());
                                            _numberOfLabels += 1;
                                        }
                                        break;
                                    case "POSTCODE":
                                        if (xmlreader.Read())
                                        {
                                            PersonsID.Add(PostCodeList.Count); //0, 1, 2, 3....
                                            NameList.Add(xmlreader.Value.Trim());
                                            LastNameList.Add(xmlreader.Value.Trim());
                                            PostCodeList.Add(xmlreader.Value.Trim());
                                            _numberOfLabels += 1;
                                        }
                                        break;
                                    case "FILE":
                                        if (xmlreader.Read())
                                        {
                                            TrainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "\\TrainingFolder\\" + xmlreader.Value.Trim()));
                                        }
                                        break;
                                }
                            }
                        }
                    }

                    if (TrainingImages.ToArray().Length != 0)
                    {
                        facerec = new FisherFaceRecognizer(10, 4000);
                        facerec.Train(TrainingImages.ToArray(), PersonsID.ToArray());
                        return true;
                    }
                    else return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else return false;
        }
        #endregion
    }
}
