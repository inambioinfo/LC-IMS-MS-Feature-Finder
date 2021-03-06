﻿using System;
using System.IO;
using System.Linq;
using FeatureFinder.Control;
using FeatureFinder.Data;
using NUnit.Framework;

namespace FeatureFinder.FunctionalTests
{
    [TestFixture]
    public class SaturationRepairTesting
    {
        // see Redmine issue: http://redmine.pnl.gov/issues/947

        [Test]
        [Ignore("Missing_File")]
        public void saturatedMSFeatureDataProcessingTest1()
        {
            var sourceIsosFile =
                @"\\protoapps\UserData\Slysz\Data\Redmine_Issues\Issue947_saturationTesting\Sarc_P09_B06_0786_20Jul11_Cheetah_11-05-31_mass860_repaired_isos.csv";

            var copiedIsosFileName = @"\\protoapps\UserData\Slysz\Data\Redmine_Issues\Issue947_saturationTesting\Sarc_P09_B06_0786_20Jul11_Cheetah_11-05-31_isos.csv";

            File.Copy(sourceIsosFile, copiedIsosFileName, true);


            var testfile =
                @"\\protoapps\UserData\Slysz\Data\Redmine_Issues\Issue947_saturationTesting\FF_IMS4Filters_NoFlags_20ppm_Min3Pts_4MaxLCGap_NoDaCorr_ConfDtn_2011-05-16_issue947.ini";

            var iniReader = new IniReader(testfile);
            iniReader.CreateSettings();

            var isosReader = new IsosReader(Settings.InputFileName, Settings.OutputDirectory);

            var controller = new LCIMSMSFeatureFinderController(isosReader);
            controller.Execute();

            Assert.AreEqual(2, controller.LCimsmsFeatures.Count());

            var testFeature1 = (from n in controller.LCimsmsFeatures where n.Charge == 2 select n).FirstOrDefault();

            Assert.IsNotNull(testFeature1);

            DisplayFeatureStats(testFeature1);
        }

        [Test]
        [Ignore("Missing_File")]
        public void traditionalMSFeatureDataProcessingTest1()
        {

            var sourceIsosFile =
                @"\\protoapps\UserData\Slysz\Data\Redmine_Issues\Issue947_saturationTesting\Sarc_P09_B06_0786_20Jul11_Cheetah_11-05-31_mass860_noRepair_isos.csv";

            var copiedIsosFileName = @"\\protoapps\UserData\Slysz\Data\Redmine_Issues\Issue947_saturationTesting\Sarc_P09_B06_0786_20Jul11_Cheetah_11-05-31_isos.csv";

            File.Copy(sourceIsosFile, copiedIsosFileName, true);


            var testfile =
                @"\\protoapps\UserData\Slysz\Data\Redmine_Issues\Issue947_saturationTesting\FF_IMS4Filters_NoFlags_20ppm_Min3Pts_4MaxLCGap_NoDaCorr_ConfDtn_2011-05-16_issue947.ini";

            var iniReader = new IniReader(testfile);
            iniReader.CreateSettings();

            var isosReader = new IsosReader(Settings.InputFileName, Settings.OutputDirectory);

            var controller = new LCIMSMSFeatureFinderController(isosReader);
            controller.Execute();

            Assert.AreEqual(2, controller.LCimsmsFeatures.Count());

            var testFeature1 = (from n in controller.LCimsmsFeatures where n.Charge == 2 select n).FirstOrDefault();

            Assert.IsNotNull(testFeature1);

            DisplayFeatureStats(testFeature1);
        }


        [Test]
        [Ignore("Missing_File")]
        public void nonSaturatedMSFeatureProcessingTest1()
        {

            var sourceIsosFile =
                @"\\protoapps\UserData\Slysz\Data\Redmine_Issues\Issue947_saturationTesting\Sarc_P09_B06_0786_20Jul11_Cheetah_11-05-31_mass1064_repaired_isos.csv";

            var copiedIsosFileName = @"\\protoapps\UserData\Slysz\Data\Redmine_Issues\Issue947_saturationTesting\Sarc_P09_B06_0786_20Jul11_Cheetah_11-05-31_isos.csv";

            File.Copy(sourceIsosFile, copiedIsosFileName, true);


            var testfile =
                @"\\protoapps\UserData\Slysz\Data\Redmine_Issues\Issue947_saturationTesting\FF_IMS4Filters_NoFlags_20ppm_Min3Pts_4MaxLCGap_NoDaCorr_ConfDtn_2011-05-16_issue947.ini";

            var iniReader = new IniReader(testfile);
            iniReader.CreateSettings();

            var isosReader = new IsosReader(Settings.InputFileName, Settings.OutputDirectory);

            var controller = new LCIMSMSFeatureFinderController(isosReader);
            controller.Execute();



            Assert.AreEqual(1, controller.LCimsmsFeatures.Count());

            var testFeature1 = controller.LCimsmsFeatures.ElementAt(0);

            Assert.IsNotNull(testFeature1);
            Assert.AreEqual(22, testFeature1.GetMemberCount());
            Assert.AreEqual(0, testFeature1.GetSaturatedMemberCount());

            Assert.AreEqual(18.82, (decimal)Math.Round(testFeature1.DriftTime, 2));



            DisplayFeatureStats(testFeature1);
        }

