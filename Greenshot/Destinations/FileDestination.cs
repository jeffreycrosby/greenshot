﻿#region Greenshot GNU General Public License

// Greenshot - a free and open source screenshot tool
// Copyright (C) 2007-2018 Thomas Braun, Jens Klingen, Robin Krom
// 
// For more information see: http://getgreenshot.org/
// The Greenshot project is hosted on GitHub https://github.com/greenshot/greenshot
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 1 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

#endregion

#region Usings

using System;
using System.ComponentModel.Composition;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Greenshot.Configuration;
using GreenshotPlugin.Controls;
using GreenshotPlugin.Core;
using GreenshotPlugin.Gfx;
using Dapplo.Ini;
using GreenshotPlugin.Interfaces;
using GreenshotPlugin.Interfaces.Plugin;
using Dapplo.Log;

#endregion

namespace Greenshot.Destinations
{
    /// <summary>
    ///     Description of FileSaveAsDestination.
    /// </summary>
    [Export(typeof(IDestination))]
    public class FileDestination : AbstractDestination
	{
		public const string DESIGNATION = "FileNoDialog";
		private static readonly LogSource Log = new LogSource();
		private static readonly ICoreConfiguration CoreConfig = IniConfig.Current.Get<ICoreConfiguration>();

		public override string Designation => DESIGNATION;

		public override string Description => Language.GetString(LangKey.quicksettings_destination_file);

		public override int Priority => 0;

		public override Keys EditorShortcutKeys => Keys.Control | Keys.S;

		public override Bitmap DisplayIcon => GreenshotResources.GetBitmap("Save.Image");

		public override ExportInformation ExportCapture(bool manuallyInitiated, ISurface surface, ICaptureDetails captureDetails)
		{
			var exportInformation = new ExportInformation(Designation, Description);
			bool outputMade;
			bool overwrite;
			string fullPath;
			// Get output settings from the configuration
			var outputSettings = new SurfaceOutputSettings();

			if (captureDetails?.Filename != null)
			{
				// As we save a pre-selected file, allow to overwrite.
				overwrite = true;
				Log.Info().WriteLine("Using previous filename");
				fullPath = captureDetails.Filename;
				outputSettings.Format = ImageOutput.FormatForFilename(fullPath);
			}
			else
			{
				fullPath = CreateNewFilename(captureDetails);
				// As we generate a file, the configuration tells us if we allow to overwrite
				overwrite = CoreConfig.OutputFileAllowOverwrite;
			}
			if (CoreConfig.OutputFilePromptQuality)
			{
				var qualityDialog = new QualityDialog(outputSettings);
				qualityDialog.ShowDialog();
			}

			// Catching any exception to prevent that the user can't write in the directory.
			// This is done for e.g. bugs #2974608, #2963943, #2816163, #2795317, #2789218, #3004642
			try
			{
				ImageOutput.Save(surface, fullPath, overwrite, outputSettings, CoreConfig.OutputFileCopyPathToClipboard);
				outputMade = true;
			}
			catch (ArgumentException ex1)
			{
				// Our generated filename exists, display 'save-as'
				Log.Info().WriteLine("Not overwriting: {0}", ex1.Message);
				// when we don't allow to overwrite present a new SaveWithDialog
				fullPath = ImageOutput.SaveWithDialog(surface, captureDetails);
				outputMade = fullPath != null;
			}
			catch (Exception ex2)
			{
				Log.Error().WriteLine(ex2, "Error saving screenshot!");
				// Show the problem
				MessageBox.Show(Language.GetString(LangKey.error_save), Language.GetString(LangKey.error));
				// when save failed we present a SaveWithDialog
				fullPath = ImageOutput.SaveWithDialog(surface, captureDetails);
				outputMade = fullPath != null;
			}
			// Don't overwrite filename if no output is made
			if (outputMade)
			{
				exportInformation.ExportMade = true;
				exportInformation.Filepath = fullPath;
				if (captureDetails != null)
				{
					captureDetails.Filename = fullPath;
				}
				CoreConfig.OutputFileAsFullpath = fullPath;
			}

			ProcessExport(exportInformation, surface);
			return exportInformation;
		}

		private static string CreateNewFilename(ICaptureDetails captureDetails)
		{
			string fullPath;
			Log.Info().WriteLine("Creating new filename");
			var pattern = CoreConfig.OutputFileFilenamePattern;
			if (string.IsNullOrEmpty(pattern))
			{
				pattern = "greenshot ${capturetime}";
			}
			var filename = FilenameHelper.GetFilenameFromPattern(pattern, CoreConfig.OutputFileFormat, captureDetails);
			CoreConfig.ValidateAndCorrectOutputFilePath();
			var filepath = FilenameHelper.FillVariables(CoreConfig.OutputFilePath, false);
			try
			{
				fullPath = Path.Combine(filepath, filename);
			}
			catch (ArgumentException)
			{
				// configured filename or path not valid, show error message...
				Log.Info().WriteLine("Generated path or filename not valid: {0}, {1}", filepath, filename);

				MessageBox.Show(Language.GetString(LangKey.error_save_invalid_chars), Language.GetString(LangKey.error));
				// ... lets get the pattern fixed....
				var dialogResult = new SettingsForm().ShowDialog();
				if (dialogResult == DialogResult.OK)
				{
					// ... OK -> then try again:
					fullPath = CreateNewFilename(captureDetails);
				}
				else
				{
					// ... cancelled.
					fullPath = null;
				}
			}
			return fullPath;
		}
	}
}