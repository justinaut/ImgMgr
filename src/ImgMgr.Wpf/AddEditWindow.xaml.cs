using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ImgMgr.Wpf.Models;

namespace ImgMgr.Wpf
{
	/// <summary>
	/// Interaction logic for EditWindow.xaml
	/// </summary>
	public partial class AddEditWindow : Window
	{
		ImageModel _imageModel;

		/// <summary>
		/// Constructor with ImageModel parameter represents an Edit Image Window.
		/// </summary>
		/// <param name="id"></param>
		public AddEditWindow(ImageModel model)
		{
			InitializeComponent();

			_imageModel = model;
			if (model.IsValid)
			{
				btnSave.Content = "Edit";
				this.Title = "Edit Image Information";
				tbTitle.Text = model.Title ?? "";
				tbFileLocation.Text = model.FileLocation ?? "";
				tbAuthor.Text = model.Author ?? "";
				tbDescription.Text = model.Description ?? "";
				tbKeywords.Text = model.Keywords ?? "";
				dpDateCreated.DisplayDate = model.DateCreated;
			}
			else
			{
				this.Title = "Add Image Information";
				btnSave.Content = "Add";
			}
		}

		private void btnOpen_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() ?? false)
			{
				tbFileLocation.Text = openFileDialog.FileName;
			}
		}

		private void btnSave_Click(object sender, RoutedEventArgs e)
		{
			_imageModel.FileLocation = tbFileLocation.Text;
			_imageModel.Title = tbTitle.Text;
			_imageModel.Description = tbDescription.Text;
			_imageModel.Author = tbAuthor.Text;
			_imageModel.DateCreated = dpDateCreated.DisplayDate;
			_imageModel.Keywords = tbKeywords.Text;

			if (_imageModel.IsValid)
			{
				this.DialogResult = true;
				this.Close();
			}
			else
			{
				string errorText = "Please ensure both a File Location and a Title are provided.";
				MessageBox.Show(errorText);
			}
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = false;
			this.Close();
		}
	}
}