        [Test]
        [Ignore("Missing_File")]
        public void nonSaturatedLowIntensityProcessingTest1()
        {
            var sourceIsosFile =
                @"\\protoapps\UserData\Slysz\Data\Redmine_Issues\Issue947_saturationTesting\Sarc_P09_B06_0786_20Jul11_Cheetah_11-05-31_lowIntensityCase860_repaired_isos.csv";

            var copiedIsosFileName = @"\\protoapps\UserData\Slysz\Data\Redmine_Issues\Issue947_saturationTesting\Sarc_P09_B06_0786_20Jul11_Cheetah_11-05-31_isos.csv";

            File.Copy(sourceIsosFile, copiedIsosFileName, true);


            var testfile =
                @"\\protoapps\UserData\Slysz\Data\Redmine_Issues\Issue947_saturationTesting\FF_IMS4Filters_NoFlags_20ppm_Min3Pts_4MaxLCGap_NoDaCorr_ConfDtn_2011-05-16_issue947.ini";

            var iniReader = new IniReader(testfile);
            iniReader.CreateSettings();

            var isosReader = new IsosReader(Settings.InputFileName, Settings.OutputDirectory);

            var controller = new LCIMSMSFeatureFinderController(isosReader);
            controller.Execute();

            Assert.AreEqual(2, controller.LCimsmsFeatures.Count());

            var testFeature1 = controller.LCimsmsFeatures.ElementAt(1);

            Assert.IsNotNull(testFeature1);
            Assert.AreEqual(20, testFeature1.GetMemberCount());
            Assert.AreEqual(0, testFeature1.GetSaturatedMemberCount());

            DisplayFeatureStats(testFeature1);

        }




        //This test is left commented out. It is useful for debugging
        //[Test]
        //public void processEntireIsosTraditionalTest1()
        //{
        //    string sourceIsosFile =
        //        @"\\protoapps\UserData\Slysz\Data\Redmine_Issues\Issue947_saturationTesting\Sarc_P09_B06_0786_20Jul11_Cheetah_11-05-31_DMSVersion_isos.csv";

        //    sourceIsosFile =
        //        @"C:\Users\d3x720\Documents\PNNL\My_DataAnalysis\2012\IMS_related\2012_01_27_Saturation_threshold_analysis\Sarc_P09_B06_0786_20Jul11_Cheetah_11-05-31_Sat90000_isos.csv";

        //    sourceIsosFile =
        //        @"C:\Users\d3x720\Documents\PNNL\My_DataAnalysis\2012\IMS_related\2012_01_27_Saturation_threshold_analysis\Sarc_P09_B06_0786_20Jul11_Cheetah_11-05-31_Original_isos.csv";

        //    //sourceIsosFile =
        //    //    @"\\protoapps\UserData\Slysz\Data\Redmine_Issues\temp\Sarc_P09_B06_0786_20Jul11_Cheetah_11-05-31_mass1064_repaired_isos.csv";

        //    sourceIsosFile =
        //        @"D:\Data\UIMF\Sarc_Main_Study_Controls\Sarc_P08_G02_0746_7Dec11_Cheetah_11-09-04_isos.csv";

        //    sourceIsosFile=
        //    @"D:\Data\UIMF\Sarc_Main_Study_Controls\Sarc_P08_A01_0673_21Nov11_Cheetah_11-09-03_isos.csv";


        //    sourceIsosFile =
        //        @"D:\Data\UIMF\Sarc_Main_Study_Controls\DrillDown_2012_03_20\Sarc_P27_A01_2497_12Dec11_Cheetah_11-09-34_filtered_filtered_isos.csv";


