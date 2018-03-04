using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgMgr.Wpf.Models
{
	public class ImageCollection : ObservableCollection<ImageModel>
	{
		public ImageCollection()
		{ }

		public void AddImage(ImageModel image)
		{
			base.Add(image);
		}
	}
}
