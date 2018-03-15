using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgMgr.Wpf.Models
{
	public class ImageModel : INotifyPropertyChanged
	{
		private int _id;
		private string _title;
		private DateTime _dateCreated;
		private DateTime _dateAdded;
		private string _description;
		private string _author;
		private string _keywords;
		private string _fileLocation;
		private static int LastId = 0;
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Constructor with zero parameters allows an empty ImageModel to be created.
		/// </summary>
		public ImageModel() : this("", "")
		{ }

		/// <summary>
		/// Simple ImageModel constructor requiring only Title and File Location.
		/// </summary>
		/// <param name="title"></param>
		/// <param name="fileLocation"></param>
		public ImageModel(string title, string fileLocation)
			: this(title, DateTime.Now, DateTime.Now, "", "", "", fileLocation)
		{ }

		/// <summary>
		/// Full ImageModel constructor.
		/// </summary>
		/// <param name="title"></param>
		/// <param name="dateCreated"></param>
		/// <param name="dateAdded"></param>
		/// <param name="description"></param>
		/// <param name="author"></param>
		/// <param name="keywords"></param>
		/// <param name="fileLocation"></param>
		public ImageModel(string title, DateTime dateCreated, DateTime dateAdded, string description, string author, string keywords, string fileLocation)
		{
			Id = NextId();
			Title = title;
			DateCreated = dateCreated;
			DateAdded = dateAdded;
			Description = description;
			Author = author;
			Keywords = keywords;
			FileLocation = fileLocation;
		}

		/// <summary>
		/// NextId ensures there is an incrementing ID applied to each instance of ImageModel.
		/// </summary>
		/// <returns></returns>
		private int NextId() { return ++LastId; }

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

		/// <summary>
		/// Copy Properties (except Id) from one ImageModel into this ImageModel.
		/// </summary>
		/// <param name="model"></param>
		public void CopyFrom(ImageModel model)
		{
			this.Title = model.Title;
			this.FileLocation = model.FileLocation;
			this.Author = model.Author;
			this.DateAdded = model.DateAdded;
			this.DateCreated = model.DateCreated;
			this.Description = model.Description;
			this.Keywords = model.Keywords;
		}

		#region Properties

		/// <summary>
		/// The ImageModel is valid when both Title and File Location are non-null and non-whitespace strings.
		/// </summary>
		public bool IsValid
		{
			get { return (!string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(FileLocation)); }
		}

		public int Id
		{
			get { return _id; }
			private set
			{
				_id = value;
				NotifyChanged("Id");
			}
		}

		public string Title
		{
			get { return _title; }
			set
			{
				_title = value;
				NotifyChanged("Title");
			}
		}

		public DateTime DateCreated
		{
			get { return _dateCreated; }
			set
			{
				_dateCreated = value;
				NotifyChanged("DateCreated");
			}
		}

		public DateTime DateAdded
		{
			get { return _dateAdded; }
			set
			{
				_dateAdded = value;
				NotifyChanged("DateAdded");
			}
		}

		public string Description
		{
			get { return _description; }
			set
			{
				_description = value;
				NotifyChanged("Description");
			}
		}

		public string Author
		{
			get { return _author; }
			set
			{
				_author = value;
				NotifyChanged("Author");
			}
		}

		public string Keywords
		{
			get { return _keywords; }
			set
			{
				_keywords = value;
				NotifyChanged("Keywords");
			}
		}

		public string FileLocation
		{
			get { return _fileLocation; }
			set
			{
				_fileLocation = value;
				NotifyChanged("FileLocation");
			}
		}
		#endregion
	}
}
