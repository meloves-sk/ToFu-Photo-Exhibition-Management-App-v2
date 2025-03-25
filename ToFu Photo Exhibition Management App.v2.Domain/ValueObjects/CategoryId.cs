using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects
{
	public class CategoryId : ValueObject<CategoryId>
	{
		public CategoryId(int value)
		{
			Value = value;
		}
		public int Value { get; }
		protected override bool EqualsCore(CategoryId other)
		{
			return Value == other.Value;
		}
	}
}
