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

		/// <summary>
		/// Returns true if the given Id is found among the Images in the Collection
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool ContainsId(int id)
		{
			return this.Count(c => c.Id.Equals(id)) > 0;
		}
	}
}
