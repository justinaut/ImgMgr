using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgMgr.Wpf.Models
{
	public class ImageModel
	{
		private int _id;
		private string _title;
		private DateTime _dateCreated;
		private DateTime _dateAdded;
		private string _description;
		private string _author;
		private string _keywords;
		private string _fileLocation;

		public ImageModel()
		{ }

		public int Id
		{
			get { return _id; }
			private set
			{
				_id = value;
			}
		}

		public string Title
		{
			get { return _title; }
			set
			{
				_title = value;
			}
		}

		public DateTime DateCreated
		{
			get { return _dateCreated; }
			set
			{
				_dateCreated = value;
			}
		}

		public DateTime DateAdded
		{
			get { return _dateAdded; }
			set
			{
				_dateAdded = value;
			}
		}

		public string Description
		{
			get { return _description; }
			set
			{
				_description = value;
			}
		}

		public string Author
		{
			get { return _author; }
			set
			{
				_author = value;
			}
		}

		public string Keywords
		{
			get { return _keywords; }
			set
			{
				_keywords = value;
			}
		}

		public string FileLocation
		{
			get { return _fileLocation; }
			set
			{
				_fileLocation = value;
			}
		}
	}
}
