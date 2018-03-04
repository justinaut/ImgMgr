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
			

			dataGridImageCollection.AutoGenerateColumns = false;
			dataGridImageCollection.ItemsSource = Images;
			dataGridImageCollection.Columns.Add(new DataGridTextColumn() { Header = "Title", Binding = new Binding("Title") });
			dataGridImageCollection.Columns.Add(new DataGridTextColumn() { Header = "Date Created", Binding = new Binding("DateCreated") });
			dataGridImageCollection.Columns.Add(new DataGridTextColumn() { Header = "Description", Binding = new Binding("Description") });
		}

		private void dataGridImageCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			SelectedDataGridItem = (ImageModel)dataGridImageCollection.SelectedItem;
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
	}
}