        //    string copiedIsosFileName = @"\\protoapps\UserData\Slysz\Data\Redmine_Issues\Issue947_saturationTesting\Sarc_P09_B06_0786_20Jul11_Cheetah_11-05-31_isos.csv";

        //    File.Copy(sourceIsosFile, copiedIsosFileName, true);


        //    string testfile =
        //        @"\\protoapps\UserData\Slysz\Data\Redmine_Issues\Issue947_saturationTesting\FF_IMS4Filters_NoFlags_20ppm_Min3Pts_4MaxLCGap_NoDaCorr_ConfDtn_2011-05-16_issue947.ini";
        //    var iniReader = new IniReader(testfile);
        //    iniReader.CreateSettings();

        //    var isosReader = new IsosReader(Settings.InputFileName, Settings.OutputDirectory);

        //    var controller = new LCIMSMSFeatureFinderController(isosReader);
        //    controller.Execute();

        //    FileInfo fileInfo = new FileInfo(sourceIsosFile);
        //    var directoryInfo = fileInfo.Directory;


        //    string sourceFeaturesFile = copiedIsosFileName.Replace("_isos.csv", "_LCMSFeatures.txt");
        //    string sourceLogFile = copiedIsosFileName.Replace("_isos.csv", "_FeatureFinder_Log.txt");

        //    string copiedFeaturesFile = directoryInfo.FullName + "\\" +
        //                                fileInfo.Name.Replace("_isos.csv", "_LCMSFeatures.txt");
        //    string copiedFeaturesLogFile = directoryInfo.FullName + "\\" +
        //                                fileInfo.Name.Replace("_isos.csv", "_FeatureFinder_Log.txt");

        //    //copy the LCMSFeatures file back to my working folder
        //    File.Copy(sourceFeaturesFile, copiedFeaturesFile,true);
        //    File.Copy(sourceLogFile, copiedFeaturesLogFile, true);


        //}


        //[Test]
        //public void processEntireIsosSaturationRepairedTest1()
        //{
        //    string sourceIsosFile =
        //        @"D:\Data\UIMF\Sarc_Main_Study_Controls\Sarc_P09_B06_0786_20Jul11_Cheetah_11-05-31_saturationFixed_all_2011_12_30_isos.csv";

        //    string copiedIsosFileName = @"\\protoapps\UserData\Slysz\Data\Redmine_Issues\Issue947_saturationTesting\Sarc_P09_B06_0786_20Jul11_Cheetah_11-05-31_isos.csv";

        //    File.Copy(sourceIsosFile, copiedIsosFileName, true);


        //    string testfile =
        //        @"\\protoapps\UserData\Slysz\Data\Redmine_Issues\Issue947_saturationTesting\FF_IMS4Filters_NoFlags_20ppm_Min3Pts_4MaxLCGap_NoDaCorr_ConfDtn_2011-05-16_issue947.ini";

        //    var iniReader = new IniReader(testfile);
        //    iniReader.CreateSettings();

        //    var isosReader = new IsosReader(Settings.InputFileName, Settings.OutputDirectory);

        //    var controller = new LCIMSMSFeatureFinderController(isosReader);
        //    controller.Execute();
        //}



        private void DisplayFeatureStats(LCIMSMSFeature testFeature1)
        {
            Console.WriteLine("OrigIndex= \t" + testFeature1.OriginalIndex);
            testFeature1.GetMinAndMaxScanLCAndScanIMSAndMSFeatureRep(
                out var scanLCMinimum, out var scanLCMaximum,
                out var scanIMSMinimum, out var scanIMSMaximum, out _);

            Console.WriteLine("FrameStart= \t" + scanLCMinimum);
            Console.WriteLine("FrameStop= \t" + scanLCMaximum);
            Console.WriteLine("IMSScan_Start= \t" + scanIMSMinimum);
            Console.WriteLine("IMSScan_Stop= \t" + scanIMSMaximum);
            Console.WriteLine("DriftTime= \t" + testFeature1.DriftTime);
            Console.WriteLine("monoMass = \t" + testFeature1.CalculateAverageMonoisotopicMass().ToString("0.0####"));
            Console.WriteLine("maxAbundance = \t" + testFeature1.AbundanceMaxRaw);
            Console.WriteLine("summedAbundance = \t" + testFeature1.AbundanceSumRaw);
            Console.WriteLine("totMemberCount = \t" + testFeature1.GetMemberCount());
            Console.WriteLine("totSaturated = \t" + testFeature1.GetSaturatedMemberCount());

        }
    }
}
