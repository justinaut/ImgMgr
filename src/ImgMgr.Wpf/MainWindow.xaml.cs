using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ImgMgr.Wpf.Models;
using System.IO;

namespace ImgMgr.Wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		ImageCollection _images;
		ImageModel _selectedItem;
		public event PropertyChangedEventHandler PropertyChanged;
		

		public MainWindow()
		{
			InitializeComponent();
			_images = new ImageCollection();
		}

		private void ImgMgrMainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			AddDefaultImages();

			// TODO: How to specify date formatting?
			// TODO: How to specify a text wrap style?
			dataGridImageCollection.ItemsSource = Images;
			dataGridImageCollection.Columns.Add(new DataGridTextColumn() { Header = "Title", Binding = new Binding("Title") });
			dataGridImageCollection.Columns.Add(new DataGridTextColumn() { Header = "Date Created", Binding = new Binding("DateCreated") });
			dataGridImageCollection.Columns.Add(new DataGridTextColumn() { Header = "Description", Binding = new Binding("Description") });
		}

		private void dataGridImageCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (dataGridImageCollection.Items.Count > 0 && dataGridImageCollection.SelectedIndex < 0)
			{
				dataGridImageCollection.SelectedIndex = 0;
			}

			SelectedDataGridItem = Images[dataGridImageCollection.SelectedIndex];

			try
			{
				if (File.Exists(SelectedDataGridItem.FileLocation))
				{
					imgImageArea.Source = new BitmapImage(new Uri(SelectedDataGridItem.FileLocation));
				}
				else
				{
					imgImageArea.Source = null;
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine($"Exception: {exception.Message}");
			}
		}

		private void btnNewImage_Click(object sender, RoutedEventArgs e)
		{
			ImageModel blankImageInfo = new ImageModel();
			AddEditWindow addModifyWindow = new AddEditWindow(blankImageInfo);
			if (addModifyWindow.ShowDialog() ?? false)
			{
				Images.Add(blankImageInfo);
				dataGridImageCollection.Items.Refresh();

				// Set the newly added ImageModel to the Selected Image in the Data Grid
				dataGridImageCollection.SelectedIndex = Images.Count - 1;
			}
		}

		private void btnEditImage_Click(object sender, RoutedEventArgs e)
		{
			if (SelectedDataGridItem != null)
			{
				ImageModel doppleganger = new ImageModel();
				doppleganger.CopyFrom(SelectedDataGridItem);

				AddEditWindow addModifyWindow = new AddEditWindow(doppleganger);
				if (addModifyWindow.ShowDialog() ?? false)
				{
					SelectedDataGridItem.CopyFrom(doppleganger);
				}
			}
		}

		private void AddDefaultImages()
		{
			Images.Add(new ImageModel(
				"The Devil Put Dinosaurs Here",
				new DateTime(2013, 5, 28),
				DateTime.Now,
				"Alice In Chains: The Devil Put Dinosaurs Here",
				"Alice In Chains",
				"album cover art",
				@"C:\Users\Justin\Desktop\Images\AIC_devil_put_dinosaurs_here.png"));

			Images.Add(new ImageModel(
				"Alaska Yukon Pacific Expo", 
				new DateTime(1909, 6, 1), 
				DateTime.Now, 
				"Originally published as a postcard that was released concurrently with the A-Y-P Exposition in 1909.", 
				"University of Washington", 
				"Alaska, Yukon, Pacific, AYP, Mount Ranier", 
				@"C:\Users\Justin\Desktop\Images\Alaska_Yukon_Pacific_Exposition_Rainier_Vista.jpg"));

			Images.Add(new ImageModel(
				"Rosetta Spacecraft", 
				new DateTime(2014, 10, 14),
				DateTime.Now,
				"The Rosetta spacecraft's selfie, 16km from a comet's surface.",
				"ESA",
				"space, comet",
				@"C:\Users\Justin\Desktop\Images\Rosetta_mission_selfie_at_16_km.png"));

			Images.Add(new ImageModel(
				"So Far From Home",
				new DateTime(2017, 9, 11),
				DateTime.Now,
				"One of Cassini's final looks at the planet Saturn.",
				"NASA",
				"space, planet",
				@"C:\Users\Justin\Desktop\Images\Saturn.jpg"));

			Images.Add(new ImageModel(
				"Shell background",
				@"C:\Users\Justin\Desktop\Images\ShellBackground.jpg"));

			// Add an ImageModel with a file path leading to no file
			Images.Add(new ImageModel(
				"Sometimes Accidents Happen",
				new DateTime(2018, 3, 8),
				DateTime.Now,
				"Test record to see how a bad file path is handled.",
				"Justin",
				"oops, my bad",
				@"C:\Users\Justin\Desktop\Images\no-image-here.jpg"));
		}

		/// <summary>
		/// Invokes the PropertyChanged event. 
		/// Helper method called by Properties.
		/// </summary>
		/// <param name="property"></param>
		private void NotifyChanged(string property)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
			}
		}

		#region Properties

		public ImageCollection Images
		{
			get { return _images; }
			set { _images = value; }
		}

		public ImageModel SelectedDataGridItem
		{
			get { return _selectedItem; }
			set
			{
				_selectedItem = value;
				NotifyChanged("SelectedDataGridItem");
			}
		}

		#endregion

		private void btnSearch_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
